using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace class_week_2
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

    }

}
