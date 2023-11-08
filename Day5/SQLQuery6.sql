CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    empname VARCHAR(255),
    salary DECIMAL(10, 2),
);
CREATE TABLE DEPARTMENT (
    deptname VARCHAR(255) PRIMARY KEY,
    floor INT,
    phone VARCHAR(20),
    empno INT NOT NULL,
    FOREIGN KEY (empno) REFERENCES EMP(empno)
);
CREATE TABLE SALES (
    salesno INT PRIMARY KEY,
    saleqty INT,
    itemname VARCHAR(255) NOT NULL,
    deptname VARCHAR(255) NOT NULL,
    FOREIGN KEY (itemname) REFERENCES ITEM(itemname),
    FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname)
);
CREATE TABLE ITEM (
    itemname VARCHAR(255) PRIMARY KEY,
    itemtype VARCHAR(255),
    itemcolor VARCHAR(255)
);
alter table emp add deptname VARCHAR(255),
    bossno INT,
    FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname),
    FOREIGN KEY (bossno) REFERENCES EMP(empno);
