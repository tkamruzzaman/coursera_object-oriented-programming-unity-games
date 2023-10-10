using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// A class holding personal data for a person
    /// </summary>
    public class PersonalData
    {
        #region Fields
        // configuration data
        static string firstName = "";
        static string middleName = "";
        static string lastName = "";
        static string streetAddress = "";
        static string city = "";
        static string state = "";
        static string postalCode = "";
        static string country = "";
        static string phoneNumber = "";
        #endregion

        #region Properties

        /// <summary>
        /// Gets the person's first name
        /// </summary>
        public string FirstName { get { return firstName; } }

        /// <summary>
        /// Gets the person's middle name
        /// </summary>
        public string MiddleName { get { return middleName; } }

        /// <summary>
        /// Gets the person's last name
        /// </summary>
        public string LastName { get { return lastName; } }

        /// <summary>
        /// Gets the person's street address
        /// </summary>
        public string StreetAddress { get { return streetAddress; } }

        /// <summary>
        /// Gets the person's city or town
        /// </summary>
        public string City { get { return city; } }

        /// <summary>
        /// Gets the person's state or province
        /// </summary>
        public string State { get { return state; } }

        /// <summary>
        /// Gets the person's postal code
        /// </summary>
        public string PostalCode { get { return postalCode; } }

        /// <summary>
        /// Gets the person's country
        /// </summary>
        public string Country { get { return country; } }

        /// <summary>
        /// Gets the person's phone number (digits only, no 
        /// parentheses, spaces, or dashes)
        /// </summary>
        public string PhoneNumber { get { return phoneNumber; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// Reads personal data from a file. If the file
        /// read fails, the object contains an empty string for all
        /// the personal data
        /// </summary>
        /// <param name="fileName">name of file holding personal data</param>
        public PersonalData(string fileName)
        {
            // your code can assume we know the order in which the
            // values appear in the string; it's the same order as
            // they're listed for the properties above. We could do 
            // something more complicated with the names and values, 
            // but that's not necessary here

            // IMPORTANT: The mono compiler the automated grader uses
            // does NOT support the string Split method. You have to 
            // use the IndexOf method to find comma locations and the
            // Substring method to chop off the front of the string
            // after you extract each value to extract and save the
            // personal data

            // read and save configuration data from file
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(fileName);

                string csvValues = reader.ReadLine();

                List<string> valuesList = new List<string>();
                int startIndex = 0;
                int endIndex = 0;

                while (endIndex < csvValues.Length)
                {
                    // Find the next comma or the end of the string
                    while (endIndex < csvValues.Length && csvValues[endIndex] != ',')
                    {
                        endIndex++;
                    }

                    // Extract the substring between startIndex and endIndex
                    string singleValue = (csvValues.Substring(startIndex, endIndex - startIndex)).Trim();
                    valuesList.Add(singleValue);

                    // Move the start index to the character after the comma (if present)
                    startIndex = endIndex + 1;
                    endIndex = startIndex;
                }

                string[] values = valuesList.ToArray();

                firstName = values[0];
                middleName = values[1];
                lastName = values[2];
                streetAddress = values[3];
                city = values[4];
                state = values[5];
                postalCode = values[6];
                country = values[7];
                phoneNumber = values[8];

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        #endregion
    }
}
