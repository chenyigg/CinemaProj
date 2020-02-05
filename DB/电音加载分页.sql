select top 1 * from MovieInfo where MovieID not in(
		select Top 5 MovieID from MovieInfo order by MovieID
	) 

if exists(select * from sysobjects where name='proc_SelectPageMovieInfo')
drop proc proc_SelectPageMovieInfo
go
create proc proc_SelectPageMovieInfo
(
@PageSize int,
@PageNum int
)
as
select Count(*) from MovieInfo
select top(@PageSize) * from MovieInfo where MovieID not in(
		select Top (@PageNum) MovieID from MovieInfo order by MovieID
	) 

	exec proc_SelectPageMovieInfo 5,10