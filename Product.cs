using System;

class Product{
    private int productID;
    private string title;
    private string author;
    private int price;
    private List<int> stock_list;
    public Product(string title_, string author_, int price_, List<int> stock_list_){
        productID = 1;
        title = title_;
        author = author_;
        price = price_;
        stock_list = stock_list_;
    }
    public int getProductID() {return productID;}
    public string getTitle() {return title;}
    public string getAuthor() {return author;}
    public int getPrice() {return price;}
    public List<int> getStock_list() {return stock_list;}
    public void setProductID(int id) {productID = id;}

    public int getStockQuantity() {return stock_list.Count();}
    
    public void addStockItem(int isbn){
        if(stock_list.Contains(isbn)) Console.WriteLine($"Ya existe el producto con ISBN: {isbn}");
        else stock_list.Add(isbn);
    }
    public void deleteStockItem(int isbn){
        if(!stock_list.Contains(isbn)) Console.WriteLine($"No existe el producto con ISBN: {isbn}");
        else stock_list.Remove(isbn);
    }
}