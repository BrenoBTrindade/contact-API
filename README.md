# Contact CRUD API

Boas-vindas ao repositório do projeto **Contact CRUD API** 👋  

Neste projeto você irá encontrar uma **API REST desenvolvida em ASP.NET Core**, responsável por gerenciar uma lista de contatos, permitindo **criar, listar, atualizar e remover contatos**.

O projeto foi desenvolvido com foco em:
- boas práticas de arquitetura
- separação de responsabilidades
- testes automatizados
- execução via Docker

Se tiver **qualquer dúvida**, fique à vontade para consultar a documentação ou os exemplos abaixo 🚀

---

## Termos e acordos

Ao utilizar este projeto, você concorda com as diretrizes de boas práticas de desenvolvimento de software, versionamento com Git e uso responsável de APIs REST.

---

## Como rodar o projeto
---

<details>
<summary><strong>🤷🏽‍♀️ Como utilizar este projeto</strong></summary>

Você pode:
- clonar este repositório
- rodar o projeto localmente
- rodar o projeto via Docker ou Docker Compose
- estudar a implementação como material de portfólio

Este projeto pode ser utilizado como **exemplo prático de uma API REST em .NET**.

</details>

<details>
<summary><strong>🧑‍💻 O que foi desenvolvido</strong></summary>

Foi desenvolvida uma **API de contatos** com as seguintes funcionalidades:

- Cadastro de contatos
- Listagem de todos os contatos
- Busca de contato por identificador
- Atualização de contatos
- Remoção de contatos
- Documentação automática com Swagger
- Testes automatizados
- Suporte a Docker

A API segue os padrões REST e utiliza corretamente os **HTTP Status Codes**.

</details>

<details>
<summary><strong>📝 Habilidades trabalhadas</strong></summary>

Neste projeto foram exercitadas as seguintes habilidades:

- Criação de APIs REST com ASP.NET Core
- Arquitetura em camadas (Controller, Service, Repository)
- Injeção de dependência
- Uso correto dos métodos HTTP
- Escrita de testes unitários e de integração
- Documentação de APIs com Swagger
- Conteinerização com Docker
- Orquestração com Docker Compose

</details>

---

## Estrutura do Projeto
---

```text
.
├── ContactCrud.Api/        # Projeto principal da API
├── ContactCrud.Tests/      # Testes automatizados
├── Dockerfile              # Build da imagem Docker
├── docker-compose.yml      # Orquestração de containers
├── ContactCrud.slnx        # Solution
└── README.md
