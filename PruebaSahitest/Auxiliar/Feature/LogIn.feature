Feature: Validar ingreso a la aplicacion training

Background:
Given que utilizo el navegador Chrome
And que ingreso a la url de training

Scenario: Validar ingreso con datos errados	
Given ingreso en el campo Username 11111
And ingreso en el campo Password 11111
When seleccione la opcion Login
Then debe presentar el mensaje Invalid username or password
And finalizo el escenario


Scenario: Validar ingreso con datos correctos
Given ingreso en el campo Username test
And ingreso en el campo Password secret
When seleccione la opcion Login
Then en la pantalla books debe presentar el titulo All available books
And finalizo el escenario
