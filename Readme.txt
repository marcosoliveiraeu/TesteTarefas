
 - No repositório TesteTarefas , está a pasta com o projeto frontend (TarefasAngular) , a pasta com o projeto backend (TarefasApi) e os scripts sql do bando de dados.


--------------------------------------------------------------------------------------

Passo 1 - Banco de dados : 

    No backend , para que a aplicação utilize o seu SQL Server , é preciso ajustar as configurações de ConnectionStrings no arquivo appsettings.json que está dentro do projeto TarefasApi de acordo com o servidor SqlServer que será utilizado .

    O banco de dados e as tabelas podem ser criados de duas formas diferentes. Via scrips ou via migrations pelo promt.

opção via Scripts: 
 - foi criado um script para criar o bando de dados e outro para criar as tabelas carregando alguns dados para teste.
 - rode primeiro o "01 - script criação do banco de dados DB_TesteTarefas.sql"  e depois o "02 - script criação de tabelas TesteTarefas.sql"

opção via promt de comando: 
 - na solução da Api , dentro da pasta Migrations , o arquivo já está pronto. É preciso entrar na pasta do projeto e digitar "dotnet ef database update".  

----------------------------------------------------------------------------------------
 
Passo 2 - BackEnd

  - abrir a solução do projeto no VisualStudio 2022 e inicializar o projeto via https .
  - a aplicação vai abrir o swagger e ali já podem ser feitos testes para visualizar a api funcionando.
  - a aplicação vai rodar em https://localhost:7131 , essa é a url que foi configurada no frontend  para buscar e consumir a api.  


------------------------------------------------------------------------------------------

Passo 3 - FrontEnd

  - abrir a pasta TarefasAngular via Visual Studio Code. 
  - abrir um novo terminal e executar o comando "npm install"
  - executar a aplicação usando o comando "ng serve"
  - a aplicação poderá ser acessada em http://localhost:3000

----------------------------------------------------------------------------------------
