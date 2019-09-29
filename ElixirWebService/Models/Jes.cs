using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;

namespace ElixirWebService.Models
{
    public class Jes
    {
      public string description { get; set; }
      public Dictionary<string,object> pair { get; set; }
      public List<Dictionary<string, string>> pairs { get; set; }
      public HttpStatusCode status { get; set; }
    }

    public class ToDict
    {
        public static List<Dictionary<string,string>> Table(DataTable datb)
        {
            return datb.AsEnumerable().Select(row => datb.Columns.Cast<DataColumn>().ToDictionary(
               column => column.ColumnName, column => row[column].ToString())).ToList();
            //return datb.AsEnumerable().ToDictionary<DataRow, string, object>(row => row.Field<string>(0), row => row.Field<object>(1));
        }
    }
   
}