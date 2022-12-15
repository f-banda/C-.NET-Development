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
using static mathteam_Assign3.ClassSource;

namespace mathteam_Assign3
{
    public partial class QueryForm : Form
    {

        /***
         * A function to format properties with price to output.
         * 
         * @param props A sorted list of properties by price.
         * @param people A list of residents to identify the owner.
         * 
         * @return A list of strings containing the formatted properties to output.
         ****************************************************************************/
        static List<string> FormatOutputPrice(IEnumerable<IGrouping<string, Property>> input, SortedSet<Person> people)
        {
            List<string> output = new List<string>();               // List of output string
            string name = "";                                       // Property Owner's Name
            string price = "";                                      // Price of property
            string temp = "";                                       // A temp for the output string
            bool flag = true;
            bool flagtwo = true;

            IEnumerable<Property> prop = input.OrderBy(group => group.First()).SelectMany(group => group);
            List<Property> props = prop.ToList();

            foreach (Property i in props)                           // Go through each property
            {
                if (i.City == "DeKalb" && flag)                     // If city is DeKalb
                {
                    output.Add("\t#### DeKalb ####\n");
                    output.Add("");                                 // Label DeKalb and un-flag
                    flag = false;
                }
                if (i.City == "Sycamore" && flagtwo)                // If city is Sycamore
                {
                    output.Add("\t#### Sycamore ####\n");           // Label and un-flagtwo
                    output.Add("");
                    flagtwo = false;
                }

                foreach (Person owner in people)                    // Go through all the residents
                {
                    if (i.Owner == owner.Id)                        // If owner id matches
                    {
                        name = owner.FullName;                      // Save property owner's name
                        break;                                      // Once found break from loop
                    }
                }

                if (i is Business)                                  // If property is a business
                {
                    Business b = (Business)i;                       // Casting i back to Business object 
                    temp = b.Address + " " + b.City + ", " + b.State + " " + b.Zip;
                    output.Add(temp);
                    price = String.Format("{0: $0,000}", b.Price);    // Format price to $000,000
                    temp = "Owner: " + name + " |\t" + price;
                    output.Add(temp);
                    temp = b.Name + ", a " + b.Type + " type of business, established in " + b.YearEstablished;
                    output.Add(temp);
                    output.Add("");
                }
                else if (i is School)                               // If property is a school
                {
                    School s = (School)i;                           // Casting is fun
                    temp = s.Address + " " + s.City + ", " + s.State + " " + s.Zip + " | Owner: " + name;
                    output.Add(temp);
                    temp = s.Name + ", established in " + s.YearEstablished;
                    output.Add(temp);
                    price = String.Format("{0: $0,000}", s.Price);
                    temp = s.Enrolled + " students enrolled\t" + price;
                    output.Add(temp);
                    output.Add("");
                }
                else if (i is House)                                // If property is a house
                {
                    House h = (House)i;                             // Let's go casting
                    temp = h.Address + " " + h.City + ", " + h.State + " " + h.Zip;
                    output.Add(temp);
                    temp = "Owner: " + name + " | " + h.Bedroom + " beds, " + h.Baths + " baths, " + h.Sqft + " sq.ft.";
                    output.Add(temp);
                    price = String.Format("{0: $0,000}", h.Price);
                    temp = h.Garage() + "\t" + price;    // Garage() returns string no, attach, or detach garage
                    output.Add(temp);
                    output.Add("");
                }
                else if (i is Apartment)                            // If property is a apartment
                {
                    Apartment a = (Apartment)i;                     // More casting
                    temp = a.Address + " Apt.#" + a.Unit + " " + a.City + ", " + a.State + " " + a.Zip;
                    output.Add(temp);
                    price = String.Format("{0: $0,000}", a.Price);
                    temp = "Owner: " + name + " | " + a.Bedroom + " beds, " + a.Baths + " baths, " + a.Sqft + " sq.ft.    " + price;
                    output.Add(temp);
                    output.Add("");
                }
            }

            if (!prop.Any())
            {
                output.Add("Your query yielded no matches.\n");
            }

            return output;                                          // Return list of output strings
        }



