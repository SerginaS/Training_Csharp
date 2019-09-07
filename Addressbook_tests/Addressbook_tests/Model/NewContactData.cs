using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NewContactData
    {
        public string firstname { get; set; }
        public string middlename { get; set; } = "";
        public string lastname { get; set; } = "";
        public string nickname { get; set; } = "";
        public string title { get; set; } = "";
        public string company { get; set; } = "";
        public string address { get; set; } = "";
        public string home { get; set; } = "";
        public string mobile { get; set; } = "";
        public string work { get; set; } = "";
        public string fax { get; set; } = "";
        public string email { get; set; } = "";
        public string email2 { get; set; } = "";
        public string email3 { get; set; } = "";
        public string homepage { get; set; } = "";
        public string bmonth { get; set; } = "-";
        public string amonth { get; set; } = "-";
        public string address2 { get; set; } = "";
        public string phone2 { get; set; } = "";
        public string notes { get; set; } = "";
        public string bday { get; set; }
        public string byear { get; set; } = "";
        public string aday { get; set; } = "-";
        public string ayear { get; set; } = "";

        public NewContactData(string firstname, string middlename, string lastname, 
            string nickname, string title, string company, string address, string home,
            string mobile, string work, string fax, string email1, string email2, string email3,
            string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear,
            string address2, string phone2, string notes)
            
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.title = title;
            this.company = company;
            this.address = address;
            this.home = home;
            this.homepage = homepage;
            this.bday = bday;
            this.bmonth = bmonth;
            this.byear = byear;
            this.company = company;
            this.address = address;
        }
        public NewContactData(string firstname)
        {
            this.firstname = firstname;
        }

    }
}
