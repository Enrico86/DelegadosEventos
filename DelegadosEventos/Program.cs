using System;
using System.Collections.Generic;

namespace DelegadosEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaLuces luces = new SistemaLuces();
            //Instanciamos en nuestra clase program uno de los tres sistemas externos

            Action action = new Action(luces.ApagarLuces);
            //Cuando instanciamos el delegado Action, nos solicita como parametro un método que no devuelve nada (void) y que 
            //no acepta ningún parametro. Justamente esta es la misma firma que tenemos nosotros en los métodos ApagarLuces,
            //EncenderAlarma y ApagarElectrodomesticos. Especificamente utilizaremos estos delegados Action cuando no deseemos 
            //devolver información como parte del delegado, como en este caso.
            
            Action<int, int, int, int> action2 = new Action<int, int, int, int>
                (Accion1);
            //El delegado Action acepta también genericos como datos de entrada. Es decir, con las llaves menor mayor que
            //caracterizan genericos, podemos decirle que el delegado contiene 4 datos genericos de entrada (en nuestro caso
            //4 tipos de dato int). Por lo tanto el método tiene que cumplir con esta firma del delegado. Es decir tiene que
            //ser un método void y que reciba 4 parametros de tipo int

            Action<int, int, int> action3 = new Action<int, int, int>(Accion1);
            //No da ningun problema porqué hemos creado sobrecarga de metodos para Accion1, que puede recibir tanto tres 
            //parametros de tipo entero como cuatro. 

            action();
            action2(2, 4, 8, 12);
            action3(7, 25, 89);


            Func<string> func = new Func<string>(Funcion1);
            //Creamos un delegado Func que hace referencia a un método que tendrá que devolver un dato de tipo string pero que 
            //no recibe ningún parametro. En este caso por lo tanto el generico que especificamos para el delegado hace 
            //referencia al tipo de dato devuelto por el método Funcion1, que tendrá que respetar la firma de este delegado
            Console.WriteLine(func());
            //Simplemente imprimimos en pantalla el dato devuelto (string) por el delegado

            Func<string, string> func2 = new Func<string, string>(Funcion1);
            //Creamos un segundo delegado de tipo Func. En este caso vamos que especificamos dos genericos. El primero es el
            //tipo de dato que tendrá que recibir por parametro el método al que hacemos referencia (Funcion1), mientras que el 
            //segundo dato será el tipo de dato devuelto por el método. El ´método tendrá que respetar la firma del delegado
            //para que podamos hacer referencia a él.
            Console.WriteLine(func2("Hola prueba"));
            //Utilizamos el delegado func2 y le pasamos el parametro de tipo string que se esperaba recibir.

            Func<string, int, bool, string> func3 = new Func<string, int, bool, string>(Funcion1);
            //Vemos como podemos utilizar este delegado también con métodos que reciban parametros de tipo diferente. Lo 
            //importante es que el método respete la firma del delegado. El ultimo generico que especificamos en un delegado de 
            //tipo Func siempre será el tipo de dato devuelto por el método al que hace referencia
            Console.WriteLine(func3("EJEMPLO",15,true));
            //Pasamos los tres parametros que ahora espera recibir el delegado func3 e imprimimos en pantalla la cadena string
            //que es el resultado del método al que hace referencia el delegado.

            
            
            //CentralHub hub = new CentralHub();

            //hub.Add(luces.ApagarLuces);
            //hub.Add(alarmas.EncenderAlarmas);
            //hub.Add(electrodomesticos.ApagarElectrodomesticos);
            ////Y a través de la instanica hub de CentralHub podemos acceder a los método Add y Remove para agregar / quitar
            ////funcionalidad a nuestro protocolo de cierre. Como parametro necesita recibir lo mismo que antes pasabamos 
            ////directamente al delegado, es decir la referencia del método que queremos agregar al delegado.

            //hub.IniciarProtocoloCierre();
            //Controlamos los tres sistemas externos desde la instancia de la clase que hemos creado
            Console.ReadLine();
        }
        static void Accion1(int num1, int num2, int num3, int num4)
        //Vamos a crear un método que cumpla con la firma del delegado para poderselo pasar como parametro al delegado
        //Action
        {
            Console.WriteLine($"El primer numero es: {num1}, el segundo {num2}, el tercero {num3} y el cuarto {num4}");
        }

        static void Accion1 (int num1, int num2, int num3)
        {
            Console.WriteLine($"El primer numero es: {num1}, el segundo {num2} y el tercero {num3}");
        }

        static string Funcion1 ()
            //Creamos el método Funcion1 al que hace referencia el delegado Func. No recibe ningún parametro pero tiene que 
            //devolver un dato de tipo string, tal como especificamos en la firma del delegado.
        {
            return "Hola";
        }
        static string Funcion1(string param1)
            //Creamos sobrecarga de métodos para Funcion1 para que podamos hacer referencia a este mismo método desde el
            //segundo delegado, que esperaba recibir por parametro un método string y que recibe un parametro de tipo string
        {
            return param1;
        }
        static string Funcion1(string param1, int param2, bool param3)
        //Vemos que este método Funcion1 recibe parametros de diferentes tipos. Es solo para que veamos que los params no tienen
        //porqué ser siempre del mismo tipo.
        {
            return $"Mensaje de texto: {param1} para el número {param2} y la variable booleana {param3}";
            //Este return no tiene muchos entido, es solo a nivel demostrativo de que podemos utilizar este metodo en un 
            //delegado de tipo Func
        }


    }
}
