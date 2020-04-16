# DbUp-MySQL-Docker
DbUp .Net with MySQL client in Docker. DbUb MySQL in Docker.

DbUp is a .NET library that helps you to deploy changes to SQL Server, MySQL databases. It tracks which SQL scripts have been run already, and runs the change scripts that are needed to get your database up to date.

https://dbup.readthedocs.io/en/latest/


## Getting Started

Add all your database scripts inside `scripts` folder

### Prerequisites

Docker

### Build docker image

After adding SQL files inside `scripts` folder build the docker image

```
docker build --no-cache -t dbup-demo .
```
After scessuful build run docker image with passing argument of Query string for database connection.

```
docker run dbup-demo 'server=127.0.0.1;port=3306;database=data;user=root;password=passwordsecret;'
```
