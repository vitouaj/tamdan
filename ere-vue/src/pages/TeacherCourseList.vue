<script setup lang="ts">
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { computed, onMounted, ref, toRaw } from "vue";
import {
  deleteCourses,
  handleApproveRequestedEnrollments,
  upsertCourse,
} from "../api/controllers";
import Loading from "./Loading.vue";
import { DAY_OF_WEEK, TIMES_OF_DAY, LEVEL, notify } from "../api/utility";
import CModal from "../components/Modals/CModal.vue";

const columns = [
  { data: "subject", title: "Subject" }, // Maps to course
  { data: "level", title: "Level" },
  { data: "teacherName", title: "Teacher Name" },
];

const courseEnrollmentDetail = [
  { data: "studentName", title: "Student Name" }, // Maps to course
  { data: "level", title: "Level" },
  { data: "enrollmentDate", title: "Enrollment Date" },
  { data: "status", title: "Status" },
];

const props = defineProps({
  courses: {
    type: Array,
  },
  enrollments: {
    type: Object,
  },
  user: Object,
  occupiedHours: {
    type: Array,
  },
});

export interface Course {
  level: Number;
  maxScore: Number;
  passingRate: Number;
  courseHours: Array<CourseHour>;
}

export interface CourseHour {
  day: Number;
  time: Number;
}

const emit = defineEmits(["refreshHomeViewData", "saverecord", "goback"]);
const daysOfWeeek = DAY_OF_WEEK;
const levels = LEVEL;
const timesOfDay = TIMES_OF_DAY;
const timeOptions = ref([]);
const selectedDay = ref(0);
const dtb = ref(null);
const dtbStudentEnrollments = ref(null);
const createModal = ref(null);
const loading = ref(null);
const options = ref({});
const initialOptions = ref();
const selectedToDisplay = ref("");
const showDeleteModal = ref(false);
const showCreateModal = ref(false);
const showViewDetail = ref(false);
const selectedEnrollmentsToView = ref([]);
const course = ref<Course>({
  level: 1,
  maxScore: 100,
  passingRate: 1,
  courseHours: [
    {
      day: 0,
      time: 0,
    },
  ],
});

onMounted(() => {
  initialOptions.value = props.occupiedHours;
  options.value = parseOccupiedHours(props.occupiedHours);
});

async function handleSaveRecord(event) {
  // loading.value?.stateLoading(true); // show loading
  let selectElement = document.getElementById("courseTimes");
  const selectedValues = [];
  for (let i = 0; i < selectElement.options.length; i++) {
    if (selectElement.options[i].selected) {
      selectedValues.push(selectElement.options[i].value);
    }
  }
  course.value.courseHours = [];
  for (let i = 0; i < selectedValues.length; i++) {
    course.value.courseHours.push({
      day: parseInt(selectedDay.value),
      time: parseInt(selectedValues[i]),
    });
  }

  let data = course.value;
  let coursePayload = {
    level: data.level,
    maxScore: data.maxScore,
    passingRate: 1,
    courseHours: data.courseHours,
  };
  if (data) {
    const result = await upsertCourse(coursePayload);
    let success = result?.success;
    if (success) {
      emit("refreshHomeViewData");
      showCreateModal.value = false;
    }
  }
  showCreateModal.value = false;
  clearForm();
  setTimeout(() => {
    dtb.value.setData(props.courses);
  }, 500);
}

function parseOccupiedHours(occupiedHours) {
  occupiedHours = toRaw(occupiedHours);
  let options = {};
  for (let key of Object.keys(DAY_OF_WEEK)) {
    options[key] = [];
    for (let time of Object.keys(TIMES_OF_DAY)) {
      options[key].push({
        time: time,
        disabled: false,
      });
    }
  }
  for (let och of occupiedHours) {
    let day = och?.dayOfWeek;
    let time = och?.timeOfDay;
    let currentOptions = options[day];
    for (let i = 0; i < currentOptions.length; i++) {
      if (currentOptions[i].time == time) {
        currentOptions[i].disabled = true;
      }
    }
    options[day] = currentOptions;
  }
  return options;
}

async function handleDeleteRows() {
  let selectedRows = dtb.value.getSelectedRows();
  selectedRows = toRaw(selectedRows);
  if (selectedRows != null) {
    var toDeleteIds = selectedRows.map((c) => c.id);
    const data = await deleteCourses(toDeleteIds);
    if (data?.success) {
      emit("refreshHomeViewData");
      showDeleteModal.value = false;
    }
  }
}

