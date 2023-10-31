namespace AcmeCorpAPI.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public string DeliveryAddress { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int Status { get; set; }
    }

    public class UpdateOrder
    {
        //public int OrderID { get; set; }
        //public int CustomerID { get; set; }
        //public int ProductID { get; set; }
        //public int Amount { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public int Status { get; set; }
    }
}
