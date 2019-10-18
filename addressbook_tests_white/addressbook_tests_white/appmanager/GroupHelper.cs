using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using NUnit.Framework;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase 
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();            
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public void Remove()
        {
            Window dialogue = OpenGroupsDialogue();
           
            IUIItem textBox = dialogue.Get(SearchCriteria.ByControlType(ControlType.TreeItem));
            Win32TreeNode node = (Win32TreeNode)textBox;
            TreeNode myNode = node.Nodes[0];
            myNode.Click();
           
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            Window deleteGroup = dialogue.ModalWindow("Delete group");
            deleteGroup.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(dialogue);
        }
        public void CheckGroupList()
        {
            Window dialogue = OpenGroupsDialogue();

            IUIItem textBox = dialogue.Get(SearchCriteria.ByControlType(ControlType.TreeItem));

            Win32TreeNode node = (Win32TreeNode)textBox;
            int count = node.Nodes.Count();
            if (count <= 1)
            {
                CloseGroupsDialogue(dialogue);
                GroupData newGroup = new GroupData("Test123");
                Add(newGroup);
            }
            else
            {
                CloseGroupsDialogue(dialogue);
            }
        }
    }
}