using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
                        // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                 // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                 // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                //create file
                
                StreamWriter sw = new StreamWriter("data.txt");

                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                                        //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }

                sw.Close();
            }
            else if (resp == "2")
            {
                string file = "data.txt";

                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {

                            //read file



                            string line = sr.ReadLine();
                            char[] delimiters = {',', '|'};
                            string[] arr = line.Split(delimiters);
                            DateTime d = Convert.ToDateTime(arr[0]);

                            //calculate total and average
                            int n1 = Convert.ToInt32(arr[1]);
                            int n2 = Convert.ToInt32(arr[2]);
                            int n3 = Convert.ToInt32(arr[3]);
                            int n4 = Convert.ToInt32(arr[4]);                            
                            int n5 = Convert.ToInt32(arr[5]);
                            int n6 = Convert.ToInt32(arr[6]);
                            int n7 = Convert.ToInt32(arr[7]);

                            double total = n1 + n2 + n3 + n4 + n5 + n6 + n7;
                            double avg = total/7;


                            //display data

                            Console.WriteLine($"Week of {d:MMM}, {d:dd}, {d:yyyy} \n Mo Tu We Th Fr Sa Su Tot Avg \n -- -- -- -- -- -- -- --- ---");
                            Console.WriteLine($" {arr[1], -3}{arr[2], -3}{arr[3], -3}{arr[4], -3}{arr[5], -3}{arr[6], -3}{arr[7], -4}{total, -3}{avg:n1}");
                        } 
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }

            }
        }
    }
}
