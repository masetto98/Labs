# Unidad 4 - Laboratorio 5

### Objetivos
Interiorizarse con conceptos de asp net core mvc como lo son: controladores, vistas, modelo, validacion por data annotations, ruteo por código o por vistas, viewmodels, vistas de error, layout (o master-view) e inyección de dependencias.

### Pasos
1. En la clase ```HomeController``` accion ```Index``` redireccionar a la accion ```List``` del controlador ```¨MateriaController```. Para esto usar el metodo 
```c#
RedirectToAction(string actionName, string controllerName)
```

2. En la clase ```Startup``` ir al metodo ```ConfigureServices(IServiceCollection services)``` y agregar los siguientes servicios (repositorios que se encargaran de manejar las colecciones en memoria requeridas para este ejercicio) para ser proveidos por el contenedor de dependencias
```c#
services.AddSingleton<IMateriaRepository, MateriaRepository>();
services.AddSingleton<IPlanRepository, PlanRepository>();
```
> Estos servicios son declarados como singletons por lo que sera proveida siempre la misma instancia de cada uno para cualquier clase que los solicite y por lo tanto la coleccion en memoria que estos alojan perdurara a pesar de que los controladores se reinstancian en cada request (ejemplo, refrescar el navegador de /Materia/List involucra volver a instanciar todo lo que esta declarado en el constructor)

3. En la clase ```MateriaController``` agregar los siguientes campos privados de solo lectura y setearlos en el constructor
```c#
public MateriaController(ILogger<MateriaController> logger, IMateriaRepository materiaRepository, IPlanRepository planRepository)
```
> El contenedor de dependencias proveera las instancias correspondientes de estas clases como se declaro en el paso anterior

4. En la accion ```List``` devolver la vista enviandole los datos de todos las materias pre-cargadas mediante ```_materiaRepository```
```c#
return View(_materiaRepository.GetAll())
```

5. Agregar el contenido de la vista correspondiente ubicada en la carpeta ***Views/Materia***, mostrando un listado ```<ul>``` de cards de bootstrap (clase ***.card***, esto ya viene configurado con el proyecto default de inicio). Asegurarse que los atributos Descripcion, Plan, HsSemanales y HsTotales sean mostrados (estos ultimos dos utilizando la clase ***.card-subtitle*** de bootstrap, ademas se aconseja usar a Descripcion como un ***.card-title*** y para el resto ***.card-text***). En cuanto al uso de directivas razor para iterar en la coleccion usar 
```c#
// Solo al inicio del archivo
@model IEnumerable<Materia>

@foreach (Materia mat in Model){@mat.Descripcion}
```
> Estas directivas ```@mat.{atributo}``` van a popular con los datos enviados desde el controlador el html enviado ante cada request (esto sucede en el servidor, osea su maquina en el puerto 5000). Estas estan fuertemente tipadas (lo cual hace que se provean sugerencias al escribir) gracias a la directiva ```@Model IEnumerable<Materia>``` que se encuentra al inicio del archivo, lo cual determina que tipo de dato se aceptara para ser enviado por el controlador en la accion correspondiente

