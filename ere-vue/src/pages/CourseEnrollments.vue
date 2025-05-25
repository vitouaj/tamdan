<script setup lang="ts">
import { computed, onMounted, ref, toRaw } from "vue";
import { enroll, loadAvailableCourse } from "../api/controllers";
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { notify } from "../api/utility";

const columns = [
  { data: "subject", title: "Subject" }, // Maps to subject (teacher)
  { data: "teacherName", title: "Teacher Name" }, // Maps to course
  { data: "levelId", title: "Level" },
  { data: "maxScore", title: "Max score" },
  { data: "passingRate", title: "Passing Rate" },
];

interface Course {
  id: number;
  subject: string;
  teacherName: string;
  levelId: number;
  maxScore: number;
  passingRate: number;
}

const props = defineProps({
  enrollments: {
    type: Array,
    default: () => [],
  },
});

const emit = defineEmits(["enroll", "refreshHomeViewData"]);
const courses = ref<Course[]>([]);
const dtb = ref();
const loading = ref(false);

onMounted(() => {
  getAvailableCourses();
});

async function getAvailableCourses() {
  let result = await loadAvailableCourse();
  if (result) {
    courses.value = result.payload.courses;
  }
}

async function handleEnroll() {
  let selectedRows = dtb.value.getSelectedRows();
  selectedRows = toRaw(selectedRows);
  let courseIds: number[] = [];
  for (let i = 0; i < selectedRows?.length; i++) {
    courseIds.push(selectedRows[i].id);
  }
  if (courseIds?.length > 0) {
    let result = await enroll(courseIds.map(String));
    if (result?.success) {
      getAvailableCourses();
      emit("refreshHomeViewData");
    } else {
      notify({
        type: "type-error",
        message: result?.message,
      });
    }
  } else if (courseIds?.length == 0) {
    notify({
      type: "type-error",
      message: "Please select any course first!",
    });
  }
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
      :key="coursesDisplay.length"
      :columns="columns"
      :data="coursesDisplay"
    />
  </template>
</template>
