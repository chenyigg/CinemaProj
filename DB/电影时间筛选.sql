/****** SSMS 的 SelectTopNRows 命令的脚本  ******/
SELECT TOP (1000) [Msg]
  FROM [Cinema].[dbo].[UrlCountInnfo]

  select * from 表名 where to_days(时间字段名) = to_days(now());  
  
  select * from ChipInfo
  where StartTime>=Convert(DateTime, CONVERT(nvarchar,GETDATE(),23)+' 00:00:00' )
  AND StartTime<Convert(DateTime, CONVERT(nvarchar,GETDATE()+1,23)+' 23:59:59')

 select ch.StartTime,ch.StopTime,mi.MovieArea,ofi.OfficeID,ofi.OfficeName,ch.ChipInfoID,mi.MovieMoney as [Money]
  from ChipInfo ch ,MovieInfo mi ,OfficeInfo ofi 
  where ch.MovieName=mi.MovieName
  and ch.OfficeID = ofi.OfficeID
  and ch.CinemaID=1 and ch.MovieName='平原上的夏洛克'
  and ch.StartTime>=Convert(DateTime, CONVERT(nvarchar,GETDATE(),23)+' 00:00:00' )
  and datediff(MINUTE,getdate(),StartTime)>15
  AND ch.StartTime<Convert(DateTime, CONVERT(nvarchar,GETDATE(),23)+' 23:59:59')

  select ch.StartTime,ch.StopTime,mi.MovieArea,ofi.OfficeID,ofi.OfficeName,ch.ChipInfoID,mi.MovieMoney as [Money]
  from ChipInfo ch ,MovieInfo mi ,OfficeInfo ofi 
  where ch.MovieName=mi.MovieName
  and ch.OfficeID = ofi.OfficeID
  and ch.CinemaID=1 and ch.MovieName='平原上的夏洛克'
  and ch.StartTime>=Convert(DateTime, CONVERT(nvarchar,GETDATE(),23)+' 23:59:00' )
  AND ch.StartTime<Convert(DateTime, CONVERT(nvarchar,GETDATE()+1,23)+' 23:59:59')


