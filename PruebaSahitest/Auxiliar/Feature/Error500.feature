Feature: Validar correcto ingreso al sitio demo


Background:
Given que utilizo el navegador Chrome
And que ingreso a la url demo	


Scenario: Validar ingreso a pagina de Sahi Tests
When cuando visualice el titulo Sahi Tests
Then debe presentar la opcion Error Pages con el texto Error Pages
And finalizo el escenario


Scenario: Validar ingreso a pagina de error page y 500 page
When seleccione la opcion Error Pages
And presente la opcion 500 Page
And seleccione la opcion 500 Page
Then debe presentar el titulo Esta página no funciona
And debe presentar el subtitulo La página sahitest.com no puede procesar esta solicitud ahora.
And debe presentar la opcion Cargar de nuevo
And finalizo el escenario
