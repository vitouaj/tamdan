<template>
  <Navbar :user="user || ({} as User)" @goto="handleGoTo" />
  <div class="grid grid-cols-5 gap-4 p-4">
    <Sidebar
      :user="user || ({} as User)"
      @goto="handleGoTo"
      class="col-span-1"
    />
    <div class="main-content-container col-span-4">
      <div class="card w-full">
        <div class="card-body content">
          <template v-if="showAllReports">
            <AllReports v-if="mainReports" :reports="mainReports" />
          </template>
          <template v-if="showStudentList">
            <div class="grid grid-cols-2">
              <StudentCard
                @gotostudentreportlist="fiterMainReports"
                v-if="students"
                v-for="student in students"
                :student="student"
              />
            </div>
          </template>
          <template v-if="showSchedules">
            <Calendar v-if="courses" :courses="computedCoursesForSchedule" />
          </template>
          <template v-if="showCourseEnrollments">
            <CourseEnrollments :enrollments="enrollments" />
          </template>
          <template v-if="showAllCourses">
            <CourseList
              v-if="courses"
              :courses="computedCourses"
              :user="user"
            />
          </template>
          <template v-if="showProfile">
            <Profile :contacts="contacts" :user="user" @goback="handleGoTo" />
          </template>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import Navbar from "../components/Navbar.vue";
import Sidebar from "../components/Sidebar.vue";
import { computed, onMounted, ref } from "vue";
import { getUser } from "../api/controllers";
import AllReports from "./AllReports.vue";
import Calendar from "./Calendar.vue";
import CourseEnrollments from "./CourseEnrollments.vue";
import Profile from "./Profile.vue";
import StudentCard from "./StudentCard.vue";
import CourseList from "./CourseList.vue";
import {
  DAY_OF_WEEK,
  getCourseDayToDisplay,
  getTimesDayToDisplay,
} from "../api/utility";

export interface User {
  name: string;
  phone: string;
  email: string;
  role: Number;
  subject: string;
  levelId: string;
  userId: string;
  studentId: string;
  createdDate: string;
  updatedDate: string;
  totalAbsence: Number;
  totalScore: Number;
  overallGrade: string;
  averageScore: Number;
}

const showAllReports = ref(false);
const showCourseEnrollments = ref(false);
const showSchedules = ref(false);
const showProfile = ref(false);
const showStudentList = ref(false);
const showAllCourses = ref(false);

const user = ref<User>();
const mainReportMap = ref({});
const mainReports = ref([]);
const enrollments = ref([]);
const courses = ref([]);
const contacts = ref([]);
const students = ref([]);

const computedCoursesForSchedule = computed(() => {
  return [...courses.value];
});

const computedCourses = computed(() => {
  return courses.value.map((item) => {
    const courseDayDisplay = getCourseDayToDisplay(item?.courseDays);
    const timesDayDisplay = getTimesDayToDisplay(item?.courseTimes);
    return {
      ...item,
      courseDays: courseDayDisplay,
      courseTimes: timesDayDisplay,
    };
  });
});

const isParent = computed(() => {
  return user.value?.role == 3;
});
const isTeacher = computed(() => {
  return user.value?.role == 2;
});
const isStudent = computed(() => {
  return user.value?.role == 1;
});

onMounted(async () => {
  let response = await getUser();
  let payload = response?.payload;

  user.value = payload?.user;
  students.value = payload?.students;
  contacts.value = payload?.contacts;
  courses.value = payload?.courses;
  mainReports.value = payload?.mainReport;
  enrollments.value = payload?.enrollments;
  mainReportMap.value = payload?.mainReportMap;

  if (user.value?.role == 3) {
    showStudentList.value = true;
  } else if (user.value?.role == 2) {
    showAllCourses.value = true;
  } else if (user.value?.role == 1) {
    showAllReports.value = true;
  }
});

function resetViews() {
  showAllReports.value = false;
  showCourseEnrollments.value = false;
  showSchedules.value = false;
  showProfile.value = false;
  showStudentList.value = false;
  showAllCourses.value = false;
}

function fiterMainReports(event: CustomEvent) {
  const id = event.detail?.id;
  let reports = mainReportMap.value[id] || [];
  // set mainreports
  mainReports.value = reports;
  showAllReports.value = true;
  showStudentList.value = false;
}

function handleGoTo(event: CustomEvent) {
  const cmp = event.detail?.cmpName;
  resetViews();
  switch (cmp) {
    case "home":
    case "allreports":
      showAllReports.value = true;
      break;
    case "studentlist":
      showStudentList.value = true;
      break;
    case "courselist":
      showAllCourses.value = true;
      break;
    case "schedules":
      showSchedules.value = true;
      break;
    case "course-enrollments":
      showCourseEnrollments.value = true;
      break;
    case "me":
      showProfile.value = true;
      break;
  }
}
</script>
