#### Autor: Pablo J. Santos --> @JaySaints


Agora esta sendo implementado a ferramenta __EntityFramework__ para que seja possivel conectar o projeto com o banco de dados SQL Server.

Para isso é necessário realizar a instalação do __EntityFramework__ no projeto atual.

Instalar o EntityFramework pelo console: 
> Install-Package EntityFramework

Após instalar a biblioteca acima, configure o arquivo __App.config__ com a string de conexão.
````
<connectionStrings>
	<add name="MyContext" providerName="System.Data.SqlClient" connectionString="Server=<NOME-INSTANCIA>;Database=<NOME-DATABASE>;Integrated Security=True;" />
</connectionStrings>
````    
- Copie o codigo acima e cole dentro do aquivo app.config abaixo do bloco `<configSections>...</configSections>` 
- No campo Server= coloque o nome da suas instancia do SQL Server;  
- No campo Database= coloque o nome do seu banco de dados existente na instancia do SQL Server;

__Obs: Consfigure a string de conexão com as configurações da sua máquina__
