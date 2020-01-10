using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PruebaSahitest.Bot.Definitions;

namespace PruebaSahitest.Bot.Steps
{
    [Binding]
    public sealed class BooksStep
    {
        BooksDefinition books = new BooksDefinition();

        [When(@"ingrese (.*) libros core Java")]
        public void ingresarCantLibrosJava(string cantidad)
        {
            books.ingresarCantLibrosJava(cantidad);
        }

        [When(@"ingrese (.*) ruby for rail")]
        public void ingresarCantLibrosRuby(string cantidad)
        {
            books.ingresarCantLibrosRuby(cantidad);
        }

        [When(@"ingrese (.*) libros Python Cookbook")]
        public void ingresarCantLibrosPhyton(string cantidad)
        {
            books.ingresarCantLibrosPhyton(cantidad);
        }

        [When(@"seleccione la opcion Add")]
        public void SeleccionarOpcionAdd()
        {
            books.SeleccionarOpcionAdd();
        }

        [When(@"seleccione la opcion Clear")]
        public void SeleccionarOpcionClear()
        {
            books.SeleccionarOpcionClear();
        }

        [Then(@"debe presentar en Grand Total (.*)")]
        public void ValidarValorTotal(string valor)
        {
            books.ValidarValorTotal(valor);
        }

        [Then(@"no debe presentar ningun valor en add quantity")]
        public void ThenNoDebePresentarNingunValorEnAddQuantity()
        {
            books.ValidarValorTotalVacio();
        }


        [Then(@"debe presentar los datos")]
        public void ValidarPrecioUnidad(Table table)
        {
            books.ValidarPrecioUnidad(table);
        }


        [Then(@"debe presentar los datos en My Cart")]
        public void ThenDebePresentarLosDatosEnMyCart(Table table)
        {
            books.ValidarPrecioTotal(table);
        }

        [Then(@"no debe presentar ningun dato en My Cart")]
        public void ValidarNoCredito()
        {
            books.ValidarNoCredito();
        }

        [Then(@"finalizo el escenario")]
        public void ThenFinalizoElEscenario()
        {
            books.Finalizar();
        }


    }
}
