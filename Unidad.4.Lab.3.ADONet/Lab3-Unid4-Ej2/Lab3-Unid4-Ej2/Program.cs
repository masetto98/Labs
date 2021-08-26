using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab3_Unid4_Ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAlumnos = new DataTable("Alumnos");

            DataColumn colIDAlumno = new DataColumn("IDAlumno", typeof(int));
            colIDAlumno.ReadOnly = true;
            colIDAlumno.AutoIncrement = true;
            colIDAlumno.AutoIncrementSeed = 0;
            colIDAlumno.AutoIncrementStep = 1;
            DataColumn colNombre = new DataColumn("Nombre", typeof(string));
            DataColumn colApellido = new DataColumn("Apellido", typeof(string));
            dtAlumnos.Columns.Add(colApellido);
            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colIDAlumno);
            dtAlumnos.PrimaryKey = new DataColumn[] { colIDAlumno };

            DataRow rwAlumno = dtAlumnos.NewRow();

            rwAlumno[colNombre] = "Juan";
            rwAlumno[colApellido] = "Perez";

            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2["Nombre"] = "Marcelo";
            rwAlumno2["Apellido"] = "Perez";
            dtAlumnos.Rows.Add(rwAlumno2);

            DataTable dtCursos = new DataTable("Cursos");

            
            DataColumn colIDCurso = new DataColumn("IDCurso", typeof(int));
            colIDCurso.ReadOnly = true;
            colIDCurso.AutoIncrement = true;
            colIDCurso.AutoIncrementSeed = 1;
            colIDCurso.AutoIncrementStep = 1;
            DataColumn colCurso = new DataColumn("Curso", typeof(string));
            dtCursos.Columns.Add(colCurso);
            dtCursos.Columns.Add(colIDCurso);
            dtCursos.PrimaryKey = new DataColumn[] { colIDCurso };

            DataRow rwCurso = dtCursos.NewRow();
            rwCurso[colCurso] = "Informatica";
            dtCursos.Rows.Add(rwCurso);

            DataSet dsUniversidad = new DataSet();
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);

            DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
            DataColumn col_ac_IDAlumno = new DataColumn("IDAlumno", typeof(int));
            DataColumn col_ac_IDCurso = new DataColumn("IDCurso", typeof(int));
            dtAlumnos_Cursos.Columns.Add(col_ac_IDCurso);
            dtAlumnos_Cursos.Columns.Add(col_ac_IDAlumno);

            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            DataRelation relAlumno_ac = new DataRelation("Alumnos_Cursos", colIDAlumno, col_ac_IDAlumno);
            DataRelation relCurso_ac = new DataRelation("Cursos_Alumnos", colIDCurso, col_ac_IDCurso);

            dsUniversidad.Relations.Add(relCurso_ac);
            dsUniversidad.Relations.Add(relAlumno_ac);

            DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDAlumno] = 0;
            rwAlumnosCursos[col_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            DataRow rwAlumnosCursos1 = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos1[col_ac_IDAlumno] = 1;
            rwAlumnosCursos1[col_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos1);

            Console.Write("Por favor ingrese el nombre del curso: ");
            string materia = Console.ReadLine();
            Console.WriteLine("Listado de alumnos del curso " + materia +": ");
            DataRow[] row_CursoInf = dtCursos.Select("Curso = '"+ materia + "'");
            foreach (DataRow rowCu in row_CursoInf)
            {
                DataRow[] row_AlumnosInf = rowCu.GetChildRows(relCurso_ac);
                foreach (DataRow rowAl in row_AlumnosInf)
                {
                    Console.WriteLine(rowAl.GetParentRow(relAlumno_ac)[colApellido].ToString()+ ", "+ rowAl.GetParentRow(relAlumno_ac)[colNombre].ToString());
                }
            }
            Console.ReadLine();

        }
    }
}
