## Português

# Projeto PDV

Projeto Faz um CRUD de produtos e consumidor e um frente de Loja

## Requisitos

-.net 8

- Visual Studio 22
- Node.js 18+
- Angular CLI 16 (`npm i -g @angular/cli@16`)

## Como rodar

# Infra

docker run --hostname=5dc10e105414 --mac-address=02:42:ac:11:00:03 --env=POSTGRES_PASSWORD=admin1234 --env=POSTGRES_DB=inicialdatabase --env=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/lib/postgresql/16/bin --env=GOSU_VERSION=1.17 --env=LANG=en_US.utf8 --env=PG_MAJOR=16 --env=PG_VERSION=16.4-1.pgdg120+1 --env=PGDATA=/var/lib/postgresql/data --volume=/var/lib/postgresql/data --network=bridge -p 5432:5432 --restart=no --runtime=runc -d postgres:latest

Aqui cria um Container com o banco de dados Postgres

# Front

```bash
npm install
npm start
```

# Back

Abra o visual studio faã um build da aplicação e então rode o container da aplicação
Como precisa fazer umas implementações no front disponibilizo umas collection para funcionar a aplicação

## English

# POS Project

This project provides a CRUD for products and customers, as well as a Point of Sale (POS) frontend.

## Requirements

- .NET 8
- Visual Studio 2022
- Node.js 18+
- Angular CLI 16 (`npm i -g @angular/cli@16`)

## How to Run

### Infrastructure

docker run --hostname=5dc10e105414 --mac-address=02:42:ac:11:00:03 --env=POSTGRES_PASSWORD=admin1234 --env=POSTGRES_DB=inicialdatabase --env=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/lib/postgresql/16/bin --env=GOSU_VERSION=1.17 --env=LANG=en_US.utf8 --env=PG_MAJOR=16 --env=PG_VERSION=16.4-1.pgdg120+1 --env=PGDATA=/var/lib/postgresql/data --volume=/var/lib/postgresql/data --network=bridge -p 5432:5432 --restart=no --runtime=runc -d postgres:latest

This will create a Docker container with a PostgreSQL database.

# Front

```bash
npm install
npm start
```

# Back

Open the solution in Visual Studio, build the application, and then run the application container.

Since some frontend implementations are still in progress, I’m also providing a Postman collection to interact with the application.
