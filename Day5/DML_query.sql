insert into Areas(area,zipcode) values('BBB','12345');
insert into Areas(area,zipcode) values('ABC','12345');
insert into Areas values('CCC','54321');
select * from Areas;
 
insert into Skills values('C','PLT');
insert into Skills values('C++','OOPS'),('Java','Web'),('SQL','RDBMS');
select *from Skills;

insert into Employees(name,age,area) values('Ramu',23,'ABC');
insert into Employees(name,age,area) values('Somu',34,'BBB');
--will not get inserted because of volating referential integrity
insert into Employees(name,age,area) values('Ramu',23,'HHH');
insert into Employees(name,age,area) values('Bhimu',23,'CCC');

select * from Employees;

insert into EmployeesSkills values(101,'C',7)
insert into EmployeesSkills values(101,'C++',7)
insert into EmployeesSkills values(101,'Java',6)
insert into EmployeesSkills values(102,'Java',7)
insert into EmployeesSkills values(102,'SQL',8)
select * from EmployeesSkills

update EmployeesSkills set skill_level=8 where employee_id=101 and skill_name='c';

--update the age of employee bhimu to 29--

update Employees set age =29 where name='Bhimu';

update Employees set name='Komu' where employee_id=102;

update Employees set age=20,area='CCC' where employee_id=101;

--delete
delete from Skills where skill_description='c';
--delete from child to delte in parent
delete from EmployeesSkills where skill_name='c';

delete from Skills where skill_description='c';