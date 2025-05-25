<script setup>
const props = defineProps({
  id: String,
  title: String,
  visible: Boolean,
});
const emit = defineEmits(["update:visible"]);
</script>

<template>
  <div
    v-show="visible"
    class="fixed inset-0 z-50 flex items-start justify-center pt-[40px] bg-black bg-opacity-50 transition-opacity"
    role="dialog"
    tabindex="-1"
  >
    <div class="relative min-width-500px">
      <div class="bg-white rounded-lg shadow-lg max-w-lg w-full">
        <div class="p-4 border-b">
          <h3 class="text-lg font-semibold">{{ title }}</h3>
          <button
            type="button"
            class="btn btn-text btn-circle btn-sm absolute minus-1_25rem"
            aria-label="Close"
            @click="emit('update:visible', false)"
          >
            <span class="icon-[tabler--x] size-4"></span>
          </button>
        </div>
        <div class="p-4">
          <slot name="content" />
        </div>
        <div class="p-4 border-t text-right">
          <slot name="actions" />
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
.minus-1_25rem {
  top: -1.25rem;
  right: -1.25rem;
}

.min-width-500px {
  min-width: 500px;
}
</style>
