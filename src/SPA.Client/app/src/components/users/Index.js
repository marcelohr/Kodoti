export default {
  name: "IndexUser",
  mounted() {
    this.getAll(1);
  },
  data() {
    return {
      collection: {
        hasItems: false,
        items: [],
        page: 1,
        pages: 0,
        total: 0,
      }
    }
  },
  methods: {
    getAll(page) {
      this.$proxies.userProxy.getAll(page, 20).then(x => {
        this.collection = x.data;
      });
    }
  }
};
