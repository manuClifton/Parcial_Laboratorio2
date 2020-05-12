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
using System.IO;

namespace Clifton.Manuel
{
    public partial class FrmAltaAula : Form
    {
       public List<Docente> listDocentes;
       public List<Alumno> listAlumnosSinAula;
       public List<Alumno> listAlumnosConAula;
        public List<Aula> listAulas;

        public Aula unAula;
        public FrmAltaAula()
        {
            InitializeComponent();
        }
        public FrmAltaAula(List<Docente> docentes, List<Alumno> alumnosSinAula, List<Aula> aulas):this()
        {
            listDocentes = docentes;
            listAlumnosSinAula = alumnosSinAula;
            listAlumnosConAula = new List<Alumno>();
            listAulas = aulas;
        }

        private void FrmAltaAula_Load(object sender, EventArgs e)
        {
            cmbTurno.DataSource = Enum.GetNames(typeof(ETurno));

            foreach (Docente doc in listDocentes)
            {
                int contador = 0;
                foreach (Aula aula in listAulas)
                {
                    if (aula.Turno == ETurno.Mañana  && doc.Dni == aula.Docente.Dni)
                    {
                        contador++;
                    }
                    if (aula.Turno == ETurno.Tarde && doc.Dni == aula.Docente.Dni)
                    {
                        contador++;
                    }
                    
                }
                if (contador < 2)
                {
                    cmbDocetes.Items.Add($"{doc.Nombre} {doc.Apellido}");
                }
            }



            string sexo = "";
            foreach (Alumno item in listAlumnosSinAula)
            {
                if (item.ColorSala == EColor.SinSala)
                {
                    if (item.Femenino)
                    {
                        sexo = "Femenino";
                    }
                    else
                    {
                        sexo = "Masculino";
                    }
                    listAlumnosSinSala.Items.Add($"{item.Nombre} {item.Apellido} {sexo}");
                }
               
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(cmbColores.SelectedIndex == -1) && cmbColores.Text != "SinSala" && !(cmbDocetes.SelectedIndex == -1) && !(cmbTurno.SelectedIndex == -1))
            {//REVISAR
                bool existe = false;
                bool existe2 = false;
                unAula = new Aula((EColor)cmbColores.SelectedIndex, this.listDocentes[this.cmbDocetes.SelectedIndex], (ETurno)cmbTurno.SelectedIndex);
                foreach (Aula item in listAulas)
                {

                    if (item.ColorSala == unAula.ColorSala && item.Turno == unAula.Turno )
                    {
                        existe = true;
                        unAula = null;
                        break;
                    }else if ( ( item.ColorSala == EColor.Amarillo || item.ColorSala == EColor.Naranja || item.ColorSala == EColor.Rojo || item.ColorSala == EColor.Verde) && item.Turno == unAula.Turno && item.Docente.Dni == unAula.Docente.Dni)
                    {
                        existe2 = true;
                        unAula = null;
                        break;
                    }
                    
                }

                if (!existe && !existe2)
                {
                    foreach (Alumno item in listAlumnosConAula)
                    {
                        if (unAula + item) 
                        {
                        } 
                    }

                    for (int i = 0; i < listAlumnosSinAula.Count; i++)
                    {
                        if (listAlumnosSinAula[i].ColorSala != EColor.SinSala)
                        {
                            listAlumnosSinAula.Remove(listAlumnosSinAula[i]);
                            i -= 1;
                        }
                    }


                    this.DialogResult = DialogResult.OK;
                }else if (!existe && existe2)
                {
                    MessageBox.Show("EL DOCENTE NO PUEDE ESTAR EN DOS AULAS EN EL MISMO TURNO.\n       ¿¿O SI??  (ツ)  ◕ ◡ ◕ ");
                    cmbColores.Enabled = true;
                    cmbDocetes.Enabled = true;
                    cmbTurno.Enabled = true;
                }
                else
                {
                    MessageBox.Show("YA EXISTE UN AULA CON ESAS CARACTERISTICAS\n         ¯|_(ツ)_/¯");
                    //MessageBox.Show("Ya existe un aula de ese color en el mismo horario.\nCambia el color de la sala o el horario del turno.\n PD: NO ME ROMPAS SOY MUY FRAGIL");

                    cmbColores.Enabled = true;
                    cmbDocetes.Enabled = true;
                    cmbTurno.Enabled = true;
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar todas las opciones Y una sala correcta");
            }
        }

        private void pictureSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void listAlumnosSinSala_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                listAlumnosSinSala.Items.Add(file);
            }
        }



        private void listAlumnosSinSala_MouseDown(object sender, MouseEventArgs e)
        {
            // listAlumnosSinSala.SelectedItem.ToString();
            listAlumnosEnSala.DoDragDrop(listAlumnosSinSala.SelectedItem.ToString(), DragDropEffects.All);
        }

        private void listAlumnosEnSala_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;



            if (!(cmbColores.SelectedIndex == -1) && cmbColores.Text != "SinSala" && !(cmbDocetes.SelectedIndex == -1) && !(cmbTurno.SelectedIndex == -1))
            {
                cmbColores.Enabled = false;
                cmbDocetes.Enabled = false;
                cmbTurno.Enabled = false;
                switch (cmbColores.Text)
                {
                    case "Naranja":
                        this.BackColor = Color.Orange;
                        break;
                    case "Rojo":
                        this.BackColor = Color.Red;
                        break;
                    case "Amarillo":
                        this.BackColor = Color.Yellow;
                        break;
                    case "Verde":
                        this.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }


                if (!(listAlumnosEnSala.Items.Contains(listAlumnosSinSala.SelectedItem)) && listAlumnosEnSala.Items.Count < 30)
                {
                    listAlumnosEnSala.Items.Add(e.Data.GetData(DataFormats.Text));
                    
                    this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex].ColorSala = (EColor)cmbColores.SelectedIndex;

                    this.listAlumnosConAula.Add(this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex]);

                //this.listAlumnosSinAula.Remove(this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex]);
                //listAlumnosSinSala.Items.Remove(this.listAlumnosSinSala.SelectedItem);
                }
                else
                {
                    //listAlumnosEnSala.Items.Remove(this.listAlumnosSinSala.SelectedItem);
                    MessageBox.Show("SISTEMA A PRUEBA DE MANCOS.. SELECCIONA UN ALUMNO QUE NO SE ENCUENTRE EN LA SALA");
                }

            }
            else
            {
                listAlumnosEnSala.Items.Remove(this.listAlumnosSinSala.SelectedItem);
                MessageBox.Show("PRIMERO SELECCIONA LOS CAMPOS 1 ,2 ,3 y una sala correcta");
            }
            
            
            
        }
    }
}
