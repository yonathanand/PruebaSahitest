Feature: Validar funcionamiento del carro de compras
	

Background:
Given que utilizo el navegador Chrome
And que ingreso a la url de training
And ingreso en el campo Username test
And ingreso en el campo Password secret
And selecciono la opcion Login
When visualice el texto All available books

Scenario: validar precio correcto de los libros
Then debe presentar los datos
| Title           | Instock | Cost    |
| Core Java       | 5       | Rs. 300 |
| Ruby for Rails  | 12      | Rs. 200 |
| Python Cookbook | 7       | Rs. 350 |
And finalizo el escenario


Scenario: validar precio correcto totales de los libros
When ingrese 3 libros core Java
And ingrese 5 ruby for rail
And ingrese 2 libros Python Cookbook
And seleccione la opcion Add
Then debe presentar los datos en My Cart
| Title           | Quantity | UnitCost | TotalCost |
| Core Java       | 03        | Rs.300   | Rs.900    |
| Ruby for Rails  | 05        | Rs.200   | Rs.1000   |
| Python Cookbook | 02        | Rs.350   | Rs.700    |
And debe presentar en Grand Total 2600
And finalizo el escenario

Scenario: validar cantidad cero en Add quantity to cart
When ingrese 0 libros core Java
And ingrese 0 ruby for rail
And ingrese 0 libros Python Cookbook
And seleccione la opcion Add
Then no debe presentar ningun dato en My Cart
And debe presentar en Grand Total 0
And finalizo el escenario

Scenario: validar ingresando caracteres string en Add quantity to cart
When ingrese a libros core Java
And ingrese b ruby for rail
And ingrese c libros Python Cookbook
And seleccione la opcion Add
Then no debe presentar ningun dato en My Cart
And debe presentar en Grand Total 0
And finalizo el escenario

Scenario: validar ingresando un valor superior a el stock en Add quantity to cart
When ingrese 100 libros core Java
And ingrese 200 ruby for rail
And ingrese 300 libros Python Cookbook
And seleccione la opcion Add
Then no debe presentar ningun dato en My Cart
Then debe presentar en Grand Total 0
And finalizo el escenario


Scenario: validar opcion Clear cuando hay datos en el formulario
When ingrese 1 libros core Java
And ingrese 2 ruby for rail
And ingrese 3 libros Python Cookbook
And seleccione la opcion Add
And seleccione la opcion Clear
Then no debe presentar ningun dato en My Cart
And debe presentar en Grand Total 0
And finalizo el escenario










