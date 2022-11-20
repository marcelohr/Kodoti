import Loader from "@/shared/Loader";

export default {
  name: "SaveClient",
  mounted() {},
  components: {
    Loader,
  },
  data() {
    return {
      model: {
        name: null,
      },
      isLoading: false,
    };
  },
  methods: {
    save() {
      this.isLoading = true;
      this.$proxies.clientProxy
        .create(this.model)
        .then(() => {
            this.$notify({
                group: "global",
                type: "success",
                text: "Cliente Creado con Exito!"
            })
            this.$router.push('/clients')
        })
        .catch(() => {
            this.isLoading = false
            this.$notify({
                group: "global",
                type: "warning",
                text: "Cliente no creado"
            })
        });
    },
  },
};
