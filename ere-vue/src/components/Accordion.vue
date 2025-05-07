<script setup>
window.addEventListener("load", function () {
  const { element } = HSAccordion.getInstance("#payment-event", true);

  element.on("open", (instance) => {
    console.log("open");
  });
  element.on("close", (instance) => {
    console.log("close");
  });
});

defineProps({
  id: {
    type: String,
    default: "payment-event",
  },
  title: {
    type: String,
    default: "When is payment taken for my order?",
  },
  content: {
    type: Object,
    default:
      "Payment is taken during the checkout process when you pay for your order. The order number that appears on the confirmation screen indicates payment has been successfully processed.",
  },
});
</script>

<template>
  <div class="accordion">
    <div class="accordion-item" id="payment-event">
      <button
        id="payment-event-btn"
        class="accordion-toggle inline-flex items-center gap-x-4 text-start"
        aria-controls="payment-event-collapse"
      >
        <span
          class="icon-[tabler--plus] accordion-item-active:hidden text-base-content size-4.5 block shrink-0"
        ></span>
        <span
          class="icon-[tabler--minus] accordion-item-active:block text-base-content size-4.5 hidden shrink-0"
        ></span>
        {{ title }}
      </button>
      <div
        id="payment-event-collapse"
        class="accordion-content hidden w-full overflow-hidden transition-[height] duration-300"
        aria-labelledby="payment-event"
      >
        <div class="px-5 pb-4">
          <p class="text-base-content/80 font-normal">
            {{ content }}
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
