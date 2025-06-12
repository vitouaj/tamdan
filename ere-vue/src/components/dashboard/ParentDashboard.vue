<template>
  <Layout>
    <div class="max-w-7xl">
      <header class="mb-8">
        <h1 class="text-3xl font-bold text-gray-900">My Children</h1>
        <p class="text-sm text-gray-500 mt-1">
          Select a child to view their dashboard and progress.
        </p>
      </header>

      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        <div
          class="relative bg-white rounded-xl shadow-md overflow-hidden transform hover:-translate-y-1 transition-all duration-300 flex flex-col"
        >
          <span class="absolute top-4 right-4 flex h-3 w-3">
            <span
              class="animate-ping absolute inline-flex h-full w-full rounded-full bg-red-400 opacity-75"
            ></span>
            <span
              class="relative inline-flex rounded-full h-3 w-3 bg-red-500"
            ></span>
          </span>

          <div class="p-6 flex items-center gap-5">
            <div
              class="w-16 h-16 rounded-full bg-blue-100 flex-shrink-0 flex items-center justify-center text-blue-600 text-2xl font-bold"
            >
              S
            </div>
            <div>
              <h3 class="text-xl font-bold text-gray-900">sotheara</h3>
              <p class="text-xs text-gray-500">ID: 94f4d0ff-a2da</p>
            </div>
          </div>
          <div class="px-6 pb-6 space-y-4 text-sm flex-grow">
            <div class="flex items-center gap-3 text-gray-700">
              <svg
                class="w-5 h-5 text-gray-400 flex-shrink-0"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M11.983 1.904a3.013 3.013 0 00-3.966 0L2.343 7.519a.75.75 0 00-.22 1.076l.004.008 7.5 10a.75.75 0 001.346 0l7.5-10a.75.75 0 00-.22-1.076l-.004-.008-5.674-5.615zM10 12.5a2.5 2.5 0 100-5 2.5 2.5 0 000 5z"
                />
              </svg>
              <span
                >Overall Grade:
                <span class="font-semibold text-green-600">A-</span></span
              >
            </div>
            <div class="flex items-center gap-3 text-gray-700">
              <svg
                class="w-5 h-5 text-gray-400 flex-shrink-0"
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
                >Attendance:
                <span class="font-semibold">0 Absences (This Month)</span></span
              >
            </div>
            <div class="flex items-center gap-3 text-gray-700">
              <svg
                class="w-5 h-5 text-gray-400 flex-shrink-0"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M10 18a8 8 0 100-16 8 8 0 000 16zm.75-13a.75.75 0 00-1.5 0v5c0 .414.336.75.75.75h4a.75.75 0 000-1.5h-3.25V5z"
                  clip-rule="evenodd"
                />
              </svg>
              <span
                >Upcoming:
                <span class="font-semibold"
                  >Math Exam on Fri, Jun 20</span
                ></span
              >
            </div>
          </div>
          <div class="bg-gray-50 p-4 mt-auto">
            <a
              href="#"
              class="block w-full text-center py-2.5 px-4 border border-transparent rounded-lg text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
            >
              View Dashboard
            </a>
          </div>
        </div>

        <div
          class="relative bg-white rounded-xl shadow-md overflow-hidden transform hover:-translate-y-1 transition-all duration-300 flex flex-col"
        >
          <div class="p-6 flex items-center gap-5">
            <div
              class="w-16 h-16 rounded-full bg-indigo-100 flex-shrink-0 flex items-center justify-center text-indigo-600 text-2xl font-bold"
            >
              S
            </div>
            <div>
              <h3 class="text-xl font-bold text-gray-900">Savong</h3>
              <p class="text-xs text-gray-500">ID: a1b2c3d4-e5f6</p>
            </div>
          </div>
          <div class="px-6 pb-6 space-y-4 text-sm flex-grow">
            <div class="flex items-center gap-3 text-gray-700">
              <svg
                class="w-5 h-5 text-gray-400 flex-shrink-0"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  d="M11.983 1.904a3.013 3.013 0 00-3.966 0L2.343 7.519a.75.75 0 00-.22 1.076l.004.008 7.5 10a.75.75 0 001.346 0l7.5-10a.75.75 0 00-.22-1.076l-.004-.008-5.674-5.615zM10 12.5a2.5 2.5 0 100-5 2.5 2.5 0 000 5z"
                />
              </svg>
              <span
                >Overall Grade:
                <span class="font-semibold text-blue-600">B+</span></span
              >
            </div>
            <div class="flex items-center gap-3 text-gray-700">
              <svg
                class="w-5 h-5 text-gray-400 flex-shrink-0"
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
                >Attendance:
                <span class="font-semibold">2 Absences (This Month)</span></span
              >
            </div>
            <div class="flex items-center gap-3 text-gray-700">
              <svg
                class="w-5 h-5 text-gray-400 flex-shrink-0"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M10 18a8 8 0 100-16 8 8 0 000 16zm.75-13a.75.75 0 00-1.5 0v5c0 .414.336.75.75.75h4a.75.75 0 000-1.5h-3.25V5z"
                  clip-rule="evenodd"
                />
              </svg>
              <span
                >Upcoming: <span class="font-semibold">No deadlines</span></span
              >
            </div>
          </div>
          <div class="bg-gray-50 p-4 mt-auto">
            <a
              href="#"
              class="block w-full text-center py-2.5 px-4 border border-transparent rounded-lg text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
            >
              View Dashboard
            </a>
          </div>
        </div>
      </div>
    </div>
  </Layout>
</template>
<script setup></script>
