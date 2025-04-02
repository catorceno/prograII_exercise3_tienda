using System;

class Carrito{
    private Inventory inventory;
    private List<(Product product, int quantity)> items;
    public Carrito(Inventory inventory_){
        inventory = inventory_;
        items = new();
    }
    public List<(Product product, int quantity)> getItems() {return items;}
    public void addItem(){
        while(true){
            inventory.showCategories(); Console.WriteLine("0.Atras");
            char char_option = inputChar(); if(!charIsInt(char_option)) continue;
            int category_opt = ctoi(char_option);
            if(category_opt == 0) {Console.WriteLine(); break;}
            if(inventory.categoryExists(category_opt)){
                Console.Write("\n\n0. Atras");
                inventory.showProductsOfCategory(category_opt);
                char_option = inputChar(); if(!charIsInt(char_option)) continue;
                int product_opt = ctoi(char_option);
                if(product_opt == 0) {Console.WriteLine(); continue;}
                while(inventory.getCategory(category_opt).productExists(product_opt)){
                    Console.Write("    Cantidad: ");
                    char_option = Console.ReadKey().KeyChar; if(!charIsInt(char_option)) continue;
                    int quantity = ctoi(char_option);
                    if(inventory.getCategory(category_opt).getProduct(product_opt).getStockQuantity() >= quantity && quantity != 0){
                        items.Add((inventory.getCategory(category_opt).getProduct(product_opt), quantity));
                        Console.WriteLine("    Los items fueron añadidos a tu carrito!");
                        break;
                    } else Console.WriteLine($"    El stock disponible es de: {inventory.getCategory(category_opt).getProduct(product_opt).getStockQuantity()}.");
                }
            }
        }
    }
    public void status(){
        Console.WriteLine("\nProductos añadidos:");
        if(!showItems()) return;
        while(true){
            Console.WriteLine("\n1.Pagar | 2.Eliminar producto | 3.Cancelar compra | 0.Atras");
            char char_option = inputChar(); if(!charIsInt(char_option)) continue;
            int option = ctoi(char_option); Console.WriteLine();
            if(option == 1) payTotal();
            else if(option == 2) Console.WriteLine("eliminando...");
            else if(option == 3){
                items.Clear();
                Console.WriteLine("El carrito ha sido vaciado.");
                break;
            }
            else if(option == 0) {Console.WriteLine(); break;}
            else Console.WriteLine("Opción no válida");
        }
    }
    public void payTotal(){
        while(true){
            Console.Write("1.Con factura | 2.Sin factura | Elige una opción: ");
            char char_option = Console.ReadKey().KeyChar; if(!charIsInt(char_option)) continue;
            int option = ctoi(char_option); Console.WriteLine();
            bool withBill = false;
            if(option == 1) withBill = true;
            foreach(var (product, quantity) in items){
                for(int i = 0; i < quantity; ++i){
                    if(product.getStock_list().Count() > 0){
                        product.getStock_list().RemoveAt(0);
                    }
                }
            }
            Sale new_sale = new(items, withBill);
            //historialSales.Add(new_sale);
            if(withBill){
                //Bill new_bill = new(new_sale);
                //new_bill.showBill();
            }
            Console.WriteLine("Compra exitosa!");
            items.Clear();
        }
    }
    public void deleteItem(){
        while(true){
            Console.WriteLine("0.Cancelar | Elige un producto: ");
            char char_option = inputChar(); if(!charIsInt(char_option)) continue;
            int product_opt = ctoi(char_option);
            if(product_opt == 0) break;

            var item = items.FirstOrDefault(i => i.product.getProductID() == product_opt);
            if(item.product == null) {
                Console.WriteLine("El producto no está en el carrito.");
                continue;
            }

            Console.Write("Cantidad a eliminar: ");
            char_option = inputChar(); if(!charIsInt(char_option)) continue;
            int quantity_to_remove = ctoi(char_option);

            if (quantity_to_remove >= item.quantity) {
                items.Remove(item);
                Console.WriteLine("Producto eliminado del carrito.");
            } else {
                int index = items.IndexOf(item);
                items[index] = (item.product, item.quantity - quantity_to_remove);
                Console.WriteLine($"Se actualizaron las unidades del producto {item.product.getTitle()}. Quedan {item.quantity - quantity_to_remove}.");
            }
        }
    }
    public bool showItems(){
        if(items.Count() == 0){
            Console.WriteLine("---- El carrito está vacío ----");
            return false;
        }
        foreach(var (product, quantity) in items){
            Console.WriteLine($" {product.getProductID()}. |  {quantity}   {product.getTitle()} por {product.getAuthor()}    Bs.{product.getPrice()*quantity}");
        }
        Console.WriteLine($"Total: Bs.{getTotal()}");
        return true;
    }
    public int getTotal(){
        int total = 0;
        foreach(var (product, quantity) in items){
            total = total + (product.getPrice() * quantity);
        }
        return total;
    }


    public char inputChar(){
        Console.Write("Elige una opción: "); char char_input = Console.ReadKey().KeyChar;
        return char_input;
    }
    public int ctoi(char c) {return c - '0';}
    public bool charIsInt(char c){
        if(c>=48 && c<=57) return true;
        else return false;
    }
}


        /*while(true){
            inventory.showCategories(); Console.WriteLine("0.Salir");
            char char_option = inputChar();
            if(!charIsInt(char_option)) continue;
            int category_opt = ctoi(char_option);
            if(inventory.categoryExists(category_opt)){
                inventory.showProductsOfCategory(category_opt);
                char_option = inputChar();
                if(!charIsInt(char_option)) continue;
                int product_opt = ctoi(char_option);
                //verificar que el producto exista
                if(inventory.getCategory(category_opt).getProducts()){}
            }
        }*/

/*public void addItem(int categoryID, int productID, int quantity){
        foreach(var category in inventory.getCategories()){
            if(category.getCategoryID() == categoryID){
                foreach(var product in category.getProducts()){
                    if(product.getProductID() == productID){
                        if(product.getStockQuantity() >= quantity){
                            Console.WriteLine("sold!");
                        } else Console.WriteLine($"El stock disponible es de: {product.getStockQuantity()}.");
                    }
                }
            } 
        }
    }*/