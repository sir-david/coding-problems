# Proyecto Currency converter
El archivo Program consulta la información desde un endpoint online y almacena localmente los valor de las tasas de cambio en una base LiteDB.


# EL proyecto rest-api 
Tiene un solo controlador donde se puede consultar la información de una tasa de cambio. el api responde al siguietne format:

https://<host>:<port>/api/exchangerate/<enviroment>/<from>/<to>
- host: Servidor
- port: Puerto
- enviroment: Local o remoto (le dice al api si usar la base de datos local o el servicio remoto)
- from: Symbolo origen de la tasa de cambio
- to: Symbolo origen de la tasa de cambio


Ejemplo:

https://localhost:44378/api/exchangerate/local/clp/usd