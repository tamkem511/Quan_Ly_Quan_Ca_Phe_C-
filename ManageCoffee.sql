
use master
go

create database ManageCoffee
go

use ManageCoffee
go

--Food
--Table
--FoodCategory
--Account
--Bill(Hoa Don)
--BillInfor(n BillInfor tu Bill)

Create table TableFood(
   ID int identity Primary key,
   NameTable nvarchar(100) not null,
   StatusTable nvarchar(100) not null default N'Trống' --Trong || Co Nguoi
)
go

create table Account(
  UserName nvarchar(100) primary key,
  DisplayName nvarchar(100) not null default N'Tên Hiển Thị',
  PassWord nvarchar(100) not null default 0,
  TypeAcc int not null default 0 -- 1 : Admin || 0 : Manage 
)
go

Create table FoodCategory(
   ID int identity primary key,
   NameFoodCategory nvarchar(100) not null default N'Chưa Đặt Tên'
)
go

create table Food(
  ID int identity primary key,
  NameFood nvarchar(100) not null default N'Chưa Đặt Tên',
  IDCategory int not null,
  Price float not null default 0,
  constraint fk_FoodCategory foreign key(IDCategory) references FoodCategory(ID) 
)
go

Create table Bill(
  ID int identity primary key,
  DateCheckIn Date not null default GetDate(),
  DateCheckOut Date,
  IDTable int not null,
  StatusBill int not null default 0 -- 1:Đã Thanh Toán || 2 : Chưa Thanh Toán
  constraint fk_tableFood foreign key(IDTable) references TableFood(ID)
)
go

create table BullInfo(
    ID int identity primary key,
	IDBill int not null,
	IDFood int not null,
	Number int not null default 0,
	Constraint fk_Bill foreign key(IDBill) references Bill(ID),
	Constraint fk_Food foreign key(IDFood) references Food(ID)
)
