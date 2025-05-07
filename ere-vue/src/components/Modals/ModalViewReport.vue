<template>
  <div :key="viewMode" :id="id" :class="modalStyle" role="dialog" tabindex="-1">
    <div class="modal-dialog-xl overlay-open:opacity-100">
      <div class="modal-content">
        <div class="modal-header">
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
          <div
            class="app-content"
            v-for="pageNum in pageNums"
            :key="pageNum"
            ref="pageRefs"
          >
            <vue-pdf-embed
              v-if="pageVisibility[pageNum]"
              :source="doc"
              :page="pageNum"
            />
          </div>
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
import VuePdfEmbed, { useVuePdfEmbed } from "vue-pdf-embed";
import {
  computed,
  onMounted,
  ref,
  watch,
  nextTick,
  onBeforeUnmount,
} from "vue";

const pdfURL =
  "https://raw.githubusercontent.com/mozilla/pdf.js/ba2edeae/web/compressed.tracemonkey-pldi-09.pdf";

const props = defineProps({
  id: String,
  viewMode: String,
  title: String,
  message: String,
  data: Object,
});

onMounted(() => {
  console.log("pdf url ", pdfURL);
});

const pageRefs = ref([]);
const pageVisibility = ref({});
let pageIntersectionObserver;
const { doc } = useVuePdfEmbed({
  source:
    "https://raw.githubusercontent.com/mozilla/pdf.js/ba2edeae/web/compressed.tracemonkey-pldi-09.pdf",
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

const pageNums = computed(() =>
  doc.value ? [...Array(doc.value.numPages + 1).keys()].slice(1) : []
);

const resetPageIntersectionObserver = () => {
  pageIntersectionObserver?.disconnect();
  pageIntersectionObserver = new IntersectionObserver((entries) => {
    entries.forEach((entry) => {
      if (entry.isIntersecting) {
        const index = pageRefs.value.indexOf(entry.target);
        const pageNum = pageNums.value[index];
        pageVisibility.value[pageNum] = true;
      }
    });
  });
  pageRefs.value.forEach((element) => {
    pageIntersectionObserver.observe(element);
  });
};

watch(pageNums, (newPageNums) => {
  pageVisibility.value = { [newPageNums[0]]: true };
  nextTick(resetPageIntersectionObserver);
});

onBeforeUnmount(() => {
  pageIntersectionObserver?.disconnect();
});

onMounted(() => {
  console.log("delete record ", JSON.stringify(props.data));
});

defineExpose({
  toggleModal,
});
</script>

<style lang="css" scoped>
.app-content {
  width: 50vw;
}
</style>
