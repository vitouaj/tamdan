<script setup lang="ts">
import Layout from "./Layout.vue";
document.addEventListener("DOMContentLoaded", function () {
  const calendarEl = document.getElementById("calendar");

  // --- Customization ---
  // Define color mappings for different courses
  const colorMap = {
    english: {
      bg: "bg-blue-100",
      border: "border-blue-500",
      text: "text-blue-800",
    },
    history: {
      bg: "bg-indigo-100",
      border: "border-indigo-500",
      text: "text-indigo-800",
    },
    default: {
      bg: "bg-gray-100",
      border: "border-gray-500",
      text: "text-gray-800",
    },
  };

  const calendar = new FullCalendar.Calendar(calendarEl, {
    // 1. Use the Tailwind theme
    themeSystem: "tailwind",

    // 2. Configure Header Toolbar
    headerToolbar: {
      left: "",
      center: "title",
      right: "dayGridMonth,timeGridWeek,timeGridDay",
    },

    // 3. Set initial view and date
    initialView: "timeGridWeek",
    initialDate: "2025-06-10",

    // 4. Set the visible time range
    slotMinTime: "07:00:00", // Start displaying at 7:00 AM
    slotMaxTime: "18:00:00", // Stop displaying slots at 7:00 PM

    // 5. Make it interactive
    editable: true,
    selectable: true,

    // 6. Sample events data
    events: [
      {
        title: "English Class",
        start: "2025-06-10T07:00:00",
        end: "2025-06-10T11:00:00",
        extendedProps: {
          // Use extendedProps for custom data
          course: "english",
        },
      },
      {
        title: "History Lab",
        start: "2025-06-11T08:00:00",
        end: "2025-06-11T10:00:00",
        extendedProps: {
          course: "history",
        },
      },
    ],

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
});
</script>

<template>
  <Layout>
    <div class="w-full">
      <div id="calendar" class="px-[3rem] pt-[3rem] h-full"></div>
    </div>
  </Layout>
</template>
