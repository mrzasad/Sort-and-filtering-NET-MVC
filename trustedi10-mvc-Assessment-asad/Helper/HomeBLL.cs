using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using trustedi10_mvc_Assessment_asad.Models;

namespace trustedi10_mvc_Assessment_asad.Helper
{
    public class HomeBLL
    {
        DataTable dt = new DataTable();
        DataAccess dal = new DataAccess();
        public List<recDetailsModel> GetRecDetails()
        {
            List<recDetailsModel> list = new List<recDetailsModel>();
            try
            {
                dt = dal.GetDatatable("SP_getRecDetails");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        list = dal.ConvertDataTable<recDetailsModel>(dt).ToList();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }

            return list;
        }
    }
}