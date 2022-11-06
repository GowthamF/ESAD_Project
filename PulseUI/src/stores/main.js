import { defineStore } from "pinia";

// main is the name of the store. It is unique across your application
// and will appear in devtools
export const useCounterStore = defineStore("counterStore", {
  state: () => ({
    counter: 2,
  }),
  actions: {
    multiply() {
      this.counter = ++this.counter;
    },
  },
});
