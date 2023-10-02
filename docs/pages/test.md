---
outline: deep
---

# Testing

Use this page to test your API implementation by sending requests so we can validate the responses.

## API details

<div class="input-field">
<label for="username">Username:</label>
<input type="text" id="username" maxlength="100">
</div>
<div class="input-field">
<label for="password">Password:</label>
<input type="text" id="password" maxlength="100">
</div>
<div class="input-field">
<label for="baseUrl">Base Url:</label>
<input type="text" id="baseUrl" maxlength="255">
</div>

<script setup lang="ts">
import { ref } from 'vue';
import { quoteSchema, sampleQuote } from './schemas/requests';
import ValidSchema from './components/ValidSchema.vue'
import RequestInput from './components/RequestInput.vue'
const requestContent:string = ref(sampleQuote)
</script>

### Quote

<ValidSchema :request-content="requestContent" :schema="quoteSchema"></ValidSchema>
<RequestInput v-model="requestContent"></RequestInput>

<style scoped>

.input-field label {
    display: inline-block;
    width: 6rem;
}
.input-field input {
    border-bottom: 1px solid darkgrey;
    width: 30rem;
    margin-top: 10px;
    margin-bottom: 10px;
}
</style>
