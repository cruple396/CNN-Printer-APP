using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
namespace CNN_App.Tables
{
    public class Orders
    {
        [PrimaryKey, AutoIncrement]
        public int orderNum { get; set; }
        public int randNum { get; set; }
    }
}

