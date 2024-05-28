namespace OrderApi.Application.Exceptions
{
    public class NotFoundUserNameException : Exception
    {
        public NotFoundUserNameException(string userName)
        : base($"Girmiş olduğunuz Kullanıcı ado {userName} ye ait kullanıcı bulunmamaktadır.. ")
        {
        }
    }
}
