create database aselco201file;

use aselco201file;

create table login(
id int not null auto_increment,
username varchar(20) not null,
password varchar(30) not null,
fname varchar(30) not null,
lname varchar(30) not null,
position varchar(30) not null,
department varchar(30) not null,
primary key (id)
);

select * from login where username="joni" and password="password";