<script setup lang="ts">
    import { computed } from 'vue';
    import { ZodSchema } from 'zod';
    import { ErrorResponse } from '../schemas'

    const props = defineProps<{
        content?: string
        schema: ZodSchema<unknown>
        error?: ErrorResponse
        includeContent: boolean,
        successIfEmpty: boolean
    }>()

    const valid = computed(() => {
        if (!props.content) {
            if (props.successIfEmpty) {
                return { success: true, error: { issues: [] } }
            }
            return { success: false, error: { issues: [{ message: 'No content', path: '' }] } }
        }
        try {
            const q = JSON.parse(props.content)
            return props.schema.safeParse(q)
        } catch (e) {
            return { success: false, error: { issues: [{ message: e.message, path: '' }] } }
        }
    })
</script>

<template>
    <p v-if="props.content && props.includeContent">
        {{ props.content }}
    </p>
    <p v-if="!props.content && !props.error && props.successIfEmpty">
        <p class="success">Success!</p>
    </p>
    <p v-if="!props.content && !props.error"></p>
    <p v-else-if="props.error">
        <p class="error">Error</p>
        <p class="error">{{ props.error }}</p>
    </p>
    <p v-else-if="!valid.success">
        <p class="error">Validation Error</p>
        <p class="error" v-for="e in valid.error.issues">
            {{ e.message }}. Path: {{ e.path }}
        </p>
    </p>
    <p v-else>  
        <p class="success">Valid!</p>
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