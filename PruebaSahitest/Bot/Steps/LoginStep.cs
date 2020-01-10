using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PruebaSahitest.Bot.Definitions;

namespace PruebaSahitest.Bot.Steps
{
    [Binding]
    public sealed class LoginStep
    {
        static IConfiguration config;
        private readonly string urltraining;
        LoginDefinition login = new LoginDefinition();


        public LoginStep()
        {
            config = InitConfiguration();           
            urltraining = config.GetSection("AppSettings:urltraining").Value;
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return config;
        }

        [Given(@"que utilizo el navegador (.*)")]
        public void SeleccionarNavegador(string navegador)
        {
            login.SeleccionarNavegador(navegador);
        }



        [Given(@"que ingreso a la url de training")]
        public void IngresarUrlTraining()
        {
            login.ingresarUrl(urltraining);
        }

        [Given(@"ingreso en el campo Username (.*)")]
        public void ingresarUsername(string username)
        {
            login.ingresarUsername(username);
        }

        [Given(@"ingreso en el campo Password (.*)")]
        public void ingresarPassword(string password)
        {
            login.ingresarPassword(password);
        }

        [When(@"seleccione la opcion Login")]
        public void SeleccionarLogin()
        {
            login.SeleccionarLogin();
        }

        [Given(@"selecciono la opcion Login")]
        public void SeleccionarOpcionLogin()
        {
            login.SeleccionarLogin();
        }

        [Then(@"debe presentar el mensaje (.*)")]
        public void ValidarMensajeErrorLogin(string mensaje)
        {
            login.ValidarMensajeErrorLogin(mensaje);
        }

        [Then(@"en la pantalla books debe presentar el titulo (.*)")]
        public void ValidarTituloPaginaBooks(string titulo)
        {
            login.ValidarTituloPaginaBooks(titulo);
        }

        [When(@"visualice el texto (.*)")]
        public void ValidarIngresoPaginaBooks(string titulo)
        {
            login.ValidarTituloPaginaBooks(titulo);
        }  

    }
}
