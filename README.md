# ADOPET.API

Bem-vindo ao meu projeto que eu desenvolvi durante estudos sobre Boas práticas cm C#. Sinta-se à vontade para baixar o projeto e executar em seu ambiente.

## Requisitos para execução em seu ambiente
- [.NET 8](https://dotnet.microsoft.com/download/dotnet)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Visual Studio](https://visualstudio.microsoft.com/vs/community/)

- ## Techonologies have used in this project so far

- .NET 8
- ASP.NET WEB API 
- Swagger/Swagger UI

- **Testes Unitários / Testes de Integração**

- XUnit

- ## Design Patterns

- Mediator
- Dependency Injection
- Repository

- ## Strategies

- Domain Driven Design (DDD)
- Test Driven Development (TDD)
- Command Query Responsability Segregation (CQRS)

- ## Comportamento esperado
- Esse projeto ler um arquivo com informações de pets e guardá-las na base de dados da AdoPet.
- O projeto irá permitir digitar comandos de importação para o arquivo. Esse projeto, que será do tipo console, irá ler o arquivo e importá-lo na base de dados da AdoPet.
- Porém, essa base de dados é controlada por outra aplicação, em uma API que irá manter a base de dados.
- O projeto possui uma solução para importar pets em lote, a qual não está na web, mas sim em um programa que roda no terminal.
-  A solução permite digitar um comando para ler o arquivo, e a partir disso, ela irá traduzir cada informação para um pet específico e consumir outra aplicação, a API da AdoPet.

