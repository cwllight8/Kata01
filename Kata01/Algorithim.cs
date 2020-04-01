using System;
using System.Collections.Generic;
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
        public List<Person> people = new List<Person>();

        public void seperate(string s)
        {
            people.Clear();
            List<string> st = s.Trim().Split('\n').ToList();
            string phonePattern = @"\d*[-]\d{3}[-]\d{3}[-]\d{4}";
            Regex phoneRgx = new Regex(phonePattern);

            string namePattern = @"<.*>";
            Regex nameRgx = new Regex(namePattern);

            string addressPattern = @"([^a-z A-z.,0-9])";
            Regex addressRgx = new Regex(addressPattern);
            string extraPattern = @"\s{2,}";
            Regex extraSpaceRgx = new Regex(extraPattern);

            for (int i = 0; i < st.Count; i++)
            {
                string phone = "";
                string name = "";
                string address = "";

                Match phoneM = phoneRgx.Match(st[i]);
                Match nameM = nameRgx.Match(st[i]);

                if (phoneRgx.IsMatch(st[i]))
                {
                    phone = phoneM.Value;
                    st[i] = phoneRgx.Replace(st[i], "");
                }
                else { break; }
                if (nameRgx.IsMatch(st[i]))
                {
                    name = nameM.Value.Replace("<", "").Replace(">", "");
                    st[i] = nameRgx.Replace(st[i], "");
                }
                else { break; }
                st[i] = addressRgx.Replace(st[i], "");
                st[i] = extraSpaceRgx.Replace(st[i], " ");
                address = st[i].Replace("_", " ");

                people.Add(new Person(name, phone, address));
            }
        }

        public string phone(string s, string num)
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

    public class PhoneDir
    {

        public static List<Person> people = new List<Person>();

        public static void seperate(string s)
        {
            people.Clear();

            List<string> st = s.Trim().Split('\n').ToList();
            string phonePattern = @"\d*[-]\d{3}[-]\d{3}[-]\d{4}";
            Regex phoneRgx = new Regex(phonePattern);

            string namePattern = @"<.*>";
            Regex nameRgx = new Regex(namePattern);

            string addressPattern = @"([^a-z A-z.,\-0-9])";
            Regex addressRgx = new Regex(addressPattern);

            string extraPattern = @"\s{2,}";
            Regex extraSpaceRgx = new Regex(extraPattern);

            for (int i = 0; i < st.Count; i++)
            {
                string phone = "";
                string name = "";
                string address = "";

                Match phoneM = phoneRgx.Match(st[i]);
                Match nameM = nameRgx.Match(st[i]);

                if (phoneRgx.IsMatch(st[i]))
                {
                    phone = phoneM.Value;
                    st[i] = phoneRgx.Replace(st[i], "");
                }
                else { break; }
                if (nameRgx.IsMatch(st[i]))
                {
                    name = nameM.Value.Replace("<", "").Replace(">", "");
                    st[i] = nameRgx.Replace(st[i], "");
                }
                else { break; }
                st[i] = addressRgx.Replace(st[i], "");
                st[i] = extraSpaceRgx.Replace(st[i], " ");
                address = st[i].Replace("_", " ");

                people.Add(new Person(name.Trim(), phone.Trim(), address.Trim()));
            }
        }

        public static string Phone(string strng, string num)
        {
            seperate(strng);

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
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public string Num { get; set; }
    //    public string Address { get; set; }

    //    public Person(string name, string num, string address)
    //    {
    //        Name = name;
    //        Num = num;
    //        Address = address;
    //    }

    //    public override string ToString()
    //    {
    //        return "Phone => " + Num + ", Name => " + Name + ", Address => " + Address;
    //    }
    //}
}

