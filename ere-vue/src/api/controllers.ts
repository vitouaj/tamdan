import HttpClient from "./httpRequests";
import router from "../router";
import { RegisterModel } from "../pages/Auth.vue";
import { notify } from "./utility";

interface loginPayload {
  emailOrPhoneNumber: String;
  password: String;
  token?: String;
  deviceId?: String;
  deviceName?: String;
  deviceType?: String;
  deviceOs?: String;
  ipAddress?: String;
}

async function getUser(showToast: Boolean) {
  try {
    const response = await HttpClient.get({
      path: "/api/v1.0/user/me",
    });
    let data = response?.data;
    return data;
  } catch (e) {
    router.push({ name: "auth" });
  }
}

async function upsertCourse(course: any) {
  const response = await HttpClient.post({
    path: "/api/v1.0/teacher/course",
    payload: course,
  });
  let data = response?.data;
  let success = data?.success;
  let toasterMessage = data?.message;
  if (success) {
    notify({
      type: "type-success",
      message: toasterMessage,
    });
  }
  return data;
}

async function loadSubjectOptions() {
  const response = await HttpClient.get({
    path: "/api/v1.0/user/static-options",
  });
  return response?.data;
}

async function login(payload: loginPayload) {
  const response = await HttpClient.post({
    path: "/api/v1.0/user/login",
    payload: payload,
  });
  let data = response?.data;
  let success = data?.success;
  if (success) {
    let token = data?.payload?.token;
    window.sessionStorage.setItem("ere-token", token);
    return router.push({ name: "home" });
  }
}

async function loadAvailableCourse() {
  const response = await HttpClient.get({
    path: "/api/v1.0/student/available-course",
  });
  let data = response?.data;
  let success = data?.success;
  if (success) {
    return data;
  }
}

async function enroll(courseIds: Array<String>) {
  const response = await HttpClient.post({
    path: "/api/v1.0/student/enroll",
    payload: {
      courseIds: courseIds,
    },
  });
  let data = response?.data;
  let success = data?.success;
  let toasterMessage = data?.message;
  if (success) {
    notify({
      type: "type-success",
      message: toasterMessage,
    });
    return data;
  }
}

async function deleteCourses(courseIds: Array<String>) {
  const response = await HttpClient.delete({
    path: "/api/v1.0/teacher/course",
    payload: {
      courseIds: courseIds,
    },
  });
  let data = response?.data;
  let success = data?.success;
  let toasterMessage = data?.message;
  if (success) {
    notify({
      type: "type-success",
      message: toasterMessage,
    });
    return data;
  }
}

async function register(payload: RegisterModel) {
  const response = await HttpClient.post({
    path: "/api/v1.0/user/register",
    payload: payload,
  });
  let data = response?.data;
  let success = data?.success;
  let toasterMessage = data?.message;
  if (success) {
    notify({
      type: "type-success",
      message: toasterMessage,
    });
    return data;
  }
}

async function logout() {
  window.sessionStorage.removeItem("ere-token");
  router.push({ name: "auth" });
}

export {
  getUser,
  login,
  logout,
  loadSubjectOptions,
  register,
  upsertCourse,
  loadAvailableCourse,
  enroll,
  deleteCourses,
};
