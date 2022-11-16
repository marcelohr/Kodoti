export default {
  name: "IndexUser",
  mounted() {
    this.getAll(1)
  },
  methods: {
    getAll(page) {
      this.$proxies.userProxy.getAll(page, 20)
    }
  }
};
