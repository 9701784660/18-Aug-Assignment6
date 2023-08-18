create database ProductInventoryDB
use ProductInventoryDB
 create table Products
 (ProductId int primary key,
 ProductName nvarchar(50),
 Price decimal,
 Quantity int,
 MfDate date,
 ExpDate date )

 insert into Products values (1,'Face Cream',800,2,'1/8/2018','1/8/2022')
 insert into Products values (5,'Soap      ',50,6,'12/9/2021','12/9/2022')
 insert into Products values (7,'BodySpray',950,1,'11/6/2022','11/8/2023') 
 insert into Products values (8,'Washing Powder',800,2,'11/8/2019','11/8/2022')
 insert into Products values (9,'Hair Color',50,6,'12/7/2021','12/9/2022')
 insert into Products values (2,'Shaving Cream',950,1,'11/5/2022','11/7/2023') 
 
 select * from Products