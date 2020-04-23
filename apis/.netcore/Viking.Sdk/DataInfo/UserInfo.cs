using System;

namespace Viking.Sdk
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
    }
}