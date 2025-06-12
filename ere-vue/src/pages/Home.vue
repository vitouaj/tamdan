<template>
  <Layout
    :hideSchedule="doHideSchedule"
    :showSchedule="doShowSchedule"
    :role="role"
  >
    <template v-if="showSchedule">
      <Schedules :user="payload.user" />
    </template>
    <template v-else="showSchedule">
      <ParentDashboard v-if="role === 3" :payload="payload" />
      <StudentDashboard v-if="role === 1" :payload="payload" />
      <TeacherDashboard v-if="role === 2" :payload="payload" />
    </template>
  </Layout>
</template>

<script setup lang="ts">
import Layout from "./Layout.vue";
import { onMounted, ref } from "vue";
import { getUser } from "../api/API_Calls";
import StudentDashboard from "../components/dashboard/StudentDashboard.vue";
import ParentDashboard from "../components/dashboard/ParentDashboard.vue";
import TeacherDashboard from "../components/dashboard/TeacherDashboard.vue";
import { showToast } from "../api/Utility";
import { useRouter } from "vue-router";
import Schedules from "./Schedules.vue";

onMounted(async () => {
  await initHomeData();
});

const router = useRouter();
const role = ref(1); // Change this to "parent" or "student" as needed 1 = student, 2 = teacher, 3 = parent
const payload = ref({});

const showSchedule = ref(false);
function doShowSchedule() {
  return (showSchedule.value = true);
}

function doHideSchedule() {
  return (showSchedule.value = false);
}

async function initHomeData() {
  try {
    const response = await getUser();
    const { success } = response.data;
    const { data } = response;
    if (success) {
      console.log("User data loaded successfully:", data.payload);
      payload.value = data.payload; // Store the payload for further use
      const { user } = payload.value;
      role.value = user.role; // Set the role based on the user data
    } else {
      showToast({
        type: "error",
        message: data.message || "Failed to load user data.",
        duration: 3000,
      });
    }
  } catch (error) {
    console.error("Error loading user data:", error);
    if (error.status === 401) {
      router.push("/login");
      return;
    }
    showToast({
      type: "error",
      message: error.message || "An error occurred while loading user data.",
      duration: 3000,
      stack: error.stack,
    });
  }
}
</script>
