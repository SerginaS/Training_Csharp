using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
         {
            //проверка на наличие хотя бы одной группы в списке групп, если нет - создаем
            app.Groups.CheckGroupList();

            app.Groups.Remove(1);
        }      
    }
}
