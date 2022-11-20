import Pager from '@/shared/Pager'
import Loader from '@/shared/Loader'

export default {
  name: "IndexUser",
  mounted() {
    this.getAll(1);
  },
  components: {
    Pager, Loader
  },
  data() {
    return {
      collection: {
        hasItems: false,
        items: [],
        page: 1,
        pages: 0,
        total: 0,
      },
      isLoading: true
    }
  },
  methods: {
    getAll(page) {
      this.isLoading = false
      this.$proxies.userProxy.getAll(page, 10).then(x => {
        this.collection = x.data;
        this.isLoading = true
      });
    }
  }
};
