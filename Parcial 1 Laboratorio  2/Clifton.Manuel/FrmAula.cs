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
    public partial class FrmAula : Form
    {
        FrmAlumnosPorAula instAlumosXAula;
        List<Aula> listAulas;
 

        public FrmAula()
        {
            InitializeComponent();
        }

        public FrmAula(List<Aula> aulas) : this()
        {
            listAulas = aulas;
            CargarTabla();
        }

        private void CargarTabla()
        {
            this.dataGridAula.Rows.Clear();
            int fila = 0;
            foreach (Aula Aux in listAulas)
            {
                fila = dataGridAula.Rows.Add();
                dataGridAula.Rows[fila].Cells[0].Value = Aux.ColorSala;
                dataGridAula.Rows[fila].Cells[1].Value = $"{Aux.Docente.Nombre} {Aux.Docente.Apellido}";
                dataGridAula.Rows[fila].Cells[2].Value = Aux.Turno;
            }

        }

    }//
}//
