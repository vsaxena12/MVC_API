create database MVC_Entity_Framework

use MVC_Entity_Framework

Create table Employee
(
	[ID] int primary key,
	[Name] varchar(255),
	[Designation] varchar(255),
	[Department_ID] int
);

insert into Employee values(1,'Mihir','SE',1001);

select * from Employee;

create table Department
(
	[ID] int primary key,
	[Name] varchar(255)
); 

select * from Department; 
insert into Department values(1001, 'IT');

ALTER TABLE Employee
ADD FOREIGN KEY ([Department_ID]) REFERENCES Department(ID);

select * from Employee
inner join Department
on Employee.[Department_ID] = Department.ID


drop table Employee;
drop table Department;


Create table Employee
(
	[ID] int primary key identity(1,1),
	[First Name] varchar(255),
	[Last Name] varchar(255),
	[Designation] varchar(255),
	[Password] password(255)
	[Confirm Password] 
);