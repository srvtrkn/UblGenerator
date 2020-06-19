using BusinessObjects;
using NUnit.Framework;
using System.IO;
using UblGenerator;
using UblServices;

namespace UblTest
{
    public class UblTest
    {
        [Test]
        public void GetDespatchUbl()
        {
            DespatchData data = DataService.Service.GetDespatchData();
            byte[] despatchUbl = UBLHelper.Generator.GenerateDespatchUbl(data);
            File.WriteAllBytes(@"C:\Temp\irsaliye.xml", despatchUbl);
        }
        [Test]
        public void GetInvoiceUbl()
        {
            InvoiceData data = DataService.Service.GetInvoiceData();
            byte[] despatchUbl = UBLHelper.Generator.GenerateInvoiceUbl(data);
            File.WriteAllBytes(@"C:\Temp\fatura.xml", despatchUbl);
        }
    }
}
