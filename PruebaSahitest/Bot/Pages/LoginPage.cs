using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using PruebaSahitest.Bot.Actions;

namespace PruebaSahitest.Bot.Pages
{
    class LoginPage
    {
        public static GeneralActions generalaction = new GeneralActions();
        GeneralActions actor = generalaction.GetActor();

        public void SeleccionarNavegador(string navegador)
        {
            actor.SeleccionarNavegador(navegador);
        }

        public void ingresarUrl(string ruta)
        {
            actor.AbrirUrl(ruta);
        }

        public void ingresarUsername(string username)
        {
            IWebElement inpUsername = actor.EsperaXpath("//input[@name='user']");
            actor.IngresarTexto(inpUsername, username);
        }

        public void ingresarPassword(string password)
        {
            IWebElement inpPassword = actor.EsperaXpath("//input[@name='password']");
            actor.IngresarTexto(inpPassword, password);
        }

        public void SeleccionarLogin()
        {
            IWebElement btnLogin = actor.EsperaXpath("//input[@type='submit']");
            actor.Click(btnLogin);
        }

        public string ExtraerMensajeErrorLogin(string texto)
        {
            IWebElement strErrorLogin = actor.EsperaId("errorMessage");
            return actor.ExtraerTexto(strErrorLogin);
        }

        public string ExtraerTituloPaginaBooks(string texto)
        {
            IWebElement strTituloPaginaBooks = actor.EsperaXpath(string.Format("//div[@id='available']/h2[text()='{0}']", texto));
            return actor.ExtraerTexto(strTituloPaginaBooks);
        }


    }
}
