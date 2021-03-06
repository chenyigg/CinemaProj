/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [MovieID]
      ,[MovieName]
      ,[MovieCover]
      ,[MovieBrief]
      ,[MovieMoney]
      ,[MovieReleaseDate]
      ,[MovieDuration]
      ,[MovieDirect]
      ,[MovieType]
      ,[MovieArea]
      ,[MovieYears]
      ,[MovieScore]
  FROM [Cinema].[dbo].[MovieInfo]

  --, count(*)as 票数

  Select [OrderID] from [dbo].[OrderInfo] where [MovieName]='勇敢者游戏2：再战巅峰'

  Select distinct [OrderID] from [dbo].[OrderInfo] where [OrderTime]>(select convert(varchar(10), getdate(), 120)+' 00:00:00')

  Select distinct  MovieName,[OrderSumMoney]  from [dbo].[OrderInfo] where [OrderID] in
  (
   Select top 5 [OrderID], count(*)as 票数 from [dbo].[OrderDetails] where [OrderID] in 
	(
	 Select distinct [OrderID] from [dbo].[OrderInfo] where [OrderTime]>
		(
		select convert(varchar(10), getdate(), 120)+' 00:00:00'
		)
	 ) 
  group by [OrderID] order by  Count(*) desc
  )
   order by [OrderSumMoney] desc




--返回Top10票房最高的电影信息
select * from [dbo].[MovieInfo] where [MovieName] in (

 Select top 10 [MovieName] from [dbo].[OrderInfo] where [MovieName] in 
 (Select [MovieName] from [dbo].[MovieInfo]) 
 and 
 [OrderID] in 
	(
	--首先查询出属于今天的订单
	 Select distinct [OrderID] from [dbo].[OrderInfo] where [OrderTime]>
		(
		select convert(varchar(10), getdate(), 120)+' 00:00:00'
		)
	 ) 

 group by  [MovieName] order by Sum([OrderSumMoney]) desc)


 --返回Top10票房总价格


 Select top 10 [MovieName],Sum([OrderSumMoney]) as SumMoney from [dbo].[OrderInfo] where [MovieName] in 
 (Select [MovieName] from [dbo].[MovieInfo]) 
 and 
 [OrderID] in 
	(
	 Select distinct [OrderID] from [dbo].[OrderInfo] where [OrderTime]>
		(
		select convert(varchar(10), getdate(), 120)+' 00:00:00'
		)
	 ) 

 group by  [MovieName] order by Sum([OrderSumMoney]) desc


 
 --多表查询今日票房
 select top 10 m.MovieID,m.MovieName,m.MovieCover,Sum(o.OrderSumMoney) SumMoney
 from OrderInfo o ,MovieInfo m
 where o.MovieName=m.MovieName
 and o.OrderTime>(select convert(varchar(10), getdate(), 120)+' 00:00:00')
 group by m.MovieID,m.MovieName,m.MovieCover 
 order by Sum(OrderSumMoney) desc

exec sp_executesql N'SELECT TOP (10) 
    [Project1].[MovieID] AS [MovieID], 
    [Project1].[MovieName] AS [MovieName], 
    [Project1].[MovieCover] AS [MovieCover], 
    [Project1].[C1] AS [C1]
    FROM ( SELECT 
        [GroupBy1].[A1] AS [C1], 
        [GroupBy1].[K1] AS [MovieID], 
        [GroupBy1].[K2] AS [MovieName], 
        [GroupBy1].[K3] AS [MovieCover]
        FROM ( SELECT 
            [Extent1].[MovieID] AS [K1], 
            [Extent1].[MovieName] AS [K2], 
            [Extent1].[MovieCover] AS [K3], 
            SUM([Extent2].[OrderSumMoney]) AS [A1]
            FROM  [dbo].[MovieInfo] AS [Extent1]
            INNER JOIN [dbo].[OrderInfo] AS [Extent2] ON [Extent1].[MovieName] = [Extent2].[MovieName]
            WHERE [Extent2].[OrderTime] > @p__linq__0
            GROUP BY [Extent1].[MovieID], [Extent1].[MovieName], [Extent1].[MovieCover]
        )  AS [GroupBy1]
    )  AS [Project1]
    ORDER BY [Project1].[C1] DESC',N'@p__linq__0 datetime2(7)',@p__linq__0='2020-01-23 00:00:00'