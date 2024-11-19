docker network create builderpulsepro --label=builderpulsepro
docker-compose -f docker-compose.infrastructure.yml up -d
exit $LASTEXITCODE