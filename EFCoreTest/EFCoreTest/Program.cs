using EFCoreTest.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        EfcoreContext context = new EfcoreContext();
        foreach (EfcoreContext ef in context.)
        {
            Console.WriteLine(ef.EmployeeID + " " + ef.Department)
        }
    }
}
