using _07.Military.Classes;
using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

namespace _07.Military
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();
            while (true)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "End")
                    return;

                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];

                if (data[0] == "Spy")
                {
                    int codeNumber = int.Parse(data[4]);
                    Spy spy = new Spy(firstName, lastName, id, codeNumber);
                    Console.WriteLine(spy.ToString());
                }

                decimal salary = decimal.Parse(data[4]);
                switch (data[0])
                {
                    case "Private":
                        Private @private = new Private(firstName, lastName, id, salary);
                        privates.Add(@private);

                        Console.WriteLine(@private.ToString());
                        break;

                    case "LieutenantGeneral":
                        LieutenantGeneral leutenant = new LieutenantGeneral(firstName, lastName, id, salary);
                        Queue<string> ids = new Queue<string>(data.Skip(5).ToList());
                        foreach (var i in ids)
                        {
                            foreach (var soldier in privates)
                            {
                                if (soldier.Id == i)
                                {
                                    leutenant.Privates.Add(soldier);
                                }
                            }
                        }

                        Console.WriteLine(leutenant.ToString());
                        break;

                    case "Engineer":
                        string corps = data[5];
                        Engineer engineer = new Engineer(firstName, lastName, id, salary, corps);

                        if (engineer.Corps == null) //invalid corps
                        {
                            continue;
                        }

                        List<string> repairsData = data.Skip(6).ToList();
                        List<Repair> repairs = new List<Repair>();
                        for(int i = 0; i < repairsData.Count; i += 2)
                        {
                            string partName = repairsData[i];
                            int hoursWorked = int.Parse(repairsData[i + 1]);
                            repairs.Add(new Repair(partName, hoursWorked));
                        }
                        engineer.Repairs = repairs;

                        Console.WriteLine(engineer.ToString());
                        break;

                    case "Commando":
                        corps = data[5];
                        Commando commando = new Commando(firstName, lastName, id, salary, corps);

                        if (commando.Corps == null) //invalid corps
                        {
                            continue;
                        }
                        List<string> missionsData = data.Skip(6).ToList();
                        List<Mission> missions = new List<Mission>();
                        for (int i = 0; i < missionsData.Count; i += 2)
                        {
                            string codeName = missionsData[i];
                            string state = missionsData[i + 1];
                            Mission mission = new Mission(codeName, state);

                            if(mission.State == null)
                            {
                                continue;
                            }

                            missions.Add(mission);
                        }
                        commando.Missions = missions;

                        Console.WriteLine(commando.ToString());
                        break;
                }
            }
        }
    }
}
