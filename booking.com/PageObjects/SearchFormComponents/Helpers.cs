using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.com.PageObjects.SearchFormComponents
{
    public enum DateFormat
    {
        yyyyMMdd,
        yyyyMM
    }
    public enum DatePickerPage
    {
        First,
        Middle,
        Last,
        Unknown
    }
    public enum SetWhat
    {
        Adults, Children, Rooms
    }
    public enum SearchFormIsIn
    {
        HomePage, SearchResultsPage
    }

    [Serializable]
    class DateNotFoundInDatePickerException : Exception
    {
        public DateNotFoundInDatePickerException() { }

        public DateNotFoundInDatePickerException(string date)
            : base(String.Format("Date Not Found: {0}", date))
        {

        }
    }
}
