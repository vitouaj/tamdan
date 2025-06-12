<script lang="ts" setup>
import { ref } from "vue";
import { DAY_OF_WEEK, LEVEL, TIMES_OF_DAY } from "../../api/Utility";

const props = defineProps({
  course: {
    type: Object as () => Course,
  },
  options: {
    type: Object,
  },
});

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

// 1. Define a more comprehensive data model for the new form
// This object will hold all the form's state.

// Define an initial state to easily reset the form
const getInitialState = () => ({
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

// 2. Define the options for your form inputs
// This keeps your template clean and makes it easy to change options later.
const dayOptions = [
  { id: "day-mon", value: "Mon", label: "Mon" },
  { id: "day-tue", value: "Tue", label: "Tue" },
  { id: "day-wed", value: "Wed", label: "Wed" },
  { id: "day-thu", value: "Thu", label: "Thu" },
  { id: "day-fri", value: "Fri", label: "Fri" },
  { id: "day-sat", value: "Sat", label: "Sat" },
  { id: "day-sun", value: "Sun", label: "Sun" },
];

const levelOptions = [
  "Grade 10",
  "Grade 11",
  "Grade 12",
  "Beginner",
  "Intermediate",
  "Advanced",
];

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

// 3. Handle form submission
// No more DOM manipulation! All data is already in the `course` ref.
function saveAndPublish() {
  console.log("Saving and publishing course:", course.value);
  // You can now emit the data to a parent component or send it to an API.
  // emit('saveCourse', course.value);
  alert("Course saved! Check the console for the data.");
}

function saveAsDraft() {
  console.log("Saving course as draft:", course.value);
  alert("Draft saved! Check the console for the data.");
}

// 4. Refactor the clearForm method
// Instead of touching the DOM, just reset the reactive state.
function clearForm() {
  course.value = getInitialState();
}

function handleCancel() {
  clearForm();
  // Optional: navigate away or close a modal
  console.log("Form cleared and cancelled.");
}
</script>

<template>
  <div class="max-w-6xl mx-auto p-4">
    <header class="mb-6">
      <h1 class="text-3xl font-bold text-gray-900">Create New Course</h1>
      <p class="text-sm text-gray-500 mt-1">
        Fill out the details below to set up a new course.
      </p>
    </header>

    <div class="grid grid-cols-2 gap-4">
      <div class="col-span-1">
        <label for="level" class="block mb-2 text-sm font-medium text-gray-900"
          >Which level</label
        >
        <select
          v-model="course.level"
          id="level"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:border-gray-600 dark:focus:ring-blue-500 dark:focus:border-blue-500"
        >
          <option :value="parseInt(level)" v-for="level in Object.keys(levels)">
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
          <!-- <option :value="parseInt(day)" v-for="day in Object.keys(options)">
            {{ daysOfWeeek[day] }}
          </option> -->
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
          <!-- <option
            :disabled="option.disabled"
            :value="parseInt(option.time)"
            v-for="option in timeOptions"
          >
            {{ timesOfDay[parseInt(option.time)] }}
          </option> -->
        </select>
      </div>
    </div>
  </div>
</template>
