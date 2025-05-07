<template>
  <section class="relative min-h-screen overflow-hidden">
    <div
      class="absolute inset-0 bg-[url('https://newsroomcambodia.com/wp-content/uploads/2020/01/1280px-School_kids_jumping_in_Cambodia_13578591625.jpg')] bg-cover bg-center bg-no-repeat blur-sm"
    ></div>

    <div class="absolute inset-0 bg-black bg-opacity-30"></div>

    <div
      class="relative z-10 flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0"
    >
      <div class="bg-opacity-60 bg-gray-300 rounded-lg p-6 w-1/4">
        <h1 class="text-2xl py-4 font-bold text-gray-900">Sign In</h1>
        <form class="space-y-4 md:space-y-6" action="#">
          <div>
            <label for="email" class="block mb-2 text-sm font-medium"
              >Your email</label
            >
            <input
              type="email"
              name="email"
              v-model="emailOrPhoneNumber"
              id="email"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder="name@company.com"
            />
          </div>
          <div>
            <label for="password" class="block mb-2 text-sm font-medium"
              >Password</label
            >
            <input
              type="password"
              name="password"
              v-model="password"
              id="password"
              placeholder="••••••••"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
            />
          </div>
          <div class="flex items-center justify-between">
            <div class="flex items-start">
              <div class="flex items-center h-5">
                <input
                  id="remember"
                  aria-describedby="remember"
                  type="checkbox"
                  class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-primary-600 dark:ring-offset-gray-800"
                />
              </div>
              <div class="ml-3 text-sm">
                <label for="remember" class="text-black">Remember me</label>
              </div>
            </div>
            <a href="#" class="text-sm font-medium text-black hover:underline"
              >Forgot password?</a
            >
          </div>
          <button
            @click.stop.prevent="submitLogin"
            class="w-full text-white bg-primary hover:bg-white-400 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
          >
            Sign in
          </button>
          <p class="text-sm font-light text-black">
            Don’t have an account yet?
            <a
              @click="emit('toggleRegister')"
              class="font-medium text-primary-600 cursor-pointer dark:text-primary-500"
              >Sign up</a
            >
          </p>
        </form>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { login } from "../api/controllers";

let emailOrPhoneNumber = ref("");
let password = ref("");

async function submitLogin() {
  let payload = {
    emailOrPhoneNumber: emailOrPhoneNumber.value,
    password: password.value,
  };
  await login(payload);
}

const emit = defineEmits();
</script>
