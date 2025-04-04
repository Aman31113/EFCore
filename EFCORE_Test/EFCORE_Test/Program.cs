using EFCORE_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


public class Program
{
    private static void Main(string[] args)
    {
        EfcoreContext ef = new EfcoreContext();
        bool exit = true;

        while (exit) {

            Console.WriteLine("\nwhich operation you want to perform\n");
            Console.WriteLine("1. read");
            Console.WriteLine("2. write");
            Console.WriteLine("3. update");
            Console.WriteLine("4. remove");
            Console.WriteLine("5. exit\n");

            int a = Convert.ToInt32(Console.ReadLine());
            switch (a) { 
                
                case 1: Read(ef); break;
                case 2: Write(ef); break;
                case 3: update(ef); break;
                case 4: remove(ef); break;
                case 5: exit = false; break;
                default: Console.WriteLine("bhak sala aisa kuch nhi hai !!! "); break;
            } 

        }


        //Read(ef);
        ////Write(ef);
        ////Console.WriteLine("\n");


        ////update(ef);
        ////Read(ef);

        //remove(ef);
        //Read(ef);



        //foreach (EfcoreEmployee emp in ef.EfcoreEmployees)
        //{
        //    Console.Write(emp.EmployeeId);
        //    Console.Write(" ");
        //    Console.Write(emp.FirstName);
        //    Console.Write(" ");
        //    Console.Write(emp.LastName);
        //    Console.Write(" ");
        //    Console.Write(emp.Department);
        //    Console.Write("\n");
        //}

    }
    public static void Read(EfcoreContext ef)
    {
        foreach (EfcoreEmployee emp in ef.EfcoreEmployees)
        {
            Console.Write(emp.EmployeeId);
            Console.Write(" ");
            Console.Write(emp.FirstName);
            Console.Write(" ");
            Console.Write(emp.LastName);
            Console.Write(" ");
            Console.Write(emp.Department);
            Console.Write("\n");
        }
    }
    
    public static void Write(EfcoreContext ef)
    {
        Console.Write(" Enter your id , first name , last name , department \n");
        int id = Convert.ToInt32(Console.ReadLine());
        string Fname = Console.ReadLine();
        string Lname = Console.ReadLine();
        string dpr = Console.ReadLine();
        EfcoreEmployee sv = new EfcoreEmployee() { EmployeeId = id, FirstName = Fname, LastName = Lname , Department=dpr };
        ef.EfcoreEmployees.Add(sv);
        ef.SaveChanges();

    }
    public static void update(EfcoreContext ef)
    {
        Console.WriteLine("enter the id to update in db");
        int id = Convert.ToInt32(Console.ReadLine());
        EfcoreEmployee existing = ef.EfcoreEmployees.FirstOrDefault(x=>x.EmployeeId == id);
        Console.WriteLine("enter the department to change");
        string newDpr = Console.ReadLine();
        existing.Department = newDpr;
        ef.EfcoreEmployees.Update(existing);
        ef.SaveChanges();
        Console.WriteLine("changes are made");


    }
    public static void remove(EfcoreContext ef)
    {
        Console.WriteLine("enter the id to delete in db");
        int id = Convert.ToInt32(Console.ReadLine());
        EfcoreEmployee existing = ef.EfcoreEmployees.FirstOrDefault(x => x.EmployeeId == id);
        ef.EfcoreEmployees.Remove(existing);
        ef.SaveChanges();
        Console.WriteLine(" person removed");
    }
} 
