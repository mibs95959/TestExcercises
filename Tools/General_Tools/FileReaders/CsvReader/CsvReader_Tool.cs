using Microsoft.VisualBasic.FileIO;


namespace Tools.General_Tools.FileReaders.CsvReader
{

    public class CsvReader_Tool
    {

        /// <summary>
        /// This method could be later transformed in order to handle different types of Delimiters and
        /// therefore serve other purposes too.
        /// 
        /// But for now this is its only purpose.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter">, o ;</param>
        /// <returns></returns>
        private static TextFieldParser ParseGivenCsvFile(string path, string delimiter)
        {
            TextFieldParser parser = new TextFieldParser(path);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(delimiter);
            return parser;
        }

        /// <summary>
        /// Important Note: 
        /// The idea of this method and object types is to have a tool that can easily 
        /// translate CSV Files into either Test Data or to certain Object Types for later handling
        /// or manipulation.
        /// 
        /// The Table must consist of:
        /// - First row: 
        /// Where the title of what the column is about
        /// 
        /// - All the other rows below: 
        /// Where the actual data is.
        ///
        /// CsvTables are made out of Columns, meaning its made out of a list of Columns.
        /// 
        /// </summary>
        /// <param name="path">Where the CSV file is.</param>
        /// <returns>The conversion of that CSV file into our own object type for later easier manipulation</returns>
        public static CsvTable_Ot FromCsvToTable(string path)
        {
            CsvTable_Ot result = new CsvTable_Ot();
            bool firstRow = true;
            TextFieldParser parser = ParseGivenCsvFile(path, ",");

            while (!parser.EndOfData)
            {
                int column = 0;
                string[] fields = parser.ReadFields();
                foreach (string field in fields)
                {
                    if (firstRow)
                    {
                        result.AddColumn(field);
                    }
                    else
                    {
                        result.GetColumnByIndex(column).AddValue(field);
                        column++;
                    }
                }
                firstRow = false;
            }
            return result;
        }

    }
}
