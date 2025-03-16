using LivingAsIntern.Data;
using LivingAsIntern.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LivingAsIntern.Services
{
    public class PostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.posts.ToListAsync();
        }

        public async Task<Post> GetPostsById(int Id)
        {
            var post = await _context.posts.FindAsync(Id);

            if (post == null)
            {
                throw new Exception("Post not Found");
            }

            return post;
        }

        public async Task<List<Post>> GetPostsByMonth(int Month)
        {
            var startDate = new DateTime(DateTime.Now.Year, Month, 1);
            var endDate = startDate.AddMonths(1);

            var posts = await _context.posts
                .Where(post => post.CreatedAt >= startDate && post.CreatedAt < endDate)
                .OrderByDescending(posts => posts.CreatedAt)
                .ToListAsync();

            return posts;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            _context.posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePost(int Id)
        {
            var post = await _context.posts.FindAsync(Id);
            if (post == null)
            {
                throw new Exception("Post Not Found");
            }
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> CreatePost(Post post)
        {
            _context.posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
