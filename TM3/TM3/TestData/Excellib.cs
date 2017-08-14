using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM3.TestData
{
    public class datacollection
    {
        public int rowNumber { get; set; }
        public string ColName { get; set; }
        public string ColValue { get; set; }
    }
    class Excellib
    {

        public static DataTable ExceltoDataTable(string filename)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();
            DataTableCollection table = result.Tables;
            DataTable resultTable = table["Sheet1"];
            return resultTable;
        }

        public static int getrowcount(DataTable datatable)
        {
            int getrowscount = datatable.Rows.Count;
            return getrowscount;
        }

        public static List<datacollection> datacol = new List<datacollection>();

        public static void popuateInCollection(string filepath)
        {
            DataTable table = ExceltoDataTable(filepath);
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    datacollection dtTable = new datacollection()
                    {
                        rowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString()
                    };
                    datacol.Add(dtTable);
                }
            }
        }
        public static void popuateInCollection1(DataTable table)
        {
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    datacollection dtTable = new datacollection()
                    {
                        rowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString()
                    };
                    datacol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string ColumnName)
        {
            try
            {
                string data = (from colData in datacol
                               where colData.ColName == ColumnName
       && colData.rowNumber == rowNumber
                               select colData.ColValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
