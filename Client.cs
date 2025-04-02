using System;

class Client{
    private Carrito carrito;
    public Client(Carrito carrito_){
        carrito = carrito_;
    }
    public void buy(){
        Console.Write("\n\nBienvenido(a) a tu carrito!");
        while(true){
            Console.WriteLine("\n1.Añadir producto | 2.Estado del carrito | 0.Cerrar Sesión");
            char char_option = inputChar();
            if(!charIsInt(char_option)) continue;
            int option = ctoi(char_option);
            if(option == 1) carrito.addItem();
            else if(option == 2) carrito.status();
            else if(option == 0) break;
            else Console.WriteLine("Opción no válida");
        }
    }
    public char inputChar(){
        Console.Write("Elige una opción: "); char char_input = Console.ReadKey().KeyChar; Console.WriteLine();
        return char_input;
    }
    public int ctoi(char c) {return c - '0';}
    public bool charIsInt(char c){
        if(c>=48 && c<=57) return true;
        else return false;
    }
}