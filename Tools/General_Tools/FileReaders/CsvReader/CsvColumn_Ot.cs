using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.General_Tools.FileReaders.CsvReader
{
    /// <summary>
    /// Just in case, "Ot" in the framework stands for: Object Type.
    /// </summary>
    public class CsvColumn_Ot
    {

        private string ColumnTitle;
        private List<string> ColumnValues;

        public CsvColumn_Ot()
        {
            ColumnValues = new List<string>();
        }

        public void SetColumnTitle(string title)
        {
            ColumnTitle = title;
        }

        public string GetColumnTitle()
        {
            return ColumnTitle;
        }

        public void AddValue(string value)
        {
            ColumnValues.Add(value);
        }

        public List<string> GetColumnValues()
        {
            return ColumnValues;
        }




    }
}