        /***
         * A file reading function to read property.
         *
         * @params house A string holding the house file path.
         * @params apartment A string holding the apartment file path.
         *
         * @return A sortedset of the properties of both house and apartment.
         *************************************************************************/
        static SortedSet<Property> ReadProperty(string house, string apartment)
        {
            SortedSet<Property> props = new SortedSet<Property>();
            List<string> ids = new List<string>();

            // Read r.txt
            string inputFileR;
            using (StreamReader inFile = new StreamReader(house))
            {
                inputFileR = inFile.ReadLine();                         // Priming the read
                while (inputFileR != null)
                {
                    string[] input = Regex.Split(inputFileR, @"\t");
                    if (!ids.Contains(input[0]))                        // Checking for duplicate ID's
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

            // Read a.txt
            string inputFileA;

            using (StreamReader inFile = new StreamReader(apartment))
            {
                inputFileA = inFile.ReadLine();                         // Priming the read
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



        /***
         * A file reading function to read person.
         *
         * @params person A string holding the person file path.
         *
         * @return A sortedset of person.
         *************************************************************************/
        static SortedSet<Person> ReadPerson(string person)
        {
            SortedSet<Person> residents = new SortedSet<Person>();
            List<string> ids = new List<string>();
            // F.B - Read p.txt
            string inputStr;

            using (StreamReader inFile = new StreamReader(person))
            {
                inputStr = inFile.ReadLine();           // F.B - Priming the read
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



        /***
         * A file reading function to read business.
         *
         * @params business A string holding the business file path.
         *
         * @return A sortedset of the properties of business.
         *************************************************************************/
        static SortedSet<Property> ReadBusiness(string business)
        {
            SortedSet<Property> businesses = new SortedSet<Property>();
            List<string> ids = new List<string>();

            string inputStr;

            using (StreamReader inFile = new StreamReader(business))
            {
                inputStr = inFile.ReadLine();                           // Priming the read
                while (inputStr != null)
                {
                    string[] input = Regex.Split(inputStr, @"\t");
                    if (!ids.Contains(input[0]))                        // Checking for dulplicate ID's
                    {
                        ids.Add(input[0]);
                        businesses.Add(new Business(input));
                        inputStr = inFile.ReadLine();
                    }
                    else                                                // Skip To next Line if Dulplicate is found
                    {
                        inputStr = inFile.ReadLine();
                    }
                }
            }

            return businesses;
        }



        /***
         * A file reading function to read school.
         *
         * @params school A string holding the school file path.
         *
         * @return A sortedset of the properties of school.
         *************************************************************************/
        static SortedSet<Property> ReadSchool(string school)
        {
            SortedSet<Property> schools = new SortedSet<Property>();
            List<string> ids = new List<string>();

            string inputStr;

            using (StreamReader inFile = new StreamReader(school))
            {
                inputStr = inFile.ReadLine();                           // Priming the read
                while (inputStr != null)
                {
                    string[] input = Regex.Split(inputStr, @"\t");
                    if (!ids.Contains(input[0]))                        // Checking for dulplicate ID's
                    {
                        ids.Add(input[0]);
                        schools.Add(new School(input));
                        inputStr = inFile.ReadLine();
                    }
                    else                                                // Skip To next Line if Dulplicate is found
                    {
                        inputStr = inFile.ReadLine();
                    }
                }
            }

            return schools;
        }


        /***
         * A function to make a community object with the combined objects.
         *
         * @params communityName A string containing the name of the Community, also
         *                              needed for the path of the file.
         *
         * @return A community object of with the given properties and residents.
         ******************************************************************************/
        static Community MakeCommunity(uint id, string communityName)
        {
            SortedSet<Property> props = new SortedSet<Property>();
            SortedSet<Person> residents = new SortedSet<Person>();
            SortedSet<Property> businesses = new SortedSet<Property>();
            SortedSet<Property> schools = new SortedSet<Property>();
            Community temp = new Community();

            //uint id = 99999;                                    // Mayor info
            uint mayorID = 0;

            string person = communityName + "/p.txt";           // Make File path
            string house = communityName + "/r.txt";
            string apartment = communityName + "/a.txt";
            string business = communityName + "/b.txt";
            string school = communityName + "/s.txt";

            residents = ReadPerson(person);                     // Read files
            props = ReadProperty(house, apartment);
            businesses = ReadBusiness(business);
            schools = ReadSchool(school);

            foreach (Property b in businesses)                  // Add business and school objects
            {                                                   //  to props
                props.Add(b);
            }
            foreach (Property s in schools)
            {
                props.Add(s);
            }

            temp = new Community(id, communityName, mayorID, props, residents);     // Make community object

            return temp;                                        // Return community object
        }


        //------------//
        // Form Stuff //
        //------------//

        bool mouseDown;
        private Point offset;

        Community DeKalb;
        Community Sycamore;
        string CurrentCommunity = "";
        Community D = new Community();
        Community S = new Community();


        /***
         * A function for QueryForm itself (app)
         * 
         * @param Properties to fill lists
         * 
         * @return A list of schools/properties
         ****************************************************************************/
        public QueryForm()
        {
            InitializeComponent();

            // Making the DeKalb and Sycamore communities

            DeKalb = MakeCommunity(0,"DeKalb");
            Sycamore = MakeCommunity(1,"Sycamore");
            D = MakeCommunity(5, "DeKalb");
            S = MakeCommunity(10, "Sycamore");

            // Making the School combo box list

            comboBox_School.SelectedIndex = -1;             // Clear selections
            comboBox_ForSaleResidence.SelectedIndex = -1;

            SortedSet<Property> props = new SortedSet<Property>();
            props = DeKalb.Prop;
            SortedSet<Property> sycamore = new SortedSet<Property>(); 
            sycamore = Sycamore.Prop;

            foreach (Property s in sycamore)                // Combined both cities into one object
            {
                props.Add(s);
            }

            var SchoolQuery =                               // Query and get city name and school name
                from N in props
                where N is School
                orderby ((School)N).City
                select (N.City , ((School)N).Name);         // Returns (city name, school name)

            List<string> output = new List<string>();       // Output List for combo box
            bool flag = true;                               // Check flags to add headers
            bool flagtwo = true;

            foreach ((string,string) s in SchoolQuery)      // Cycle through all the schools
            {
                if (s.Item1 == "DeKalb" && flag)            // Check to add headers
                {
                    output.Add("DeKalb:");
                    output.Add(new string('-', 10));
                    flag = false;
                }
                if (s.Item1 == "Sycamore" && flagtwo)
                {
                    output.Add("");
                    output.Add("Sycamore:");
                    output.Add(new string('-', 10));
                    flagtwo = false;
                }

                output.Add(s.Item2);                        // Add School to output list
            }

            comboBox_School.Items.AddRange(output.ToArray<string>());           // Output to combo box for school

            output = new List<string>();

            // Query and get house, sale, city, and address
            var Houses =
                from N in props
                where N is House && N.Sale
                select (N.City, N.Address, "");

            // Query and get apartment, sale, city, and address
            var Apartments =
                from N in props
                where N is Apartment && N.Sale
                select (N.City, N.Address, ((Apartment)N).Unit);

            // Query to concat houses & apartments into AddressQuery
            var AddressQuery = Houses.Concat(Apartments);

            // Query to order AddressQuery (ascending)
            AddressQuery =
                from N in AddressQuery
                orderby N.Item1 ascending
                select (N.Item1, N.Item2, N.Item3);

            // Initializing flags
            flag = true;
            flagtwo = true;
            bool flagthree = true;
            bool flagfour = true;

            foreach ((string, string, string) s in AddressQuery)      // Cycle through all the schools
            {
                if (s.Item1 == "DeKalb" && flag)            // Check to add headers
                {
                    output.Add("DeKalb:");
                    output.Add(new string('-', 10));
                    flag = false;
                }
                if (s.Item1 == "Sycamore" && flagtwo)
                {
                    output.Add("");
                    output.Add("Sycamore:");
                    output.Add(new string('-', 10));
                    flagtwo = false;
                }

                if (s.Item3 == "")            // Check to add headers
                {
                    output.Add(s.Item2);                        // Add School to output list
                }
                else
                {
                    if (s.Item1 == "DeKalb" && flagthree)
                    {
                        output.Add("");
                        flagthree = false;
                    }
                    if (s.Item1 == "Sycamore" && flagfour)
                    {
                        output.Add("");
                        flagfour = false;
                    }
                    output.Add(s.Item2 + " # " + s.Item3);                        // Add School to output list
                }
            }

            comboBox_ForSaleResidence.Items.AddRange(output.ToArray<string>());

        }



        /***
         * A function to list for sale properties within a specified price
         * 
         * @param Properties (for sale)
         * @param Price range
         * 
         * @return A list of properties within the specified range
         ****************************************************************************/
        private void button_PriceRange_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();                               // Output List to send to combo box for query results

            SortedSet<Property> props = DeKalb.Prop;                                // SortedSets to make into
            SortedSet<Property> sycamore = Sycamore.Prop;
            SortedSet<Person> residents = DeKalb.Residents;
            SortedSet<Person> sycamoreResidents = Sycamore.Residents;

            // Loop through properties and add to props
            foreach (Property s in sycamore)
            {
                props.Add(s);
            }

            // Loop through people and add residents
            foreach (Person s in sycamoreResidents)
            {
                residents.Add(s);
            }

            // Declaring variables
            string min;
            string max;

            // Format Min/Max Price Values
            min = String.Format("{0: $0,000}", trackBar_MinPrice.Value);
            max = String.Format("{0: $0,000}", trackBar_MaxPrice.Value);

            output.Add($"Properties for sale within the [ {min}, {max} ] price range.");
            output.Add(new string('-', 75));

            if (!checkBox_Residental.Checked && !checkBox_Business.Checked && !checkBox_School.Checked)
            {
                MessageBox.Show("Error: Please select one or more of the properties you are looking for...");
                return;
            }
            else if (checkBox_Residental.Checked && !checkBox_Business.Checked && !checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is House || N is Apartment)
                    orderby N.Price ascending
                    group N by N.City;

                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (!checkBox_Residental.Checked && checkBox_Business.Checked && !checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Business)
                    orderby N.Price ascending
                    group N by N.City;


                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (!checkBox_Residental.Checked && !checkBox_Business.Checked && checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is School)
                    orderby N.Price ascending
                    group N by N.City;

                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (!checkBox_Residental.Checked && checkBox_Business.Checked && !checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Business)
                    orderby N.Price ascending
                    group N by N.City;


                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (!checkBox_Residental.Checked && !checkBox_Business.Checked && checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is School)
                    orderby N.Price ascending
                    group N by N.City;

                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (checkBox_Residental.Checked && !checkBox_Business.Checked && checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Residential || N is School)
                    orderby N.Price ascending
                    group N by N.City;

                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (checkBox_Residental.Checked && checkBox_Business.Checked && !checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Residential || N is Business)
                    orderby N.Price ascending
                    group N by N.City;


                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }
            }
            else if (!checkBox_Residental.Checked && checkBox_Business.Checked && checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Business || N is School)
                    orderby N.Price ascending
                    group N by N.City;

                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }
            else if (checkBox_Residental.Checked && checkBox_Business.Checked && checkBox_School.Checked)
            {
                // Query to find properties within desired price range, sort ascending, group by city
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price)
                    orderby N.Price ascending
                    group N by N.City;


                List<string> temp = new List<string>();

                if (!(CombinedQuery == null))
                {
                    temp = FormatOutputPrice(CombinedQuery, residents);

                    foreach (string i in temp)
                    {
                        output.Add(i);
                    }
                }

                // Query found nothing
                if (CombinedQuery == null)
                {
                    output.Add("Your query yielded no matches.\n");
                }
            }

            output.Add("");
            output.Add("### END OF OUTPUT ###");

            listBox_QueryResults.DataSource = null;

            listBox_QueryResults.Items.Clear();

            listBox_QueryResults.DataSource = output;
        }



        /***
         * A function to list for sale residences within range of a school
         * 
         * @param School to initialize local location
         * @param Range to calculate local residences
         * 
         * @return Residences within range
         ****************************************************************************/
        private void button_SchoolRange_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();

            SortedSet<Property> props = DeKalb.Prop;
            SortedSet<Property> sycamore = Sycamore.Prop;
            SortedSet<Person> residents = DeKalb.Residents;
            SortedSet<Person> sycamoreResidents = Sycamore.Residents;

            foreach (Property s in sycamore)
            {
                props.Add(s);
            }

            foreach (Person s in sycamoreResidents)
            {
                residents.Add(s);
            }

            if (comboBox_School.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a school first...");
            }
            else
            {
                // Initialize variables
                string selectedSchool = comboBox_School.SelectedItem.ToString();
                string city = "";
                string address = "";
                string unit = "";
                bool isApartment = false;
                (int, int) coords = (0, 0);

                // Query to find desired school, to further gather info
                var getSchool =
                    from N in props
                    where (N is School)
                    where (((School)N).Name == selectedSchool)
                    select (N.xcoord, N.ycoord, N.City);

                // Format output
                output.Add("Residences for sale within " + numericUpDown_ResidenceForSaleSchoolRange.Value + " units of distance");
                output.Add("\t" + "from " + selectedSchool + ".");
                output.Add(new string('-', 125));

                // Get school coordinates and city
                foreach((int, int, string) N in getSchool)
                {
                    coords = (N.Item1, N.Item2);
                    city = N.Item3;
                }

                // Query to get all houses and information
                var Houses =
                        from N in props
                        where N is House && N.Sale
                        select (N.xcoord, N.ycoord, N.Owner, N.City, N.State, N.Address, N.Price, N.Zip, ((House)N).Bedroom, ((House)N).Baths, ((House)N).Sqft, ((House)N).Garage(), "");

                // Query to get all apartments and information
                var Apartments =
                    from N in props
                    where N is Apartment && N.Sale
                    select (N.xcoord, N.ycoord, N.Owner, N.City, N.State, N.Address, N.Price, N.Zip, ((Apartment)N).Bedroom, ((Apartment)N).Baths, ((Apartment)N).Sqft, "", " # " + ((Apartment)N).Unit);

                // Query to combineHouses and Apartments
                var CombinedQuery = Houses.Concat(Apartments);

                // Query properties and residents, store all needed information
                var DeKalbRangeQuery =
                        from N in CombinedQuery
                        join R in residents on N.Owner equals R.Id
                        where (N.Item4 == "DeKalb" &&
                                (double)numericUpDown_ResidenceForSaleSchoolRange.Value >
                                (Math.Sqrt(Math.Pow((int)N.Item1 - (int)coords.Item1, 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2)))
                                )
                        select ((Math.Sqrt(Math.Pow((int)N.Item1 - (int)coords.Item1, 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2))),
                                N.Item6 + N.Item13 + " " + N.Item4 + ", " + N.Item5 + " " + N.Item8 + "\t" + (int)(Math.Sqrt(Math.Pow(((int)N.xcoord - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))) +
                                " units away " +
                                "\nOwner: " + R.FullName + "  |    " + N.Item9 + " beds, " + N.Item10 + " baths, " + N.Item11 + " sq.ft.\n" +
                                N.Item12 + "    " + (String.Format("{0: $0,0}", N.Item7)) + "\n"
                                );

                // Query properties and residents, store all needed information
                var SycamoreRangeQuery =
                    from N in CombinedQuery
                    join R in residents on N.Owner equals R.Id
                    where (N.Item4 == "Sycamore" &&
                            (double)numericUpDown_ResidenceForSaleSchoolRange.Value >
                            (Math.Sqrt(Math.Pow(((int)N.Item1 + 250 - (int)coords.Item1), 2) + Math.Pow(((int)N.Item2 - (int)coords.Item2), 2)))
                            )
                    select ((Math.Sqrt(Math.Pow((int)N.Item1 - (int)coords.Item1, 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2))),
                                N.Item6 + N.Item13 + " " + N.Item4 + ", " + N.Item5 + " " + N.Item8 + "\t" + (int)(Math.Sqrt(Math.Pow(((int)N.xcoord - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))) +
                                " units away " +
                                "\nOwner: " + R.FullName + "  |    " + N.Item9 + " beds, " + N.Item10 + " baths, " + N.Item11 + " sq.ft.\n" +
                                N.Item12 + "    " + (String.Format("{0: $0,0}", N.Item7)) + "\n"
                                );

                // Query to combine DeKalbRangeQuery and SycamoreRangeQuery
                var RangeQuery = DeKalbRangeQuery.Concat(SycamoreRangeQuery);

                // Sort RangeQuery, descending
                var NewRangeQuery =
                    from N in RangeQuery
                    orderby N.Item1 descending
                    select N.Item2;

                // Add items to output
                foreach (string i in NewRangeQuery)
                {
                    string[] lines = Regex.Split(i, "\n");
                    foreach (string x in lines)
                        output.Add(x.ToString());
                }

                // Query found nothing
                if (!NewRangeQuery.Any())
                {
                    output.Add("Your query yielded no matches.");
                    output.Add("");
                }

            }

            output.Add("### END OF OUTPUT ###");

            listBox_QueryResults.DataSource = null;

            listBox_QueryResults.Items.Clear();

            listBox_QueryResults.DataSource = output;

        }



        /***
         * A function to print min price, and ensure max price isn't
         * less than min price
         * 
         * @param trackBar_MinPrice.Value
         * 
         * @return Minimum price value, and fixed Max price value
         ****************************************************************************/
        private void trackBar_MinPrice_ValueChanged(object sender, EventArgs e)
        {
            // Print minimum trackbar value
            minimumPriceRange_Label.Text = trackBar_MinPrice.Value.ToString();

            // Drag maximum along with minimum
            if (trackBar_MinPrice.Value > trackBar_MaxPrice.Value)
            {
                trackBar_MaxPrice.Value = trackBar_MinPrice.Value;
            }
        }



        /***
         * A function to print max price, and ensure min price isn't
         * more than max price
         * 
         * @param trackBar_MaxPrice.Value
         * 
         * @return Maximum price value, and fixed min price value
         ****************************************************************************/
        private void trackBar_MaxPrice_ValueChanged(object sender, EventArgs e)
        {
            // Print maximum trackbar value
            maximumPriceRange_Label.Text = trackBar_MaxPrice.Value.ToString();

            // Drag minimum along with maximum
            if (trackBar_MaxPrice.Value < trackBar_MinPrice.Value)
            {
                trackBar_MinPrice.Value = trackBar_MaxPrice.Value;
            }
        }



        /***
         * A function to list properties with specified requests
         * 
         * @param House/Apartment, beds, baths, min sq.ft, garage (attached/not)
         * 
         * @return Properties that meet the criteria
         ****************************************************************************/
        private void button_SpecificResidence_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();

            SortedSet<Property> props = DeKalb.Prop;
            SortedSet<Property> sycamore = Sycamore.Prop;
            SortedSet<Person> residents = DeKalb.Residents;
            SortedSet<Person> sycamoreResidents = Sycamore.Residents;

            // Add each property to props
            foreach (Property s in sycamore)
            {
                props.Add(s);
            }
            
            // Add each person to residents
            foreach (Person s in sycamoreResidents)
            {
                residents.Add(s);
            }


            // nothing selected
            if (!checkBox_Apartment.Checked && !checkBox_House.Checked)
            {
                MessageBox.Show("Please specificy house and/or apartment...");
            }

            // Apartment checked
            else if (checkBox_Apartment.Checked && !checkBox_House.Checked)
            {
                // Query properties and residents, store all needed information
                var CombinedQuery =
                    from N in props
                    join R in residents on N.Owner equals R.Id
                    where (N.Sale && N is Apartment && (((Apartment)N).Bedroom >= numericUpDown_Bed.Value) && (((Apartment)N).Baths >= numericUpDown_Bath.Value) && (((Apartment)N).Sqft >= numericUpDown_Sqft.Value))
                    orderby N.Price ascending
                    select (
                                ((Apartment)N).Address + " Apt.#" + ((Apartment)N).Unit + " " + ((Apartment)N).City + ", " + ((Apartment)N).State + " " + ((Apartment)N).Zip + "\n" +
                                    "Owner: " + R.FullName + " | " + ((Apartment)N).Bedroom + " bed(s), " + ((Apartment)N).Baths + " bath(s), " +
                                    ((Apartment)N).Sqft + " sq.ft.    " + (String.Format("{0: $0,0}", ((Apartment)N).Price)) + "\n"
                            );

                // Output to Query Results listbox

                output.Add("Apartment with at least " + numericUpDown_Bed.Value + " bed(s), "
                    + numericUpDown_Bath.Value + " bath(s), and " + numericUpDown_Sqft.Value + " sq.ft.");
                output.Add(new string('-', 100));

                List<string> temp = new List<string>();

                // Add items to output
                foreach (string i in CombinedQuery)
                {
                    string[] lines = Regex.Split(i, "\n");
                    foreach (string x in lines)
                        output.Add(x.ToString());
                }

                // Query found nothing
                if (!CombinedQuery.Any())
                {
                    output.Add("Your query yielded no matches.");
                    output.Add("");
                }
            }

            // House checked with garage not checked (no garage)
            else if (!checkBox_Apartment.Checked && checkBox_House.Checked && !checkBox_Garage.Checked)
            {
                // Query properties and residents, store all needed information
                var CombinedQuery =
                    from N in props
                    join R in residents on N.Owner equals R.Id
                    where (N.Sale && N is House && !((House)N).isGarage && (((House)N).Bedroom >= numericUpDown_Bed.Value) && (((House)N).Baths >= numericUpDown_Bath.Value) && (((House)N).Sqft >= numericUpDown_Sqft.Value))
                    orderby N.Price ascending
                    select (
                                ((House)N).Address + " " + ((House)N).City + ", " + ((House)N).State + " " + ((House)N).Zip + "\n" +
                                    "Owner: " + R.FullName + " | " + ((House)N).Bedroom + " bed(s), " + ((House)N).Baths + " bath(s), " + ((House)N).Sqft +
                                    " sq.ft.    " + "\n" + ((House)N).Garage() + "    " + (String.Format("{0: $0,0}", ((House)N).Price)) + "\n"
                            );


                output.Add("House with at least " + numericUpDown_Bed.Value + " bed(s), "
                    + numericUpDown_Bath.Value + " bath(s), and " + numericUpDown_Sqft.Value + " sq.ft. without a garage.");
                output.Add(new string('-', 100));

                List<string> temp = new List<string>();

                // Add items to output
                foreach (string i in CombinedQuery)
                {
                    string[] lines = Regex.Split(i, "\n");
                    foreach (string x in lines)
                        output.Add(x.ToString());
                }

                // Query found nothing
                if (!CombinedQuery.Any())
                {
                    output.Add("Your query yielded no matches.");
                    output.Add("");
                }
            }

            // House wwith garage checked and attached checked
            else if (!checkBox_Apartment.Checked && checkBox_House.Checked && checkBox_Garage.Checked && checkBox_attachedGarage.Checked)
            {
                // Query properties and residents, store all needed information
                var CombinedQuery =
                    from N in props
                    join R in residents on N.Owner equals R.Id
                    where (N.Sale && N is House && (((House)N).AttachedGarage == true) && ((House)N).isGarage && (((House)N).Bedroom >= numericUpDown_Bed.Value) && (((House)N).Baths >= numericUpDown_Bath.Value) && (((House)N).Sqft >= numericUpDown_Sqft.Value))
                    orderby N.Price ascending
                    select (
                                ((House)N).Address + " " + ((House)N).City + ", " + ((House)N).State + " " + ((House)N).Zip + "\n" +
                                 "Owner: " + R.FullName + " | " + ((House)N).Bedroom + " bed(s), " + ((House)N).Baths + " bath(s), " + ((House)N).Sqft +
                                 " sq.ft.    " + "\n" + ((House)N).Garage() + "    " + (String.Format("{0: $0,0}", ((House)N).Price)) + "\n"
                                );

                output.Add("House with at least " + numericUpDown_Bed.Value + " bed(s), "
                    + numericUpDown_Bath.Value + " bath(s), and " + numericUpDown_Sqft.Value + " sq.ft. with an attached garage.");
                output.Add(new string('-', 100));

                List<string> temp = new List<string>();

                // Add items to output
                foreach (string i in CombinedQuery)
                {
                    string[] lines = Regex.Split(i, "\n");
                    foreach (string x in lines)
                        output.Add(x.ToString());
                }

                // Query found nothing
                if (!CombinedQuery.Any())
                {
                    output.Add("Your query yielded no matches.");
                    output.Add("");
                }
            }

            // House with garage checked and attached not checked
            else if (!checkBox_Apartment.Checked && checkBox_House.Checked && checkBox_Garage.Checked && !checkBox_attachedGarage.Checked)
            {
                // Query properties and residents, store all needed information
                var CombinedQuery =
                    from N in props
                    join R in residents on N.Owner equals R.Id
                    where (N.Sale && N is House && !(((House)N).AttachedGarage == true) && ((House)N).isGarage && (((House)N).Bedroom >= numericUpDown_Bed.Value) && (((House)N).Baths >= numericUpDown_Bath.Value) && (((House)N).Sqft >= numericUpDown_Sqft.Value))
                    orderby N.Price ascending
                    select (
                                ((House)N).Address + " " + ((House)N).City + ", " + ((House)N).State + " " + ((House)N).Zip + "\n" +
                                 "Owner: " + R.FullName + " | " + ((House)N).Bedroom + " bed(s), " + ((House)N).Baths + " bath(s), " + ((House)N).Sqft +
                                 " sq.ft.    " + "\n" + ((House)N).Garage() + "    " + (String.Format("{0: $0,0}", ((House)N).Price)) + "\n"
                                );

                output.Add("House with at least " + numericUpDown_Bed.Value + " bed(s), "
                    + numericUpDown_Bath.Value + " bath(s), and " + numericUpDown_Sqft.Value + " sq.ft. with a detached garage.");
                output.Add(new string('-', 100));

                List<string> temp = new List<string>();

                // Add items to output
                foreach (string i in CombinedQuery)
                {
                    string[] lines = Regex.Split(i, "\n");
                    foreach (string x in lines)
                        output.Add(x.ToString());
                }


                // Query found nothing
                if (!CombinedQuery.Any())
                {
                    output.Add("Your query yielded no matches.");
                    output.Add("");
                }
            }

            // Apartment && House checked
            else if (checkBox_Apartment.Checked && checkBox_House.Checked)
            {
                // Query properties and residents, store all needed information
                var CombinedQuery =
                    from N in props
                    join R in residents on N.Owner equals R.Id
                    where ((N.Sale && N is House && (((House)N).Bedroom >= numericUpDown_Bed.Value) && (((House)N).Baths >= numericUpDown_Bath.Value) && (((House)N).Sqft >= numericUpDown_Sqft.Value)))
                            || (N.Sale && N is Apartment && (((Apartment)N).Bedroom >= numericUpDown_Bed.Value) && (((Apartment)N).Baths >= numericUpDown_Bath.Value) && (((Apartment)N).Sqft >= numericUpDown_Sqft.Value))
                    orderby N.Price ascending
                    select N;

                List<string> tempOutput = new List<string>();

                // Format and add each property to output
                foreach (Property p in CombinedQuery)
                {
                    string name = "";
                    foreach (Person R in residents)
                    {
                        if (p.Owner == R.Id)
                        {
                            name = R.FullName;
                            break;
                        }
                    }

                    if (p is House)
                    {
                        tempOutput.Add(((House)p).Address + " " + ((House)p).City + ", " + ((House)p).State + " " + ((House)p).Zip + "\n" +
                            "Owner: " + name + " | " + ((House)p).Bedroom + " bed(s), " + ((House)p).Baths + " bath(s), " + ((House)p).Sqft +
                            " sq.ft.    " + "\n" + ((House)p).Garage() + "    " + (String.Format("{0: $0,0}", ((House)p).Price)) + "\n");
                    }
                    else if (p is Apartment)
                    {
                        tempOutput.Add(((Apartment)p).Address + " Apt.#" + ((Apartment)p).Unit + " " + ((Apartment)p).City + ", " + ((Apartment)p).State + " " + ((Apartment)p).Zip + "\n" +
                                    "Owner: " + name + " | " + ((Apartment)p).Bedroom + " bed(s), " + ((Apartment)p).Baths + " bath(s), " +
                                    ((Apartment)p).Sqft + " sq.ft.    " + (String.Format("{0: $0,0}", ((Apartment)p).Price)) + "\n");
                    }
                }
                output.Add("House and Apartments with at least " + numericUpDown_Bed.Value + " bed(s), "
                    + numericUpDown_Bath.Value + " bath(s), and " + numericUpDown_Sqft.Value + " sq.ft.");
                output.Add(new string('-', 100));

                List<string> temp = new List<string>();

                // Add items to output
                foreach (string i in tempOutput)
                {
                    string[] lines = Regex.Split(i, "\n");
                    foreach (string x in lines)
                        output.Add(x.ToString());
                }

                // Query found nothing
                if (!CombinedQuery.Any())
                {
                    output.Add("Your query yielded no matches.");
                    output.Add("");
                }
            }

            listBox_QueryResults.DataSource = null;

            listBox_QueryResults.Items.Clear();

            listBox_QueryResults.DataSource = output;

        }


        /***
         * A function to check if garage is checked, 
         *                      and enable attachedGarage checkbox
         * 
         * @param checkBox_Garage.Checked
         * 
         * @return attachedGarage visibility
         ****************************************************************************/
        private void checkBox_Garage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Garage.Checked)
            {
                checkBox_attachedGarage.Visible = true;
            }
            else
            {
                checkBox_attachedGarage.Visible = false;
                checkBox_attachedGarage.Checked = false;
            }
        }



