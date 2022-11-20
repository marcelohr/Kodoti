import Loader from "@/shared/Loader";

/* eslint-disable no-undef */
export default {
  name: "SaveProduct",
  mounted() {},
  components: {
    Loader,
  },
  data() {
    return {
      model: {
        name: null,
        description: null,
        price: 0,
      },
      isLoading: false,
    };
  },
  methods: {
    save() {
      this.isLoading = true;
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
    },
  },
};