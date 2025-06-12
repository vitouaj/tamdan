<template>
  <div class="bg-gray-100 font-sans">
    <div class="flex h-screen bg-gray-100">
      <aside
        id="sidebar"
        class="hidden md:flex md:flex-col md:w-64 bg-slate-800 text-white mobile-sidebar fixed inset-y-0 left-0 z-30 md:relative md:translate-x-0 transform -translate-x-full"
      >
        <div class="px-6 py-8">
          <h1 class="text-2xl font-bold text-white">ERE System</h1>
          <p class="text-sm text-slate-300">{{ roleDisplay }} Portal</p>
        </div>

        <nav class="flex-1 px-4 space-y-2">
          <a
            @click="hideSchedule"
            class="flex items-center gap-4 px-4 py-3 text-slate-300 hover:bg-slate-700 rounded-md"
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
                d="M2.25 12l8.954-8.955c.44-.439 1.152-.439 1.591 0L21.75 12M4.5 9.75v10.125c0 .621.504 1.125 1.125 1.125H9.75v-4.875c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125V21h4.125c.621 0 1.125-.504 1.125-1.125V9.75M8.25 21h7.5"
              />
            </svg>
            <span class="font-medium">Overview</span>
          </a>
          <a
            @click="showSchedule"
            class="flex items-center gap-4 px-4 py-3 text-slate-300 hover:bg-slate-700 rounded-md"
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
                d="M6.75 3v2.25M17.25 3v2.25M3 18.75V7.5a2.25 2.25 0 012.25-2.25h13.5A2.25 2.25 0 0121 7.5v11.25m-18 0A2.25 2.25 0 005.25 21h13.5A2.25 2.25 0 0021 18.75m-18 0v-7.5A2.25 2.25 0 015.25 9h13.5A2.25 2.25 0 0121 11.25v7.5m-9-6h.008v.008H12v-.008z"
              />
            </svg>
            <span class="font-medium">Schedules</span>
          </a>
        </nav>

        <div class="px-6 py-4 border-t border-slate-700">
          <div class="flex items-center justify-between">
            <div class="flex items-center gap-3">
              <a
                href="/me"
                class="w-10 h-10 rounded-full bg-blue-500 flex items-center justify-center font-bold"
              >
                U
              </a>
              <div>
                <p class="text-sm font-medium text-white">Student User</p>
                <p class="text-xs text-slate-400">user@example.com</p>
              </div>
            </div>
            <button class="p-2 rounded-md hover:bg-slate-700">
              <svg
                class="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M15.75 6a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0zM4.501 20.118a7.5 7.5 0 0114.998 0A17.933 17.933 0 0112 21.75c-2.676 0-5.216-.584-7.499-1.632z"
                />
              </svg>
            </button>
          </div>
        </div>
      </aside>
      <div class="sm:p-6 lg:p-8 w-full">
        <slot id="main--content"></slot>
      </div>
    </div>
  </div>
</template>

<script lang="js" setup>
import { defineProps, onMounted } from "vue";
import { ref } from "vue";
const menuButton = document.getElementById("menu-button");
const sidebar = document.getElementById("sidebar");
if (menuButton != null) {
  menuButton.addEventListener("click", () => {
    sidebar.classList.toggle("hidden");
    sidebar.classList.toggle("-translate-x-full");
  });
}

const props = defineProps({
  role: {
    type: String,
  },
  showSchedule: {
    type: Function,
  },
  hideSchedule: {
    type: Function,
  },
});

function showSchedule() {
  props.showSchedule();
}

function hideSchedule() {
  props.hideSchedule();
}

const roleDisplay = ref("");
function displayRole() {
  if (props.role === 1) {
    return "Student";
  } else if (props.role === 2) {
    return "Teacher";
  } else {
    return "Parent";
  }
}

onMounted(() => {
  roleDisplay.value = displayRole();
});
</script>
