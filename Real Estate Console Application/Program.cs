/****************************************************************************
 *                                                                          *
 *  Kyle Saysavanh & Francisco Banda                                        *
 *  CSCI 473                                                                *
 *  Assignment 1 - Building a Console Application for Real Estate           *
 *  1/29/2022                                                               *
 *                                                                          *
 *  Individual work is separated by initials in comments                    *
 *  Ex:   // K.S - Declaring Example Class                                  *
 *                                                                          *
 ****************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;

namespace mathteam_Assign1
{
    class Program
    {

        public class Person : IComparable
        {
            private readonly uint id;
            private string lastName;
            private string firstName;
            private string occupation;
            private readonly DateTime birthday;
            private List<uint> residenceIds = new List<uint>();

            public Person()                                             // F.B - Default Constructor
            {
                id = 0;
                lastName = firstName = occupation = "";
            }

            public Person(string inputStr)                     // F.B - Alt Constructor
            {                                                                                               // K.S - Fixed changed birthday -> birthDay

                uint resId;
                int birthYear;
                int birthMonth;
                int birthDay;

                string[] input = Regex.Split(inputStr, @"\t");          // F.B - Passing in values, separating by tab (\t)

                UInt32.TryParse(input[0], out id);
                lastName = input[1];
                firstName = input[2];
                occupation = input[3];
                Int32.TryParse(input[4], out birthYear);
                Int32.TryParse(input[5], out birthMonth);
                Int32.TryParse(input[6], out birthDay);
                UInt32.TryParse(input[7], out resId);                     // K.S - Fixed resID into adding it the list
                residenceIds.Add(resId);
                DateTime checkBirthday = new DateTime(birthYear, birthMonth, birthDay);         // K.S - Check for birthdays that are in the future
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

            public int Age()
            {
                var today = DateTime.Today;
                var birthdate = Birthday;
                var age = today.Year - birthdate.Year;

                if (birthdate.Date > today.AddYears(-age))
                    age--;

                return age;
            }

            public ref List<uint> ResidenceIds
            {
                get { return ref residenceIds; }
            }

            public string FullName
            {
                get { return lastName + ", " + firstName; }
            }

            public string Occupation
            {
                get { return occupation; }
            }

            public int CompareTo(Object alpha)                           // F.B - Comparing Two FullName's
            {
                if (alpha == null)
                    return 1;

                Person otherPerson = alpha as Person;
                if (otherPerson != null)
                    return this.FullName.CompareTo(otherPerson.FullName);
                else
                    throw new ArgumentException("Other person is null, could not continue.");
            }

            public override string ToString()                           // F.B - Override ToString
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

            public Property()                                       // K.S - Default Constructor
            {                                                       //    Setting all values to zero or ""
                ownerID = id = x = y = 0;
                forSale = false;
                streetAddr = city = state = zip = "";
            }

            public Property(string[] input)                        // K.S - Alt Constructor
            {                                                       //    Initializing with provided values
                                                                    // Initializing variables
                UInt32.TryParse(input[0], out id);
                UInt32.TryParse(input[1], out ownerID);
                UInt32.TryParse(input[2], out x);
                UInt32.TryParse(input[3], out y);

                streetAddr = input[4];
                city = input[5];
                state = input[6];
                zip = input[7];

                if (input[8] == "T")
                    forSale = true;
                else
                    forSale = false;
            }

            public uint PropID
            {
                get { return id; }
            }

            public uint Owner
            {
                get { return ownerID; }
            }

            public uint setOwner
            {
                get { return ownerID; }
                set { ownerID = value; }
            }

            public string Address
            {
                get { return streetAddr; }
            }

            public string City
            {
                get { return city; }
            }

            public string State
            {
                get { return state; }
            }

            public string Zip
            {
                get { return zip; }
            }

            public bool Sale
            {
                get { return forSale; }
            }

            public bool setSale
            {
                get { return forSale; }
                set { forSale = value; }
            }

            public abstract void printProp(Person owner);

            public abstract void printAddress();

            public abstract int CompareTo(Object alpha);

        }

        public abstract class Residential : Property
        {
            private uint bedrooms;
            private uint baths;
            private uint sqft;

            public Residential(string[] input) : base(input) // F.B - Residential Constructor
            {
                UInt32.TryParse(input[9], out bedrooms);
                UInt32.TryParse(input[10], out baths);
                UInt32.TryParse(input[11], out sqft);
            }

            public uint Bedroom
            {
                get { return bedrooms; }
            }

            public uint Baths
            {
                get { return baths; }
            }

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

            public House(string[] input) : base(input)              // F.B - House Constructor
            {                                                       // K.S - Remodeled house constructor
                //string[] input = Regex.Split(inputStr, @"\t");    // Moving this to main
                if (input[12] == "T")                               // K.S - Fixed/Added garage checker
                {                                                   //   Check for garage
                    garage = true;
                    if (input[13] == "T")                           // Check if its attached
                        attachedGarage = true;
                    else                                            // Else its a detached garage
                        attachedGarage = false;
                }
                else                                                // No garage then null attached garage
                {
                    garage = false;
                    attachedGarage = null;
                }

                UInt32.TryParse(input[14], out floors);
            }

            public override void printProp(Person owner)
            {
                string sale = "";
                string garageString = "";

                if (Sale)
                    sale = "FOR SALE";
                else
                    sale = "NOT for sale";

                if (garage == true && attachedGarage != null && attachedGarage == true)
                {

                    garageString = "... with an attached garage :";
                }

                else if (garage == true && attachedGarage != null && attachedGarage == false)
                {
                    garageString = "... with a detached garage :";
                }

                else
                {
                    garageString = "... with no garage :";
                }

                Console.WriteLine($"Property Address: {Address} / {City} / {State} / {Zip}");
                Console.WriteLine($"\tOwned by {owner.FullName}, Age ({owner.Age()}), Occupation: {owner.Occupation}");
                Console.WriteLine($"\t({sale}) {Bedroom}, bedrooms \\ {Baths} baths \\ {Sqft} sq.ft.");
                Console.WriteLine($"\t{garageString} {floors} floors.");
                Console.WriteLine("");
            }

            public override void printAddress()
            {
                Console.WriteLine($"{Address} {City}, {State}, {Zip}");
            }


            public override int CompareTo(Object alpha)                      // K.S - CompareTo Method
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

            public Apartment(string[] input) : base(input)          // F.B - Apartment Constructor
            {

                unit = input[input.Length - 1];                   // K.S - Removed = ""          
            }

            public string Unit
            {
                get { return unit; }
            }

            public override void printProp(Person owner)
            {
                string sale = "";

                if (Sale)
                    sale = "FOR SALE";
                else
                    sale = "NOT for sale";

                Console.WriteLine($"Property Address: {Address} / {City} / {State} / {Zip}");
                Console.WriteLine($"\tOwned by {owner.FullName}, Age {owner.Age()} Occupation: {owner.Occupation}");
                Console.WriteLine($"\t({sale}) {Bedroom}, bedrooms \\ {Baths} baths \\ {Sqft} sq.ft. Apt.# {Unit}");
                Console.WriteLine("");
            }

            public override void printAddress()
            {
                Console.WriteLine($"{Address} Apt.# {Unit} {City}, {State}, {Zip}");
            }

            public override int CompareTo(Object alpha)                      // K.S - CompareTo Method
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

            public Community()                  // K.S - Default Constructor
            {
                id = mayorID = 0;
                name = "";
            }

            public Community(uint id, string name, uint mayorID, SortedSet<Property> props, SortedSet<Person> residents) // F.B - Community Constructor
            {
                this.id = id;
                this.name = name;
                this.mayorID = mayorID;
                this.props = props;
                this.residents = residents;
            }

            public uint getMayorId
            {
                get { return mayorID; }
            }

            public string comName
            {
                get { return name; }
            }

            public string findMayor()
            {
                uint id = getMayorId;
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

            public string ID
            {
                get { return id.ToString(); }
            }

            public int Population                               // K.S - Get-only number of residents
            {
                get { return residents.Count; }
            }

            public SortedSet<Property> Prop
            {
                get { return props; }
            }

            public SortedSet<Person> Residents
            {
                get { return residents; }
            }

            public int CompareTo(Object alpha)                  // K.S - CompareTo Method
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

            IEnumerator IEnumerable.GetEnumerator()             // K.S - GetEnumerator Method
            {
                return (IEnumerator)GetEnumerator();
            }

            public CommEnum GetEnumerator()
            {
                return new CommEnum(residents.ToArray<Person>());
            }

        }

        public class CommEnum : IEnumerator                 // K.S - CommEnum Class
        {
            public Person[] residents;

            int position = -1;

            public CommEnum(Person[] list)
            {
                residents = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < residents.Length);
            }

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

        static void Menu()
        {

            Console.WriteLine(" 1. Full property list");
            Console.WriteLine(" 2. List addresses of either House or Apartment-type properties");
            Console.WriteLine(" 3. List addresses of all for-sale properties");
            Console.WriteLine(" 4. List all residents of a community");
            Console.WriteLine(" 5. List all residents of a property, by street address");
            Console.WriteLine(" 6. Toggle a property, by street address, as being for-sale or not.");
            Console.WriteLine(" 7. Buy a for-sale property, by street address");
            Console.WriteLine(" 8. Add yourself as an occupant to a property.");
            Console.WriteLine(" 9. Remove yourself as an occupant from a property");
            Console.WriteLine("10. Quit\n");

        }

        static void option1(Community DeKalb) //Apartment apart, House house)
        {
            Console.WriteLine($@"<{DeKalb.ID}> {DeKalb.comName}, Population ({DeKalb.Population}). Mayor: {DeKalb.findMayor()}");
            Console.WriteLine(new string('-', 30));
            SortedSet<Property> props = new SortedSet<Property>();
            props = DeKalb.Prop;
            foreach (Property prop in props)
            {
                Person owner = new Person();

                foreach (Person resident in DeKalb)
                {
                    if (prop.Owner == resident.Id)
                    {
                        owner = resident;
                        break;
                    }
                }

                prop.printProp(owner);
            }
        }

        static void option2(Community DeKalb)
        {
            Console.WriteLine("Enter property type (House/Apartment):");
            string givenString = Console.ReadLine();

            Console.WriteLine("\nList of addresses of " + givenString + " properties in the DeKalb community.");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("");
            foreach (Property prop in DeKalb.Prop)
            {
                if (givenString.Equals("Apartment", StringComparison.OrdinalIgnoreCase))
                {
                    if (prop is Apartment)
                    {
                        prop.printAddress();
                    }
                }
                else if (givenString.Equals("House", StringComparison.OrdinalIgnoreCase))
                {
                    if (prop is House)
                    {
                        prop.printAddress();
                    }
                }
                else
                {
                    Console.WriteLine("No property could be found for: " + givenString);
                }

            }
        }

        static void option3(Community DeKalb)
        {

            Console.WriteLine("\nList of addresses for all FOR SALE properties in the DeKalb community.");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("");

            foreach (Property prop in DeKalb.Prop)
            {
                if (prop.Sale)
                {
                    if (prop is House)
                    {
                        prop.printAddress();
                    }
                    if (prop is Apartment)
                    {
                        prop.printAddress();
                    }
                }

            }
        }

        static void option4(Community DeKalb)
        {
            foreach (Person resident in DeKalb)
            {
                Console.WriteLine(resident.FullName + ", Age: (" + resident.Age() + "), Occupation: " + resident.Occupation + "\n");
            }
        }

        static void option5(Community DeKalb)
        {
            Console.WriteLine("Enter the street address to lookup:");
            string givenAddress = Console.ReadLine();

            Console.WriteLine("\nList of residents living at " + givenAddress + ":");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("");

            foreach (Property prop in DeKalb.Prop)
            {
                if (prop.Address == givenAddress)
                {
                    foreach (Person resident in DeKalb)
                    {
                        //if (resident.Id == prop.Owner)
                        if (resident.ResidenceIds.Contains(prop.PropID)) 
                        {
                            Console.WriteLine(resident.FullName + ", Age: (" + resident.Age() + "), Occupation: " + resident.Occupation + "\n");
                        }
                    }
                }

            }
        }

        static void option6(Community DeKalb)
        {
            Console.WriteLine("Enter the street address to lookup:");
            string givenAddress = Console.ReadLine();

            foreach (Property prop in DeKalb.Prop)
            {
                if (prop.Address == givenAddress)
                {
                    if (prop.setSale == true)
                    {
                        Console.WriteLine(prop.Address + " is now listed as NOT for sale!\n");
                        prop.setSale = !prop.Sale;

                    }
                    else if (prop.setSale == false)
                    {
                        Console.WriteLine(prop.Address + " is now listed as FOR SALE!\n");
                        prop.setSale = !prop.Sale;
                    }
                }

            }
        }

        static void option7(Community DeKalb)
        {
            string givenAddress = "";

            Console.WriteLine("Enter the street address to lookup: ");
            givenAddress = Console.ReadLine();

            foreach (Property prop in DeKalb.Prop)
            {
                if (prop.Address == givenAddress)
                {
                    if (prop.Sale == true)
                    {
                        prop.setSale = false;
                        prop.setOwner = 0;
                        Console.WriteLine("Congratulations! You have successfully purchased this property!\n");
                        Person owner = new Person();

                        foreach (Person resident in DeKalb)
                        {
                            if (prop.Owner == resident.Id)
                            {
                                owner = resident;
                                break;
                            }
                        }
                        prop.printProp(owner);
                    }
                    else
                        Console.WriteLine("\nProperty is not for sale!");
                    return;
                }
            }
            Console.WriteLine($"\nWrong Address or Address is not recognized: '{givenAddress}'");
        }

        static void option8(ref Community DeKalb)
        {
            string givenAddress = "";
            uint propId = 0;
            
            Console.WriteLine("Enter the street address to lookup: ");
            givenAddress = Console.ReadLine();
            foreach (Property prop in DeKalb.Prop)
            {
                if (prop.Address == givenAddress)
                {
                    propId = prop.PropID;
                    foreach (Person resident in DeKalb)
                    {
                        if (resident.Id == 0)
                        {
                            List<uint> residenceIds = resident.ResidenceIds;
                            foreach (uint id in residenceIds)
                            {
                                if (id == propId)
                                {
                                    Console.WriteLine("You are already a resident at this property.");
                                    return;
                                }
                            }
                            resident.ResidenceIds.Add(propId);
                            Console.WriteLine("Success! You have been added as a resident at this property.");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine($"\nWrong Address or Address is not recognized: '{givenAddress}'");
            return;
        }

        static void option9(ref Community DeKalb)
        {
            Console.WriteLine("Enter the street address to lookup:");
            string givenAddress = Console.ReadLine();
            bool foundProperty = false;

            foreach (Property prop in DeKalb.Prop)
            {
                if (prop.Address == givenAddress)
                {
                   foundProperty = true;

                   foreach(Person resident in DeKalb)
                    {
                        if (resident.Id == 0)
                        {

                            if (!resident.ResidenceIds.Contains(prop.PropID))
                            {
                                Console.WriteLine("You do not currently reside at this property.");
                                return;
                            }

                            resident.ResidenceIds.Remove(prop.PropID);
                            Console.WriteLine("Success! You have been removed as a resident from this property.");
                        }
                    }
                }
            }

            if (!foundProperty)
            {
                Console.WriteLine("I'm sorry, I don't recognize this address: '" + givenAddress + "'.");
            }
        }

        static void Main(string[] args)
        {
            SortedSet<Property> props = new SortedSet<Property>();
            SortedSet<Person> residents = new SortedSet<Person>();

            // F.B - Read p.txt
            string inputFileP;

            using (StreamReader inFile = new StreamReader("p.txt"))
            {
                inputFileP = inFile.ReadLine(); // F.B - Priming the read
                while (inputFileP != null)
                {
                    residents.Add(new Person(inputFileP));
                    inputFileP = inFile.ReadLine();
                }
            }

            // F.B - Read r.txt
            string inputFileR;
            using (StreamReader inFile = new StreamReader("r.txt"))
            {
                inputFileR = inFile.ReadLine(); // F.B - Priming the read
                while (inputFileR != null)
                {
                    string[] input = Regex.Split(inputFileR, @"\t");
                    props.Add(new House(input));
                    inputFileR = inFile.ReadLine();
                }
            }

            // F.B - Read a.txt
            string inputFileA;
            using (StreamReader inFile = new StreamReader("a.txt"))
            {
                inputFileA = inFile.ReadLine(); // F.B - Priming the read
                while (inputFileA != null)
                {
                    string[] input = Regex.Split(inputFileA, @"\t");
                    props.Add(new Apartment(input));
                    inputFileA = inFile.ReadLine();
                }
            }

            uint id = 99999;
            string name = "DeKalb";
            uint mayorID = 0;
            Community DeKalb = new Community(id, name, mayorID, props, residents);


        // F.B - Jump back here if invalid input, or task is finished
        retryInput:
            Console.Clear();
            Menu();

            // F.B - Read Input
            string line = Console.ReadLine();

            // F.B - 10 Case | q, e, quit, exit, and 10 will all exit the program (uppercase as well)
            if (line.Equals("q", StringComparison.OrdinalIgnoreCase) || line.Equals("e", StringComparison.OrdinalIgnoreCase)
                || line.Equals("quit", StringComparison.OrdinalIgnoreCase) || line.Equals("exit", StringComparison.OrdinalIgnoreCase) || line == "10")
            {
                System.Environment.Exit(0);
            }

            // x - 9 Case
            else if (line == "9")
            {
                option9(ref DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 8 Case
            else if (line == "8")
            {
                option8(ref DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 7 Case
            else if (line == "7")
            {
                option7(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 6 Case
            else if (line == "6")
            {
                option6(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 5 Case
            else if (line == "5")
            {
                option5(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 4 Case
            else if (line == "4")
            {
                Console.WriteLine("List of all residents living in the DeKalb community.");

                Console.WriteLine(new string('-', 51));
                option4(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 3 Case
            else if (line == "3")
            {
                option3(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 2 Case
            else if (line == "2")
            {
                option2(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // x - 1 Case
            else if (line == "1")
            {
                option1(DeKalb);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            // F.B - Invalid Input
            else
            {
                Console.WriteLine("Unrecognized input, please select a valid option (1-10).");
                Console.WriteLine("Press any key to retry...");
                Console.ReadKey();
            }

            goto retryInput;

        }
    }
}