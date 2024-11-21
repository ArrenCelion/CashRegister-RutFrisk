namespace CashRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductLookup.CreateLookup();
            Register register = new Register();
            register.StartApplication();
        }
    }
}
