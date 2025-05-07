<template>
  <div id="lineAreaChart" class="w-full"></div>
</template>

<script setup>
window.addEventListener("load", () => {
  (function () {
    const areaChartEl = document.querySelector("#lineAreaChart"),
      areaChartConfig = {
        chart: {
          height: 400,
          width: "100%",
          type: "area",
          parentHeightOffset: 0,
          toolbar: {
            show: false,
          },
        },
        dataLabels: {
          enabled: false,
        },
        stroke: {
          show: false,
          curve: "straight",
        },
        legend: {
          show: true,
          position: "top",
          horizontalAlign: "start",
          labels: {
            colors: "var(--color-base-content)",
            useSeriesColors: false,
          },
        },
        grid: {
          borderColor:
            "color-mix(in oklab, var(--color-base-content) 40%, transparent)",
          xaxis: {
            lines: {
              show: true,
            },
          },
        },
        colors: [
          "color-mix(in oklab, var(--color-success) 30%, transparent)",
          "color-mix(in oklab, var(--color-success) 60%, transparent)",
          "color-mix(in oklab, var(--color-success) 90%, transparent)",
        ],
        series: [
          {
            name: "Visits",
            data: [
              100, 120, 90, 170, 130, 160, 140, 240, 220, 180, 270, 280, 375,
            ],
          },
          {
            name: "Clicks",
            data: [60, 80, 70, 110, 80, 100, 90, 180, 160, 140, 200, 220, 275],
          },
          {
            name: "Sales",
            data: [20, 40, 30, 70, 40, 60, 50, 140, 120, 100, 140, 180, 220],
          },
        ],
        xaxis: {
          categories: [
            "7/12",
            "8/12",
            "9/12",
            "10/12",
            "11/12",
            "12/12",
            "13/12",
            "14/12",
            "15/12",
            "16/12",
            "17/12",
            "18/12",
            "19/12",
            "20/12",
          ],
          axisBorder: {
            show: false,
          },
          axisTicks: {
            show: false,
          },
          labels: {
            style: {
              colors: "var(--color-base-content)",
              fontSize: "13px",
            },
          },
        },
        yaxis: {
          labels: {
            style: {
              colors: "var(--color-base-content)",
              fontSize: "13px",
            },
          },
        },
        fill: {
          opacity: 1,
          type: "solid",
        },
        tooltip: {
          shared: false,
        },
      };
    if (typeof areaChartEl !== undefined && areaChartEl !== null) {
      const areaChart = new ApexCharts(areaChartEl, areaChartConfig);
      areaChart.render();
    }
  })();
});
</script>
