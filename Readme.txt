ChallengeNetWeb.

-Se recomienda iniciar con la credenciales de:
	°Número de tarjeta: 1234567891234567	
	°Número de pin: 1234

-Tecnologías utilizadas:
	°Bootstrap 5.3.0
	°JQuery 3.7.0
	°SQL Express 2008
	°.Net 6.0
	°Dapper 2.0.143
	°Microsoft.Data.SqlClient 5.1.1
	°Entity Framework 6.4.4
	
-Referencias entre capas y pluggins:
	°Capa DTO: 		Dapper
	°Capa DataAcces:	DTO, EntityFramework
	°Capa Business: 	DTO,DataAcces, Models		
	°Capa Models: 	DTO
	°Capa UI: 		Bootstrap, Jquery, Capa Business, Capa Models
	
-Información de la Base de Datos 
	°Nombre: ATMdb
	°Servidor local: (localdb)\MSSQLLocalDB
	°Conection String: metadata=res://*/ModelATM.csdl|res://*/ModelATM.ssdl|res://*/ModelATM.msl;provider=System.Data.SqlClient;provider connection string="data source=(localdb)\MSSQLLocalDB;initial catalog=ATMdb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
	°Los diagrama de entidad relación, se encuentran en el repositorio en una carpeta llamada DER