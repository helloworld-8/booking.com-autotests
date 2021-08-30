using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AutoTests.Libraries.ExcelReader
{
    public class ExcelReader
    {
        private DataSet _data;

        public DataSet GetData()
        {
            return _data;
        }

        public void SetData(DataSet value)
        {
            _data = value;
        }

        public ExcelReader(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                //// reader.IsFirstRowAsColumnNames
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                DataSet result = reader.AsDataSet(conf);
                this.SetData(result);              
            }
        }
    }
}
