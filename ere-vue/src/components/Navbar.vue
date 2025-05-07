<template>
  <nav
    class="navbar bg-base-100 max-sm:rounded-box max-sm:shadow sm:border-b border-base-content/25 sm:z-[1] relative"
  >
    <button
      type="button"
      class="btn btn-text max-sm:btn-square sm:hidden me-2"
      aria-haspopup="dialog"
      aria-expanded="false"
      aria-controls="default-sidebar"
      data-overlay="#default-sidebar"
    >
      <span class="icon-[tabler--menu-2] size-5"></span>
    </button>
    <div class="flex flex-1 items-center">
      <a
        class="link text-base-content link-neutral text-xl font-semibold no-underline"
        href="/"
      >
        ERE System
      </a>
    </div>
    <div class="navbar-end flex items-center gap-4">
      <div
        class="dropdown relative inline-flex [--auto-close:inside] [--offset:8] [--placement:bottom-end]"
      >
        <button
          id="dropdown-scrollable"
          type="button"
          class="dropdown-toggle flex items-center"
          aria-haspopup="menu"
          aria-expanded="false"
          aria-label="Dropdown"
        >
          <div class="avatar">
            <div class="size-9.5 rounded-full">
              <img src="https://i.pravatar.cc/300" alt="avatar 1" />
            </div>
          </div>
        </button>
        <ul
          class="dropdown-menu dropdown-open:opacity-100 hidden min-w-60"
          role="menu"
          aria-orientation="vertical"
          aria-labelledby="dropdown-avatar"
        >
          <li class="dropdown-header gap-2">
            <div class="avatar cursor-pointer">
              <div @click="goTo" data-cmp="me" class="w-10 rounded-full">
                <img src="https://i.pravatar.cc/300" alt="avatar" />
              </div>
            </div>
            <div>
              <h6 class="text-base-content text-base font-semibold">
                {{ user?.name }}
              </h6>
              <small class="text-base-content/50">{{ user?.role }}</small>
            </div>
          </li>

          <li class="dropdown-footer gap-2">
            <div @click="logout" class="btn btn-error btn-soft btn-block">
              <span class="icon-[tabler--logout]"></span>
              Sign out
            </div>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script setup lang="ts">
import { PropType } from "vue";
import { logout } from "../api/controllers";
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
