--选出符合条件的ID并去掉内层的ID，得到的就是其他符合要求的ID
select Top 1 * from MovieInfo where MovieID not in(
		--查询出所有符合条件的ID，通过Top来换页
		select top 1 MovieID from MovieInfo
		where 
		(
		(MovieType like '%'+'剧情'+'%') and (MovieArea like '%'+'大陆'+'%')and(MovieYears like '%'+'2019'+'%')
		)order by MovieID
	) 
	and (MovieType like '%'+'剧情'+'%') 
	and (MovieArea like '%'+'大陆'+'%')
	and (MovieYears like '%'+'2019'+'%')

if exists(select * from sysobjects where name='proc_SelectPageMovieType')
drop proc proc_SelectPageMovieType
go
create proc proc_SelectPageMovieType
(
@MovieType nvarchar(50),
@MovieArea nvarchar(50),
@MovieYears nvarchar(50),
@PageSize int,
@PageNum int
)
as
select Count(*) from MovieInfo where 
		(
		(MovieType like '%'+@MovieType+'%') and 
		(MovieArea like '%'+@MovieArea+'%') and
		(MovieYears like '%'+@MovieYears+'%')
		)
if  @PageNum!=0
	begin
		select Top (@PageSize) * from MovieInfo where MovieID not in
		(
			select top (@PageNum) MovieID from MovieInfo
			where 
			(
			  (MovieType like '%'+@MovieType+'%') and
			  (MovieArea like '%'+@MovieArea+'%') and
			  (MovieYears like '%'+@MovieYears+'%')
			)order by MovieID
		) 
		and (MovieType like '%'+@MovieType+'%') 
		and (MovieArea like '%'+@MovieArea+'%')
		and (MovieYears like '%'+@MovieYears+'%')
	end

else
	begin
		select top(@PageSize) * from MovieInfo where MovieID in(
				select MovieID from MovieInfo 
				where 
				(
					(MovieType like '%'+@MovieType+'%') and 
					(MovieArea like '%'+@MovieArea+'%') and
					(MovieYears like '%'+@MovieYears+'%')
				)
		) 
				order by MovieID
	end

	exec proc_SelectPageMovieType '','','',18,18