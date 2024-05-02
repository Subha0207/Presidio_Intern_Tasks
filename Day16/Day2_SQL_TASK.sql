use pubs
--1) Print all the titles names
SELECT title FROM titles;

--2) Print all the titles that have been published by 1389
select * from titles where pub_id=1389

--3) Print the books that have price in rangeof 10 to 15
select title,price from titles where price<15.00 AND price>10.00

--4) Print those books that have no price
SELECT title,price FROM titles WHERE price IS NULL;

--5) Print the book names that strat with 'The'
SELECT title as "Book name starting with 'The' " FROM titles WHERE title LIKE 'The%';

--6) Print the book names that do not have 'v' in their name
 SELECT title as "Book names that do not have 'v' in their name " FROM titles WHERE title NOT LIKE '%v%';

--7) print the books sorted by the royalty
SELECT title, royalty 
FROM titles 
ORDER BY royalty;
--8) print the books sorted by publisher in descending then by types in asending then by price in descending
SELECT pub_id, price, type 
FROM titles 
ORDER BY price DESC;

--9) Print the average price of books in every type
 SELECT TYPE, AVG(price) as "Average Price"
FROM TITLES 
GROUP BY TYPE;

--10) print all the types in uniques
SELECT DISTINCT TYPE, TITLE
FROM TITLES;
 
--11) Print the first 2 costliest books
SELECT TOP 2 title, price 
FROM titles 
ORDER BY price DESC;


--12) Print books that are of type business and have price less than 20 which also have advance greater than 7000
SELECT title, type 
FROM titles 
WHERE type = 'business' AND price < 20.00 AND advance > 7000;

--13) Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. Also sort the result in ascending order of count
SELECT pub_id, COUNT(*) AS books
FROM titles
WHERE price > 15 AND price < 25 AND title LIKE '%It%'
GROUP BY pub_id
HAVING COUNT(*) > 2
ORDER BY books ASC;

--14) Print the Authors who are from 'CA'
 select au_lname as "Author LastName" ,au_fname as "Author FirstName"  from authors where state='CA'

--15) Print the count of authors from every state
SELECT state, COUNT(*) as "Author Count"
FROM authors 
GROUP BY state;
