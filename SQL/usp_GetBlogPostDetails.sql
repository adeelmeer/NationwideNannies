
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_GetBlogPostDetails')
DROP PROCEDURE [dbo].[usp_GetBlogPostDetails]
GO

CREATE procedure [dbo].[usp_GetBlogPostDetails]
(
	@slug nvarchar(255)
	,@getPublishedOnly bit
)
as
begin
	
	select p.Title, p.Description, p.PostContent, p.DateCreated, p.Slug, p.IsPublished
	into #temp
	from be_Posts p
	where p.Slug = @slug
	and p.IsDeleted = 0

	--and p.IsPublished = 1

	if(@getPublishedOnly = 1)
	begin
		delete from #temp where IsPublished = 0
	end
	
	select p.Title, p.Description, p.PostContent, p.DateCreated, p.Slug from #temp p

	drop table #temp
end
-- usp_GetBlogPostDetails 'another-post', 0
-- 