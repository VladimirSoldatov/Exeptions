using System;
using System.Collections;
using static System.Console;
namespace SimpleProject
{
    public class DateTimeCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
            }
     
            throw new System.NotImplementedException();
        }
    }
    public class Student : IComparable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {BirthDate.ToString("dd.MM.yyyy")}"; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList auditory = new ArrayList {
                new Student {
                FirstName ="John",
                LastName ="Miller",
                BirthDate =new DateTime(1997,3,12)
                },
                new Student {
                FirstName ="Candice",
                LastName ="Leman",
                BirthDate =new DateTime(1998,7,22)
                }
            };
            auditory.Sort();
            foreach(var item in auditory)
            {
                Console.WriteLine(item);
            }
            auditory.Sort(new DateTimeCompare());
            foreach (var item in auditory)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}