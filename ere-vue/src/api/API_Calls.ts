import axios from "axios";
import { LoginWrapper, RegisterWrapper } from "./DataWrapper";

const BASE_URL = import.meta.env.VITE_API_BASE_URL || "http://localhost:5137";
axios.defaults.baseURL = BASE_URL;
const TOKEN = window.sessionStorage.getItem("ere-token");
const AUTH_HEADER = {
  Authorization: `Bearer ${TOKEN}`,
};
const METHOD = {
  GET: "get",
  POST: "post",
  PUT: "put",
  DELETE: "delete",
};
const API_ENDPOINTS = {
  LOGIN: "/api/v1.0/user/login",
  REGISTER: "/api/v1.0/user/register",
  GET_USER: "/api/v1.0/user/me",
  UPDATE_USER: "/api/v1.0/user/me",
  GET_OPTIONS: "/api/v1.0/user/static-options",

  CREATE_COURSE: "/api/v1.0/teacher/courses",
  DELETE_COURSE: "/api/v1.0/teacher/courses",
  CREATE_COURSE_REPORT: "/api/v1.0/teacher/course-report",
  UPDATE_COURSE_REPORT: "/api/v1.0/teacher/course-report",
  UPDATE_ENROLLMENT: "/api/v1.0/teacher/enrollments",

  DO_ENROLL: "/api/v1.0/student/enroll",
  DO_COMMENT: "/api/v1.0/student/comment",
  GET_AVAILABLE_COURSES: "/api/v1.0/student/available-course",
  GET_ENROLLMENTS: "/api/v1.0/student/enrollment",
};

function doLogin(payload: LoginWrapper) {
  return axios({
    method: METHOD.POST,
    url: API_ENDPOINTS.LOGIN,
    data: payload,
  });
}

function doRegister(payload: RegisterWrapper) {
  return axios({
    method: METHOD.POST,
    url: API_ENDPOINTS.REGISTER,
    data: payload,
  });
}

function logout() {
  window.sessionStorage.removeItem("ere-token");
}

function getUser() {
  return axios({
    method: METHOD.GET,
    url: API_ENDPOINTS.GET_USER,
    headers: AUTH_HEADER,
  });
}

function getMyEnrollments() {
  return axios({
    method: METHOD.GET,
    url: "/api/v1.0/student/enrollment",
    headers: AUTH_HEADER,
  });
}

function upsertCourse(course: any) {
  return axios({
    method: METHOD.POST,
    url: "/api/v1.0/teacher/course",
    data: course,
    headers: AUTH_HEADER,
  });
}

function loadSubjectOptions() {
  return axios({
    method: METHOD.GET,
    url: "/api/v1.0/user/static-options",
    headers: AUTH_HEADER,
  });
}

function loadAvailableCourse() {
  return axios({
    method: METHOD.GET,
    url: "/api/v1.0/student/available-course",
    headers: AUTH_HEADER,
  });
}

function updateEnollmentStatus(enrollmentIds: Array<string>) {
  return axios({
    method: METHOD.PUT,
    url: API_ENDPOINTS.UPDATE_ENROLLMENT,
    data: {
      enrollmentIds: enrollmentIds,
    },
    headers: AUTH_HEADER,
  });
}

function enroll(courseIds: Array<String>) {
  return axios({
    method: METHOD.POST,
    url: "/api/v1.0/student/enroll",
    data: {
      courseIds: courseIds,
    },
    headers: AUTH_HEADER,
  });
}

function deleteCourses(courseIds: Array<String>) {
  return axios({
    method: METHOD.DELETE,
    url: "/api/v1.0/teacher/course",
    data: {
      courseIds: courseIds,
    },
    headers: AUTH_HEADER,
  });
}

export {
  getUser,
  doLogin,
  getMyEnrollments,
  updateEnollmentStatus,
  logout,
  loadSubjectOptions,
  doRegister,
  upsertCourse,
  loadAvailableCourse,
  enroll,
  deleteCourses,
};
