using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class clAlgorithm
    {
        #region Varibles
        private string filePath;
        private List<string> exctractedData;

        #endregion

        #region Constructors
        public clAlgorithm(string filePathParam, List<string> exctractedDataParam)
        {
            this.filePath = filePathParam;
            this.exctractedData = exctractedDataParam;

        }

        public clAlgorithm(string filePathParam)
        {
            this.filePath = filePathParam;

        }

        public clAlgorithm()
        {

        }
        #endregion

        #region Returnables

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        #endregion


        #region Functions

        public void ExtractData()
        {
            clTextFilehandler txtFilehandler = new clTextFilehandler(filePath);
            exctractedData = txtFilehandler.ReadDataFromCSV();
        }

        public string FirstTest()
        {
            ExtractData();

            

            return exctractedData[1];
        }

        public List<string> GeilteredList()
        {
            List<string> theList = new List<string>();

            int index = exctractedData.IndexOf("</Head>");

            for (int i = index; i < exctractedData.Count-1; i++)
            {
                try
                {
                    if (exctractedData[i].Contains("<h2>") && exctractedData[i+1].Contains("<h3>") && exctractedData[i+2].Contains("<h4>")  )
                    {
                        theList.Add((RemoveWrappers(exctractedData[i]).Replace(',',' '))
                            +","+
                            (RemoveWrappers(exctractedData[i+1]).Replace(',', ' '))
                            +","+
                            (RemoveWrappers(exctractedData[i+3]).Replace(',', ' '))
                            );
                        i += 3;
                    }
                }
                catch (Exception e)
                {

                    
                }

            }

            WriteListToCSV(theList);
            return theList;
        }

        public void WriteListToCSV(List<String> theList)
        {
            clTextFilehandler txtFilehandler = new clTextFilehandler("C:\\TheBigTest.csv");
            txtFilehandler.WriteDataToCSV(theList);
        }
        #endregion


        #region Special Functions

        public string RemoveWrappers(string mainText)
        {
            string tempHolder = "";

            if (mainText.Contains('<'))
            {
                if (mainText[0] != '<')
                {
                    tempHolder = mainText.Substring(0,mainText.IndexOf('<'));
                }
                return RemoveWrappers(tempHolder + mainText.Substring(mainText.IndexOf('>') + 1));
            }
            else
            {
                return mainText;
            }

            return "";
        }

        #endregion

    }
}
