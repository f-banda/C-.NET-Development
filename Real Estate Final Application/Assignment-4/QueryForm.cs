/****************************************************************************
 *                                                                          *
 *  Made by:                                                                *
 *      Francisco Banda (Z1912220)                                          *
 *                 &                                                        *
 *      Kyle Saysavanh  (Z1911954)                                          *
 *                                                                          *
 *  CSCI 473                                                                *
 *  Assignment 4 - Linq                                                     *
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
using static mathteam_Assign4.ClassSource;

namespace mathteam_Assign4
{
    public partial class QueryForm : Form
    {

        // Declaring Delta
        public static double Delta = 1;
        public static double DeltaX, DeltaY = 0;


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
                    temp = b.Name + ", a " + b.Type + ", established in " + b.YearEstablished;
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
        static Community MakeCommunity(string communityName)
        {
            SortedSet<Property> props = new SortedSet<Property>();
            SortedSet<Person> residents = new SortedSet<Person>();
            SortedSet<Property> businesses = new SortedSet<Property>();
            SortedSet<Property> schools = new SortedSet<Property>();
            Community temp = new Community();

            uint id = 99999;                                    // Mayor info
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

        public Community DeKalb;
        public Community Sycamore;
        public string CurrentCommunity = "";

        List<string> ForSaleResidence = new List<string>();
        List<string> PreviousSelectedResidence = new List<string> { "Previous Selected Residences", new string('-', 20) };
   
        Bitmap HomeIcon = new Bitmap("HomeIcon.PNG");
        Bitmap SchoolIcon = new Bitmap("SchoolIcon.PNG");
        Bitmap BusinessIcon = new Bitmap("BusinessIcon.PNG");
        Bitmap MarkerIcon = new Bitmap("MarkerIcon.PNG");

        (int, int) HomeCoords = (0, 0);
        (int, int) SchoolCoords = (0, 0);

        bool home = false;
        bool school = false;
        bool search = false;

        IEnumerable<(int, uint, uint, string, string, string, string, string, uint, string, string, string, int)> BusinessResult = Enumerable.Empty<(int, uint, uint, string, string, string, string, string, uint, string, string, string, int)>();
        IOrderedEnumerable<(int, uint, uint, string, string, string, string, string, string, uint, uint, uint, string, string, string)> FinalResult = Enumerable.Empty<(int, uint, uint, string, string, string, string, string, string, uint, uint, uint, string, string, string)>().OrderBy(x => 1);
        IEnumerable<(uint, uint, string, string, string, string, string, string, uint, string, int)> SchoolResult = Enumerable.Empty<(uint, uint, string, string, string, string, string, string, uint, string, int)>();

        public QueryForm()
        {
            InitializeComponent();

            // Making the DeKalb and Sycamore communities

            DeKalb = MakeCommunity("DeKalb");
            Sycamore = MakeCommunity("Sycamore");

            // Making the School combo box list

            comboBox_School.SelectedIndex = -1;             // Clear selections
            comboBox_ForSaleResidence.SelectedIndex = -1;

            SortedSet<Property> props = DeKalb.Prop;
            SortedSet<Property> sycamore = Sycamore.Prop;

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

            var Houses =
                from N in props
                where N is House && N.Sale
                select (N.City, N.Address, "");

            var Apartments =
                from N in props
                where N is Apartment && N.Sale
                select (N.City, N.Address, ((Apartment)N).Unit);

            var AddressQuery = Houses.Concat(Apartments);

            AddressQuery =
                from N in AddressQuery
                orderby N.Item1 ascending
                select (N.Item1, N.Item2, N.Item3);

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

            ForSaleResidence = output;

            comboBox_ForSaleResidence.Items.AddRange(output.ToArray<string>());

        }



        private void trackBar_MinPrice_ValueChanged(object sender, EventArgs e)
        {
            // Print minimum trackbar value
            minimumPriceRange_Label.Text = String.Format("{0: $#,##0}", trackBar_MinPrice.Value);

            // Drag maximum along with minimum
            if (trackBar_MinPrice.Value > trackBar_MaxPrice.Value)
            {
                trackBar_MaxPrice.Value = trackBar_MinPrice.Value;
            }
        }

        private void trackBar_MaxPrice_ValueChanged(object sender, EventArgs e)
        {
            // Print maximum trackbar value
            maximumPriceRange_Label.Text = String.Format("{0: $#,##0}", trackBar_MaxPrice.Value);

            // Drag minimum along with maximum
            if (trackBar_MaxPrice.Value < trackBar_MinPrice.Value)
            {
                trackBar_MinPrice.Value = trackBar_MaxPrice.Value;
            }
        }



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


        public void PrintHomeIcon()
        {
            Graphics G = Canvas.CreateGraphics();

            G.DrawImage(HomeIcon, (int)((HomeCoords.Item1 + DeltaX) * Delta), (int)((HomeCoords.Item2 + DeltaY) * Delta), 20, 20);
        }

        public void PrintSchoolIcon(int x, int y)
        {
            Graphics G = Canvas.CreateGraphics();

            G.DrawImage(SchoolIcon, (int)((x + DeltaX) * Delta), (int)((y + DeltaY) * Delta), 30, 30);
        }

        public void PrintBusinessIcon(int x, int y)
        {
            Graphics G = Canvas.CreateGraphics();

            G.DrawImage(BusinessIcon, (int)((x + DeltaX) * Delta), (int)((y + DeltaY) * Delta), 20, 20);
        }

        public void PrintMarkerIcon(int x, int y)
        {
            Graphics G = Canvas.CreateGraphics();

            G.DrawImage(MarkerIcon, (int)((x + DeltaX) * Delta), (int)((y + DeltaY) * Delta), 20, 20);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();

            SortedSet<Property> props = DeKalb.Prop;
            SortedSet<Property> sycamore = Sycamore.Prop;
            SortedSet<Person> residents = DeKalb.Residents;
            SortedSet<Person> sycamoreResidents = Sycamore.Residents;

            foreach (Property s in sycamore)                    // Combining communities data together
            {
                props.Add(s);                                   // Dekalb & Sycamore Properties
            }

            foreach (Person s in sycamoreResidents)
            {
                residents.Add(s);                               // Dekalb & Sycamore Residents
            }


            //--------------//
            // First Query  //
            //--------------//

            // Sorting the data for properties by type and price

            string min;
            string max;
            IEnumerable<IGrouping<string, Property>> results = null;

            min = String.Format("{0: $#,##0}", trackBar_MinPrice.Value);
            max = String.Format("{0: $#,##0}", trackBar_MaxPrice.Value);

            output.Add($"Properties for sale within the [ {min}, {max} ] price range.");
            output.Add(new string('-', 75));

            if (!checkBox_Residental.Checked && !checkBox_Business.Checked && !checkBox_School.Checked)
            {
                MessageBox.Show("Error: Please select one or more of the properties you are looking for...");
                return;
            }
            else if (checkBox_Residental.Checked && !checkBox_Business.Checked && !checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Residential)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }
            else if (!checkBox_Residental.Checked && checkBox_Business.Checked && !checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Business)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }
            else if (!checkBox_Residental.Checked && !checkBox_Business.Checked && checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is School)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }
            else if (checkBox_Residental.Checked && !checkBox_Business.Checked && checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Residential || N is School)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }
            else if (checkBox_Residental.Checked && checkBox_Business.Checked && !checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Residential || N is Business)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }
            else if (!checkBox_Residental.Checked && checkBox_Business.Checked && checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price) && (N is Business || N is School)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }
            else if (checkBox_Residental.Checked && checkBox_Business.Checked && checkBox_School.Checked)
            {
                var CombinedQuery =
                    from N in props
                    where (N.Sale && trackBar_MinPrice.Value <= N.Price && trackBar_MaxPrice.Value >= N.Price)
                    orderby N.Price ascending
                    group N by N.City;
                results = CombinedQuery;
            }

            IEnumerable<Property> tempResult = results.OrderBy(group => group.First()).SelectMany(group => group);
            List<Property> Result1 = tempResult.ToList();

            var xHouses =
                from N in Result1
                where N is House && N.Sale
                select (N.xcoord, N.ycoord, N.Owner, N.City, N.State, N.Address, N.Price, N.Zip, ((House)N).Bedroom, ((House)N).Baths, ((House)N).Sqft, (((House)N).Floors).ToString(), ((House)N).Garage(), "");

            var xApartments =
                from N in Result1
                where N is Apartment && N.Sale
                select (N.xcoord, N.ycoord, N.Owner, N.City, N.State, N.Address, N.Price, N.Zip, ((Apartment)N).Bedroom, ((Apartment)N).Baths, ((Apartment)N).Sqft, "", "", " # " + ((Apartment)N).Unit);

            var xTempQuery = xHouses.Concat(xApartments);

            var DeKalbRange =
                from N in xTempQuery
                join R in residents on N.Owner equals R.Id
                select (0, N.Item1, N.Item2, N.Item6, N.Item14, N.Item4, N.Item5, N.Item8, (string)R.FullName, N.Item9, N.Item10, N.Item11, N.Item12, N.Item13, N.Item7.ToString());

            var SycamoreRange =
                from N in xTempQuery
                join R in residents on N.Owner equals R.Id
                select (0, N.Item1 + 250, N.Item2, N.Item6, N.Item14, N.Item4, N.Item5, N.Item8, (string)R.FullName, N.Item9, N.Item10, N.Item11, N.Item12, N.Item13, N.Item7.ToString());

            var xRangeQuery = DeKalbRange.Concat(SycamoreRange);

            var xOrganizedQuery =
                from N in xRangeQuery
                orderby N.Item1 descending
                select N;

            FinalResult = xOrganizedQuery;

            var BusinessesDeKalb =
                from N in Result1
                join R in residents on N.Owner equals R.Id
                where N is Business && N.Sale && (N.City == "DeKalb")
                select (0, N.xcoord, N.ycoord, N.Address, N.City, N.State, N.Zip, (string)R.FullName, ((Business)N).ActiveRecruitment, ((Business)N).Name, ((Business)N).Type, ((Business)N).YearEstablished, (int)N.Price);

            var BusinessesSycamore =
                 from N in Result1
                 join R in residents on N.Owner equals R.Id
                 where N is Business && N.Sale && (N.City == "Sycamore")
                 select (0, N.xcoord + 250, N.ycoord, N.Address, N.City, N.State, N.Zip, (string)R.FullName, ((Business)N).ActiveRecruitment, ((Business)N).Name, ((Business)N).Type, ((Business)N).YearEstablished, (int)N.Price);

            BusinessResult = BusinessesDeKalb.Concat(BusinessesSycamore);

            var DeKalbSchool =
                from N in Result1
                join R in residents on N.Owner equals R.Id
                where N is School && N.Sale && N.City == "DeKalb"
                select (N.xcoord, N.ycoord, N.Address, N.City, N.State, N.Zip, (string)R.FullName, ((School)N).Name, ((School)N).Enrolled, ((School)N).YearEstablished, (int)N.Price);

            var SycamoreSchool =
                from N in Result1
                join R in residents on N.Owner equals R.Id
                where N is School && N.Sale && N.City == "Sycamore"
                select (N.xcoord + 250, N.ycoord, N.Address, N.City, N.State, N.Zip, (string)R.FullName, ((School)N).Name, ((School)N).Enrolled, ((School)N).YearEstablished, (int)N.Price);

            var SchoolInfo = DeKalbSchool.Concat(SycamoreSchool);

            SchoolResult = SchoolInfo;

            if ((!checkBox_Apartment.Checked && !checkBox_House.Checked) && (comboBox_ForSaleResidence.SelectedIndex == -1) && (comboBox_School.SelectedIndex == -1))
            {
                school = false;
            }

            //--------------//
            // Second Query //
            //--------------//

            // If query 2 is used then it'll limit Result1 dataset to only residences within the distance of the school

            IOrderedEnumerable < (int, uint, uint, string, string, string, string, string, string, uint, uint, uint, string, string, string) > Result2 = null;

            if (comboBox_School.SelectedIndex != -1)
            {
                string selectedSchool = comboBox_School.SelectedItem.ToString();
                (int, int) coords = (0, 0);
                string city = "";

                school = true;

                var getSchool =
                    from N in props
                    where (N is School)
                    where (((School)N).Name == selectedSchool)
                    select (N.xcoord, N.ycoord, N.City);

                foreach ((int, int, string) N in getSchool)
                {
                    coords = (N.Item1, N.Item2);
                    city = N.Item3;
                }

                var Houses =
                    from N in Result1
                    where N is House && N.Sale
                    select (N.xcoord, N.ycoord, N.Owner, N.City, N.State, N.Address, N.Price, N.Zip, ((House)N).Bedroom, ((House)N).Baths, ((House)N).Sqft, (((House)N).Floors).ToString(), ((House)N).Garage(), "");

                var Apartments =
                    from N in Result1
                    where N is Apartment && N.Sale
                    select (N.xcoord, N.ycoord, N.Owner, N.City, N.State, N.Address, N.Price, N.Zip, ((Apartment)N).Bedroom, ((Apartment)N).Baths, ((Apartment)N).Sqft, "", "", " # " + ((Apartment)N).Unit);

                var TempQuery = Houses.Concat(Apartments);

                if (city == "DeKalb")
                {
                    var DeKalbRangeQuery =
                            from N in TempQuery
                            join R in residents on N.Owner equals R.Id
                            where (N.Item4 == "DeKalb" &&
                                    (double)numericUpDown_ResidenceForSaleSchoolRange.Value >
                                    (Math.Sqrt(Math.Pow((int)N.Item1 - (int)coords.Item1, 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2)))
                                    )
                            select ((int)(Math.Sqrt(Math.Pow((int)N.Item1 - (int)coords.Item1, 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2))), N.Item1, N.Item2, N.Item6, N.Item14, N.Item4, N.Item5, N.Item8, (string)R.FullName,
                                    N.Item9, N.Item10, N.Item11, N.Item12, N.Item13, N.Item7.ToString()
                                    );

                    var SycamoreRangeQuery =
                        from N in TempQuery
                        join R in residents on N.Owner equals R.Id
                        where (N.Item4 == "Sycamore" &&
                                (double)numericUpDown_ResidenceForSaleSchoolRange.Value >
                                (Math.Sqrt(Math.Pow((((int)N.Item1 + 250) - ((int)coords.Item1)), 2) + Math.Pow(((int)N.Item2 - (int)coords.Item2), 2)))
                                )
                        select ((int)(Math.Sqrt(Math.Pow(((int)N.Item1 + 250) - ((int)coords.Item1), 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2))), N.Item1 + 250, N.Item2, N.Item6, N.Item14, N.Item4, N.Item5, N.Item8, (string)R.FullName,
                                N.Item9, N.Item10, N.Item11, N.Item12, N.Item13, N.Item7.ToString()
                                );

                    var RangeQuery = DeKalbRangeQuery.Concat(SycamoreRangeQuery);

                    var OrganizedQuery =
                        from N in RangeQuery
                        orderby N.Item1 descending
                        select N;

                    Result2 = OrganizedQuery;           // Data info:  Distance , X-Coords , Y-Coords , Address , Unit , City , State , Zip , Owner Name , Bedroom , Baths , Sqft , Floors , Garage , Price
                }
                else
                {
                    var DeKalbRangeQuery =
                            from N in TempQuery
                            join R in residents on N.Owner equals R.Id
                            where (N.Item4 == "DeKalb" &&
                                    (double)numericUpDown_ResidenceForSaleSchoolRange.Value >
                                    (Math.Sqrt(Math.Pow((int)N.Item1 - ((int)coords.Item1 + 250), 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2)))
                                    )
                            select ((int)(Math.Sqrt(Math.Pow((int)N.Item1 - ((int)coords.Item1 + 250), 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2))), N.Item1, N.Item2, N.Item6, N.Item14, N.Item4, N.Item5, N.Item8, (string)R.FullName,
                                    N.Item9, N.Item10, N.Item11, N.Item12, N.Item13, N.Item7.ToString()
                                    );

                    var SycamoreRangeQuery =
                        from N in TempQuery
                        join R in residents on N.Owner equals R.Id
                        where (N.Item4 == "Sycamore" &&
                                (double)numericUpDown_ResidenceForSaleSchoolRange.Value >
                                (Math.Sqrt(Math.Pow((((int)N.Item1 + 250) - ((int)coords.Item1 + 250)), 2) + Math.Pow(((int)N.Item2 - (int)coords.Item2), 2)))
                                )
                        select ((int)(Math.Sqrt(Math.Pow(((int)N.Item1 + 250) - ((int)coords.Item1 + 250), 2) + Math.Pow((int)N.Item2 - (int)coords.Item2, 2))), N.Item1 + 250, N.Item2, N.Item6, N.Item14, N.Item4, N.Item5, N.Item8, (string)R.FullName,
                                N.Item9, N.Item10, N.Item11, N.Item12, N.Item13, N.Item7.ToString()
                                );

                    var RangeQuery = DeKalbRangeQuery.Concat(SycamoreRangeQuery);

                    var OrganizedQuery =
                        from N in RangeQuery
                        orderby N.Item1 descending
                        select N;

                    Result2 = OrganizedQuery;           // Data info:  Distance , X-Coords , Y-Coords , Address , Unit , City , State , Zip , Owner Name , Bedroom , Baths , Sqft , Floors , Garage , Price
                }
                FinalResult = Result2;
                BusinessResult = Enumerable.Empty<(int, uint, uint, string, string, string, string, string, uint, string, string, string, int)>();
                SchoolResult = Enumerable.Empty<(uint, uint, string, string, string, string, string, string, uint, string, int)>();
            }

            //--------------//
            // Third Query  //
            //--------------//

            // If query 3 is used it'll add businesses to the results based on the distance from the selected residence

            //IEnumerable<(int, uint, uint, string, string, string, string, string, uint, string, string, string)> BusinessResult = null;

            if (comboBox_ForSaleResidence.SelectedIndex != -1)
            {
                string address = comboBox_ForSaleResidence.SelectedItem.ToString();
                string unit = "";
                bool isApartment = false;
                (uint, uint) coords = (0, 0);
                string city = "";

                home = true;

                PreviousSelectedResidence.Add(address);

                if (address.Contains("#"))
                {
                    string[] apartment = Regex.Split(address, " # ");
                    address = apartment[0];
                    unit = apartment[1];
                    isApartment = true;
                }

                if (isApartment)
                {
                    var apart =
                        from N in props
                        where N is Apartment
                        where (N.Address == address) && N.CheckUnit(unit)
                        select (N.xcoord, N.ycoord, N.City);

                    foreach ((uint, uint, string) c in apart)
                    {
                        coords = (c.Item1, c.Item2);
                        city = c.Item3;
                    }
                }
                else
                {
                    var house =
                        from N in props
                        where (N.Address == address)
                        select (N.xcoord, N.ycoord, N.City);

                    foreach ((uint, uint, string) c in house)
                    {
                        coords = (c.Item1, c.Item2);
                        city = c.Item3;
                    }
                }

                var TakeOutSelectedResidence =                                          // Taking out Selected Residence ForSale Icon and replacing it with Home Icon
                    from N in FinalResult
                    where (N.Item2 != coords.Item1 && N.Item3 != coords.Item2)
                    select N;

                Result2 =
                    from N in TakeOutSelectedResidence
                    orderby N.Item1
                    select N;

                var Businesses =
                    from N in props
                    where N is Business
                    select (Business)N;

                if (city == "DeKalb")
                {
                    var DeKalbRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "DeKalb" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow((int)N.xcoord - (int)coords.Item1, 2) + Math.Pow((int)N.ycoord - (int)coords.Item2, 2)))
                              )
                        select ((int)(Math.Sqrt(Math.Pow(((int)N.xcoord - (int)coords.Item1), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))), N.xcoord, N.ycoord, N.Address, N.City, N.State, N.Zip,
                                (string)R.FullName, N.ActiveRecruitment, N.Name, N.Type, N.YearEstablished, 0
                                );

                    var SycamoreRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "Sycamore" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow((((int)N.xcoord + 250) - ((int)coords.Item1)), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2)))
                               )
                        select ((int)(Math.Sqrt(Math.Pow((((int)N.xcoord + 250) - ((int)coords.Item1)), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))), N.xcoord + 250, N.ycoord, N.Address, N.City, N.State, N.Zip,
                                (string)R.FullName, N.ActiveRecruitment, N.Name, N.Type, N.YearEstablished, 0
                               );

                    BusinessResult = DeKalbRangeQuery.Concat(SycamoreRangeQuery);
                }
                else
                {
                    var DeKalbRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "DeKalb" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow((int)N.xcoord - ((int)coords.Item1 + 250), 2) + Math.Pow((int)N.ycoord - (int)coords.Item2, 2)))
                              )
                        select ((int)(Math.Sqrt(Math.Pow(((int)N.xcoord - ((int)coords.Item1) + 250), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))), N.xcoord, N.ycoord, N.Address, N.City, N.State, N.Zip,
                                (string)R.FullName, N.ActiveRecruitment, N.Name, N.Type, N.YearEstablished, 0
                                );

                    var SycamoreRangeQuery =
                        from N in Businesses
                        join R in residents on N.Owner equals R.Id
                        where (N.City == "Sycamore" &&
                                (double)numericUpDown_ResidenceForSaleBusinessRange.Value >
                                (Math.Sqrt(Math.Pow((((int)N.xcoord + 250) - ((int)coords.Item1 + 250)), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2)))
                              )
                        select ((int)(Math.Sqrt(Math.Pow((((int)N.xcoord + 250) - ((int)coords.Item1 + 250)), 2) + Math.Pow(((int)N.ycoord - (int)coords.Item2), 2))), N.xcoord + 250, N.ycoord, N.Address, N.City, N.State, N.Zip,
                                (string)R.FullName, N.ActiveRecruitment, N.Name, N.Type, N.YearEstablished, 0
                                );

                    BusinessResult = DeKalbRangeQuery.Concat(SycamoreRangeQuery);
                }
                SchoolResult = Enumerable.Empty<(uint, uint, string, string, string, string, string, string, uint, string, int)>();
            }

            //--------------//
            // Fourth Query //
            //--------------//

            // If query 4 is used it'll filter Result2

            if ((checkBox_Apartment.Checked || checkBox_House.Checked) && (comboBox_ForSaleResidence.SelectedIndex == -1) && (comboBox_School.SelectedIndex == -1))
            {
                BusinessResult = Enumerable.Empty<(int, uint, uint, string, string, string, string, string, uint, string, string, string, int)>();
                SchoolResult = Enumerable.Empty<(uint, uint, string, string, string, string, string, string, uint, string, int)>();
            }

            // Apartment checked
            if (checkBox_Apartment.Checked && !checkBox_House.Checked)
            {
                var CombinedQuery =
                    from N in FinalResult
                    where ((N.Item5 != "") && (N.Item10 >= numericUpDown_Bed.Value) && (N.Item11 >= numericUpDown_Bath.Value) && (N.Item12 >= numericUpDown_Sqft.Value))
                    orderby N.Item15 ascending
                    select N;

                FinalResult = CombinedQuery;
            }

            // House checked with garage not checked (no garage)
            else if (!checkBox_Apartment.Checked && checkBox_House.Checked && !checkBox_Garage.Checked)
            {
                var CombinedQuery =
                    from N in FinalResult
                    where ((N.Item5 == "") && N.Item14 == "no garage" && (N.Item10 >= numericUpDown_Bed.Value) && (N.Item11 >= numericUpDown_Bath.Value) && (N.Item12 >= numericUpDown_Sqft.Value))
                    orderby N.Item15 ascending
                    select N;

                FinalResult = CombinedQuery;
            }

            // House with garage checked and attached checked
            else if (!checkBox_Apartment.Checked && checkBox_House.Checked && checkBox_Garage.Checked && checkBox_attachedGarage.Checked)
            {
                var CombinedQuery =
                    from N in FinalResult
                    where ((N.Item5 == "") && N.Item14 == "an attached garage" && (N.Item10 >= numericUpDown_Bed.Value) && (N.Item11 >= numericUpDown_Bath.Value) && (N.Item12 >= numericUpDown_Sqft.Value))
                    orderby N.Item15 ascending
                    select N;

                FinalResult = CombinedQuery;
            }

            // House with garage checked and attached not checked
            else if (!checkBox_Apartment.Checked && checkBox_House.Checked && checkBox_Garage.Checked && !checkBox_attachedGarage.Checked)
            {
                var CombinedQuery =
                    from N in FinalResult
                    where ((N.Item5 == "") && N.Item14 == "a detached garage" && (N.Item10 >= numericUpDown_Bed.Value) && (N.Item11 >= numericUpDown_Bath.Value) && (N.Item12 >= numericUpDown_Sqft.Value))
                    orderby N.Item15 ascending
                    select N;

                FinalResult = CombinedQuery;
            }

            // Apartment && House checked
            else if (checkBox_Apartment.Checked && checkBox_House.Checked)
            {
                var CombinedQuery =
                    from N in FinalResult
                    where ((N.Item10 >= numericUpDown_Bed.Value) && (N.Item11 >= numericUpDown_Bath.Value) && (N.Item12 >= numericUpDown_Sqft.Value))
                    orderby N.Item15 ascending
                    select N;

                FinalResult = CombinedQuery;
            }

            search = true;

            Canvas.Refresh();

            Graphics G = Canvas.CreateGraphics();

            if (comboBox_ForSaleResidence.SelectedIndex != -1)
            {
                //
                // Print HomeIcon
                //
                string HomeAddress = comboBox_ForSaleResidence.SelectedItem.ToString();
                (int, int) Homecoords = (0, 0);

                if (HomeAddress.Contains("#"))
                {
                    string[] apartment = Regex.Split(HomeAddress, " # ");
                    HomeAddress = apartment[0];
                }

                foreach (Property prop in props)
                {
                    if (prop.Address == HomeAddress)
                    {
                        if (prop.City == "DeKalb")
                        {
                            Homecoords.Item1 = (int)(prop.xcoord);
                            Homecoords.Item2 = (int)(prop.ycoord);
                        }
                        else
                        {
                            Homecoords.Item1 = (int)(prop.xcoord + 250);
                            Homecoords.Item2 = (int)(prop.ycoord);
                        }
                    }
                }

                HomeCoords = Homecoords;

                PrintHomeIcon();
            }

            if (comboBox_School.SelectedIndex != -1)
            {
                string selectedSchool = comboBox_School.SelectedItem.ToString();

                (int, int) coords = (0, 0);

                var getSchool =                                     // Need to check for city
                    from N in props
                    where (N is School)
                    where (((School)N).Name == selectedSchool)
                    select ((int)N.xcoord, (int)N.ycoord, N.City);

                if (getSchool.First().Item3 == "DeKalb")
                {
                    coords = (getSchool.First().Item1, getSchool.First().Item2);
                }
                else
                {
                    coords = (getSchool.First().Item1 + 250, getSchool.First().Item2);
                }

                SchoolCoords = coords;

                PrintSchoolIcon(SchoolCoords.Item1, SchoolCoords.Item2);
            }

            //
            // Print Residence Marker Icons
            //
            foreach ((int, uint, uint, string, string, string, string, string, string, uint, uint, uint, string, string, string) residence in FinalResult)
            {
                PrintMarkerIcon((int)residence.Item2, (int)residence.Item3);
            }

            //
            // Print Business Icons
            //
            foreach ((int, uint, uint, string, string, string, string, string, uint, string, string, string, int) business in BusinessResult)
            {
                PrintBusinessIcon((int)business.Item2, (int)business.Item3);
            }

            //
            // Print School Icons for Query 1
            //
            foreach ((uint, uint, string, string, string, string, string, string, uint, string, int) school in SchoolResult)
            {
                PrintSchoolIcon((int)school.Item1, (int)school.Item2);
            }


            //comboBox_School.SelectedIndex = -1;                       // Leaving Inputs so user knows what they are searching
            //comboBox_ForSaleResidence.SelectedIndex = -1;
            //numericUpDown_ResidenceForSaleBusinessRange.Value = 0;
            //numericUpDown_ResidenceForSaleSchoolRange.Value = 0;
            //numericUpDown_Bath.Value = 0;
            //numericUpDown_Bed.Value = 0;
            //numericUpDown_Sqft.Value = 1200;
        }


        private void checkbox_ShowPrevious_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_ForSaleResidence.Items.Clear();

            if (checkbox_ShowPrevious.Checked)
            {
                comboBox_ForSaleResidence.Items.AddRange(PreviousSelectedResidence.ToArray<string>());
            }
            else
            {
                comboBox_ForSaleResidence.Items.AddRange(ForSaleResidence.ToArray<string>());
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            SortedSet<Property> dekalb = DeKalb.Prop;
            SortedSet<Property> sycamore = Sycamore.Prop;

            Graphics g = e.Graphics;

            // Scale
            using (Font font = new Font("Arial", 7))
            {
                g.DrawString("|--------|--------|", font, Brushes.WhiteSmoke, new Point(10, 230));
                g.DrawString(String.Format("{0}     {1, 0:0.#}     {2, 0:0.#}", 0*Delta, 25*Delta, 50*Delta), font, Brushes.WhiteSmoke, new Point(10, 237));
            }

            // Plotting locations
            var DeKalbHouses =
                        from N in dekalb
                        where N is House
                        select (((int)N.xcoord + DeltaX) * Delta, ((int)N.ycoord + DeltaY)* Delta, N.City, string.Join(" ", (N.Address).Split().Skip(1)));

            // Deleting DeKalb duplicates, unknown doubling
            int size = DeKalbHouses.Count();
            DeKalbHouses = DeKalbHouses.Take(size - (size / 2));

            var SycamoreHouses =
                        from N in sycamore
                        where N is House
                        select (((int)N.xcoord + 250 + DeltaX) * Delta, ((int)N.ycoord + DeltaY)* Delta, N.City, string.Join(" ", (N.Address).Split().Skip(1)));

            var CombinedQuery = DeKalbHouses.Concat(SycamoreHouses);

            //foreach ((int, int, string, string) N in CombinedQuery)
            //{
            //    Point place = new Point(N.Item1, N.Item2);
            //    Pen drawPlace = new Pen(Color.White);
            //    g.DrawRectangle(drawPlace, N.Item1, N.Item2, 1, 1);
            //}

            // Apartments

            var ApartmentProps =
                from N in dekalb
                where N is Apartment
                select (N.Address, N.City, N.Sale, N.Zip, N.Owner, N.State, ((int)N.xcoord + DeltaX) * Delta, ((int)N.ycoord + DeltaY) * Delta);

            //foreach ((string, string, bool, string, int, string, int, int) N in ApartmentProps)
            //{
            //    string[] address = N.Item1.Split(' ');
            //    int apartNumber = 0;
            //    if (address.Length > 1)
            //    {
            //        int.TryParse(address[0], out apartNumber);
            //    }

            //    Point place = new Point(N.Item7, N.Item8);
            //    Pen drawPlace = new Pen(Color.Orange);
            //    g.DrawRectangle(drawPlace, N.Item7, N.Item8, 1, 1);

            //}

            var SycamoreApartmentProps =
                from N in sycamore
                where N is Apartment
                select (N.Address, N.City, N.Sale, N.Zip, N.Owner, N.State, ((int)N.xcoord + 250 + DeltaX) * Delta, ((int)N.ycoord + DeltaY) * Delta);

            //foreach ((string, string, bool, string, int, string, int, int) N in SycamoreApartmentProps)
            //{
            //    string[] address = N.Item1.Split(' ');
            //    int apartNumber = 0;
            //    if (address.Length > 1)
            //    {
            //        int.TryParse(address[0], out apartNumber);
            //    }

            //    Point place = new Point(N.Item7, N.Item8);
            //    Pen drawPlace = new Pen(Color.Orange);
            //    g.DrawRectangle(drawPlace, N.Item7, N.Item8, 1, 1);

            //}

            // Schools

            var DeKalbSchools =
                from N in dekalb
                where N is School
                select (N.Address, N.City, N.Sale, N.Zip, N.Owner, N.State, ((int)N.xcoord + DeltaX) * Delta, ((int)N.ycoord + DeltaY) * Delta);

            //foreach ((string, string, bool, string, int, string, int, int) N in DeKalbSchools)
            //{
            //    string[] address = N.Item1.Split(' ');
            //    int schoolNumber = 0;
            //    if (address.Length > 1)
            //    {
            //        int.TryParse(address[0], out schoolNumber);
            //    }

            //    Point place = new Point(N.Item7, N.Item8);
            //    Pen drawPlace = new Pen(Color.LimeGreen);
            //    g.DrawRectangle(drawPlace, N.Item7, N.Item8, 1, 1);

            //}

            var SycamoreSchools =
                from N in sycamore
                where N is School
                select (N.Address, N.City, N.Sale, N.Zip, N.Owner, N.State, ((int)N.xcoord + 250 + DeltaX) * Delta, ((int)N.ycoord + DeltaY) * Delta);

            //foreach ((string, string, bool, string, int, string, int, int) N in SycamoreSchools)
            //{
            //    string[] address = N.Item1.Split(' ');
            //    int schoolNumber = 0;
            //    if (address.Length > 1)
            //    {
            //        int.TryParse(address[0], out schoolNumber);
            //    }

            //    Point place = new Point(N.Item7, N.Item8);
            //    Pen drawPlace = new Pen(Color.LimeGreen);
            //    g.DrawRectangle(drawPlace, N.Item7, N.Item8, 1, 1);

            //}

            // Businesses

            var DeKalbBusiness =
                from N in dekalb
                where N is Business
                select (N.Address, N.City, N.Sale, N.Zip, N.Owner, N.State, ((int)N.xcoord + DeltaX) * Delta, ((int)N.ycoord + DeltaY) * Delta);

            //foreach ((string, string, bool, string, int, string, int, int) N in DeKalbBusiness)
            //{
            //    string[] address = N.Item1.Split(' ');
            //    int businessNumber = 0;
            //    if (address.Length > 1)
            //    {
            //        int.TryParse(address[0], out businessNumber);
            //    }

            //    Point place = new Point(N.Item7, N.Item8);
            //    Pen drawPlace = new Pen(Color.Blue);
            //    g.DrawRectangle(drawPlace, N.Item7, N.Item8, 1, 1);

            //}

            var SycamoreBusiness =
                from N in sycamore
                where N is Business
                select (N.Address, N.City, N.Sale, N.Zip, N.Owner, N.State, ((int)N.xcoord + 250 + DeltaX) * Delta, ((int)N.ycoord + DeltaY) * Delta);

            //foreach ((string, string, bool, string, int, string, int, int) N in SycamoreBusiness)
            //{
            //    string[] address = N.Item1.Split(' ');
            //    int businessNumber = 0;
            //    if (address.Length > 1)
            //    {
            //        int.TryParse(address[0], out businessNumber);
            //    }

            //    Point place = new Point(N.Item7, N.Item8);
            //    Pen drawPlace = new Pen(Color.Blue);
            //    g.DrawRectangle(drawPlace, N.Item7, N.Item8, 1, 1);

            //}

            // Draw streets

            var DeKalbStreets =
                from N in DeKalbHouses
                orderby N.Item1
                group N by N.Item4;


            var SycamoreStreets =
                        from N in SycamoreHouses
                        orderby N.Item1
                        group N by N.Item4;

            var StreetQuery = DeKalbStreets.Concat(SycamoreStreets);

            foreach (var street in StreetQuery)
            {
                var streetKey = street.Key;             // Street Name, will be used to label street

                string city = street.First().Item3;

                var AllxCoords =                        // Get all X and Y coords of the street
                    from N in street
                    select (int)N.Item1;

                var AllyCoords =
                    from N in street
                    select (int)N.Item2;

                int firstXcoord = AllxCoords.FirstOrDefault();       // Grab the first coord
                int firstYcoord = AllyCoords.FirstOrDefault();

                bool sameXCoords = AllxCoords.Skip(1).All(xcoord => int.Equals(firstXcoord, xcoord));        // Compare and check if the street has the same x or y coords
                bool sameYCoords = AllyCoords.Skip(1).All(ycoord => int.Equals(firstYcoord, ycoord));

                Pen whitePen = new Pen(Color.White);
                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.White);
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                if (sameXCoords == true)
                {
                    g.DrawLine(whitePen, firstXcoord, (float)(DeltaY * Delta), firstXcoord, (float)((250 + DeltaY) * Delta));
                    g.DrawString(streetKey, drawFont, drawBrush, new Point((int)firstXcoord, (int)(((250 / 2) + DeltaY) * Delta)), drawFormat);
                    
                }
                else if (sameYCoords == true && city == "DeKalb")
                {
                    g.DrawLine(whitePen, (float)(DeltaX * Delta), firstYcoord, (float)((250 + DeltaX) * Delta), firstYcoord);
                    g.DrawString(streetKey, drawFont, drawBrush, new Point((int)(((250 / 4) + DeltaX) * Delta), firstYcoord));
                }
                else if (sameYCoords == true && city == "Sycamore")
                {
                    g.DrawLine(whitePen, (float)((250 + DeltaX) * Delta), firstYcoord, (float)((500 + DeltaX) * Delta), firstYcoord);
                    g.DrawString(streetKey, drawFont, drawBrush, new Point((int)((((500 / 4) * 3) + DeltaX) * Delta), firstYcoord));
                }
            }
        }

        public bool isDragging = false;
        public ToolTip toolTip = new ToolTip();

        int currentX;
        int currentY;

        double oldDeltaX = 0;
        double oldDeltaY = 0;

        //public void ToolTip(System.Drawing.Point mouse)
        //{
        //    toolTip = new ToolTip();
        //    IWin32Window info = Canvas;

        //    toolTip.Show("Address: " + address + "\n" + "City: " + city + "\n" + "Zip: " + zip + "\n" + "For sale: " + sale + "\n" + "Price: " + price, win, mouse, [pop up time]);

        //}

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        #region Move Map
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            currentX = e.X;
            currentY = e.Y;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging)
            {
                if (((e.Y - currentY) + oldDeltaY) + 250 <= 250 * Delta && ((e.Y - currentY) + oldDeltaY) >= -(250 * Delta - 250))
                {
                    DeltaY = (e.Y - currentY) + oldDeltaY;
                }

                if(((e.X - currentX) + oldDeltaX) + 500 <= 500 * Delta && ((e.X - currentX) + oldDeltaX) >= -(500 * Delta - 500))
                {
                    DeltaX = (e.X - currentX) + oldDeltaX;
                }

                Canvas.Refresh();

                if (home)
                {
                    PrintHomeIcon();

                    foreach ((int, uint, uint, string, string, string, string, string, uint, string, string, string, int) business in BusinessResult)
                    {
                        PrintBusinessIcon((int)business.Item2, (int)business.Item3);
                    }
                }

                if (school)
                {
                    PrintSchoolIcon(SchoolCoords.Item1, SchoolCoords.Item2);
                }

                if (search)
                {
                    foreach ((int, uint, uint, string, string, string, string, string, string, uint, uint, uint, string, string, string) residence in FinalResult)
                    {
                        PrintMarkerIcon((int)residence.Item2, (int)residence.Item3);
                    }

                    foreach ((uint, uint, string, string, string, string, string, string, uint, string, int) school in SchoolResult)
                    {
                        PrintSchoolIcon((int)school.Item1, (int)school.Item2);
                    }
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            oldDeltaY = DeltaY;
            oldDeltaX = DeltaX;
        }
        #endregion

        private void QueryForm_Load(object sender, EventArgs e)
        {

        }

        private void zoom_Percent_ValueChanged(object sender, EventArgs e)
        {
            if (zoom_Percent.Value == 1)
            {
                zoom_Text.Text = "Zoom: 100%";
                Delta = 1;

                DeltaX = 0;
                DeltaY = 0;
                oldDeltaX = 0;
                oldDeltaY = 0;
                Canvas.Refresh();
            }
            else if (zoom_Percent.Value == 2)
            {
                zoom_Text.Text = "Zoom: 125%";
                Delta = 1.25;

                DeltaX = 0;
                DeltaY = 0;
                oldDeltaX = 0;
                oldDeltaY = 0;
                Canvas.Refresh();
            }
            else if (zoom_Percent.Value == 3)
            {
                zoom_Text.Text = "Zoom: 150%";
                Delta = 1.5;
            }
            else if (zoom_Percent.Value == 4)
            {
                zoom_Text.Text = "Zoom: 175%";
                Delta = 1.75;
            }

            Canvas.Refresh();

            if (home)
            {
                PrintHomeIcon();

                foreach ((int, uint, uint, string, string, string, string, string, uint, string, string, string, int) business in BusinessResult)
                {
                    PrintBusinessIcon((int)business.Item2, (int)business.Item3);
                }
            }

            if (school)
            {
                PrintSchoolIcon(SchoolCoords.Item1, SchoolCoords.Item2);
            }

            if (search)
            {
                foreach ((int, uint, uint, string, string, string, string, string, string, uint, uint, uint, string, string, string) residence in FinalResult)
                {
                    PrintMarkerIcon((int)residence.Item2, (int)residence.Item3);
                }

                foreach ((uint, uint, string, string, string, string, string, string, uint, string, int) school in SchoolResult)
                {
                    PrintSchoolIcon((int)school.Item1, (int)school.Item2);
                }
            }
        }

        private void label_zoomOut_Click(object sender, EventArgs e)
        {
            zoom_Percent.Value = Math.Max(1, zoom_Percent.Value - 1);
        }


        private void label_zoomIn_Click(object sender, EventArgs e)
        {
            zoom_Percent.Value = Math.Min(4, zoom_Percent.Value + 1);
        }
    }
}
