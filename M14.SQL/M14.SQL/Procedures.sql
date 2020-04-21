
--13.1	�������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� ������������ ���. � ����������� �� ����� ����
--��������� ������� ������ ��������, ������ ���� ������ ���� � ����� �������. � ����������� ������� ������ ���� �������� ��������� �������:
--������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), ����� ������ � ��� ���������. � ������� ���� ��������� 
--Discount ��� ������� �������. ��������� ���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������. ���������� �������
--������ ���� ����������� �� �������� ����� ������. 

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

--����������� ���������
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

--13.2	�������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � ���� (������� ����� OrderDate � ShippedDate).
--� ����������� ������ ���� ���������� ������, ���� ������� ��������� ���������� �������� ��� ��� �������������� ������. �������� �� ��������� ���
--������������� ����� 35 ����. �������� ��������� ShippedOrdersDiff. ��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate,
--ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������).  ���������� ������������������
--������������� ���� ���������.
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

