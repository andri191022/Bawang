using SMK.BAWANG.Dto.custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMK.BAWANG.Logic
{
    public class GenerateTableHTML
    {
        protected static string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<table class='table table-striped table-bordered' id='' style='width: 100%;'>");
            strHTMLBuilder.Append("<thead >");
            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<th >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</th>");

            }
            strHTMLBuilder.Append("<th></th>");

            strHTMLBuilder.Append("</tr>");
            strHTMLBuilder.Append("</thead >");

            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("<td style='text-align:center; '>[aksi]</td>");
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>");

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;

        }

        public static tbl_content_cstm generatePageTableData(DataTable dt)
        {
            tbl_content_cstm obj = new tbl_content_cstm();
            obj.content_text = ExportDatatableToHtml(dt);
            return obj;
        }
    }
}
