# Students-Mangement-System-With-EntityFramework
This project is developed by Entity Framework (Data Base First)

Including:
- It's created with N-Tire Layers (Multitier architecture PL BL ) to organize coding.
- Back up and Restore .
- Simple Report by crystal report to print invoce .
- Users Permeissions for forms.(User or Manager)
- using Setting of project .
- ERD .

* First Note :
When you downlod the project you will find Folder included (Database) you have to attach them
with SQL Server Management Studio so you can copy the database and paste on the path ("C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA") Then attach them ..

* Second Note :
 this project is developed from Ado.net "https://github.com/OmarRayes98/Students-Mangement-System-With-ADO.net/tree/master"
 To be more effective . 
 
 * Third Note :
    to download project with Client and you would not use SQL Server Management Studio to be installed with Client ....So you can : just Change String Connection from :
     <add name="Office_TutorialsEntities" connectionString="metadata=res://*/OfficeModel.csdl|res://*/OfficeModel.ssdl|res://*/OfficeModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=Office_Tutorials;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
      providerName="System.Data.EntityClient" />
      
      To :
      
      <add name="Office_TutorialsEntities" connectionString="metadata=res://*/OfficeModel.csdl|res://*/OfficeModel.ssdl|res://*/OfficeModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Office_tutorials.mdf;initial catalog=Office_Tutorials;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
      providerName="System.Data.EntityClient" />
      
      So you have to replace the answer of Data Source and add AttachDbFilename . And you have to put database in Debug folder .In addition ,  use LocalDB instead of SQL Management . 
 
 * Fourth Note : 
  you find random values in database (It's not empty ).

