import { ref, type Ref } from "vue";
import { QuoteRequest, BookRequest, UpdateRequest } from "../schemas";

export const useRequestTests = (
  username: Ref<string>,
  password: Ref<string>,
  baseUrl: Ref<string>
) => {
  // Data
  const requestInProgress = ref(false);

  // Internal Methods
  const makeUrl = (path: string) => {
    return `${baseUrl.value}${baseUrl.value.endsWith("/") ? "" : "/"}${path}`;
  };

  const getAuthHeader = () => {
    return "Basic " + btoa(username.value + ":" + password.value);
  };

  async function sendRequest<TRequest extends { toString(): string }>(
    path: string,
    request: TRequest | null,
    successResponse: Ref,
    errorResponse: Ref,
    method: string = "POST"
  ) {
    successResponse.value = null;
    errorResponse.value = null;
    requestInProgress.value = true;
    try {
      const response = await fetch(makeUrl(path), {
        method,
        cache: "no-cache",
        redirect: "follow",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          Authorization: getAuthHeader(),
        },
        body: request?.toString(),
      });
      let result = await response.text();
      if (response.ok) {
        successResponse.value = result;
      } else {
        if (!result) {
          result = JSON.stringify({
            status: response.status,
            statusText: response.statusText,
          });
        }
        errorResponse.value = result;
      }
    } finally {
      requestInProgress.value = false;
    }
  }

  // Exported Methods
  const sendQuoteRequest = async (
    request: QuoteRequest,
    response: Ref,
    errorResponse: Ref
  ) => {
    return sendRequest("quote", request, response, errorResponse);
  };
  const sendBookRequest = async (
    request: BookRequest,
    response: Ref,
    errorResponse: Ref
  ) => {
    return sendRequest("book", request, response, errorResponse);
  };
  const sendStatusRequest = async (
    id: string,
    response: Ref,
    errorResponse: Ref
  ) => {
    return sendRequest("book/" + id, null, response, errorResponse, "GET");
  };
  const sendUpdateRequest = async (
    id: string,
    request: UpdateRequest,
    response: Ref,
    errorResponse: Ref
  ) => {
    return sendRequest("book/" + id, request, response, errorResponse, "PUT");
  };
  const sendCancelRequest = async (
    id: string,
    response: Ref,
    errorResponse: Ref
  ) => {
    return sendRequest("book/" + id, null, response, errorResponse, "DELETE");
  };
  return {
    requestInProgress,
    sendQuoteRequest,
    sendBookRequest,
    sendStatusRequest,
    sendUpdateRequest,
    sendCancelRequest,
  };
};
