
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

--13.2	Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в днях (разница между OrderDate и ShippedDate).
--В результатах должны быть возвращены заказы, срок которых превышает переданное значение или еще недоставленные заказы. Значению по умолчанию для
--передаваемого срока 35 дней. Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие колонки: OrderID, OrderDate, ShippedDate,
--ShippedDelay (разность в днях между ShippedDate и OrderDate), SpecifiedDelay (переданное в процедуру значение).  Необходимо продемонстрировать
--использование этой процедуры.
GO
CREATE OR ALTER PROC ShippedOrdersDiff(@SpecifiedDelay int = 35)
AS
BEGIN
	SELECT ord.OrderID, ord.OrderDate, ord.ShippedDate, delays.ShippedDelay, 'SpecifiedDelay' = @SpecifiedDelay
	FROM Orders ord	
	LEFT JOIN (SELECT OrderID, 'ShippedDelay'=DAY(ShippedDate - OrderDate) FROM Orders) delays
	ON ord.OrderID=delays.OrderID
	WHERE [ShippedDelay]>@SpecifiedDelay OR ord.ShippedDate IS NULL
END

--13.3	 Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, так и подчиненных его подчиненных.
--В качестве входного параметра функции используется EmployeeID. Необходимо распечатать имена подчиненных и выровнять их в тексте (использовать оператор
--PRINT) согласно иерархии подчинения. Продавец, для которого надо найти подчиненных также должен быть высвечен. Название процедуры SubordinationInfo.
--В качестве алгоритма для решения этой задачи надо использовать пример, приведенный в Books Online и рекомендованный Microsoft для решения подобного типа
--задач. Продемонстрировать использование процедуры.
GO
CREATE OR ALTER PROC SubordinationInfo(@EmployeeID int)
AS
BEGIN
	SELECT @EmployeeID AS 'Head', subord.EmployeeID AS 'Subordinate', subord2.EmployeeID AS 'Subordinate2' FROM Employees empl
	JOIN (SELECT EmployeeID FROM Employees WHERE EmployeeID=@EmployeeID) head --выбираем сотрудника, подчинённых которого надо вывести
	ON empl.EmployeeID=head.EmployeeID
	JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord --подчинённые
	ON head.EmployeeID=subord.ReportsTo
	LEFT JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord2 --подчинённые подчинённых
	ON subord.EmployeeID=subord2.ReportsTo
END;

--GO
--CREATE OR ALTER PROC SubordinationInfo1(@EmployeeID int)
--WITH RECURSIVE 
--Rec(head, subordinate, subordinate2)
--AS (
--	SELECT @EmployeeID AS 'Head', subord.EmployeeID AS 'Subordinate', subord2.EmployeeID AS 'Subordinate2' FROM Employees empl
--	JOIN (SELECT EmployeeID FROM Employees WHERE EmployeeID=@EmployeeID) head --выыбираем сотрудника, подчинённых которого надо вывести
--	ON empl.EmployeeID=head.EmployeeID
--	JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord --подчинённые
--	ON head.EmployeeID=subord.ReportsTo
--	LEFT JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord2 --подчинённые подчинённых
--	ON subord.EmployeeID=subord2.ReportsTo
--	UNION ALL
--	SELECT Rec.
--	)
--	WHERE 
--END

--Написать функцию, которая определяет, есть ли у продавца подчиненные. Возвращает тип данных BIT. В качестве входного параметра функции используется EmployeeID.
--Название функции IsBoss. Продемонстрировать использование функции для всех продавцов из таблицы Employees.
GO
CREATE OR ALTER FUNCTION IsBoss(@EmployeeID int)
RETURNS BIT 
AS
BEGIN
	IF EXISTS (
				SELECT EmployeeID FROM Employees
				WHERE @EmployeeID=ReportsTo
			  )
			  RETURN 1
	RETURN 0
END
