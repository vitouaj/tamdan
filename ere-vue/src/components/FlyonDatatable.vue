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
import { ref, onMounted } from "vue";
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
  data.value = props.data.map((item) => ({
    ...item,
    enrollmentDate: new Date(item.enrollmentDate).toLocaleDateString(),
    completionDate: item.completionDate
      ? new Date(item.completionDate).toLocaleDateString()
      : "In Progress",
  }));
});

function getSelectedRows() {
  let selectedData = dt.rows({ selected: true }).data().toArray();
  // emit("getselectedrows", selectedData);
  return selectedData;
}

defineExpose({
  getSelectedRows,
});
</script>

<style>
@import "datatables.net-dt";
</style>
