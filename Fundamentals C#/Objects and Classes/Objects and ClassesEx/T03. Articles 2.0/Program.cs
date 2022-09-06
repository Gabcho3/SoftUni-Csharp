using System;
using System.Collections.Generic;

namespace T03._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for(int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(", ");

                Article article = new Article()
                {
                    Title = data[0],
                    Content = data[1],
                    Author = data[2]
                };

                articles.Add(article);
            }

            Console.ReadLine();

            for(int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine("{0} - {1}: {2}", articles[i].Title, articles[i].Content, articles[i].Author);
            }
        }
    }

    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}
