# WotBlitzStatisticsPro
Detailed player &amp; tank statistics and history for [World of Tanks: Blitz](https://wotblitz.com/)

- Uses [Wargaming API Service](https://developers.wargaming.net/documentation/guide/getting-started/) for gathering players statistics
- Stores statistics snapshots in local database
- Allows to view players, their tanks and achievements statistics, and how it was change in time

## Technologies used:

- Backend - GraphQL API based on .Net core 3 Web server ([GraphQL HotChocolate](https://hotchocolate.io/) + MongoDB)
- Frontent - Blazor WebAssembly (coming soon)

### Local MongoDB Installation for debugging ([Docker desktop for Windows](https://www.docker.com/products/docker-desktop))
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

### Hosting solution (k8s)
(Coming soon)

## Contact me:
[dr.mboga@yahoo.com](mailto:dr.mboga@yahoo.com)
