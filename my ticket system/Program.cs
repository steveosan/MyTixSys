using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace my_ticket_system
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "courseData.csv";
            string choice;

            do
            {
                // ask user a question
                Console.WriteLine("1) Read Ticket information from file.");
                Console.WriteLine("2) Create New Ticket from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line); 
                    }sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }    
                else if (choice == "2")
                {   
                    if (!File.Exists(file))
                    {
                    StreamWriter sw1 = new StreamWriter("courseData.csv");
                    sw1.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    sw1.WriteLine("1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones");
                    sw1.Close();
                                        
                    }
                    // create file from data
                    StreamWriter sw = new StreamWriter("courseData.csv", true);
                    for (int i = 0; i < 7; i++)
                    {

                        // ask a question
                        Console.WriteLine("Add a New Ticket (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }

                        // prompt for ticket ID number
                        Console.WriteLine("Enter the ticket ID number.");
                        // save the ticket ID number
                        int ID = Convert.ToInt32(Console.ReadLine());

                        // prompt for ticket summary
                        Console.WriteLine("Enter the ticket summary.");
                        // save the ticket summary
                        string summary = Console.ReadLine();

                        // prompt for ticket summary
                        Console.WriteLine("Enter the ticket status.");
                        // save the ticket summary
                        string status = Console.ReadLine();

                        // prompt for ticket priority
                        Console.WriteLine("Set this tickets priority");
                        //save the ticket prioity
                        string priority = Console.ReadLine();

                        // prompt for who is assigned
                        Console.WriteLine("Who is assigned to this ticket?");
                        //save who is assigned
                        string assigned = Console.ReadLine();
                        
                        // prompt for who submitted
                        Console.WriteLine("Who is submitted this ticket?");
                        //save who is assigned
                        string submitted = Console.ReadLine();
                        
                        //prompt for who is watching
                        Console.WriteLine("How many watchers for this ticket?");
                        int numWatchers = Convert.ToInt32(Console.ReadLine());

                        string[] watchers = new string[numWatchers];
                        int k = 0;
                        while (k < numWatchers)
                            {
                                Console.WriteLine("who is watching this ticket?");
                                watchers[k] = Console.ReadLine();
                                k++;
                            }
                        //save who is watching this ticket                
                        
                        string watching = string.Join("|", watchers);


                            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ID, summary,status,priority,submitted, assigned,watching);


                    }
                    sw.Close();
                }     
            } while (choice == "1" || choice == "2");
        }
    }
}
