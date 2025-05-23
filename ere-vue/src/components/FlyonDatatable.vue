<template>
  <div>
    <template v-if="data">
      <DataTable
        class="display"
        :columns="columns"
        :data="data"
        :options="{ select: true }"
        ref="table"
      />
    </template>
  </div>
</template>

<script setup lang="js">
import { ref, onMounted, watch } from "vue";
import DataTable from "datatables.net-vue3";
import DataTablesLib from "datatables.net";
import "datatables.net-select";

DataTable.use(DataTablesLib);

const props = defineProps({
  data: {
    type: Array,
    default: () => [],
  },
  columns: {
    type: Array,
    default: () => [],
  },
});

let dt;
const data = ref([]);
const table = ref();
const emit = defineEmits();

onMounted(function () {
  dt = table.value.dt;
  data.value = props.data;
});

function getSelectedRows() {
  let selectedData = dt.rows({ selected: true }).data().toArray();
  // emit("getselectedrows", selectedData);
  return selectedData;
}

function setData(newData) {
  data.value = newData;
  dt.clear().draw();
  dt.rows.add(data.value); // Add new data
  dt.columns.adjust().draw(); // Redraw the DataTable
}

defineExpose({
  getSelectedRows,
  setData,
});
</script>

<style>
@import "datatables.net-dt";
</style>
