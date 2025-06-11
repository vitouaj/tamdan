<template>
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
                    autocomplete="new-password"
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
                    required
                    class="mt-1 block w-full px-3 py-3 border border-gray-300 bg-white rounded-lg shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  >
                    <option value="" disabled selected>Select your role</option>
                    <option value="Student">Student</option>
                    <option value="Teacher">Teacher</option>
                  </select>
                </div>
                <div>
                  <button
                    type="button"
                    id="next-btn"
                    class="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
                  >
                    Next →
                  </button>
                </div>
              </div>

              <div id="step-2" class="hidden space-y-5">
                <h3 class="text-md font-semibold text-gray-700 border-b pb-2">
                  Parent/Guardian Contact Information
                </h3>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
                  <div>
                    <label
                      for="parent-name"
                      class="block text-sm font-medium text-gray-700"
                      >Full Name</label
                    >
                    <input
                      id="parent-name"
                      name="parent-name"
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
                    type="text"
                    required
                    class="mt-1 w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div class="flex items-center gap-4 pt-4">
                  <button
                    type="button"
                    id="back-btn"
                    class="w-full flex justify-center py-3 px-4 border border-gray-300 rounded-lg shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 transition"
                  >
                    ← Back
                  </button>
                  <button
                    type="submit"
                    id="finish-btn"
                    class="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
                  >
                    Create Account
                  </button>
                </div>
              </div>
            </form>

            <p class="mt-6 text-center text-sm text-gray-500">
              Already have an account?
              <a
                href="#"
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
import { ref, PropType, onMounted } from "vue";
import { ContactModel, RegisterModel } from "./Auth.vue";
import ContactForm from "./ContactForm.vue";
import UserRegisterForm from "./UserRegisterForm.vue";
import { register } from "../api/controllers";

const props = defineProps({
  registerModel: {
    type: Object as PropType<RegisterModel>,
    required: true,
  },
});

const emit = defineEmits();

const isStep1 = ref(true);
const isStep2 = ref(false);
const registerModel = ref<RegisterModel>();
const contactModel = ref<ContactModel>();

function goToStep(step: Number) {
  isStep1.value = false;
  isStep2.value = false;
  if (step == 1) {
    isStep1.value = true;
  } else if (step == 2) {
    isStep2.value = true;
  }
}

onMounted(() => {
  registerModel.value = props.registerModel;
  contactModel.value = registerModel.value.contacts[0];
});

function handleNextStep() {
  if (registerModel.value?.role != 2) {
    return goToStep(2);
  }
  handleSubmit();
}

async function handleSubmit() {
  if (registerModel.value) {
    console.log(registerModel.value);
    let result = await register(registerModel.value);
    if (result?.success) {
      return emit("toggleSignin");
    }
  }
}

document.addEventListener("DOMContentLoaded", function () {
  const step1 = document.getElementById("step-1");
  const step2 = document.getElementById("step-2");
  const stepTitle = document.getElementById("step-title");

  const nextBtn = document.getElementById("next-btn");
  const backBtn = document.getElementById("back-btn");
  const finishBtn = document.getElementById("finish-btn"); // This would be your final submit button

  const roleSelect = document.getElementById("role");
  const form = document.getElementById("signup-form");

  nextBtn.addEventListener("click", () => {
    const role = roleSelect.value;
    // Add validation here if needed before proceeding

    if (role === "Student") {
      step1.classList.add("hidden");
      step2.classList.remove("hidden");
      stepTitle.textContent = "Step 2 of 2: Parent/Guardian Contact";
    } else if (role === "Teacher") {
      // If a teacher, we can submit the form directly from step 1
      alert("Teacher account creation complete!");
      // form.submit();
    } else {
      alert("Please select your role.");
    }
  });

  backBtn.addEventListener("click", () => {
    step2.classList.add("hidden");
    step1.classList.remove("hidden");
    stepTitle.textContent = "Step 1 of 2: Your Details";
  });

  // The finish button would trigger the form submission
  form.addEventListener("submit", (e) => {
    e.preventDefault(); // Prevents default form submission for this demo
    alert("Student account creation complete!");
    // Here you would gather all form data and send to your server
    // const formData = new FormData(form);
    // for (let [key, value] of formData.entries()) {
    //     console.log(key, value);
    // }
  });
});
</script>
