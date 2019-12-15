using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows.Forms;

namespace k_means
{
    public class Excel
    {
        ExcelPackage ep = null;
        string sheetTitle = null;
        int shag = 0;
        int start = 1;

        public Excel()
        {
            ep = new ExcelPackage();
        }

        public void CreateSheet(string sheetName)
        {
            ep.Workbook.Worksheets.Add(sheetName);
            sheetTitle = sheetName;
            
        }

        public void CreateCells(DataGridView dgv, List<int[]> list, string sheetName, int k, double error, DataTable table, List<Center> cent)
        {
            int ch = 0;
            int kl = 0;
            ep.Workbook.Worksheets[sheetName].Cells[start, 1].Value = (string)("k = " + k);
            for (int i = 0; i < list.Count; i++)
            {
                kl = 0;
                ep.Workbook.Worksheets[sheetName].Cells[start + kl, 2].Value = "Класс " + (i) + ":";
                //for (int j = 0; j < list[i].Count(); j++)
                //{
                for (int q = 0; q < table.Rows.Count; q++)
                {
                    if (Convert.ToInt32(table.Rows[q][table.Columns.Count - 1]) == i)
                    {
                        ep.Workbook.Worksheets[sheetName].Cells[start, 3 + kl].Value = Convert.ToString(dgv.Rows[q].Cells[0].Value);
                        kl++;
                    }

                }
                start += 1;
               // }
            }
            for(int i = 0; i < cent.Count();i++)
            {
                ep.Workbook.Worksheets[sheetName].Cells[start, 2].Value = "Центр: " + (i) + ":";
                for (int j = 0; j < cent[i].Count;j++)
                {
                    ep.Workbook.Worksheets[sheetName].Cells[start, 3+j].Value = cent[i][j];
                    //ep.Workbook.Worksheets[sheetName].Cells[start, 3 + j].Style.
                }
                start++;
            }
            ep.Workbook.Worksheets[sheetName].Cells[start, 2].Value = "Error:";
            ep.Workbook.Worksheets[sheetName].Cells[start, 3].Value = error;
            start +=  3 ;
        }

        public void WriteToFile(string fileName)
        {
            if (ep != null)
            {
                var bin = ep.GetAsByteArray();
                File.WriteAllBytes(fileName + ".xlsx", bin);
            }
        }
    }
}