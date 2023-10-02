<script setup lang="ts">
    import { defineProps } from 'vue';

    defineProps(['modelValue'])
    defineEmits(['update:modelValue'])
</script>

<template>
    <textarea class="request-editor" :value="modelValue" @input="$emit('update:modelValue', ($event.target as HTMLTextAreaElement)?.value)"></textarea>
</template>

<style scoped>
    .request-editor {
        font-family: monospace;
        padding: 1rem;
        font-size: 0.9em;
        background-color: #3D4149;
        color: white;
        width: 100%;
        height: 80vh;
    }
</style>