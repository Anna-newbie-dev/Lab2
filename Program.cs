using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonsLib;

namespace LaunchLab
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to create lists ");
            Console.ReadKey();
            Console.Write("\nCreating lists... ");

            var listOne = new PersonList();
            var listTwo = new PersonList();

            var firstList = new Person[]
            {
                new Person("Зohn", "Do-e", 45, Gender.Male),
                new Person("Billy", "Herrington", 48, Gender.Male),
                new Person("Lisa", "Su", 50, Gender.Female),
            };

            var secondList = new Person[]
            {
                new Person("Robert", "Swan", 59, Gender.Male),
                new Person("Van", "Darkholme", 47, Gender.Male),
                new Person("Fo-o", "Bar", 34, Gender.Female),
            };

            listOne.AddRange(firstList);
            listTwo.AddRange(secondList);

            Console.WriteLine("\nLists have been created. "
                + "Press any key to display the lists.");
            Console.ReadKey();
            Console.WriteLine();
            PrintLists(listOne, listTwo);

            bool flag = true;
            while (flag)
            {
                PrintMenu();
                switch (ExceptionHandler())
                {
                    case 1:
                        Console.WriteLine("Adding a new person " + 
                            "programmatically...");
                        var newEntry = new Person("Rick", "Astley", 
                            54, Gender.Male);
                        listOne.AddPerson(newEntry);
                        Console.WriteLine("Successful!");
                        Console.WriteLine("Press Y to show list, any key " +
                            "to go back to the menu.");
                        char key = Console.ReadKey().KeyChar;
                        if (key == 'y' || key == 'н')
                        {
                            PrintLists(listOne);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Which index whould you like " +
                            "to copy?");
                        listTwo.AddPerson(ExceptionHandler(firstList));
                        SuccessfulMethod();
                        PrintLists(listOne, listTwo);
                        break;
                    case 3:
                        Console.WriteLine("Which index whould you like "
                        + " to delete?");
                        listOne.DeletePersonByIndex(IndexExceptionHandler
                            (firstList));
                        SuccessfulMethod();
                        PrintLists(listOne, listTwo);
                        break;
                    case 4:
                        listOne.AddPerson(RandomPerson.PickPerson());
                        SuccessfulMethod();
                        PrintLists(listOne);
                        break;
                    case 5:
                        listTwo.Clear();
                        SuccessfulMethod();
                        PrintLists(listOne,listTwo);
                        break;
                    case 6:
                        listOne.AddPerson(CreateNewPerson());
                        PrintLists(listOne, listTwo);
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        TryAgain();
                        break;
                }
            }
        }
        /// <summary>
        /// Displays two lists on the screen
        /// </summary>
        /// <param name="firstList">Первый список</param>
        /// <param name="secondList">Второй список</param>
        static void PrintLists(PersonList firstList,
            PersonList secondList)
        {
            var personLists = new PersonList[]
            {
                firstList,
                secondList
            };

            for (int i = 0; i < personLists.Length; i++)
            {
                Console.WriteLine("Список " + (i + 1) + "\n");
                Console.WriteLine("   Name      Surname     Age      Gender");
                for (int j = 0; j < personLists[i].Length; j++)
                {
                    Console.WriteLine("{0,10} | {1,10} | {2,3} | {3,7}",
                        personLists[i][j].FirstName, personLists[i][j].LastName,
                        personLists[i][j].Age, personLists[i][j].Gender);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------\n");
        }

        /// <summary>
        /// Displays a list on the screen
        /// </summary>
        /// <param name="personList">A list to be displayed</param>
        static void PrintLists(PersonList personList)
        {
            var personLists = new PersonList[]
            {
                personList,
            };

            for (int i = 0; i < personLists.Length; i++)
            {
                //Console.WriteLine("Список " + (i + 1) + "\n");

                for (int j = 0; j < personLists[i].Length; j++)
                {
                    Console.WriteLine(
                        personLists[i][j].FirstName + "\t" + personLists[i][j].LastName +
                        "\t" + personLists[i][j].Age + "\t" + personLists[i][j].Gender);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("----------\n");
        }

        /// <summary>
        /// Shows menu
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What should be done next?");
            Console.WriteLine("1 - Add a new person programmatically;");
            Console.WriteLine("2 - Copy an entry to List 2;");
            Console.WriteLine("3 - Delete an entry by its index;");
            Console.WriteLine("4 - Add a random person");
            Console.WriteLine("5 - Clear the second list;");
            Console.WriteLine("6 - Add a new person from keyboard.");
            Console.WriteLine("0 - Exit program.");
        }

        /// <summary>
        /// Exception handler
        /// </summary>
        static int ExceptionHandler()
        {
            int option = 0;
            while (true)
            {
                try
                {
                    option = int.Parse(Console.ReadLine());
                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered a wrong format!" +
                        " Please, enter once more.");
                }
            }
        }

        /// <summary>
        /// The overloaded
        /// ExceptionHandler
        /// <param name="list">Array</param>
        /// <returns></returns>
        static Person ExceptionHandler(Person[] list)
        {
            int option = 0;
            while (true)
            {
                try
                {
                    option = int.Parse(Console.ReadLine());
                    return list[option - 1];
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered a wrong format!" +
                        " Please, enter once more..");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Index doesnt't exist. Please, " +
                        "enter once more.");
                }
            }

            return null;
        }

        /// <summary>
        /// Handles OutOfRangeException
        /// <param name="list">Array</param>
        /// <returns>Index</returns>
        static int IndexExceptionHandler(Person[] list)
        {
            int option = 0;
            while (true)
            {
                try
                {
                    option = int.Parse(Console.ReadLine()) - 1;
                    var temp = list[option];
                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You've entered a wrong format!" +
                        " Please, enter once more.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Index doesnt't exist. Please, " +
                        "enter once more");
                }
            }
        }

        /// <summary>
        /// Shows "Successful!" message
        /// </summary>
        public static void SuccessfulMethod()
        {
            Console.WriteLine("Successful!");
            Console.WriteLine("Press any key see the updated lists");
            Console.ReadKey();
        }

        /// <summary>
        /// "TryAgain" method
        /// </summary>
        public static void TryAgain()
        {
            Console.WriteLine("Please, try again.");
        }

        /// <summary>
        /// New Person instance
        /// to be filled from keyboard
        /// </summary>
        /// <returns>A Person instance</returns>
        public static Person CreateNewPerson()
        {
            var createdPerson = new Person();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.Write("Please, type the first name: ");
                    createdPerson.FirstName = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.Write("Please, type the last name: ");
                    createdPerson.LastName = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.Write("Please, enter the age (0-150): ");
                    createdPerson.Age = ExceptionHandler();
                }),
                new Action(() =>
                {
                    bool tempBool = true;
                    while (tempBool)
                    {
                        Console.Write("Please, enter the gender. " +
                            "0 - Male, 1 - Female: ");
                        switch(ExceptionHandler())
                        {
                            case 0:
                                createdPerson.Gender = Gender.Male;
                                tempBool = false;
                                break;
                            case 1:
                                createdPerson.Gender = Gender.Female;
                                tempBool = false;
                                break;
                            default:
                                Console.WriteLine("Try to enter gender " + 
                                    "once more.");
                                break;                        
                        }
                    }

                }),
            };
            actions.ForEach(SetValue);
            return createdPerson;
        }

        /// <summary>
        /// Получить пользовательский ввод и задать параметр
        /// </summary>
        /// <param name="action">Делегат с заданием параметра</param>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (ArgumentException)
                {
                    TryAgain();
                }
                catch (FormatException)
                {
                    TryAgain();
                }
                catch (InvalidOperationException)
                {
                    TryAgain();
                }
            }
        }
    }
}