![image](https://user-images.githubusercontent.com/41701343/132447918-4167529f-bbed-49da-82ad-6e6e33590616.png)

<details close>
<summary>Ver Vista Completa</summary>

```html
@model IEnumerable<Materia>

<ul class="list-group">
    @foreach (Materia mat in Model)
    {
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">@mat.Descripcion</h5>
                <h6 class="card-subtitle mb-2 text-muted">
                    @Html.DisplayNameFor(model => mat.HsSemanales): @mat.HsSemanales -
                    @Html.DisplayNameFor(model => mat.HsTotales): @mat.HsTotales
                </h6>
                <p class="card-text">@mat.Plan.Especialidad <span class="text-info">@mat.Plan.Anio</span></p>
                <a class="btn btn-primary" asp-area="" asp-action="Edit" asp-route-id="@mat.Id">Editar</a>
            </div>
        </div>
    }
</ul>
```

</details> 

6. En la accion ```Edit(int? id)``` devolver la vista inicial para el formulario de edicion, enviandole el viewmodel ```EditMateriaViewModel```(conjunto de datos especifico para esta vista) que toma tomo argumentos requeridos la materia a editar (obtenible desde ```_materiaRepository.GetOne(int id)```) y los planes de estudio disponibles (se puede obtener desde ```_planesRepository.GetAll()```). Recordar validar que el id enviado como argumento a la accion no sea nulo (ya que esto puede ocurrir como bien denota el tipo entero nullable ```int?```) y que la materia devuelta por ```_materiaRepository.GetOne(int id)``` no sea una referencia nula (observar que su tipo de retorno en la firma del metodo es ```Materia?```, un tipo de referencia nullable), si alguna de estas situaciones sucede devolver el resultado ```NotFound()```
<details close>
<summary>Ver Codigo</summary>

```c#
if (id == null) return NotFound();
Materia? materia = _materiaRepository.GetOne((int)id);
if (materia == null) return NotFound();
return View(new EditMateriaViewModel(materia, _planRepository.GetAll()));
```

</details> 

7. Agregar la vista correspondiente, utilizando un formulario de edicion ```<form asp-action="Edit">``` donde como se observa se utilizaran directivas ***asp-{...}*** para agregarle propiedades a la vista que solo seran utilizadas para renderizar el html (con los datos correspondientes) a enviar por el servidor. Usar la directiva razor ```asp-for``` tanto en los input como en los labels contenidos en los ```<div class="form-group"></div>``` (***.form-group*** es una clase de bootstrap). Como este es un formulario de edicion dejar los values de cada ```<input/>``` con el valor del atributo de la materia ```@@Model.Materia.{Atributo}```. Ya que hay un conjunto finito de planes que pueden ser asociados a una materia es conveniente optar por un elemento ```<select></select>``` que muestre las opciones disponibles (para designar cuales son estas utilizar la directiva ```asp-items="Model.Planes"```, donde ***Model.Planes*** es un campo del viewmodel enviado por el controlador). Finalmente, agregar un input de tipo submit con las clases ```.btn .btn-primary``` de bootstrap. Recordar agregar un campo para preservar el atributo id a ser enviado en la accion nuevamente POST
```html
<input asp-for="Materia.Id" type="hidden" />
```

![image](https://user-images.githubusercontent.com/41701343/132448186-45922162-6000-4913-bf35-46d8c03c91c3.png)

<details close>
<summary>Ver Vista Completa</summary>

```html
@model EditMateriaViewModel

<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input asp-for="Materia.Id" type="hidden" />
            <div class="form-group">
                <label asp-for="Materia.Descripcion" class="form-label">Descripcion</label>
                <input asp-for="Materia.Descripcion" class="form-control" placeholder="@Model.Materia.Descripcion"
                       value="@Model.Materia.Descripcion" />
            </div>

            <div class="form-group">
                <label asp-for="Materia.HsSemanales" class="form-label">Horas Semanales</label>
                <input asp-for="Materia.HsSemanales" type="number" class="form-control" placeholder="@Model.Materia.HsSemanales"
                       value="@Model.Materia.HsSemanales">
                <span asp-validation-for="Materia.HsSemanales" class="text-danger"></span>
            </div>

            <div class="form-group">
                <label asp-for="Materia.HsTotales" class="form-label">Horas Totales</label>
                <input asp-for="Materia.HsTotales" type="number" class="form-control" placeholder="@Model.Materia.HsTotales"
                       value="@Model.Materia.HsTotales">
                <span asp-validation-for="Materia.HsTotales" class="text-danger"></span>
            </div>

            <select class="form-group" asp-for="Materia.PlanId" asp-items="Model.Planes"></select>

            <div class="form-group">
                <button type="submit" class="btn btn-primary">Save</button>
            </div>
        </form>
    </div>
</div>
```

</details> 

8. En la entidad ```Materia``` agregar validaciones para lo siguiente
- La descripcion de una materia debe tener este 3 y 20 caracteres
- Las horas semanales de una materia deben ser entre 2 y 6. Ademas, este campo se debe mostrar como "Horas Semanales" 
- Las horas totales no deben sobrepasar las 150 y tienen que ser superiores a 90 horas. Este campo se debe mostrar como "Horas Totales""
- Los campos Descripcion, HsSemanales, HsTotales y PlanId son requeridos
> Para esto usar las data annotations: [StringLength(maximoCaracteres, MinimumLength = minimoCaracteres)]
, [Range(inferior, superior)], [Required], [Display(Name = "nombreX")]

Al terminar agregar los spans siguientes como ultimo contenido de cada ```<div class="form-group">...</div>``` de la vista ***Edit***. Lo cual servira para mostrar los mensajes de validacion correspondientes a cada campo directamente abajo de este, esto sera ejecutado primero en cliente por lo que no se permitira hacer la request al servidor si hay errores de validacion y solo se hara la validacion en servidor si javascript se encuentra desactivado o por otras razones.
```html
// Unicamente al inicio del form
<div asp-validation-summary="ModelOnly" class="text-danger"></div>

// Dentro de cada .form-group
<div class="form-group">
    ...
    <span asp-validation-for="Materia.{Atributo}" class="text-danger"></span>
</div>

```
    
![image](https://user-images.githubusercontent.com/41701343/132448329-fa3b8ae9-5c2f-4bfd-b201-91555a10fa4e.png)
    
    
<details close>
<summary>Ver Código</summary>

```c#
    public int Id { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Descripcion { get; set; }
    [Required]
    [Range(2, 6)]
    [Display(Name = "Horas Semanales")]
    public int HsSemanales { get; set; }
    [Required]
    [Range(90, 150)]
    [Display(Name = "Horas Totales")]
    public int HsTotales { get; set; }
    [Required]
    public int PlanId { get; set; }
    public Plan? Plan { get; set; }
```

</details>

<details close>
<summary>Ver Vista Completa</summary>

```html
@model EditMateriaViewModel

<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input asp-for="Materia.Id" type="hidden" />
            <div class="form-group">
                <label asp-for="Materia.Descripcion" class="form-label">Descripcion</label>
                <input asp-for="Materia.Descripcion" class="form-control" placeholder="@Model.Materia.Descripcion"
                       value="@Model.Materia.Descripcion" />
            </div>

            <div class="form-group">
                <label asp-for="Materia.HsSemanales" class="form-label">Horas Semanales</label>
                <input asp-for="Materia.HsSemanales" type="number" class="form-control" placeholder="@Model.Materia.HsSemanales"
                       value="@Model.Materia.HsSemanales">
                <span asp-validation-for="Materia.HsSemanales" class="text-danger"></span>
            </div>

            <div class="form-group">
                <label asp-for="Materia.HsTotales" class="form-label">Horas Totales</label>
                <input asp-for="Materia.HsTotales" type="number" class="form-control" placeholder="@Model.Materia.HsTotales"
                       value="@Model.Materia.HsTotales">
                <span asp-validation-for="Materia.HsTotales" class="text-danger"></span>
            </div>

            <select class="form-group" asp-for="Materia.PlanId" asp-items="Model.Planes"></select>

            <div class="form-group">
                <button type="submit" class="btn btn-primary">Save</button>
            </div>
        </form>
    </div>
</div>
```

</details>
9. En la accion ```Edit(int id, [Bind("Id, Descripcion, HsSemanales, HsTotales, PlanId")]Materia materia)```, osea la parte que ocurre al hacer submit (POST) del formulario obtenido en el GET de la accion, actualizar la materia del id correspondiente con el metodo ```_materiaRepository.Update(Materia materia)``` y redirigir a la accion ```List```. Recordar comprobar si no se pasaron las validaciones con ```!ModelState.IsValid```, si ocurre re-renderizar la vista devolviendo ```View(new EditMateriaViewModel(...))``` al igual que en el GET y si el id enviado en la ruta no corresponde al enviado en los datos del formulario, si esto ultimo sucede devolver el resultado ```NotFound()```)
<details close>
<summary>Ver Código</summary>

```c#
if (id != materia.Id) return NotFound();
if (!ModelState.IsValid)
{
    return View(new EditMateriaViewModel(materia, _planRepository.GetAll()));
}

_materiaRepository.Update(materia);
return RedirectToAction("List");
```

</details>

10. Agregar el codigo para el viewmodel ```CreateMateriaViewModel``` correspondiente a la accion ```Create```. Este es muy similar al viewmodel correspondiente a la accion ```Edit``` con la salvedad que la propiedad ```Materia``` puede ser nula (al hacer el GET de esta accion siempre lo es, ya que es un formulario de creacion por lo que todos sus datos se encuentran vacios), para esto denotar el tipo de referencia nullable ```Materia?``` cuando sea necesario. Ademas, aqui no se preselecciona ninguna ```<option />``` del ```<select />```, ya que esta no es una materia previamente existente y por lo tanto no tiene ningun plan asignado.

<details close>
<summary>Ver Codigo</summary>

```c#
[HttpGet]
public IActionResult Create()
{
    return View(new CreateMateriaViewModel(null, _planRepository.GetAll()));
}
----------------------------------------------------------------------------
public Materia? Materia { get; }
public List<SelectListItem> Planes { get; }
public CreateMateriaViewModel(Materia? materia, IEnumerable<Plan> planes)
{
    Materia = materia;
    Planes = planes
        .Select(p => new SelectListItem
        { Text = $"{p.Especialidad}:{p.Anio}", Value = p.Id.ToString() }
        ).ToList();
}
```

</details>

11. Con la accion GET de la accion ***Create*** tener en cuenta lo mencionado en el paso anterior. En cuanto a la accion POST proceder de la misma manera que con la de ***Edit***, utilizando el metodo ```_materiaRepository.Add(Materia materia)``` y agregando la anotacion ```[Bind("Id, Descripcion, HsSemanales, HsTotales, PlanId")]``` para solo tomar y validar que esten incluidas esas propiedades en la instancia de materia envidada como argumento. Recordar revisar si las validaciones no fueron exitosas.  
    
<details close>
<summary>Ver Codigo</summary>

```c#
if (!ModelState.IsValid)
{
    return View(new CreateMateriaViewModel(materia, _planRepository.GetAll()));
}

_materiaRepository.Add(materia);
return RedirectToAction("List");
```

</details>

13. Para la vista correspondiente a la accion ***Create*** proceder de forma similar a lo realizado para la vista ***Edit***.
    
![image](https://user-images.githubusercontent.com/41701343/132448388-d1c4d474-e5ac-43b5-9d4d-a4d1365d8d1a.png)  
    
<details close>
<summary>Ver Vista Completa</summary>

```html
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Materia.Descripcion" class="control-label"></label>
                <input asp-for="Materia.Descripcion" class="form-control" />
                <span asp-validation-for="Materia.Descripcion" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Materia.HsSemanales" class="control-label"></label>
                <input asp-for="Materia.HsSemanales" class="form-control" />
                <span asp-validation-for="Materia.HsSemanales" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Materia.HsTotales" class="control-label"></label>
                <input asp-for="Materia.HsTotales" class="form-control" />
                <span asp-validation-for="Materia.HsTotales" class="text-danger"></span>
            </div>
            <select class="form-group" asp-for="Materia.PlanId" asp-items="Model.Planes"></select>
            <div class="form-group">
                <input type="submit" value="Create" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>
```

</details>

14. Ir la carpeta ***/Views/Shared*** vista ***_Layout*** (esta es la master-view donde sobre la que se renderiza cada una de las demas views), alli agregar una opcion mas al navbar ```<li class="nav-item">``` que redirija a la accion ```Create``` mediante las directivas ```asp-area=""```, ```asp-controller="Materia"``` y ```asp-action="Create"```.

<details close>
<summary>Ver Header Completo del Layout</summary>

```html
<header>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
        <div class="container">
            <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">Unidad._5.Lab._1.MVC</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item">
                        <a class="nav-link text-dark" asp-area="" asp-controller="Materia" asp-action="List">Listar Materias</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link text-dark" asp-area="" asp-controller="Materia" asp-action="Create">Agregar Materia</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</header>
```

</details>

15. En la clase ```Startup``` metodo ```Configure(IApplicationBuilder app, IWebHostEnvironment env)``` en el lugar comentado agregar 
```c#
app.UseStatusCodePagesWithReExecute("/Error/{0}");
```
> Esto permitira redirigir a una pagina de error especificas segun el codigo de error que suceda, el ```{0}``` es remplazado durante la ejecucion por esto ultimo, logrando que se redirija al controlador ```Error``` y la accion marcada por esa ruta. Ejemplo "/Error/404", osea NotFound

16. Ya que no es valido que una accion se llame "404" o "500" se debe utilizar la anotacion ```[Route("...")]``` para no utilizar la convencion de ruta ***"/{controlador}/{accion}/{id?}"*** para esta accion del controlador. Para esto ir al controlador ```Error``` accion ```NotFoundError``` y agregar la anotacion ```[Route("/error/404")]```. Agregar una vista para esta accion, se debe ver como lo siguiente.

![image](https://user-images.githubusercontent.com/41701343/132452274-ee6732fb-6539-491a-b739-f95e07dd9f23.png)
    
<details close>
<summary>Ver Vista Completa</summary>

```html
<div class="page-wrap d-flex flex-row align-items-center">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <span class="display-1 d-block">404</span>
                <div class="mb-4 lead">Pagina no encontrada</div>
                <a asp-area="" asp-controller="Home" asp-action="Index" class="btn btn-link">Back to Home</a>
            </div>
        </div>
    </div>
</div>
```

</details>

17. Tener en cuenta que hay mas tipos de errores, por lo que en la accion ```GenericError(int code)``` agregar la anotacion correspondiente, teniendo en cuenta que en este tipo de anotaciones es posible parametrizar el string de parametro con lo siguiente "{code:int}", este code es justamente reflejado en el parametro del metodo.

18. En el proyecto ***Test*** clase ```IntegrationTestWeb``` ir a ***Prueba***/***Ejecutar todas las pruebas*** de la barra de herramientas de VS. Esto es para verificar que la implementación cumpla con las especificaciones requeridas. Por ejemplo para la accion ***/Materia/List***:
``` c#
[Fact]
public async Task VisitRootPage_ShouldRenderTwoMateriaCardsAndTheFirstOneMustHaveCertainCardSubtitle()
```
> Cada uno de estos test revisara el html enviado por cada accion de los controladores y chequeara que esten ciertos elementos previamente solicitados, como pueden ser las secciones de validacion o las opciones del select
