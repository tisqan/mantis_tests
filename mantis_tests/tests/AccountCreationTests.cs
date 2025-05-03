﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AccountCreationTests : TestBase
    {
        //[OneTimeSetUp]
        //public void SetUpConfig()
        //{
        //    app.Ftp.BackupFile("/config_inc.php");
        //    using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
        //    {
        //        app.Ftp.Upload("/config_inc.php", localFile);
        //    }
        //}

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }
    }
}
