using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext _bloggieDbContext;

        [BindProperty]
        public BlogPost BlogPosts { get; set; }

        public EditModel(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }
        public async Task OnGet(Guid id)
        {
            BlogPosts = await _bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await _bloggieDbContext.BlogPosts.FindAsync(BlogPosts.Id);
            if (existingBlogPost != null) 
            {
                existingBlogPost.Heading = BlogPosts.Heading;
                existingBlogPost.PageTitle = BlogPosts.PageTitle;
                existingBlogPost.Content = BlogPosts.Content;
                existingBlogPost.ShortDescription = BlogPosts.ShortDescription;
                existingBlogPost.FeatureImageUrl = BlogPosts.FeatureImageUrl;
                existingBlogPost.UrlHandle = BlogPosts.UrlHandle;
                existingBlogPost.PublishedDate = BlogPosts.PublishedDate;
                existingBlogPost.Author = BlogPosts.Author;
                existingBlogPost.Visible = BlogPosts.Visible;

            }
            await _bloggieDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete() 
        {
            var existingBlog = _bloggieDbContext.BlogPosts.Find(BlogPosts.Id);

            if(existingBlog != null)
            {
                _bloggieDbContext.BlogPosts.Remove(existingBlog);
                await _bloggieDbContext.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
