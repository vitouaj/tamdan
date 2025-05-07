<template>
  <section class="relative min-h-screen overflow-hidden">
    <div
      class="absolute inset-0 bg-[url('https://newsroomcambodia.com/wp-content/uploads/2020/01/1280px-School_kids_jumping_in_Cambodia_13578591625.jpg')] bg-cover bg-center bg-no-repeat blur-sm"
    ></div>

    <div class="absolute inset-0 bg-black bg-opacity-30"></div>

    <div
      class="relative z-10 flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0"
    >
      <div class="bg-opacity-60 bg-gray-300 rounded-lg p-6 w-2/4">
        <template v-if="isStep1">
          <h1 class="text-2xl py-4 font-bold text-gray-900">Register</h1>

          <UserRegisterForm
            :registerModel="registerModel"
            :handleNextStep="handleNextStep"
          />
          <div class="text-sm font-light text-black">
            Already had an account?
            <a
              @click="emit('toggleSignin')"
              class="font-medium text-primary-600 dark:text-primary-500 cursor-pointer"
              >Sign in</a
            >
          </div>
        </template>
        <template v-if="isStep2">
          <h1 class="text-2xl py-4 font-bold text-gray-900">Contacts</h1>
          <ContactForm :contactModel="contactModel" />
          <div class="flex justify-between">
            <button
              @click.stop.prevent="goToStep(1)"
              class="text-white bg-primary hover:bg-white-400 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
            >
              Previous
            </button>
            <button
              @click.stop.prevent="handleSubmit"
              class="text-white bg-primary hover:bg-white-400 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
            >
              Register
            </button>
          </div>
        </template>
      </div>
    </div>
  </section>
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
</script>
