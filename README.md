# KoshelekTestTask
Test-Task 
## Description of the task:
Откройте папку KoshelekRuTestTask\KoshelekWebServer, зтем откройте cmd or powershell и используйте команды: 
1) docker compose build --no-cache
2) docker compose up

web-server (http://localhost:25545/)

Клиент для отправки сообщений (http://localhost:8181/api/html/SendMessage)

Клиент для прослушивания по web-socket (http://localhost:8282/api/html/WriteMessage), так же для прослушивания можно активировать несколько клиентов.

Клиент для просмотра сообщений по дате (http://localhost:8383/api/html/GetHisoryMessage) дату можно указать в формате 05/27/2024

## Technology Stack:
* ASP.NET Core
* Entity Framework Core
* PostgreSQL
* Docker
* Web-sockets
* Serilog
* Mock
* XUnit
