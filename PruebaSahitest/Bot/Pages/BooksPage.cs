using PruebaSahitest.Bot.Actions;
using OpenQA.Selenium;

namespace PruebaSahitest.Bot.Pages
{
    class BooksPage
    {
        public static GeneralActions generalaction = new GeneralActions();
        GeneralActions actor = generalaction.GetActor();

        string lblTable = "listing";
        string lblTableMyCart = "added";
        string lblTotal = "total";


        public string ExtraerDatoTabla(string texto, int posicion)
        {
            IWebElement strTexto = actor.EsperaXpath(string.Format("//table[@id='{0}']//tr[{1}]/td[text()='{2}']", lblTable, posicion, texto));
            return actor.ExtraerTexto(strTexto);
        }

        public string ExtraerDatoTablaMyCart(string texto, int posicion)
        { 
            IWebElement strTexto = actor.EsperaXpath(string.Format("//table[@id='{0}']//tr[{1}]//td[contains(text(),'{2}')]", lblTableMyCart, posicion, texto));
            return actor.ExtraerTexto(strTexto);
        }

        public void ingresarCantLibrosJava(string cantidad)
        {
            IWebElement inpJava = actor.EsperaXpath("//tr[2]//input[@name='q']");
            actor.IngresarTexto(inpJava, cantidad);
        }

        public void ingresarCantLibrosRuby(string cantidad)
        {
            IWebElement inpRuby = actor.EsperaXpath("//tr[3]//input[@name='q']");
            actor.IngresarTexto(inpRuby, cantidad);
        }

        public void ingresarCantLibrosPhyton(string cantidad)
        {
            IWebElement inpPhyton = actor.EsperaXpath("//tr[4]//input[@name='q']");
            actor.IngresarTexto(inpPhyton, cantidad);
        }

        public void SeleccionarOpcionAdd()
        {
            IWebElement btnAdd = actor.EsperaXpath("//input[@value='Add']");
            actor.Click(btnAdd);
        }

        public void SeleccionarOpcionClear()
        {
            IWebElement btnClear = actor.EsperaXpath("//input[@value='Clear']");
            actor.Click(btnClear);
        }

        public string ExtraerValorTotal()
        {
            IWebElement strValorTotal = actor.EsperaId(lblTotal);
            return actor.ExtraerAtributo(strValorTotal);
        }

        public bool NoPresentarDatoMyCart()
        {
            IWebElement libro = actor.EsperaXpathONull("//table[@id='added']//tr[2]/td[text()='Core Java']");
            if (libro != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public void Finalizar()
        {
            actor.Finalizar();
        }

    }
}