function allCapsToPascalCase(str) {
  return str
    .toLowerCase()
    .split(/[_\s-]+/)
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
    .join("");
}

function stringifySelectedRows() {
  let selectedRows = dtb.value.getSelectedRows();
  selectedRows = toRaw(selectedRows);
  let subjectLevels = selectedRows.map(
    (item) =>
      `${allCapsToPascalCase(item.subject)} ${allCapsToPascalCase(item.level)}`
  );
  selectedToDisplay.value = subjectLevels.join(", ");
}

const computedCourses = computed(() => {
  if (props.courses) {
    return [...props.courses];
  }
});

function openCreateModal() {
  showCreateModal.value = true;
}

function openDeleteModal() {
  stringifySelectedRows();
  showDeleteModal.value = true;
}

function openViewDetail() {
  let allEnrollmentsToView: any[] = [];
  let selectedRows = dtb.value.getSelectedRows();
  selectedRows = toRaw(selectedRows);

  if (props.enrollments !== undefined || props.enrollments !== null) {
    for (let courseSelected of selectedRows) {
      let cEnrollments =
        props.enrollments && props.enrollments[courseSelected.id];
      allEnrollmentsToView.push(cEnrollments);
    }
  }

  selectedEnrollmentsToView.value = [...allEnrollmentsToView];
  showViewDetail.value = true;
}

function clearForm() {
  course.value.level = 1;
  course.value.maxScore = 1;
  course.value.passingRate = 1;
  let dayElement = document.getElementById("courseDays");
  for (let i = 0; i < dayElement.options.length; i++) {
    if (dayElement.options[i].selected) {
      dayElement.options[i].selected = false;
    }
  }
  let timeElement = document.getElementById("courseTimes");
  for (let i = 0; i < timeElement.options.length; i++) {
    if (timeElement.options[i].selected) {
      timeElement.options[i].selected = false;
    }
  }
  selectedDay.value = 0;
  timeOptions.value = [];
}

function handleSelectDay(event) {
  const day = event.target.value;
  selectedDay.value = day;
  // clear selected times
  timeOptions.value = [];
  setTimeout(() => {
    if (options.value) timeOptions.value = options.value[day];
  }, 700);
}

async function handleApproveEnrollments() {
  let selectedRows = dtbStudentEnrollments.value.getSelectedRows();
  selectedRows = toRaw(selectedRows);
  if (selectedRows == null) {
    return;
  }
  let selectedEnrollmentIds = selectedRows.map((item) => item.id);
  const result = await handleApproveRequestedEnrollments(selectedEnrollmentIds);
  if (result?.success) {
    // getAvailableCourses();
    showViewDetail.value = false;
    emit("refreshHomeViewData");
  } else {
    notify({
      type: "type-error",
      message: result?.message,
    });
  }
}
</script>

