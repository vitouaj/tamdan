<script setup lang="ts">
import { defineEmits, computed } from "vue";

const emit = defineEmits(["goback"]);

const props = defineProps({
  selectedReport: {
    type: Object,
  },
});

const greenStatus = ["FEEDBACK_RECIEVED", "READY"];

const conputedStatusStyle = computed(() => {
  if (greenStatus.includes(props.selectedReport?.report?.status)) {
    return "text-green-500 text-sm p-1 rounded bg-green-300";
  }
});
</script>

<template>
  <template v-if="selectedReport?.status !== 'N/A'">
    <span
      @click="emit('goback')"
      class="icon-[tabler--arrow-back-up] size-8"
    ></span>

    <div class="grid grid-cols-4 gap-4 p-10">
      <div class="col-span-2">
        <h2 class="text-xl font-bold">Report of {{ selectedReport?.name }}</h2>
        <p class="text-gray-600">{{ selectedReport?.report?.id }}</p>
        <p class="text-gray-600">
          Student Name: {{ selectedReport?.report?.studentName }}
        </p>
        <div class="card-actions">
          <div :class="conputedStatusStyle">
            {{ selectedReport?.report?.status.toLocaleLowerCase() }}
          </div>
        </div>
      </div>
      <div class="col-span-2 text-right">
        <p class="text-xl font-bold">Student Information</p>
        <p class="text-gray-600">
          {{ selectedReport?.report?.studentId }}
        </p>
        <p class="text-gray-600">
          {{ selectedReport?.report?.studentEmail }}
        </p>
        <p class="text-gray-600">Level {{ selectedReport?.report?.levelId }}</p>
      </div>
      <table class="w-full col-span-4 mx-auto border-collapse">
        <thead>
          <tr>
            <th class="text-start">Subject</th>
            <th class="text-start">Teacher Name</th>
            <th class="text-start">Score</th>
            <th class="text-start">Status</th>
            <th class="text-start">Number of absense</th>
            <th class="text-start">Comment</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="courseReport in selectedReport?.report?.courseReports">
            <td>{{ courseReport.subject }}</td>
            <td>{{ courseReport.teacherName }}</td>
            <td>{{ courseReport.score }}</td>
            <td>{{ courseReport.statusId }}</td>
            <td>{{ courseReport.absences }}</td>
            <td>{{ courseReport.teacherCmt }}</td>
          </tr>
        </tbody>
      </table>

      <div class="col-span-3">
        <div>
          <h2 class="text-xl font-bold">Overall Performance</h2>
          <p class="text-gray-600">
            Total Score: {{ selectedReport?.report?.totalScore }}
          </p>
          <p class="text-gray-600">
            Average Score: {{ selectedReport?.report?.averageScore }}
          </p>
          <p class="text-gray-600">
            Overall Grade: {{ selectedReport?.report?.overallGrade }}
          </p>
          <p class="text-gray-600">
            Absences: {{ selectedReport?.report?.totalAbsence }}
          </p>
        </div>
        <div class="mt-4">
          <h2 class="text-xl font-bold">Comments</h2>
          <p class="text-gray-600">
            {{ selectedReport?.report?.parentCmt }}
          </p>
        </div>
      </div>
    </div>
  </template>
  <template v-else>
    <span
      @click="emit('goback')"
      class="icon-[tabler--arrow-back-up] size-8"
    ></span>

    <div class="grid grid-cols-4 gap-4 p-10">
      <div class="col-span-4 mx-auto">Report is not ready</div>
    </div>
  </template>
</template>
