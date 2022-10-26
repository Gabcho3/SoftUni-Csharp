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

            var pieces = new Dictionary<string, Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|');

                Piece piece = new Piece() { Composer = input[1], Key = input[2] };

                pieces[input[0]] = piece;
            }

            string[] command = Console.ReadLine().Split('|');

            while (command[0] != "Stop")
            {
                string piece = command[1];

                switch (command[0])
                {
                    case "Add":
                        string composer = command[2];
                        string key = command[3];
                        Add(pieces, piece, composer, key);
                        break;

                    case "Remove":
                        if (pieces.ContainsKey(piece))
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }

                        else
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");

                        break;

                    case "ChangeKey":
                        string newKey = command[2];
                        ChangeKey(pieces, piece, newKey);
                        break;
                }

                command = Console.ReadLine().Split('|');
            }

            foreach (var piece in pieces)
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
        }

        static void Add(Dictionary<string, Piece> pieces, string piece, string composer, string key)
        {
            if (pieces.ContainsKey(piece))
                Console.WriteLine($"{piece} is already in the collection!");

            else
            {
                Piece newPiece = new Piece() { Composer = composer, Key = key };
                pieces[piece] = newPiece;

                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
        }

        static void ChangeKey(Dictionary<string, Piece> pieces, string piece, string newKey)
        {
            if (!pieces.ContainsKey(piece))
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");

            else
            {
                pieces[piece].Key = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
        }

        class Piece
        {
            public string Composer { get; set; }

            public string Key { get; set; }
        }
    }
}
