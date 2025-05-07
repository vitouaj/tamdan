<template>
  <template v-if="showReportDetail">
    <ReportDetails
      @goback="toggleShowReportDetail"
      :selectedReport="selectedReport"
    />
  </template>
  <template v-else="showReportDetail">
    <div class="grid grid-cols-4 gap-4 p-4">
      <Card
        v-for="month in fullMonthReports"
        :data-id="month.id"
        @select="handleShowReportDetail"
        class="col-spans-1"
        :id="month.id"
        :title="month.name"
        :status="month.status"
        :className="month.className"
        :key="month.id"
        :report="month.report"
      />
    </div>
  </template>
</template>

<script setup>
import { computed, onMounted } from "vue";
import Card from "../components/Card.vue";
import ReportDetails from "./ReportDetails.vue";
import { ref } from "vue";
const props = defineProps({
  reports: {
    type: Array,
    default: () => [],
  },
});

const showReportDetail = ref(false);
const selectedReport = ref({});

function toggleShowReportDetail() {
  showReportDetail.value = !showReportDetail.value;
}

function handleShowReportDetail(monthId) {
  console.log(monthId);
  selectedReport.value = fullMonthReports.value.find((r) => r.id === monthId);
  toggleShowReportDetail();
}

const fullMonthReports = computed(() => {
  const monthNames = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];

  let allreports = props.reports;

  return monthNames.map((name, index) => {
    const id = String(index + 1);
    const report = allreports.find((r) => String(r.monthId) === id);
    let className = "card cursor-pointer gray-out";
    let status = "N/A";
    if (report) {
      className = "card cursor-pointer";
      status = report.status;
    }

    return {
      id,
      name,
      status: status,
      className: className,
      report,
    };
  });
});
</script>
