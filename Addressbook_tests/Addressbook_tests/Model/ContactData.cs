using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname)
        {
            this.Firstname = firstname;
        }
        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Concat(Firstname, " ", Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
        }
        public string Firstname { get; set; } = "";
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string Home { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Work { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; } = "";
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; } = "";
        public string Bmonth { get; set; } = "-";
        public string Amonth { get; set; } = "-";
        public string Address2 { get; set; } = "";
        public string Phone2 { get; set; } = "";
        public string Notes { get; set; } = "";
        public string Bday { get; set; }
        public string Byear { get; set; } = "";
        public string Aday { get; set; } = "-";
        public string Ayear { get; set; } = "";

        public ContactData(string firstname, string middlename, string lastname, 
            string nickname, string title, string company, string address, string home,
            string mobile, string work, string fax, string email1, string email2, string email3,
            string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear,
            string address2, string phone2, string notes)
            
        {
            this.Firstname = firstname;
            this.Middlename = middlename;
            this.Lastname = lastname;
            this.Nickname = nickname;
            this.Title = title;
            this.Company = company;
            this.Address = address;
            this.Home = home;
            this.Homepage = homepage;
            this.Bday = bday;
            this.Bmonth = bmonth;
            this.Byear = byear;
            this.Company = company;
            this.Address = address;
        }
    }
}
