import Pager from "@/shared/Pager";
import Loader from "@/shared/Loader";

export default {
  name: "IndexProduct",
  mounted() {
    this.getAll(1);
  },
  components: {
    Pager,
    Loader,
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
      isLoading: false,
    };
  },
  methods: {
    getAll(page) {
      this.isLoading = true;
      this.$proxies.productProxy.getAll(page, 10).then(x => {
        this.collection = x.data;
        this.isLoading = false;
      });
    },
    remove(id) {
      this.isLoading = true;
      this.$proxies.productProxy.remove(id).then(() => {
        this.getAll(1);
      });
    },
  },
};
