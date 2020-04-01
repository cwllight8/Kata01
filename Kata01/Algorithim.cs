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
            string phonePattern;
            phonePattern = @"[+]\d*[-]\d\d\d[-]\d\d\d[-]\d\d\d\d";
            Regex phoneRgx = new Regex(phonePattern);

            for (int i = 0; i < st.Count; i++)
            {
                string phone = "";
                if (phoneRgx.IsMatch(st[i]))
                {
                    phone = "is phone number";
                }
                string name = "name";
                string address = "address";


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
