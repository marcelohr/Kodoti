import Loader from "@/shared/Loader";

/* eslint-disable no-undef */
export default {
  name: "SaveProduct",
  mounted() {
    this.get();
  },
  components: {
    Loader,
  },
  data() {
    return {
      model: {
        productId: 0,
        name: null,
        description: null,
        price: 0,
      },
      isLoading: false,
    };
  },
  methods: {
    get() {
      if (this.$route.params.id) {
        this.isLoading = true;
        this.$proxies.productProxy
          .getById(this.$route.params.id)
          .then((x) => {
            this.isLoading = false;
            this.model = x.data;
          })
          .catch(() => {
            this.isLoading = false;
          });
      }
    },
    save() {
      this.isLoading = true;
      if (!this.model.productId) {
        this.$proxies.productProxy
          .create(this.model)
          .then(() => {
            this.$notify({
              group: "global",
              type: "success",
              text: "Producto creado con éxito.",
            });
            this.$router.push("/products");
          })
          .catch(() => {
            this.isLoading = false;
            this.$notify({
              group: "global",
              type: "warning",
              text: "Producto no creado.",
            });
          });
      } else {
        this.$proxies.productProxy
          .update(this.model.productId, this.model)
          .then(() => {
            this.$notify({
              group: "global",
              type: "success",
              text: "Producto actualizado con éxito!",
            });
            this.$router.push("/products");
          })
          .catch(() => {
            this.isLoading = false;
            this.$notify({
              group: "global",
              type: "warning",
              text: "Producto no actualizado.",
            });
          });
      }
    },
  },
};
