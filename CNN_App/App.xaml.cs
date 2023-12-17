using System;
using System.IO;
using CNN_App.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CNN_App.Views;

namespace CNN_App
{
    public partial class App : Application
    {

        //UserDatabase and Location
        static UserDatabase db;
        public static UserDatabase Database
        {
            get
            {
                if (db == null)
                {
                    db = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3"));
                }
                return db;
            }
        }

        //PrinterDatabase and location
        static PrinterDatabase db2;
        public static PrinterDatabase Database2
        {
            get
            {
                if(db2==null)
                {
                    db2 = new PrinterDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PrinterDatabase.db3"));
                }
                return db2;
            }
        }

        //CartDatabase and location
        static CartDatabase db3;
        public static CartDatabase Database3
        {
            get
            {
                if (db3 == null)
                {
                    db3 = new CartDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CartDatabase.db3"));
                }
                return db3;
            }
        }


        //OrderDatabase and location
        static OrderDatabase db4;
        public static OrderDatabase Database4
        {
            get
            {
                if (db4 == null)
                {
                    db4 = new OrderDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OrderDatabase.db3"));
                }
                return db4;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

