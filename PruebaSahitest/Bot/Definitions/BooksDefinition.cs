using System;
using System.Collections.Generic;
using System.Text;
using PruebaSahitest.Bot.Pages;
using PruebaSahitest.Bot.Actions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Threading;

namespace PruebaSahitest.Bot.Definitions
{
    class BooksDefinition
    {
        public static GeneralActions generalaction = new GeneralActions();
        GeneralActions actor = generalaction.GetActor();
        BooksPage books = new BooksPage();
        public static readonly string ERROR_MSG_TEXT = "Error, al intentar obtener el texto {0} se obtuvo: {1}";


        public void ingresarCantLibrosJava(string cantidad)
        {
            Thread.Sleep(1000);
            books.ingresarCantLibrosJava(cantidad);
        }

        public void ingresarCantLibrosPhyton(string cantidad)
        {
            Thread.Sleep(1000);
            books.ingresarCantLibrosPhyton(cantidad);
        }

        public void ingresarCantLibrosRuby(string cantidad)
        {
            Thread.Sleep(1000);
            books.ingresarCantLibrosRuby(cantidad);
        }

        public void SeleccionarOpcionAdd()
        {
            books.SeleccionarOpcionAdd();
            Thread.Sleep(1000);
        }

        public void SeleccionarOpcionClear()
        {
            books.SeleccionarOpcionClear();
        }

        public void ValidarValorTotal(string texto)
        {
            try
            {
                string retornaMensaje = books.ExtraerValorTotal();
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer valor total pagina books", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }

        public void ValidarValorTotalVacio()
        {
            try
            {
                string retornaMensaje = books.ExtraerValorTotal();
                Assert.IsTrue(retornaMensaje.Equals("0"), string.Format(ERROR_MSG_TEXT + " Presento un valor distinto a cero",  retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }


        public void ValidarPrecioUnidad(Table precioUnidad)
        {
            for (int i = 0; i < precioUnidad.RowCount; i++)
            {
                String Title = precioUnidad.Rows[i]["Title"];
                String Instock = precioUnidad.Rows[i]["Instock"];
                String Cost = precioUnidad.Rows[i]["Cost"];
                

                try
                {
                    string retornaMensaje1 = (books.ExtraerDatoTabla(Title, i+2)).TrimEnd().TrimStart();
                    Assert.True(retornaMensaje1.Equals(Title), string.Format(ERROR_MSG_TEXT + " en extraer title ", Title, retornaMensaje1));

                    string retornaMensaje2 = (books.ExtraerDatoTabla(Instock, i+2)).TrimEnd().TrimStart();
                    Assert.True(retornaMensaje2.Equals(Instock), string.Format(ERROR_MSG_TEXT + " en extraer In stock ", Instock, retornaMensaje2));

                    string retornaMensaje3 = books.ExtraerDatoTabla(Cost, i+2);
                    Assert.True(retornaMensaje3.Equals(Cost), string.Format(ERROR_MSG_TEXT + " en extraer Cost", Cost, retornaMensaje3));
                                        
                }

                catch (Exception)
                {
                    actor.Finalizar();
                    Assert.Fail();
                }
                
            }

        }

        public void ValidarNoCredito()
        {

            try
            {
                bool Retorna = books.NoPresentarDatoMyCart();
                Assert.IsFalse(Retorna, "Se presento datos en my cart y este no debe presentarse");
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }

        public void ValidarPrecioTotal(Table precioTotal)
        {
            for (int i = 0; i < precioTotal.RowCount; i++)
            {
                String Title = precioTotal.Rows[i]["Title"];
                String Quantity = precioTotal.Rows[i]["Quantity"];
                String UnitCost = precioTotal.Rows[i]["UnitCost"];
                String TotalCost = precioTotal.Rows[i]["TotalCost"];


                try
                {
                    string retornaMensaje1 = (books.ExtraerDatoTablaMyCart(Title, i+2)).TrimEnd().TrimStart();
                    Assert.True(retornaMensaje1.Equals(Title), string.Format(ERROR_MSG_TEXT + " en extraer title ", Title, retornaMensaje1));

                    string retornaMensaje2 = (books.ExtraerDatoTablaMyCart(Quantity, i+2)).TrimEnd().TrimStart();
                    Assert.True(retornaMensaje2.Equals(Quantity), string.Format(ERROR_MSG_TEXT + " en extraer Quantity ", Quantity, retornaMensaje2));

                    string retornaMensaje3 = books.ExtraerDatoTablaMyCart(UnitCost, i+2);
                    Assert.True(retornaMensaje3.Equals(UnitCost), string.Format(ERROR_MSG_TEXT + " en extraer Unit Cost", UnitCost, retornaMensaje3));
                    
                    string retornaMensaje4 = books.ExtraerDatoTablaMyCart(TotalCost, i+2).TrimStart();
                    Assert.True(retornaMensaje4.Equals(TotalCost), string.Format(ERROR_MSG_TEXT + " en extraer Total Cost", TotalCost, retornaMensaje4));

                }

                catch (Exception)
                {
                    actor.Finalizar();
                    Assert.Fail();
                }

            }

        }

        public void Finalizar()
        {
            books.Finalizar();
        }
    }
}