<template>
  <div class="max-w-7xl p-4 w-full sm:p-6 lg:p-8">
    <header class="mb-[3rem]">
      <h1 class="text-3xl font-bold text-gray-900">My Courses</h1>
      <p class="text-sm text-gray-500 mt-1">
        Manage and view the courses you have created.
      </p>
    </header>

    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
      <a
        href="#"
        class="flex flex-col items-center justify-center bg-white rounded-xl border-2 border-dashed border-gray-300 text-gray-500 hover:border-blue-500 hover:text-blue-500 transition-all duration-300 min-h-[350px] transform hover:-translate-y-1"
      >
        <div class="text-center">
          <svg
            class="mx-auto h-12 w-12"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M12 4.5v15m7.5-7.5h-15"
            />
          </svg>
          <p class="mt-2 font-semibold">Create New Course</p>
        </div>
      </a>

      <a
        href="/course-detail/1"
        class="bg-white rounded-xl shadow-md overflow-hidden transform hover:-translate-y-1 transition-all duration-300"
      >
        <img
          class="w-full h-40 object-cover"
          src="https://images.unsplash.com/photo-1588702547919-26089e690ee6?q=80&w=2070&auto=format&fit=crop"
          alt="Mathematics Course"
        />
        <div class="p-6">
          <div class="flex items-start justify-between">
            <div>
              <span
                class="text-xs font-semibold text-blue-800 bg-blue-100 px-2 py-1 rounded-full"
                >Mathematics</span
              >
              <h3 class="text-xl font-bold text-gray-900 mt-2">
                Introduction to Algebra
              </h3>
            </div>
            <button
              class="text-gray-400 hover:text-gray-600 p-1 rounded-full hover:bg-gray-100"
            >
              <svg
                class="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z"
                />
              </svg>
            </button>
          </div>
          <div class="mt-4 space-y-3 text-sm text-gray-600">
            <div class="flex items-center gap-2">
              <svg
                class="w-5 h-5 text-gray-400"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-4.67c.12-.24.232-.487.335-.737m-3.058 3.058A12.31 12.31 0 016.624 21c-2.662 0-5.133-.688-7.247-1.917C4.78 17.165 6.84 16.5 9 16.5c.338 0 .671.017 1.003.051"
                />
              </svg>
              <span>42 Enrolled Students</span>
            </div>
            <div class="flex items-center gap-2">
              <svg
                class="w-5 h-5 text-green-500"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
                  clip-rule="evenodd"
                />
              </svg>
              <span
                >Status:
                <span class="font-medium text-green-700">Published</span></span
              >
            </div>
          </div>
          <div class="mt-4">
            <p class="text-sm text-gray-500">Average Completion</p>
            <div class="flex items-center gap-2 mt-1">
              <div class="w-full bg-gray-200 rounded-full h-2">
                <div
                  class="bg-blue-600 h-2 rounded-full"
                  style="width: 75%"
                ></div>
              </div>
              <span class="text-sm font-semibold text-gray-700">75%</span>
            </div>
          </div>
        </div>
      </a>

      <a
        href="/course-detail/2"
        class="bg-white rounded-xl shadow-md overflow-hidden transform hover:-translate-y-1 transition-all duration-300"
      >
        <img
          class="w-full h-40 object-cover"
          src="https://images.unsplash.com/photo-1456513080510-7bf3a84b82f8?q=80&w=1973&auto=format&fit=crop"
          alt="History Course"
        />
        <div class="p-6">
          <div class="flex items-start justify-between">
            <div>
              <span
                class="text-xs font-semibold text-indigo-800 bg-indigo-100 px-2 py-1 rounded-full"
                >History</span
              >
              <h3 class="text-xl font-bold text-gray-900 mt-2">
                World War II History
              </h3>
            </div>
            <button
              class="text-gray-400 hover:text-gray-600 p-1 rounded-full hover:bg-gray-100"
            >
              <svg
                class="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z"
                />
              </svg>
            </button>
          </div>
          <div class="mt-4 space-y-3 text-sm text-gray-600">
            <div class="flex items-center gap-2">
              <svg
                class="w-5 h-5 text-gray-400"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-4.67c.12-.24.232-.487.335-.737m-3.058 3.058A12.31 12.31 0 016.624 21c-2.662 0-5.133-.688-7.247-1.917C4.78 17.165 6.84 16.5 9 16.5c.338 0 .671.017 1.003.051"
                />
              </svg>
              <span>0 Enrolled Students</span>
            </div>
            <div class="flex items-center gap-2">
              <svg
                class="w-5 h-5 text-yellow-500"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a.75.75 0 000 1.5h.253a.25.25 0 01.244.304l-.459 2.066A1.75 1.75 0 0010.747 15H11a.75.75 0 000-1.5h-.253a.25.25 0 01-.244-.304l.459-2.066A1.75 1.75 0 009.253 9H9z"
                  clip-rule="evenodd"
                />
              </svg>
              <span
                >Status:
                <span class="font-medium text-yellow-800">Draft</span></span
              >
            </div>
          </div>
          <div class="mt-4">
            <p class="text-sm text-gray-500">Average Completion</p>
            <div class="flex items-center gap-2 mt-1">
              <div class="w-full bg-gray-200 rounded-full h-2">
                <div
                  class="bg-gray-400 h-2 rounded-full"
                  style="width: 0%"
                ></div>
              </div>
              <span class="text-sm font-semibold text-gray-700">0%</span>
            </div>
          </div>
        </div>
      </a>
    </div>
  </div>
</template>

<style scoped>
.loader {
  border-top-color: #3498db;
  -webkit-animation: spinner 1.5s linear infinite;
  animation: spinner 1.5s linear infinite;
}

@-webkit-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
  }
}

@keyframes spinner {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
