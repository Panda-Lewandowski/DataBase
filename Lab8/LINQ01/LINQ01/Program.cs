using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_to_Object
{
    [Serializable]
    public class Passenger : IComparable<Passenger>, IFormattable
    {
        public Passenger(int id, string name, string sex, int age, string ticket, bool survival)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
            this.Ticket = ticket;
            this.Survival = survival;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Ticket { get; set; }
        public bool Survival { get; set; }

        public override string ToString()
        {
            return String.Format("{0}", Name);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "I":
                    return Id.ToString();
                case "S":
                    return Sex;
                case "T":
                    return Ticket;
                case "Sur":
                    return Survival.ToString();
                case "A":
                    return Age.ToString();
                case "All":
                    return String.Format("#{0} {1} {2} y.o.,{3}, with ticket #{4} and survival {5}", Id, Name, Age, Sex, Ticket, Survival);
                default:
                    throw new FormatException(String.Format("Format {0} not supported", format));
            }
        }
        
        public int CompareTo(Passenger other)
        {
            if (other == null) throw new ArgumentNullException("other");

            return this.Name.CompareTo(other.Name);
        }
    }

        

       
    


    public static class Titanic
    {
        private static List<Passenger> passengers;

        public static IList<Passenger> GetPassengers()
        {
            if (passengers == null)
            {
                passengers = new List<Passenger>(10);
                passengers.Add(new Passenger( 1 , " Braund, Mr. Owen Harris ", " male ",  22 , " A/5 21171 ",  false));
                passengers.Add(new Passenger( 2 , " Cumings, Mrs. John Bradley (Florence Briggs Thayer) ", " female ",  38 , " PC 17599 ",  true  ));
                passengers.Add(new Passenger( 3 , " Heikkinen, Miss. Laina ", " female ",  26 , " STON/O2. 3101282 ",  true));
                passengers.Add(new Passenger( 4 , " Futrelle, Mrs. Jacques Heath (Lily May Peel) ", " female ",  35 , " 113803 ",  true));
                passengers.Add(new Passenger( 5 , " Allen, Mr. William Henry ", " male ",  35 , " 373450 ",  false  ));
                passengers.Add(new Passenger( 6 , " Moran, Mr. James ", " male ",  27 , " 330877 ",  false));
                passengers.Add(new Passenger( 7 , " McCarthy, Mr. Timothy J ", " male ",  54, " 17463 ",  false));
                passengers.Add(new Passenger( 8 , " Palsson, Master. Gosta Leonard ", " male ",  2 , " 349909 ",  false));
                passengers.Add(new Passenger( 9 , " Johnson, Mrs. Oscar W (Elisabeth Vilhelmina Berg) ", " female ",  27 , " 347742 ",  true));
                passengers.Add(new Passenger( 10 , " Nasser, Mrs. Nicholas (Adele Achem) ", " female ",  14 , " 237736 ",  true));
                
            }
            return passengers;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            GetLittleGirls();
            GetSurvived();
            Console.WriteLine("Вот и все...");
            Console.ReadLine();
        }

        static void GetLittleGirls()
        {
            Console.WriteLine("Get little girls...\n");
            var pass = from p in Titanic.GetPassengers()
                         where p.Age < 15 && p.Sex == " female "
                         select p;

            foreach (var p in pass)
            {
                Console.WriteLine("{0}  {1}\n", p.Name, p.Age);
            }
        }

        static void GetSurvived()
        {
            Console.WriteLine("Get Sutvived Passengers...\n");
            var pass = from p in Titanic.GetPassengers()
                       where p.Survival == true
                       select p;

            foreach (var p in pass)
            {
                Console.WriteLine("{0}  {1}\n", p.Name, p.Ticket);
            }
        }

    }
}
