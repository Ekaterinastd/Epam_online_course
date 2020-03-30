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


