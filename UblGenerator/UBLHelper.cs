using BusinessObjects;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UblGenerator.Common;

namespace UblGenerator
{
    public class UBLHelper
    {
        private static readonly object ulock = new object();
        private static UBLHelper _generator;
        public static UBLHelper Generator
        {
            get
            {
                lock (ulock)
                {
                    if (_generator == null)
                    {
                        _generator = new UBLHelper();
                    }
                    return _generator;
                }
            }
        }
        public byte[] GenerateDespatchUbl(DespatchData data)
        {
            var despatch = new DespatchAdviceType
            {
                UUID = new UUIDType() { Value = Guid.NewGuid().ToString() },
                UBLVersionID = new UBLVersionIDType() { Value = "2.1" },
                CustomizationID = new CustomizationIDType() { Value = "TR1.2" },
                ProfileID = new ProfileIDType() { Value = "TEMELIRSALIYE" },
                ID = new IDType() { Value = data.IRSALIYE_NO }, //Irsaliye No
                CopyIndicator = new CopyIndicatorType() { Value = false },
                IssueDate = new IssueDateType { Value = DateTime.Now.Date },
                IssueTime = new IssueTimeType { Value = DateTime.Now },
                DespatchAdviceTypeCode = new DespatchAdviceTypeCodeType { Value = "SEVK" },
                UBLExtensions = new UBLExtensionType[]
                {
                    new UBLExtensionType
                    {
                        ExtensionContent = null
                    }
                },
                DespatchSupplierParty = new SupplierPartyType()
                {
                    Party = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType
                        {
                            Value = "www.firmaadi.com"
                        },
                        PartyIdentification = new PartyIdentificationType[]
                        {
                            new PartyIdentificationType
                            {
                                ID= new IDType
                                {
                                    schemeID="VKN",
                                    Value=data.GONDEREN_VERGINO
                                }
                            }
                        },
                        PartyName = new PartyNameType
                        {
                            Name = new NameType1 { Value = data.GONDEREN_UNVAN }
                        },
                        PostalAddress = new AddressType
                        {
                            CitySubdivisionName = new CitySubdivisionNameType { Value = data.GONDEREN_ILCE },
                            CityName = new CityNameType { Value = data.GONDEREN_IL },
                            Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType
                        {
                            TaxScheme = new TaxSchemeType
                            {
                                Name = new NameType1
                                {
                                    Value = data.GONDEREN_VERGIDAIRESI
                                }
                            }
                        }
                    }
                },
                DeliveryCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification = new PartyIdentificationType[]
                        {
                            new PartyIdentificationType{
                                ID= new IDType
                                {
                                    schemeID="VKN",
                                    Value=!string.IsNullOrEmpty(data.ALICI_VERGINO)?data.ALICI_VERGINO:"5555555555"
                                }
                            }
                        },
                        PartyName = new PartyNameType
                        {
                            Name = new NameType1
                            {
                                Value = !string.IsNullOrEmpty(data.ALICI_VERGINO) ? data.ALICI_UNVAN : "Muhtelif Müşteriler"
                            }
                        },
                        PostalAddress = new AddressType
                        {
                            CitySubdivisionName = new CitySubdivisionNameType
                            {
                                Value = data.ALICI_ILCE
                            },
                            CityName = new CityNameType
                            {
                                Value = data.ALICI_IL
                            },
                            Country = new CountryType
                            {
                                Name = new NameType1
                                {
                                    Value = "Türkiye"
                                }
                            }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType
                        {
                            TaxScheme = new TaxSchemeType
                            {
                                Name = new NameType1
                                {
                                    Value = data.ALICI_VERGIDAIRESI
                                }
                            }
                        }
                    }
                },
                Shipment = new ShipmentType
                {
                    ID = new IDType
                    {
                        Value = ""
                    },
                    GoodsItem = new GoodsItemType[]
                    {
                        new GoodsItemType
                        {
                            HazardousRiskIndicator = new HazardousRiskIndicatorType
                            {
                                Value=false,
                            },
                            ValueAmount= new ValueAmountType
                            {
                                currencyID= "TRY", // Toplam_Tutar_Bilgisi
                                Value=0
                            },
                            CustomsImportClassifiedIndicator= new CustomsImportClassifiedIndicatorType
                            {
                                Value=false
                            }
                        }
                    },
                    Delivery = new DeliveryType
                    {
                        Despatch = new DespatchType
                        {
                            ActualDespatchDate = new ActualDespatchDateType
                            {
                                Value = DateTime.Now.Date
                            },
                            ActualDespatchTime = new ActualDespatchTimeType
                            {
                                Value = DateTime.Now
                            }
                        },
                        CarrierParty = new PartyType
                        {
                            PartyIdentification = new PartyIdentificationType[]
                            {
                                new PartyIdentificationType
                                {
                                    ID = new IDType
                                    {
                                        schemeID= "",
                                        Value=data.CarrierInfo.VERGINO
                                    }
                                }
                            },
                            PartyName = new PartyNameType
                            {
                                Name = new NameType1
                                {
                                    Value = data.CarrierInfo.FIRMA_ADI
                                }
                            },
                            PostalAddress = new AddressType
                            {
                                CitySubdivisionName = new CitySubdivisionNameType
                                {
                                    Value = data.CarrierInfo.ILCE
                                },
                                CityName = new CityNameType
                                {
                                    Value = data.CarrierInfo.IL
                                },
                                Country = new CountryType
                                {
                                    Name = new NameType1
                                    {
                                        Value = "Türkiye"
                                    }
                                }
                            }
                        }
                    }
                },
                DespatchLine = data.Details.Select(d => new DespatchLineType
                {
                    ID = new IDType
                    {
                        Value = d.SIRANO
                    },
                    DeliveredQuantity = new DeliveredQuantityType
                    {
                        unitCode = "NIU",
                        Value = d.ADET
                    },
                    OrderLineReference = new OrderLineReferenceType
                    {
                        LineID = new LineIDType
                        {
                            Value = d.SIRANO
                        }
                    },
                    Item = new ItemType
                    {
                        Name = new NameType1
                        {
                            Value = d.ACIKLAMA
                        },
                        SellersItemIdentification = new ItemIdentificationType
                        {
                            ID = new IDType
                            {
                                Value = d.IRS_SATIR_ID//IRSALIYE_SATIR_ID
                            }
                        }
                    }
                }).ToArray()
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DespatchAdviceType));
            using (MemoryStream output = new MemoryStream())
            {
                xmlSerializer.Serialize(output, despatch, new Common.UblGenerator());
                return output.ToArray();
            }
        }
        public byte[] GenerateInvoiceUbl(InvoiceData data)
        {
            var invoice = new InvoiceType
            {
                UUID = new UUIDType() { Value = Guid.NewGuid().ToString() },
                UBLVersionID = new UBLVersionIDType() { Value = "2.1" },
                CustomizationID = new CustomizationIDType() { Value = "TR1.2" },
                ProfileID = new ProfileIDType() { Value = "TEMELFATURA" },
                ID = new IDType() { Value = "FAT20200000000001" },
                CopyIndicator = new CopyIndicatorType() { Value = false },
                InvoicePeriod = new PeriodType
                {
                    StartDate = new StartDateType { Value = data.FATURA_BASLANGIC },
                    EndDate = new EndDateType { Value = data.FATURA_BITIS }
                },
                Signature = new SignatureType[]
                {
                    new SignatureType
                    {
                        ID = new IDType{schemeID="VKN_TCKN",Value = data.SATICI_VKN},
                        SignatoryParty = new PartyType
                        {
                            PartyIdentification = new PartyIdentificationType[]
                            {
                                new PartyIdentificationType{
                                    ID = new IDType{schemeID="VKN",Value=data.SATICI_VKN}
                                }
                            },
                            PostalAddress = new AddressType
                            {
                                CityName = new CityNameType
                                {
                                    Value=data.SATICI_IL
                                },
                                CitySubdivisionName = new CitySubdivisionNameType
                                {
                                    Value=data.SATICI_ILCE
                                },
                                Country = new CountryType
                                {
                                    Name = new NameType1
                                    {
                                        Value="Türkiye"
                                    }
                                }
                            }
                        },
                        DigitalSignatureAttachment = new AttachmentType
                        {
                            ExternalReference= new ExternalReferenceType
                            {
                                URI= new URIType{Value="#Signature"}
                            }
                        }
                    }
                },
                AccountingSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType
                        {
                            Value = data.SATICI_WEBSITE
                        },
                        PartyIdentification = new PartyIdentificationType[]
                        {
                            new PartyIdentificationType
                            {
                                ID = new IDType
                                {
                                    schemeID="VKN",
                                    Value = data.SATICI_VKN
                                }
                            }
                        },
                        PartyName = new PartyNameType
                        {
                            Name = new NameType1
                            {
                                Value = data.SATICI_UNVAN
                            }
                        },
                        PostalAddress = new AddressType
                        {
                            CityName = new CityNameType
                            {
                                Value = data.SATICI_IL
                            },
                            CitySubdivisionName = new CitySubdivisionNameType
                            {
                                Value = data.SATICI_ILCE
                            },
                            Country = new CountryType
                            {
                                Name = new NameType1
                                {
                                    Value = "Türkiye"
                                }
                            }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType
                        {
                            TaxScheme = new TaxSchemeType
                            {
                                Name = new NameType1
                                {
                                    Value = data.SATICI_VERGIDAIRESI
                                }
                            }
                        },
                        Contact = new ContactType
                        {
                            Telephone = new TelephoneType
                            {
                                Value = data.SATICI_TELEFON
                            },
                            Telefax = new TelefaxType
                            {
                                Value = data.SATICI_FAX
                            },
                            ElectronicMail = new ElectronicMailType
                            {
                                Value = data.SATICI_EPOSTA
                            }
                        }
                    }
                },
                AccountingCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType
                        {
                            Value = ""
                        },
                        PartyIdentification = new PartyIdentificationType[]
                        {
                            new PartyIdentificationType
                            {
                                ID = new IDType
                                {
                                    schemeID="TCKN",
                                    Value = data.MUSTERI_TCKN
                                }
                            }
                        },
                        PostalAddress = new AddressType
                        {
                            CityName = new CityNameType
                            {
                                Value = data.MUSTERI_IL
                            },
                            CitySubdivisionName = new CitySubdivisionNameType
                            {
                                Value = data.MUSTERI_ILCE
                            },
                            Country = new CountryType
                            {
                                Name = new NameType1
                                {
                                    Value = "Türkiye"
                                }
                            }
                        },
                        Contact = new ContactType
                        {
                            Telephone = new TelephoneType
                            {
                                Value = data.MUSTERI_TELEFON
                            },
                            ElectronicMail = new ElectronicMailType
                            {
                                Value = data.MUSTERI_EPOSTA
                            }
                        },
                        Person = new PersonType
                        {
                            FirstName = new FirstNameType { Value = data.MUSTERI_AD },
                            FamilyName = new FamilyNameType { Value = data.MUSTERI_SOYAD }
                        }
                    }
                },
                PaymentTerms = new PaymentTermsType
                {
                    Note = new NoteType
                    {
                        Value = data.FATURA_NOT
                    },
                    Amount = new AmountType2
                    {
                        Value = data.FATURA_TUTARI
                    },
                    PaymentDueDate = new PaymentDueDateType
                    {
                        Value = data.FATURA_BITIS
                    }
                },
                TaxTotal = new TaxTotalType[]
                {
                    new TaxTotalType
                    {
                        TaxAmount = new TaxAmountType
                        {
                            currencyID = "TRY",
                            Value = data.VERGI_TUTARI
                        },
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxableAmount = new TaxableAmountType
                                {
                                    currencyID = "TRY",
                                    Value = data.FATURA_TUTARI
                                },
                                TaxAmount = new TaxAmountType
                                {
                                    currencyID = "TRY",
                                    Value = data.VERGI_TUTARI
                                },
                                TaxCategory = new TaxCategoryType
                                {
                                    TaxScheme = new TaxSchemeType
                                    {
                                        TaxTypeCode = new TaxTypeCodeType
                                        {
                                            Value = data.VERGI_TIPI
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                InvoiceLine = data.Details.Select(d => new InvoiceLineType
                {
                    InvoicedQuantity = new InvoicedQuantityType
                    {
                        Value = d.ADET
                    },
                    LineExtensionAmount = new LineExtensionAmountType
                    {
                        currencyID = "TRY",
                        Value = d.TUTAR
                    },
                    TaxTotal = new TaxTotalType
                    {
                        TaxAmount = new TaxAmountType
                        {
                            currencyID = "TRY",
                            Value = d.VERGI_TUTARI
                        },
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxableAmount = new TaxableAmountType
                                {
                                    currencyID = "TRY",
                                    Value = d.TUTAR
                                },
                                TaxAmount = new TaxAmountType
                                {
                                    currencyID = "TRY",
                                    Value = d.VERGI_TUTARI
                                },
                                TaxCategory = new TaxCategoryType
                                {
                                    TaxScheme = new TaxSchemeType
                                    {
                                        TaxTypeCode = new TaxTypeCodeType
                                        {
                                            Value = d.VERGI_TIPI
                                        }
                                    }
                                }
                            }
                        }
                    },
                    Item = new ItemType
                    {
                        Name = new NameType1
                        {
                            Value = d.ACIKLAMA
                        }
                    },
                    Price = new PriceType
                    {
                        PriceAmount = new PriceAmountType
                        {
                            currencyID = "TRY",
                            Value = d.TUTAR
                        }
                    }
                }).ToArray()
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InvoiceType));
            using (MemoryStream output = new MemoryStream())
            {
                xmlSerializer.Serialize(output, invoice, new Common.UblGenerator());
                return output.ToArray();
            }
        }
    }
}