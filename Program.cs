using System;
using System.Linq;

namespace RedditDL
{
    class Program
    {
        static void Main()
        {
            using (var db = new RedditContext())
            {
                  Console.WriteLine("Inserting a new post");
                  db.Add(new Post { PostId = "foo" });
                  db.SaveChanges();

                  var post = db.Posts.OrderBy(b => b.PostId).First();
                  db.Remove(post);

                  db.SaveChanges();
            }
        }
    }
}
