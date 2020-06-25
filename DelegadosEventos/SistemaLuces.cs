using System;
using System.Collections.Generic;
using System.Text;

namespace DelegadosEventos
{
    class SistemaLuces
    {
        public void ApagarLuces ()
            //Con esto queremos simular un sistema completo (desarrollado por el instalador de luces) que nos permita
            //acceder a este método, no pretendemos desarrollar el apagado de las luces, sino ver como lo podemos controlar
            //desde nuestra app instalada en el hub central.
        {
            Console.WriteLine("Luces apagadas");
        }
    }
}
