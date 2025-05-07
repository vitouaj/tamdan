<script setup lang="ts">
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { ref } from "vue";
const props = defineProps({
  courses: {
    type: Array,
  },
});

const dtb = ref(null);
function getSelectedRows() {
  let selected = dtb.value.getSelectedRows();
  console.log(selected);
}

const columns = [
  { data: "subject", title: "Subject" }, // Maps to course
  { data: "level", title: "Level" },
  { data: "teacherName", title: "Teacher Name" },
  { data: "courseDays", title: "Course Days" },
  { data: "courseTimes", title: "Course Time" },
  //   { data: "teacherName", title: "Taught By" },
];
</script>

<template>
  <template v-if="courses">
    <p class="text-xl font-bold">Available Courses</p>
    <div class="datatable-action mt-6 mb-4 flex justify-end">
      <button
        class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
        @click="getSelectedRows"
      >
        Enroll
      </button>
    </div>
    <FlyonDatatable
      ref="dtb"
      :key="courses.length"
      :columns="columns"
      :data="courses"
    />
  </template>
</template>
