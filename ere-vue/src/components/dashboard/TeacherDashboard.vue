<script setup lang="ts">
import { ref } from "vue";
import { defineProps } from "vue";
import StateLoading from "../ui/StateLoading.vue";
import { showToast, Util } from "../../api/Utility";
import { updateEnollmentStatus } from "../../api/API_Calls";
const props = defineProps({
  payload: {
    type: Object,
    required: true,
  },
});

const showCourseDetial = ref(false);
const courseDetail = ref({});
const enrollmentsDetail = ref([]);
const stateLoading = ref(false);
const selectedEnrollments = ref([]);

function handleCourseDetailClick(event) {
  stateLoading.value = true;
  let courseId = event.currentTarget.getAttribute("data-course-id");
  showCourseDetial.value = true;
  let findCourse = props.payload.courses.find((c) => c.id === courseId);
  enrollmentsDetail.value = props.payload.enrollments[courseId] || [];
  if (findCourse) {
    courseDetail.value = findCourse;
  } else {
    console.error("Course not found:", courseId);
  }
  stateLoading.value = false;
}

function handleSelectAll(event) {
  let isChecked = event.target.checked;
  let checkboxes = document.querySelectorAll(
    'input[type="checkbox"][data-enrollment-id]'
  );
  checkboxes.forEach((checkbox) => {
    checkbox.checked = isChecked;
  });

  if (isChecked) {
    let clonedEnrollments = Util.deepCloneData(enrollmentsDetail.value);
    selectedEnrollments.value = clonedEnrollments.map(
      (enrollment) => enrollment.id
    );
  } else {
    selectedEnrollments.value = [];
  }
  console.log("Selected enrollment ID:", selectedEnrollments.value);
}

function handleSelect(event) {
  let isChecked = event.target.checked;
  let enrollmentId = event.currentTarget.getAttribute("data-enrollment-id");
  if (isChecked && enrollmentId) {
    selectedEnrollments.value.push(enrollmentId);
  } else {
    selectedEnrollments.value = selectedEnrollments.value.filter(
      (id) => id !== enrollmentId
    );
  }
  console.log("Selected enrollment ID:", selectedEnrollments.value);
}

async function doApproveEnrollments() {
  stateLoading.value = true;
  const selectedIds = Util.deepCloneData(selectedEnrollments.value);
  try {
    const response = await updateEnollmentStatus(selectedIds);
    if (response.status === 200) {
      stateLoading.value = false;
      showToast({
        type: "success",
        message: response.data.message,
      });
    }
  } catch (error) {
    console.error(error);
  } finally {
    setTimeout(() => {
      stateLoading.value = false;
    }, 1000);
  }
}
</script>

