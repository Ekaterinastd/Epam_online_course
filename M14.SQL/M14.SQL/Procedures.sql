
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

--13.3	 �������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, ��� � ����������� ��� �����������.
--� �������� �������� ��������� ������� ������������ EmployeeID. ���������� ����������� ����� ����������� � ��������� �� � ������ (������������ ��������
--PRINT) �������� �������� ����������. ��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������. �������� ��������� SubordinationInfo.
--� �������� ��������� ��� ������� ���� ������ ���� ������������ ������, ����������� � Books Online � ��������������� Microsoft ��� ������� ��������� ����
--�����. ������������������ ������������� ���������.
GO
CREATE OR ALTER PROC SubordinationInfo(@EmployeeID int)
AS
BEGIN
	SELECT @EmployeeID AS 'Head', subord.EmployeeID AS 'Subordinate', subord2.EmployeeID AS 'Subordinate2' FROM Employees empl
	JOIN (SELECT EmployeeID FROM Employees WHERE EmployeeID=@EmployeeID) head --�������� ����������, ���������� �������� ���� �������
	ON empl.EmployeeID=head.EmployeeID
	JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord --����������
	ON head.EmployeeID=subord.ReportsTo
	LEFT JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord2 --���������� ����������
	ON subord.EmployeeID=subord2.ReportsTo
END;

--GO
--CREATE OR ALTER PROC SubordinationInfo1(@EmployeeID int)
--WITH RECURSIVE 
--Rec(head, subordinate, subordinate2)
--AS (
--	SELECT @EmployeeID AS 'Head', subord.EmployeeID AS 'Subordinate', subord2.EmployeeID AS 'Subordinate2' FROM Employees empl
--	JOIN (SELECT EmployeeID FROM Employees WHERE EmployeeID=@EmployeeID) head --��������� ����������, ���������� �������� ���� �������
--	ON empl.EmployeeID=head.EmployeeID
--	JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord --����������
--	ON head.EmployeeID=subord.ReportsTo
--	LEFT JOIN (SELECT EmployeeID, ReportsTo FROM Employees) subord2 --���������� ����������
--	ON subord.EmployeeID=subord2.ReportsTo
--	UNION ALL
--	SELECT Rec.
--	)
--	WHERE 
--END

--�������� �������, ������� ����������, ���� �� � �������� �����������. ���������� ��� ������ BIT. � �������� �������� ��������� ������� ������������ EmployeeID.
--�������� ������� IsBoss. ������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.
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
