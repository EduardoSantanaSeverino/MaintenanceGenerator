
YOUR_PROJECT_DIRECTORY="/Users/eduardosantana/source/AspnetBoilerPlate/8.1.0"
YOUR_PROJECT_NAME="AspnetBoilerPlate"
YOUR_ENTITY_LOWERCASE="place"
YOUR_TAG="v20230826_1319"

docker run --rm \
    -v $YOUR_PROJECT_DIRECTORY:/src \
    ghcr.io/eduardosantanaseverino/mg:$YOUR_TAG \
    --projectName $YOUR_PROJECT_NAME \
    --entity $YOUR_ENTITY_LOWERCASE
