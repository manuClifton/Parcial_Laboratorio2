using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Clifton.Manuel
{
    
    public partial class FrmAlumnos : Form
    {

        public List<Alumno> listAlumnosSinAula;
        public List<Alumno> listAlumnosConAula;

        public FrmAlumnos()
        {
            InitializeComponent();
            
        }

        public FrmAlumnos(List<Alumno> alumnosConAula) : this()
        {
            listAlumnosConAula = alumnosConAula;
            CargarConAula();
        }
        public FrmAlumnos(List<Alumno> alumnosSinAula, string s) : this()
        {
            listAlumnosSinAula = alumnosSinAula;

            CargarSinAula();
        }

        private void CargarConAula()
        {
            this.dataGridAlumnos.Rows.Clear();

            int fila = 0;
            foreach (Alumno Aux in listAlumnosConAula)
            {
                if (Aux.ColorSala != EColor.SinSala)
                {
                    fila = dataGridAlumnos.Rows.Add();
                    dataGridAlumnos.Rows[fila].Cells[0].Value = Aux.Nombre;
                    dataGridAlumnos.Rows[fila].Cells[1].Value = Aux.Apellido;
                    dataGridAlumnos.Rows[fila].Cells[2].Value = Aux.Dni;
                    if (Aux.Femenino)
                    {
                        dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                    }
                    else
                    {
                        dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                    }

                    dataGridAlumnos.Rows[fila].Cells[4].Value = Aux.PrecioCuota;
                    dataGridAlumnos.Rows[fila].Cells[5].Value = Aux.ColorSala;
                }
            }
        }

        private void CargarSinAula()
        {
            this.dataGridAlumnos.Rows.Clear();

            int fila = 0;
            foreach (Alumno Aux in listAlumnosSinAula)
            {
                if (Aux.ColorSala == EColor.SinSala)
                {
                    fila = dataGridAlumnos.Rows.Add();
                    dataGridAlumnos.Rows[fila].Cells[0].Value = Aux.Nombre;
                    dataGridAlumnos.Rows[fila].Cells[1].Value = Aux.Apellido;
                    dataGridAlumnos.Rows[fila].Cells[2].Value = Aux.Dni;
                    if (Aux.Femenino)
                    {
                        dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                    }
                    else
                    {
                        dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                    }

                    dataGridAlumnos.Rows[fila].Cells[4].Value = Aux.PrecioCuota;
                    dataGridAlumnos.Rows[fila].Cells[5].Value = Aux.ColorSala;
                }

            }
        }





















    }//
}//
