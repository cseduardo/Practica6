using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Practica6
{
    public class TESHDatos
    {

        int matricula;
        string nombre;
        string ape_pat;
        string ape_mat;
        string calle;
        int num_calle;
        string colonia;
        int cod_postal;
        string municipio;
        string estado;
        string num_telefono;
        int carrera;
        int semestre;
        string email;
        string git;

            [PrimaryKey,MaxLength(8),Unique]
            public int Matricula
            {
                get { return matricula; }
                set { matricula = value; }
            }

            [MaxLength(50)]
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            [MaxLength(50),Column("Apellido Paterno")]
            public string Ape_Pat
            {
                get { return ape_pat; }
                set { ape_pat = value; }
            }
            [MaxLength(50),Column("Apellido Materno")]
            public string Ape_Mat
            {
                get { return ape_mat; }
                set { ape_mat = value; }
            }
            [MaxLength(35)]
            public string Calle
            {
                get { return calle; }
                set { calle = value; }
            }
            [MaxLength(4), Column("Numero de Calle")]
            public int Num_calle
            {
                get { return num_calle; }
                set { num_calle = value; }
            }
            [MaxLength(40)]
            public string Colonia
            {
                get { return colonia; }
                set { colonia = value; }
            }
            [MaxLength(5), Column("Codigo Postal")]
            public int Cod_Postal
            {
                get { return cod_postal; }
                set { cod_postal = value; }
            }
            [MaxLength(45)]
            public string Municipio
            {
                get { return municipio; }
                set { municipio = value; }
            }
            [MaxLength(45)]
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }
            [MaxLength(12)]
            public string Telefono
            {
                get { return num_telefono; }
                set { num_telefono = value; }
            }
            [MaxLength(15)]
            public int Carrera
            {
                get { return carrera; }
                set { carrera = value; }
            }
            [MaxLength(15)]
            public int Semestre
            {
                get { return semestre; }
                set { semestre = value; }
            }
            [MaxLength(40)]
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            [MaxLength(30)]
            public string Git
            {
                get { return git; }
                set { git = value; }
            }
        }
}
