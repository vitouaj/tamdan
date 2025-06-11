<template>
  <div class="mx-auto">
    <header class="mb-8">
      <h1 class="text-3xl font-bold text-gray-900">Dashboard</h1>
      <p class="text-sm text-gray-500 mt-1">
        Welcome back, sotheara! Here is a summary of your progress.
      </p>
    </header>

    <div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
      <div class="lg:col-span-2 space-y-8">
        <div class="bg-white rounded-xl shadow-sm border border-gray-200">
          <div class="p-6">
            <h3 class="text-lg font-semibold text-gray-800">
              June 2025 Report - In Progress
            </h3>
          </div>
          <div class="p-6 border-t border-gray-200">
            <div class="grid grid-cols-2 sm:grid-cols-4 gap-4 text-center">
              <div>
                <p class="text-sm text-gray-500">Current Score</p>
                <p class="text-2xl font-bold text-gray-900">88</p>
              </div>
              <div>
                <p class="text-sm text-gray-500">Current Grade</p>
                <p class="text-2xl font-bold text-green-600">A-</p>
              </div>
              <div>
                <p class="text-sm text-gray-500">Absences</p>
                <p class="text-2xl font-bold text-gray-900">0</p>
              </div>
              <div>
                <p class="text-sm text-gray-500">Tasks Done</p>
                <p class="text-2xl font-bold text-gray-900">12/15</p>
              </div>
            </div>
          </div>
          <div class="p-6 border-t border-gray-200">
            <h4 class="font-semibold text-gray-700 mb-3">Recent Highlights</h4>
            <ul class="space-y-2 text-sm">
              <li class="flex items-center gap-3">
                <span
                  class="flex-shrink-0 w-8 h-8 rounded-full bg-green-100 text-green-700 flex items-center justify-center font-bold"
                  >A+</span
                >
                <span>Perfect score on Mathematics Quiz 3</span>
              </li>
              <li class="flex items-center gap-3">
                <span
                  class="flex-shrink-0 w-8 h-8 rounded-full bg-blue-100 text-blue-700 flex items-center justify-center font-bold"
                  >✓</span
                >
                <span>100% attendance this month</span>
              </li>
            </ul>
          </div>
        </div>

        <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
          <div class="bg-white rounded-xl shadow-sm border border-gray-200 p-6">
            <h3
              class="text-lg font-semibold text-gray-800 mb-2 flex items-center gap-2"
            >
              <svg
                class="w-5 h-5 text-gray-400"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M5.5 2A.5.5 0 005 2.5v1.75a.75.75 0 01-1.5 0V2.5A2 2 0 015.5 1h9A2 2 0 0116.5 3v1.5a.75.75 0 01-1.5 0V3a.5.5 0 00-.5-.5h-9z"
                  clip-rule="evenodd"
                />
                <path
                  fill-rule="evenodd"
                  d="M2 7.5a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 7.5zM2 11.5a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75a.75.75 0 01-.75-.75zM2 15.5a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75a.75.75 0 01-.75-.75z"
                  clip-rule="evenodd"
                />
              </svg>
              Teacher's Feedback
            </h3>
            <p class="text-sm text-gray-600 italic mt-4">
              "Excellent participation in the English class discussions this
              month, sotheara. Keep up the great work!"
            </p>
            <p class="text-xs text-right text-gray-400 mt-2">
              - Ms. Smith, June 10, 2025
            </p>
          </div>

          <div class="bg-white rounded-xl shadow-sm border border-gray-200 p-6">
            <h3
              class="text-lg font-semibold text-gray-800 mb-2 flex items-center gap-2"
            >
              <svg
                class="w-5 h-5 text-gray-400"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M7 2a2 2 0 00-2 2v12a2 2 0 002 2h6a2 2 0 002-2V4a2 2 0 00-2-2H7zm0 2h6v12H7V4z"
                  clip-rule="evenodd"
                />
                <path d="M10.5 6a.5.5 0 00-1 0v4a.5.5 0 001 0V6z" />
              </svg>
              Parent's Feedback
            </h3>
            <div class="text-center text-sm text-gray-400 mt-4 py-4">
              <p>No new feedback from your parent.</p>
              <p class="text-xs mt-1">
                They can add comments on your monthly reports.
              </p>
            </div>
          </div>
        </div>
      </div>

      <div class="lg:col-span-1">
        <div class="bg-white rounded-xl shadow-sm border border-gray-200">
          <div class="p-6">
            <h3 class="text-lg font-semibold text-gray-800">Past Reports</h3>
          </div>
          <ul class="divide-y divide-gray-200">
            <li
              class="flex items-center justify-between p-4 hover:bg-gray-50 transition-colors"
            >
              <div class="flex items-center gap-4">
                <svg
                  class="w-6 h-6 text-blue-500"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M19.5 14.25v-2.625a3.375 3.375 0 00-3.375-3.375h-1.5A1.125 1.125 0 0113.5 7.125v-1.5a3.375 3.375 0 00-3.375-3.375H8.25m0 12.75h7.5m-7.5 3H12M10.5 2.25H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 00-9-9z"
                  />
                </svg>
                <span class="font-medium text-sm text-gray-700"
                  >May 2025 Report</span
                >
              </div>
              <a
                href="#"
                class="text-sm font-medium text-blue-600 hover:underline"
                >View</a
              >
            </li>
            <li
              class="flex items-center justify-between p-4 hover:bg-gray-50 transition-colors"
            >
              <div class="flex items-center gap-4">
                <svg
                  class="w-6 h-6 text-blue-500"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M19.5 14.25v-2.625a3.375 3.375 0 00-3.375-3.375h-1.5A1.125 1.125 0 0113.5 7.125v-1.5a3.375 3.375 0 00-3.375-3.375H8.25m0 12.75h7.5m-7.5 3H12M10.5 2.25H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 00-9-9z"
                  />
                </svg>
                <span class="font-medium text-sm text-gray-700"
                  >April 2025 Report</span
                >
              </div>
              <a
                href="#"
                class="text-sm font-medium text-blue-600 hover:underline"
                >View</a
              >
            </li>
            <li
              class="flex items-center justify-between p-4 hover:bg-gray-50 transition-colors"
            >
              <div class="flex items-center gap-4">
                <svg
                  class="w-6 h-6 text-blue-500"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M19.5 14.25v-2.625a3.375 3.375 0 00-3.375-3.375h-1.5A1.125 1.125 0 0113.5 7.125v-1.5a3.375 3.375 0 00-3.375-3.375H8.25m0 12.75h7.5m-7.5 3H12M10.5 2.25H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 00-9-9z"
                  />
                </svg>
                <span class="font-medium text-sm text-gray-700"
                  >March 2025 Report</span
                >
              </div>
              <a
                href="#"
                class="text-sm font-medium text-blue-600 hover:underline"
                >View</a
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
// Removed redundant export default block as <script setup> already handles it
</script>
