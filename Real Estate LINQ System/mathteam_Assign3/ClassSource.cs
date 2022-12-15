/****************************************************************************
 *                                                                          *
 *  Made by:                                                                *
 *      Francisco Banda (Z1912220)                                          *
 *                 &                                                        *
 *      Kyle Saysavanh  (Z1911954)                                          *
 *                                                                          *
 *  CSCI 473                                                                *
 *  Assignment 3 - Linq                                                     *
 *  Due: 3/3/22                                                             *
 *                                                                          *
 ****************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mathteam_Assign3
{
    public class ClassSource
    {
        /***
         * A class to input a line, and split into appropriate person details
         * 
         * @param Line(s)
         * 
         * @return Person details
         ****************************************************************************/
        public class Person : IComparable
        {
            // Declaring variables
            private readonly uint id;
            private string lastName;
            private string firstName;
            private string occupation;
            private readonly DateTime birthday;
            private List<uint> residenceIds = new List<uint>();

            // Constructor for Person
            public Person()
            {
                id = 0;
                lastName = firstName = occupation = "";
            }

            // Alt constructor for Person
            public Person(params string[] input)
            {
                // Declaring variables
                uint resId;
                int birthYear;
                int birthMonth;
                int birthDay;

                // Initializing variables
                UInt32.TryParse(input[0], out id);
                lastName = input[1];
                firstName = input[2];
                occupation = input[3];
                Int32.TryParse(input[4], out birthYear);
                Int32.TryParse(input[5], out birthMonth);
                Int32.TryParse(input[6], out birthDay);

                // Input resId
                for (int i = 7; i <= input.Length - 1; i++)
                {
                    UInt32.TryParse(input[i], out resId);
                    residenceIds.Add(resId);
                }

                // Assign Birthday properly
                DateTime checkBirthday = new DateTime(birthYear, birthMonth, birthDay);

                // Check if the birthday is in the future
                if (checkBirthday > DateTime.Now)
                {

                    return;
                }
                else
                {
                    birthday = checkBirthday;
                }
            }

            // Creating get/set property for ID
            public uint Id
            {
                get { return id; }
            }

            // Creating get/set property for Birthday
            public DateTime Birthday
            {
                get { return birthday; }
            }

            // Creating get/set property for age
            public int Age()
            {
                var today = DateTime.Today;
                var birthdate = Birthday;
                var age = today.Year - birthdate.Year;

                if (birthdate.Date > today.AddYears(-age))
                    age--;

                return age;
            }

            // Creating get/set property for residenceIds

            public ref List<uint> ResidenceIds
            {
                get { return ref residenceIds; }
            }

            // Creating get/set property for full name
            public string FullName
            {
                get { return lastName + ", " + firstName; }
            }

            // Creating get/set property for first name
            public string FirstName
            {
                get { return firstName; }
            }

            // Creating get/set property for occupation
            public string Occupation
            {
                get { return occupation; }
            }

            // Creating get/set property for name comparison
            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                    return 1;

                Person otherPerson = alpha as Person;
                if (otherPerson != null)
                    return this.FullName.CompareTo(otherPerson.FullName);
                else
                    throw new ArgumentNullException("Other person is null, could not continue.");
            }

            // Override ToString
            public override string ToString()
            {
                return FullName;
            }

        }

        /***
         * A class to input a line, and split into appropriate property details
         * 
         * @param Line(s)
         * 
         * @return Property details
         ****************************************************************************/
        public abstract class Property : IComparable
        {
            // Declaring variables
            private readonly uint id;
            private uint ownerID;
            private readonly uint x;
            private readonly uint y;
            private string streetAddr;
            private string city;
            private string state;
            private string zip;
            private bool forSale;
            private Nullable<int> price;

            // Default constructor for property
            public Property()
            {
                // Initializing variables
                ownerID = id = x = y = 0;
                forSale = false;
                streetAddr = city = state = zip = "";
            }

            // Alternative constructor for property
            public Property(params string[] input)
            {
                // Re-initializing variables
                UInt32.TryParse(input[0], out id);
                UInt32.TryParse(input[1], out ownerID);
                UInt32.TryParse(input[2], out x);
                UInt32.TryParse(input[3], out y);
                streetAddr = input[4];
                city = input[5];
                state = input[6];
                zip = input[7];

                // Input 8 takes if property is for sale,
                // so we initalize is here
                if (input[8] == "F")
                {
                    forSale = false;
                    price = null;
                }
                else
                {
                    forSale = true;

                    int temp;

                    int.TryParse(input[8].Substring(2), out temp);

                    price = temp;
                }
            }

            // Creating get/set property for Property ID
            public uint PropID
            {
                get { return id; }
            }

            // Creating get/set property for price
            public Nullable<int> Price
            {
                get { return price; }
            }

            // Creating get/set property for x coordinate
            public uint xcoord
            {
                get { return x; }
            }

            // Creating get/set property for y coordinate
            public uint ycoord
            {
                get { return y; }
            }

            // Creating get/set property for owner
            public uint Owner
            {
                get { return ownerID; }
            }

            // Creating get/set property for assigning owner
            public uint SetOwner
            {
                get { return ownerID; }
                set { ownerID = value; }
            }

            // Creating get/set property for address
            public string Address
            {
                get { return streetAddr; }
            }

            // Creating get/set property for city
            public string City
            {
                get { return city; }
            }

            // Creating get/set property for state
            public string State
            {
                get { return state; }
            }

            // Creating get/set property for zip
            public string Zip
            {
                get { return zip; }
            }

            // Creating get/set property for for sale status
            public bool Sale
            {
                get { return forSale; }
            }

            // Creating get/set property for set sale status
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

        /***
         * A class to input a line, and split into appropriate business details
         * 
         * @param Line(s)
         * 
         * @return Business details
         ****************************************************************************/
        public class Business : Property
        {
            // Declaring Business Name
            private string name;

            // Declaring business establishment (year)
            private readonly string yearEstablished;

            // Declaring a list of business types
            private readonly BusinessType type;
            enum BusinessType
            {
                Grocery,            // 0
                Bank,               // 1
                Repair,             // 2
                FastFood,           // 3
                DepartmentStore     // 4
            }

            // Declaring business recruitment status
            private uint activeRecruitment;

            // Business constructor
            public Business()
            {
                name = yearEstablished = "";
                activeRecruitment = 0;
            }

            // Business alt constructor, input 9, 10, 11, 12
            public Business(params string[] input) : base(input)
            {
                // Input business name
                name = input[9];

                // Input business type
                int temp = 0;
                Int32.TryParse(input[10], out temp);
                type = (BusinessType)temp;

                // Input year of business establishment
                yearEstablished = input[11];

                // Input amount of active recruitments
                UInt32.TryParse(input[12], out activeRecruitment);
            }

            // Creating get/set property for name
            public string Name
            {
                get { return name; }
            }

            // Creating get/set property for year established
            public string YearEstablished
            {
                get { return yearEstablished; }
            }

            // Creating get/set property for business type
            public string Type
            {
                get { return type.ToString(); }
            }

            // Creating get/set property for active recruitment
            public uint ActiveRecruitment
            {
                get { return activeRecruitment; }
            }

            // Creating an unimplemented PrintAddress
            public override string PrintAddress()
            {
                throw new NotImplementedException();
            }

            // CompareTo method, compares state, city, address
            public override int CompareTo(Object alpha)
            {
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

            // Creating an unimplemented CheckUnit
            public override bool CheckUnit(string check)
            {
                throw new NotImplementedException();
            }
        }

        /***
         * A class to input a line, and split into appropriate school details
         * 
         * @param Line(s)
         * 
         * @return School details
         ****************************************************************************/
        public class School : Property
        {
            // Declaring school name
            private string name;

            // Declaring school type
            private readonly SchoolType type;
            enum SchoolType
            {
                Elementary,         // 0
                HighSchool,         // 1
                CommunityCollege,   // 2
                University          // 3
            }

            // Declaring school establishment (year)
            private string yearEstablished;

            // Declaring enrollment status
            private uint enrolled;

            // School constructor
            public School()
            {
                // Initializing variables
                name = yearEstablished = "";
                enrolled = 0;
            }

            // School alt constructor, input 9, 10, 11
            public School(params string[] input) : base(input)
            {
                // Input school name
                name = input[9];

                // Input year school was established
                yearEstablished = input[10];

                // Input amount of enrollments
                UInt32.TryParse(input[11], out enrolled);
            }

            // Creating get/set property for school name
            public string Name
            {
                get { return name; }
            }

            // Creating get/set property for school type
            public string Type
            {
                get { return type.ToString(); }
            }

            // Creating get/set property for year school established
            public string YearEstablished
            {
                get { return yearEstablished; }
            }

            // Creating get/set property for enrollment count
            public uint Enrolled
            {
                get { return enrolled; }
            }

            // Creating unimplemented PrintAddress
            public override string PrintAddress()
            {
                throw new NotImplementedException();
            }

            // Creating CompareTo method, compares state, city, address
            public override int CompareTo(Object alpha)
            {
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

            // Creating unimplemented CheckUnit
            public override bool CheckUnit(string check)
            {
                throw new NotImplementedException();
            }
        }

        /***
         * A class to input a line, and split into appropriate residential details
         * 
         * @param Line(s)
         * 
         * @return Residential property details
         ****************************************************************************/
        public abstract class Residential : Property
        {
            // Declaring variables
            private uint bedrooms;
            private uint baths;
            private uint sqft;

            // Constructor for Residential
            public Residential(params string[] input) : base(input)
            {
                // Initializing variables
                UInt32.TryParse(input[9], out bedrooms);
                UInt32.TryParse(input[10], out baths);
                UInt32.TryParse(input[11], out sqft);
            }

            // Creating get/set property for bedrooms
            public uint Bedroom
            {
                get { return bedrooms; }
            }

            // Creating get/set property for baths
            public uint Baths
            {
                get { return baths; }
            }

            // Creating get/set property for sqft
            public uint Sqft
            {
                get { return sqft; }
            }
        }

        /***
         * A class to input a line, and split into appropriate house details
         * 
         * @param Line(s)
         * 
         * @return House details
         ****************************************************************************/
        public class House : Residential
        {
            // Declaring variables
            private bool garage;
            private Nullable<bool> attachedGarage;
            private uint floors;

            // Constructor for House
            public House(params string[] input) : base(input)
            {
                // Check if garage exists
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

                // Initializing floors amount
                UInt32.TryParse(input[14], out floors);
            }

            // Creating get/set property for garage
            public bool isGarage
            {
                get { return garage; }                
            }

            // Creating get/set property for attached garage
            public Nullable<bool> AttachedGarage
            {
                get { return attachedGarage; }
            }

            // Creating get/set property for floors
            public uint Floors
            {
                get { return floors; }
            }

            // Method to print garage status and floors
            public string Garage()
            {
                if (!isGarage)
                {
                    return "with no garage : " + Floors + " floors.";
                }
                else if ((bool)AttachedGarage)
                {
                    return "with an attached garage : " + Floors + " floors.";
                }
                else
                    return "with a detached garage : " + Floors + " floors.";
            }

            // Creating get/set property for apartment unit
            public override bool CheckUnit(string check)
            {
                return false;
            }

            // Format address properly
            public override string PrintAddress()
            {
                string street = ($"{Address}");
                string addr = " " + street.PadLeft(24) + " ";
                return addr;
            }

            // CompareTo method, compares state, city, address
            public override int CompareTo(Object alpha)
            {
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

        /***
         * A class to input a line, and split into appropriate apartment details
         * 
         * @param Line(s)
         * 
         * @return Apartment details
         ****************************************************************************/
        public class Apartment : Residential
        {
            // Declaring variables
            private string unit;

            // Constructor for apartment
            public Apartment(params string[] input) : base(input)
            {

                unit = input[input.Length - 1];
            }

            // Creating get/set property for unit
            public string Unit
            {
                get { return unit; }
            }

            // Method to override checkunit
            public override bool CheckUnit(string check)
            {
                if (check == Unit)
                    return true;
                else
                    return false;
            }

            // Method to format apartment address with unit
            public override string PrintAddress()
            {
                string street = ($"{Address} # {Unit}");
                string addr = " " + street.PadLeft(24) + " ";
                return addr;
            }

            // CompareTo method, compares state, city, address
            public override int CompareTo(Object alpha)
            {
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

        /***
         * A class to build a community with necessary community stuff
         * 
         * @param Mayor, community name
         * 
         * @return Community details
         ****************************************************************************/
        public class Community : IComparable, IEnumerable
        {
            SortedSet<Property> props = new SortedSet<Property>();
            SortedSet<Person> residents = new SortedSet<Person>();

            // Declaring variables
            private readonly uint id;
            private readonly string name;
            private uint mayorID;

            // Constructor for community
            public Community()
            {
                // Initialize variables
                id = mayorID = 0;
                name = "";
            }

            // Alternative constructor for community
            public Community(uint id, string name, uint mayorID, SortedSet<Property> props, SortedSet<Person> residents)
            {
                this.id = id;
                this.name = name;
                this.mayorID = mayorID;
                this.props = props;
                this.residents = residents;
            }

            // Creating get/set property for mayor ID
            public uint GetMayorId
            {
                get { return mayorID; }
            }

            // Creating get/set property for community name
            public string ComName
            {
                get { return name; }
            }

            // Method to find mayor, by ID
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

            // Creating get/set property for ID
            public string ID
            {
                get { return id.ToString(); }
            }

            // Creating get/set property for population
            public int Population
            {
                get { return residents.Count; }
            }

            // Creating get/set property for prop
            public ref SortedSet<Property> Prop
            {
                get { return ref props; }
            }

            // Creating get/set property for residents
            public ref SortedSet<Person> Residents
            {
                get { return ref residents; }
            }

            // CompareTo Method, compares communities
            public int CompareTo(Object alpha)
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

            // Method for GetEnumator
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public CommEnum GetEnumerator()
            {
                return new CommEnum(residents.ToArray<Person>());
            }

        }

        /***
         * A class for community enumator
         * 
         * @return Residents
         ****************************************************************************/
        public class CommEnum : IEnumerator
        {
            // Declaring variables
            public Person[] residents;

            // Setting position
            int position = -1;

            // Assigning the list
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
    }
}