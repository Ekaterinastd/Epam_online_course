use Northwind
--1.1	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) ������������ � ������� ���������� � ShipVia >= 2.
-- ���� �� ������ ������ � NULL � ������� ShippedDate, ������ ��� � ����� ���������� �������� NULL ���������� false
select OrderID, ShippedDate, ShipVia from dbo.Orders where ShippedDate >= '6.05.1998' and ShipVia >= 2
--1.2	�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders. � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped� � ������������ ��������� ������� CAS�.
select 'ShippedDate' = case when ShippedDate is NULL then 'Not shipped' end, OrderID from dbo.Orders where ShippedDate is NULL
--1.3	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) �� ������� ��� ���� ��� ������� ��� �� ����������.
select 'Shipped Date' = case when ShippedDate is NULL then 'Not shipped' end, 'Order Number'=OrderID from dbo.Orders where ShippedDate>'06.05.1998' or ShippedDate is NULL

--2.1	������� �� ������� Customers ���� ����������, ����������� � USA � Canada. ������ ������� � ������ ������� ��������� IN. ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ���������� � �� ����� ����������.
select ContactName, Country from dbo.Customers where Country in ('USA', 'Canada') order by ContactName, Address
--2.2	������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. ������ ������� � ������� ��������� IN. ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ����������.
select ContactName, Country from dbo.Customers where Country not in ('USA', 'Canada') order by ContactName
--2.3	������� �� ������� Customers ��� ������, � ������� ��������� ���������. ������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. �� ������������ ����������� GROUP BY. ����������� ������ ���� ������� � ����������� �������. 
select distinct Country from dbo.Customers order by Country desc

--3.1	������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), ��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � ������� Order Details. ������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID.
select distinct OrderID from dbo.[Order Details] where Quantity between 3 and 10
--3.2	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g. ������������ �������� BETWEEN. ���������, ��� � ���������� ������� �������� Germany. ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
select CustomerID, Country from dbo.Customers where Country between 'B%' and 'G%' order by Country
--3.3	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g, �� ��������� �������� BETWEEN. 
select CustomerID, Country from dbo.Customers where Country like '[B-G]%' order by Country
--������ � between ����������������, �.�. �������� Estimated Row Size � Estimated Number of Rows � ���� ������.

--4.1	� ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 'chocolade'. ��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - ����� ��� ��������, ������� ������������� ����� �������. ���������: ���������� ������� ������ ����������� 2 ������.
select ProductName from dbo.Products where ProductName like '%cho_olade%'

--5.1	����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � ������ �� ���. ��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money.  ������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������. ��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � ������� UnitPrice ����. ����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'.
select 'Totals'=convert(nvarchar,cast(sum((UnitPrice-UnitPrice*Discount)*Quantity) as money),1) from [dbo].[Order Details]
--5.2	�� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � ������� ShippedDate ��� �������� ���� ��������). ������������ ��� ���� ������� ������ �������� COUNT. �� ������������ ����������� WHERE � GROUP
select  count(*) - count(ShippedDate) from [Orders]
--5.3	�� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������. ������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.
select count(distinct CustomerID) from [Orders]

--6.1	�� ������� Orders ����� ���������� ������� � ������������ �� �����. � ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total.
select 'Year'=year(OrderDate), 'Total'=count(OrderDate)  from [Orders] group by year(OrderDate) order by year(OrderDate)
-- �������� ����������� ������, ������� ��������� ���������� ���� �������.
select count(*) from [Orders]
--6.2	�� ������� Orders ����� ���������� �������, c�������� ������ ���������. ����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, ��� � ������� EmployeeID ������ �������� ��� ������� ��������. � ����������� ������� ���� ����������� ������� � ������ �������� (������ ������������� ��� ���������� ������������� LastName & FirstName. ��� ������ LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������. ����� �������� ������ ������ ������������ ����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� c ����������� ������� ����������� � ��������� 'Amount'. ���������� ������� ������ ���� ����������� �� �������� ���������� �������. 
select 'Seller'=(select concat(LastName,FirstName) from [Employees] where [Orders].EmployeeID=[Employees].EmployeeID),
	   'Amount'=count(EmployeeID) from [Orders] group by EmployeeID order by count(EmployeeID) desc;
--6.3	�� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������. ���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. � ����������� ������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�), ������� � ������ ���������� (�������� ������� �Customer�)  � ������� c ����������� ������� ����������� � ��������� 'Amount'. � ������� ���������� ������������ ����������� �������� ����� T-SQL ��� ������ � ���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������). ����������� ������ ���� ������� �� ID �������� � ����������. 
select 'Seller'=ISNULL((select concat(LastName,FirstName) from [Employees] where [Orders].EmployeeID=[Employees].EmployeeID),'ALL'),
	   'Customer'=ISNULL((select ContactName from [Customers] where [Customers].CustomerID=[Orders].CustomerID),'ALL'),
	   'Amount'=Count(*) from Orders WHERE YEAR(OrderDate)=1998 GROUP BY CUBE(EmployeeID,CustomerID) ORDER BY  'Amount' DESC, 'Seller', 'Customer';
--6.4	����� ����������� � ���������, ������� ����� � ����� ������. ���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� ��� ��������� �����������,
--		�� ���������� � ����� ���������� � ��������� �� ������ �������� � �������������� �����. �� ������������ ����������� JOIN. � ����������� ������� ���������� �������
--		��������� ��������� ��� ����������� �������: �Person�, �Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ��������� �� ���� ������), �City�. ������������� ���������� ������� �� ������� �City� � �� �Person�.
select 'Person'=Employees.LastName+' '+Employees.FirstName, 'Seller' AS Type, Employees.City from Employees, Customers where Employees.City=Customers.City UNION
select Customers.ContactName AS Person, 'Customer' AS Type, Customers.City from Employees, Customers where Employees.City=Customers.City order by 'City', 'Person'
--6.5	����� ���� �����������, ������� ����� � ����� ������. � ������� ������������ ���������� ������� Customers c ����� - ��������������. ��������� ������� CustomerID
--		� City. ������ �� ������ ����������� ����������� ������. ��� �������� �������� ������, ������� ����������� ������, ������� ����������� ����� ������ ���� � �������
--		Customers. ��� �������� ��������� ������������ �������.
SELECT  cust1.CustomerID, cust1.City from Customers cust1 JOIN
Customers cust2 ON cust1.City=cust2.City
