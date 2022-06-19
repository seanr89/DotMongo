# DotMongo

.Net Implementation Practice with MongoDB

## Docker Commands/Scripts

spin up a simple mongo instance `docker run --name some-mongo -d -p 27017:27017 mongo:tag`

connect to docker instance `docker exec -it some-mongo /bin/bash`

connect to mongo `mongo`

create db `use EventDb`


## Docker Compose
run cmd `docker compose -f docker-compose.dev.yml up -d mongo-cont`

stop compose `docker-compose stop`

remove compose `docker-compose down`