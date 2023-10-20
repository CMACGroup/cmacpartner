---
outline: deep
---

# Testing

Use this page to test your API implementation by loading requests so we can validate the responses.

## API details

<div v-if="!apiDetailsValid">
    <h4 style="color:red">Error</h4>
    <p style="color:red">Please provide all API details</p>
</div>

<div class="input-field">
<label for="username">Username:</label>
<input type="text" id="username" maxlength="100" v-model="username" required>
</div>
<div class="input-field">
<label for="password">Password:</label>
<input type="text" id="password" maxlength="100" v-model="password" required>
</div>
<div class="input-field">
<label for="baseUrl">Base Url:</label>
<input type="text" id="baseUrl" maxlength="255" placeholder="Full address e.g. https://myapi.operator.com" v-model="baseUrl" required>
</div>

<script setup lang="ts">
import { ref } from 'vue';
import { 
    quoteRequestSchema, 
    quoteResponseSchema, 
    sampleQuoteRequest, 
    bookRequestSchema,
    bookResponseSchema, 
    sampleBookRequest, 
    statusResponseSchema, 
     } from './schemas';
import { useRequestTests } from './composables/useRequestTests'
import ValidSchema from './components/ValidSchema.vue'
import RequestInput from './components/RequestInput.vue'

const quoteRequestContent = ref(sampleQuoteRequest)
const quoteResponseContent:QuoteResponse = ref(null)
const quoteResponseError:ErrorResponse = ref(null)

const bookRequestContent = ref(sampleBookRequest)
const bookResponseContent:BookResponse = ref(null)
const bookResponseError:ErrorResponse = ref(null)

const statusRequestId = ref('')
const statusResponseContent:StatusResponse = ref(null)
const statusResponseError:ErrorResponse = ref(null)

const updateRequestId = ref('')
const updateRequestContent = ref(sampleBookRequest)
const updateResponseContent:BookResponse = ref(null)
const updateResponseError:ErrorResponse = ref(null)

const cancelRequestId = ref('')
const cancelResponseContent:StatusResponse = ref(null)
const cancelResponseError:ErrorResponse = ref(null)

const bookingIdRequiredStatus = JSON.stringify({
            status: 400,
            statusText: "Booking id required",
          })

const username = ref('') // admin
const password = ref('') // admin
const baseUrl = ref('') // http://localhost:5143

const apiDetailsValid = ref(true)

const { requestInProgress, sendQuoteRequest, sendBookRequest, sendStatusRequest, sendUpdateRequest, sendCancelRequest } = useRequestTests(username, password, baseUrl)

const checkRequiredApiProps = () => {
    if (!username.value || !password.value || !baseUrl.value) {
        apiDetailsValid.value = false
        window.scrollTo(0, 0)
        return false
    }
    apiDetailsValid.value = true
    return true
}

const testQuote = async() => {
    if (!checkRequiredApiProps()) return
    await sendQuoteRequest(quoteRequestContent.value, quoteResponseContent, quoteResponseError)
}
const testBook = async() => {
    if (!checkRequiredApiProps()) return
    await sendBookRequest(bookRequestContent.value, bookResponseContent, bookResponseError)
}
const testStatus = async() => {
    if (!checkRequiredApiProps()) return
    if (!statusRequestId.value) {
        statusResponseError.value = bookingIdRequiredStatus
        return
    }
    await sendStatusRequest(statusRequestId.value, statusResponseContent, statusResponseError)
}
const testUpdate = async() => {
    if (!checkRequiredApiProps()) return
    if (!updateRequestId.value) {
        updateResponseError.value = bookingIdRequiredStatus
        return
    }
    await sendUpdateRequest(updateRequestId.value, updateRequestContent.value, updateResponseContent, updateResponseError)
}
const testCancel = async() => {
    if (!checkRequiredApiProps()) return
    if (!cancelRequestId.value) {
        cancelResponseError.value = bookingIdRequiredStatus
        return
    }
    await sendCancelRequest(cancelRequestId.value, cancelResponseContent, cancelResponseError)
}
</script>

<hr/>

### Quote

<ValidSchema :content="quoteRequestContent" :schema="quoteRequestSchema"></ValidSchema>
<RequestInput v-model="quoteRequestContent"></RequestInput>
<button class="button" v-if="!requestInProgress" @click="testQuote">Send</button>
<ValidSchema :content="quoteResponseContent" :schema="quoteResponseSchema" :error="quoteResponseError" include-content></ValidSchema>

<hr/>

### Book

<ValidSchema :content="bookRequestContent" :schema="bookRequestSchema"></ValidSchema>
<RequestInput v-model="bookRequestContent"></RequestInput>
<button class="button" v-if="!requestInProgress" @click="testBook">Send</button>
<ValidSchema :content="bookResponseContent" :schema="bookResponseSchema" :error="bookResponseError" include-content></ValidSchema>

<hr/>

### Status

<div class="input-field">
<label for="statusBookingId">Booking Id:</label>
<input type="text" id="statusBookingId" maxlength="255" v-model="statusRequestId">
</div>
<button class="button" v-if="!requestInProgress" @click="testStatus">Send</button>
<ValidSchema :content="statusResponseContent" :schema="statusResponseSchema" :error="statusResponseError" include-content></ValidSchema>

<hr/>

### Update

<ValidSchema :request-content="updateRequestContent" :schema="bookRequestSchema"></ValidSchema>

<div class="input-field">
<label for="updateBookingId">Booking Id:</label>
<input type="text" id="updateBookingId" maxlength="255" v-model="updateRequestId">
</div>
<RequestInput v-model="updateRequestContent"></RequestInput>
<button class="button" v-if="!loading" @click="testUpdate">Send</button>
<ValidSchema :content="updateResponseContent" :schema="bookResponseSchema" :error="updateResponseError" include-content></ValidSchema>

<hr/>

### Cancel

<div class="input-field">
<label for="cancelBookingId">Booking Id:</label>
<input type="text" id="cancelBookingId" maxlength="255" v-model="cancelRequestId">
</div>
<button class="button" v-if="!loading" @click="testCancel">Send</button>
<ValidSchema :content="cancelResponseContent" :schema="statusResponseSchema" :error="cancelResponseError" include-content></ValidSchema>

<hr/>
