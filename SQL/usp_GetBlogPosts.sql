
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_GetBlogPosts')
DROP PROCEDURE [dbo].[usp_GetBlogPosts]
GO

CREATE procedure [dbo].[usp_GetBlogPosts]
(
	@isTestimonial bit = 0
)
as
begin
	
	declare @categoryId nvarchar(200) 
	declare @categoryName nvarchar(80) = 'BlogPost'

	if(@isTestimonial = 1)
	begin
		set @categoryName = 'Testimonial'
	end

	select @categoryId = CategoryID from be_Categories where CategoryName  = @categoryName

	--select c.CategoryName, p.*
	select p.Title, p.Description, p.DateCreated, p.Slug
	from be_Posts p
	left join be_PostCategory pc on pc.PostID = p.PostID
	left join be_Categories c on c.CategoryID = pc.CategoryID
	where p.IsDeleted = 0
	and		p.IsPublished = 1
	and		c.CategoryID = @categoryId 
	order by DateCreated desc
	
end
-- usp_GetBlogPosts
-- usp_GetBlogPosts 1