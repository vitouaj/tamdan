<script setup lang="ts">
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { ref, toRaw } from "vue";
import ModalContent, { Course } from "./ModalContent.vue";
import HttpClient from "../api/httpRequests";
import { createCourse } from "../api/controllers";
const props = defineProps({
  courses: {
    type: Array,
  },
  user: Object,
});

const dtb = ref(null);
function getSelectedRows() {
  let selected = dtb.value.getSelectedRows();
}

const columns = [
  { data: "subject", title: "Subject" }, // Maps to course
  { data: "level", title: "Level" },
  { data: "teacherName", title: "Teacher Name" },
  { data: "courseDays", title: "Course Days" },
  { data: "courseTimes", title: "Course Time" },
  //   { data: "teacherName", title: "Taught By" },
];

const course = ref<Course>();

async function handleSaveRecord(event) {
  let data = event.detail;
  let coursePayload = {
    level: data.level,
    maxScore: data.maxScore,
    passingRate: 1,
    DayOfWeeks: toRaw(data.courseDays),
    TimeOfDays: toRaw(data.courseTimes),
  };
  console.log(coursePayload);
  if (data) {
    const result = await createCourse(coursePayload);
    console.log(result);
  }
}
</script>

<template>
  <!-- create modal -->
  <ModalContent :course="course" @saverecord="handleSaveRecord" />
  <!-- end create modal -->

  <template v-if="courses">
    <template v-if="user?.role == 1">
      <p class="text-xl font-bold">Available Courses</p>
      <div class="datatable-action mt-4 mb-2 flex justify-end">
        <button
          class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
          @click="getSelectedRows"
        >
          Enroll
        </button>
      </div>
    </template>
    <template v-if="user?.role == 2">
      <p class="text-xl font-bold">My Courses</p>
      <div class="datatable-action mt-4 mb-2 flex justify-end gap-2">
        <button
          class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
          type="button"
          aria-haspopup="dialog"
          aria-expanded="false"
          aria-controls="basic-modal"
          data-overlay="#basic-modal"
          @click="getSelectedRows"
        >
          Create new
        </button>
        <button
          type="button"
          aria-haspopup="dialog"
          aria-expanded="false"
          aria-controls="basic-modal"
          data-overlay="#basic-modal"
          class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
          @click="getSelectedRows"
        >
          Update Course
        </button>
      </div>
    </template>
    <FlyonDatatable
      ref="dtb"
      :key="courses.length"
      :columns="columns"
      :data="courses"
    />
  </template>
</template>
