<template>
  <div id="calendar"></div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { defineProps } from "vue";
import { DateTimeUtility } from "../api/utility";
import { computed } from "vue";
const props = defineProps({
  courses: {
    type: Array,
    default: () => [],
  },
  occupiedHours: {
    type: Array,
    default: () => [],
  },
});

function renderCalendar(mapEvents) {
  const calendarEl = document.getElementById("calendar");
  if (calendarEl) {
    const calendar = new FullCalendar.Calendar(calendarEl, {
      initialView: "timeGridWeek",
      headerToolbar: {
        center: "title",
        left: "timeGridWeek,timeGridDay",
      },
      events: mapEvents,
    });
    calendar.render();
  }
}

onMounted(() => {
  let mapEvents = DateTimeUtility.mapEventsOccupiedHours(props.occupiedHours);
  console.log("mapEvents", mapEvents);
  renderCalendar(mapEvents);
});
</script>
