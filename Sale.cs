using System;

class Sale{
    private int saleID;
    private DateTime date;
    public List<(Product product, int quantity)> soldItems;
    public bool withBill;
    public Sale(List<(Product product, int quantity)> items, bool withBill_){
        saleID = 1;
        date = DateTime.Now;
        soldItems = new(items);
        withBill = withBill_;
    }
    public int getSaleID() {return saleID;}
    public DateTime getDate() {return date;}
    public List<(Product product, int quantity)> getSoldItems() {return soldItems;}
    public bool getWithBill() {return withBill;}
}