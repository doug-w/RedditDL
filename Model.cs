using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedditDL
{
    public class RedditContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=reddit.db");
    }

    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
	public string Subreddit { get; set; }
	public string CommentId { get; set; }
	public string ParentId { get; set; }
	public Post Post { get; set; }
	public string Json { get; set; }
	public string Link { get; set; }
	public string Author { get; set; }
	public DateTime Submitted  { get; set; }
	public String Body { get; set; }
    }

    [Serializable]
    public class Post
    {
        public int Id { get; set; }
	public string Subreddit { get; set; }
	public string PostId { get; set; }
	public string Title { get; set; }
	public string Json { get; set; }
	public string Link { get; set; }
	public string Author { get; set; }
	public DateTime Submitted  { get; set; }
    }
}
