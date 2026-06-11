using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Template
    {
        public void run()
        {
            ReportGenerator salesReport = new SalesReport();
            salesReport.GenrateReport();
            Console.WriteLine();
            ReportGenerator inventoryReport = new InventoryReport();
            inventoryReport.GenrateReport();
        }
    }

    //Template Skeleton 
    public abstract class ReportGenerator
    {
        public void GenrateReport()
        {
            Fetchdata();
            FormatData();
            ExportReport();
        }
        protected abstract void Fetchdata();
        protected abstract void FormatData();
        protected virtual void ExportReport()
        {
            Console.WriteLine("Exporting Report");
        }
    }

    //implemenation of the template skeleton --1
    public class SalesReport : ReportGenerator
    {
        protected override void Fetchdata()
        {
            Console.WriteLine("Fetching Sales Data");
        }

        protected override void FormatData()
        {
            Console.WriteLine("Formatting Sales Data");
        }
    }

    //implemenation of the template skeleton --2
    public class InventoryReport : ReportGenerator
    {
        protected override void Fetchdata()
        {
            Console.WriteLine("Fetching Inventory Data");
        }
        protected override void FormatData()
        {
            Console.WriteLine("Formatting Inventory Data");
        }

        protected override void ExportReport()
        {
            Console.WriteLine("Exporting Inventory Report in Excel Format");
        }
    }

}
