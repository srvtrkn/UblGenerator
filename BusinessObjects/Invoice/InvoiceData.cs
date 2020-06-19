using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class InvoiceData
    {
        public DateTime FATURA_BASLANGIC { get; set; }
        public DateTime FATURA_BITIS { get; set; }
        public string FATURA_NOT { get; set; }
        public decimal FATURA_TUTARI { get; set; }
        public decimal VERGI_TUTARI { get; set; }
        public string VERGI_TIPI { get; set; }
        public string SATICI_VKN { get; set; }
        public string SATICI_VERGIDAIRESI { get; set; }
        public string SATICI_UNVAN { get; set; }
        public string SATICI_IL { get; set; }
        public string SATICI_ILCE { get; set; }
        public string SATICI_WEBSITE { get; set; }
        public string SATICI_TELEFON { get; set; }
        public string SATICI_FAX { get; set; }
        public string SATICI_EPOSTA { get; set; }
        public string MUSTERI_TCKN { get; set; } //VKN
        public string MUSTERI_VERGIDAIRESI { get; set; }
        public string MUSTERI_UNVAN { get; set; }
        public string MUSTERI_AD { get; set; }
        public string MUSTERI_SOYAD { get; set; }
        public string MUSTERI_IL { get; set; }
        public string MUSTERI_ILCE { get; set; }
        public string MUSTERI_TELEFON { get; set; }
        public string MUSTERI_FAX { get; set; }
        public string MUSTERI_EPOSTA { get; set; }
        public List<InvoiceDetail> Details { get; set; }
    }
}
