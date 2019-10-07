using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Linq;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string detailsInformation;

        public ContactData()
        {
        }

        public ContactData(string firstname)
        {
            Firstname = firstname;
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
            if(Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; } = "";

        [Column(Name = "middlename")]
        public string Middlename { get; set; } = "";

        [Column(Name = "lastname")]
        public string Lastname { get; set; } = "";

        [Column(Name = "nickname")]
        public string Nickname { get; set; } = "";

        [Column(Name = "title")]
        public string Title { get; set; } = "";

        [Column(Name = "company")]
        public string Company { get; set; } = "";

        [Column(Name = "address")]
        public string Address { get; set; } = "";

        [Column(Name = "home")]
        public string HomePhone { get; set; } = "";

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; } = "";

        [Column(Name = "work")]
        public string WorkPhone { get; set; } = "";

        [Column(Name = "fax")]
        public string Fax { get; set; } = "";

        [Column(Name = "email")]
        public string Email { get; set; } = "";

        [Column(Name = "email2")]
        public string Email2 { get; set; } = "";

        [Column(Name = "email3")]
        public string Email3 { get; set; } = "";

        [Column(Name = "firstname")]
        public string Homepage { get; set; } = "";

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; } = "-";

        [Column(Name = "amonth")]
        public string Amonth { get; set; } = "-";

        [Column(Name = "address2")]
        public string Address2 { get; set; } = "";

        [Column(Name = "phone2")]
        public string Phone2 { get; set; } = "";

        [Column(Name = "notes")]
        public string Notes { get; set; } = "";

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; } = "";

        [Column(Name = "aday")]
        public string Aday { get; set; } = "-";

        [Column(Name = "ayear")]
        public string Ayear { get; set; } = "";

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
               allPhones = value;
            }
        }
        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                   return allEmail;
                }
                else
                {
                    return (NextLine(Email) + NextLine(Email2) + Email3).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }
        public string DetailsInformation
        {
            get
            {
                if (detailsInformation != null)
                {
                    return detailsInformation;
                }
                else
                {
                    return (Firstname + " " + NextLine(Lastname) + NextLine(Address) + "\r\n"
                        +  NextLine(HomePhone).Insert(0, "H: ") + NextLine(MobilePhone).Insert (0, "M: ") 
                        + NextLine(WorkPhone).Insert(0, "W: ") + "\r\n" + NextLine(Email) 
                        + NextLine(Email2) + NextLine(Email3)).Trim();
                }
            }
            set
            {
                detailsInformation = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string NextLine(string item)
        {
            if (item == null || item == "")
            {
                return "";
            }
            return item + "\r\n";
        }


        public ContactData(string firstname, string middlename, string lastname, 
            string nickname, string title, string company, string address, string homephone,
            string mobilephone, string workphone, string fax, string email1, string email2, string email3,
            string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear,
            string address2, string phone2, string notes)
            
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Nickname = nickname;
            Title = title;
            Company = company;
            Address = address;
            HomePhone = homephone;
            MobilePhone = mobilephone;
            WorkPhone = workphone;
            Homepage = homepage;
            Bday = bday;
            Bmonth = bmonth;
            Byear = byear;
            Company = company;
        }        
    }
}
