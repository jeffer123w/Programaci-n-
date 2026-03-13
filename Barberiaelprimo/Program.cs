using System;
using System.ComponentModel.Design;

// No usamos "Namespace" para que sea más directo.
class Program
{
    static void Main(string[] args)
    {
        // --- NUESTRAS "CAJAS" PARA GUARDAR DATOS (Arreglos) ---
        string[] listaClientes = new string[500];
        string[] listaServicios = new string[500];
        decimal[] listaPrecios = new decimal[500];
        string[] listaHoras = new string[500];

        int contadorVentas = 0; // Este número nos dice en qué renglón vamos
        bool salir = false;

        // Título de la ventana 
        Console.Title = "Sistema Barberia Profesional";

        while (salir == false)
        {
            // --- DIBUJAR EL MENÚ ---
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("    BARBERIA EL PRIMO v1.0");
            Console.WriteLine("========================================");
            Console.ResetColor();

            Console.WriteLine("1. Registrar Venta");
            Console.WriteLine("2. Ver Historial");
            Console.WriteLine("3. Corte de Caja");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opcion: ");

            string opcion = Console.ReadLine();

            // --- LÓGICA DE LAS OPCIONES ---
            if (opcion == "1") // REGISTRAR VENTA

            {

                Console.Clear();

                Console.WriteLine("--- NUEVO SERVICIO ---");

                Console.Write("Nombre del Cliente: ");

                string clienteNom = Console.ReadLine();

                Console.WriteLine("\nServicios:");
                Console.WriteLine("1. Corte (100 Lps.)");
                Console.WriteLine("2. Barba (80 Lps.)");
                Console.WriteLine("3. Combo VIP (200 Lps.)");
                Console.WriteLine("4. Tinte (180 Lps.)");
                Console.WriteLine("5. Cisa (60 Lps.)");
                Console.Write("Opcion: ");
                string opServicio = Console.ReadLine();

                // Decidir precio y nombre del servicio con IFs simples
                decimal precioFinal = 0;
                string nombreServicio = "";
                bool opcionValida = true;

                if (opServicio == "1")
                {
                    precioFinal = 100;
                    nombreServicio = "Corte";
                }
                else if (opServicio == "2")
                {
                    precioFinal = 80;
                    nombreServicio = "Barba";
                }
                else if (opServicio == "3")
                {
                    precioFinal = 200;
                    nombreServicio = "Combo VIP";
                }
                else if (opServicio == "4")
                {
                    precioFinal = 180;
                    nombreServicio = "Tinte";
                }
                else if (opServicio == "5")
                {
                    precioFinal = 60;
                    nombreServicio = "Cisa";
                }
                else
                {
                    Console.WriteLine("OPCION INNVALIDA,NO SE REGISTRO VENTA");
                    Console.ResetColor();
                    opcionValida = false;
                }
                if (opcionValida == true)
                {
                    if (contadorVentas >= 500)
                    {
                        Console.WriteLine("Memoria llena. No se pueden registrar más ventas hoy.");

                    }
                    else
                    {
                        // Guardamos los datos en los arreglos usando el contador
                        listaClientes[contadorVentas] = clienteNom;
                        listaServicios[contadorVentas] = nombreServicio;
                        listaPrecios[contadorVentas] = precioFinal;
                        listaHoras[contadorVentas] = DateTime.Now.ToShortTimeString();

                        // Sumamos 1 al contador para que la próxima venta se guarde en el siguiente lugar
                        contadorVentas = contadorVentas + 1;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nVenta registrada correctamente.");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

            else if (opcion == "2") // VER HISTORIAL
            {
                Console.Clear();
                Console.WriteLine("--- HISTORIAL DEL DIA ---\n");

                if (contadorVentas == 0)
                {
                    Console.WriteLine("No hay ventas aun.");
                }
                else
                {
                    // Dibujamos la tabla manualmente
                    Console.WriteLine("HORA       | CLIENTE         | SERVICIO     | PRECIO");
                    Console.WriteLine("-------------------------------------------------------");

                    // Recorremos desde 0 hasta el número de ventas que llevamos
                    for (int i = 0; i < contadorVentas; i++)
                    {
                        // Usamos tabuladores (\t) o espacios para que se vea derecho
                        Console.WriteLine(listaHoras[i] + "    | " + listaClientes[i] + "      | " + listaServicios[i] + "    | $" + listaPrecios[i]);
                    }
                }
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

            else if (opcion == "3") // CORTE DE CAJA
            {
                Console.Clear();
                decimal sumaTotal = 0;

                // Sumamos todos los precios que hay en el arreglo hasta ahora
                for (int i = 0; i < contadorVentas; i++)
                {
                    sumaTotal = sumaTotal + listaPrecios[i];
                }

                Console.WriteLine("========================================");
                Console.WriteLine("           CIERRE DE CAJA               ");
                Console.WriteLine("========================================");
                Console.WriteLine("Total Servicios: " + contadorVentas);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("TOTAL DINERO:    Lps." + sumaTotal);
                Console.ResetColor();
                Console.WriteLine("========================================");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

            else if (opcion == "4") // SALIR
            {
                salir = true;
            }
        }
    }
}
