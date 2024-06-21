using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Post
    {


        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }

        public Post()
        {
            LikeCount = 0;
            ViewCount = 0;
        }

    }
}
