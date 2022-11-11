<template>
  <v-card>
    <v-card-title>
      <span class="text-h5">{{ `Add ${modalTitle}` }}</span>
    </v-card-title>
    <v-card-text>
      <v-container fluid>
        <v-col>
          <v-form ref="form" v-model="valid" lazy-validation>
            <v-text-field
              outlined
              v-model="typeName"
              :rules="typeNameRule"
              :label="title"
              required
            ></v-text-field>
          </v-form>
        </v-col>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" text @click="close()"> Close </v-btn>
      <v-btn color="blue darken-1" text @click="save()"> Save </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      typeName: null,
      valid: false,
      typeNameRule: [(v) => !!v || "Name is required"],
      title: this.modalTitle,
    };
  },
  methods: {
    close() {
      this.$refs.form.resetValidation();
      this.$emit("close-dialog");
    },
    save() {
      var isValid = this.$refs.form.validate();
      if (isValid) {
        this.$emit("save-type", this.typeName);
      }
    },
  },
  props: {
    modalTitle: {
      type: String,
      required: true,
    },
  },
};
</script>

<style>
</style>