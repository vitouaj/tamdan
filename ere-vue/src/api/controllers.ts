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

let toasterMessage = "";

async function getUser() {
  try {
    const response = await HttpClient.get({
      path: "/api/v1.0/user/me",
    });
    console.log(response);
    let data = response?.data;
    let success = data?.success;
    toasterMessage = data?.message;
    toasterMessage = data?.message;
    if (success) {
      notify({
        type: "type-success",
        message: toasterMessage,
      });
    }
    return data;
  } catch (e) {
    let errorPayload = e?.response?.data;
    toasterMessage = errorPayload?.message;
    router.push({ name: "auth" });
  }
}

async function loadSubjectOptions() {
  try {
    const response = await HttpClient.get({
      path: "/api/v1.0/user/static-options",
    });
    console.log(response);
    let data = response?.data;
    let success = data?.success;

    toasterMessage = data?.message;
    if (success) {
      // notify({
      //   type: "type-success",
      //   message: toasterMessage,
      // });
    }
    return data;
  } catch (e) {
    let errorPayload = e?.response?.data;
    toasterMessage = errorPayload?.message;
    router.push({ name: "auth" });
  }
}

async function login(payload: loginPayload) {
  try {
    const response = await HttpClient.post({
      path: "/api/v1.0/user/login",
      payload: payload,
    });
    let data = response?.data;
    let success = data?.success;
    toasterMessage = data?.message;
    if (success) {
      let token = data?.payload?.token;
      window.sessionStorage.setItem("ere-token", token);
      // redirect to home
      return router.push({ name: "home" });
    }
  } catch (e) {
    let errorPayload = e?.response?.data;
    toasterMessage = errorPayload?.message;
  }
}

async function register(payload: RegisterModel) {
  try {
    const response = await HttpClient.post({
      path: "/api/v1.0/user/register",
      payload: payload,
    });
    let data = response?.data;
    let success = data?.success;
    toasterMessage = data?.message;
    if (success) {
      notify({
        type: "type-success",
        message: toasterMessage,
      });
      return data;
    }
  } catch (e) {
    let errorPayload = e?.response?.data;
    toasterMessage = errorPayload?.message;
  }
}

async function logout() {
  window.sessionStorage.removeItem("ere-token");
  router.push({ name: "auth" });
}

export { getUser, login, logout, loadSubjectOptions, register };
