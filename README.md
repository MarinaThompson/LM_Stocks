# LM_Stocks
Projeto de controle de estoque feito com C#/.NET e React </br>
</br>
<strong>Script da criação da tabela products:</strong>

CREATE DATABASE LM_Stocks; </br>

USE LM_Stocks; </br>

CREATE TABLE Products( </br>
    	ID int IDENTITY(1,1) PRIMARY KEY, </br>
   	Name varchar(15) NOT NULL, </br>
	Price numeric(5,2) NOT NULL, </br>
	Validity date NOT NULL, </br>
	Lot varchar(20) NOT NULL, </br>
	Weight decimal(5,2) NOT NULL, </br>
	Quantity int NOT NULL, </br>
	Description varchar (100) NOT NULL </br>
);