<template>
  <StateLoading :isLoading="stateLoading" />
  <div v-if="showCourseDetial" class="bg-gray-50 font-sans">
    <div class="w-full">
      <h1 class="text-3xl font-bold text-gray-900 mb-6">Course Management</h1>

      <div class="mb-8">
        <div
          class="bg-white inline-block rounded-xl shadow-sm border border-gray-200 p-5"
        >
          <div class="flex items-center gap-3">
            <div class="bg-green-100 rounded-full p-2">
              <svg
                class="w-5 h-5 text-green-600"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M18 18.72a9.094 9.094 0 003.741-.479 3 3 0 00-4.682-2.72m-7.5-2.962A3 3 0 013 10.5V12a9 9 0 0118 0v-1.5a3 3 0 01-3-3H6a3 3 0 01-3 3z"
                />
              </svg>
            </div>
            <span class="text-sm font-medium text-gray-600">Total Enroll</span>
          </div>
          <div class="mt-2 ml-1">
            <p class="text-3xl font-semibold text-gray-900">
              {{ enrollmentsDetail.length || 0 }}
            </p>
            <p class="text-sm text-green-600">+8% from last month</p>
          </div>
        </div>
      </div>

      <div class="bg-white rounded-xl shadow-sm border border-gray-200">
        <div class="p-4 sm:p-6 border-b border-gray-200">
          <div
            class="flex flex-col sm:flex-row items-start sm:items-center justify-between gap-4"
          >
            <div>
              <h2 class="text-xl font-semibold text-gray-800">Enrollments</h2>
            </div>
            <div
              class="flex flex-col sm:flex-row items-start sm:items-center gap-3 w-full sm:w-auto"
            >
              <div class="relative w-full sm:w-auto">
                <div
                  class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none"
                >
                  <svg
                    class="w-5 h-5 text-gray-400"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke-width="1.5"
                    stroke="currentColor"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="M21 21l-5.197-5.197m0 0A7.5 7.5 0 105.196 5.196a7.5 7.5 0 0010.607 10.607z"
                    />
                  </svg>
                </div>
                <input
                  type="text"
                  placeholder="Search enrollments..."
                  class="w-full sm:w-64 bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block pl-10 p-2.5"
                />
              </div>
              <button
                :disabled="selectedEnrollments.length === 0"
                @click="doApproveEnrollments"
                class="w-full sm:w-auto flex items-center justify-center gap-2 px-4 py-2.5 text-sm font-medium text-white bg-blue-600 rounded-lg hover:bg-blue-700 focus:ring-4 focus:ring-blue-300 disabled:bg-gray-300"
              >
                <svg
                  class="w-5 h-5"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 20 20"
                  fill="currentColor"
                >
                  <path
                    fill-rule="evenodd"
                    d="M10 18a8 8 0 100-16 8 8 0 000 16zm.75-11.25a.75.75 0 00-1.5 0v2.5h-2.5a.75.75 0 000 1.5h2.5v2.5a.75.75 0 001.5 0v-2.5h2.5a.75.75 0 000-1.5h-2.5v-2.5z"
                    clip-rule="evenodd"
                  />
                </svg>
                Approve
              </button>
            </div>
          </div>
        </div>

        <div class="overflow-x-auto">
          <table class="w-full text-sm text-left text-gray-600">
            <thead class="bg-gray-50 text-xs text-gray-700 uppercase">
              <tr>
                <th scope="col" class="p-4">
                  <div class="flex items-center">
                    <input
                      id="checkbox-all"
                      @change="handleSelectAll"
                      type="checkbox"
                      class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500"
                    />
                    <label for="checkbox-all" class="sr-only">checkbox</label>
                  </div>
                </th>
                <th scope="col" class="px-6 py-3">Student</th>
                <th scope="col" class="px-6 py-3">Course</th>
                <th scope="col" class="px-6 py-3">Enrollment Date</th>
                <th scope="col" class="px-6 py-3">Status</th>
                <th scope="col" class="px-6 py-3">Teacher</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="enrollment in enrollmentsDetail"
                :key="enrollment.id"
                class="bg-white border-b hover:bg-gray-50"
              >
                <td class="w-4 p-4">
                  <div class="flex items-center">
                    <input
                      id="checkbox-table-1"
                      @change="handleSelect"
                      :data-enrollment-id="enrollment.id"
                      type="checkbox"
                      class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500"
                    />
                    <label for="checkbox-table-1" class="sr-only"
                      >checkbox</label
                    >
                  </div>
                </td>
                <td class="px-6 py-4">
                  <div class="flex items-center gap-3">
                    <img
                      class="w-9 h-9 rounded-full object-cover"
                      src="https://i.pravatar.cc/40?u=chit_soknea"
                      alt="chit soknea avatar"
                    />
                    <div class="font-medium text-gray-900 whitespace-nowrap">
                      {{ enrollment.studentName }}
                    </div>
                  </div>
                </td>
                <td class="px-6 py-4">{{ enrollment.courseName }}</td>
                <td class="px-6 py-4">{{ enrollment.enrollmentDate }}</td>
                <td class="px-6 py-4">
                  <span
                    class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                    >{{ enrollment.status }}</span
                  >
                </td>
                <td class="px-6 py-4">{{ enrollment.level }}</td>
              </tr>
            </tbody>
          </table>
        </div>

        <div
          class="p-4 flex flex-col sm:flex-row items-center justify-between gap-4"
        >
          <span class="text-sm text-gray-700">
            Showing <span class="font-semibold text-gray-900">1</span> to
            <span class="font-semibold text-gray-900">3</span> of
            <span class="font-semibold text-gray-900">3</span> entries
          </span>
          <div class="inline-flex items-center -space-x-px">
            <a
              href="#"
              class="px-3 py-2 ml-0 leading-tight text-gray-500 bg-white border border-gray-300 rounded-l-lg hover:bg-gray-100 hover:text-gray-700"
              >Previous</a
            >
            <a
              href="#"
              aria-current="page"
              class="px-3 py-2 text-blue-600 border border-gray-300 bg-blue-50 hover:bg-blue-100 hover:text-blue-700"
              >1</a
            >
            <a
              href="#"
              class="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700"
              >2</a
            >
            <a
              href="#"
              class="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 rounded-r-lg hover:bg-gray-100 hover:text-gray-700"
              >Next</a
            >
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-else="showCourseDetial" class="max-w-7xl w-full">
    <header class="mb-[3rem]">
      <h1 class="text-3xl font-bold text-gray-900">My Courses</h1>
      <p class="text-sm text-gray-500 mt-1">
        Manage and view the courses you have created.
      </p>
    </header>

    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
      <a
        href="/create-course"
        class="flex flex-col items-center justify-center bg-white rounded-xl border-2 border-dashed border-gray-300 text-gray-500 hover:border-blue-500 hover:text-blue-500 transition-all duration-300 min-h-[350px] transform hover:-translate-y-1"
      >
        <div class="text-center">
          <svg
            class="mx-auto h-12 w-12"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M12 4.5v15m7.5-7.5h-15"
            />
          </svg>
          <p class="mt-2 font-semibold">Create New Course</p>
        </div>
      </a>

      <a
        @click="handleCourseDetailClick"
        v-for="course in payload.courses"
        :key="course.id"
        :data-course-id="course.id"
        class="bg-white rounded-xl shadow-md overflow-hidden transform hover:-translate-y-1 transition-all duration-300"
      >
        <img
          class="w-full h-40 object-cover"
          src="https://images.unsplash.com/photo-1456513080510-7bf3a84b82f8?q=80&w=1973&auto=format&fit=crop"
          alt="Mathematics Course"
        />
        <div class="p-6">
          <div class="flex items-start justify-between">
            <div>
              <span
                class="text-xs font-semibold text-blue-800 bg-blue-100 px-2 py-1 rounded-full"
                >{{ course.level }}</span
              >
              <h3 class="text-xl font-bold text-gray-900 mt-2">
                {{ course.subject }}
              </h3>
            </div>
            <button
              class="text-gray-400 hover:text-gray-600 p-1 rounded-full hover:bg-gray-100"
            >
              <svg
                class="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z"
                />
              </svg>
            </button>
          </div>
          <div class="mt-4 space-y-3 text-sm text-gray-600">
            <div class="flex items-center gap-2">
              <svg
                class="w-5 h-5 text-gray-400"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-4.67c.12-.24.232-.487.335-.737m-3.058 3.058A12.31 12.31 0 016.624 21c-2.662 0-5.133-.688-7.247-1.917C4.78 17.165 6.84 16.5 9 16.5c.338 0 .671.017 1.003.051"
                />
              </svg>
              <span>42 Enrolled Students</span>
            </div>
            <div class="flex items-center gap-2">
              <svg
                class="w-5 h-5 text-green-500"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
                  clip-rule="evenodd"
                />
              </svg>
              <span
                >Status:
                <span class="font-medium text-green-700">Published</span></span
              >
            </div>
          </div>
          <div class="mt-4">
            <p class="text-sm text-gray-500">Average Completion</p>
            <div class="flex items-center gap-2 mt-1">
              <div class="w-full bg-gray-200 rounded-full h-2">
                <div
                  class="bg-blue-600 h-2 rounded-full"
                  style="width: 75%"
                ></div>
              </div>
              <span class="text-sm font-semibold text-gray-700">75%</span>
            </div>
          </div>
        </div>
      </a>
    </div>
  </div>
</template>

<style scoped></style>
