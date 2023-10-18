<script setup>
import DefaultTheme from "vitepress/theme";

const { Layout } = DefaultTheme;
</script>

<template>
  <Layout>
    <template #nav-bar-title-before>
      <img src="/img/favicon-32x32.png" alt="logo" style="margin-right: 10px" />
    </template>
  </Layout>
</template>
