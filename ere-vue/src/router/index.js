import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../pages/Home.vue";
import NotFound from "../pages/NotFound.vue";
import Auth from "../pages/Auth.vue";
import Login from "../pages/Login.vue";
import Register from "../pages/Register.vue";
import Schedules from "../pages/Schedules.vue";
import Profile from "../pages/Profile.vue";
import CourseDetail from "../pages/CourseDetail.vue";
import StudentDetail from "../pages/StudentDetail.vue";
import ReportDetails from "../pages/ReportDetails.vue";
import CreateCourse from "../components/ui/CreateCourse.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/login",
      name: "login",
      component: Login,
    },
    {
      path: "/register",
      name: "register",
      component: Register,
    },
    {
      path: "/schedule",
      name: "schedule",
      component: Schedules,
    },
    {
      path: "/create-course",
      name: "create-course",
      component: CreateCourse,
    },
    {
      path: "/me",
      name: "profile",
      component: Profile,
    },
    {
      path: "/course-detail/:courseId",
      props: true,
      name: "courseDetail",
      component: CourseDetail,
    },
    {
      path: "/report/:reportId",
      props: true,
      name: "reportDetail",
      component: ReportDetails,
    },
    {
      path: "/student/:studentId",
      props: true,
      name: "studentDetail",
      component: StudentDetail,
    },
    {
      path: "/:pathMatch(.*)*",
      name: "NotFound",
      component: NotFound,
    },
  ],
});

router.afterEach((to, from, failure) => {
  if (!failure) {
    setTimeout(() => {
      window.HSStaticMethods.autoInit();
    }, 100);
  }
});

export default router;
