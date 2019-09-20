﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            //подсчет  и сравнение количества групп
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
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
    