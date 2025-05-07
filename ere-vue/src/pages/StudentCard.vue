<template>
  <div
    @click="goTo"
    :data-id="student.id"
    class="card col-span-1 max-w-[400px] cursor-pointer hover:shadow-sm mb-4"
  >
    <div class="card-body content">
      <div class="text-center mb-8 md:mb-0">
        <img
          src="https://i.pravatar.cc/300"
          alt="Profile Picture"
          class="rounded-full w-48 h-48 mb-4 mx-auto border-4 border-indigo-800 dark:border-blue-900 transition-transform duration-300 hover:scale-105"
        />
        <h1 class="text-2xl font-bold mb-2">{{ student?.name }}</h1>
        <p class="">{{ student?.email }}</p>
        <span class="">{{ student?.levelId }}</span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  student: any;
}>();

const emit = defineEmits(["gotostudentreportlist"]);

const goTo = (event: MouseEvent) => {
  const target = event.currentTarget as HTMLElement;
  const id = target.dataset.id;
  if (id) {
    emit("gotostudentreportlist", {
      detail: {
        id: id,
      },
    }); // ✅ Use Vue's emit, not dispatchEvent
  }
};
</script>
