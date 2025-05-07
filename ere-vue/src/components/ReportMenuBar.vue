<template>
  <div
    class="flex flex-col flex-wrap gap-3 sm:flex-row sm:items-center sm:justify-between"
  >
    <FilterButton />
    <SearchInputBar />
  </div>
</template>
<script setup>
import FilterButton from "./FilterButton.vue";
import SearchInputBar from "./SearchInputBar.vue";
</script>
