<script setup lang="ts">
import FlyonDatatable from "../components/FlyonDatatable.vue";

const props = defineProps({
  enrollments: {
    type: Array,
    default: () => [],
  },
});

const columns = [
  { data: "teacherName", title: "Subject" }, // Maps to subject (teacher)
  { data: "courseName", title: "Course" }, // Maps to course
  { data: "enrollmentDate", title: "Enrollment Date" },
  { data: "completionDate", title: "Completion Date" },
  { data: "studentName", title: "Student Name" },
  { data: "studentEmail", title: "Student Email" },
];
</script>

<template>
  <template v-if="enrollments">
    <p class="text-xl font-bold">Enrollments</p>
    <div class="datatable-action mt-4 mb-2 flex justify-end">
      <button
        class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
      >
        Enroll
      </button>
    </div>
    <FlyonDatatable :columns="columns" :data="enrollments" />
  </template>
</template>
