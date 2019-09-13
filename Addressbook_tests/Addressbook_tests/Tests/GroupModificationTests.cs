using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Test22222");
            newData.Header = null;
            newData.Footer = null;

            //проверка на наличие хотя бы одной группы в списке групп, если нет - создаем
            app.Groups.CheckGroupList();

            app.Groups.Modify(1, newData);
        }
    }
}
