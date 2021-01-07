# WotBlitzStatisticsPro
Detailed player &amp; tank statistics and history for [World of Tanks: Blitz](https://wotblitz.com/)

- Uses [Wargaming API Service](https://developers.wargaming.net/documentation/guide/getting-started/) for gathering players statistics
- Stores statistics snapshots in local database
- Allows to view players, their tanks and achievements statistics, and how it was change in time

## Technologies used:

- Backend - GraphQL API based on .NET 5.0 Web server ([GraphQL HotChocolate](https://hotchocolate.io/) + MongoDB)
- Frontent - Blazor WebAssembly (coming soon)

## Local MongoDB Installation for debugging ([Docker desktop for Windows](https://www.docker.com/products/docker-desktop))
For the developing and debugging purposes, you have to istall MongoDB locally on your dev machine and run it as a service. Alternatively, if you have istalled [Docker desktop for Windows](https://www.docker.com/products/docker-desktop), you can deploy MongoDB inside the container. To do so, create an empty folder and make 2 files there: ```docker-compose.yml``` and ```.env```. Second one will contain sensitive data. 

<details>
  <summary>Example for docker-compose.yml with mongo-express shell:</summary>

```yml
version: "3"
services:
    mongo:
        image: mongo
        restart: always
        container_name: "mein-mongo"
        ports:
            - "27017:27017"
        environment:
            MONGO_INITDB_ROOT_USERNAME: "${DB_USERNAME}"
            MONGO_INITDB_ROOT_PASSWORD: "${DB_PASSWORD}"
        volumes:
            - "mongodblvolume:/data/db"
    mongo-express:
        image: mongo-express
        container_name: "mein-mongo-express"
        restart: always
        ports:
            - 8081:8081
        environment:
            ME_CONFIG_MONGODB_ADMINUSERNAME: "${DB_USERNAME}"
            ME_CONFIG_MONGODB_ADMINPASSWORD: "${DB_PASSWORD}"
volumes:
  mongodblvolume:
```
</details>

<details>
<summary>Example of .env file</summary>

```
DB_USERNAME=root
DB_PASSWORD=P@SSW0RT!
```
</details>
<br>
To install docker, use shell command:

```bash
docker-compose up -d
```

That's all. You can use mongo shell like this:

```bash
docker exec -it mein-mongo bash
mongo --username root --password --authenticationDatabase admin
use your_database_name
db.someSampleCollection.insert({})
```

Or you can use mongo-express by this address: http://localhost:8081/

To use this mongo instance in application, use this connection string in ```appsettings.json```:

```json
{
        "Mongo": {
            "ConnectionString": "mongodb://root:P@SSW0RT!@localhost:27017/?authSource=admin"
    } 
}
```

## Backup and restore database using mongodump/mongorestore

[Mongudump/mongorestore documentation](https://docs.mongodb.com/manual/tutorial/backup-and-restore-tools/)

To backup or restore database, donwnload mongo database tools for Windows [here](https://www.mongodb.com/try/download/database-tools). You can unzip tools somewhere and add path to them in environment variables.

1. To backup for example `WotBlitzStatisticsPro` database from `localhost` with port 27017, execute this command:

```bash
mongodump --host=localhost --port=27017 --username=root --password="[YOUR PASSWORD]" --out=backup/mongodump-2020-12-27 --db=WotBlitzStatisticsPro --authenticationDatabase=admin
```

2. To restore `WotBlitzStatisticsPro` to `localhost` with port 27017, execute this command:

```bash
mongorestore --host=localhost --port=27017 --username=root --password="[YOUR PASSWORD]" --authenticationDatabase=admin mongodump-2020-12-27
```

## Deploying solution using docker-compose

1. First, build container image to have it locally:

```bash
- docker build -t mike/wot-blitz-statistics-pro:v1 .
```

2. Create environment file `.env` and fill the values in it (without square brackets):

```env
WARGAMING_APPLICATION_ID=[your_application_id]
MONGO_CONNECTION_STRING=mongodb://[your_db_user]:[your_db_password]@mongo:27017/?authSource=admin
MONGO_DATABASE_NAME=WotBlitzStatisticsPro
DB_USERNAME=[your_db_user]
DB_PASSWORD=[your_db_password]
```

3. Deploy application, using command:

```bash
docker-compose up -d
```

4. Navigate to http://localhost:8000 (or http://localhost:8000/graphql/ for GraphQl playground)

5. Do delete the deployment, use command:

```bash
docker-compose down
```

## Deploying solution using Kubernetes and kubectl

1. First, build container image to have it locally:

```bash
- docker build -t mike/wot-blitz-statistics-pro:v1 .
```

2. Create a k8s `secret` and fill the values in it (without square brackets), using command:

```bash
kubectl create secret generic wot-blitz-statistics-secret --from-literal='MONGO_INITDB_ROOT_PASSWORD=[your_db_password]' --from-literal='MONGO_INITDB_ROOT_USERNAME=[your_db_user]' --from-literal='Mongo__ConnectionString=mongodb://[your_db_user]:[your_db_password]@wot-blitz-statistics-pro-app-mongo-service:27027/?authSource=admin' --from-literal='Mongo__DatabaseName=WotBlitzStatisticsPro' --from-literal='WargamingApi__ApplicationId=[your_application_id]'
```

3. Deploy application, using command:

```bash
kubectl apply -f k8s
```

4. Navigate to http://localhost:8040 (or http://localhost:8040/graphql/ for GraphQl playground)

5. Do delete the deployment, use command:

```bash
kubectl delete -f k8s
```




## Contact me:
[dr.mboga@yahoo.com](mailto:dr.mboga@yahoo.com)
