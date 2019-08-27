using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class NewContactData
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";

        public NewContactData(string firstname, string middlename, string lastname, 
            string nickname, string title, string company, string address, string home,
            string mobile, string work, string fax, string email1, string email2, string email3,
            string homepage, int bday, string bmonth, int byear, int aday, string amonth, int ayear,
            string address2, string phone2, string notes)
        {
            this.firstname = firstname;
        }
    }
}
