FROM mcr.microsoft.com/appsvc/staticappsclient:stable
WORKDIR /app/build
COPY ./build/entrypoint.sh ./
COPY ./docs ./docs
ENTRYPOINT ["bash", "/app/build/entrypoint.sh"]
