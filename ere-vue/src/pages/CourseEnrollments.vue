<script setup lang="ts">
import { computed, onMounted, ref, toRaw } from "vue";
import { enroll, loadAvailableCourse } from "../api/controllers";
import FlyonDatatable from "../components/FlyonDatatable.vue";

const props = defineProps({
  enrollments: {
    type: Array,
    default: () => [],
  },
});
const emit = defineEmits(["enroll"]);
const courses = ref([]);
const dtb = ref();
const loading = ref(false);

async function getAvailableCourses() {
  let result = await loadAvailableCourse();
  if (result) {
    courses.value = result.payload.courses;
  }
}

async function handleEnroll() {
  let selectedRows = dtb.value.getSelectedRows();
  selectedRows = toRaw(selectedRows);
  let courseIds = [];
  for (let i = 0; i < selectedRows.length; i++) {
    courseIds.push(selectedRows[i].id);
  }
  let result = await enroll(courseIds);

  // remove selected rows from available courses
  // update data table
}

const coursesDisplay = computed(() => {
  return courses.value.map((course) => {
    return {
      id: course.id,
      subject: course.subject,
      teacherName: course.teacherName,
      levelId: course.levelId,
      maxScore: course.maxScore,
      passingRate: course.passingRate,
    };
  });
});

onMounted(() => {
  getAvailableCourses();
});

// levelId
// :
// 7
// maxScore
// :
// 100
// name
// :
// 100
// passingRate
// :
// 50
// subject
// :
// "Science"
// teacherName
// :
// "string string"

const columns = [
  { data: "subject", title: "Subject" }, // Maps to subject (teacher)
  { data: "teacherName", title: "Teacher Name" }, // Maps to course
  { data: "levelId", title: "Level" },
  { data: "maxScore", title: "Max score" },
  { data: "passingRate", title: "Passing Rate" },
];
</script>

<template>
  <template v-if="coursesDisplay">
    <p class="text-xl font-bold">Available Course</p>
    <div class="datatable-action mt-4 mb-2 flex justify-end">
      <button
        @click="handleEnroll"
        class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
      >
        Enroll
      </button>
    </div>
    <FlyonDatatable
      ref="dtb"
      v-if="coursesDisplay.length > 0"
      :key="coursesDisplay.length"
      :columns="columns"
      :data="coursesDisplay"
    />
  </template>
</template>
