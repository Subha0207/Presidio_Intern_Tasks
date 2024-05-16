namespace PizzaShopAPI.Exceptions
{
    public class NoPizzaFoundException : Exception
    {
       public NoPizzaFoundException() : base("No Pizza found")

        {

        }
    }
}
