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
            <Calendar
              v-if="courses"
              :isTeacher="isTeacher"
              :courses="computedCoursesForSchedule"
              :occupiedHours="user?.occupiedHours"
            />
          </template>
          <template v-if="showCourseEnrollments">
            <CourseEnrollments
              @refreshHomeViewData="refreshHomeViewData"
              :enrollments="enrollments"
            />
          </template>
          <template v-if="showAllCourses">
            <TeacherCourseList
              v-if="courses"
              @goback="handleGoTo"
              @refreshHomeViewData="refreshHomeViewData"
              :enrollments="enrollments"
              :courses="computedCoursesDataTable"
              :user="user"
              :occupiedHours="user?.occupiedHours"
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
import TeacherCourseList from "./TeacherCourseList.vue";
import {
  DAY_OF_WEEK,
  Utility,
  // getCourseDayToDisplay,
  // getTimesDayToDisplay,
} from "../api/utility";
import { CourseHour } from "./ModalContent.vue";

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
  occupiedHours: Array<CourseHour>;
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

const computedCoursesDataTable = computed(() => {
  return courses.value.map((item) => {
    return {
      ...item,
      subject: Utility.allCapsToPascalCase(item.subject),
      level: Utility.allCapsToPascalCase(item.level),
      teacherName: Utility.allCapsToPascalCase(item.teacherName),
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
  await initHomeData(false);
});

async function initHomeData(isRefresh: Boolean) {
  let response = isRefresh ? await getUser(false) : await getUser(true);
  let payload = response?.payload;
  user.value = payload?.user;
  students.value = payload?.students;
  contacts.value = payload?.contacts;
  courses.value = payload?.courses;
  mainReports.value = payload?.mainReport;
  enrollments.value = payload?.enrollments;
  mainReportMap.value = payload?.mainReportMap;
  if (isRefresh !== undefined && !isRefresh) {
    resetViews();
    if (user.value?.role == 3) {
      showStudentList.value = true;
    } else if (user.value?.role == 2) {
      showAllCourses.value = true;
    } else if (user.value?.role == 1) {
      showAllReports.value = true;
    }
  }
}
function resetViews() {
  showAllReports.value = false;
  showCourseEnrollments.value = false;
  showSchedules.value = false;
  showProfile.value = false;
  showStudentList.value = false;
  showAllCourses.value = false;
}

async function refreshHomeViewData() {
  await initHomeData(true);
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
  setTimeout(() => {
    switch (cmp) {
      case "home":
      case "allreports":
        showAllReports.value = true;
        break;
      case "studentlist":
        showStudentList.value = true;
        break;
      case "teachercourselist":
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
  }, 200);
}
</script>
