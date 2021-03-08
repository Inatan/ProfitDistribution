# ProfitDistribution
Api de Distribuição de lucros que é responsável por:
- Recuperar/cadastrar/deletar/atualizar funcionário(Employee);
- Realizar um relatório de distribuição de lucros(ProfitDistribuitionReport) com base no total o que a empresa pretende disponibilizar para distribuir de lucros.

## Persistência de dados
- Escolha foi Firebase como base de dados;
- Configurações de conexão no appsettings.json;
- Identificador de Employee é o código da matricula.

## Arquitetura
- API: Camada de aplicação onde é feita a comunicação com a API RestFul;
- Services: Camada responsável pelas regras de negócio da aplicação;
- Domain: Camada responsável pelas classes estruturas que definem o negócio;
- Infrastructure: Cammada de persistência de dados utilizando Firesharp (Firebase);
- Tests: Camada de teste onde são feitos os testes unitários utilizando moq e xunit.

# Como rodar
## Requisitos para rodar
- Para Rodar é necessário: 
	- [.Net Core Runtime 3.1](https://dotnet.microsoft.com/download);
	- [AspnetCore Runtime 3.1](https://dotnet.microsoft.com/download);
	
	
	
- Na raiz da solution o comando:
```
dotnet run --project src\ProfitDistribution.Api\ProfitDistribution.Api.csproj
```
- Ao iniciar a aplicação as abrir (http://localhost:5000/swagger/index.html) para ver a documentação da API.

- Para publicar API:
```
dotnet publish -c Release  -o ./publish src/ProfitDistribution.Api/ProfitDistribution.Api.csproj
```

- Rodar testes:
```
dotnet test test\ProfitDistribution.Test\ProfitDistribution.Test.csproj
```

## Frameworks e Tecnologias
 - [.NET  Core 3.1](https://dotnet.microsoft.com/download)
 - [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
 - [Firebase](https://firebase.google.com/products/realtime-database)
 - [Swagger](https://swagger.io/)
 
