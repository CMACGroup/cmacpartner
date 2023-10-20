#!/bin/bash

cd /bin/staticsites/
Comd="./StaticSitesClient --deploymentaction 'upload' --deploymentProvider 'GitLab' --apiToken $API_TOKEN --app $APP_PATH"

if [[ $VERBOSE != "" ]]
then
    Comd+=" --verbose "$VERBOSE
fi
if [[ $WOR_DIR != "" ]]
then
    Comd+=" --workdir "$WOR_DIR
fi
if [[ $BUILD_TIM_MIN != "" ]]
then
    Comd+=" --buildTimeoutInMinutes "$BUILD_TIM_MIN
fi
if [[ $API_PATH != "" ]]
then
    Comd+=" --api "$API_PATH
fi
if [[ $ROUTE_PATH != "" ]]
then
    Comd+=" --routesLocation "$ROUTE_PATH
fi
if [[ $CONFIG_PATH != "" ]]
then
    Comd+=" --configFileLocation "$CONFIG_PATH
fi
if [[ $OUTPUT_PATH != "" ]]
then
    Comd+=" --outputLocation "$OUTPUT_PATH
fi
if [[ $ARTIFACT_PATH != "" ]]
then
    Comd+=" --appArtifactLocation "$ARTIFACT_PATH
fi
if [[ $EVENT_PATH != "" ]]
then
    Comd+=" --event "$EVENT_PATH
fi
if [[ $REPO_TOKEN != "" ]]
then
    Comd+=" --repoToken "$REPO_TOKEN
fi
if [[ $APP_BUILD_COMMAND != "" ]]
then
    Comd+=" --appBuildCommand "$APP_BUILD_COMMAND
fi
if [[ $API_BUILD_COMMAND != "" ]]
then
    Comd+=" --apiBuildCommand "$API_BUILD_COMMAND
fi
if [[ $REPO_URL != "" ]]
then
    Comd+=" --repositoryUrl "$REPO_URL
fi
if [[ $DEPLOYMENT_ENVIRONMENT != "" ]]
then
    Comd+=" --deploymentEnvironment "$DEPLOYMENT_ENVIRONMENT
fi
if [[ $BRANCH != "" ]]
then
    Comd+=" --branch "$BRANCH
fi
if [[ $SKIP_APP_BUILD != "" ]]
then
    Comd+=" --skipAppBuild "$SKIP_APP_BUILD
fi
if [[ $SKIP_API_BUILD != "" ]]
then
    Comd+=" --skipApiBuild "$SKIP_API_BUILD
fi
if [[ $IS_STATIC_EXPORT != "" ]]
then
    Comd+=" --isStaticExport "$IS_STATIC_EXPORT
fi
if [[ $PR_TITLE != "" ]]
then
    Comd+=" --pullRequestTitle "$PR_TITLE
fi
if [[ $HEAD_BRANCH != "" ]]
then
    Comd+=" --headBranch "$HEAD_BRANCH
fi
if [[ $PROD_BRANCH != "" ]]
then
    Comd+=" --productionBranch "$PROD_BRANCH
fi
if [[ $VERSION != "" ]]
then
    Comd+=" --version "$VERSION
fi
if [[ $HELP != "" ]]
then
    Comd+=" --help "$HELP
fi

eval $Comd
