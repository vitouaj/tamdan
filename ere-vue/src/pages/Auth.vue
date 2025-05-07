<script setup lang="ts">
import { onMounted } from "vue";
import Login from "./Login.vue";
import Register from "./Register.vue";
import { ref } from "vue";

export interface RegisterModel {
  firstName: String;
  lastName: String;
  password: String;
  email: String;
  phone: String;
  role: Number;
  subject?: Number;
  levelId?: Number;
  contacts: Array<ContactModel>;
}

export interface ContactModel {
  firstName: String;
  lastName: String;
  email: String;
  phone: String;
  homeNumber: String;
  street: String;
  village: String;
  commune: String;
  district: String;
  province: String;
}

const registerModel = ref<RegisterModel>({
  firstName: "",
  lastName: "",
  password: "",
  email: "",
  phone: "",
  role: 0, // or any default role number
  subject: 0,
  levelId: 0,
  contacts: [
    {
      firstName: "",
      lastName: "",
      email: "",
      phone: "",
      homeNumber: "",
      street: "",
      village: "",
      commune: "",
      district: "",
      province: "",
    },
  ],
});

const isLogin = ref(true);
const isRegister = ref(false);

function toggleRegister() {
  isRegister.value = true;
  isLogin.value = false;
}

function toggleSignin() {
  isLogin.value = true;
  isRegister.value = false;
}

onMounted(() => {});
</script>

<template>
  <Register
    @toggleSignin="toggleSignin"
    v-if="isRegister"
    :registerModel="registerModel"
  />
  <template v-if="isLogin">
    <Login @toggleRegister="toggleRegister" />
  </template>
</template>
