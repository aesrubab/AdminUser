using ConsoleApp7;

using System;
using System.Collections.Generic;

using static ConsoleApp7.Exceptions;

class Program
{
    static List<Admin> admins = new List<Admin>();
    static List<User> users = new List<User>();

    static void Main(string[] args)
    {
        SeedData();
        Console.WriteLine("Are you Admin or User?");
        string role = Console.ReadLine().ToLower();

        if (role == "admin")
        {
            try
            {
                Admin admin = AuthenticateAdmin();
                AdminPanel(admin);
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else if (role == "user")
        {
            try
            {
                User user = AuthenticateUser();
                UserPanel(user);
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid role");
        }
    }

    static void SeedData()
    {
        var admin = new Admin { Id = 1, Email = "rubabhuseynova013@gmail.com", Password = "1234" };
        admins.Add(admin);

        var user = new User { Id = 1, Name = "Aygun", Surname = "Bayramova", Age = 20, Email = "aykabayram@gmail.com", Password = "5555" };
        var user2 = new User { Id = 2, Name = "Sabina", Surname = "Shakiyeva", Age = 20, Email = "sabishaki@gmail.com", Password = "7777" };
        var user3 = new User { Id = 2, Name = "Huseyn", Surname = "Huseynov", Age = 20, Email = "huseyn.hemidov.2004@gmail.com", Password = "0404" };
        users.Add(user);
        users.Add(user2);
        users.Add(user3);

        var post = new Post { Id = 1, Content = "Step students", CreationDateTime = DateTime.Now };
        admin.Posts.Add(post);
    }

    static Admin AuthenticateAdmin() 
    {
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        foreach (var admin in admins)
        {
            if (admin.Email == email && admin.Password == password)
            {
                return admin;
            }
        }

        throw new AuthenticationException("Invalid admin");
    }

    static User AuthenticateUser()
    {
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        foreach (var user in users)
        {
            if (user.Email == email && user.Password == password)
            {
                return user;
            }
        }

        throw new AuthenticationException("Invalid user.");
    }

    static void AdminPanel(Admin admin)
    {
        Console.WriteLine($"Welcome {admin.Email}");
        while (true)
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Add Post");
            Console.WriteLine("2. View Posts");
            Console.WriteLine("3. Delete Post by ID");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                {
                    Console.Write("Enter post content: ");
                    string content = Console.ReadLine();
                    admin.AddPost(content);
                }
                else if (choice == "2")
                {
                    admin.ViewPosts();
                }
                else if (choice == "3")
                {
                    Console.Write("Enter post ID to delete: ");
                    int postId = int.Parse(Console.ReadLine());
                    admin.DeletePostById(postId);
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    throw new InvalidInputException("Invalid choice");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    static void UserPanel(User user)
    {
        Console.WriteLine($"Welcome {user.Name} {user.Surname}");
        while (true)
        {
            Console.WriteLine("User Menu:");

            Console.WriteLine("1. View Posts");
            Console.WriteLine("2. Like Post");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                {
                    ViewPosts(user);
                }
                else if (choice == "2")
                {
                    LikePost(user);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    throw new InvalidInputException("Invalid choice");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void ViewPosts(User user)
    {
        foreach (var admin in admins)
        {
            foreach (var post in admin.Posts)
            {
                Console.WriteLine($"ID: {post.Id}, Content: {post.Content}, Views: {post.ViewCount}, Likes: {post.LikeCount}");
            }
        }

        try
        {
            Console.Write("Enter post ID to view: ");
            int postId = int.Parse(Console.ReadLine());

            foreach (var admin in admins)
            {
                var post = admin.Posts.Find(p => p.Id == postId);
                if (post != null)
                {
                    post.ViewCount++;
                    admin.Notify($"Post {postId} viewed by {user.Name} {user.Surname}", user);
                    Console.WriteLine(post.Content);
                    return;
                }
            }

            throw new PostNotFoundException("Post not found");
        }
        catch (FormatException)
        {
            throw new InvalidInputException("Invalid ID");
        }
    }

    static void LikePost(User user)
    {
        try
        {
            Console.Write("Enter post ID to like: ");
            int postId = int.Parse(Console.ReadLine());

            foreach (var admin in admins)
            {
                var post = admin.Posts.Find(p => p.Id == postId);
                if (post != null)
                {
                    post.LikeCount++;
                    admin.Notify($"Post {postId} liked by {user.Name} {user.Surname}", user);
                    Console.WriteLine("Post liked");
                    return;
                }
            }

            throw new PostNotFoundException("Post not found");
        }
        catch (FormatException)
        {
            throw new InvalidInputException("Invalid ID");
        }
    }
}
