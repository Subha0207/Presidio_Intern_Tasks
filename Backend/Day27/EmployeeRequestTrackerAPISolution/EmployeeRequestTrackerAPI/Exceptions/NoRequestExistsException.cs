namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoRequestExistsException:Exception
    {
       public NoRequestExistsException() : base("Requests are empty.No Request exists")
        {

        }
    }
}
