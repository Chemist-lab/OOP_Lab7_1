using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Lab7_1
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("╔════════════╤══════════════════════════════════╗");
                Console.WriteLine("   Hot key   │            Function       ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("      A      │        Add plane data  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("      C      │       Change plane data  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("      D      │      Delete plane data ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("      T      │     Show all plane data  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("    Space    │         Clear console  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("     Esc     │          Exit program  ");
                Console.WriteLine("╚════════════╧══════════════════════════════════╝");

                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                var data = JsonConvert.DeserializeObject<List<Planes>>(File.ReadAllText(FilePath));
                int menuselect = 0;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        menuselect = 1;
                        break;
                    case ConsoleKey.S:
                        menuselect = 2;
                        break;
                    case ConsoleKey.T:
                        menuselect = 3;
                        break;
                    case ConsoleKey.Escape:
                        menuselect = 4;
                        break;
                    case ConsoleKey.D:
                        menuselect = 5;
                        break;
                }

                if (menuselect == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Enter Plane Data\n");
                    Console.WriteLine("Plane name: ");
                    string plName = Console.ReadLine();
                    Console.WriteLine("Plane id: ");
                    string plId = Console.ReadLine();
                    Console.WriteLine("Flying time: ");
                    string plFltime = Console.ReadLine();
                    Console.WriteLine("Capacity: ");
                    string plCapacity = Console.ReadLine();
                    Console.WriteLine("Plane power: ");
                    string plPower = Console.ReadLine();

                    if (plName != null && plId != null && plFltime != null && plCapacity != null && plPower != null)
                    {
                        data.Add(new Planes { PlaneName = plName, PlaneId = plId, Fly_time = plFltime, PlaneCapacity = plCapacity, PlanePower = plPower });
                    }
                    else
                    {
                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                    }
                    Console.Clear();
                }

                if (menuselect == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter id of search plane: ");
                    string id = Console.ReadLine();
                    if (Console.ReadLine() != null)
                    {
                        Console.Clear();
                        Planes FoundData = data.Find(found => found.PlaneId == id);
                        if (FoundData != null)
                        {
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("     Name    │     ID     │ Fly time │   Capacity  │  Pale power");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.PlaneName, FoundData.PlaneId, FoundData.Fly_time, FoundData.PlaneCapacity, FoundData.PlanePower);
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");


                            Console.WriteLine("\nTo edit press 'E'");
                            Console.WriteLine("\n\nTo edit press 'D'");
                            if (Console.ReadKey().Key == ConsoleKey.E)
                            {
                                Console.WriteLine("Edit Plane Data\n");
                                Console.WriteLine("Plane name: ");
                                string plName = Console.ReadLine();
                                Console.WriteLine("Plane id: ");
                                string plId = Console.ReadLine();
                                Console.WriteLine("Flying time: ");
                                string plFltime = Console.ReadLine();
                                Console.WriteLine("Capacity: ");
                                string plCapacity = Console.ReadLine();
                                Console.WriteLine("Plane power: ");
                                string plPower = Console.ReadLine();

                                if (plName == null || plId == null || plFltime == null || plCapacity == null || plPower == null)
                                {
                                    Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                                }
                                FoundData.PlaneName = plPower;
                                FoundData.PlaneId = plId;
                                FoundData.Fly_time = plFltime;
                                FoundData.PlaneCapacity = plCapacity;
                                FoundData.PlanePower = plPower;
                                Console.Clear();
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("     Name    │     ID     │ Fly time │   Capacity  │  Pale power");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.PlaneName, FoundData.PlaneId, FoundData.Fly_time, FoundData.PlaneCapacity, FoundData.PlanePower);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                            }
                            if (Console.ReadKey().Key == ConsoleKey.D)
                            {
                                data.RemoveAll(x => x.PlaneId == id);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error\n\n" +
                        "Plane not found");
                        }


                    }
                }

                if (menuselect == 3)
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                    Console.WriteLine("     Name    │     ID     │ Fly time │   Capacity  │  Pale power");
                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                    data.Sort(new Planes.SortByTimeAndCapacity());
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", data[i].PlaneName, data[i].PlaneId, data[i].Fly_time, data[i].PlaneCapacity, data[i].PlanePower);
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                    }
                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }
                }

                if (menuselect == 4)
                {
                    Environment.Exit(0);
                }

                if (menuselect == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter id of plane to delete: ");
                    string id = Console.ReadLine();
                    if (Console.ReadLine() != null)
                    {
                        Console.Clear();
                        Planes FoundData = data.Find(found => found.PlaneId == id);
                        if (FoundData != null)
                        {
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("     Name    │     ID     │ Fly time │   Capacity  │  Pale power");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.PlaneName, FoundData.PlaneId, FoundData.Fly_time, FoundData.PlaneCapacity, FoundData.PlanePower);
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                            data.RemoveAll(x => x.PlaneId == id);
                            Console.WriteLine("This information has been deleted");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error\n\n" +
                        "Plane not found");
                        }


                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                }

                string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                if (serialize.Count() > 1)
                {
                    if (!File.Exists(FileName))
                    {
                        File.Create(FileName).Close();
                    }
                    File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                }
            }
        }
    }

    public class Planes
    {
        public string PlaneName { get; set; }
        public string PlaneId { get; set; }
        public string Fly_time { get; set; }
        public string PlaneCapacity { get; set; }
        public string PlanePower { get; set; }
        public int CompareTo(Planes p)
        {
            return Convert.ToDouble(this.Fly_time).CompareTo(Convert.ToDouble(p.Fly_time));
        }
        public class SortByTimeAndCapacity : IComparer<Planes>
        {
            public int Compare(Planes p1, Planes p2)
            {
                float fl1 = (float)Convert.ToDouble(p1.Fly_time);
                float fl2 = (float)Convert.ToDouble(p2.Fly_time);
                float c1 = (float)Convert.ToDouble(p1.PlaneCapacity);
                float c2 = (float)Convert.ToDouble(p2.PlaneCapacity);
                if (fl1 < fl2)
                    return 1;
                else if (fl1 > fl2)
                    return -1;
                else if(c1 < c2)
                    return 1;
                else if (c1 > c2)
                    return -1;
                else
                    return 0;
            }
        }
        public class ArrayPlanes : IEnumerable
        {
            int cnt = 0;
            Planes[] mas;
            public ArrayPlanes(int count = 10)
            {
                mas = new Planes[count];
            }
            public void Add(Planes o)
            {
                if (cnt >= 10)
                {
                    return;
                }
                mas[cnt] = o;
                cnt++;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                for (int i = 0; i < cnt; ++i) yield return mas[i];
            }
            public void Sort()
            {
                Array.Sort(mas, new Planes.SortByTimeAndCapacity());
            }
        }
    }

}
