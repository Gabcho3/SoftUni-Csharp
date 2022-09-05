using System;
using System.Collections.Generic;

namespace T03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();


            for(int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split('_');

                Song song = new Song(data[0], data[1], data[2]);

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
                foreach (Song song in songs)
                    Console.WriteLine(song.Name);

            else
                foreach (Song song in songs)
                    if (song.TypeList == typeList)
                        Console.WriteLine(song.Name);
        }
    }

    class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}
