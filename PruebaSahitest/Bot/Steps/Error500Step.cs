using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using PruebaSahitest.Bot.Definitions;

namespace PruebaSahitest.Bot.Steps
{
    [Binding]
    public sealed class Error500Step
    {
        static IConfiguration config;
        private readonly string urlDemo;
        private readonly string urltraining;
        Error500Definition error500 = new Error500Definition();
        

        public Error500Step()
        {
            config = InitConfiguration();
            urlDemo = config.GetSection("AppSettings:urlDemo").Value;
            urltraining = config.GetSection("AppSettings:urltraining").Value;
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return config;
        }       


        [Given(@"que ingreso a la url demo")]
        public void IngresarUrlDemo()
        {
            error500.ingresarUrl(urlDemo);
        }

        [When(@"cuando visualice el titulo (.*)")]
        public void ValidarTitulo(string texto)
        {
            error500.ValidarTitulo(texto);
        }

        [Then(@"debe presentar la opcion Error Pages con el texto (.*)")]
        public void ValidarTextoOpcionErrorPage(string texto)
        {
            error500.ValidarTextoOpcionErrorPage(texto);
        }

        [When(@"seleccione la opcion Error Pages")]
        public void SeleccionarOpcionErrorPage()
        {
            error500.SeleccionarOpcionErrorPage();
        }

        [When(@"presente la opcion (.*)")]
        public void WhenPresenteLaOpcionPage(string texto)
        {
            error500.ValidarTextoOpcionError500(texto);
        }

        [When(@"seleccione la opcion 500 Page")]
        public void WhenSeleccioneLaOpcionPage()
        {
            error500.SeleccionarOpcionError500();
        }

        [Then(@"debe presentar el titulo (.*)")]
        public void ValidarTituloPaginaError500(string texto)
        {
            error500.ValidarTituloPaginaError500(texto);
        }

        [Then(@"debe presentar el subtitulo (.*)")]
        public void ValidarSubtituloPaginaError500(string texto1)
        {
            error500.ValidarSubtituloPaginaError500(texto1);

        }

        [Then(@"debe presentar la opcion Cargar de nuevo")]
        public void ThenDebePresentarLaOpcionCargarDeNuevo()
        {
            error500.ValidarPresentacionOpcionCargarDeNuevo();
        }



    }
}
