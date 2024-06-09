use NorthWind
select * from Categories
select * from [Order Details]
select * from Customers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50
select * from products

--get the order id, productname and quantitysold of products that have price
--greater than 15

select OrderID,products.ProductName,[Order Details].Quantity
from [Order Details]
join Products on [Order Details].ProductID=products.ProductID
where products.UnitPrice>15


--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20


SELECT OrderID, p.productname, Quantity "Quantity Sold" FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE  c.CategoryName LIKE '%Dairy%';



select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc

--CTE

  with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

  select top 10 * from  OrderDetails_CTE order by price desc


  CREATE VIEW vwOrderDetails
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%');


select * from vwOrderDetails order by UnitPrice


--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA

--The order ID, Customer name and the product name for products that are ordered by people from france 
--with fright less than 20
with orderdetailsCTE (OrderID,CustomerName,ProductName)
as(
SELECT [Order Details].OrderID, Products.ProductName, Customers.ContactName
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID
JOIN Products ON [Order Details].ProductID = Products.ProductID
WHERE Customers.Country = 'USA'

union

SELECT [Order Details].OrderID, Products.ProductName, Customers.ContactName
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID
JOIN Products ON [Order Details].ProductID = Products.ProductID
WHERE Customers.Country = 'France' and Orders.Freight<20)
select top 10 * from OrderDetailsCTE;

--indexes(for fatser retrieval as we are focusing only on cloumn what we want rather than whole)
--you’re creating an index idxEmpEmail on the city column of the Employees table. 
--This index would speed up queries that match on the city column.
--For instance, the query SELECT * FROM Employees WHERE city LIKE 'r%' would benefit from this index, as it would only need to scan the index rather than the entire Employees table.
sp_help Employees

create index idxEmpCity on Employees(city)

select * from employees where city like 'r%'

drop index idxEmpCity on Employees

--Procedures
--A stored procedure is a prepared SQL code that you can save, 
--so the code can be reused over and over again.save it as a stored procedure, 
--and then just call it to execute it.
create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure

create proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Hello '+@cname
end

exec proc_GreetWithName 'Ramu'

--passing multiple parametersseperated by comma
create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

exec proc_AddEmployee 'Bimu','2000-09-07','HHHH','1122334455','bimu@gmail.com'

--altering existing procedure
create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

alter proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Welcome '+@cname
end

--concatinating different datatypes by casting 
Create proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+@cage +'years old, Your phone is '+@cphone
end
alter  proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+cast(@cage as varchar(3))+'years old, Your phone is '+@cphone
end

proc_PrintDetails 'Ramu',23,'8877665544'
