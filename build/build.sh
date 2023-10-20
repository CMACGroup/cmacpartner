#!/bin/bash
set -e
echo "Deploy - Static Web App"
docker build -t deploycmacpartnerspa -f ./Dockerfile ../
docker run -e "APP_PATH=/app/build" -e "API_TOKEN=$swatoken_cmacpartner" -e "OUTPUT_PATH=/app/build/docs/.vitepress/dist" -e "APP_BUILD_COMMAND='npm run build'" deploycmacpartnerspa
