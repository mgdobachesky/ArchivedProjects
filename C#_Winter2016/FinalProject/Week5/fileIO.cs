using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Week5
{

    class fileIO
    {

        public static string writeFile(string myFileName, string myString)
        {
            //Declare StreamWriter
            StreamWriter sw;

            //Set reult to OK for error purposes
            string result = "OK";

            try
            {
                //Set up the StreamWriter
                sw = new StreamWriter(File.Open(@myFileName, FileMode.OpenOrCreate));

                //Place the cursor on a new line
                sw.BaseStream.Seek(0, SeekOrigin.End);

                //Write a new record to the bottom of the file
                sw.WriteLine(myString);

                //Force the write, save the file, and clear the buffer
                sw.Flush();

                //Close the file reguardless of errors
                sw.Close();
            }

            catch (Exception err)
            {
                result = err.Message;
            }

            finally
            {
            }

            return result;

        }


        public static string[] readFile(string fileName)
        {
            //Create variable to hole file contents
            string[] fileString = new string[100];
            int index = 0;

            //Declare StreamReader object
            StreamReader sr;

            //Set up error trapping for file reading
            try
            {
                //Create new object and deal with how it will handle the file
                sr = new StreamReader(File.Open(@fileName, FileMode.Open));

                try
                {
                    //Read file line by line and store in an array
                    while (sr.EndOfStream == false)
                    {
                        fileString[index] = sr.ReadLine();
                        index++;
                    }
                }

                finally
                {
                    //Close the text file reguardless of errors
                    sr.Close();
                }
            }

            catch (Exception exc)
            {
                //Set return value equal to the error message if file reading fails
                fileString[0] = "ERROR: " + exc.Message;
            }

            //Return string to the main program
            return fileString;
        }

    }
}
