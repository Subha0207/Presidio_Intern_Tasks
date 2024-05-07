
use pubs
select * from stores
select * from sales
select * from authors
select * from publishers
select * from titles 
select * from employee
select * from jobs

--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

CREATE PROC proc_PrintBookWithAuthorName1(@author_name varchar(20))
AS
BEGIN
   SELECT titles.title, publishers.pub_name 
   FROM titles 
   JOIN titleauthor ON titleauthor.title_id = titles.title_id
   JOIN authors ON titleauthor.au_id = authors.au_id
   JOIN publishers ON publishers.pub_id = titles.pub_id
   WHERE authors.au_fname = @author_name;
END
EXEC proc_PrintBookWithAuthorName 'Ann'

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
create proc proc_EmployeePerformance1(@emp_firstname varchar(20))
as
begin
select titles.title,titles.price,sales.qty,(sales.qty *titles.price) as "Total cost"
from titles 
join employee on employee.pub_id=titles.pub_id
join sales on sales.title_id=titles.title_id
where employee.fname=@emp_firstname;
end
EXEC proc_EmployeePerformance1 'Mary'


--3) Create a query that will print all names from authors and employees
create proc proc_PrintAuthorsAndEmployee1
as
begin
select (au_fname +' '+ au_lname) as 'Name of employee and author' 
from authors
union
select(fname+lname) AS 'Name of employee and author'from employee
end
EXEC proc_PrintAuthorsAndEmployee1
--4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,

SELECT TOP 5 
    titles.title,
    publishers.pub_name,
    authors.au_fname + ' ' + authors.au_lname AS "Author full name",
    sales.qty,
    titles.price,
    (sales.qty * titles.price) AS "Total cost"
FROM 
    titleauthor
JOIN 
    sales ON sales.title_id = titleauthor.title_id
JOIN 
    authors ON authors.au_id = titleauthor.au_id
JOIN 
    titles ON titles.title_id = sales.title_id
JOIN 
    publishers ON publishers.pub_id = titles.pub_id 
ORDER BY 
    "Total cost" 


--print first 5 orders after sorting them based on the price of order

