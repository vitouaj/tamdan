<template>
  <div class="card w-full mb-10">
    <div class="card-body content">
      <form v-if="contactModel" class="space-y-4 md:space-y-6" action="#">
        <div class="grid grid-cols-2 gap-4">
          <div class="col-span-1">
            <label for="firstname" class="block mb-2 text-sm font-medium"
              >Firstname</label
            >
            <input
              type="text"
              name="firstname"
              id="firstname"
              v-model="contactModel.firstName"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder="firstname"
              required
            />
          </div>
          <div class="col-span-1">
            <label for="lastname" class="block mb-2 text-sm font-medium"
              >Lastname</label
            >
            <input
              type="text"
              name="lastname"
              v-model="contactModel.lastName"
              id="lastname"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder="lastname"
              required
            />
          </div>
        </div>

        <div>
          <label for="email" class="block mb-2 text-sm font-medium"
            >Email</label
          >
          <input
            type="email"
            name="email"
            v-model="contactModel.email"
            id="email"
            class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="name@company.com"
            required
          />
        </div>

        <div>
          <label for="phone" class="block mb-2 text-sm font-medium"
            >Phone</label
          >
          <input
            type="text"
            name="phone"
            v-model="contactModel.phone"
            id="phone"
            class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder=""
            required
          />
        </div>

        <div class="grid grid-cols-2 gap-4">
          <div class="col-span-1">
            <div class="col-span-1">
              <label for="streetno" class="block mb-2 text-sm font-medium"
                >Street No</label
              >
              <input
                type="text"
                name="streetno"
                v-model="contactModel.street"
                id="streetno"
                class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
                placeholder="01992121"
                required
              />
            </div>
          </div>
          <div class="col-span-1">
            <label for="homeno" class="block mb-2 text-sm font-medium"
              >Home/Apartment No</label
            >
            <input
              type="text"
              name="homeno"
              v-model="contactModel.homeNumber"
              id="homeno"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder="01992121"
              required
            />
          </div>
          <div class="col-span-1">
            <label for="village" class="block mb-2 text-sm font-medium"
              >Village</label
            >
            <input
              type="text"
              name="village"
              v-model="contactModel.village"
              id="village"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder=""
              required
            />
          </div>
          <div class="col-span-1">
            <label for="commune" class="block mb-2 text-sm font-medium"
              >Commune</label
            >
            <input
              type="text"
              name="commune"
              v-model="contactModel.commune"
              id="commune"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder=""
              required
            />
          </div>
          <div class="col-span-1">
            <label for="district" class="block mb-2 text-sm font-medium"
              >District</label
            >
            <input
              type="text"
              name="district"
              v-model="contactModel.district"
              id="district"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder=""
              required
            />
          </div>
          <div class="col-span-1">
            <label for="province" class="block mb-2 text-sm font-medium"
              >Province</label
            >
            <input
              type="text"
              name="province"
              v-model="contactModel.province"
              id="province"
              class="bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:placeholder-gray-400 dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder=""
              required
            />
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  contactModel: any;
}>();
</script>
