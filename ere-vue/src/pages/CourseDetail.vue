<template>
  <Layout>
    <div class="bg-gray-50 font-sans">
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
              <span class="text-sm font-medium text-gray-600"
                >Total Enroll</span
              >
            </div>
            <div class="mt-2 ml-1">
              <p class="text-3xl font-semibold text-gray-900">18</p>
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
                  class="w-full sm:w-auto flex items-center justify-center gap-2 px-4 py-2.5 text-sm font-medium text-white bg-blue-600 rounded-lg hover:bg-blue-700 focus:ring-4 focus:ring-blue-300"
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
                  Enroll Student
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
                  <th scope="col" class="px-6 py-3">Student Email</th>
                </tr>
              </thead>
              <tbody>
                <tr class="bg-white border-b hover:bg-gray-50">
                  <td class="w-4 p-4">
                    <div class="flex items-center">
                      <input
                        id="checkbox-table-1"
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
                        chit soknea
                      </div>
                    </div>
                  </td>
                  <td class="px-6 py-4">ENGLISH ELEVENTH</td>
                  <td class="px-6 py-4">4/23/2025</td>
                  <td class="px-6 py-4">
                    <span
                      class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                      >In Progress</span
                    >
                  </td>
                  <td class="px-6 py-4">by sotheara</td>
                  <td class="px-6 py-4">bysotheara@gmail.com</td>
                </tr>
                <tr class="bg-white border-b hover:bg-gray-50">
                  <td class="w-4 p-4">
                    <div class="flex items-center">
                      <input
                        id="checkbox-table-2"
                        type="checkbox"
                        class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500"
                      />
                      <label for="checkbox-table-2" class="sr-only"
                        >checkbox</label
                      >
                    </div>
                  </td>
                  <td class="px-6 py-4">
                    <div class="flex items-center gap-3">
                      <img
                        class="w-9 h-9 rounded-full object-cover"
                        src="https://i.pravatar.cc/40?u=lun_navy"
                        alt="Lun Navy avatar"
                      />
                      <div class="font-medium text-gray-900 whitespace-nowrap">
                        <a href="/student/1" class="hover:underline"
                          >Lun Navy</a
                        >
                      </div>
                    </div>
                  </td>
                  <td class="px-6 py-4">SCIENCE ELEVENTH</td>
                  <td class="px-6 py-4">4/23/2025</td>
                  <td class="px-6 py-4">
                    <span
                      class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                      >In Progress</span
                    >
                  </td>
                  <td class="px-6 py-4">by sotheara</td>
                  <td class="px-6 py-4">bysotheara@gmail.com</td>
                </tr>
                <tr class="bg-white hover:bg-gray-50">
                  <td class="w-4 p-4">
                    <div class="flex items-center">
                      <input
                        id="checkbox-table-3"
                        type="checkbox"
                        class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500"
                      />
                      <label for="checkbox-table-3" class="sr-only"
                        >checkbox</label
                      >
                    </div>
                  </td>
                  <td class="px-6 py-4">
                    <div class="flex items-center gap-3">
                      <img
                        class="w-9 h-9 rounded-full object-cover"
                        src="https://i.pravatar.cc/40?u=norng_sokchan"
                        alt="Norng Sokchan avatar"
                      />
                      <div class="font-medium text-gray-900 whitespace-nowrap">
                        Norng Sokchan
                      </div>
                    </div>
                  </td>
                  <td class="px-6 py-4">MATH ELEVENTH</td>
                  <td class="px-6 py-4">4/23/2025</td>
                  <td class="px-6 py-4">
                    <span
                      class="px-3 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800"
                      >In Progress</span
                    >
                  </td>
                  <td class="px-6 py-4">by sotheara</td>
                  <td class="px-6 py-4">vitouaj68@gmail.com</td>
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
  </Layout>
</template>

<script lang="js" setup>
import Layout from "./Layout.vue";
// No specific script needed for this static example
// No specific script needed for this static example
</script>
