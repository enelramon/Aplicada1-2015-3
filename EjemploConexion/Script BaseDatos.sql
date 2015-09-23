Create Database Aplicada1Db

go
use Aplicada1Db
go

Create Table Cuotas(Id int identity(1,1),NoCuota int,Capital money,Interes money)

Insert Into Cuotas(NoCuota,Capital,Interes) Values(1,1000,500)