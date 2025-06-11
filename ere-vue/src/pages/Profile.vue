<template>
  <Layout>
    <div class="bg-gray-100 font-sans w-full">
      <div class="px-4">
        <!-- <div class="mb-8">
          <h1 class="text-3xl font-bold text-gray-900">Profile Settings</h1>
          <p class="text-sm text-gray-500 mt-1">
            Manage your personal information and preferences
          </p>
        </div> -->

        <div class="bg-white rounded-xl shadow-md">
          <div class="p-6 sm:p-8 border-b border-gray-200">
            <div
              class="flex flex-col sm:flex-row items-center sm:items-start gap-6"
            >
              <div class="relative group w-24 h-24">
                <img
                  class="w-full h-full rounded-full object-cover"
                  src="https://i.pravatar.cc/150?u=sotheara"
                  alt="by sotheara"
                />
                <button
                  class="absolute inset-0 bg-black bg-opacity-40 flex items-center justify-center rounded-full text-white opacity-0 group-hover:opacity-100 transition-opacity"
                >
                  <svg
                    class="w-6 h-6"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke-width="1.5"
                    stroke="currentColor"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="M6.827 6.175A2.31 2.31 0 015.186 7.23c-.38.054-.757.112-1.134.175C2.999 7.58 2.25 8.507 2.25 9.574V18a2.25 2.25 0 002.25 2.25h15A2.25 2.25 0 0021.75 18V9.574c0-1.067-.75-1.994-1.802-2.169a47.865 47.865 0 00-1.134-.175 2.31 2.31 0 01-1.64-1.055l-.822-1.316a2.192 2.192 0 00-1.736-1.039 48.774 48.774 0 00-5.232 0 2.192 2.192 0 00-1.736 1.039l-.821 1.316z"
                    />
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="M16.5 12.75a4.5 4.5 0 11-9 0 4.5 4.5 0 019 0zM18.75 10.5h.008v.008h-.008V10.5z"
                    />
                  </svg>
                </button>
              </div>
              <div class="text-center sm:text-left">
                <h2 class="text-2xl font-bold text-gray-800">by sotheara</h2>
                <p class="text-sm text-gray-500">vitouaj68@gmail.com</p>
                <span
                  class="inline-block mt-3 bg-blue-100 text-blue-800 text-xs font-semibold px-3 py-1 rounded-full"
                  >Student</span
                >
              </div>
            </div>
          </div>

          <form class="p-6 sm:p-8 space-y-8">
            <div>
              <h3
                class="text-lg font-semibold text-gray-800 flex items-center gap-2"
              >
                <svg
                  class="w-5 h-5 text-gray-400"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 20 20"
                  fill="currentColor"
                >
                  <path
                    fill-rule="evenodd"
                    d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-5.5-2.5a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0zM10 12a5.99 5.99 0 00-4.793 2.39A6.483 6.483 0 0010 16.5a6.483 6.483 0 004.793-2.11A5.99 5.99 0 0010 12z"
                    clip-rule="evenodd"
                  />
                </svg>
                Personal Information
              </h3>
              <div class="mt-6 grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                  <label
                    for="full_name"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Full Name</label
                  >
                  <input
                    type="text"
                    id="full_name"
                    value="by sotheara"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div>
                  <label
                    for="phone_number"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Phone Number</label
                  >
                  <input
                    type="tel"
                    id="phone_number"
                    value="0982192124"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div class="md:col-span-2">
                  <label
                    for="email_address"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Email Address</label
                  >
                  <input
                    type="email"
                    id="email_address"
                    value="vitouaj68@gmail.com"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg bg-gray-50 text-gray-500 cursor-not-allowed"
                    readonly
                  />
                </div>
              </div>
            </div>

            <div class="border-t border-gray-200"></div>

            <div>
              <h3
                class="text-lg font-semibold text-gray-800 flex items-center gap-2"
              >
                <svg
                  class="w-5 h-5 text-gray-400"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 20 20"
                  fill="currentColor"
                >
                  <path
                    d="M2.22 2.22a.75.75 0 011.06 0l1.25 1.25a.75.75 0 010 1.06l-1.06 1.06a.75.75 0 01-1.06 0l-1.25-1.25a.75.75 0 010-1.06l1.06-1.06zM15.869 9.13a.75.75 0 010 1.06l-1.06 1.06a.75.75 0 01-1.06 0l-1.25-1.25a.75.75 0 010-1.06l1.25-1.25a.75.75 0 011.06 0zM5.52 11.08a.75.75 0 011.06 0l1.25 1.25a.75.75 0 010 1.06l-1.06 1.06a.75.75 0 01-1.06 0l-1.25-1.25a.75.75 0 010-1.06l1.06-1.06zM12.94 4.54a.75.75 0 011.06 0l1.25 1.25a.75.75 0 010 1.06l-1.06 1.06a.75.75 0 01-1.06 0L11.89 6.61a.75.75 0 010-1.06l1.05-1.06zM9.13 2.22a.75.75 0 011.06 0l1.25 1.25a.75.75 0 010 1.06L10.19 5.8a.75.75 0 01-1.06 0l-1.25-1.25a.75.75 0 010-1.06l1.25-1.25zM11.08 15.52a.75.75 0 011.06 0l1.25 1.25a.75.75 0 010 1.06l-1.06 1.06a.75.75 0 01-1.06 0l-1.25-1.25a.75.75 0 010-1.06l1.06-1.06z"
                  />
                </svg>
                Contact & Address
              </h3>
              <div class="mt-6 grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                  <label
                    for="first_name"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >First Name</label
                  >
                  <input
                    type="text"
                    id="first_name"
                    value="By"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div>
                  <label
                    for="last_name"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Last Name</label
                  >
                  <input
                    type="text"
                    id="last_name"
                    value="Savong"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div>
                  <label
                    for="alternative_email"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Alternative Email</label
                  >
                  <input
                    type="email"
                    id="alternative_email"
                    value="savongfkyou@gmail.com"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div>
                  <label
                    for="alternative_phone"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Alternative Phone</label
                  >
                  <input
                    type="tel"
                    id="alternative_phone"
                    value="0291213314"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div class="md:col-span-2">
                  <label
                    for="street_address"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Street Address</label
                  >
                  <input
                    type="text"
                    id="street_address"
                    value="betong"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div>
                  <label
                    for="apartment"
                    class="block text-sm font-medium text-gray-700 mb-1"
                    >Apartment / Unit</label
                  >
                  <input
                    type="text"
                    id="apartment"
                    value="4st"
                    class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
              </div>
            </div>

            <div class="pt-6 border-t border-gray-200 flex justify-end gap-3">
              <button
                type="button"
                class="px-5 py-2.5 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded-lg hover:bg-gray-50 focus:ring-4 focus:ring-gray-200"
              >
                Cancel
              </button>
              <button
                type="submit"
                class="px-5 py-2.5 text-sm font-medium text-white bg-blue-600 rounded-lg hover:bg-blue-700 focus:ring-4 focus:ring-blue-300 flex items-center gap-2"
              >
                <svg
                  class="w-4 h-4"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 20 20"
                  fill="currentColor"
                >
                  <path
                    d="M2.695 14.763l-1.262 3.154a.5.5 0 00.65.65l3.155-1.262a4 4 0 001.343-.885L17.5 5.5a2.121 2.121 0 00-3-3L3.58 13.42a4 4 0 00-.885 1.343z"
                  />
                </svg>
                Save Changes
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </Layout>
</template>

<script setup lang="ts">
import { defineEmits, onMounted, ref } from "vue";
import { type User } from "./Home.vue";
import ContactForm from "./ContactForm.vue";
import Layout from "./Layout.vue";
import { ContactModel } from "./Auth.vue";
import { ROLE_MAPPER } from "../api/utility";
const emit = defineEmits(["goback"]);
const props = defineProps({
  user: {
    type: Object as () => User,
  },
  contacts: {
    type: Array<ContactModel>,
  },
});

const user = ref<User>();
onMounted(() => {
  user.value = props.user;
});
</script>
