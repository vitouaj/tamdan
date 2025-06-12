<script setup lang="ts">
import { defineProps, ref } from "vue";
import { Util } from "../api/Utility";
import { onMounted } from "vue";

const props = defineProps({
  user: Object,
});

const occupiedHours = ref();

function renderCalendar(mapEvents) {
  const calendarEl = document.getElementById("calendar");
  if (calendarEl) {
    const colorMap = {
      ENGLISH: {
        bg: "bg-blue-100",
        border: "border-blue-500",
        text: "text-blue-800",
      },
      HISTORY: {
        bg: "bg-indigo-100",
        border: "border-indigo-500",
        text: "text-indigo-800",
      },
      MATH: {
        bg: "bg-gray-100",
        border: "border-gray-500",
        text: "text-gray-800",
      },
    };
    const calendar = new FullCalendar.Calendar(calendarEl, {
      themeSystem: "tailwind",

      // 2. Configure Header Toolbar
      headerToolbar: {
        left: "",
        center: "title",
        right: "dayGridMonth,timeGridWeek,timeGridDay",
      },

      initialView: "timeGridWeek",

      slotMinTime: "07:00:00", // Start displaying at 7:00 AM
      slotMaxTime: "18:00:00", // Stop displaying slots at 7:00 PM

      // 5. Make it interactive
      editable: true,
      selectable: true,
      events: mapEvents,

      // 7. CUSTOM EVENT RENDERING
      // This is where we inject our custom Tailwind HTML for events
      eventContent: function (arg) {
        const course = arg.event.extendedProps.course || "default";
        const colors = colorMap[course];

        let eventHtml = `
                        <div class="p-1.5 w-full h-full ${colors.bg} ${colors.border} border-l-4 rounded-r-md overflow-hidden flex flex-col justify-center">
                            <b class="font-semibold text-xs ${colors.text} whitespace-normal">${arg.event.title}</b>
                            <p class="text-xs ${colors.text}">${arg.timeText}</p>
                        </div>
                    `;

        return { html: eventHtml };
      },
    });
    calendar.render();
  }
}

onMounted(() => {
  let mapEvents = Util.mapEventsOccupiedHours(props.user.occupiedHours, true);
  renderCalendar(mapEvents);
});
</script>

<template>
  {{ occupiedHours }}
  <div class="w-full">
    <div id="calendar" class="px-[3rem] pt-[3rem]"></div>
  </div>
</template>
