using System;

namespace tienda{
    class Program{
        static void Main(string[] args){
            Inventory tienda = new();
            Console.WriteLine("1.Cliente | 2.Administrador");
            Console.Write("Elige un rol: "); char rol_option = Console.ReadKey().KeyChar;
            if(rol_option == '1'){
                Carrito carrito = new(tienda);
                Client client = new(carrito);
                client.buy();
            } /*else if(rol_option == '2'){
                Administrator admin = new();
                admin.manage();
            }*/ else Console.WriteLine("\nOpcion no válida.");

        }
    }
}