create database DB_Consoles;
use DB_Consoles;

create table Company
(
	ID int auto_increment primary key,
    Company_Name varchar(50) not null,
    Founded date not null,
    Headquarters varchar (100)
);

create table Console
(
	ID int auto_increment primary key,
    Console_Name varchar(50) not null,
    Short_Name varchar(20) not null,
    Company int not null,
    constraint FK_Company_Console foreign key (Company) references Company(ID)
);

SET GLOBAL optimizer_switch = 'derived_merge=OFF';
SET optimizer_switch = 'derived_merge=OFF';