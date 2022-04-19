/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) o.[OrderId]
      ,o.[CustomerId]
	  ,od.OrderDetailId
	  ,od.ProductId
      ,[OrderDate]
	  ,c.FirstName	
	  ,p.[Name] ProductName
	  
	  --,p.Name
  FROM [StoreDB].[dbo].[Orders] o
  left join customers c
	on o.CustomerId = c.CustomerId
  left join OrderDetails od
	on od.OrderId = o.OrderId
	
  left join products p
	on od.ProductId = p.ProductId
  

  SELECT *
  FROm Customers
  where CustomerId = 'FF49A222-A993-4ABE-A595-765D99D5A882'