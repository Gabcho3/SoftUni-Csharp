using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace T03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var pieces = new List<Piece>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                Piece piece = new Piece()
                {
                    Name = input[0],
                    Composer = input[1],
                    Key = input[2]
                };

                pieces.Add(piece);
            }

            string[] command = Console.ReadLine().Split('|');

            while (command[0] != "Stop")
            {
                switch(command[0])
                {
                    case "Add":
                        Add(command, pieces);
                        break;

                    case "Remove":
                        Remove(command, pieces); 
                        break;

                    case "ChangeKey":
                        ChangeKey(command, pieces);
                        break;
                }

                command = Console.ReadLine().Split('|');
            }

            foreach (var piece in pieces)
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
        }

        static void Add(string[] command, List<Piece> pieces)
        {
            Piece piece = new Piece { Name = command[1], Composer = command[2], Key = command[3] };

            if (pieces.Any(p => p.Name == command[1]))
                Console.WriteLine($"{piece.Name} is already in the collection!");

            else
            {
                pieces.Add(piece);
                Console.WriteLine($"{piece.Name} by {piece.Composer} in {piece.Key} added to the collection!");
            }

        }

        static void Remove(string[] command, List<Piece> pieces)
        {
            bool found = false;
            
            for (int i = 0; i < pieces.Count; i++)
                if (pieces[i].Name == command[1])
                {
                    pieces.RemoveAt(i);

                    found = true;

                    Console.WriteLine($"Successfully removed {command[1]}!");
                }

            if(!found)
                Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
        }

        static void ChangeKey(string[] command, List<Piece> pieces)
        {
            string piece = command[1];
            string key = command[2];

            bool found = false;

            for (int i = 0; i < pieces.Count; i++)
                if (pieces[i].Name == piece)
                {
                    pieces[i].Key = key;

                    found = true;

                    Console.WriteLine($"Changed the key of {piece} to {key}!");
                }

            if (!found)
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }
    }

    class Piece
    { 
        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }
    }
}
