<script lang="ts" setup>
import { ref } from "vue";
import { onMounted } from "vue";
import { DAY_OF_WEEK, LEVEL } from "../api/utility";
import { TIMES_OF_DAY } from "../api/utility";

export interface Course {
  level: Number;
  maxScore: Number;
  passingRate: Number;
  courseHours: Array<CourseHour>;
}

export interface CourseHour {
  day: Number;
  time: Number;
}

const emit = defineEmits(["saverecord"]);
const props = defineProps({
  course: {
    type: Object as () => Course,
  },
  options: {
    type: Object,
  },
});

const daysOfWeeek = DAY_OF_WEEK;
const levels = LEVEL;
const timesOfDay = TIMES_OF_DAY;
const timeOptions = ref([]);
const selectedDay = ref(0);
const course = ref<Course>({
  level: 1,
  maxScore: 1,
  passingRate: 1,
  courseHours: [
    {
      day: 0,
      time: 0,
    },
  ],
});

onMounted(() => {});

function clearForm() {
  course.value.level = 1;
  course.value.maxScore = 1;
  course.value.passingRate = 1;
  let dayElement = document.getElementById("courseDays");
  for (let i = 0; i < dayElement.options.length; i++) {
    if (dayElement.options[i].selected) {
      dayElement.options[i].selected = false;
    }
  }
  let timeElement = document.getElementById("courseTimes");
  for (let i = 0; i < timeElement.options.length; i++) {
    if (timeElement.options[i].selected) {
      timeElement.options[i].selected = false;
    }
  }
  selectedDay.value = 0;
  timeOptions.value = [];
}

function handleSelectDay(event) {
  const day = event.target.value;
  selectedDay.value = day;
  // clear selected times
  timeOptions.value = [];
  setTimeout(() => {
    if (props.options) timeOptions.value = props.options[day];
  }, 700);
}

function handleSaveRecord(event) {
  let selectElement = document.getElementById("courseTimes");
  const selectedValues = [];
  for (let i = 0; i < selectElement.options.length; i++) {
    if (selectElement.options[i].selected) {
      selectedValues.push(selectElement.options[i].value);
    }
  }
  course.value.courseHours = [];
  for (let i = 0; i < selectedValues.length; i++) {
    course.value.courseHours.push({
      day: parseInt(selectedDay.value),
      time: parseInt(selectedValues[i]),
    });
  }
  emit("saverecord", {
    detail: course.value,
  });
}

defineExpose({
  clearForm,
});
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
          <h3 class="modal-title">New</h3>
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
                placeholder="Select Course Days"
                id="courseDays"
                @change="handleSelectDay"
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              >
                <option default>Please choose</option>
                <option
                  :value="parseInt(day)"
                  v-for="day in Object.keys(options)"
                >
                  {{ daysOfWeeek[day] }}
                </option>
              </select>
            </div>
            <div class="col-span-1">
              <label
                for="courseTimes"
                class="block mb-2 text-sm font-medium text-gray-900"
                >Available Times</label
              >
              <select
                multiple
                id="courseTimes"
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              >
                <option
                  :disabled="option.disabled"
                  :value="parseInt(option.time)"
                  v-for="option in timeOptions"
                >
                  {{ timesOfDay[parseInt(option.time)] }}
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
            data-overlay="#basic-modal"
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
