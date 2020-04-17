--13.1	Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год. В результатах не может быть
--несколько заказов одного продавца, должен быть только один и самый крупный. В результатах запроса должны быть выведены следующие колонки:
--колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), номер заказа и его стоимость. В запросе надо учитывать 
--Discount при продаже товаров. Процедуре передается год, за который надо сделать отчет, и количество возвращаемых записей. Результаты запроса
--должны быть упорядочены по убыванию суммы заказа. 

GO
CREATE OR ALTER PROC GreatestOrders(@Year int, @Count int)
AS
BEGIN 
	SELECT DISTINCT TOP (@Count) empl.EmployeeID, empl.FirstName, empl.LastName, ord.OrderID, 'Max price'=MAX((UnitPrice-UnitPrice*Discount)*Quantity)
	FROM Employees empl
	JOIN Orders ord ON empl.EmployeeID=ord.EmployeeID
	JOIN [Order Details] ordDet ON ord.OrderID=ordDet.OrderID
	WHERE @Year=YEAR(ord.OrderDate)
	GROUP BY empl.EmployeeID, empl.FirstName, empl.LastName, ord.OrderID
	ORDER BY 'Max price' DESC
END

--проверочная процедура
GO
CREATE OR ALTER PROC GreatestOrdersCheck(@Year int, @Employee_F nvarchar(20), @Employee_L nvarchar(20))
AS
BEGIN 
	--SELECT @Employee_F
	SELECT empl.FirstName, empl.LastName, ord.OrderID, 'Price'=(UnitPrice-UnitPrice*Discount)*Quantity
	FROM Employees empl
	LEFT JOIN Orders ord ON empl.EmployeeID=ord.EmployeeID
	LEFT JOIN [Order Details] ordDet ON ord.OrderID=ordDet.OrderID
	WHERE @Year=YEAR(ord.OrderDate) AND empl.FirstName=@Employee_F AND empl.LastName=@Employee_L
	GROUP BY empl.FirstName, empl.LastName, ord.OrderID, UnitPrice, Discount, Quantity
	ORDER BY 'Price' DESC
END


