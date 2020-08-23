using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS_2935082014
{
    /// <summary>
    /// Summary description for Servicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicios : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet GetConsultaMontoOrdenes(int Orden)
        {
            SqlConnection conn = new SqlConnection("Data Source=TALLER;Initial Catalog=Adventureworks2014;Integrated Security=true;");
            conn.Open();
            SqlCommand sql = new SqlCommand("Select Freight, TotalDue, TaxAmt, SUM(UnitPrice * OrderQty) AS totalFactura FROM Sales.SalesOrderHeader INNER JOIN Sales.SalesOrderDetail ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID where SalesOrderHeader.SalesOrderID=@order GROUP BY SalesOrderHeader.SalesOrderID, Freight, TotalDue, TaxAmt", conn);
            sql.Parameters.AddWithValue("@order", Orden);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        [WebMethod]
        public DataSet GetNumeroOrdenes()
        {
            SqlConnection conn = new SqlConnection("Data Source=TALLER;Initial Catalog=Adventureworks2014;Integrated Security=true;");
            conn.Open();
            SqlCommand sql = new SqlCommand("Select top(100) SalesOrderID FROM Sales.SalesOrderHeader GROUP BY SalesOrderID", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
