using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace trustedi10_mvc_Assessment_asad.Helper
{
    public class DataAccess
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        
        public DataTable GetDatatable(string SPName, string[] paramNames, object[] paramValues)
        {
            SqlConnection cnn = new SqlConnection(ConnectionString);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < paramNames.Length; i++)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = paramNames[i];
                    p.Value = paramValues[i];
                    cmd.Parameters.Add(p);
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public DataTable GetDatatable(string SPName)
        {
            SqlConnection cnn = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                return null;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }        

        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}