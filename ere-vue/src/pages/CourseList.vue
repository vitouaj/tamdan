<script setup lang="ts">
import FlyonDatatable from "../components/FlyonDatatable.vue";
import { computed, onMounted, ref, toRaw } from "vue";
import ModalContent, { Course } from "./ModalContent.vue";
import { upsertCourse } from "../api/controllers";
// import { getCourseDayToDisplay, getTimesDayToDisplay } from "../api/utility";
import Loading from "./Loading.vue";
import { DAY_OF_WEEK, TIMES_OF_DAY } from "../api/utility";

const props = defineProps({
  courses: {
    type: Array,
  },
  user: Object,
  occupiedHours: {
    type: Array,
  },
});

const dtb = ref(null);
function getSelectedRows() {
  let selected = dtb.value.getSelectedRows();
}

const columns = [
  { data: "subject", title: "Subject" }, // Maps to course
  { data: "level", title: "Level" },
  { data: "teacherName", title: "Teacher Name" },
  // { data: "courseDays", title: "Course Days" },
  // { data: "courseTimes", title: "Course Time" },
  //   { data: "teacherName", title: "Taught By" },
];

const course = ref<Course>();
const options = ref({});
const initialOptions = ref();
onMounted(() => {
  initialOptions.value = props.occupiedHours;
  options.value = parseOccupiedHours(props.occupiedHours);
});

async function handleSaveRecord(event) {
  // loading.value?.stateLoading(true); // show loading
  let data = event.detail;
  let coursePayload = {
    level: data.level,
    maxScore: data.maxScore,
    passingRate: 1,
    courseHours: data.courseHours,
  };

  if (data) {
    const result = await upsertCourse(coursePayload);
    let newRecord = result?.payload?.course;
    let ops = result?.payload?.occupiedHours;

    let initials = initialOptions.value;
    for (let oc of ops) {
      initials.push(oc);
    }
    initialOptions.value = initials;
    options.value = parseOccupiedHours(initials);

    let operation = result?.operation;

    newRecord = {
      ...newRecord,
    };

    if (operation == 2) {
      let index = props.courses?.findIndex((item) => item.id === newRecord.id);
      if (index != -1 && props.courses) {
        props.courses[index] = { ...newRecord };
      }
    } else if (operation == 1) {
      props.courses?.push(newRecord);
    }
  }

  modal.value?.clearForm();
  setTimeout(() => {
    dtb.value.setData(props.courses);
  }, 500);
}

const computedCourses = computed(() => {
  if (props.courses) {
    return [...props.courses];
  }
});

const modal = ref(null);
const loading = ref(null);

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

  console.log("options", options);
  return options;
}
</script>

<template>
  <Loading ref="loading" />
  <!-- create modal -->
  <ModalContent
    ref="modal"
    :options="options"
    :course="course"
    @saverecord="handleSaveRecord"
  />
  <!-- end create modal -->
  {{ computedCourses }}
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
      :data="computedCourses"
    />
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
