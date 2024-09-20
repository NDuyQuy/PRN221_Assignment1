use Store
go

create table [Member](
 MemberId int primary key identity(1,1),
 Email varchar(100) not null,
 CompanyName varchar(40) not null,
 City varchar(15) not null,
 Country varchar(15) not null,
 Password varchar(30) not null
);

create table [Order](
	OrderId int primary key identity(1,1)
	,MemberId int foreign key references Member(MemberId) not null
	,OrderDate datetime not null
	,RequiredDate datetime
	,ShippedDate datetime 
	,Freight money 
);

create table [Product](
 ProductId int primary key identity(1,1)
 ,CategoryId int foreign key references [Categories](CategoryId)
 ,ProductName varchar(40) not null
 ,Weight varchar(20) not null
 ,UnitPrice varchar(20) not null
 ,UnitsInStock int not null
);

create table [OrderDetail]
(
 OrderId int foreign key references [Order]([OrderId])
 ,ProductId int foreign key references [Product]([ProductId])
 ,UnitPrice money not null
 ,Quantity int not null 
 ,Discount float not null
);

