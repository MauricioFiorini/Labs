using System;
using System.Data;

namespace Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear el DataSet principal
            DataSet dsUniversidad = new DataSet("dsUniversidad");

            // ==========================================
            // 2. Crear Tabla Alumnos (dtAlumnos)
            // ==========================================
            DataTable dtAlumnos = new DataTable("dtAlumnos");

            DataColumn colIDAlumno = new DataColumn("IDAlumno", typeof(int));
            colIDAlumno.AutoIncrement = true;
            colIDAlumno.AutoIncrementSeed = 0;
            colIDAlumno.AutoIncrementStep = 1;

            dtAlumnos.Columns.Add(colIDAlumno);
            dtAlumnos.Columns.Add("Nombre", typeof(string));
            dtAlumnos.Columns.Add("Apellido", typeof(string));

            // Establecer Primary Key
            dtAlumnos.PrimaryKey = new DataColumn[] { colIDAlumno };

            // ==========================================
            // 3. Crear Tabla Cursos (dtCursos)
            // ==========================================
            DataTable dtCursos = new DataTable("dtCursos");

            DataColumn colIDCurso = new DataColumn("IDCurso", typeof(int));
            colIDCurso.AutoIncrement = true;
            colIDCurso.AutoIncrementSeed = 1; // El lab indica que Informatica es 1
            colIDCurso.AutoIncrementStep = 1;

            dtCursos.Columns.Add(colIDCurso);
            dtCursos.Columns.Add("Curso", typeof(string));

            dtCursos.PrimaryKey = new DataColumn[] { colIDCurso };

            // ==========================================
            // 4. Crear Tabla Intermedia (dtAlumnos_Cursos)
            // ==========================================
            DataTable dtAlumnos_Cursos = new DataTable("dtAlumnos_Cursos");
            dtAlumnos_Cursos.Columns.Add("col_ac_IDAlumno", typeof(int));
            dtAlumnos_Cursos.Columns.Add("col_ac_IDCurso", typeof(int));

            // ==========================================
            // 5. Agregar Tablas al DataSet y Crear Relaciones
            // ==========================================
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);
            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            DataRelation relAlumnos = new DataRelation("relAlumnos_Cursos",
                dtAlumnos.Columns["IDAlumno"],
                dtAlumnos_Cursos.Columns["col_ac_IDAlumno"]);

            DataRelation relCursos = new DataRelation("relCursos_Alumnos",
                dtCursos.Columns["IDCurso"],
                dtAlumnos_Cursos.Columns["col_ac_IDCurso"]);

            dsUniversidad.Relations.Add(relAlumnos);
            dsUniversidad.Relations.Add(relCursos);

            // ==========================================
            // 6. Insertar Datos de Prueba
            // ==========================================
            // Agregar Alumno
            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno["Nombre"] = "Juan";
            rwAlumno["Apellido"] = "Perez";
            dtAlumnos.Rows.Add(rwAlumno);
            // Nota: IDAlumno será 0 automáticamente

            // Agregar Curso
            DataRow rwCurso = dtCursos.NewRow();
            rwCurso["Curso"] = "Informatica";
            dtCursos.Rows.Add(rwCurso);
            // Nota: IDCurso será 1 automáticamente

            // Asociar Alumno (0) con Curso (1)
            DataRow rwAsociacion = dtAlumnos_Cursos.NewRow();
            rwAsociacion["col_ac_IDAlumno"] = 0;
            rwAsociacion["col_ac_IDCurso"] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAsociacion);

            // ==========================================
            // 7. Mostrar Resultados en Consola
            // ==========================================
            Console.WriteLine("=== Listado de Alumnos y Cursos ===");

            foreach (DataRow rowAC in dtAlumnos_Cursos.Rows)
            {
                int idAlumno = (int)rowAC["col_ac_IDAlumno"];
                int idCurso = (int)rowAC["col_ac_IDCurso"];

                // Buscar los datos reales usando las relaciones
                DataRow dataAlumno = dtAlumnos.Rows.Find(idAlumno);
                DataRow dataCurso = dtCursos.Rows.Find(idCurso);

                Console.WriteLine($"Alumno: {dataAlumno["Apellido"]}, {dataAlumno["Nombre"]} - Curso: {dataCurso["Curso"]}");
            }

            Console.ReadLine();
        }
    }
}