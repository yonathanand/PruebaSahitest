using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PruebaSahitest.Bot.Pages;
using PruebaSahitest.Bot.Actions;

namespace PruebaSahitest.Bot.Definitions
{
    class Error500Definition
    {
        public static GeneralActions generalaction = new GeneralActions();
        GeneralActions actor = generalaction.GetActor();
        Error500Page error500 = new Error500Page();
        public static readonly string ERROR_MSG_TEXT = "Error, al intentar obtener el texto {0} se obtuvo: {1}";


        public void ingresarUrl(string ruta)
        {
            error500.ingresarUrl(ruta);
        }



        public void ValidarTitulo(string texto)
        {
            try
            {
                string retornaMensaje = error500.ExtraerTitulo(texto);
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer titulo", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }

        public void ValidarTextoOpcionErrorPage(string texto)
        {
            try
            {
                string retornaMensaje = error500.ExtraerTextoOpcionErrorPage(texto);
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer texto opcion error page", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }

        public void SeleccionarOpcionErrorPage()
        {
            error500.SeleccionarOpcionErrorPage();
        }

        public void ValidarTextoOpcionError500(string texto)
        {
            try
            {
                string retornaMensaje = error500.ExtraerTextoOpcionError500(texto);
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer texto opcion error 500", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }
        public void ValidarTituloPaginaError500(string texto)
        {
            try
            {
                string retornaMensaje = error500.ExtraerTituloPaginaError500(texto);
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer titulo error 500", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }

        public void ValidarSubtituloPaginaError500(string texto)
        {
            try
            {
                string retornaMensaje = error500.ExtraerSubtituloPaginaError500();
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer subtitulo 1 error 500", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }
        

        public void SeleccionarOpcionError500()
        {
            error500.SeleccionarOpcionError500();
        }

        public void ValidarPresentacionOpcionCargarDeNuevo()
        {

            try
            {
                bool Retorna = error500.ValidarPresentacionOpcionCargarDeNuevo();
                Assert.IsTrue(Retorna, "No se presento la opcion cargar de nuevo y esta debe presentarse");
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }


    }
}
