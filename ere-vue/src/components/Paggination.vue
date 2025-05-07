<template>
  <div class="flex items-center justify-between mt-4 px-4 py-3 sm:px-6">
    <div class="flex flex-1 justify-between sm:hidden">
      <a
        href="#"
        class="relative inline-flex items-center rounded-md border border-gray-300 bg-white px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        >Previous</a
      >
      <a
        href="#"
        class="relative ml-3 inline-flex items-center rounded-md border border-gray-300 bg-white px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        >Next</a
      >
    </div>
    <div class="hidden sm:flex sm:flex-1 sm:items-center sm:justify-between">
      <div>
        <p class="text-sm text-gray-700">
          Showing
          <select
            @change="handleRecordPerPage"
            :value="thisRecordPerPage"
            class="font-medium"
          >
            <option value="5" class="font-medium">1-5</option>
            <option value="10" class="font-medium">1-10</option>
            <option value="20" class="font-medium">1-20</option>
          </select>

          of
          <span class="font-medium">{{ totalRecords }}</span>
          results
        </p>
      </div>
      <div>
        <nav
          class="isolate inline-flex -space-x-px rounded-md shadow-sm"
          aria-label="Pagination"
        >
          <a
            href="#"
            class="relative inline-flex items-center rounded-l-md px-2 py-2 text-gray-400 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:z-20 focus:outline-offset-0"
          >
            <span class="sr-only">Previous</span>
            <svg
              class="size-5"
              viewBox="0 0 20 20"
              fill="currentColor"
              aria-hidden="true"
              data-slot="icon"
            >
              <path
                fill-rule="evenodd"
                d="M11.78 5.22a.75.75 0 0 1 0 1.06L8.06 10l3.72 3.72a.75.75 0 1 1-1.06 1.06l-4.25-4.25a.75.75 0 0 1 0-1.06l4.25-4.25a.75.75 0 0 1 1.06 0Z"
                clip-rule="evenodd"
              />
            </svg>
          </a>
          <!-- Current: "z-10 bg-indigo-600 text-white focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600", Default: "text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:outline-offset-0" -->
          <a
            :data-current-page="page.index"
            :data-selected="page.isSelected"
            @click="handleCurrentPageSelection"
            v-for="page in pages"
            href="#"
            aria-current="page"
            :class="paginationNumberSytle(page.isSelected)"
            >{{ page.index }}</a
          >

          <a
            href="#"
            class="relative inline-flex items-center rounded-r-md px-2 py-2 text-gray-400 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:z-20 focus:outline-offset-0"
          >
            <span class="sr-only">Next</span>
            <svg
              class="size-5"
              viewBox="0 0 20 20"
              fill="currentColor"
              aria-hidden="true"
              data-slot="icon"
            >
              <path
                fill-rule="evenodd"
                d="M8.22 5.22a.75.75 0 0 1 1.06 0l4.25 4.25a.75.75 0 0 1 0 1.06l-4.25 4.25a.75.75 0 0 1-1.06-1.06L11.94 10 8.22 6.28a.75.75 0 0 1 0-1.06Z"
                clip-rule="evenodd"
              />
            </svg>
          </a>
        </nav>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted, watchEffect } from "vue";

const props = defineProps({
  currentPage: Number,
  totalRecords: Number,
  recordPerPage: Number,
});
const pages = ref([{ index: 1, isSelected: true }]);
const emit = defineEmits(["currentpageselection"]);
const thisRecordPerPage = ref(props.recordPerPage);

const totalPages = computed(() => {
  return Math.ceil(props.totalRecords / thisRecordPerPage.value);
});

// Automatically update `pages` when totalPages changes
watchEffect(() => {
  pages.value = Array.from({ length: totalPages.value }, (_, i) => ({
    index: i + 1,
    isSelected: i + 1 === 1 ? true : false,
  }));
});

const handleCurrentPageSelection = (event) => {
  const { currentPage } = event.target.dataset;
  // Update the selected page
  pages.value = pages.value.map((page) => ({
    index: page.index,
    isSelected: page.index === parseInt(currentPage),
  }));
  emit("currentpageselection", {
    detail: {
      currentPage: currentPage,
    },
  });
};

const paginationNumberSytle = (selected) => {
  return selected
    ? "relative z-10 inline-flex items-center bg-indigo-600 px-4 py-2 text-sm font-semibold text-white focus:z-20 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
    : "relative inline-flex items-center px-4 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:z-20 focus:outline-offset-0";
};

onMounted(() => {
  console.log(props.currentPage, props.totalPages, props.recordPerPage);
});

const handleRecordPerPage = (event) => {
  const newValue = event.target.value;
  thisRecordPerPage.value = parseInt(newValue);
  // Emit the event to the parent component
  emit("recordperpagechanged", {
    detail: {
      recordPerPage: thisRecordPerPage.value,
    },
  });
};
</script>
