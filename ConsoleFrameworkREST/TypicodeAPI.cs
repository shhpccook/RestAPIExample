using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleFrameworkREST
{

    class Post
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

        public string toString()
        {
            return $"Name: {this.name}\r\nemail: {this.email}\r\nbody: {this.body}";
        }
    }
    /*class Posts
    {
        public IList<Post> results { get; set; }

    }*/

    
    class TypicodeAPI:BaseAPI
    {
        IList<Post> allPosts = null;

        public TypicodeAPI(String URI)
        {
            this.URI = URI;
            base.RunAsync().GetAwaiter().GetResult();
        }

        override public void Show()
        {
            if (allPosts == null) return;
            foreach (Post post in allPosts)
            {
                Console.WriteLine($"Name: {post.name}\r\n email: {post.email}");
            }
        }

        override public void Convert(String data)
        {
            this.result = JsonConvert.DeserializeObject<IList<Post>>(data);
            allPosts = (IList<Post>)result;
        }

        public Post getPost(int id)
        {
            if (allPosts == null) return null;
            foreach (Post post in allPosts)
            {
                if(post.id==id) return post;
            }
            return null;
        }

    }
}
