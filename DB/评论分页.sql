
if object_id('tempdb..#temp') is not null
begin
--删除临时表
DROP Table #temp
end
select * into #temp from (select top 5 * from [dbo].[CommentInfo] where [CommentID] not in (select top 5 [CommentID] from [dbo].[CommentInfo]  where MovieID=1 order by [CommentID] desc) and MovieID=1 order by [CommentID] desc ) num
select * from #temp order by [CommentID] desc

select Count(*) from [dbo].[CommentInfo] where [MovieID] = 1 

if exists(select * from sysobjects where name='proc_SelectCommentCount')
drop proc proc_SelectCommentCount
go
create proc proc_SelectCommentCount
(
@pageSize int ,--控制一页显示数量
@page int ,--查看下一页
@MovieID int --哪个电影的评论
)
as 
select Count(*) from [dbo].[CommentInfo] where [MovieID] =  @MovieID --返回查询总数
 
if object_id('tempdb..#temp') is not null
begin
--删除临时表
DROP Table #temp
end

select * into #temp from (select top(@pageSize) * from [dbo].[CommentInfo] where [CommentID] not in (select top(@page) [CommentID] from [dbo].[CommentInfo] where MovieID=@MovieID order by [CommentID] desc)  and  MovieID=@MovieID order by [CommentID] desc ) CommentInfo --返回查询详情
select * from #temp order by [CommentID] desc
go
exec proc_SelectCommentCount 5,0,1