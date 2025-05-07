<template>
  <div class="max-w-sm">
    <div class="relative" :data-combo-box="JSON.stringify(datacombobox)">
      <!-- SearchBox -->
      <div class="relative">
        <span
          class="icon-[tabler--search] text-base-content absolute start-3 top-1/2 size-4 flex-shrink-0 -translate-y-1/2"
        ></span>
        <input
          class="input ps-8"
          type="text"
          placeholder="Search or type a command"
          role="combobox"
          aria-expanded="false"
          v-model="searchQuery"
          autofocus
          data-combo-box-input=""
        />
      </div>
      <!-- SearchBox Body -->
      <div
        class="bg-base-100 vertical-scrollbar rounded-scrollbar rounded-box absolute z-50 max-h-56 w-full space-y-0.5 p-2 shadow-lg"
        style="display: none"
        data-combo-box-output=""
      >
        <div
          :data-name="item.name"
          v-on:click="handleSelectDropdown"
          v-for="item in items"
          class="dropdown-item cursor-pointer hover:text-purple-500"
        >
          {{ item.name }}
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";

const searchQuery = ref("");

// Properly formatted JSON for data-combo-box-output-item-attr
const datacomboboxoutputitemattr = JSON.stringify([
  { valueFrom: "image", attr: "src" },
  { valueFrom: "name", attr: "alt" },
]);

// Correctly formatted outputItemTemplate
const outputItemTemplate = `
  <div class="dropdown-item combo-box-selected:active" data-combo-box-output-item>
    <div class="flex items-center justify-between">
      <div class="flex items-center w-full">
        <div class="flex items-center justify-center rounded-full bg-base-200 size-6 overflow-hidden me-2.5">
          <img class="flex-shrink-0"
               data-combo-box-output-item-attr='${datacomboboxoutputitemattr}' />
        </div>
        <div data-combo-box-output-item-field="name" data-combo-box-search-text data-combo-box-value></div>
      </div>
      <span class="icon-[tabler--check] text-primary combo-box-selected:block hidden size-4 flex-shrink-0"></span>
    </div>
  </div>`;

const groupingTitleTemplate = `
  <div class="block text-xs text-base-content/50 m-3 mb-1"></div>`;

// Properly defined dataComboBox object, ensuring it's a JSON object
const datacombobox = ref({
  groupingType: "default",
  isOpenOnFocus: true,
  apiUrl: "/json/searchbox.json",
  apiGroupField: "position",
  outputItemTemplate: outputItemTemplate,
  groupingTitleTemplate: groupingTitleTemplate,
});

const handleSelectDropdown = (event) => {
  const { name } = event.target.dataset;
  searchQuery.value = name;
  console.log("value on div, ", name);
};
// Sample Data (Replace with API Fetch if needed)
const items = ref([
  {
    name: "Apple",
  },
  {
    name: "Banana",
  },
  {
    name: "Cherry",
  },
]);
</script>
