namespace Art.App.Authorization
{
    public static class Authorized
    {
        public static bool IsAuthorizedUser(string OwnerUsername, string username)
        {
            if (OwnerUsername != username)
            {
                return true;
            }
            
            return false;
        }
    }
}
