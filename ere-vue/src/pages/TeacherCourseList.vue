<script setup lang="ts">
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { computed, onMounted, ref, toRaw } from "vue";
import { deleteCourses, upsertCourse } from "../api/controllers";
import Loading from "./Loading.vue";
import { DAY_OF_WEEK, TIMES_OF_DAY, LEVEL } from "../api/utility";
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
const createModal = ref(null);
const loading = ref(null);
const options = ref({});
const initialOptions = ref();
const selectedToDisplay = ref("");
const showDeleteModal = ref(false);
const showCreateModal = ref(false);
const showViewDetail = ref(false);
const selectedEnrollmentsToView = ref({});
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
      `${allCapsToPascalCase(item.subject)}  ${allCapsToPascalCase(item.level)}`
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
</script>

<template>
  <template v-if="!showViewDetail">
    <Loading ref="loading" />
    <CModal ref="createModal" title="New" v-model:visible="showCreateModal">
      <template #content>
        <div class="grid grid-cols-2 gap-4">
          <div class="col-span-1">
            <label
              for="level"
              class="block mb-2 text-sm font-medium text-gray-900"
              >Which level</label
            >
            <select
              v-model="course.level"
              id="level"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
            >
              <option
                :value="parseInt(level)"
                v-for="level in Object.keys(levels)"
              >
                {{ levels[level] }}
              </option>
            </select>
          </div>
          <div class="col-span-1">
            <label
              for="maxScore"
              class="block mb-2 text-sm font-medium text-gray-900"
              >Max Score</label
            >
            <input
              v-model="course.maxScore"
              id="maxScore"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              type="number"
            />
          </div>
          <div class="col-span-1">
            <label
              for="courseDays"
              class="block mb-2 text-sm font-medium text-gray-900"
              >Course Days</label
            >
            <select
              placeholder="Select Course Days"
              id="courseDays"
              @change="handleSelectDay"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
            >
              <option default>Please choose</option>
              <option
                :value="parseInt(day)"
                v-for="day in Object.keys(options)"
              >
                {{ daysOfWeeek[day] }}
              </option>
            </select>
          </div>
          <div class="col-span-1">
            <label
              for="courseTimes"
              class="block mb-2 text-sm font-medium text-gray-900"
              >Available Times</label
            >
            <select
              multiple
              id="courseTimes"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
            >
              <option
                :disabled="option.disabled"
                :value="parseInt(option.time)"
                v-for="option in timeOptions"
              >
                {{ timesOfDay[parseInt(option.time)] }}
              </option>
            </select>
          </div>
        </div>
      </template>
      <template #actions>
        <button class="btn btn-primary" @click="handleSaveRecord">
          Create
        </button>
      </template>
    </CModal>
    <CModal title="Are you sure?" v-model:visible="showDeleteModal">
      <template #content>
        <p>
          Deleting <span class="text-blue-500">{{ selectedToDisplay }}</span>
        </p>
      </template>
      <template #actions>
        <button class="btn btn-primary" @click="handleDeleteRows">
          Confirm
        </button>
      </template>
    </CModal>
    <!-- end create modal -->
    <template v-if="courses">
      <p class="text-xl font-bold">My Classrooms</p>
      <div class="datatable-action mt-4 mb-2 flex justify-end gap-2">
        <button
          class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
          @click="openViewDetail"
        >
          View
        </button>
        <button
          class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
          @click="openCreateModal"
        >
          Create new
        </button>
        <button
          class="text-blue-500 border border-sm rounded border-blue-500 px-3 py-1 w-fit"
          @click="openDeleteModal"
        >
          Delete Course
        </button>
      </div>
    </template>
    <FlyonDatatable
      ref="dtb"
      :key="courses?.length"
      :columns="columns"
      :data="computedCourses"
    />
  </template>
  <template v-if="showViewDetail">
    <FlyonDatatable
      ref="dtbStudentEnrollments"
      :key="courses?.length"
      :columns="courseEnrollmentDetail"
      :data="selectedEnrollmentsToView"
    />
    <span
      @click="emit('goback', { detail: { cmpName: 'teachercourselist' } })"
      class="icon-[tabler--arrow-back-up] size-8"
    ></span>
  </template>
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
