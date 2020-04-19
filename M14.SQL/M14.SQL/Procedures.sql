--13.1	�������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� ������������ ���. � ����������� �� ����� ����
--��������� ������� ������ ��������, ������ ���� ������ ���� � ����� �������. � ����������� ������� ������ ���� �������� ��������� �������:
--������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), ����� ������ � ��� ���������. � ������� ���� ��������� 
--Discount ��� ������� �������. ��������� ���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������. ���������� �������
--������ ���� ����������� �� �������� ����� ������. 

--GO
--CREATE OR ALTER PROC GreatestOrders(@Year int, @Count int)
--AS
--BEGIN 
--	SELECT DISTINCT TOP (@Count) empl.EmployeeID, empl.FirstName, empl.LastName, ord.OrderID, 'Max price'=MAX((UnitPrice-UnitPrice*Discount)*Quantity)
--	FROM Employees empl
--	JOIN Orders ord ON empl.EmployeeID=ord.EmployeeID
--	JOIN [Order Details] ordDet ON ord.OrderID=ordDet.OrderID
--	WHERE @Year=YEAR(ord.OrderDate)
--	GROUP BY empl.EmployeeID, empl.FirstName, empl.LastName, ord.OrderID
--	ORDER BY 'Max price' DESC
--END

GO
CREATE OR ALTER PROC GreatestOrders(@Year int, @Count int)
AS
BEGIN 
SELECT ord.EmployeeID, ord.OrderID, 'Max price' = (UnitPrice-UnitPrice*Discount)*Quantity
	FROM Orders ord
	JOIN [Order Details] ordDet ON ord.OrderID=ordDet.OrderID
	WHERE @Year=YEAR(ord.OrderDate) AND 'Max price'=
	(SELECT MAX((UnitPrice-UnitPrice*Discount)*Quantity)
	FROM Orders ord1
	JOIN [Order Details] ordDet1 ON ord1.OrderID=ordDet1.OrderID
	WHERE @Year=YEAR(ord1.OrderDate) AND ord.EmployeeID = ord1.EmployeeID)
	ORDER BY 'Max price' DESC
END


--����������� ���������
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


