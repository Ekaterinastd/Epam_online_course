
--13.1	Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год. В результатах не может быть
--несколько заказов одного продавца, должен быть только один и самый крупный. В результатах запроса должны быть выведены следующие колонки:
--колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), номер заказа и его стоимость. В запросе надо учитывать 
--Discount при продаже товаров. Процедуре передается год, за который надо сделать отчет, и количество возвращаемых записей. Результаты запроса
--должны быть упорядочены по убыванию суммы заказа. 

GO
CREATE OR ALTER PROC GreatestOrders(@Year int, @Count int)
AS
BEGIN 
	SELECT TOP(@Count) maxes.EmployeeID, empl.FirstName, empl.LastName, sums2.OrderID, maxes.[Max price]
	FROM 
		(SELECT ord.EmployeeID, MAX(sums.Sum) AS 'Max price' FROM Orders ord
		JOIN 
			(SELECT OrderID, 'Sum' = SUM((UnitPrice-UnitPrice*Discount)*Quantity)
			FROM [Order Details]
			GROUP BY OrderID) sums
		ON ord.OrderID=sums.OrderID
		WHERE YEAR(ord.OrderDate)=@Year
		GROUP BY ord.EmployeeID) maxes
	JOIN
		(SELECT OrderID, 'Sum' = SUM((UnitPrice-UnitPrice*Discount)*Quantity)
		FROM [Order Details]
		GROUP BY OrderID) sums2
	ON maxes.[Max price]=sums2.Sum
	JOIN Employees empl ON maxes.EmployeeID=empl.EmployeeID
	ORDER BY maxes.[Max price] DESC
END

--проверочная процедура
GO
CREATE OR ALTER PROC GreatestOrdersCheck(@Year int, @Employee_F nvarchar(20), @Employee_L nvarchar(20))
AS
BEGIN 
	SELECT empl.EmployeeID, empl.FirstName, empl.LastName, sums.OrderID, sums.Sum FROM Employees empl
	JOIN Orders ord ON empl.EmployeeID=ord.EmployeeID
	JOIN (SELECT ordDet.OrderID, 'Sum' = SUM((UnitPrice-UnitPrice*Discount)*Quantity)
	FROM [Order Details] ordDet
	GROUP BY OrderID) sums
	ON ord.OrderID=sums.OrderID
	WHERE @Year=YEAR(ord.OrderDate) AND empl.FirstName=@Employee_F AND empl.LastName=@Employee_L
	ORDER BY sums.Sum DESC
END
