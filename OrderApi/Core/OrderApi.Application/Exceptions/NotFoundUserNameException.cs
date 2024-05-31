namespace OrderApi.Application.Exceptions
{
    public class NotFoundUserNameException : Exception
    {
        public NotFoundUserNameException(string userName)
        : base($"Girmiş olduğunuz Kullanıcı adına ({userName}) ait kullanıcı bulunmamaktadır.")
        {
        }
    }
}
