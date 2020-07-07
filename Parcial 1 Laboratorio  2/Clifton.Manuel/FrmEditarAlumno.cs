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
    public partial class FrmEditarAlumno : Form
    {

        private List<Alumno> listAlumnosConAula;
        private List<Alumno> listAlumnosSinAula;
        private List<Responsable> listResponsables;
        private List<Aula> listAulas;

        private Alumno unAlumno;
        private Alumno eliminarAlumno;

        public FrmEditarAlumno()
        {
            InitializeComponent();
            unAlumno = new Alumno();
            //eliminarAlumno = new Alumno();
        }

        public List<Alumno> ListAlumnosConAula
        {
            get { return this.listAlumnosConAula; }
            set { this.listAlumnosConAula = value; }
        }
        public List<Alumno> ListAlumnosSinAula
        {
            get { return this.listAlumnosSinAula; }
            set { this.listAlumnosSinAula = value; }
        }
        public List<Responsable> ListResponsables
        {
            get { return this.listResponsables; }
            set { this.listResponsables = value; }
        }
        public List<Aula> ListAulas
        {
            get { return this.listAulas; }
            set { this.listAulas = value; }
        }

        private void FrmEditar_Load(object sender, EventArgs e)
        {
            foreach (Responsable item in ListResponsables)
            {
                cmbResponsable.Items.Add($"{item.Nombre}, {item.Apellido}");
            }
            Lb_Editar.Text = "Editar Alumno";
            btnEditarAlumno.Enabled = false;
            dataGridAlumnos.ReadOnly = true;
            dataGridAlumnos.AllowUserToAddRows = false;
        }

        private void btnEditarAlumno_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                unAlumno.Nombre = txtNombre.Text;
                unAlumno.Apellido = txtApellido.Text;
                unAlumno.Dni = int.Parse(txtDni.Text);
                unAlumno.PrecioCuota = float.Parse(txtImporte.Text);

                if (cmbResponsable.SelectedIndex != -1)
                {
                    for (int i = 0; i < ListResponsables.Count; i++)
                    {
                        if (cmbResponsable.SelectedIndex == i)
                        {
                            unAlumno.Responsable = ListResponsables[i];
                        }
                    }
                }

                if (unAlumno.ColorSala == EColor.SinSala)
                {
                    // ListAlumnosSinAula.RemoveAt(indiceAlumno);
                    //listAlumnosSinAula.Insert(indiceAlumno, unAlumno);
                    ListAlumnosSinAula.Remove(eliminarAlumno);
                    ListAlumnosSinAula.Add(unAlumno);
                }
                else
                {
                    // listAlumnosConAula.RemoveAt(indiceAlumno);
                    // listAlumnosConAula.Insert(indiceAlumno, unAlumno);
                    listAlumnosConAula.Remove(eliminarAlumno);
                    listAlumnosConAula.Add(unAlumno);

                    foreach (Aula item in ListAulas)
                    {
                        for (int i = 0; i < item.Alumnos.Count; i++)
                        {
                            if (item.Alumnos[i] == eliminarAlumno)
                            {
                                item.Alumnos[i] = unAlumno;
                            }
                        }
                    }
                }

                MessageBox.Show("Se Edito el Alumno correctamente");
                DialogResult = DialogResult.OK;
            }
        }

        //  int indiceAlumno = 0;
        private void dataGridAlumnos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            flag = true;
            // int index = 0;

            cmbResponsable.SelectedIndex = -1;
            cmbResponsable.Text = "";

            txtNombre.Text = dataGridAlumnos.Rows[dataGridAlumnos.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txtApellido.Text = dataGridAlumnos.Rows[dataGridAlumnos.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtDni.Text = dataGridAlumnos.Rows[dataGridAlumnos.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txtImporte.Text = dataGridAlumnos.Rows[dataGridAlumnos.CurrentCell.RowIndex].Cells[4].Value.ToString();

            foreach (Alumno item in ListAlumnosConAula)
            {
                if (item.Dni == int.Parse(txtDni.Text))
                {
                    unAlumno.Nombre = item.Nombre;
                    unAlumno.Apellido = item.Apellido;
                    unAlumno.Dni = item.Dni;
                    unAlumno.ColorSala = item.ColorSala;
                    unAlumno.Responsable = item.Responsable ;
                    unAlumno.Legajo = item.Legajo;
                    unAlumno.Femenino = item.Femenino;
                    unAlumno.PrecioCuota = item.PrecioCuota;

                    eliminarAlumno = item;
                    // indiceAlumno = index;
                    //   index = 0;
                    break;
                }
                // index++;
            }

            foreach (Alumno item in ListAlumnosSinAula)
            {
                if (item.Dni == int.Parse(txtDni.Text))
                {
                    unAlumno.Nombre = item.Nombre;
                    unAlumno.Apellido = item.Apellido;
                    unAlumno.Dni = item.Dni;
                    unAlumno.ColorSala = item.ColorSala;
                    unAlumno.Responsable = item.Responsable;
                    unAlumno.Legajo = item.Legajo;
                    unAlumno.Femenino = item.Femenino;
                    unAlumno.PrecioCuota = item.PrecioCuota;

                    eliminarAlumno = item;
                    //  indiceAlumno = index;
                    //index = 0;
                    break;
                }
                //index++;
            }


            txtResponsable.Text = $"{unAlumno.Responsable.Nombre} { unAlumno.Responsable.Apellido}";

            btnEditarAlumno.Enabled = true;

            //REVISAR ESTA PARTE. COMO AGREGAR EL RESPONSABLE DEL ALUMNO SELECCIONADO AL CMB
            //for (int i = 0; i < ListResponsables.Count; i++)
            //{
            //    if (!(unAlumno.Responsable is null))
            //    {
            //        if (unAlumno.Responsable.Dni == ListResponsables[i].Dni)
            //        {
            //            break;
            //        }
            //    }
            //}
        }

        private bool flag = false;
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text);
            txtNombre.SelectionStart = txtNombre.Text.Length;
            if (flag == false)
            {
                this.dataGridAlumnos.Rows.Clear();
                int fila = 0;
                foreach (Alumno item in listAlumnosConAula)
                {
                    if (item.Nombre.Contains(txtNombre.Text))
                    {
                        fila = dataGridAlumnos.Rows.Add();
                        dataGridAlumnos.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridAlumnos.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridAlumnos.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridAlumnos.Rows[fila].Cells[4].Value = item.PrecioCuota;
                        dataGridAlumnos.Rows[fila].Cells[5].Value = item.ColorSala;
                    }
                }
                foreach (Alumno item in listAlumnosSinAula)
                {
                    if (item.Nombre.Contains(txtNombre.Text))
                    {
                        fila = dataGridAlumnos.Rows.Add();
                        dataGridAlumnos.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridAlumnos.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridAlumnos.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridAlumnos.Rows[fila].Cells[4].Value = item.PrecioCuota;
                        dataGridAlumnos.Rows[fila].Cells[5].Value = item.ColorSala;
                    }
                }

                if (txtNombre.Text == string.Empty)
                {
                    this.dataGridAlumnos.Rows.Clear();
                }
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text);
            txtApellido.SelectionStart = txtApellido.Text.Length;
            if (flag == false)
            {
                this.dataGridAlumnos.Rows.Clear();
                int fila = 0;
                foreach (Alumno item in listAlumnosConAula)
                {
                    if (item.Apellido.Contains(txtApellido.Text))
                    {
                        fila = dataGridAlumnos.Rows.Add();
                        dataGridAlumnos.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridAlumnos.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridAlumnos.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridAlumnos.Rows[fila].Cells[4].Value = item.PrecioCuota;
                        dataGridAlumnos.Rows[fila].Cells[5].Value = item.ColorSala;
                    }
                }
                foreach (Alumno item in listAlumnosSinAula)
                {
                    if (item.Apellido.Contains(txtApellido.Text))
                    {
                        fila = dataGridAlumnos.Rows.Add();
                        dataGridAlumnos.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridAlumnos.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridAlumnos.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridAlumnos.Rows[fila].Cells[4].Value = item.PrecioCuota;
                        dataGridAlumnos.Rows[fila].Cells[5].Value = item.ColorSala;
                    }
                }

                if (txtApellido.Text == string.Empty)
                {
                    this.dataGridAlumnos.Rows.Clear();
                }
            }
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (flag == false)
            {
                this.dataGridAlumnos.Rows.Clear();
                int fila = 0;
                foreach (Alumno item in listAlumnosConAula)
                {
                    if (item.Dni.ToString().Contains(txtDni.Text))
                    {
                        fila = dataGridAlumnos.Rows.Add();
                        dataGridAlumnos.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridAlumnos.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridAlumnos.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridAlumnos.Rows[fila].Cells[4].Value = item.PrecioCuota;
                        dataGridAlumnos.Rows[fila].Cells[5].Value = item.ColorSala;
                    }
                }
                foreach (Alumno item in listAlumnosSinAula)
                {
                    if (item.Dni.ToString().Contains(txtDni.Text))
                    {
                        fila = dataGridAlumnos.Rows.Add();
                        dataGridAlumnos.Rows[fila].Cells[0].Value = item.Nombre;
                        dataGridAlumnos.Rows[fila].Cells[1].Value = item.Apellido;
                        dataGridAlumnos.Rows[fila].Cells[2].Value = item.Dni;
                        if (item.Femenino)
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Femenino";
                        }
                        else
                        {
                            dataGridAlumnos.Rows[fila].Cells[3].Value = "Masculino";
                        }
                        dataGridAlumnos.Rows[fila].Cells[4].Value = item.PrecioCuota;
                        dataGridAlumnos.Rows[fila].Cells[5].Value = item.ColorSala;
                    }
                }

                if (txtDni.Text == string.Empty)
                {
                    this.dataGridAlumnos.Rows.Clear();
                }
            }
        }

       
 

        private bool ValidarCampos()
        {
            if (Validaciones.ValidarString(txtApellido.Text) &&
                Validaciones.ValidarString(txtNombre.Text)   &&
                Validaciones.ValidarString(txtDni.Text)      &&
                Validaciones.ValidarString(txtImporte.Text)  &&
                Validaciones.ValidarString(txtResponsable.Text))
            {
                if (Validaciones.ValidarStringSoloLetras(txtNombre.Text) &&
                    Validaciones.ValidarStringSoloLetras(txtApellido.Text))
                {
                    if (Validaciones.ValidarStringSoloNumeros(txtImporte.Text) &&
                        Validaciones.ValidarFlotante(txtImporte.Text, 100000, 2499))
                    {
                        if (Validaciones.ValidarStringSoloNumeros(txtDni.Text) &&
                            (Convert.ToInt64(txtDni.Text) >= 1000000 && Convert.ToInt64(txtDni.Text) <= 99999999))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("DNI Invalido");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Importe Invalido");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Nombre o Apellido mal escritos, solo debe contener letras.");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Todos los cambos deben estar completos.");
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResponsable.Text = cmbResponsable.Text;
        }


    }
}
