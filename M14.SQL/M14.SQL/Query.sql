use Northwind
--1.1	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2.
-- Сюда не попали заказы с NULL в колонке ShippedDate, потому что в любых логических условиях NULL возвращает false
select OrderID, ShippedDate, ShipVia from dbo.Orders where ShippedDate >= '6.05.1998' and ShipVia >= 2
--1.2	Написать запрос, который выводит только недоставленные заказы из таблицы Orders. В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ – использовать системную функцию CASЕ.
select 'ShippedDate' = case when ShippedDate is NULL then 'Not shipped' end, OrderID from dbo.Orders where ShippedDate is NULL
--1.3	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) не включая эту дату или которые еще не доставлены.
select 'Shipped Date' = case when ShippedDate is NULL then 'Not shipped' end, 'Order Number'=OrderID from dbo.Orders where ShippedDate>'06.05.1998' or ShippedDate is NULL

--2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем пользователя и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков и по месту проживания.
select ContactName, Country from dbo.Customers where Country in ('USA', 'Canada') order by ContactName, Address
--2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков.
select ContactName, Country from dbo.Customers where Country not in ('USA', 'Canada') order by ContactName
--2.3	Выбрать из таблицы Customers все страны, в которых проживают заказчики. Страна должна быть упомянута только один раз и список отсортирован по убыванию. Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса. 
select distinct Country from dbo.Customers order by Country desc

--3.1	Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице Order Details. Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.
select distinct OrderID from dbo.[Order Details] where Quantity between 3 and 10
--3.2	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g. Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает Germany. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
select CustomerID, Country from dbo.Customers where Country between 'B%' and 'G%' order by Country
--3.3	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g, не используя оператор BETWEEN. 
select CustomerID, Country from dbo.Customers where Country like '[B-G]%' order by Country
--запрос с between предпочтительнее, т.к. значения Estimated Row Size и Estimated Number of Rows у него меньше.

--4.1	В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все продукты, которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки.
select ProductName from dbo.Products where ProductName like '%cho_olade%'

--5.1	Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и скидок по ним. Результат округлить до сотых и высветить в стиле 1 для типа данных money.  Скидка (колонка Discount) составляет процент из стоимости для данного товара. Для определения действительной цены на проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены. Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.
select 'Totals'=convert(nvarchar,cast(sum((UnitPrice-UnitPrice*Discount)*Quantity) as money),1) from [dbo].[Order Details]
--5.2	По таблице Orders найти количество заказов, которые еще не были доставлены (т.е. в колонке ShippedDate нет значения даты доставки). Использовать при этом запросе только оператор COUNT. Не использовать предложения WHERE и GROUP
select  count(*) - count(ShippedDate) from [Orders]
--5.3	По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
select count(distinct CustomerID) from [Orders]

--6.1	По таблице Orders найти количество заказов с группировкой по годам. В результатах запроса надо высвечивать две колонки c названиями Year и Total.
select 'Year'=year(OrderDate), 'Total'=count(OrderDate)  from [Orders] group by year(OrderDate) order by year(OrderDate)
-- Написать проверочный запрос, который вычисляет количество всех заказов.
select count(*) from [Orders]
--6.2	По таблице Orders найти количество заказов, cделанных каждым продавцом. Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке EmployeeID задано значение для данного продавца. В результатах запроса надо высвечивать колонку с именем продавца (Должно высвечиваться имя полученное конкатенацией LastName & FirstName. Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'. Результаты запроса должны быть упорядочены по убыванию количества заказов. 
select 'Seller'=(select concat(LastName,FirstName) from [Employees] where [Orders].EmployeeID=[Employees].EmployeeID),
	   'Amount'=count(EmployeeID) from [Orders] group by EmployeeID order by count(EmployeeID) desc;
--6.3	По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. Необходимо определить это только для заказов сделанных в 1998 году. В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), колонку с именем покупателя (название колонки ‘Customer’)  и колонку c количеством заказов высвечивать с названием 'Amount'. В запросе необходимо использовать специальный оператор языка T-SQL для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса). Группировки должны быть сделаны по ID продавца и покупателя. 
select 'Seller'=ISNULL((select concat(LastName,FirstName) from [Employees] where [Orders].EmployeeID=[Employees].EmployeeID),'ALL'),
	   'Customer'=ISNULL((select ContactName from [Customers] where [Customers].CustomerID=[Orders].CustomerID),'ALL'),
	   'Amount'=Count(*) from Orders WHERE YEAR(OrderDate)=1998 GROUP BY CUBE(EmployeeID,CustomerID) ORDER BY  'Amount' DESC, 'Seller', 'Customer';
