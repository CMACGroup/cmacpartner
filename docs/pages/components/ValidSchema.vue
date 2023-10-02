<script setup lang="ts">
    import { computed, defineProps } from 'vue';
    import { ZodSchema } from 'zod';

    const props = defineProps<{
        requestContent?: string
        schema: ZodSchema<unknown>
    }>()

    const valid = computed(() => {
        const q = JSON.parse(props.requestContent ?? '')
        return props.schema.safeParse(q)
    })
</script>

<template>
    <p v-if="!valid.success">
        <p class="error">Invalid request</p>
        <p class="error" v-for="e in valid.error.issues">
            {{ e.message }}. Path: {{ e.path }}
        </p>
    </p>
    <p v-else>
        <p class="success">Request OK</p>
    </p>
</template>

<style scoped>
.success {
    color: green;
}
.error {
    color: red;
}
</style>