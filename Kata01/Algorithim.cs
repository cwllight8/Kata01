using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata01
{
    public class Person
    {
        public string Name { get; set; }
        public string Num { get; set; }
        public string Address { get; set; }

        public Person(string name, string num, string address)
        {
            Name = name;
            Num = num;
            Address = address;
        }

        public override string ToString()
        {
            return "Phone => " + Num + ", Name => " + Name + ", Address => " + Address;
        }
    }

    public class Algorithim
    {
        NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;

        public List<Person> people = new List<Person>();

        public void seperate(string s)
        {
            List<string> st = s.Trim().Split('\n').ToList();
            string phonePattern = @"[+]\d*[-]\d{3}[-]\d{3}[-]\d{4}";
            Regex phoneRgx = new Regex(phonePattern);

            string namePattern = @"<.*>";
            Regex nameRgx = new Regex(namePattern);

            string addressPattern = @"([^a-z A-z.,0-9]|[_])";
            Regex addressRgx = new Regex(addressPattern);

            for (int i = 0; i < st.Count; i++)
            {
                string phone = "";
                string name = "";
                string address = "";
                if (phoneRgx.IsMatch(st[i]))
                {
                    phone = "";
                }
                else { break; }
                if (nameRgx.IsMatch(st[i]))
                {
                    name = "is name";
                }
                else { break; }
                if (addressRgx.IsMatch(st[i]))
                {
                    address = "is address";
                }
                
                people.Add(new Person(name, phone, address));
            }
        }

        public string Phone(string s, string num)
        {
            seperate(s);

            int count = 0;
            Person result = null;
            foreach (Person p in people)
            {
                if (p.Num.Equals(num))
                {
                    count++;
                    if (count > 1)
                    {
                        return "Error => Too many people: " + num;
                    }
                    result = p;
                }
            }
            if (result == null)
            {
                return "Error => Not found: " + num;
            }
            else
            {
                return result.ToString();
            }

        }

    }
}
