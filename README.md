# dz-api
Parte da avaliação prática

## Recursos

- .net Core 3.1
- EF Core
  - MySQL
- Pattern Repository
- CQRS e MediatR
- FluentAPI
- Automapper
- Firebase
- Swagger como Api Explorer
- Clean Architecture


## Funcionalidades:
- Criar conta com saldo inicial;
- Consulta e validação de conta a ser utilizado na autenticação;
- Atualizar de saldo;
- Converter pontos em Reais;
- Converter Reais em pontos;
- Adicionar de cartão de crédito virtual ou físico com limite compartilhado;
- Atualizar o Status do Cartão de Crédito;
- Atualizar dia de vencimento do Cartão de Crédito;
- Consultar Cartões de Crédito da Conta;
- Simular uma transação;
- Consultar transações da conta aplicando filtro de paginação.

## Pré-requisitos

1. Docker
2. Visual studio 2019 OU VSCode com extensão C#
3. Node (para instalação do pacote http-server para recuperar o jwt do firebase)

## Instalação

1. Clone este repositório:

  ```
  git clone https://github.com/fabiomaias/dz-webapi
  ```


2. Acessar o diretório e executar com docker compose:

  ```
  docker-compose up -d
  ```
  
     
- O Swagger estará acessível através do *http://localhost:9000/swagger/*

3. Instale o http-server
  ```
  npm install --global http-server
  ```
  
4. Acesse o [diretório do projeto]/firetest e execute o http-server
  ```
  http-server -c1
  ```

5. Abra a url http://localhost:8080 no browser, pressione f12, autentique e copie o JWT do retorno no console para utilizar na autenticação
  ```
  Bearer [JWT retornado no console]
  ```
  
6. Crie uma conta no endpoint */api/account/sign-on* para testar as funcionalidades. 
