use pubs
select * from titles;
--1) Print the storeid and number of orders for the store
select stor_id ,count (*)ord_num from sales group by stor_id 

--2) print the number of orders for every title
select title_id,count(*)ord_num from sales group by title_id

--3) print the publisher name and book name
SELECT publishers.pub_name as "PUBLISHER NAME", titles.title as "BOOK NAME"
FROM publishers
JOIN titles
ON publishers.pub_id = titles.pub_id;

--4) Print the author full name for all the authors
SELECT au_fname + ' ' + au_lname AS 'Full Name'
FROM authors;

--5) Print the price or every book with tax (price+price*12.36/100)
select title as "Book name" ,(price+price*12.36/100) as "Price with tax" from titles

--6) Print the author name, title name
SELECT authors.au_fname + ' ' + authors.au_lname AS 'Author Name', titles.title AS 'Title Name'
FROM authors
JOIN titleauthor
ON authors.au_id = titleauthor.au_id
JOIN titles
ON titleauthor.title_id = titles.title_id;

--7) print the author name, title name and the publisher name
SELECT 
    authors.au_fname, 
    authors.au_lname, 
    titles.title, 
    publishers.pub_name
FROM 
    authors
JOIN 
    titleauthor ON authors.au_id = titleauthor.au_id
JOIN 
    titles ON titleauthor.title_id = titles.title_id
JOIN 
    publishers ON titles.pub_id = publishers.pub_id;

--8) Print the average price of books pulished by every publicher
select publishers.pub_name,avg(titles.price ) as "AVERAGE PRICE"
from titles 
join publishers on titles.pub_id =publishers.pub_id group by publishers.pub_name
--9) print the books published by 'Marjorie'
SELECT 
    titles.title 
FROM 
    titles 
JOIN 
    titleauthor ON titles.title_id = titleauthor.title_id
JOIN 
    authors ON authors.au_id = titleauthor.au_id 
WHERE 
    authors.au_fname = 'Marjorie';

--10) Print the order numbers of books published by 'New Moon Books'

SELECT 
    sales.ord_num as "Order no of Books published by new moon books"
FROM 
    sales
JOIN 
    titles ON sales.title_id = titles.title_id  
JOIN 
    publishers ON publishers.pub_id = titles.pub_id
WHERE 
    publishers.pub_name = 'New Moon Books';

--11) Print the number of orders for every publisher
SELECT publishers.pub_id, COUNT(sales.ord_num) as "No of orders"
FROM sales
JOIN titles ON titles.title_id = sales.title_id
JOIN publishers ON publishers.pub_id = titles.pub_id
GROUP BY publishers.pub_id;


--12) print the order number , book name, quantity, price and the total price for all orders
select sales.ord_num,titles.title,sales.qty ,titles.price,sales.qty*titles.price as "TOTAL PRICE"
from titles
join sales on titles.title_id=sales.title_id

--13) print he total order quantity fro every book
select titles.title_id,SUM(sales.qty )as "ORDER QUANTITY"
from sales
join titles on titles.title_id=sales.title_id group by titles.title_id;

--14) print the total ordervalue for every book
select titles.title,sales.qty*titles.price as "TOTAL PRICE"
from titles
join sales on titles.title_id=sales.title_id

--15) print the orders that are for the books published by the publisher for which 'Paolo' works 
select sales.ord_num as "orders"
from sales 
join titles on sales.title_id=titles.title_id
join publishers on publishers.pub_id=titles.pub_id
join employee on employee.pub_id=publishers.pub_id
where employee.fname='Paolo'

