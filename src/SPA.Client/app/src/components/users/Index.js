import Pager from '@/shared/Pager'

export default {
  name: "IndexUser",
  mounted() {
    this.getAll(1);
  },
  components: {
    Pager
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
      this.$proxies.userProxy.getAll(page, 10).then(x => {
        this.collection = x.data;
      });
    }
  }
};
