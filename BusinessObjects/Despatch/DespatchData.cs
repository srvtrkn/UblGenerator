using System.Collections.Generic;

namespace BusinessObjects
{
    public class DespatchData
    {
        public string IRSALIYE_ID { get; set; }
        public string IRSALIYE_NO { get; set; }
        public string NEREDEN_AD { get; set; }
        public string NEREYE_AD { get; set; }
        public string SON_KULLANICI { get; set; }
        public string ALICI_UNVAN { get; set; }
        public string ALICI_VERGIDAIRESI { get; set; }
        public string ALICI_VERGINO { get; set; }
        public string ALICI_IL { get; set; }
        public string ALICI_ILCE { get; set; }
        public string ALICI_ADRES { get; set; }
        public string GONDEREN_UNVAN { get; set; }
        public string GONDEREN_VERGIDAIRESI { get; set; }
        public string GONDEREN_VERGINO { get; set; }
        public string GONDEREN_IL { get; set; }
        public string GONDEREN_ILCE { get; set; }
        public string GONDEREN_ADRES { get; set; }
        public List<DespatchDetail> Details { get; set; }
        public CarrierInfo CarrierInfo { get; set; }
    }
}