namespace OrderApi.Application.Exceptions
{
    public class NotFoundIdException : Exception
    {
        public NotFoundIdException(int id)
        : base($"Girmiş olduğunuz id ye ( {id} ) ye ait kayıt bulunmamaktadır. ")
        {
        }
    }
}
