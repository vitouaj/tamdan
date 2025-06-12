<template>
  <StateLoading :isLoading="isLoading" />
  <div
    class="bg-cover bg-center"
    style="
      background-image: url(&quot;https://images.unsplash.com/photo-1523240795612-9a054b0db644?q=80&w=2070&auto=format&fit=crop&quot;);
    "
  >
    <div
      class="flex items-center justify-center min-h-screen bg-slate-900 bg-opacity-50"
    >
      <main
        class="w-full max-w-5xl mx-auto grid grid-cols-1 lg:grid-cols-2 rounded-xl shadow-2xl overflow-hidden"
      >
        <div
          class="hidden lg:flex flex-col justify-center text-white p-12 bg-blue-800 bg-opacity-80 backdrop-blur-sm"
        >
          <div class="space-y-4">
            <h1 class="text-4xl font-extrabold tracking-tight">
              Welcome Back to ERE Learning System
            </h1>
            <p class="text-blue-100 leading-relaxed">
              Continue your educational journey with our comprehensive learning
              platform designed for students, teachers, and parents.
            </p>
          </div>
        </div>

        <div class="bg-white p-8 sm:p-12">
          <div class="w-full">
            <div class="text-center mb-8">
              <h2 class="text-3xl font-bold text-gray-800">Sign In</h2>
              <p class="text-gray-500 mt-2">Access your student portal.</p>
            </div>

            <form action="#" method="POST" class="space-y-5">
              <div>
                <label
                  for="username"
                  class="block text-sm font-medium text-gray-700"
                  >Username</label
                >
                <div class="mt-1">
                  <input
                    id="username"
                    name="username"
                    v-model="payload.emailOrPhoneNumber"
                    type="email"
                    autocomplete="email"
                    required
                    class="w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    placeholder="name@company.com"
                  />
                </div>
              </div>

              <div>
                <label
                  for="password"
                  class="block text-sm font-medium text-gray-700"
                  >Password</label
                >
                <div class="mt-1">
                  <input
                    id="password"
                    name="password"
                    type="password"
                    v-model="payload.password"
                    autocomplete="current-password"
                    required
                    class="w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                    placeholder="••••••••"
                  />
                </div>
              </div>

              <div class="flex items-center justify-end">
                <div class="text-sm">
                  <a
                    href="#"
                    class="font-medium text-blue-600 hover:text-blue-500"
                    >Forgot Password?</a
                  >
                </div>
              </div>

              <div>
                <button
                  @click.prevent="submitLogin"
                  type="submit"
                  class="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 transition"
                >
                  Sign In →
                </button>
              </div>
            </form>

            <div class="mt-6">
              <p class="mt-8 text-center text-sm text-gray-500">
                Don't have an account?
                <a
                  href="/register"
                  class="font-semibold leading-6 text-blue-600 hover:text-blue-500"
                  >Sign Up</a
                >
              </p>
            </div>
          </div>
        </div>
      </main>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { doLogin } from "../api/API_Calls";
import { LoginWrapper } from "../api/DataWrapper";
import { Util } from "../api/Utility";
import StateLoading from "../components/ui/StateLoading.vue";
import { useRouter } from "vue-router";

const payload = ref<LoginWrapper>({
  emailOrPhoneNumber: "",
  password: "",
});

const router = useRouter();
const isLoading = ref(false);

async function submitLogin() {
  isLoading.value = true;
  let clonedPayload = Util.deepCloneData(payload?.value);
  try {
    let { data } = await doLogin(clonedPayload);
    let { success, payload } = data;
    if (success) {
      window.sessionStorage.setItem("ere-token", payload.token);
      router.push({ name: "home" });
    }
  } catch (error) {
    console.error("Login failed:", error);
  } finally {
    isLoading.value = false;
  }
}
</script>
