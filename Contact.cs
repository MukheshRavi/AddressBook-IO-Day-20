using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AddressBookIO
{
    public interface IAddress { };
    [Serializable]
    class Contacts
    {
        public string frstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string email;
        public string zip;
        public string phnNo;
        public List<Contacts> contactsList = new List<Contacts>();
        public Dictionary<Contacts, string> addressBook = new Dictionary<Contacts, string>();
        public Dictionary<Contacts, string> cityList = new Dictionary<Contacts, string>();
        public Dictionary<Contacts, string> stateList = new Dictionary<Contacts, string>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Contacts()
        {

        }
        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="frstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="email"></param>
        /// <param name="zip"></param>
        /// <param name="phnNo"></param>
        public Contacts(string frstName, string lastName, string address, string city, string state, string email, string zip, string phnNo)
        {
            this.frstName = frstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.email = email;
            this.zip = zip;
            this.phnNo = phnNo;

        }

        /// <summary>
        /// This method is used to Edit details by taking First name as parameter
        /// </summary>
        /// <param name="name"></param>
        public void EditDetails(string name)
        {
            Contacts contacts = new Contacts();
            for (int i = 0; i < contactsList.Count; i++)
            {
                contacts = contactsList[i];
                if (contacts.frstName == name)
                {
                    Console.WriteLine("enter the number of details you want to edit");

                    Console.WriteLine(" 1:frstName  2:lastName  3:address  4:city  5:state  6:email 7:zip  8:PhoneNumber ");
                    int num = Convert.ToInt32(Console.ReadLine()); //user enters the which detail should be updated
                    Console.WriteLine("enter the new detail");
                    string detail = Console.ReadLine();  //user enters the new detail

                    switch (num)
                    {
                        case 1:
                            contacts.frstName = detail;
                            break;

                        case 2:
                            contacts.lastName = detail;
                            break;
                        case 3:
                            contacts.address = detail;
                            break;
                        case 4:
                            contacts.city = detail;
                            break;
                        case 5:
                            contacts.state = detail;
                            break;
                        case 6:
                            contacts.email = detail;
                            break;
                        case 7:
                            contacts.zip = detail;
                            break;
                        case 8:
                            contacts.phnNo = detail;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// This method is used to take user details and add contacts in list
        /// </summary>
        public void AddDetails()
        {
            Console.WriteLine("Enter the name of address book");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Contact Details");
            Console.WriteLine("Enter First Name");
            string frstName = Console.ReadLine();

            Console.WriteLine("Enter last Name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Address ");
            string address = Console.ReadLine();

            Console.WriteLine("Enter city Name");
            string city = Console.ReadLine();

            Console.WriteLine("Enter state Name");
            string state = Console.ReadLine();

            Console.WriteLine("Enter email id");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Zip code");
            string zip = Console.ReadLine();

            Console.WriteLine("Enter Phone Number");
            string phnNo = Console.ReadLine();

            Contacts contacts = new Contacts(frstName, lastName, address, city, state, email, zip, phnNo);
            ///creating FullName using FirstName and LastName
            string fullName = contacts.frstName + " " + contacts.lastName;
            ///if list does not contain any contacts then it will add first entered contact
            if (contactsList.Count == 0)
            {
                ///Adding into List and Dictionary
                contactsList.Add(contacts);
                addressBook.Add(contacts, name);
                cityList.Add(contacts, city);
                stateList.Add(contacts, state);
                Console.WriteLine("New contact added");
                Console.WriteLine("Firstname:" + contacts.frstName + "\nLastname:" + contacts.lastName + "\naddress:" + contacts.address +
                    "\ncity:" + contacts.city + "\nstate:" + contacts.state + "\nzip" + contacts.zip + "\nPhone Number:" + contacts.phnNo);
            }
            ///if list contains contacts then it will go into else block
            else
            {
                foreach (KeyValuePair<Contacts, string> a in addressBook)
                {
                    string fullNameInList = a.Key.frstName + " " + a.Key.lastName;
                    /// If entered AddressBook name already present in list 
                    if (a.Value.ToLower() == name.ToLower())
                    {
                        ///Then checks for fullName ,if fullName not  present then it will go into if block 
                        if (fullNameInList.ToLower() != fullName.ToLower())
                        {
                            ///Adding into List and Dictionary

                            contactsList.Add(contacts);
                            addressBook.Add(contacts, name);
                            cityList.Add(contacts, city);
                            stateList.Add(contacts, state);
                            Console.WriteLine("New contact added");
                            Console.WriteLine("Firstname:" + contacts.frstName + "\nLastname:" + contacts.lastName + "\naddress:" + contacts.address +
                             "\ncity:" + contacts.city + "\nstate:" + contacts.state + "\nzip" + contacts.zip + "\nPhone Number:" + contacts.phnNo);
                            break;


                        }
                        else
                        {
                            Console.WriteLine("Contact Already Present");
                            break;
                        }
                    }

                    else
                    {
                        ///If Different Address Book then the contact will be added
                        ///Adding in to List and Dictionary
                        contactsList.Add(contacts);
                        addressBook.Add(contacts, name);
                        cityList.Add(contacts, city);
                        stateList.Add(contacts, state);
                        Console.WriteLine("New contact added");
                        Console.WriteLine("Firstname:" + contacts.frstName + "\nLastname:" + contacts.lastName + "\naddress:" + contacts.address +
                            "\ncity:" + contacts.city + "\nstate:" + contacts.state + "\nzip" + contacts.zip + "\nPhone Number:" + contacts.phnNo);
                        break;

                    }
                }
            }

        }
        /// <summary>
        /// Displays the contacts in Address Book
        /// </summary>
        public void DisplayAddressBook()
        {
            ///if addressBook does not contain any contacts
            if (addressBook.Count == 0)
                Console.WriteLine("There is no contact added to display");
            else
            {
                ///if contains then it will display contacts
                foreach (KeyValuePair<Contacts, string> a in addressBook)
                {
                    Console.WriteLine("Name of AddressBook: firstname, lastname, address, city, state, email, zip, phoneNumber");
                    Console.WriteLine(a.Value + ":" + a.Key.frstName + "," + a.Key.lastName + "," + a.Key.address + "," + a.Key.city + ","
                        + a.Key.state + "," + a.Key.email + "," + a.Key.zip + "," + a.Key.phnNo);

                }
            }
        }
        /// <summary>
        /// this method deletes the contact based on first name entered
        /// </summary>
        /// <param name="named"></param>
        public void DeleteContact(string named)
        {
            Contacts c = new Contacts();
            for (int i = 0; i < contactsList.Count; i++)
            {
                c = contactsList[i];
                if (c.frstName == named)
                {
                    contactsList.Remove(c);
                }
            }
        }
        /// <summary>
        /// To Check for a contact with specified city or state
        /// </summary>
        public void GetPersonFromCityOrState()
        {
            ///To check if there is any contact added in list
            if (addressBook.Count == 0)
                Console.WriteLine("There is no contact added");
            else
            {
                ///checks for contact with specified city or state
                Console.WriteLine("\nEnter the city or state name to find the person");
                string value = Console.ReadLine();
                foreach (KeyValuePair<Contacts, string> a in addressBook)
                {
                    if (a.Key.city == value || a.Key.state == value)
                        Console.WriteLine("Name of AddressBook: firstname, lastname, address, city, state, email, zip, phoneNumber");
                    Console.WriteLine(a.Value + ":" + a.Key.frstName + "," + a.Key.lastName + "," + a.Key.address + "," + a.Key.city + ","
                        + a.Key.state + "," + a.Key.email + "," + a.Key.zip + "," + a.Key.phnNo);

                }
            }
        }
        /// <summary>
        /// Displays State and City lists 
        /// </summary>
        public void DisplayCityAndStateList()
        {
            ///To check if there is any contact added in list
            if (addressBook.Count == 0)
                Console.WriteLine("There is no contact added");
            ///if contacts are present then displays both lists
            else
            {
                foreach (KeyValuePair<Contacts, string> keyValuePair in cityList)
                {
                    Console.WriteLine("The contacts with " + keyValuePair.Value + " city are :");
                    Console.WriteLine("First Name: " + keyValuePair.Key.frstName + " Last Name: " + keyValuePair.Key.lastName +
                            " Address: " + keyValuePair.Key.address + " city: " + keyValuePair.Key.city + " state: " + keyValuePair.Key.state
                             + " Email:" + keyValuePair.Key.email + "Zip: " + keyValuePair.Key.zip + "Phone Nmuber: " + keyValuePair.Key.phnNo);
                }
                foreach (KeyValuePair<Contacts, string> keyValuePair in stateList)
                {
                    Console.WriteLine("The contacts with " + keyValuePair.Value + " state are :");
                    Console.WriteLine("First Name: " + keyValuePair.Key.frstName + " Last Name: " + keyValuePair.Key.lastName +
                            " Address: " + keyValuePair.Key.address + " city: " + keyValuePair.Key.city + " state: " + keyValuePair.Key.state
                             + " Email:" + keyValuePair.Key.email + "Zip: " + keyValuePair.Key.zip + "Phone Nmuber: " + keyValuePair.Key.phnNo);

                }
            }
        }
        /// <summary>
        /// Displays count of contacts for a specific city or state
        /// </summary>
        public void CountForCityAndState()
        {
            ///To check if there is any contact added in list
            if (addressBook.Count == 0)
                Console.WriteLine("There is no contact added");

            ///Take the input from user 
            Console.WriteLine("Enter the name of city or state to get Count");
            string name = Console.ReadLine();
            int count = 0;
            foreach (KeyValuePair<Contacts, string> keyValuePair in cityList)
            {
                ///checks for entered city name
                if (keyValuePair.Value == name)
                    count++;
            }

            foreach (KeyValuePair<Contacts, string> keyValuePair in stateList)
            {
                ///checks for entered state name
                if (keyValuePair.Value == name)
                    count++;
            }
            ///Displays count of city or state
            Console.WriteLine("The count for entered city or state name " + name + "is:" + count);
        }
        public void WriteToFile()
        {
            ///Given path to create or open a file
            string path = @"C:\Users\MUKHESH\source\repos\AddressBookIO\Contacts.txt";
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            /// Copy the details from address book list to serialize them in to file
            formatter.Serialize(stream, addressBook);
        }
        public void ReadFromFile()
        {
            FileStream stream;
            string path = @"C:\Users\MUKHESH\source\repos\AddressBookIO\Contacts.txt";
                /// Open the specified path
                /// If path is not found then it throws file not found exception
                using (stream = new FileStream(path, FileMode.Open))
                {
                 BinaryFormatter formatter = new BinaryFormatter();
                 /// Deserialize the data from file
                 Dictionary<Contacts, string> c = new Dictionary<Contacts, string>();
                 c= ( Dictionary<Contacts, string>)formatter.Deserialize(stream);
                 ///Displaying addressbook list after deserialising
                foreach(KeyValuePair<Contacts, string> a in c)
                   Console.WriteLine(a.Value + ":" + a.Key.frstName + "," + a.Key.lastName + "," + a.Key.address + "," + a.Key.city + ","
                        + a.Key.state + "," + a.Key.email + "," + a.Key.zip + "," + a.Key.phnNo);
            };
        }
    }
}
