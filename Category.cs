using System;

class Category{
    private int categoryID;
    private string name;
    private List<Product> products;
    public Category(int categoryID_, string name_){
        categoryID = categoryID_;
        name = name_;
        products = new();
    }
    public int getCategoryID() {return categoryID;}
    public string getName() {return name;}
    public List<Product> getProducts() {return products;}
    public Product getProduct(int id) {return products[id-1];}
    public void setCategoryID(int id) {categoryID = id;}

    public void addProduct(Product new_product){
        int last_id = 0;
        foreach(var product in products){
            if(product.getTitle() == new_product.getTitle() && product.getAuthor() == new_product.getAuthor()){
                Console.WriteLine($"El producto '{new_product.getTitle()}' de {new_product.getAuthor()} ya existe.");
                return;
            }
            last_id = product.getProductID();
        }
        products.Add(new_product);
        new_product.setProductID(last_id+1);
        //Console.WriteLine($"Producto agregado existosamente!");
    }
    public bool productExists(int id){
        foreach(var product in products){
            if(product.getProductID() == id){
                return true;
            }
        }
        Console.WriteLine($"    No se pudo añadir porque el producto '{id}'no existe.");
        return false;
    }
    public void showProducts(){
        Console.WriteLine();
        foreach(var product in products){
            Console.WriteLine($"{product.getProductID()}. {product.getTitle()} por {product.getAuthor()}    Bs.{product.getPrice()}");
        }
    }
}