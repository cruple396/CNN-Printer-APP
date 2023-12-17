using System;
using SQLite;

namespace CNN_App.Tables
{
    public class RegUser
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Admin { get; set; }
    }
}

