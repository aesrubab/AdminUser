using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp7.Network;

namespace ConsoleApp7
{
    internal class Admin : UserInfo
    {
        public List<ConsoleApp7.Post> Posts { get; set; }
        public List<Notification> Notifications { get; set; }

        public Admin()
        {
            Posts = new List<ConsoleApp7.Post>();
            Notifications = new List<Notification>();
        }

        public void Notify(string text, User user)
        {
            var notification = new Notification
            {
                Id = Notifications.Count + 1,
                Text = text,
                DateTime = DateTime.Now,
                FromUser = user
            };
            Notifications.Add(notification);

            MailService.SendEmail(Email, "New Notification", text);
        }

         public void AddPost(string content)
        {
            var post = new ConsoleApp7.Post
            {
                Id = Posts.Count + 1,
                Content = content,
                CreationDateTime = DateTime.Now
            };
            Posts.Add(post);
            Console.WriteLine("Post added");
        }

        public void ViewPosts()
        {
            foreach (var post in Posts)
            {
                Console.WriteLine($"ID: {post.Id}, Content: {post.Content}, Created: {post.CreationDateTime}, Views: {post.ViewCount}, Likes: {post.LikeCount}");
            }
        }

        public void DeletePostById(int postId)
        {
            var post = Posts.Find(p => p.Id == postId);
            if (post != null)
            {
                Posts.Remove(post);
                Console.WriteLine("Post deleted ");
            }
            else
            {
                Console.WriteLine("Post not found ");
            }
        }
    }
}
