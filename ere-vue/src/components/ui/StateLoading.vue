<template>
  <div
    v-if="isLoading"
    class="fixed inset-0 z-50 flex items-center justify-center bg-gray-900/20 backdrop-blur-sm"
  >
    <div
      class="h-16 w-16 animate-spin rounded-full border-8 border-solid border-gray-300 border-t-blue-600"
    ></div>
  </div>
</template>

<script setup>
// Using <script setup> for modern Vue 3 syntax
import { defineProps } from "vue";

// Define the 'isLoading' prop that the parent component will pass down
defineProps({
  isLoading: {
    type: Boolean,
    required: true,
  },
});
</script>

<style scoped>
/* No additional styles are needed as Tailwind CSS handles everything */
</style>
