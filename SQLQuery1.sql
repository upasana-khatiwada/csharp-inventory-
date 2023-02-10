Create database admin;
Use admin
go
create table employees1(
name nvarchar (255) not null,
phone_number nvarchar (15)not null primary key ,

password nvarchar(255) not null,

);
Select * from employees1
insert into employees1 (name,phone_number, password) 
values ('upasana','9843816723','nepal'),
('sova','9857687574','hello'),
('rinjha','9855647809','hi');

create table productlist(
item_name nvarchar (255) not null,
item_id nvarchar (15)not null primary key ,

category nvarchar(255) not null,
quantity nvarchar(255) not null,

);

Select * from productlist
DELETE FROM productlist where 1=1;
insert into productlist (item_name,item_id, quantity,category) 
values ('upasana','9843816723','100','2');
