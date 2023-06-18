# Projeto CarrefourBankTest

Este projeto fornece uma API RESTful para controlar débitos e créditos em uma conta, juntamente com a geração de um relatório para o saldo. Ele segue a arquitetura Domain Driven Design (DDD) usando .NET 6.0, Entity Framework e SQLite como banco de dados.

## Visão Geral da Arquitetura

![Fluxo](https://github.com/leandrobg/CarrefourBankTest/blob/main/Fluxo.png)

O projeto segue a arquitetura DDD, que separa o código em várias camadas para obter uma estrutura clara e modular:

- **CarrefourBankTest.Domain**: Contém os modelos de domínio e a lógica de negócio.
- **CarrefourBankTest.Application**: Implementa a camada de aplicação.
- **CarrefourBankTest.Infrastructure**: Fornece serviços de infraestrutura e implementação de acesso a dados.
- **CarrefourBankTest.Api**: Contém os controladores da API RESTful e a configuração.
- **CarrefourBankTest.UnitTests**: Inclui testes unitários para o projeto.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes pré-requisitos instalados:

- .NET 6.0 SDK: [Baixe Aqui](https://dotnet.microsoft.com/download)
- Docker: [Baixe Aqui](https://www.docker.com/get-started)

## Instruções

Siga estes passos para executar o projeto:

1. Clone o repositório:
    ```
    git clone https://github.com/your-username/MyApi.git
    ```

2. Navegue até o diretório do projeto:
    ```
    cd CarrefourBankTest
    ```

3. Restaure as dependências do projeto:
    ```
    dotnet restore
    ```

4. Compile o projeto:
    ```
    dotnet build
    ```

5. Execute o projeto:
    ```
    dotnet run --project CarrefourBankTest.WebApi
    ```

6. A API agora deve ser acessível em [http://localhost:5000](http://localhost:5000).

## Publicando o Projeto no Docker

Para publicar o projeto em um contêiner Docker, siga estes passos:

1. Compile a imagem Docker:
    ```
    docker build -t CarrefourBankTest .
    ```

2. Execute o contêiner Docker:
    ```
    docker run -d -p 8080:80 CarrefourBankTest
    ```
    A flag -p mapeia a porta 8080 na máquina host para a porta 80 dentro do contêiner Docker.

3. A API agora deve ser acessível em [http://localhost:8080](http://localhost:8080).

## Executando os Testes

Para executar os testes, execute o seguinte comando:
```
    dotnet test
```

Isso executará todos os testes unitários no projeto e exibirá os resultados dos testes.
