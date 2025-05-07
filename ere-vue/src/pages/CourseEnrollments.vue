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
  <template v-if="enrollments.length > 0">
    <p class="text-xl font-bold">My Courses</p>
    <div class="datatable-action mt-6 mb-4 flex justify-end">
      <button
        class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
        @click="getSelectedRows"
      >
        Enroll
      </button>
    </div>
    <FlyonDatatable :columns="columns" :data="enrollments" />
  </template>
</template>
