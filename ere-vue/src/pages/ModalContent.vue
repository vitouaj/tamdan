<script lang="ts" setup>
import { ref } from "vue";
import { onMounted } from "vue";
import { DAY_OF_WEEK, LEVEL } from "../api/utility";
import { TIMES_OF_DAY } from "../api/utility";

export interface Course {
  level: Number;
  maxScore: Number;
  passingRate: Number;
  courseDays: Array<Number>;
  courseTimes: Array<Number>;
}

const daysOfWeeek = DAY_OF_WEEK;
const levels = LEVEL;
const timesOfDay = TIMES_OF_DAY;

const emit = defineEmits(["saverecord"]);
const props = defineProps({
  course: {
    type: Object as () => Course,
  },
});

const course = ref<Course>({
  level: 1,
  maxScore: 1,
  passingRate: 1,
  courseDays: [1],

  courseTimes: [1],
});

onMounted(() => {});

function handleSaveRecord(event) {
  emit("saverecord", {
    detail: course.value,
  });
}
</script>
<template>
  <div
    id="basic-modal"
    class="overlay modal overlay-open:opacity-100 hidden overlay-open:duration-300"
    role="dialog"
    tabindex="-1"
  >
    <div
      class="modal-dialog overlay-open:opacity-100 overlay-open:duration-300"
    >
      <div class="modal-content">
        <div class="modal-header">
          <h3 class="modal-title">Create New</h3>
          <button
            type="button"
            class="btn btn-text btn-circle btn-sm absolute end-3 top-3"
            aria-label="Close"
            data-overlay="#basic-modal"
          >
            <span class="icon-[tabler--x] size-4"></span>
          </button>
        </div>
        <div class="modal-body">
          <div class="grid grid-cols-2 gap-4">
            <div class="col-span-1">
              <label
                for="level"
                class="block mb-2 text-sm font-medium text-gray-900"
                >Which level</label
              >
              <select
                v-model="course.level"
                id="level"
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              >
                <option
                  :value="parseInt(level)"
                  v-for="level in Object.keys(levels)"
                >
                  {{ levels[level] }}
                </option>
              </select>
            </div>
            <div class="col-span-1">
              <label
                for="maxScore"
                class="block mb-2 text-sm font-medium text-gray-900"
                >Max Score</label
              >
              <input
                v-model="course.maxScore"
                id="maxScore"
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
                type="number"
              />
            </div>
            <div class="col-span-1">
              <label
                for="courseDays"
                class="block mb-2 text-sm font-medium text-gray-900"
                >Course Days</label
              >
              <select
                v-model="course.courseDays"
                multiple
                id="courseDays"
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              >
                <option
                  :value="parseInt(day)"
                  v-for="day in Object.keys(daysOfWeeek)"
                >
                  {{ daysOfWeeek[day] }}
                </option>
              </select>
            </div>
            <div class="col-span-1">
              <label
                for="courseTimes"
                class="block mb-2 text-sm font-medium text-gray-900"
                >Course Times</label
              >
              <select
                multiple
                v-model="course.courseTimes"
                id="courseTimes"
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              >
                <option
                  :value="parseInt(time)"
                  v-for="time in Object.keys(timesOfDay)"
                >
                  {{ timesOfDay[time] }}
                </option>
              </select>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-soft btn-secondary"
            data-overlay="#basic-modal"
          >
            Close
          </button>
          <button
            @click="handleSaveRecord"
            type="button"
            class="btn btn-primary"
          >
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
