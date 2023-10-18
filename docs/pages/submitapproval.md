---
prev: false
next: false
---

# Submit Approval

Once you have successfully used the [Testing](/pages/test) page to run validation tests against your implementation you can use this page to send us a request to enable the integration between ourselves. Our internal Supplier Relations team will validate the information submitted make sure you're onboarded as soon as possible.

We ask that you submit details for both your testing and production environments. This enables us to create some automated tests

If you've already submitted an approval request and simply need an update, you can contact us by email on [supplierrelations.cmacgroup.com](mailto:supplierrelations.cmacgroup.com).

<div class="input-field">
<label for="companyname">Name:</label>
<input type="text" id="companyname" maxlength="100" placeholder="Operator's name e.g. London Taxis" v-model="companyname" required>
</div>
<div class="input-field">
<label for="coverage">Coverage:</label>
<textarea id="coverage" rows="10" cols="65" maxlength="1000" placeholder="The areas you are willing to cover without charging lead miles. This can be a list of postcodes within the UK e.g. LS10, LS11, or another description that would enable us to control which jobs are sent to you" v-model="coverage" required></textarea>
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
const companyname = ref('')
const coverage = ref('')
const username = ref('')
const password = ref('')
const baseUrl = ref('')
const submitApproval = () => {
  return true
}
</script>

<button class="button" @click="submitApproval">Send</button>
