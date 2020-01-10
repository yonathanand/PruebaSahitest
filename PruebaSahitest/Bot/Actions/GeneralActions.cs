using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Threading;
using System;
using NUnit.Framework;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;

namespace PruebaSahitest.Bot.Actions
{
    class GeneralActions
    {
        public RemoteWebDriver driver;
        private static GeneralActions actor;
        static IConfiguration config;
        string ruta = Directory.GetCurrentDirectory() + "\\Auxiliar\\Resources\\Driver\\Chrome";
        readonly ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService(Directory.GetCurrentDirectory() + "\\Auxiliar\\Resources\\Driver\\Chrome");
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        readonly FirefoxDriverService firefoxService = FirefoxDriverService.CreateDefaultService(Directory.GetCurrentDirectory() + "\\Auxiliar\\Resources\\Driver\\Firefox");
        private readonly string urlDominio;

        public GeneralActions GetActor()
        {
            if (actor == null)
            {
                actor = new GeneralActions();
            }
            return actor;
        }

        public GeneralActions()
        {
            config = InitConfiguration();
            urlDominio = config.GetSection("AppSettings:urlDominio").Value;

        }

        public static IConfiguration InitConfiguration()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return config;
        }

        public void SeleccionarNavegador(string navegador)
        {
            switch (navegador)
            {
                case "Chrome":
                    CambiarNavegadorChrome();
                    break;
                case "Firefox":
                    CambiarNavegadorFireFox();
                    break;                
            }
        }

        public void AbrirUrl(string ruta)
        {
            driver.Navigate().GoToUrl(urlDominio + ruta);
            Thread.Sleep(3000);
        }

        public void CambiarNavegadorChrome()
        {
            driver = new ChromeDriver(chromeService);
        }

        public void CambiarNavegadorFireFox()
        {
            driver = new FirefoxDriver(firefoxService);
        }

        public void LimpiarCampos(IWebElement campo)
        {
            try
            {
                campo.Clear();
            }
            catch (Exception e)
            {
                Finalizar();
                Assert.Fail("No fue posible realizar clic el limpiado de los campos" + e);
            }
        }

        public void Click(IWebElement boton)
        {
            try
            {
                boton.Click();
            }
            catch (Exception e)
            {
                Finalizar();
                Assert.Fail("No fue posible realizar clic en el boton " + boton + e);
            }
        }

        public void IngresarTexto(IWebElement elementoTexto, string texto)
        {
            try
            {
                elementoTexto.SendKeys(texto);
            }
            catch (Exception e)
            {
                Finalizar();
                Assert.Fail("No fue posible ingresar el texto " + texto + e);
            }
        }

        public string ExtraerTexto(IWebElement texto)
        {

            try
            {
                return texto.Text;
            }
            catch (Exception e)
            {
                Finalizar();
                Assert.Fail("No fue posible extraer el texto " + texto + e);
                return null;
            }
        }

        public void Finalizar()
        {

            driver.Close();
            driver.Quit();
            KillProcess("chromedriver");
            KillProcess("geckodriver");
        }

        public void KillProcess(string processDriver)
        {
            foreach (var process in Process.GetProcessesByName(processDriver))
            {
                process.Kill();
            }

        }

        public bool EstaPresente(IWebElement elemento)
        {
            try
            {
                return elemento.Displayed;
            }
            catch (Exception e)
            {
                {
                    Finalizar();
                    Assert.Fail("No fue posible extraer elemento " + e);
                    return false;
                }
            }
        }

        public string ExtraerAtributo(IWebElement elemento)
        {
            try
            {
                return elemento.GetAttribute("value");
            }
            catch (Exception e)
            {
                {
                    Finalizar();
                    Assert.Fail("No fue posible extraer elemento " + e);
                    return null;
                }
            }
        }

        public IWebElement EsperaId(string id)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(x => x.FindElement(By.Id(id)));
            }
            catch (Exception e)
            {
                Finalizar();
                Assert.Fail("No fue posible mapear el elemento " + id + e);
                return null;
            }
        }

        public IWebElement EsperaXpath(string xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
                return wait.Until(x => driver.FindElement(By.XPath(xpath)));
            }
            catch (Exception e)
            {
                Finalizar();
                Assert.Fail("No fue posible mapear el elemento " + xpath + e);
                return null;
            }
        }

        public IWebElement EsperaXpathONull(string xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
                return wait.Until(x => driver.FindElement(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
