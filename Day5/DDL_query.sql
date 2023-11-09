create Database dbCompany26Oct2023;

use dbCompany26Oct2023;

create table Areas
(Area varchar(20) constraint pk_area primary key,
ZipCode char(5));

sp_help Areas;

alter table Areas
alter column ZipCode char(6) not null;

alter table Areas
add remarks varchar(100);

alter table Areas
drop column remarks;

drop table Areas;

create table Employees
(employee_id int constraint pk_emp_id primary key,
name varchar(50),
age int,
area varchar(20) constraint fk_area foreign key references Areas(Area));

sp_help Employees;

drop table Employees;

create table Employees
(employee_id int identity(100,1) constraint pk_emp_id primary key,
name varchar(50) not null,
age int default 18,
area varchar(20) constraint fk_area foreign key references Areas(Area));

create table Skills
(skill varchar(20) constraint pk_skill primary key,
skill_description varchar(50));

sp_help Skills;

create table EmployeesSkills
(employee_id int constraint fk_emp_id foreign key references employees(employee_id),
skill_name varchar(20) constraint fk_skill foreign key references Skills(skill),
skill_level float,
constraint pk_emp_skill primary key(employee_id,skill_name))

sp_help EmployeesSkills;