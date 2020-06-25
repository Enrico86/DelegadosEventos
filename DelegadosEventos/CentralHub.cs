using System;
using System.Collections.Generic;
using System.Text;

namespace DelegadosEventos
{
    class CentralHub
        //Con esta clase pretendemos poder controlar los tres diferentes sistemas que nos han montado
    {

        public delegate void iniciarProtocoloDelegate();
        //El delegado tiene que tener la misma firma del/los método/s a los que hace referencia: es un método void y no recibe
        //ningún parametro, y logicamente tiene que tener la palbra reservada delegate delante.

        iniciarProtocoloDelegate iniciarProtocolo;
        //Después de haber creado un delegado, el siguiente paso es crear una instancia del mismo y hacer que haga referencia
        //a un método utilizando el operador compuesto +=. De hecho con la decalarción de un delegado es como si hubieramos
        //creado una nueva clase o estructura, por lo que le podemos asignar un nombre; es como si tuvieramos un tipo de dato 
        //int con su correspectivo nombre, solo que al ser un delegado antes tuvimos que especificar cual es el tipo de dato
        //que delegará (delegate void) y los parametros que recibirá (en este ejemplo ninguno).

        //public iniciarProtocoloDelegate IniciarProtocolo 
        //{ 
        //    get=>iniciarProtocolo; 
        //    set=> iniciarProtocolo=value; 
        //}
        //La primera forma sería convertir en public el delegado iniciarProtocolo; la segunda forma sería esta, crear una 
        //propiedad accesible (publica) que con el get coja el valor del delegado iniciarProtocolo y con el set 
        //asigne un valor al mismo

        //public CentralHub()
        //{
        //    ////iniciarProtocolo += luces.ApagarLuces;
        //    //iniciarProtocolo = new iniciarProtocoloDelegate(luces.ApagarLuces);
        //    ////Estas dos líneas hacen exactamente lo mismo. La segunda es más larga, pero era unicamente para ver que
        //    ////cuando instanciamos nuestro delegado (que dijimos antes que era como una clase) este tiene que recibir por 
        //    ////parametro un método que tenga la misma firma que esepcificamos en la declaración del delegado
        //    //iniciarProtocolo += alarmas.EncenderAlarmas;
        //    //iniciarProtocolo += electrodomesticos.ApagarElectrodomesticos;
        //    ////Con el operador compuesto += podemos añadir al delegado toda la funcionalidad que queramos, siempre y cuando
        //    ////estos métodos tengan la firma requerida por el delegado. Con el operador -= podemos de la misma forma
        //    ////quitar cierta funcionalidad que habíamos asignado anteriormente al delegado
        //}

        //SistemaLuces luces = new SistemaLuces();
        //SistemaAlarmas alarmas = new SistemaAlarmas();
        //SistemaElectrodomesticos electrodomesticos= new SistemaElectrodomesticos();
        //Vamos a hacer tres referencias a los tres sistemas para tener tres campos de esta clase que podamos utilizar
        //También tendremos que instanciar estas tres clases para que no tengan referencia null, de otra manera cuando
        //invoquemos estos métodos nos daría error, ya que intentará hacerlo un objeto que es null

        public void IniciarProtocoloCierre()
            //Creamos un método que invoque los tres métodos digamos externos (nos han llegado ya con esta funcionalidad)
        {
            iniciarProtocolo();
            //Aquí es donde le tendríamos que pasar los parametros en el caso que el método al que hace referencia el delegado 
            //reciba parametros
        }
         
        public void Add (iniciarProtocoloDelegate metodoProtocolo)=>
            //Este método no devuelve nada, solo ejecuta la acción de añadir un método al protocolo. Recibe por parametro un 
            //dato de tipo delegado (acordemonos que la intención de esto que estamos haciendo es desacoplar nuestra clase
            //CentralHub de los sistemas (clases) externos, por lo que tiene todo el sentido que este método vaya a 
            //añadir una funcionalidad de tipo delegado a nuestro delegado. De hecho ya hemos dicho que un deñlegado se utiliza 
            //para pasar a un método otro método como parametro, que es nuestra necesidad ahora: pasarle un método al método
            //Add para que este añada una referencia del mismo a nuestro delegado

            iniciarProtocolo += metodoProtocolo;
            //Vamos a utilizar el operador compuesto += para añadir la referencia al método a delegar a nuestro delegado. 
            //Vemos que de esta manera no necesitamos instanciar aquí en esta clase las tres clases de sistemas externos, 
            //sino que ahora lo podremos hacer desde fuera

        public void Remove (iniciarProtocoloDelegate metodoProtocolo)=>
            iniciarProtocolo -= metodoProtocolo;
        //De la misma forma creamos el método Remove que a diferencia del Add utiliza el operador compuesto -= para quitar alguna
        //referencia a un método a nuestro delegado
    }
}
