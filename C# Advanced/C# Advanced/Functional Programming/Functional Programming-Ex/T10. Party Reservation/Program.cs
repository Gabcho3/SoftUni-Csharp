namespace T10._Party_Reservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            List<Filter> filters = new List<Filter>();

            string[] input;
            while(true)
            {
                input = Console.ReadLine().Split(';');
                string cmd = input[0];

                if (cmd == "Print")
                    break;

                string type = input[1];
                string parameter = input[2];

                if (cmd == "Add filter")
                {
                    filters.Add(new Filter() { Type = type, Parameter = parameter });
                }

                else if (cmd == "Remove filter")
                {
                    filters.RemoveAll(x => x.Type == type && x.Parameter == parameter);
                }
            }

            foreach(var filter in filters)
            {
                string filterType = filter.Type;
                string parameter = filter.Parameter;

                switch(filterType)
                {
                    case "Starts with":
                        names = names.Where(x => x[0] != char.Parse(parameter)).ToArray();
                        break;

                    case "Ends with":
                        names = names.Where(x => x[x.Length - 1] != char.Parse(parameter)).ToArray();
                        break;

                    case "Length":
                        names = names.Where(x => x.Length != int.Parse(parameter)).ToArray();
                        break;

                    case "Contains":
                        names = names.Where(x => !x.Contains(parameter)).ToArray();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
    class Filter
    {
        public string Type { get; set; }

        public string Parameter { get; set; }
    }
}