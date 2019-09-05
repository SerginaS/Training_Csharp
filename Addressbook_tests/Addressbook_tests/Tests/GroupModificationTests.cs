using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Test11111");
            newData.Header = "Test222222";
            newData.Footer = "Test333333";

            app.Groups.Modify(1, newData);
        }
    }
}
