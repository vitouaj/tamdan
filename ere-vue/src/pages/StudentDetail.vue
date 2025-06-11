<template>
  <Layout>
    <div class="pt-[3rem] px-[3rem] mx-auto">
      <header
        class="bg-white rounded-xl shadow-sm border border-gray-200 p-6 mb-8"
      >
        <div
          class="flex flex-col sm:flex-row items-start sm:items-center justify-between"
        >
          <div class="flex items-center gap-5">
            <div
              class="w-20 h-20 rounded-full bg-blue-100 flex items-center justify-center text-blue-600 text-3xl font-bold"
            >
              S
            </div>
            <div>
              <h1 class="text-3xl font-bold text-gray-900">sotheara</h1>
              <p class="text-sm text-gray-500 mt-1">
                Student ID: 94f4d0ff-a2da-4794-baff-308bcd59511d
              </p>
              <p class="text-sm text-gray-500">Level 11</p>
            </div>
          </div>
          <div
            class="mt-4 sm:mt-0 flex flex-col sm:flex-row items-stretch gap-3 w-full sm:w-auto"
          >
            <a
              href="#"
              class="w-full sm:w-auto flex items-center justify-center gap-2 px-5 py-2.5 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded-lg hover:bg-gray-50 transition"
            >
              <svg
                class="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M3 4a2 2 0 00-2 2v1.161l8.441 4.221a1.25 1.25 0 001.118 0L19 7.162V6a2 2 0 00-2-2H3z"
                />
                <path
                  d="M19 8.839l-7.77 3.885a2.75 2.75 0 01-2.46 0L1 8.839V14a2 2 0 002 2h14a2 2 0 002-2V8.839z"
                />
              </svg>
              Send Message
            </a>
            <a
              href="#"
              class="w-full sm:w-auto flex items-center justify-center gap-2 px-5 py-2.5 text-sm font-medium text-white bg-blue-600 rounded-lg hover:bg-blue-700 focus:ring-4 focus:ring-blue-300 transition"
            >
              <svg
                class="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-5.5-2.5a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0zM10 12a5.99 5.99 0 00-4.793 2.39A6.483 6.483 0 0010 16.5a6.483 6.483 0 004.793-2.11A5.99 5.99 0 0010 12z"
                  clip-rule="evenodd"
                />
              </svg>
              View Full Profile
            </a>
          </div>
        </div>
      </header>

      <div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
        <div class="lg:col-span-2 space-y-8">
          <div class="bg-white rounded-xl shadow-sm border border-gray-200">
            <div class="p-6">
              <h3 class="text-lg font-semibold text-gray-800">
                Performance History
              </h3>
            </div>
            <div class="overflow-x-auto">
              <table class="w-full text-sm text-left text-gray-600">
                <thead class="bg-gray-50 text-xs text-gray-700 uppercase">
                  <tr>
                    <th scope="col" class="px-6 py-3">Report Month</th>
                    <th scope="col" class="px-6 py-3">Total Score</th>
                    <th scope="col" class="px-6 py-3">Absences</th>
                    <th scope="col" class="px-6 py-3">Overall Grade</th>
                    <th scope="col" class="px-6 py-3">Status</th>
                    <th scope="col" class="px-6 py-3">
                      <span class="sr-only">Actions</span>
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr class="bg-white border-b hover:bg-gray-50">
                    <td class="px-6 py-4 font-medium text-gray-900">
                      May 2025
                    </td>
                    <td class="px-6 py-4">168</td>
                    <td class="px-6 py-4">1</td>
                    <td class="px-6 py-4 font-semibold text-green-700">A-</td>
                    <td class="px-6 py-4">
                      <span
                        class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                        >Completed</span
                      >
                    </td>
                    <td class="px-6 py-4 text-right">
                      <a
                        href="#"
                        class="font-medium text-blue-600 hover:underline"
                        >View Report</a
                      >
                    </td>
                  </tr>
                  <tr class="bg-white border-b hover:bg-gray-50">
                    <td class="px-6 py-4 font-medium text-gray-900">
                      April 2025
                    </td>
                    <td class="px-6 py-4">157</td>
                    <td class="px-6 py-4">2</td>
                    <td class="px-6 py-4 font-semibold text-blue-700">B+</td>
                    <td class="px-6 py-4">
                      <span
                        class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                        >Completed</span
                      >
                    </td>
                    <td class="px-6 py-4 text-right">
                      <a
                        href="#"
                        class="font-medium text-blue-600 hover:underline"
                        >View Report</a
                      >
                    </td>
                  </tr>
                  <tr class="bg-white hover:bg-gray-50">
                    <td class="px-6 py-4 font-medium text-gray-900">
                      March 2025
                    </td>
                    <td class="px-6 py-4">145</td>
                    <td class="px-6 py-4">4</td>
                    <td class="px-6 py-4 font-semibold text-yellow-800">C+</td>
                    <td class="px-6 py-4">
                      <span
                        class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                        >Completed</span
                      >
                    </td>
                    <td class="px-6 py-4 text-right">
                      <a
                        href="#"
                        class="font-medium text-blue-600 hover:underline"
                        >View Report</a
                      >
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>

        <div class="lg:col-span-1">
          <div class="bg-white rounded-xl shadow-sm border border-gray-200">
            <div class="p-6">
              <h3 class="text-lg font-semibold text-gray-800">
                Issue New Report
              </h3>
            </div>
            <form class="p-6 border-t border-gray-200 space-y-5">
              <div>
                <label
                  for="report-month"
                  class="block text-sm font-medium text-gray-700"
                  >Report Month</label
                >
                <select
                  id="report-month"
                  name="report-month"
                  required
                  class="mt-1 block w-full px-3 py-2.5 border border-gray-300 bg-white rounded-lg shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                >
                  <option>June 2025</option>
                  <option>July 2025</option>
                  <option>August 2025</option>
                </select>
              </div>
              <div class="grid grid-cols-2 gap-4">
                <div>
                  <label
                    for="total-score"
                    class="block text-sm font-medium text-gray-700"
                    >Total Score</label
                  >
                  <input
                    type="number"
                    id="total-score"
                    name="total-score"
                    required
                    class="mt-1 w-full px-4 py-2.5 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
                <div>
                  <label
                    for="total-absences"
                    class="block text-sm font-medium text-gray-700"
                    >Absences</label
                  >
                  <input
                    type="number"
                    id="total-absences"
                    name="total-absences"
                    required
                    class="mt-1 w-full px-4 py-2.5 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                  />
                </div>
              </div>
              <div>
                <label
                  for="overall-grade"
                  class="block text-sm font-medium text-gray-700"
                  >Overall Grade</label
                >
                <input
                  type="text"
                  id="overall-grade"
                  name="overall-grade"
                  placeholder="e.g., A+, B, C-"
                  required
                  class="mt-1 w-full px-4 py-2.5 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                />
              </div>
              <div>
                <label
                  for="comments"
                  class="block text-sm font-medium text-gray-700"
                  >Comments</label
                >
                <textarea
                  id="comments"
                  name="comments"
                  rows="4"
                  placeholder="Add comments on the student's progress..."
                  class="mt-1 w-full px-4 py-2.5 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                ></textarea>
              </div>
              <div>
                <button
                  type="submit"
                  class="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
                >
                  Submit Report
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </Layout>
</template>
<script lang="js">
import Layout from "./Layout.vue";
export default {
  name: "StudentDetail",
  components: {
    Layout,
  },
};
</script>
