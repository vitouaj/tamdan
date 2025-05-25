<script setup lang="ts">
import { computed, onMounted, ref, toRaw } from "vue";
import { enroll, loadAvailableCourse } from "../api/controllers";
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { notify, Utility } from "../api/utility";
import { getMyEnrollments } from "../api/controllers";

const columns = [
  { data: "subject", title: "Subject" }, // Maps to subject (teacher)
  { data: "teacherName", title: "Teacher Name" }, // Maps to course
  { data: "levelId", title: "Level" },
  { data: "maxScore", title: "Max score" },
  { data: "passingRate", title: "Passing Rate" },
];

const courseEnrollmentDetail = [
  // { data: "studentName", title: "Student Name" }, // Maps to course
  { data: "courseName", title: "Subject" },
  { data: "enrollmentDate", title: "Enrollment Date" },
  { data: "status", title: "Status" },
];

interface Course {
  id: number;
  subject: string;
  teacherName: string;
  levelId: number;
  maxScore: number;
  passingRate: number;
}

// const props = defineProps({
//   enrollments: {
//     type: Object,
//     default: () => {},
//   },
// });

function parseEnrollmentArray(enrollments) {
  if (enrollments == undefined) {
    return [];
  }
  for (let i = 0; i < enrollments?.length; i++) {
    enrollments[i].courseName = Utility.allCapsToPascalCase(
      enrollments[i].courseName
    );
    enrollments[i].status = Utility.allCapsToPascalCase(enrollments[i].status);
  }
  return enrollments;
}

const emit = defineEmits(["enroll", "refreshHomeViewData"]);
const courses = ref<Course[]>([]);
const myEnrollments = ref([]);
const dtb = ref();
const dtbstudentenrollment = ref();
const displayMyEnrollment = ref(true);
const loading = ref(false);

onMounted(async () => {
  await getAvailableCourses();
  await loadMyEnrollment();
});

async function getAvailableCourses() {
  let result = await loadAvailableCourse();
  if (result) {
    courses.value = result.payload.courses;
  }
}

async function loadMyEnrollment() {
  let result = await getMyEnrollments();
  if (result) {
    let enrollments = result.payload.enrollments;
    myEnrollments.value = parseEnrollmentArray(enrollments);
  }
}

async function handleEnroll() {
  displayMyEnrollment.value = false;
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
      loadMyEnrollment();
      emit("refreshHomeViewData");
      setTimeout(() => {
        displayMyEnrollment.value = true;
      }, 500);
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
  <div v-if="coursesDisplay">
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
  </div>
  <div v-if="myEnrollments?.length > 0">
    <p class="text-xl font-bold">My Enrollments</p>
    <FlyonDatatable
      ref="dtbstudentenrollment"
      :key="courseEnrollmentDetail.length"
      :columns="courseEnrollmentDetail"
      :data="myEnrollments"
    />
  </div>
</template>
