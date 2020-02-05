  --在没有影片ID的时候，查询该电影院的所有排片电影
 Select * from MovieInfo where MovieName in (select MovieName from [dbo].[ChipInfo] where CinemaID=2 and datediff(MINUTE,getdate(),StartTime)>30)

 select * from [dbo].[OfficeInfo] where [OfficeID] in  
 (select OfficeID from [dbo].[ChipInfo] where CinemaID=2 and datediff(MINUTE,getdate(),StartTime)>30)



--在有影片ID的时候，查询该电影院属于该电影的排片
 select * from [dbo].[OfficeInfo] where [OfficeID] in  
 (select OfficeID from [dbo].[ChipInfo] where CinemaID=2
 and datediff(MINUTE,getdate(),StartTime)>30
 and MovieName='我和我的祖国'
 )


 --在有影片ID和影院ID的时候查询该电影信息
Select * from MovieInfo where MovieName in ( select MovieName from [dbo].[ChipInfo] where CinemaID=2)
