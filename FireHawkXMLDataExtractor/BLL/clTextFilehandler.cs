using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace BLL
{
    class clTextFilehandler
    {
        private string filePath;
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public clTextFilehandler(string filePathParam = "Problem.csv")
        {
            this.filePath = filePathParam;
        }


        #region text reader
        public List<string> ReadDataFromCSV()
        {
            List<string> dataRaw = new List<string>();
            try
            {
                if (File.Exists(this.filePath))
                {
                    stream = new FileStream(this.filePath, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(stream);

                    while (!reader.EndOfStream)
                    {
                        dataRaw.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                reader.Close();
                stream.Close();
            }

            return dataRaw;
        }

        #endregion

        #region Writer
        public void WriteDataToCSV(List<string> dataToWrite)
        {

            try
            {
                if (File.Exists(this.filePath))
                {
                    stream = new FileStream(this.filePath, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    stream = new FileStream(this.filePath, FileMode.Create, FileAccess.Write);
                }

                writer = new StreamWriter(stream);

                foreach (string itemToWrite in dataToWrite)
                {
                    if (writer.BaseStream == null)
                    {
                       // throw new WriteException();
                    }

                    writer.WriteLine(itemToWrite);

                    writer.Flush();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                writer.Close();
                stream.Close();
            }


        }

        #endregion
    }
}
