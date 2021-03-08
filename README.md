# ProfitDistribution
Api de Distribuição de lucros é responsável 
- recuperar/cadastrar/deletar/atualizar funcionário(Employee)
- realizar um relatório de distribuição de lucros(ProfitDistribuitionReport) com base no total o que a empresa pretende disponibilizar para distribuir de lucros

## Persistência de dados
- Escolha foi Firebase como base de dados
- Configurações de conexão no appsettings.json
- Firebase livre para testes até dias  05/04/2021
- Identificador de Employee é o código da matricula

## Implementation structure
- API: Aplication developed using .NET  Core 3.1
- Services: Library layer that contains all business rules
- Domain: Library contains reusable classes in all application
- Infrastructure: Library layer of data persistence to firebase
- Tests: Test project using Moq and xunit to test all solution

## Como rodar
- Na raiz do projeto rodar o comando:
```
dotnet run --configuration Release --project src\ProfitDistribution.Api\ProfitDistribution.Api.csproj
```
- Rodar testes:
```
dotnet test test\ProfitDistribution.Test\ProfitDistribution.Test.csproj
```

## Frameworks e Tecnologias
 - [.NET  Core 3.1](https://docs.microsoft.com/pt-br/dotnet/core/introduction)
 - [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
 - [Firebase](https://firebase.google.com/products/realtime-database)
 - [Swagger](https://swagger.io/)
 