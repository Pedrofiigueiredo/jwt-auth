# Autenticação e autorização via Token (Bearer e JWT)

Projeto simples para estudo.

Referência: [https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt]


### Pacotes

- ```Microsoft.AspNetCore.Authentication```
- ```Microsoft.AspNetCore.Authentication.JwtBearer```


### Rotas

Requisições do tipo POST devem conter o header ```Content-Type: application/json``` e as do tipo GET ```Authorization: Bearer [TOKEN_DO_USUARIO_LOGADO]```.

- ```POST v1/account/loggin``` - login
- ```GET v1/account/anonymous``` - autorizado para qualquer usuário
- ```GET v1/account/employee``` - autorizado para ```employee``` e ```manager```
- ```GET v1/account/manager``` - autorizado para ```manager```


* Dois usuários cadastrados:
  * ```Username: pedro``` | ```Password: pedro``` | ```Role: manager```
  * ```Username: daniel``` | ```Password: daniel``` | ```Role: employee```