namespace UblGenerator.Common
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class IdentifierType
    {

        private string schemeIDField;

        private string schemeNameField;

        private string schemeAgencyIDField;

        private string schemeAgencyNameField;

        private string schemeVersionIDField;

        private string schemeDataURIField;

        private string schemeURIField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeID
        {
            get
            {
                return this.schemeIDField;
            }
            set
            {
                this.schemeIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeName
        {
            get
            {
                return this.schemeNameField;
            }
            set
            {
                this.schemeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeAgencyID
        {
            get
            {
                return this.schemeAgencyIDField;
            }
            set
            {
                this.schemeAgencyIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyName
        {
            get
            {
                return this.schemeAgencyNameField;
            }
            set
            {
                this.schemeAgencyNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeVersionID
        {
            get
            {
                return this.schemeVersionIDField;
            }
            set
            {
                this.schemeVersionIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string schemeDataURI
        {
            get
            {
                return this.schemeDataURIField;
            }
            set
            {
                this.schemeDataURIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string schemeURI
        {
            get
            {
                return this.schemeURIField;
            }
            set
            {
                this.schemeURIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "normalizedString")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}