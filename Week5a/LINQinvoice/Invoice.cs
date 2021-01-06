// Exercise 9.3 Solution: Invoice.cs
// Invoice class.
namespace Zadacha1
{
    public class Invoice
    {
        private int quantityValue;
        private decimal priceValue;

        public int PartNumber { get; set; }
        public string PartDescription { get; set; }

        
        public Invoice(int part, string description, int count, decimal pricePerItem)
        {
            PartNumber = part;
            PartDescription = description;
            Quantity = count;
            Price = pricePerItem;
        } 

        // property for quantityValue; ensures value is positive
        public int Quantity
        {
            get
            {
                return quantityValue;
            } 
            set
            {
                if (value > 0) quantityValue = value;
            } 
        } 

        public decimal Price
        {
            get
            {
                return priceValue;
            } 
            set
            {
                if (value >= 0M)
                    priceValue = value; 
            } 
        } 

        public override string ToString()
        {
            // left justify each field, and give large enough spaces so
            // all the columns line up
            return string.Format("{0,-5} {1,-20} {2,-5} {3,6:C}",
                              PartNumber, PartDescription, Quantity, Price);
        } 
    } 
}