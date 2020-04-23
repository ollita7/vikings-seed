using System.Linq;

namespace Viking.DataAccess
{
    public class UserDataAccess
    {
        private readonly VikingContext _context;

        public bool UserExist(string username)
        {
            if (_context.Users.Any(x => x.Username == username))
                return true;

            return false;
        }





    }
}