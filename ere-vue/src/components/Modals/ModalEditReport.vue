<template>
  <div :key="viewMode" :id="id" :class="modalStyle" role="dialog" tabindex="-1">
    <div class="modal-dialog overlay-open:opacity-100">
      <div class="modal-content">
        <div class="modal-header">
          <h3 class="modal-title">{{ title }}</h3>
          <button
            type="button"
            class="btn btn-text btn-circle btn-sm absolute end-3 top-3"
            aria-label="Close"
            @click="toggleModal"
          >
            <span class="icon-[tabler--x] size-4"></span>
          </button>
        </div>
        <div class="modal-body">
          {{ data }}
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-soft btn-secondary"
            @click="toggleModal"
          >
            Close
          </button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
  </div>
  <div
    v-if="isActive"
    id="edit-backdrop"
    data-overlay-backdrop-template=""
    style="z-index: 79"
    class="transition duration fixed inset-0 bg-base-shadow/70 overlay-backdrop overflow-y-auto"
  ></div>
</template>
<script setup>
import { computed, onMounted, ref } from "vue";

const props = defineProps({
  id: String,
  viewMode: String,
  title: String,
  message: String,
  data: Object,
});

onMounted(() => {
  console.log("delete record ", JSON.stringify(props.data));
});

const isActive = ref(false);

const modalStyle = computed(() => {
  return isActive.value
    ? "overlay modal overlay-open:opacity-100 open opened"
    : "overlay modal overlay-open:opacity-100 hidden";
});

const toggleModal = () => {
  isActive.value = !isActive.value;
};

defineExpose({
  toggleModal,
});
</script>
