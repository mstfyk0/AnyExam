namespace OrderApi.Application.Exceptions
{
    public class NotFoundIdException : Exception
    {
        public NotFoundIdException(int id)
        : base($"Girmiş olduğunuz Id {id} ye ait kayıt bulunmamaktadır. ")
        {
        }
    }
}
