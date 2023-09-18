---
outline: deep
---

# Authentication

Two types of authenticate are supported:

- Basic

The username and password will be passed in an `Authorization` header with the value `Basic <credentials>` where credentials is a base64 encoded string made up of `username:password`

- OAuth 2.0

A url is provided that will return a JWT

## Credentials

You can choose your own username/password combination and CMAC will store and use these whenever requests are made
