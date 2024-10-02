namespace PruebaDetalleMaestro.Models;

public class Order {
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderDetails { get; set; }
}