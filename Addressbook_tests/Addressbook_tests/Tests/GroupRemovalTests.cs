using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
         {
            //проверка на наличие хотя бы одной группы в списке групп, если нет - создаем
            app.Groups.CheckGroupList();
            
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            //подсчет  и сравнение количества групп
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);

            //сравнение двух списков после удаления группы
            Assert.AreEqual(oldGroups, newGroups);

            //проверка, что id группы который был удален отсутствует в списке
            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }      
    }
}
    