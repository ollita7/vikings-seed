using System;

namespace Viking.DataAccess
{
    public class Users
    {
        public int id { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool active { get; set; }
    }
}