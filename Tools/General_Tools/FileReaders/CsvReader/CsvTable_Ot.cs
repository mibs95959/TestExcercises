using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.General_Tools.FileReaders.CsvReader
{
    public class CsvTable_Ot
    {

        private List<CsvColumn_Ot> table;

        public CsvTable_Ot()
        {
            table = new List<CsvColumn_Ot>();
        }

        public List<CsvColumn_Ot> GetTable()
        {
            return table;
        }

        public void AddColumn(string title)
        {
            CsvColumn_Ot newColumn = new CsvColumn_Ot();
            newColumn.SetColumnTitle(title);
            table.Add(newColumn);
        }

        public CsvColumn_Ot GetColumnWithGivenTitle(string title)
        {
            foreach (CsvColumn_Ot column in table)
            {
                if (column.GetColumnTitle().Equals(title))
                {
                    return column;
                }
            }
            Console.WriteLine("the given Title does not belongs to any of the current columns in the table.");
            return null;
        }

        public CsvColumn_Ot GetColumnByIndex(int index)
        {
            return table[index];
        }

        public List<string> GetColumnTitles()
        {
            List<string> columnTitles = new List<string>();
            foreach (CsvColumn_Ot column in table)
            {
                columnTitles.Add(column.GetColumnTitle());
            }
            return columnTitles;
        }




    }
}
