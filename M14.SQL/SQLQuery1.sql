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


