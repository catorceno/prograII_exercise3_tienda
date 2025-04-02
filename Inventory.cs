using System;

class Inventory{
    private List<Category> categories = new(){
        new Category(1, "CLASICOS"),
        new Category(2, "POESIA"),
        new Category(3, "NACIONALES")
    };
    public Inventory(){
        categories[0].addProduct(new Product("El Quijote", "Miguel de Cervantes", 200, [1111, 1112]));
        categories[0].addProduct(new Product("Viaje al centro de la Tierra", "Julio Verne", 250, [2111, 2112]));
        categories[1].addProduct(new Product("La canción del pirata", "José de Esproceda", 100, [3111, 3112]));
        categories[1].addProduct(new Product("x", "Ernesto Castro", 80, [4111, 4112]));
        categories[2].addProduct(new Product("Borracho estaba pero me acuerdo", "Jose Bizcarra", 80, [5111, 5112]));
        categories[2].addProduct(new Product("y", "z", 50, [6111, 6112]));
    }
    public List<Category> getCategories() {return categories;}
    public Category getCategory(int id) {return categories[id-1];}
    public void addCategory(string new_name){
        int last_id = 0;
        foreach(var category in categories){
            if(category.getName() == new_name){
                Console.WriteLine($"La categoría '{new_name}' ya existe.");
                return;
            }
            last_id = category.getCategoryID();
        }
        categories.Add(new Category(last_id+1, new_name));
        Console.WriteLine("Categoría agregada existosamente!");
    }
    public void showCategories(){
        Console.WriteLine();
        foreach(var category in categories){
            Console.Write($"{category.getCategoryID()}.{category.getName()} | ");
        }
    }
    public void showProductsOfCategory(int categoryID){
        categories[categoryID-1].showProducts();
    }
    public void addProductToCategory(int categoryID, Product product){
        if(categoryExists(categoryID)) categories[categoryID-1].addProduct(product);
    }
    public void showAllProducts(){
        foreach(var category in categories){
            Console.WriteLine(category.getName());
            category.showProducts();
        }
    }
    public bool categoryExists(int id){
        foreach(var category in categories){
            if(category.getCategoryID() == id){
                return true;
            }
        }
        Console.WriteLine($"    No se pudo añadir porque la categoría '{id}'no existe");
        return false;
    }
}