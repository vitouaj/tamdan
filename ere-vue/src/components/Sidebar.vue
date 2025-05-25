<template>
  <template v-if="user.role == 1">
    <ul class="menu">
      <li>
        <div @click="goTo" data-cmp="home">
          <span class="icon-[tabler--home] size-5"></span>
          Home
        </div>
      </li>
      <li>
        <div @click="goTo" data-cmp="schedules">
          <span class="icon-[tabler--calendar] size-5"></span>
          Schedules
        </div>
      </li>
      <li>
        <div @click="goTo" data-cmp="course-enrollments">
          <span class="icon-[tabler--report] size-5"></span>
          Courses
        </div>
      </li>
    </ul>
  </template>
  <template v-if="user.role == 2">
    <ul class="menu">
      <li>
        <div @click="goTo" data-cmp="teachercourselist">
          <span class="icon-[tabler--home] size-5"></span>
          Home
        </div>
      </li>
      <li>
        <div @click="goTo" data-cmp="schedules">
          <span class="icon-[tabler--calendar] size-5"></span>
          Schedules
        </div>
      </li>
      <!-- <li>
        <div @click="goTo" data-cmp="course-enrollments">
          <span class="icon-[tabler--report] size-5"></span>
          Course Enrollments (For teacher)
        </div>
      </li> -->
    </ul>
  </template>
  <template v-if="user.role == 3">
    <ul class="menu">
      <li>
        <div @click="goTo" data-cmp="studentlist">
          <span class="icon-[tabler--home] size-5"></span>
          Home
        </div>
      </li>
    </ul>
  </template>
</template>

<script setup lang="ts">
import { defineEmits, PropType } from "vue";
import { User } from "../pages/Home.vue";

const props = defineProps({
  user: {
    type: Object as PropType<User>,
    required: true,
  },
});

const emit = defineEmits(["goto"]);

const goTo = (event: MouseEvent) => {
  const target = event.currentTarget as HTMLElement;
  const cmp = target.dataset.cmp;
  if (cmp) {
    emit("goto", {
      detail: {
        cmpName: cmp,
      },
    }); // ✅ Use Vue's emit, not dispatchEvent
  }
};
</script>
