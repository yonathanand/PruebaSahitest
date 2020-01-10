using System;
using System.Collections.Generic;
using System.Text;
using PruebaSahitest.Bot.Pages;
using PruebaSahitest.Bot.Actions;
using NUnit.Framework;

namespace PruebaSahitest.Bot.Definitions
{
    class LoginDefinition
    {
        public static GeneralActions generalaction = new GeneralActions();
        GeneralActions actor = generalaction.GetActor();
        LoginPage login = new LoginPage();
        public static readonly string ERROR_MSG_TEXT = "Error, al intentar obtener el texto {0} se obtuvo: {1}";


        public void SeleccionarNavegador(string navegador)
        {
            login.SeleccionarNavegador(navegador);
        }
        public void ingresarUrl(string ruta)
        {
            login.ingresarUrl(ruta);
        }

        public void ingresarUsername(string username)
        {
            login.ingresarUsername(username);
        }

        public void ingresarPassword(string password)
        {
            login.ingresarPassword(password);
        }

        public void SeleccionarLogin()
        {
            login.SeleccionarLogin();
        }

        public void ValidarTituloPaginaBooks(string texto)
        {
            try
            {
                string retornaMensaje = login.ExtraerTituloPaginaBooks(texto);
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer titulo pagina books", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }

        public void ValidarMensajeErrorLogin(string texto)
        {
            try
            {
                string retornaMensaje = login.ExtraerMensajeErrorLogin(texto);
                Assert.True(retornaMensaje.Equals(texto), string.Format(ERROR_MSG_TEXT + " en extraer mensaje error login", texto, retornaMensaje));
            }
            catch (Exception)
            {
                actor.Finalizar();
                Assert.Fail();
            }
        }
    }
}
