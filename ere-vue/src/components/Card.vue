<template>
  <a @click="$emit('select', id)">
    <div :class="className">
      <div class="card-body">
        <h5 class="text-xl font-bold">{{ title }}</h5>
        <p class="mb-4">
          {{ content }}
        </p>
        <div class="card-actions">
          <div :class="conputedStatusStyle">
            {{ status.toLocaleLowerCase() }}
          </div>
        </div>
      </div>
    </div>
  </a>
</template>
<script setup lang="js">
import { computed } from "vue";

const props = defineProps({
  id: {
    type: String,
    default: "welcome-card",
  },
  title: {
    type: String,
    default: "Welcome to Our Service",
  },
  content: {
    type: String,
    default: "",
  },
  className: {
    type: String,
    default: "",
  },
  status: {
    type: String,
    default: "",
  },
  report: {
    type: Object,
    default: {},
  },
});

const greenStatus = ["FEEDBACK_RECIEVED", "READY"];

const conputedStatusStyle = computed(() => {
  if (greenStatus.includes(props.status)) {
    return "text-green-500 text-sm p-1 rounded bg-green-300";
  }
});
</script>
