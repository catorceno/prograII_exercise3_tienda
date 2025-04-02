using System;

class Bill{
    public int billID;
    public Sale sale;
    public Bill(Sale sale_){
        billID = 1;
        sale = sale_;
    }
}