﻿using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string detailsInformation;

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
        public string Firstname { get; set; } = "";
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string WorkPhone { get; set; } = "";
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
        public string Id { get; set; }
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
