namespace PizzaShopAPI.Exceptions
{
    public class UserNotActiveException: Exception
    {
        public UserNotActiveException(string message) : base(message)
        {

        }
    }
}

