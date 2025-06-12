<template>
  <StateLoading :isLoading="isLoading" />
  <div
    class="bg-cover bg-center"
    style="
      background-image: url(&quot;https://images.unsplash.com/photo-1523240795612-9a054b0db644?q=80&w=2070&auto=format&fit=crop&quot;);
    "
  >
    <div
      class="flex items-center justify-center min-h-screen bg-slate-900 bg-opacity-50 py-12"
    >
      <main
        class="w-full max-w-5xl mx-auto grid grid-cols-1 lg:grid-cols-2 rounded-xl shadow-2xl overflow-hidden"
      >
        <div
          class="hidden lg:flex flex-col justify-center text-white p-12 bg-blue-800 bg-opacity-80 backdrop-blur-sm"
        >
          <div class="space-y-4">
            <h1 class="text-4xl font-extrabold tracking-tight">
              Join Our Learning Community
            </h1>
            <p class="text-blue-100 leading-relaxed">
              Create your account and start your educational journey with our
              comprehensive learning platform designed for everyone.
            </p>
          </div>
        </div>

        <div class="bg-white p-8 sm:p-12">
          <div class="w-full">
            <div class="text-center mb-6">
              <h2 class="text-3xl font-bold text-gray-800">
                Create an Account
              </h2>
              <p id="step-title" class="text-gray-500 mt-2 text-sm font-medium">
                Step 1 of 2: Your Details
              </p>
            </div>

            <form id="signup-form" action="#" method="POST">
              <template v-if="step === 1">
                <div id="step-1" class="space-y-5">
                  <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
                    <div>
                      <label
                        for="firstname"
                        class="block text-sm font-medium text-gray-700"
                        >First Name</label
                      >
                      <input
                        id="firstname"
                        name="firstname"
                        v-model="payload.firstName"
                        type="text"
                        autocomplete="given-name"
                        required
                        class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                      />
                    </div>
                    <div>
                      <label
                        for="lastname"
                        class="block text-sm font-medium text-gray-700"
                        >Last Name</label
                      >
                      <input
                        id="lastname"
                        name="lastname"
                        v-model="payload.lastName"
                        type="text"
                        autocomplete="family-name"
                        required
                        class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                      />
                    </div>
                  </div>
                  <div>
                    <label
                      for="email"
                      class="block text-sm font-medium text-gray-700"
                      >Email</label
                    >
                    <input
                      id="email"
                      name="email"
                      v-model="payload.email"
                      type="email"
                      autocomplete="email"
                      required
                      class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    />
                  </div>
                  <div>
                    <label
                      for="password"
                      class="block text-sm font-medium text-gray-700"
                      >Password</label
                    >
                    <input
                      id="password"
                      name="password"
                      type="password"
                      v-model="payload.password"
                      autocomplete="new-password"
                      required
                      class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    />
                  </div>
                  <div>
                    <label
                      for="phone"
                      class="block text-sm font-medium text-gray-700"
                      >Phone</label
                    >
                    <input
                      id="phone"
                      name="phone"
                      type="tel"
                      v-model="payload.phone"
                      autocomplete="new-phone"
                      required
                      class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    />
                  </div>
                  <div>
                    <label
                      for="role"
                      class="block text-sm font-medium text-gray-700"
                      >Are you a student or teacher?</label
                    >
                    <select
                      id="role"
                      name="role"
                      v-model="payload.role"
                      autocomplete="role"
                      required
                      class="mt-1 block w-full px-3 py-3 border border-gray-300 bg-white rounded-lg shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    >
                      <option value="" disabled selected>
                        Select your role
                      </option>
                      <option value="1">Student</option>
                      <option value="2">Teacher</option>
                    </select>
                  </div>
                  <div>
                    <button
                      type="button"
                      @click="handleNextStep"
                      id="next-btn"
                      class="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
                    >
                      Next →
                    </button>
                  </div>
                </div>
              </template>
              <template v-if="step === 2">
                <div id="step-2" class="space-y-5">
                  <h3 class="text-md font-semibold text-gray-700 border-b pb-2">
                    Parent/Guardian Contact Information
                  </h3>
                  <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
                    <div>
                      <label
                        for="first-name"
                        class="block text-sm font-medium text-gray-700"
                        >Firstname</label
                      >
                      <input
                        id="first-name"
                        v-model="contactPayload.firstName"
                        name="first-name"
                        type="text"
                        required
                        class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                      />
                    </div>
                    <div>
                      <label
                        for="last-name"
                        class="block text-sm font-medium text-gray-700"
                        >Lastname</label
                      >
                      <input
                        id="last-name"
                        v-model="contactPayload.lastName"
                        name="last-name"
                        type="text"
                        required
                        class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                      />
                    </div>
                    <div>
                      <label
                        for="parent-phone"
                        class="block text-sm font-medium text-gray-700"
                        >Phone Number</label
                      >
                      <input
                        id="parent-phone"
                        name="parent-phone"
                        v-model="contactPayload.phone"
                        type="tel"
                        required
                        class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                      />
                    </div>
                  </div>
                  <div>
                    <label
                      for="parent-email"
                      class="block text-sm font-medium text-gray-700"
                      >Email</label
                    >
                    <input
                      id="parent-email"
                      v-model="contactPayload.email"
                      name="parent-email"
                      type="email"
                      required
                      class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    />
                  </div>
                  <div>
                    <label
                      for="address"
                      class="block text-sm font-medium text-gray-700"
                      >Street Address</label
                    >
                    <input
                      id="address"
                      v-model="contactPayload.address"
                      name="address"
                      type="text"
                      required
                      class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    />
                  </div>
                  <div>
                    <label
                      for="city"
                      class="block text-sm font-medium text-gray-700"
                      >City</label
                    >
                    <input
                      id="city"
                      name="city"
                      v-model="contactPayload.city"
                      autocomplete="address-level2"
                      type="text"
                      required
                      class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    />
                  </div>
                  <div class="flex items-center gap-4 pt-4">
                    <button
                      type="button"
                      @click="handleBackStep"
                      id="back-btn"
                      class="w-full flex justify-center py-3 px-4 border border-gray-300 rounded-lg shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 transition"
                    >
                      ← Back
                    </button>
                    <button
                      @click.prevent="doSubmitRegister"
                      type="submit"
                      id="finish-btn"
                      class="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
                    >
                      Create Account
                    </button>
                  </div>
                </div>
              </template>
            </form>

            <p class="mt-6 text-center text-sm text-gray-500">
              Already have an account?
              <a
                href="/login"
                class="font-semibold leading-6 text-blue-600 hover:text-blue-500"
                >Sign In</a
              >
            </p>
          </div>
        </div>
      </main>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from "vue";
import { doRegister } from "../api/API_Calls";
import { ContactWrapper, RegisterWrapper } from "../api/DataWrapper";
import StateLoading from "../components/ui/StateLoading.vue";
import { defineEmits } from "vue";
import { showToast, Util } from "../api/Utility";
import { useRouter } from "vue-router";

const payload = ref<RegisterWrapper>({
  firstName: "",
  lastName: "",
  password: "",
  email: "",
  phone: "",
  role: 0,
  subject: 0,
  levelId: 0,
  contacts: [],
});

const router = useRouter();
const contactPayload = ref<ContactWrapper>({
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
});

const isLoading = ref(false);

function doSubmitRegister() {
  isLoading.value = true;
  const registerData: RegisterWrapper = {
    ...payload.value,
    role: parseInt(payload.value.role.toString()),
    contacts: [Util.deepCloneData(contactPayload.value)],
  };
  console.log("Registering with data:", registerData);
  doRegister(registerData)
    .then((response) => {
      console.log("Registration response:", response);
      const { success, message } = response.data;
      if (success) {
        router.push("/login");
      }
    })
    .catch((error) => {
      console.error("Registration failed:", error);
      showToast({
        message:
          error.response?.data?.message ||
          "An error occurred during registration.",
        type: "error",
        stack: error.stack,
        duration: 5000000000000000,
      });
    })
    .finally(() => {
      isLoading.value = false;
    });
}

const step = ref(1);

function handleNextStep() {
  if (payload.value.role.toString() === "1" && step.value == 1) {
    step.value = 2;
    return;
  }
  doSubmitRegister();
}
function handleBackStep() {
  if (step.value === 2) {
    step.value = 1;
  }
}

const emit = defineEmits();
</script>

<style></style>
