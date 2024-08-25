namespace Domain.Shared.Layer
{
    public class ErrorsConstant
    {
        public const string NotFoundItem = "Not found Item";
        public const string AddingProblem = "Item can't be Added";
        public const string DeletingProblem = "Item can't be Deleted";
        public const string UpdatingProblem = "Item can't be Updated";
        public const string LessThanZero = "Price must be greater than or equal to 0";
        public const string Empty = "Name cannot be empty";
        public static string ErrorMessage = "Error Occurred";
    }

    public class ResponseMessages
    {
        public const string AddedItem = "Item is successfully Added";
        public const string DeletedItem = " Item is succssfully deleted";
        public const string UpdatedItem = " Item is succssfully updated";
    }

    public class Paths
    {
        public const string LogFile = "C:\\Users\\lamaa\\source\\repos\\FirstTask\\Host\\logs\\log.txt";
        public const string SenderEmail = "lamaabothaher15@gmail.com";
        public const string ReciverEmail = "ahmad.shellah@ultimitats.com";
    }
}
