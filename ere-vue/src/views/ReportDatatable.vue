<script setup>
import { ref, computed } from "vue";
import Datatable from "../components/Datatable.vue";
import Paggination from "../components/Paggination.vue";
import ReportMenuBar from "../components/ReportMenuBar.vue";

const headers = [
  {
    label: "Report Number",
    name: "number",
  },
  {
    label: "Student Name",
    name: "studentName",
  },
  {
    label: "Status",
    name: "status",
  },
  {
    label: "Action",
    name: "action",
  },
];

const data = [
  {
    id: "f3a9c7b2-8e41-4b1a-9a67-2e9f834d2345",
    reportNumber: "1",
    studentName: "Sok Dara",
    reportStatus: "feedback received",
    selected: false,
  },
  {
    id: "b7e6d4a1-2c3f-4890-a8b5-1d2f567e890a",
    reportNumber: "2",
    studentName: "Chan Sreyneang",
    reportStatus: "draft",
    selected: false,
  },
  {
    id: "9c5f2a34-7d61-4e2b-937a-1f8e6d5b9c0d",
    reportNumber: "3",
    studentName: "Kim Vannak",
    reportStatus: "sent",
    selected: false,
  },
  {
    id: "f3a9c7b2-8e41-4b1a-9a67-2e9f834d2343",
    reportNumber: "4",
    studentName: "Sok Dara",
    reportStatus: "feedback received",
    selected: false,
  },
  {
    id: "b7e6d4a1-2c3f-4890-a8b5-1d2f567e890m",
    reportNumber: "5",
    studentName: "Chan Sreyneang",
    reportStatus: "draft",
    selected: false,
  },
  {
    id: "9c5f2a34-7d61-4e2b-937a-1f8e6d5b9x0d",
    reportNumber: "6",
    studentName: "Kim Vannak",
    reportStatus: "sent",
    selected: false,
  },
  {
    id: "f3a9c7b2-8e41-4b1a-9a67-2e9f834d2343",
    reportNumber: "7",
    studentName: "Sok Dara",
    reportStatus: "feedback received",
    selected: false,
  },
  {
    id: "b7e6d4a1-2c3f-4890-a8b5-1d2f567e890m",
    reportNumber: "8",
    studentName: "Chan Sreyneang",
    reportStatus: "draft",
    selected: false,
  },
  {
    id: "9c5f2a34-7d61-4e2b-937a-1f8e6d5b9x0d",
    reportNumber: "9",
    studentName: "Kim Vannak",
    reportStatus: "sent",
    selected: false,
  },
  {
    id: "f3a9c7b2-8e41-4b1a-9a67-2e9f834d2343",
    reportNumber: "10",
    studentName: "Sok Dara",
    reportStatus: "feedback received",
    selected: false,
  },

  {
    id: "9c5f2a34-7d61-4e2b-937a-1f8e6d5b9x0d",
    reportNumber: "11",
    studentName: "Kim Vannak",
    reportStatus: "sent",
    selected: false,
  },
  {
    id: "f3a9c7b2-8e41-4b1a-9a67-2e9f834d2343",
    reportNumber: "12",
    studentName: "Sok Dara",
    reportStatus: "feedback received",
    selected: false,
  },
  {
    id: "b7e6d4a1-2c3f-4890-a8b5-1d2f567e890m",
    reportNumber: "13",
    studentName: "Chan Sreyneang",
    reportStatus: "draft",
    selected: false,
  },
  {
    id: "9c5f2a34-7d61-4e2b-937a-1f8e6d5b9x0d",
    reportNumber: "14",
    studentName: "Kim Vannak",
    reportStatus: "sent",
    selected: false,
  },
  {
    id: "b7e6d4a1-2c3f-4890-a8b5-1d2f567e890m",
    reportNumber: "15",
    studentName: "Chan Sreyneang",
    reportStatus: "draft",
    selected: false,
  },
];

const currentPage = ref(1);
const recordPerPage = ref(10); // flexible via user input

const totalRecords = computed(() => {
  return data.length;
});

const pagginatedRecords = computed(() => {
  const start = (currentPage.value - 1) * recordPerPage.value;
  const end =
    start + recordPerPage.value > data.length
      ? data.length
      : start + recordPerPage.value;

  return [...data.slice(start, end)];
});

const handleCurrentPage = (event) => {
  const newValue = event.detail.currentPage;
  currentPage.value = parseInt(newValue);
};

const recordperpagechanged = (event) => {
  const newValue = event.detail.recordPerPage;

  recordPerPage.value = parseInt(newValue); // set the new record per page
  currentPage.value = 1; // reset the current page to 1
};
</script>

<template>
  <div class="w-full">
    <ReportMenuBar />
    <Datatable :headers="headers" :data="pagginatedRecords" />
    <Paggination
      @currentpageselection="handleCurrentPage"
      :total-records="totalRecords"
      :current-page="currentPage"
      :record-per-page="recordPerPage"
      @recordperpagechanged="recordperpagechanged"
    />
  </div>
</template>
