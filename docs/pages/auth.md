---
outline: deep
---

# Authentication

Only a single type of authentication is currently supported:

- Basic

The username and password will be passed in an `Authorization` header with the value `Basic <credentials>` where credentials is a base64 encoded string made up of `username:password`

### Coming soon

We are aiming to support the following additional authentication schemes

- OAuth 2.0

## Credentials

You can choose your own username/password combination and CMAC will store and use these whenever requests are made
