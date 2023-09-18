---
outline: deep
---

# Authentication

To simplify how CMAC will authenticate with your API you should use basic authentication. This will mean that the API should be served over HTTPS/SSL and the username/password will be passed in an `Authorization` header with the value `Basic <credentials>` where credentials is a base64 encoded string made up of `username:password`

## Credentials

You can choose your own username/password combination and CMAC will store and use these whenever requests are made
