using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using PruebaSahitest.Bot.Actions;

namespace PruebaSahitest.Bot.Pages
{
    class Error500Page
    {

        public static GeneralActions generalaction = new GeneralActions();
        GeneralActions actor = generalaction.GetActor();


        public void ingresarUrl(string ruta)
        {
            actor.AbrirUrl(ruta);
        }

        public string ExtraerTitulo(string texto)
        {
            IWebElement strTextoTitulo = actor.EsperaXpath(string.Format("//h2[text()='{0}']", texto));
            return actor.ExtraerTexto(strTextoTitulo);
        }

        public string ExtraerTextoOpcionErrorPage(string texto)
        {
            IWebElement strTextoOpcionErrorPage = actor.EsperaXpath(string.Format("//a[@href='errorPages.htm' and text()='{0}']", texto));
            return actor.ExtraerTexto(strTextoOpcionErrorPage);
        }

        public void SeleccionarOpcionErrorPage()
        {
            IWebElement btnErrorPage = actor.EsperaXpath("//a[@href='errorPages.htm']");
            actor.Click(btnErrorPage);
        }

        public string ExtraerTextoOpcionError500(string texto)
        {
            IWebElement strTextoOpcionError500 = actor.EsperaXpath(string.Format("//a[@href='/demo/php/500.php' and text()='{0}']", texto));
            return actor.ExtraerTexto(strTextoOpcionError500);
        }

        public void SeleccionarOpcionError500()
        {
            IWebElement btnError500 = actor.EsperaXpath("//a[@href='/demo/php/500.php']");
            actor.Click(btnError500);
        }

        public string ExtraerTituloPaginaError500(string texto)
        {
            IWebElement strTituloPaginaError500 = actor.EsperaXpath(string.Format("//div[@id='main-message']/h1/span[text()='{0}']", texto));
            return actor.ExtraerTexto(strTituloPaginaError500);
        }

        public string ExtraerSubtituloPaginaError500()
        {
            IWebElement strSubtitulo1PaginaError500 = actor.EsperaXpath(string.Format("//div[@id='main-message']/p"));
            return actor.ExtraerTexto(strSubtitulo1PaginaError500);
        }

        public bool ValidarPresentacionOpcionCargarDeNuevo()
        {
            IWebElement btnCargarDeNuevo = actor.EsperaId("reload-button");
            return actor.EstaPresente(btnCargarDeNuevo);
        }

    }
}