        /***
         * A function to check if apartment is checked, 
         *                      and disable Garage checkbox
         * 
         * @param checkBox_Apartment.Checked
         * 
         * @return Garage/attachedGarage visibility
         ****************************************************************************/
        private void checkBox_Apartment_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Apartment.Checked)
            {
                checkBox_Garage.Visible = false;
                checkBox_Garage.Checked = false;
                checkBox_attachedGarage.Visible = false;
                checkBox_attachedGarage.Checked = false;
            }
            else
            {
                checkBox_Garage.Visible = true;
            }
        }


        /***
         * A function to find businesses within range of a property for sale
         * 
         * @param Property for sale
         * @param Specified distance
         * 
         * @return Businesses within the distance
         ****************************************************************************/
        private void button_BusinessRange_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();

            SortedSet<Property> props = DeKalb.Prop;
            SortedSet<Property> sycamore = Sycamore.Prop;
            SortedSet<Person> residents = DeKalb.Residents;
            SortedSet<Person> sycamoreResidents = Sycamore.Residents;


            foreach (Property s in sycamore)
            {
                props.Add(s);
            }

            foreach (Person s in sycamoreResidents)
            {
                residents.Add(s);
            }

            if (comboBox_ForSaleResidence.SelectedIndex == -1)
            {
                MessageBox.Show("Error: Please select a For-Sale Residence...");
            }
            else
            {
                // Intialize variables
                string address = comboBox_ForSaleResidence.SelectedItem.ToString();
                string unit = "";
                bool isApartment = false;
                (uint, uint) coords = (0, 0);
                string city = "";

                // Format output
                output.Add("Hiring Businesses within " + numericUpDown_ResidenceForSaleBusinessRange.Value.ToString() + " units of distance from");
                output.Add("\t" + address);
                output.Add(new string('-', 125));

                // Break up apartment, for ease-of-use
                if (address.Contains("#"))
                {
                    string[] apartment = Regex.Split(address, "#");
                    address = apartment[0];
                    unit = apartment[1];
                    isApartment = true;
                }

                if (isApartment)
                {
                    // Query to find apartment property, store city, x coordinate, and y coordinate
                    var apart =
                        from N in props
                        where N is Apartment
                        where (N.Address == address) && N.CheckUnit(unit)
                        select (N.City, N.xcoord, N.ycoord);

                    foreach ((string, uint, uint) c in apart)
                    {
                        coords = (c.Item2, c.Item3);
                        city = c.Item1;
                    }
                }
                else
                {
                    // Query to find house property, store city, x coordinate, and y coordinate
                    var house =
                        from N in props
                        where (N.Address == address)
                        select (N.City, N.xcoord, N.ycoord);

                    foreach ((string, uint, uint) c in house)
                    {
                        coords = (c.Item2, c.Item3);
                        city = c.Item1;
                    }
                }

                if (city == "DeKalb")
                {
                    // Query to find business properties
                    var Businesses =
                        from N in props
                        where N is Business
                        select (Business)N;

                    // Calculate distance and format output
                    var DeKalbRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "DeKalb" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow((int)N.xcoord - (int)coords.Item1, 2) + Math.Pow((int)N.ycoord - (int)coords.Item2, 2)))
                                )
                        select (N.ActiveRecruitment,
                                N.Address + " " + N.City + ", " + N.State + " " + N.Zip +
                                "\nOwner: " + R.FullName + " |    " + (int)(Math.Sqrt(Math.Pow(((int)N.xcoord - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))) +
                                " units away, with " + N.ActiveRecruitment + " open positions\n" +
                                N.Name + ", a " + N.Type + " type of business, established in " + N.YearEstablished + "\n"
                                );

                    // Calculate distance and format output
                    var SycamoreRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "Sycamore" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow(((int)N.xcoord + 250 - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2)))
                                )
                        select (N.ActiveRecruitment,
                                N.Address + " " + N.City + ", " + N.State + " " + N.Zip +
                                "\nOwner: " + R.FullName + " |    " + (int)(Math.Sqrt(Math.Pow(((int)N.xcoord + 250 - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))) +
                                " units away, with " + N.ActiveRecruitment + " open positions\n" +
                                N.Name + ", a " + N.Type + " type of business, established in " + N.YearEstablished + "\n"
                                );

                    // Query to combine DeKalbRangeQuery and SycamoreRangeQuery
                    var RangeQuery = DeKalbRangeQuery.Concat(SycamoreRangeQuery);

                    // Query to sort BusinessRangeQuery, descending
                    var BusinessRangeQuery =
                        from N in RangeQuery
                        where N.Item1 > 0
                        orderby N.Item1 descending
                        select N.Item2;

                    // Add items to output
                    foreach (string i in BusinessRangeQuery)
                    {
                        string[] lines = Regex.Split(i, "\n");
                        foreach (string x in lines)
                            output.Add(x.ToString());
                    }

                    // Query found nothing
                    if (!BusinessRangeQuery.Any())
                    {
                        output.Add("Your query yielded no matches.");
                        output.Add("");
                    }
                }
                else
                {
                    // Query business properties
                    var Businesses =
                        from N in props
                        where N is Business
                        select (Business)N;

                    // Calculate distance and format output
                    var DeKalbRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "DeKalb" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow(((int)N.xcoord + 250 - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2)))
                                )
                        select (N.ActiveRecruitment,
                                N.Address + " " + N.City + ", " + N.State + " " + N.Zip +
                                "\nOwner: " + R.FullName + " |    " + (int)(Math.Sqrt(Math.Pow(((int)N.xcoord + 250 - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))) +
                                " units away, with " + N.ActiveRecruitment + " open positions\n" +
                                N.Name + ", a " + N.Type + " type of business, established in " + N.YearEstablished + "\n"
                                );

                    // Calculate distance and format output
                    var SycamoreRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "Sycamore" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow(((int)N.xcoord - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2)))
                                )
                        select (N.ActiveRecruitment,
                                N.Address + " " + N.City + ", " + N.State + " " + N.Zip +
                                "\nOwner: " + R.FullName + " |    " + (int)(Math.Sqrt(Math.Pow(((int)N.xcoord - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))) +
                                " units away, with " + N.ActiveRecruitment + " open positions\n" +
                                N.Name + ", a " + N.Type + " type of business, established in " + N.YearEstablished + "\n"
                                );

                    // Query to combine DeKalbRangeQuery and SycamoreRangeQuery
                    var RangeQuery = DeKalbRangeQuery.Concat(SycamoreRangeQuery);

                    // Query to sort BusinessRangeQuery, descending
                    var BusinessRangeQuery =
                        from N in RangeQuery
                        where N.Item1 > 0
                        orderby N.Item1 descending
                        select N.Item2;

                    // Add items to output
                    foreach (string i in BusinessRangeQuery)
                    {
                        string[] lines = Regex.Split(i, "\n");
                        foreach (string x in lines)
                            output.Add(x.ToString());
                    }

                    // Query found nothing
                    if (!BusinessRangeQuery.Any())
                    {
                        output.Add("Your query yielded no matches.");
                        output.Add("");
                    }
                }
            }

            output.Add("### END OF OUTPUT ###");

            listBox_QueryResults.DataSource = null;

            listBox_QueryResults.Items.Clear();

            listBox_QueryResults.DataSource = output;
        }


        /***
         * A function to ensure the selected item isn't invalid
         * 
         * @param School_SelectedIndex
         * 
         * @return Error message
         ****************************************************************************/
        private void comboBox_School_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_School.SelectedIndex != -1)
            {
                string item = comboBox_School.Text;

                // Prevents selection of items that aren't School
                if (item == "DeKalb:" || item == "Sycamore:" || item == (new string('-', 10)) || item == "")
                {
                    //MessageBox.Show("Error: Please select a valid address...");
                    comboBox_School.SelectedIndex = -1;
                }

                ActiveControl = null;
            }
        }


        /***
         * A function to locate properties owned by out-of-towners
         * 
         * @param Properties
         * @param Residents
         * 
         * @return List of properties which are owned by out-of-towners
         ****************************************************************************/
        private void button_OutOfTowners_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();

            //SortedSet<Property> props = DeKalb.Prop;
            //SortedSet<Property> sycamore = Sycamore.Prop;
            //SortedSet<Person> residents = DeKalb.Residents;
            //SortedSet<Person> sycamoreResidents = Sycamore.Residents;

            List<string> temp = new List<string>();

            output.Add("Properties Owned by Out-Of-Towners");
            output.Add(new string('-', 125));

            // Query properties and residents in DeKalb, get full name
            var Query =
                from N in DeKalb.Prop
                join R in Sycamore.Residents on (int)N.Owner equals (int)R.Id
                where ((int)N.Owner == (int)R.Id && N.City == "DeKalb")
                select (N, R.FullName);

            foreach ((Property, string) p in Query)
            {
                if (p.Item1 is House)
                {
                    House h = (House)p.Item1;

                    // Format output
                    temp.Add(h.Address + " " + h.City + ", " + h.State + " " + h.Zip + "\n" +
                            "Owner: " + p.Item2 + " | " + h.Bedroom + " bed(s), " + h.Baths + " bath(s), " + h.Sqft +
                            " sq.ft.    " + "\n" + h.Garage() + "    " + (String.Format("{0: $0,0}", h.Price)) + "\n");

                }
                else if (p.Item1 is Apartment)
                {
                    Apartment a = (Apartment)p.Item1;

                    // Format output
                    temp.Add(a.Address + " Apt.#" + a.Unit + " " + a.City + ", " + a.State + " " + a.Zip + "\n" +
                         "Owner: " + p.Item2 + " | " + a.Bedroom + " bed(s), " + a.Baths + " bath(s), " +
                         a.Sqft + " sq.ft.    " + (String.Format("{0: $0,0}", a.Price)) + "\n");
                }
                else if (p.Item1 is Business)
                {
                    Business b = (Business)p.Item1;
                    int price = 0;

                    if (b.Price != null)
                    {
                        price = (int)b.Price;
                    }

                    // Format output
                    temp.Add(b.Address + " " + b.City + ", " + b.State + " " + b.Zip +
                                "\nOwner: " + p.Item2 + " |    " + (String.Format("{0: $0,0}", price)) + "\n" +
                                b.Name + ", a " + b.Type + " type of business, established in " + b.YearEstablished + "\n"
                                );
                }
                else
                {
                    School s = (School)p.Item1;

                    // Format output
                    temp.Add(s.Address + " " + s.City + ", " + s.State + " " + s.Zip + " | Owner: " + p.Item2 + "\n" +
                                s.Name + ", established in " + s.YearEstablished + "\n" +
                                s.Enrolled + " students enrolled\t" + String.Format("{0: $0,000}", s.Price) + "\n");
                }
            }

            // Query properties and residents in sycamore, get full name
            var SycamoreQuery =
                from N in S.Prop
                join R in D.Residents on (int)N.Owner equals (int)R.Id
                where ((int)N.Owner == (int)R.Id && N.City == "Sycamore")
                select (N, R.FullName);

            foreach ((Property, string) syc in SycamoreQuery)
            {
                if (syc.Item1 is House)
                {
                    House h = (House)syc.Item1;

                    // Format output
                    temp.Add(h.Address + " " + h.City + ", " + h.State + " " + h.Zip + "\n" +
                            "Owner: " + syc.Item2 + " | " + h.Bedroom + " bed(s), " + h.Baths + " bath(s), " + h.Sqft +
                            " sq.ft.    " + "\n" + h.Garage() + "    " + (String.Format("{0: $0,0}", h.Price)) + "\n");

                }
                else if (syc.Item1 is Apartment)
                {
                    Apartment a = (Apartment)syc.Item1;

                    // Format output
                    temp.Add(a.Address + " Apt.#" + a.Unit + " " + a.City + ", " + a.State + " " + a.Zip + "\n" +
                         "Owner: " + syc.Item2 + " | " + a.Bedroom + " bed(s), " + a.Baths + " bath(s), " +
                         a.Sqft + " sq.ft.    " + (String.Format("{0: $0,0}", a.Price)) + "\n");
                }
                else if (syc.Item1 is Business)
                {
                    Business b = (Business)syc.Item1;
                    int price = 0;

                    if (b.Price != null)
                    {
                        price = (int)b.Price;
                    }

                    // Format output
                    temp.Add(b.Address + " " + b.City + ", " + b.State + " " + b.Zip +
                                "\nOwner: " + syc.Item2 + " |    " + (String.Format("{0: $0,0}", price)).ToString() + "\n" +
                                b.Name + ", a " + b.Type + " type of business, established in " + b.YearEstablished + "\n"
                                );
                }
                else if (syc.Item1 is School)
                {
                    School s = (School)syc.Item1;

                    // Format output
                    temp.Add(s.Address + " " + s.City + ", " + s.State + " " + s.Zip + " | Owner: " + syc.Item2 + "\n" +
                                s.Name + ", established in " + s.YearEstablished + "\n" +
                                s.Enrolled + " students enrolled\t" + String.Format("{0: $0,000}", s.Price) + "\n");
                }
            }

            // Add output
            foreach (string i in temp)
            {
                string[] lines = Regex.Split(i, "\n");
                foreach (string x in lines)
                    output.Add(x.ToString());
            }

            // Query found nothing
            if (!temp.Any())
            {
                output.Add("Your query yielded no matches.");
                output.Add("");
            }


            output.Add("### END OF OUTPUT ###");

            listBox_QueryResults.DataSource = null;

            listBox_QueryResults.Items.Clear();

            listBox_QueryResults.DataSource = output;
        }

        /***
         * A function to ensure the selected item isn't invalid
         * 
         * @param ForSaleResidence_SelectedIndex
         * 
         * @return Error message
         ****************************************************************************/
        private void comboBox_ForSaleResidence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ForSaleResidence.SelectedIndex != -1)
            {
                string item = comboBox_ForSaleResidence.Text;

                // Prevents selection of items that aren't School
                if (item == "DeKalb:" || item == "Sycamore:" || item == (new string('-', 10)) || item == "")
                {
                    //MessageBox.Show("Error: Please select a valid address...");
                    comboBox_ForSaleResidence.SelectedIndex = -1;
                }

                ActiveControl = null;
            }
        }
    }
}
