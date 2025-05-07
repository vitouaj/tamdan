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
            {{ user?.role }}
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
            <Calendar v-if="courses" :courses="computedCourses" />
          </template>
          <template v-if="showCourseEnrollments">
            <CourseList v-if="courses" :courses="courses" />
            <CourseEnrollments :enrollments="enrollments" />
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

function resetViews() {
  showAllReports.value = false;
  showCourseEnrollments.value = false;
  showSchedules.value = false;
  showProfile.value = false;
  showStudentList.value = false;
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

const user = ref<User>();
const mainReportMap = ref({});
const mainReports = ref([]);
const enrollments = ref([]);
const courses = ref([]);
const contacts = ref([]);
const students = ref([]);

const computedCourses = computed(() => {
  return [...courses.value];
});

const computedReports = computed(() => {
  if (!mainReports.value || !Array.isArray(mainReports.value)) return [];
  // Example transformation: group by monthId
  return mainReports.value.map((report) => {
    return {
      ...report,
      monthId: String(report.monthId),
      status: report.status || "Pending",
      className: "btn btn-primary",
    };
  });
});

onMounted(async () => {
  let response = await getUser();

  let payload = response?.payload;
  user.value = payload?.user;

  if (user.value?.role === 3 || user.value?.role === 2) {
    students.value = payload?.students;
    showStudentList.value = true;
  } else {
    showAllReports.value = true;
  }
  contacts.value = payload?.contacts;
  courses.value = payload?.courses;
  mainReports.value = payload?.mainReport;
  enrollments.value = payload?.enrollments;
  mainReportMap.value = payload?.mainReportMap;
});
</script>
