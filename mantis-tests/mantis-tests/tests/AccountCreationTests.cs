﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
   
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
       [TestFixtureSetUp]
       public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("config_inc.php", localFile);
            }            
        }

        [Test]
        public void TestAccountRegistration()
        {
            
            AccountData account = new AccountData()
            {
                Name = "testuser2",
                Password = "password",
                Email = "testuser2@localhost.localDomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccouns();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            if(existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            app.Registration.Register(account);
        }
        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("config_inc.php");
        }
    }
}
