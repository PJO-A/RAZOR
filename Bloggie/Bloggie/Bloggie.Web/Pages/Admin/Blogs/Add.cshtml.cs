using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
// Created and assigned field
        private readonly BloggieDbContext _bloggieDbContext;
//

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

// CONSTRUKTOR
        public AddModel(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }
//

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() // IActionResult - is used to return to bage
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeatureImageUrl = AddBlogPostRequest.FeatureImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };

           await _bloggieDbContext.BlogPosts.AddAsync(blogPost);
           await _bloggieDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
