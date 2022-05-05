# Teste Técnico Wk Technology
Projeto desenvolvido em solicitação da empresa WKTechnology como fruto de avalição técnica

## Projeto API

## Dependências

* Necessário ter MySql instalado na máquina ou direcionar a um servidor.
* Microsoft.EntityFrameworkCore 6.0.4
* Microsoft.EntityFrameworkCore.Tools 6.0.4
* Pomelo.EntityFrameworkCore.MySql 6.0.1
* Pomelo.EntityFrameworkCore.MySql.Design 1.1.2
* Swashbuckle.AspNetCore 6.2.3

## Introdução

O projeto foi configurado as tabelas de Produto e Categoria, foi também configurado método seed para popular o sistema para facilitar um teste inicial.

# Documentação

Após clonar o projeto, deve:
* Verificar as conexões do MySQL para que possa rodar corretamente na sua máquina ou servidor.
* Rodar o comando "Update-Database" para criação do banco e população dos dados inicias.
* Verificar se a porta da API está diferente de "https://localhost:7221".

## Executar

E finalmente executar a aplicação:

* Opção 1: Por via comando:
`dotnet run`

* Opção 2: Utilizando a IDE


## Projeto WEB

## Dependências

* Ter Internet 
* Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 6.0.4

## Introdução

O projeto web não foi configurado contexto porque seus meios de crud são feitos atraves do Projeto API.

# Documentação

Após clonar o projeto, deve se atentar a porta de inicialização do Projeto API caso não vincule automáticamente.

## Executar

E finalmente executar a aplicação:

* Opção 1: Por via comando:
`dotnet run`

* Opção 2: Utilizando a IDE
