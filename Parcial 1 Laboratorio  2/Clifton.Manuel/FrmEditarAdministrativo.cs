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
    public partial class FrmEditarAdministrativo : Form
    {
        List<Administrativo> listAdministrativos;
        List<Docente> listDocentes;

        Administrativo unAdministrativo;
        Administrativo eliminarAdministrativo;

        public FrmEditarAdministrativo()
        {
            unAdministrativo = new Administrativo();
            InitializeComponent();
        }

        public List<Administrativo> ListAdministrativo
        {
            get { return this.listAdministrativos; }
            set { this.listAdministrativos = value; }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            //TERMINAR EDICION
        }

        private void FrmEditarAdministrativo_Load(object sender, EventArgs e)
        {
            //TERMINAR EDICION
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        // /////////////////////////////// FALTA AGREGAR BUSCADOR POR APELLIDO DNI Y DEMAS. LUEGO HACER LOS CAMBIOS Y GUARDAR
        private bool flag = false;
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text);
            txtNombre.SelectionStart = txtNombre.Text.Length;
            if (flag == false)
            {
                this.dataGridNoDocente.Rows.Clear();
                int fila = 0;
                foreach (Administrativo item in listAdministrativos)
                {
                    if (item.Nombre.Contains(txtNombre.Text))
                    {
                        fila = dataGridNoDocente.Rows.Add();
                        dataGridNoDocente.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridNoDocente.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridNoDocente.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridNoDocente.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridNoDocente.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridNoDocente.Rows[fila].Cells[4].Value = item.Entrada;
                        dataGridNoDocente.Rows[fila].Cells[5].Value = item.Salida;
                        dataGridNoDocente.Rows[fila].Cells[6].Value = item.Cargo;
                    }
                }

                if (txtNombre.Text == string.Empty)
                {
                    this.dataGridNoDocente.Rows.Clear();
                }
            }
        }



    }//
}//
