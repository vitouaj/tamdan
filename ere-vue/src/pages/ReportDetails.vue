<script setup lang="ts">
import { defineEmits, computed } from "vue";
import Layout from "./Layout.vue";

const emit = defineEmits(["goback"]);

const props = defineProps({
  selectedReport: {
    type: Object,
  },
});

const greenStatus = ["FEEDBACK_RECIEVED", "READY"];

const conputedStatusStyle = computed(() => {
  if (greenStatus.includes(props.selectedReport?.report?.status)) {
    return "text-green-500 text-sm p-1 rounded bg-green-300";
  }
});
</script>

<template>
  <Layout>
    <div class="max-w-4xl pl-6 pt-8">
      <header class="mb-8">
        <h1 class="text-3xl font-bold text-gray-900">
          Monthly Report - April 2025
        </h1>
        <p class="text-sm text-gray-500 mt-1">
          Showing performance details for student
          <span class="font-medium text-gray-700">sotheara</span>.
        </p>
      </header>

      <div
        class="bg-white rounded-xl shadow-sm border border-gray-200 p-6 mb-8"
      >
        <h3 class="text-lg font-semibold text-gray-800 mb-4">
          Overall Performance
        </h3>
        <div class="grid grid-cols-2 sm:grid-cols-4 gap-4 text-center">
          <div>
            <p class="text-sm text-gray-500">Total Score</p>
            <p class="text-2xl font-bold text-gray-900">157</p>
          </div>
          <div>
            <p class="text-sm text-gray-500">Average Score</p>
            <p class="text-2xl font-bold text-gray-900">78.5</p>
          </div>
          <div>
            <p class="text-sm text-gray-500">Overall Grade</p>
            <p class="text-2xl font-bold text-green-600">B+</p>
          </div>
          <div>
            <p class="text-sm text-gray-500">Total Absences</p>
            <p class="text-2xl font-bold text-red-600">2</p>
          </div>
        </div>
      </div>

      <div class="bg-white rounded-xl shadow-sm border border-gray-200 mb-8">
        <div class="p-6">
          <h3 class="text-lg font-semibold text-gray-800">
            Performance Details
          </h3>
        </div>
        <div class="overflow-x-auto">
          <table class="w-full text-sm text-left text-gray-600">
            <thead class="bg-gray-50 text-xs text-gray-700 uppercase">
              <tr>
                <th scope="col" class="px-6 py-3">Subject</th>
                <th scope="col" class="px-6 py-3">Teacher Name</th>
                <th scope="col" class="px-6 py-3">Score</th>
                <th scope="col" class="px-6 py-3">Status</th>
                <th scope="col" class="px-6 py-3">Absences</th>
                <th scope="col" class="px-6 py-3">Comment</th>
              </tr>
            </thead>
            <tbody>
              <tr class="bg-white border-b hover:bg-gray-50">
                <td class="px-6 py-4 font-medium text-gray-900">Mathematics</td>
                <td class="px-6 py-4">Mr. Johnson</td>
                <td class="px-6 py-4 font-semibold">75</td>
                <td class="px-6 py-4">
                  <span
                    class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                    >Completed</span
                  >
                </td>
                <td class="px-6 py-4">2</td>
                <td class="px-6 py-4">Good progress</td>
              </tr>
              <tr class="bg-white hover:bg-gray-50">
                <td class="px-6 py-4 font-medium text-gray-900">English</td>
                <td class="px-6 py-4">Ms. Smith</td>
                <td class="px-6 py-4 font-semibold">82</td>
                <td class="px-6 py-4">
                  <span
                    class="px-3 py-1 text-xs font-medium rounded-full bg-indigo-100 text-indigo-800"
                    >In Progress</span
                  >
                </td>
                <td class="px-6 py-4">0</td>
                <td class="px-6 py-4">Excellent participation</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
        <div class="bg-white rounded-xl shadow-sm border border-gray-200 p-6">
          <h3 class="text-lg font-semibold text-gray-800 mb-2">
            Teacher's Comments
          </h3>
          <p class="text-sm text-gray-600 italic">
            "Please help him improve math with his girl friend"
          </p>
        </div>

        <div class="bg-white rounded-xl shadow-sm border border-gray-200 p-6">
          <h3 class="text-lg font-semibold text-gray-800 mb-2">
            Parent's Feedback
          </h3>

          <form class="mt-4 space-y-4">
            <div>
              <label for="parent-comment" class="sr-only">Parent Comment</label>
              <textarea
                id="parent-comment"
                name="parent-comment"
                rows="3"
                class="w-full px-4 py-2.5 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                placeholder="Share your thoughts on this report..."
              ></textarea>
            </div>
            <div class="flex justify-end">
              <button
                type="submit"
                class="flex items-center justify-center gap-2 px-5 py-2.5 text-sm font-medium text-white bg-blue-600 rounded-lg hover:bg-blue-700 focus:ring-4 focus:ring-blue-300 transition"
              >
                Submit Comment
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </Layout>
</template>
