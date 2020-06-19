using BusinessObjects;
using System;
using System.Collections.Generic;

namespace UblServices
{
    public class DataService
    {
        private static readonly object sLock = new object();
        private static DataService _service;
        public static DataService Service
        {
            get
            {
                lock (sLock)
                {
                    if (_service == null)
                    {
                        _service = new DataService();
                    }
                    return _service;
                }
            }
        }
        public DespatchData GetDespatchData()
        {
            return new DespatchData
            {
                IRSALIYE_ID = "IRS2020",
                IRSALIYE_NO = "1",
                ALICI_UNVAN = "ALICI_UNVAN",
                ALICI_VERGIDAIRESI = "ALICI_VERGIDAIRESI",
                ALICI_VERGINO = "ALICI_VERGINO",
                ALICI_IL = "ALICI_IL",
                ALICI_ILCE = "ALICI_ILCE",
                ALICI_ADRES = "ALICI_ADRES",
                GONDEREN_UNVAN = "GONDEREN_UNVAN",
                GONDEREN_VERGIDAIRESI = "GONDEREN_VERGIDAIRESI",
                GONDEREN_VERGINO = "GONDEREN_VERGINO",
                GONDEREN_IL = "GONDEREN_IL",
                GONDEREN_ILCE = "GONDEREN_ILCE",
                GONDEREN_ADRES = "GONDEREN_ADRES",
                CarrierInfo = new CarrierInfo
                {
                    FIRMA_ADI = "TASIYICI_FIRMA_ADI",
                    VERGINO = "TASIYICI_VKN",
                    IL = "TASIYICI_IL",
                    ILCE = "TASIYICI_ILCE"
                },
                Details = new List<DespatchDetail>
                {
                    new DespatchDetail{
                        SIRANO = "1",
                        ACIKLAMA = "Ürün ADI",
                        ADET = 1,
                        IRS_SATIR_ID = "1"
                    }
                }
            };
        }
        public InvoiceData GetInvoiceData()
        {
            return new InvoiceData
            {
                FATURA_BASLANGIC = DateTime.Now.AddMonths(-3),
                FATURA_BITIS = DateTime.Now,
                FATURA_NOT = "FATURA",
                FATURA_TUTARI = 100,
                VERGI_TIPI = "KDV",
                VERGI_TUTARI = 18,
                SATICI_VKN = "SATICI_VKN",
                SATICI_VERGIDAIRESI = "SATICI_VERGIDAIRESI",
                SATICI_UNVAN = "SATICI_UNVAN",
                SATICI_IL = "SATICI_IL",
                SATICI_ILCE = "SATICI_IL",
                SATICI_EPOSTA = "SATICI_EPOSTA",
                SATICI_FAX = "SATICI_FAX",
                SATICI_TELEFON = "SATICI_TELEFON",
                SATICI_WEBSITE = "SATICI_WEBSITE",
                MUSTERI_AD = "MUSTERI_AD",
                MUSTERI_SOYAD = "MUSTERI_SOYAD",
                MUSTERI_TCKN = "MUSTERI_TCKN",
                MUSTERI_IL = "MUSTERI_IL",
                MUSTERI_ILCE = "MUSTERI_ILCE",
                MUSTERI_EPOSTA = "MUSTERI_EPOSTA",
                MUSTERI_TELEFON = "",
                MUSTERI_FAX = "",
                Details = new List<InvoiceDetail>
                {
                    new InvoiceDetail
                    {
                        ACIKLAMA="ACIKLAMA",
                        ADET=1,
                        TUTAR=100,
                        VERGI_TIPI="KDV",
                        VERGI_TUTARI=18
                    }
                }
            };
        }
    }
}
