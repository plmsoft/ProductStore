using System.Runtime.Serialization;

namespace ProductStore.Product_WCFService.BO
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Sku { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal OriginalPrice { get; set; }
        [DataMember]
        public decimal DiscountPrice { get; set; }
        [DataMember]
        public decimal RRP { get; set; }
    }

}
