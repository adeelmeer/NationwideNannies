
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_GetPublishedBlogPosts')
DROP PROCEDURE [dbo].[usp_GetPublishedBlogPosts]
GO

CREATE procedure [dbo].[usp_GetPublishedBlogPosts]

as
begin
	
	select p.Title, p.Description, p.DateCreated, p.Slug, p.IsCommentEnabled
	from be_Posts p
	left join be_PostCategory pc on pc.PostID = p.PostID
	left join be_Categories c on c.CategoryID = pc.CategoryID
	where p.IsDeleted = 0
	and		p.IsPublished = 1
	and		c.CategoryName = 'BlogPost'
	order by DateCreated desc
	
end
-- usp_GetPublishedBlogPosts
