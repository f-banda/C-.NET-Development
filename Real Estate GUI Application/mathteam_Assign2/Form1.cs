/****************************************************************************
 *                                                                          *
 *  Made by:                                                                *
 *      Francisco Banda (Z1912220)                                          *
 *                 &                                                        *
 *      Kyle Saysavanh  (Z1911954)                                          *
 *                                                                          *
 *  CSCI 473                                                                *
 *  Assignment 2 - Practice Good Form                                       *
 *  Due: 2/17/22                                                            *
 *                                                                          *
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using static System.Windows.Forms.DomainUpDown;

namespace mathteam_Assign2
{
    public partial class Form1 : Form
    {
        public class Person : IComparable
        {
            private readonly uint id;
            private string lastName;
            private string firstName;
            private string occupation;
            private readonly DateTime birthday;
            private List<uint> residenceIds = new List<uint>();

            public Person()                                             // Default Constructor
            {
                id = 0;
                lastName = firstName = occupation = "";
            }

            public Person(string[] input)                     // Alt Constructor
            {

                uint resId;
                int birthYear;
                int birthMonth;
                int birthDay;
               
                UInt32.TryParse(input[0], out id);
                lastName = input[1];
                firstName = input[2];
                occupation = input[3];
                Int32.TryParse(input[4], out birthYear);
                Int32.TryParse(input[5], out birthMonth);
                Int32.TryParse(input[6], out birthDay);
                for (int i = 7; i <= input.Length-1; i++)
                {
                    UInt32.TryParse(input[i], out resId);                     // Fixed resID into adding it the list
                    residenceIds.Add(resId);
                }
                DateTime checkBirthday = new DateTime(birthYear, birthMonth, birthDay);         // Check for birthdays that are in the future
                if (checkBirthday > DateTime.Now)
                {

                    return;
                }
                else
                {
                    birthday = checkBirthday;
                }
            }

            public uint Id
            {
                get { return id; }
            }

            public DateTime Birthday
            {
                get { return birthday; }
            }

            // Get age function

            public int Age()
            {
                var today = DateTime.Today;
                var birthdate = Birthday;
                var age = today.Year - birthdate.Year;

                if (birthdate.Date > today.AddYears(-age))
                    age--;

                return age;
            }

            // residence ID's, made into ref for future purposes

            public ref List<uint> ResidenceIds
            {
                get { return ref residenceIds; }
            }

            // Combine lastName and firstName

            public string FullName
            {
                get { return lastName + ", " + firstName; }
            }

            // Just for FirstName

            public string FirstName
            {
                get { return firstName; }
            }

            // Occupation get/set

            public string Occupation
            {
                get { return occupation; }
            }

            // Compare two full names

            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                    return 1;

                Person otherPerson = alpha as Person;
                if (otherPerson != null)
                    return this.FullName.CompareTo(otherPerson.FullName);
                else
                    throw new ArgumentException("Other person is null, could not continue.");
            }

            // ToString override

            public override string ToString()
            {
                return FullName;
            }

        }

        public abstract class Property : IComparable
        {
            private readonly uint id;
            private uint ownerID;
            private readonly uint x;
            private readonly uint y;
            private string streetAddr;
            private string city;
            private string state;
            private string zip;
            private bool forSale;

            public Property()                                       // Default Constructor
            {                                                       // Setting all values to zero or ""
                ownerID = id = x = y = 0;
                forSale = false;
                streetAddr = city = state = zip = "";
            }

            public Property(string[] input)                         // Alt Constructor
            {

                UInt32.TryParse(input[0], out id);                  // Initializing with provided values
                UInt32.TryParse(input[1], out ownerID);             // Initializing variables
                UInt32.TryParse(input[2], out x);
                UInt32.TryParse(input[3], out y);
                streetAddr =    input[4];
                city       =    input[5];
                state      =    input[6];
                zip        =    input[7];

                // Input 8 takes if property is for sale,
                // so we initalize is here

                if (input[8] == "T")
                    forSale = true;
                else
                    forSale = false;
            }

            // Property ID get/set

            public uint PropID
            {
                get { return id; }
            }

            // Owner get/set

            public uint Owner
            {
                get { return ownerID; }
            }

            // OwnerID get/set, used to set the owner

            public uint SetOwner
            {
                get { return ownerID; }
                set { ownerID = value; }
            }

            // Address get/set

            public string Address
            {
                get { return streetAddr; }
            }

            // City get/set

            public string City
            {
                get { return city; }
            }

            // State get/set

            public string State
            {
                get { return state; }
            }

            // ZIP get/set

            public string Zip
            {
                get { return zip; }
            }

            // Property for sale? get/set

            public bool Sale
            {
                get { return forSale; }
            }

            // Set property status get/set

            public bool SetSale
            {
                get { return forSale; }
                set { forSale = value; }
            }

            // Making PrintAddress abstract

            public abstract string PrintAddress();

            // Making CompareTo abstract

            public abstract int CompareTo(Object alpha);

            // Making CheckUnit abstract

            public abstract bool CheckUnit(string check);

        }

        public abstract class Residential : Property
        {
            private uint bedrooms;
            private uint baths;
            private uint sqft;

            public Residential(string[] input) : base(input)    // Residential Constructor
            {
                UInt32.TryParse(input[9], out bedrooms);
                UInt32.TryParse(input[10], out baths);          // Initializing with provided values
                UInt32.TryParse(input[11], out sqft);
            }

            // Bedrooms amount, get/set

            public uint Bedroom
            {
                get { return bedrooms; }
            }

            // Baths amount, get/set

            public uint Baths
            {
                get { return baths; }
            }

            // Sqft amount, get/set

            public uint Sqft
            {
                get { return sqft; }
            }

        }

        public class House : Residential
        {
            private bool garage;
            private Nullable<bool> attachedGarage;
            private uint floors;

            public House(string[] input) : base(input)              // House Constructor
            {
                // Check for garage

                if (input[12] == "T")
                {
                    // Has garage
                    garage = true;

                    // Check if garage is attached/detached

                    if (input[13] == "T")
                        attachedGarage = true;
                    else
                        attachedGarage = false;
                }
                else
                {
                    garage = false;
                    attachedGarage = null;
                }

                // Input amount of building floors

                UInt32.TryParse(input[14], out floors);
            }

            // Apartment unit, get/set

            public override bool CheckUnit(string check)
            {
                return false;
            }

            // Formatted address

            public override string PrintAddress()
            {
                string street = ($"{Address}");
                string addr = " " + street.PadLeft(24) + " ";
                return addr;
            }

            public override int CompareTo(Object alpha)             //   CompareTo Method
            {                                                       //   Comparing State -> City -> Street -> Street Num
                if (alpha == null)
                    throw new ArgumentNullException();

                Property otherProperty = alpha as Property;

                if (otherProperty != null)
                {
                    var result = State.CompareTo(otherProperty.State);
                    if (result == 0)
                    {
                        result = City.CompareTo(otherProperty.City);
                        if (result == 0)
                        {
                            var otherStreet = otherProperty.Address.Split(' ').Skip(1).FirstOrDefault();

                            var street = Address.Split(' ').Skip(1).FirstOrDefault();
                            result = street.CompareTo(otherStreet);
                            if (result == 0)
                            {
                                var otherNum = otherProperty.Address.Split(' ').First();
                                var num = Address.Split(' ').First();
                                result = num.CompareTo(otherNum);
                            }
                        }
                    }
                    return result;
                }
                else
                    throw new ArgumentException("[Property]:CompareTo arguement is not a Property");
            }

        }

        public class Apartment : Residential
        {
            private string unit;

            public Apartment(string[] input) : base(input)          // Apartment Constructor
            {

                unit = input[input.Length - 1];       
            }

            public string Unit
            {
                get { return unit; }
            }

            public override bool CheckUnit(string check)
            {
                if (check == Unit)
                    return true;
                else
                    return false;
            }

            public override string PrintAddress()
            {
                string street = ($"{Address} # {Unit}");
                string addr = " " + street.PadLeft(24) + " ";
                return addr;
            }

            public override int CompareTo(Object alpha)                      // CompareTo Method
            {                                                                // Comparing State -> City -> Street -> Street Num
                if (alpha == null)
                    throw new ArgumentNullException();

                Property otherProperty = alpha as Property;

                if (otherProperty != null)
                {
                    var result = State.CompareTo(otherProperty.State);
                    if (result == 0)
                    {
                        result = City.CompareTo(otherProperty.City);
                        if (result == 0)
                        {
                            var otherStreet = otherProperty.Address.Split(' ').Skip(1).FirstOrDefault();

                            var street = Address.Split(' ').Skip(1).FirstOrDefault();
                            result = street.CompareTo(otherStreet);
                            if (result == 0)
                            {
                                var otherNum = otherProperty.Address.Split(' ').First();
                                var num = Address.Split(' ').First();
                                result = num.CompareTo(otherNum);
                                if (result == 0)
                                {
                                    Apartment otherApart = alpha as Apartment;
                                    result = Unit.CompareTo(otherApart.Unit);
                                }
                            }
                        }
                    }
                    return result;
                }
                else
                    throw new ArgumentException("[Property]:CompareTo arguement is not a Property");
            }

        }

        public class Community : IComparable, IEnumerable
        {
            SortedSet<Property> props = new SortedSet<Property>();
            SortedSet<Person> residents = new SortedSet<Person>();
            private readonly uint id;
            private readonly string name;
            private uint mayorID;

            public Community()                  // Default Constructor
            {
                id = mayorID = 0;
                name = "";
            }

            public Community(uint id, string name, uint mayorID, SortedSet<Property> props, SortedSet<Person> residents) // Community Constructor
            {
                this.id = id;
                this.name = name;
                this.mayorID = mayorID;
                this.props = props;
                this.residents = residents;
            }

            // Mayor ID get/set

            public uint GetMayorId
            {
                get { return mayorID; }
            }

            // Community Name, get/set

            public string ComName
            {
                get { return name; }
            }

            // Find out who the mayor is

            public string FindMayor()
            {
                uint id = GetMayorId;
                string mayor = "";
                SortedSet<Person> residentList = Residents;
                foreach (Person resident in residentList)
                {
                    if (id == resident.Id)
                    {
                        mayor = resident.FullName;
                        return mayor;
                    }
                }
                Console.WriteLine("Can't Find Mayor...");
                return mayor;
            }

            // ID get/set

            public string ID
            {
                get { return id.ToString(); }
            }

            // Get population, but later used a different method

            public int Population                               // Get-only number of residents
            {
                get { return residents.Count; }
            }

            // Property get/set, with ref for future use

            public ref SortedSet<Property> Prop
            {
                get { return ref props; }
            }

            // Residents get/set, with ref for future use

            public ref SortedSet<Person> Residents
            {
                get { return ref residents; }
            }

            public int CompareTo(Object alpha)                  // CompareTo Method
            {
                if (alpha == null)
                    throw new ArgumentNullException();

                Community otherCommunity = alpha as Community;

                if (otherCommunity != null)
                {
                    return name.CompareTo(otherCommunity.name);
                }
                else
                    throw new ArgumentException("[Community]:CompareTo arguement is not a Community");
            }

            IEnumerator IEnumerable.GetEnumerator()             // GetEnumerator Method
            {
                return (IEnumerator)GetEnumerator();
            }

            public CommEnum GetEnumerator()
            {
                return new CommEnum(residents.ToArray<Person>());
            }

        }

        public class CommEnum : IEnumerator                 // CommEnum Class
        {
            public Person[] residents;

            int position = -1;

            public CommEnum(Person[] list)
            {
                residents = list;
            }

            // Move to the next resident

            public bool MoveNext()
            {
                position++;
                return (position < residents.Length);
            }

            // Reset position

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Person Current
            {
                get
                {
                    try
                    {
                        return residents[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        // Returns a output of the Selected Resident personal information
        //              in detail and where they live

        static List<string> ResidentDetails(Community community, string name)   //Apartment apart, House house
        {
            Person owner = new Person();
            int age = 0;
            string[] info = Regex.Split(name, @"\s+");

            name = info[0];
            Int32.TryParse(info[1], out age);

            foreach (Person resident in community)
            {
                if (name == resident.FirstName && resident.Age() == age)
                {
                    owner = resident;
                    break;
                }
            }

            List<string> output = new List<string>();

            string tmp = owner.FullName + ", Age (" + owner.Age() + ") Occupation: " +
                            owner.Occupation + ", who resides at:";

            output.Add(tmp);

            foreach (uint id in owner.ResidenceIds)
            {
                foreach (Property prop in community.Prop)
                {
                    if (prop.PropID == id)
                    {
                        output.Add("\n\t" + prop.Address);
                    }
                }
            }
            return output;
        }

        // Returns a list of Properties and if they are on sale
        //      for current Selected community

        static List<string> ResidenceSaleInfo(Community community)
        {
            List<string> residence = new List<string>();

            residence.Add("Houses:");
            residence.Add(new string('-', 15));

            string temp;

            foreach (Property prop in community.Prop)
            {
                if (prop is House)
                {
                    if (prop.Sale)
                    {
                        temp = prop.PrintAddress() + "\u26A1";
                        residence.Add(temp.ToString());
                    }
                    else
                    {
                        temp = prop.PrintAddress();
                        residence.Add(temp.ToString());
                    }
                }
            }

            residence.Add("");
            residence.Add("Apartments:");
            residence.Add(new string('-', 15));
            foreach (Property prop in community.Prop)
            {
                if (prop is Apartment)
                {
                    if (prop.Sale)
                    {
                        temp = prop.PrintAddress() + "\u26A1";
                        residence.Add(temp.ToString());
                    }
                    else
                    {
                        temp = prop.PrintAddress();
                        residence.Add(temp.ToString());
                    }
                }
            }
            return residence;
        }



        // Returns a list of properties of current selected community

        static List<string> ResidenceInfo(Community community)
        {
            List<string> residence = new List<string>();

            residence.Add("Houses:");
            residence.Add(new string('-', 15));

            string temp;

            foreach (Property prop in community.Prop)
            {
                if (prop is House)
                {
                    temp = prop.PrintAddress();
                    temp = temp.Trim();
                    residence.Add(temp.ToString());
                }
            }

            residence.Add("");
            residence.Add("Apartments:");
            residence.Add(new string('-', 15));
            foreach (Property prop in community.Prop)
            {
                if (prop is Apartment)
                {
                    temp = prop.PrintAddress();
                    temp = temp.Trim();
                    residence.Add(temp.ToString());
                }
            }
            return residence;
        }



        // Truncate long strings and replace with (...)

        static string Truncate(string variable, int Length)
        {
            if (string.IsNullOrEmpty(variable)) return variable;
            return variable.Length <= Length ? variable : variable.Substring(0, Length) + "...";
        }



        // Returns a list of Residents living in the
        //      current selected Community

        static List<string> ResidentInfo(Community community)
        {
            List<string> residents = new List<string>();
            string res = "";
            string occ = "";
            string fname = "";
            string age = "";
            foreach (Person resident in community)
            {
                occ = resident.Occupation;
                occ = Truncate(occ,12);
                fname = resident.FirstName;
                fname = fname.PadRight(9) + " ";
                age = resident.Age().ToString();
                age = age.PadRight(3) + " ";
                res = fname + age + occ;
                residents.Add(res);
            }
            return residents;
        }



        // Returns an output for Selected Property
        //      and who owns the property and who lives there

        static List<string> ResidenceDetails(Community community, string address)
        {
            List<string> output = new List<string>();
            uint ownerID;
            string unit = "";
            bool ifApartment = false;
            string apt = "";
            bool notFoundR = true;              // If resident is not found
            bool notFoundP = true;              // If address is not found

            address = address.Replace("\u26A1", "");

            if (address.Contains("#"))
            {
                string[] apartment = Regex.Split(address, "#");
                address = apartment[0];
                unit = apartment[1];
                ifApartment = true;
            }

            address = address.Trim();
            unit = unit.Trim();

            foreach (Property prop in community.Prop)
            {
                if (prop.Address == address)
                {
                    if (ifApartment)                        // If it is a apartment check for unit
                    {
                        apt = " # " + unit;
                        if (prop is Apartment)
                        {
                            if (!prop.CheckUnit(unit))          // If unit is not matching property
                            {
                                continue;
                            }
                        }
                        else
                            continue;
                    }

                    notFoundP = false;
                    ownerID = prop.Owner;

                    foreach (Person resident in community)
                    {
                        if (ownerID == resident.Id)
                        {
                            notFoundR = false;
                            output.Add("Residents living at " + address + apt + ", " + community.ComName +
                                            ", owned by " + resident.FullName + ":\n");
                            output.Add(new string('-', 75));
                            break;
                        }
                    }

                    foreach (Person resident in community)
                    {
                        //if (resident.Id == prop.Owner)
                        if (resident.ResidenceIds.Contains(prop.PropID))
                        {
                            notFoundR = false;
                            string age = "";
                            age += resident.Age();
                            output.Add("\n" + resident.FullName.PadRight(25) + age.PadRight(4) + resident.Occupation.PadLeft(30));
                        }
                    }

                    break;
                }

            }

            if (notFoundP)                                         // If address is not found
                output.Add("Invalid: Address not found...");
            else if (notFoundR)                                    // No one lives at this address
                output.Add("No one lives here...");

            return output;
        }



        // Check if property is already owned and if its on sale Then buy property

        static (Community, string) BuyProperty(Community community, string address, string name)
        {
            uint ownerID = 0;
            string unit = "";
            bool ifApartment = false;
            string apt = "";
            string error = "";
            int age = 0;
            (Community, string) output;

            address = address.Replace("\u26A1", "");

            if (address.Contains("#"))
            {
                string[] apartment = Regex.Split(address, "#");
                address = apartment[0];
                unit = apartment[1];
                ifApartment = true;
            }

            address = address.Trim();
            unit = unit.Trim();

            string[] info = Regex.Split(name, @"\s+");

            name = info[0];
            Int32.TryParse(info[1], out age);

            foreach (Person resident in community)                  // Get ownerID
            {
                if (resident.FirstName == name && resident.Age() == age)
                {
                    ownerID = resident.Id;
                    break;
                }
            }

            foreach (Property prop in community.Prop)       // Set Owner if Bought
            {
                if (prop.Address == address)
                {
                    if (ifApartment)                        // If it is a apartment check for unit
                    {
                        apt = " # " + unit;
                        if (prop is Apartment)
                        {
                            if (!prop.CheckUnit(unit))          // If unit is not matching property
                            {
                                continue;
                            }
                        }
                        else
                            continue;
                    }

                    if (prop.Sale == false)
                    {
                        error = "Error: " + address + apt + " is not for Sale!";
                        output.Item1 = community;
                        output.Item2 = error;
                        return output;
                    }
                    else if (prop.Sale == true)
                    {
                        if (ownerID != prop.Owner)
                        {
                            prop.SetSale = false;
                            prop.SetOwner = ownerID;
                            output.Item1 = community;
                            output.Item2 = error;
                            return output;
                        }
                        else
                        {
                            error = "Error: " + name + " already owns the property at " + address + apt + " !!!";
                            output.Item1 = community;
                            output.Item2 = error;
                            return output;
                        }
                    }
                    break;
                }
            }
            output.Item1 = community;
            output.Item2 = "Error: Address not found!";
            return output;
        }

        static (Community, string) AddResident(Community community, string address, string name)
        {
            uint propID = 0;
            string unit = "";
            bool ifApartment = false;
            string apt = "";
            string error = "";
            int age = 0;
            (Community, string) output;

            address = address.Replace("\u26A1", "");

            if (address.Contains("#"))
            {
                string[] apartment = Regex.Split(address, "#");
                address = apartment[0];
                unit = apartment[1];
                ifApartment = true;
            }

            address = address.Trim();
            unit = unit.Trim();

            string[] info = Regex.Split(name, @"\s+");

            name = info[0];
            Int32.TryParse(info[1], out age);

            foreach (Property prop in community.Prop)       // Set Owner if Bought
            {
                if (prop.Address == address)
                {
                    if (ifApartment)                        // If it is a apartment check for unit
                    {
                        apt = " # " + unit;
                        if (prop is Apartment)
                        {
                            if (!prop.CheckUnit(unit))          // If unit is not matching property
                            {
                                continue;
                            }
                        }
                        else
                            continue;
                    }
                    propID = prop.PropID;
                    break;
                }
            }

            foreach (Person resident in community)                  // Get ownerID
            {
                if (resident.FirstName == name && resident.Age() == age)
                {
                    if (resident.ResidenceIds.Contains(propID))
                    {
                        error = "Error: " + name + " already resides at " + address + apt + " !!!";
                    }
                    else
                    {
                        resident.ResidenceIds.Add(propID);
                    }
                    break;
                }
            }

            output.Item1 = community;
            output.Item2 = error;
            return output;
        }

        // Remove a resident from the community

        static (Community, string) RemoveResident(Community community, string address, string name)
        {
            // Initialize variables
            uint propID = 0;
            string unit = "";
            bool ifApartment = false;
            string apt = "";
            string error = "";
            int age = 0;
            (Community, string) output;

            // Replace lightning bolt with nothing
            address = address.Replace("\u26A1", "");

            // If the address contains "#", then it's an apartment
            if (address.Contains("#"))
            {
                // Split at "#"
                string[] apartment = Regex.Split(address, "#");
                address = apartment[0];
                unit = apartment[1];
                ifApartment = true;
            }
            // Remove extra spacing from address and unit
            address = address.Trim();
            unit = unit.Trim();

            string[] info = Regex.Split(name, @"\s+");

            name = info[0];
            Int32.TryParse(info[1], out age);

            foreach (Property prop in community.Prop)       // Set Owner if Bought
            {
                if (prop.Address == address)
                {
                    if (ifApartment)                        // If it is a apartment check for unit
                    {
                        apt = " # " + unit;
                        if (prop is Apartment)
                        {
                            if (!prop.CheckUnit(unit))          // If unit is not matching property
                            {
                                continue;
                            }
                        }
                        else
                            continue;
                    }
                    propID = prop.PropID;
                    break;
                }
            }

            foreach (Person resident in community)                  // Get ownerID
            {
                if (resident.FirstName == name && resident.Age() == age)
                {
                    if (resident.ResidenceIds.Contains(propID))
                    {
                        resident.ResidenceIds.Remove(propID);
                    }
                    else
                    {
                        error = "Error: " + name + " does not reside at " + address + apt + " !!!";
                    }
                    break;
                }
            }

            output.Item1 = community;
            output.Item2 = error;
            return output;
        }

        static SortedSet<Property> readProperty(string house, string apartment)
        {
            SortedSet<Property> props = new SortedSet<Property>();
            List<string> ids = new List<string>();

            // F.B - Read r.txt
            string inputFileR;
            using (StreamReader inFile = new StreamReader(house))
            {
                inputFileR = inFile.ReadLine(); // F.B - Priming the read
                while (inputFileR != null)
                {
                    string[] input = Regex.Split(inputFileR, @"\t");
                    if (!ids.Contains(input[0]))                        // Checking for dulplicate ID's
                    {
                        ids.Add(input[0]);
                        props.Add(new House(input));
                        inputFileR = inFile.ReadLine();
                    }
                    else                                                // Skip To next Line if Dulplicate is found
                    {
                        inputFileR = inFile.ReadLine();
                    }
                }
            }

            // F.B - Read a.txt
            string inputFileA;
            //ids = new List<string>();

            using (StreamReader inFile = new StreamReader(apartment))
            {
                inputFileA = inFile.ReadLine(); // F.B - Priming the read
                while (inputFileA != null)
                {
                    string[] input = Regex.Split(inputFileA, @"\t");
                    if (!ids.Contains(input[0]))                        // Checking for dulplicate ID's
                    {
                        ids.Add(input[0]);
                        props.Add(new Apartment(input));
                        inputFileA = inFile.ReadLine();
                    }
                    else                                                // Skip To next Line if Dulplicate is found
                    {
                        inputFileA = inFile.ReadLine();
                    }
                }
            }

            return props;
        }

        static SortedSet<Person> readPerson(string person)
        {
            SortedSet<Person> residents = new SortedSet<Person>();
            List<string> ids = new List<string>();
            // F.B - Read p.txt
            string inputStr;

            using (StreamReader inFile = new StreamReader(person))
            {
                inputStr = inFile.ReadLine(); // F.B - Priming the read
                while (inputStr != null)
                {
                    string[] input = Regex.Split(inputStr, @"\t");          // Passing in values, separating by tab (\t)
                    if (!ids.Contains(input[0]))                            // Checking for dulplicate ID's
                    {
                        ids.Add(input[0]);
                        residents.Add(new Person(input));
                        inputStr = inFile.ReadLine();
                    }
                    else                                                // Skip To next Line if Dulplicate is found
                    {
                        inputStr = inFile.ReadLine();
                    }
                }
            }

            return residents;
        }

        static Community makeCommunity(string communityName)
        {
            SortedSet<Property> props = new SortedSet<Property>();
            SortedSet<Person> residents = new SortedSet<Person>();
            Community temp = new Community();

            uint id = 99999;
            uint mayorID = 0;

            string person = communityName + "/p.txt";
            string house = communityName + "/r.txt";
            string apartment = communityName + "/a.txt";

            residents = readPerson(person);
            props = readProperty(house, apartment);
            temp = new Community(id, communityName, mayorID, props, residents);
            return temp;
        }


        //------------//
        // Form Stuff //
        //------------//

        bool mouseDown;
        private Point offset;

        Community DeKalb;
        Community Sycamore;
        string CurrentCommunity = "";
        int num = 300;

        public Form1()
        {
            InitializeComponent();

            // Making the DeKalb and Sycamore communities

            DeKalb = makeCommunity("DeKalb");
            Sycamore = makeCommunity("Sycamore");

            int dekalbCount = 0;
            int sycamoreCount = 0;

            // Primary output, used this method because I don't like .Count

            foreach (Person resident in DeKalb.Residents)
            {
                dekalbCount++;
            }

            foreach (Person resident in Sycamore.Residents)
            {
                sycamoreCount++;
            }

            // Formatted output

            rich_Output.AppendText("There are " + dekalbCount + " people living in DeKalb." +
                                    "\n" + "There are " + sycamoreCount + " people living in Sycamore.");

        }

        /*  
         *  Start of draggable window events below, since
         *  form border was removed for personal visual candy
         *  + Exit button
         *  
         */

        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if(mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * 
         *  End of borderless window settings
         * 
         */

        // DeKalb Bubble Selection, reset list and print

        private void comm_DeKalb_CheckedChanged(object sender, EventArgs e)
        {
            CurrentCommunity = "DeKalb";

            this.list_Person.DataSource = null;

            this.list_Person.Items.Clear();

            this.list_Person.DataSource = ResidentInfo(DeKalb);

            this.list_Person.ClearSelected();

            this.list_Person.SelectedIndex = -1;

            this.list_Residence.DataSource = null;

            this.list_Residence.Items.Clear();

            this.list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

            this.list_Residence.ClearSelected();

            this.list_Residence.SelectedIndex = -1;

            List<string> temp = new List<string>();

            temp = ResidenceInfo(DeKalb);

            string[] properties = temp.ToArray();

            this.comboBox1.Items.Clear();

            this.comboBox1.Items.AddRange(properties);

            rich_Output.Clear();
            rich_Output.AppendText("The residents and properties of DeKalb are now listed.");
        }

        // Sycamore Bubble Selection, reset list and print

        private void comm_Sycamore_CheckedChanged(object sender, EventArgs e)
        {
            CurrentCommunity = "Sycamore";

            this.list_Person.DataSource = null;

            this.list_Person.Items.Clear();

            this.list_Person.DataSource = ResidentInfo(Sycamore);

            this.list_Person.ClearSelected();

            this.list_Person.SelectedIndex = -1;

            this.list_Residence.DataSource = null;

            this.list_Residence.Items.Clear();

            this.list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

            this.list_Residence.ClearSelected();

            this.list_Residence.SelectedIndex = -1;

            List<string> temp = new List<string>();

            temp = ResidenceInfo(Sycamore);

            string[] properties = temp.ToArray();

            this.comboBox1.Items.Clear();

            this.comboBox1.Items.AddRange(properties);

            rich_Output.Clear();
            rich_Output.AppendText("The residents and properties of Sycamore are now listed.");
        }


        // Toggle for Sale button

        private void button_toggleSale_Click(object sender, EventArgs e)
        {
            string unit = "";
            string addy;

            // If no address is selected

            if (list_Residence.SelectedIndex == -1)
            {
                rich_Output.Clear();
                MessageBox.Show("Please select an address first!");
            }
            else // If address is selected, store to "addy" and remove formatting
            {
                addy = list_Residence.SelectedItem.ToString();

                addy = addy.Replace("\u26A1", "");

                addy = addy.Trim();

                // If community is DeKalb, house/apartment

                if(CurrentCommunity == "DeKalb")
                {
                    foreach (Property prop in DeKalb.Prop)
                    {
                        if (prop.Address == addy)
                        {
                            if (prop.Sale == true)
                            {
                                prop.SetSale = !prop.Sale;

                                list_Residence.DataSource = null;

                                list_Residence.Items.Clear();

                                list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                                rich_Output.Clear();

                                rich_Output.AppendText(addy + " is now listed as NOT for sale!");
                            }
                            else if (prop.Sale == false)
                            {
                                prop.SetSale = !prop.Sale;

                                list_Residence.DataSource = null;

                                list_Residence.Items.Clear();

                                list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                                rich_Output.Clear();

                                rich_Output.AppendText(addy + " is now listed FOR SALE!");
                            }
                            break;
                        }
                        else if (addy.Contains("#"))
                        {
                            string[] apartment = Regex.Split(addy, "#");
                            string street = "";
                            street = apartment[0];
                            unit = apartment[1];
                            street = street.Trim();
                            unit = unit.Trim();

                            if (prop.Address == street && prop.CheckUnit(unit))
                            {
                                if (prop.Sale == true)
                                {
                                    prop.SetSale = !prop.Sale;

                                    list_Residence.DataSource = null;

                                    list_Residence.Items.Clear();

                                    list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                                    rich_Output.Clear();

                                    rich_Output.AppendText(street + " # " + unit + " is now listed as NOT for sale!");
                                }
                                else if (prop.Sale == false)
                                {
                                    prop.SetSale = !prop.Sale;

                                    list_Residence.DataSource = null;

                                    list_Residence.Items.Clear();

                                    list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                                    rich_Output.Clear();

                                    rich_Output.AppendText(street + " # " + unit + " is now listed FOR SALE!");
                                }
                                break;
                            }
                        }

                    }

                }

                // If community is Sycamore, house/apartment

                else if (CurrentCommunity == "Sycamore")
                {
                    foreach (Property prop in Sycamore.Prop)
                    {
                        if (prop.Address == addy)
                        {
                            if (prop.Sale == true)
                            {
                                prop.SetSale = !prop.Sale;

                                list_Residence.DataSource = null;

                                list_Residence.Items.Clear();

                                list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                                rich_Output.Clear();

                                rich_Output.AppendText(addy + " is now listed as NOT for sale!");
                            }
                            else if (prop.Sale == false)
                            {
                                prop.SetSale = !prop.Sale;

                                list_Residence.DataSource = null;

                                list_Residence.Items.Clear();

                                list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                                rich_Output.Clear();

                                rich_Output.AppendText(addy + " is now listed FOR SALE!");
                            }
                            break;
                        }
                        else if (addy.Contains("#"))
                        {
                            string[] apartment = Regex.Split(addy, "#");
                            string street = "";
                            street = apartment[0];
                            unit = apartment[1];
                            street = street.Trim();
                            unit = unit.Trim();

                            if (prop.Address == street && prop.CheckUnit(unit))
                            {
                                if (prop.Sale == true)
                                {
                                    prop.SetSale = !prop.Sale;

                                    list_Residence.DataSource = null;

                                    list_Residence.Items.Clear();

                                    list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                                    rich_Output.Clear();

                                    rich_Output.AppendText(street + " # " + unit + " is now listed as NOT for sale!");
                                }
                                else if (prop.Sale == false)
                                {
                                    prop.SetSale = !prop.Sale;

                                    list_Residence.DataSource = null;

                                    list_Residence.Items.Clear();

                                    list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                                    rich_Output.Clear();

                                    rich_Output.AppendText(street + " # " + unit + " is now listed FOR SALE!");
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        // If an item in Residence List is selected

        private void list_Residence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.list_Residence.SelectedIndex != -1)
            {
                List<string> output = new List<string>();
                string item = this.list_Residence.SelectedItem.ToString();

                // Prevents selection of items that aren't an address
                if (item == "Houses:" || item == "Apartments:" || item == (new string('-', 15)) || item == "")
                {
                    rich_Output.Clear();
                    this.list_Residence.SelectedIndex = -1;
                    this.list_Residence.ClearSelected();
                }
                else
                {
                    if (CurrentCommunity == "DeKalb")
                    {
                        output = ResidenceDetails(DeKalb, item);
                    }
                    else if (CurrentCommunity == "Sycamore")
                    {
                        output = ResidenceDetails(Sycamore, item);
                    }

                    rich_Output.Clear();

                    foreach (string line in output)
                    {
                        rich_Output.AppendText(line);
                    }

                    rich_Output.AppendText("\n\n### END OUTPUT ###");
                }
            }
        }

        // If an item in Person list is selected

        private void list_Person_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.list_Person.SelectedIndex != -1)
            {
                List<string> output = new List<string>();
                string item = this.list_Person.SelectedItem.ToString();

                if (CurrentCommunity == "DeKalb")
                {
                    output = ResidentDetails(DeKalb, item);
                }
                else if (CurrentCommunity == "Sycamore")
                {
                    output = ResidentDetails(Sycamore, item);
                }

                rich_Output.Clear();

                foreach (string line in output)
                {
                    rich_Output.AppendText(line);
                }

                rich_Output.AppendText("\n\n### END OUTPUT ###");
            }
        }

        // Buy Property Button

        private void button_buyProperty_Click(object sender, EventArgs e)
        {
            // No selection, error checking

            if (list_Person.SelectedIndex == -1 && list_Residence.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person and a residence!");
            }
            else if (list_Person.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person!");
            }
            else if (list_Residence.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a residence!");
            }
            else // Property and person is selected, continue
            {
                // Store selected person and property
                string person  = list_Person.SelectedItem.ToString();
                string address = list_Residence.SelectedItem.ToString();

                if (CurrentCommunity == "DeKalb")
                {
                    (Community com, string error) temp = BuyProperty(DeKalb, address, person);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        DeKalb = com;

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                        rich_Output.Clear();

                        rich_Output.AppendText("Property has been successfully bought!");

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                }
                else if (CurrentCommunity == "Sycamore")
                {
                    (Community com, string error) temp = BuyProperty(Sycamore, address, person);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        Sycamore = com;

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                        rich_Output.Clear();

                        rich_Output.AppendText("Property has been successfully bought!");

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                }
            }
        }

        // Remove resident button

        private void button_removeResident_Click(object sender, EventArgs e)
        {
            // No selection, error checking

            if (list_Person.SelectedIndex == -1 && list_Residence.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person and a residence!");
            }
            else if (list_Person.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person!");
            }
            else if (list_Residence.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a residence!");
            }
            else // Person and property are selected, continue
            {
                string person = list_Person.SelectedItem.ToString();
                string address = list_Residence.SelectedItem.ToString();

                if (CurrentCommunity == "DeKalb")
                {
                    (Community com, string error) temp = RemoveResident(DeKalb, address, person);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        DeKalb = com;

                        list_Person.DataSource = null;

                        list_Person.Items.Clear();

                        list_Person.DataSource = ResidentInfo(DeKalb);

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                        rich_Output.Clear();

                        rich_Output.AppendText("Resident has been successfully removed from property!");

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                }
                else if (CurrentCommunity == "Sycamore")
                {
                    (Community com, string error) temp = RemoveResident(Sycamore, address, person);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        Sycamore = com;

                        list_Person.DataSource = null;

                        list_Person.Items.Clear();

                        list_Person.DataSource = ResidentInfo(Sycamore);

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                        rich_Output.Clear();

                        rich_Output.AppendText("Resident has been successfully removed from property!");

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                }
            }
        }

        // Added resident button

        private void button_AddResident_Click(object sender, EventArgs e)
        {
            // No selection, error checking

            if (list_Person.SelectedIndex == -1 && list_Residence.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person and a residence!");
            }
            else if (list_Person.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person!");
            }
            else if (list_Residence.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a residence!");
            }
            else // Person and property are selected, continue
            {
                string person = list_Person.SelectedItem.ToString();
                string address = list_Residence.SelectedItem.ToString();

                if (CurrentCommunity == "DeKalb")
                {
                    (Community com, string error) temp = AddResident(DeKalb, address, person);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        DeKalb = com;

                        list_Person.DataSource = null;

                        list_Person.Items.Clear();

                        list_Person.DataSource = ResidentInfo(DeKalb);

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                        rich_Output.Clear();

                        rich_Output.AppendText("Resident has been successfully added to property!");

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                }
                else if (CurrentCommunity == "Sycamore")
                {
                    (Community com, string error) temp = AddResident(Sycamore, address, person);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        Sycamore = com;

                        list_Person.DataSource = null;

                        list_Person.Items.Clear();

                        list_Person.DataSource = ResidentInfo(Sycamore);

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                        rich_Output.Clear();

                        rich_Output.AppendText("Resident has been successfully added to property!");

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                }
            }
        }

        // If garage checkbox is checked, make attached checkbox visible

        private void bool_Garage_CheckedChanged(object sender, EventArgs e)
        {
            if (bool_Garage.Checked)
            {
                bool_attachedGarage.Visible = true;
            }
            else
            {
                bool_attachedGarage.Visible = false;
            }
        }

        // If apartment unit is entered, disable garage and attached checkbox
        // If apartment unit is entered, disable floors (default to 1)

        private void input_AptNum_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(input_AptNum.Text))
            {
                bool_Garage.Visible = true;
                input_Floors.Value = 1;
                input_Floors.Enabled = true;
            }
            else
            {
                bool_Garage.Checked = false;
                bool_attachedGarage.Checked = false;
                bool_Garage.Visible = false;
                bool_attachedGarage.Visible = false;
                input_Floors.Value = 1;
                input_Floors.Enabled = false;
            }
        }

        /*

        Beginning of add property

        */

        private void button_addNewProperty_Click(object sender, EventArgs e)
        {
            uint uid = 0;
            uint ownerID = uint.MaxValue;
            uint zip = 0;

            // Randomize x and y coords

            Random rnd = new Random();

            int xcord = rnd.Next(1, 250);
            int ycord = rnd.Next(1, 250);

            string input = "";
            string address = "";
            string unit = "";
            string garage = "";
            string attachedGarage = "";
            string city = "";
            string state = "Illinois";
            string forSale = "T";

            decimal sqft = 0;
            decimal bedrooms = 0;
            decimal baths = 0;
            decimal floors = 0;

            bool isApartment;

            // Beginning of error checking and storing values

            if (CurrentCommunity != "DeKalb" && CurrentCommunity != "Sycamore")
            {
                MessageBox.Show("Please select a community!");
            }

            if (String.IsNullOrEmpty(input_Address.Text))
            {
                MessageBox.Show("Please input an address!");
            }
            else
            {
                address = input_Address.Text;
            }

            if (input_SqrFt.Value < 500 || input_SqrFt.Value > 10000)
            {
                MessageBox.Show("Invalid Square Footage Specified");
            }
            else
            {
                sqft = input_SqrFt.Value;
            }

            if (input_Floors.Value <= 0 || input_Floors.Value > 10)
            {
                MessageBox.Show("Invalid Floors Specified");
            }
            else
            {
                floors = input_Floors.Value;
            }

            if (input_Baths.Value <= 0 || input_Baths.Value > 10)
            {
                MessageBox.Show("Invalid Baths Specified");
            }
            else
            {
                baths = input_Baths.Value;
            }

            if (input_Bedrooms.Value <= 0 || input_Bedrooms.Value > 10)
            {
                MessageBox.Show("Invalid Bedrooms Specified");
            }
            else
            {
                bedrooms = input_Bedrooms.Value;
            }

            if (!String.IsNullOrEmpty(input_AptNum.Text))
            {
                unit = input_AptNum.Text;
                isApartment = true;
                bool_Garage.Checked = false;
            }
            else
            {
                isApartment = false;
            }

            if (bool_Garage.Checked)
            {
                garage = "T";
            }
            else
            {
                garage = "F";
            }

            if (bool_attachedGarage.Checked)
            {
                attachedGarage = "T";
            }
            else
            {
                attachedGarage = "F";
            }
            
            // End of error checking and storing values

            // Assigning new house to DeKalb community

            if (CurrentCommunity == "DeKalb" && isApartment == false)
            {
                city = CurrentCommunity;
                zip = 60115;

                foreach (Property prop in DeKalb.Prop)
                {
                    if (prop.PropID >= uid)
                    {
                        uid = prop.PropID + 1;
                    }
                }

                input = (uid + "\t" + ownerID + "\t" + xcord + "\t" + ycord + "\t" + address + "\t" + city + "\t"
                            + state + "\t" + zip + "\t" + forSale + "\t" + bedrooms + "\t" + baths + "\t" + sqft
                            + "\t" + garage + "\t" + attachedGarage + "\t" + floors);

                string[] tempinput = Regex.Split(input, @"\t");

                DeKalb.Prop.Add(new House(tempinput));

                list_Residence.DataSource = null;

                list_Residence.Items.Clear();

                list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                // Reset input values
                input_Address.Clear();
                input_SqrFt.Value = 500;
                input_Baths.Value = 1;
                input_Bedrooms.Value = 1;
                input_Floors.Value = 1;
                input_AptNum.Clear();
                bool_attachedGarage.Checked = false;
                bool_Garage.Checked = false;

                rich_Output.Clear();
                rich_Output.AppendText("Success! A new property has been added to DeKalb!");
            }

            // Assigning new apartment to DeKalb community

            else if (CurrentCommunity == "DeKalb" && isApartment == true)
            {
                city = CurrentCommunity;
                zip = 60115;

                foreach (Property prop in DeKalb.Prop)
                {
                    if (prop.PropID >= uid)
                    {
                        uid = prop.PropID + 1;
                    }
                }

                input = (uid + "\t" + ownerID + "\t" + xcord + "\t" + ycord + "\t" + address + "\t" + city + "\t"
                            + state + "\t" + zip + "\t" + forSale + "\t" + bedrooms + "\t" + baths + "\t" + sqft
                            + "\t" + unit);

                string[] tempinput = Regex.Split(input, @"\t");
                DeKalb.Prop.Add(new Apartment(tempinput));

                list_Residence.DataSource = null;

                list_Residence.Items.Clear();

                list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                // Reset input values
                input_Address.Clear();
                input_SqrFt.Value = 500;
                input_Baths.Value = 1;
                input_Bedrooms.Value = 1;
                input_Floors.Value = 1;
                input_AptNum.Clear();

                rich_Output.Clear();
                rich_Output.AppendText("Success! A new property has been added to DeKalb!");
            }

            // Assigning new house to Sycamore community

            else if (CurrentCommunity == "Sycamore" && isApartment == false)
            {
                city = CurrentCommunity;
                zip = 60115;

                foreach (Property prop in Sycamore.Prop)
                {
                    if (prop.PropID >= uid)
                    {
                        uid = prop.PropID + 1;
                    }
                }

                input = (uid + "\t" + ownerID + "\t" + xcord + "\t" + ycord + "\t" + address + "\t" + city + "\t"
                            + state + "\t" + zip + "\t" + forSale + "\t" + bedrooms + "\t" + baths + "\t" + sqft
                            + "\t" + garage + "\t" + attachedGarage + "\t" + floors);

                string[] tempinput = Regex.Split(input, @"\t");
                Sycamore.Prop.Add(new House(tempinput));

                list_Residence.DataSource = null;

                list_Residence.Items.Clear();

                list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                // Reset input values
                input_Address.Clear();
                input_SqrFt.Value = 500;
                input_Baths.Value = 1;
                input_Bedrooms.Value = 1;
                input_Floors.Value = 1;
                input_AptNum.Clear();
                bool_attachedGarage.Checked = false;
                bool_Garage.Checked = false;

                rich_Output.Clear();
                rich_Output.AppendText("Success! A new property has been added to Sycamore!");
            }

            // Assigning new apartment to Sycamore community

            else if (CurrentCommunity == "Sycamore" && isApartment == true)
            {
                city = CurrentCommunity;
                zip = 60115;

                foreach (Property prop in Sycamore.Prop)
                {
                    if (prop.PropID >= uid)
                    {
                        uid = prop.PropID + 1;
                    }
                }

                input = (uid + "\t" + ownerID + "\t" + xcord + "\t" + ycord + "\t" + address + "\t" + city + "\t"
                            + state + "\t" + zip + "\t" + forSale + "\t" + bedrooms + "\t" + baths + "\t" + sqft
                            + "\t" + unit);

                string[] tempinput = Regex.Split(input, @"\t");
                Sycamore.Prop.Add(new Apartment(tempinput));

                list_Residence.DataSource = null;

                list_Residence.Items.Clear();

                list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                // Reset input values
                input_Address.Clear();
                input_SqrFt.Value = 500;
                input_Baths.Value = 1;
                input_Bedrooms.Value = 1;
                input_Floors.Value = 1;
                input_AptNum.Clear();

                rich_Output.Clear();
                rich_Output.AppendText("Success! A new property has been added to Sycamore!");
            }
        }

        /*

        End of add property

        */

        // ******************

        /*

        Beginning of add person

        */

        private void input_Birthday_ValueChanged(object sender, EventArgs e)
        {
            DateTime date;

            date = input_Birthday.Value;

            if (date > DateTime.Today)
            {
                rich_Output.Clear();
                rich_Output.AppendText("Error: Birthdays cannot be a future date...");
                input_Birthday.Value = DateTime.Today;
            }
            else if (date != DateTime.Today)
            {
                rich_Output.Clear();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = this.comboBox1.Text;

            rich_Output.Clear();

            // Prevents selection of items that aren't an address
            if (item == "Houses:" || item == "Apartments:" || item == (new string('-', 15)))
            {
                rich_Output.Clear();
                rich_Output.AppendText("Error: Please select a valid address...");
                this.comboBox1.ResetText();
            }

        }

        private void button_AddNewResident_Click(object sender, EventArgs e)
        {
            rich_Output.Clear();
            string fullname;
            string[] name;
            string[] tempperson;
            string firstName;
            string lastName;
            string address;
            int year;
            int month;
            int day;
            string person;
            string occupation;
            string pep;
            int age;

            DateTime date = input_Birthday.Value;

            year = date.Year;
            month = date.Month;
            day = date.Day;

            occupation = input_Occupation.Text.ToString();

            address = this.comboBox1.Text;

            fullname = input_Name.Text.ToString();

            name = Regex.Split(fullname, " ");

            if (input_Name.Text == "")
            {
                rich_Output.Clear();
                rich_Output.AppendText("Error: Please input a name...");
            }
            else if (name.Length < 1)
            {
                rich_Output.Clear();
                rich_Output.AppendText("Error: Name doesn't have a space between first and last name...");
            }
            else if (String.IsNullOrEmpty(occupation))
            {
                rich_Output.AppendText("Error: Please enter an occupation for this new resident...");
            }
            else if (address == "")
            {
                rich_Output.Clear();
                rich_Output.AppendText("Error: No residence is selected!\nPlease select a residence...");
            }
            else
            {
                firstName = name[0];
                lastName = name[1];
                person = num + "\t" + lastName + "\t" + firstName + "\t" + occupation + "\t" +
                                year + "\t" + month + "\t" + day;
                num += 6;
                age = DateTime.Today.Year - year;
                pep = firstName + "   " + age;
                if (CurrentCommunity == "DeKalb")
                {
                    tempperson = Regex.Split(person, @"\t");
                    DeKalb.Residents.Add(new Person(tempperson));
                    (Community com, string error) temp = AddResident(DeKalb, address, pep);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        DeKalb = com;

                        list_Person.DataSource = null;

                        list_Person.Items.Clear();

                        list_Person.DataSource = ResidentInfo(DeKalb);

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(DeKalb);

                        input_Name.Clear();

                        input_Occupation.Clear();

                        input_Birthday.Value = DateTime.Today;

                        comboBox1.ResetText();

                        rich_Output.AppendText("Resident has been successfully added to property!");
                    }
                }
                else if (CurrentCommunity == "Sycamore")
                {
                    tempperson = Regex.Split(person, @"\t");
                    Sycamore.Residents.Add(new Person(tempperson));
                    (Community com, string error) temp = AddResident(Sycamore, address, pep);
                    string error = temp.error;
                    Community com = temp.com;
                    if (error != "")
                    {
                        rich_Output.Clear();

                        rich_Output.AppendText(error);

                        rich_Output.AppendText("\n\n### END OUTPUT ###");
                    }
                    else
                    {
                        Sycamore = com;

                        list_Person.DataSource = null;

                        list_Person.Items.Clear();

                        list_Person.DataSource = ResidentInfo(Sycamore);

                        list_Residence.DataSource = null;

                        list_Residence.Items.Clear();

                        list_Residence.DataSource = ResidenceSaleInfo(Sycamore);

                        input_Name.Clear();

                        input_Occupation.Clear();

                        input_Birthday.Value = DateTime.Today;

                        comboBox1.ResetText();

                        rich_Output.AppendText("Resident has been successfully added to property!");
                    }
                }
            }
        }
    }
}