--6.4	Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один или несколько продавцов или только один или несколько покупателей,
--		то информация о таких покупателя и продавцах не должна попадать в результирующий набор. Не использовать конструкцию JOIN. В результатах запроса необходимо вывести
--		следующие заголовки для результатов запроса: ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или  ‘Seller’ в завимости от типа записи), ‘City’. Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
select 'Person'=Employees.LastName+' '+Employees.FirstName, 'Seller' AS Type, Employees.City from Employees, Customers where Employees.City=Customers.City UNION
select Customers.ContactName AS Person, 'Customer' AS Type, Customers.City from Employees, Customers where Employees.City=Customers.City order by 'City', 'Person'
--6.5	Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение таблицы Customers c собой - самосоединение. Высветить колонки CustomerID
--		и City. Запрос не должен высвечивать дублируемые записи. Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза в таблице
--		Customers. Это позволит проверить правильность запроса.
SELECT  cust1.CustomerID, cust1.City from Customers cust1 JOIN
Customers cust2 ON cust1.City=cust2.City
--6.6	По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. Высветить колонки с именами
--'User Name' (LastName) и 'Boss'.В колонках должны быть высвечены имена из колонки LastName. Высвечены ли все продавцы в этом запросе?
SELECT e1.LastName AS 'User Name', e2.LastName AS 'Boss' FROM Employees e1 JOIN Employees e2 ON e1.ReportsTo=e2.EmployeeID
--Не высвечен продавец, руководитель которого равен NULL

--7.1	Определить продавцов, которые обслуживают регион 'Western' (таблица Region). Результаты запроса должны высвечивать два поля: 'LastName' продавца
--и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories). Запрос должен использовать JOIN в предложении FROM.
--Для определения связей между таблицами Employees и Territories надо использовать графические диаграммы для базы Northwind.
SELECT e1.LastName AS 'Seller', t.TerritoryDescription, r.RegionDescription FROM Employees e1 
JOIN EmployeeTerritories et ON e1.EmployeeID=et.EmployeeID
JOIN Territories t ON et.TerritoryID=t.TerritoryID
JOIN Region r ON t.RegionID=r.RegionID WHERE r.RegionDescription='Western'

--8.1	Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их заказов из таблицы Orders.
--Принять во внимание, что у некоторых заказчиков нет заказов, но они также должны быть выведены в результатах запроса. 
--Упорядочить результаты запроса по возрастанию количества заказов.
SELECT c.ContactName AS 'Customer', COUNT(o.OrderID) AS 'Count' FROM Customers c
LEFT JOIN Orders o ON c.CustomerID=o.CustomerID
GROUP BY c.ContactName 
ORDER BY 'Count'

--9.1	Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы одного продукта на складе
--(UnitsInStock в таблице Products равно 0). Использовать вложенный SELECT для этого запроса с использованием оператора IN.
--Можно ли использовать вместо оператора IN оператор '=' ?
--SELECT CompanyName AS 'Suppler', UnitsInStock FROM Suppliers, Products WHERE Suppliers.SupplierID=Products.SupplierID AND UnitsInStock=0 --работает
SELECT CompanyName AS 'Suppler' FROM Suppliers INNER JOIN
Products ON Products.SupplierID=Suppliers.SupplierID WHERE Products.SupplierID IN(SELECT Suppliers.SupplierID FROM Suppliers WHERE UnitsInStock IN(0))
--Вместо оператора IN нельзя использовать оператор '=' при создании вложенного запроса, потому что оператор сравнения может обрабатывать только одну записть, а IN - множество

--10.1	Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.
SELECT LastName FROM Employees WHERE EmployeeID IN(SELECT EmployeeID FROM Orders GROUP BY EmployeeID HAVING COUNT(OrderID)>150)

--11.1	Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа (подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS.
SELECT ContactName FROM Customers WHERE NOT EXISTS(SELECT CustomerID FROM Orders WHERE Customers.CustomerID=Orders.CustomerID)

--12.1	Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита, с которых начинаются фамилии
SELECT DISTINCT LEFT(LastName,1) AS 'First Letter' FROM Employees ORDER BY 'First Letter'

--Procedures
--13.1 
EXEC GreatestOrders @Year=1997, @Count=100;

--проверочная процедура
EXEC GreatestOrdersCheck 1997, 'Margaret', 'Peacock';

--13.2
EXEC ShippedOrdersDiff @SpecifiedDelay = 10;
EXEC ShippedOrdersDiff;