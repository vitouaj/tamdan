<template>
  <form v-if="registerModel" class="space-y-4 md:space-y-6" action="#">
    <div class="grid grid-cols-2 gap-4">
      <div class="col-span-1">
        <label for="firstname" class="block mb-2 text-sm font-medium"
          >Firstname</label
        >
        <input
          type="text"
          name="firstname"
          id="firstname"
          v-model="registerModel.firstName"
          class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
          placeholder="firstname"
          required
        />
      </div>
      <div class="col-span-1">
        <label for="lastname" class="block mb-2 text-sm font-medium"
          >Lastname</label
        >
        <input
          type="text"
          name="lastname"
          v-model="registerModel.lastName"
          id="lastname"
          class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
          placeholder="lastname"
          required
        />
      </div>
    </div>

    <div>
      <label for="email" class="block mb-2 text-sm font-medium">Email</label>
      <input
        type="email"
        name="email"
        v-model="registerModel.email"
        id="email"
        class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
        placeholder="name@company.com"
        required
      />
    </div>
    <div>
      <label for="phone" class="block mb-2 text-sm font-medium">Phone</label>
      <input
        type="text"
        name="phone"
        v-model="registerModel.phone"
        id="phone"
        class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
        placeholder="01992121"
        required
      />
    </div>
    <div>
      <label for="password" class="block mb-2 text-sm font-medium"
        >Password</label
      >
      <input
        type="password"
        v-model="registerModel.password"
        name="password"
        id="password"
        placeholder="••••••••"
        class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
        required
      />
    </div>
    <div class="grid grid-cols-2 gap-4">
      <div class="col-span-1">
        <label for="roles" class="block mb-2 text-sm font-medium"
          >Are you a student or teacher?</label
        >
        <select
          v-model="registerModel.role"
          required="true"
          id="roles"
          class="bg-gray-50 required border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-3 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
        >
          <option selected>Choose a role</option>
          <template v-if="roleOptions">
            <option v-for="option in roleOptions" :value="option.id">
              {{ option.name }}
            </option>
          </template>
        </select>
      </div>
      <template v-if="registerModel.role == 2">
        <div class="col-span-1">
          <label for="subjects" class="block mb-2 text-sm font-medium"
            >What subject do you teach?</label
          >
          <select
            v-model="registerModel.subject"
            required="true"
            id="subjects"
            class="bg-gray-50 required border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-3 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
            <option selected>Choose a subject</option>
            <template v-if="subjectOptions">
              <option v-for="option in subjectOptions" :value="option.id">
                {{ option.name }}
              </option>
            </template>
          </select>
        </div>
      </template>
      <template v-if="registerModel.role == 1">
        <div class="col-span-1">
          <label for="level" class="block mb-2 text-sm font-medium"
            >Which level are you?</label
          >
          <select
            v-model="registerModel.levelId"
            required="true"
            id="level"
            class="bg-gray-50 required border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-3 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
            <option selected>Choose a level</option>
            <template v-if="levelOptions">
              <option v-for="option in levelOptions" :value="option.id">
                {{ option.name }}
              </option>
            </template>
          </select>
        </div>
      </template>
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
          <label for="remember" class="text-black"
            >Agree our terms and conditions</label
          >
        </div>
      </div>
    </div>

    <div class="flex justify-end">
      <button
        @click.stop.prevent="handleNextStep"
        class="text-white bg-primary hover:bg-white-400 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
      >
        Next
      </button>
    </div>
  </form>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { loadSubjectOptions } from "../api/controllers";
import { RegisterModel } from "./Auth.vue";

const props = defineProps<{
  registerModel: RegisterModel;
  handleNextStep: any;
}>();

const subjectOptions = ref<{ id: number; name: string }[]>([]);
const roleOptions = ref<{ id: number; name: string }[]>([]);
const levelOptions = ref<{ id: number; name: string }[]>([]);

onMounted(async () => {
  let options = await loadSubjectOptions();
  subjectOptions.value = options?.payload?.subjectOptions;
  roleOptions.value = options?.payload?.roleOptions;
  levelOptions.value = options?.payload?.levelOptions;
});
</script>
