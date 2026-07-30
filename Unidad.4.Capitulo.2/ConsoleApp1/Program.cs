using ConsoleApp1;

Console.WriteLine("--- Iniciando Laboratorio de Entity Framework Core ---");

// Ejecución del flujo principal (Paso 6)
CrearAlumno();
LeerAlumno();
ActualizarAlumno();
//EliminarAlumno();

Console.WriteLine("--- Operaciones finalizadas exitosamente ---");
Console.ReadLine();

// -----------------------------------------------------------
// Definición de Métodos CRUD (Paso 5)
// -----------------------------------------------------------

// a) Crear
static void CrearAlumno()
{
    Console.WriteLine("\n>>> Ejecutando CREAR...");
    using (var context = new UniversidadContext())
    {
        var nuevoAlumno = new Alumno
        {
            Nombre = "Juan",
            Apellido = "Pérez",
            Legajo = 12345,
            Direccion = "Calle Falsa 123"
        };

        context.Alumnos.Add(nuevoAlumno);
        context.SaveChanges();
        Console.WriteLine("Alumno creado y guardado en la base de datos.");
    }
}

// b) Leer
static void LeerAlumno()
{
    Console.WriteLine("\n>>> Ejecutando LEER...");
    using (var context = new UniversidadContext())
    {
        var alumno = context.Alumnos.FirstOrDefault(a => a.Legajo == 12345);
        if (alumno != null)
        {
            Console.WriteLine($"Alumno recuperado: {alumno.Nombre} {alumno.Apellido}, Dirección: {alumno.Direccion}");
        }
        else
        {
            Console.WriteLine("Alumno no encontrado.");
        }
    }
}

// c) Actualizar
static void ActualizarAlumno()
{
    Console.WriteLine("\n>>> Ejecutando ACTUALIZAR...");
    using (var context = new UniversidadContext())
    {
        var alumno = context.Alumnos.FirstOrDefault(a => a.Legajo == 12345);
        if (alumno != null)
        {
            alumno.Direccion = "Avenida Siempreviva 742";
            context.SaveChanges();
            Console.WriteLine("Dirección del alumno actualizada.");
        }
    }
}

// d) Eliminar
static void EliminarAlumno()
{
    Console.WriteLine("\n>>> Ejecutando ELIMINAR...");
    using (var context = new UniversidadContext())
    {
        var alumno = context.Alumnos.FirstOrDefault(a => a.Legajo == 12345);
        if (alumno != null)
        {
            context.Alumnos.Remove(alumno);
            context.SaveChanges();
            Console.WriteLine("Alumno eliminado de la base de datos.");
        }
    }
}