<script setup>
import { ref, computed } from "vue";

function handleSelectMonth(event) {
  let { ariaSelected, id } = event.target;
  if (monthsMap.value[parseInt(id)]) {
    monthsMap.value[id].selected = !monthsMap.value[id].selected;
  }
}

const filterTitle = computed(() => {
  let selectedMonths = Object.values(monthsMap.value).filter(
    (month) => month.selected
  );

  if (selectedMonths.length > 0) {
    let tempName = "";
    for (let m of selectedMonths) {
      tempName += " " + m.name;
    }
    return tempName;
  }
  return "Filter by Month";
});

const monthsMap = ref({
  1: { index: 1, name: "January", selected: false },
  2: { index: 2, name: "February", selected: false },
  3: { index: 3, name: "March", selected: false },
  4: { index: 4, name: "April", selected: false },
  5: { index: 5, name: "May", selected: false },
  6: { index: 6, name: "June", selected: false },
  7: { index: 7, name: "July", selected: false },
  8: { index: 8, name: "August", selected: false },
  9: { index: 9, name: "September", selected: false },
  10: { index: 10, name: "October", selected: false },
  11: { index: 11, name: "November", selected: false },
  12: { index: 12, name: "December", selected: false },
});
</script>
<template>
  <select class="select join-item w-36" aria-label="select">
    <option disabled selected>Filter</option>
    <option v-for="item in Object.values(monthsMap)">{{ item.name }}</option>
  </select>
</template>
