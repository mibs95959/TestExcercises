using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{

    /// <summary>
    /// The Row object itself.
    /// </summary>
    public class WE_Row : WE_Base
    {

        // Variables:

        protected IList<IWebElement> _WEsTDs;


        // Constructors:

        public WE_Row(By rowLocator, By tdLocator)
        {
            SetElement(rowLocator);
            _WEsTDs = Find.Elements(element, tdLocator);
        }

        public WE_Row(IWebElement row, By tdLocator)
        {
            SetElement(row);
            _WEsTDs = Find.Elements(element, tdLocator);
        }


        // Methods:

        public int GetAmountOfColumns()
        {
            return _WEsTDs.Count;
        }

        public object GetTdByIndex(int index)
        {
            return _WEsTDs[index];
        }

        public IWebElement GetTdWeByIndex(int index)
        {
            return _WEsTDs[index];
        }

        // Generic Methods - So you dont have to implement nothing special to use them... ;)

        public void ClickOnGivenTD(int index)
        {
            Click.OnElement(_WEsTDs[index]);
        }

        public string GetElementText(int index)
        {
            return Text.GetElementText(_WEsTDs[index]);
        }

    }

    public class WE_Table : WE_Base
    {

        // variables:

        private List<WE_Row> rows = null;

        private static By _rowLocator;
        private static By _tdLocator;

        // Constructors:

        public WE_Table(By tableLocator, By rowLocator, By tdLocator)
        {
            SetElement(tableLocator);
            _rowLocator = rowLocator;
            _tdLocator = tdLocator;
        }

        public WE_Table(IWebElement givenElement, By rowLocator, By tdLocator)
        {
            SetElement(givenElement);
            _rowLocator = rowLocator;
            _tdLocator = tdLocator;
        }


        // Methods:

        private IList<IWebElement> GetAllRowsAsWEs()
        {
            return Find.Elements(element, _rowLocator);
        }

        public List<WE_Row> GetAllRows()
        {
            List<WE_Row> allRows = new List<WE_Row>();
            foreach (IWebElement row in GetAllRowsAsWEs())
            {
                allRows.Add(new WE_Row(row, _tdLocator));
            }
            return allRows;
        }

        public WE_Row GetRowByIndex(int index)
        {
            try
            {
                return rows[index];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        // Row Retrieving methods:

        /// <summary>
        /// This method looks in a RAW way for the Row
        /// with the given value. Once it finds it will
        /// return the whole Row.
        /// 
        /// Note: This will return the FIRST ROW that happens 
        /// to have the given string value at the given column index.
        /// 
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public WE_Row GetRowByColumnValue(int columnIndex, string value)
        {
            foreach (IWebElement row in GetAllRowsAsWEs())
            {
                if (row.FindElements(_tdLocator)[columnIndex].Text.Equals(value))
                    return new WE_Row(row, _tdLocator);
            }
            return null;
        }

        public List<WE_Row> GetRowsByColumnValue(int columnIndex, string value)
        {
            List<WE_Row> result = new List<WE_Row>();
            foreach (IWebElement row in GetAllRowsAsWEs())
            {
                if (row.FindElements(_tdLocator)[columnIndex].Text.Equals(value))
                    result.Add(new WE_Row(row, _tdLocator));
            }
            return result;
        }

        private bool DoesRowHaveGivenValues(IWebElement row, IDictionary<int, string> indexAndValue)
        {
            foreach (KeyValuePair<int, string> entry in indexAndValue)
            {
                if (!row.FindElements(_tdLocator)[entry.Key].Text.Equals(entry.Value)) return false;
            }
            return true;
        }

        public WE_Row GetRowByColumnsValues(IDictionary<int, string> indexAndValue)
        {
            foreach (IWebElement row in GetAllRowsAsWEs())
            {
                if (DoesRowHaveGivenValues(row, indexAndValue)) return new WE_Row(row, _tdLocator);
            }
            return null;
        }

        public List<WE_Row> GetRowsByColumnsValues(IDictionary<int, string> indexAndValue)
        {
            List<WE_Row> result = new List<WE_Row>();
            foreach (IWebElement row in GetAllRowsAsWEs())
            {
                if (DoesRowHaveGivenValues(row, indexAndValue)) result.Add(new WE_Row(row, _tdLocator));
            }
            return result;
        }


        // Row Assertion Methods:

        public bool DoesRowWithGivenColumnValueExist(int columnIndex, string value)
        {
            return GetRowByColumnValue(columnIndex, value) != null;
        }


        // Other methods: 

        public int GetAmountOfRowsWithGivenValue(int columnIndex, string value)
        {
            return GetRowsByColumnValue(columnIndex, value).Count;
        }

    }
}
