﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
namespace ExcelRefer
{
    public class ChartExam
    {
        public ChartExam()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.Visible = true;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Student1";
            xlWorkSheet.Cells[1, 3] = "Student2";
            xlWorkSheet.Cells[1, 4] = "Student3";

            xlWorkSheet.Cells[2, 1] = "Term1";
            xlWorkSheet.Cells[2, 2] = "80";
            xlWorkSheet.Cells[2, 3] = "65";
            xlWorkSheet.Cells[2, 4] = "45";

            xlWorkSheet.Cells[3, 1] = "Term2";
            xlWorkSheet.Cells[3, 2] = "78";
            xlWorkSheet.Cells[3, 3] = "72";
            xlWorkSheet.Cells[3, 4] = "60";

            xlWorkSheet.Cells[4, 1] = "Term3";
            xlWorkSheet.Cells[4, 2] = "82";
            xlWorkSheet.Cells[4, 3] = "80";
            xlWorkSheet.Cells[4, 4] = "65";

            xlWorkSheet.Cells[5, 1] = "Term4";
            xlWorkSheet.Cells[5, 2] = "75";
            xlWorkSheet.Cells[5, 3] = "82";
            xlWorkSheet.Cells[5, 4] = "68";

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d5");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            xlApp.ScreenUpdating = false;


            xlWorkBook.SaveAs(Path.Combine(Environment.CurrentDirectory, "csharp.net-informations.xls"), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();





            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
