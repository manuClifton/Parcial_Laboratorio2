using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clifton.Manuel
{
    public partial class FrmSueldos : Form
    {
        List<Docente> listDocentes;
        List<Administrativo> listNoDocentes;
        List<Alumno> listAlumnos;
        List<Alumno> listalumnos2;

        double acumuladorDocente = 0;
        double acumuladorNoDocente = 0;
        float acumularoAlumnos = 0;
        float acumularoAlumnos2 = 0;

        public FrmSueldos()
        {
            InitializeComponent();

        }

        public FrmSueldos(List<Docente> docentes):this()
        {
            listDocentes = docentes;
            foreach (Docente item in listDocentes)
            {
                acumuladorDocente += item.Salario;
            }
            Lb_SueldoTotal.Text = acumuladorDocente.ToString();
            Lb_texto.Text = "Salario total de docentes: ";
            this.Text = "Salario de Docentes";
        }

        public FrmSueldos(List<Administrativo> noDocentes):this()
        {
            listNoDocentes = noDocentes;
            foreach (Administrativo item in listNoDocentes)
            {
                acumuladorNoDocente += item.Salario;
            }
            Lb_SueldoTotal.Text = acumuladorNoDocente.ToString();
            Lb_texto.Text = "Salario total de Administrativos: ";
            this.Text = "Salario de Administrativos";
        }

        public FrmSueldos(List<Alumno> alumnos1, List<Alumno> alumnos2) : this()
        {
            listAlumnos = alumnos1;
            listalumnos2 = alumnos2;

            foreach (Alumno item in listAlumnos)
            {
                acumularoAlumnos += item.PrecioCuota;
            }

            foreach (Alumno item in listalumnos2)
            {
                acumularoAlumnos2 = (acumularoAlumnos2 + item.PrecioCuota);
            }
            Lb_texto.Text = "Recaudacion total del Jardin";
            Lb_SueldoTotal.Text = (acumularoAlumnos + acumularoAlumnos2).ToString();
            this.Text = "Recaudacion";
        }


    }//
}//
