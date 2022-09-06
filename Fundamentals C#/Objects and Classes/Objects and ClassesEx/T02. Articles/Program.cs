using System;

namespace T02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(", ");
            int lines = int.Parse(Console.ReadLine());

            Article article = new Article
            {
                Title = data[0],
                Content = data[1],
                Author = data[2]
            };

            for(int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                switch(command[0])
                {
                    case "Edit":
                        article.Edit(command);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(command);
                        break;

                    case "Rename":
                        article.Rename(command);
                        break;
                }
            }

            article.PrintArticle();
        }
    }

    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string[] command)
        {
            this.Content = command[1];
        }

        public void ChangeAuthor(string[] command)
        {
            this.Author = command[1];
        }

        public void Rename(string[] command)
        {
            this.Title = command[1];
        }

        public void PrintArticle()
        {
            Console.WriteLine("{0} - {1}: {2}", this.Title, this.Content, this.Author);
        }
    }
}
