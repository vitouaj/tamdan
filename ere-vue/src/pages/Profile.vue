<template>
  <span
    @click="emit('goback', { detail: { cmpName: 'home' } })"
    class="icon-[tabler--arrow-back-up] size-8"
  ></span>

  <div
    class="max-w-4xl w-full mx-auto p-8 transition-all duration-300 animate-fade-in"
  >
    <div class="flex flex-col gap-10">
      <div class="grid grid-cols-2 w-full gap-8">
        <div class="text-start mb-8 md:mb-0">
          <img
            src="https://i.pravatar.cc/300"
            alt="Profile Picture"
            class="rounded-full w-48 h-48 mb-4 border-4 border-indigo-800 dark:border-blue-900 transition-transform duration-300 hover:scale-105"
          />
          <h1 class="text-2xl font-bold mb-2">{{ user?.name }}</h1>
          <p class="">{{ ROLE_MAPPER[user?.role] }}</p>
          <span class="">{{ user?.subject }}</span>
        </div>
        <div class="col-span-1">
          <h2 class="text-xl font-semibold mb-4">Personal Information</h2>
          <template v-if="user">
            <div>
              <label class="text-sm block" for="#name">Name</label>
              <input
                type="text"
                v-model="user.name"
                class="ps-3 max-w-lg border-2 border-gray-300 rounded-lg w-full h-10 mb-4 focus:outline-none focus:ring-2 focus:ring-indigo-600 dark:focus:ring-blue-900 transition-all duration-300"
                id="name"
              />
            </div>
            <div>
              <label class="text-sm block" for="#name">Phone</label>
              <input
                type="text"
                v-model="user.phone"
                class="ps-3 max-w-lg border-2 border-gray-300 rounded-lg w-full h-10 mb-4 focus:outline-none focus:ring-2 focus:ring-indigo-600 dark:focus:ring-blue-900 transition-all duration-300"
                id="name"
              />
            </div>
            <div>
              <label class="text-sm block" for="#name">Email</label>
              <input
                type="email"
                v-model="user.email"
                class="ps-3 max-w-lg border-2 border-gray-300 rounded-lg w-full h-10 mb-4 focus:outline-none focus:ring-2 focus:ring-indigo-600 dark:focus:ring-blue-900 transition-all duration-300"
                id="name"
              />
            </div>
          </template>
        </div>
        <template v-if="contacts">
          <div class="col-span-2">
            <h2 class="text-xl font-semibold mb-4">Contacts Information</h2>
            <div class="">
              <ContactForm
                v-for="contact in contacts"
                :contactModel="contact"
              />
            </div>
          </div>
        </template>
      </div>
      <!-- contact information -->
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineEmits, onMounted, ref } from "vue";
import { type User } from "./Home.vue";
import ContactForm from "./ContactForm.vue";
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
