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
    public partial class btnAceptar : Form
    {
       private List<Docente> listDocentes;
       private List<Alumno> listAlumnosSinAula;
       private List<Alumno> listAlumnosConAula; // MODIFICAR A PRIVADO CUANDO REFACTORIZE AGREGAR ALUMNO CON AULA
       private List<Aula> listAulas;

        private Aula unAula;
        public btnAceptar()
        {
            InitializeComponent();
        }
        //public FrmAltaAula(List<Docente> docentes, List<Alumno> alumnosSinAula, List<Aula> aulas):this()
        //{
        //    listDocentes = docentes;
        //    listAlumnosSinAula = alumnosSinAula;
        //    listAlumnosConAula = new List<Alumno>();
        //    listAulas = aulas;
        //}
        public List<Docente> ListDocentes
        {
            get { return this.listDocentes; }
            set { this.listDocentes = value; }
        }
        public List<Alumno> ListAlumnosSinAula
        {
            get { return this.listAlumnosSinAula; }
            set { this.listAlumnosSinAula = value; }
        }
        public List<Alumno> ListAlumnosConAula
        {
            get { return this.listAlumnosConAula; }
            set { this.listAlumnosConAula = value; }
        }
        public List<Aula> ListAulas
        {
            get { return this.listAulas; }
            set { this.listAulas = value; }
        }
        public Aula UnAula
        {
            get { return this.unAula; }
            set { this.unAula = value; }
        }

        // CONSTRUCTOR CUANDO SE LE ASIGNA UN AULA PARA AGREGAR NIÑOS
        #region AGREGAR ALUMNOS A AULA EXISTENTE
        public btnAceptar(Aula aula)
        {
            unAula = aula;
            cmbColores.Text = unAula.ColorSala.ToString();    /// ACA ORMPRE NUL REFERENCIA DE AULA
            cmbColores.Enabled = false;
            cmbDocetes.Text = unAula.Docente.Nombre.ToString() + unAula.Docente.Apellido.ToString();
            cmbDocetes.Enabled = false;
            cmbTurno.Text = unAula.Turno.ToString();
            cmbTurno.Enabled = false;
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            string sexo = "";
            foreach (Alumno item in unAula.Alumnos)
            {
                if (item.Femenino)
                {
                    sexo = "Femenino";
                }
                else
                {
                    sexo = "Masculino";
                }
                listAlumnosEnSala.Items.Add($"{item.Nombre} {item.Apellido} {sexo}");
            }
        }
        #endregion

        private void FrmAltaAula_Load(object sender, EventArgs e)
        {
            if (unAula is null)
            {
                cmbTurno.DataSource = Enum.GetNames(typeof(ETurno));

                foreach (Docente doc in listDocentes)
                {
                    int contador = 0;
                    foreach (Aula aula in listAulas)
                    {
                        if (aula.Turno == ETurno.Mañana && doc.Dni == aula.Docente.Dni)
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
            else
            {
                // Completar Cuando El aula nos sea NULL para agregar alumnos
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(unAula is null))
            {//REVISAR

                //EColor color = EColor.SinSala;
                //switch (cmbColores.Text)
                //{
                //    case "Naranja":
                //        color = EColor.Naranja;
                //        break;
                //    case "Rojo":
                //        color = EColor.Rojo;
                //        break;
                //    case "Amarillo":
                //        color = EColor.Amarillo;
                //        break;
                //    case "Verde":
                //        color = EColor.Verde;
                //        break;
                //    default:
                //        break;
                //}

                //bool existe = false;
                //bool existe2 = false;


                ////unAula = new Aula(color, this.listDocentes[this.cmbDocetes.SelectedIndex], (ETurno)cmbTurno.SelectedIndex);

                //foreach (Aula item in listAulas)
                //{

                //    if (item.ColorSala == unAula.ColorSala && item.Turno == unAula.Turno )
                //    {
                //        existe = true;
                //        unAula = null;
                //        break;
                //    }else if ( ( item.ColorSala == EColor.Amarillo || item.ColorSala == EColor.Naranja || item.ColorSala == EColor.Rojo || item.ColorSala == EColor.Verde) && item.Turno == unAula.Turno && item.Docente.Dni == unAula.Docente.Dni)
                //    {
                //        existe2 = true;
                //        unAula = null;
                //        break;
                //    }
                //}

                //if (!existe && !existe2)
                //{
                //    // aca esta el error le estoy sumando a el aula todos los alumnos que ya tienen aula asignada ///////////////////////////////////////////////////////////////
                //    foreach (Alumno item in listAlumnosConAula)
                //    {
                //        if (unAula + item) 
                //        {
                //        } 
                //    }

                    //for (int i = 0; i < listAlumnosSinAula.Count; i++)
                    //{
                    //    if (listAlumnosSinAula[i].ColorSala != EColor.SinSala)
                    //    {
                    //        listAlumnosSinAula.Remove(listAlumnosSinAula[i]);
                    //        i -= 1;
                    //    }
                    //}


                    this.DialogResult = DialogResult.OK;
            
                }
           //  else if (!existe && existe2)
            //    {
            //        MessageBox.Show("EL DOCENTE NO PUEDE ESTAR EN DOS AULAS EN EL MISMO TURNO.");
            //        cmbColores.Enabled = true;
            //        cmbDocetes.Enabled = true;
            //        cmbTurno.Enabled = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("YA EXISTE UN AULA CON ESAS CARACTERISTICAS.");
            //        //MessageBox.Show("Ya existe un aula de ese color en el mismo horario.\nCambia el color de la sala o el horario del turno.\n PD: NO ME ROMPAS SOY MUY FRAGIL");

            //        cmbColores.Enabled = true;
            //        cmbDocetes.Enabled = true;
            //        cmbTurno.Enabled = true;
            //    }
                
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar todas las opciones Y una sala correcta");
            //}
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
            if (listAlumnosSinSala.SelectedIndex != -1)
            {
                listAlumnosEnSala.DoDragDrop(listAlumnosSinSala.SelectedItem.ToString(), DragDropEffects.All);
            }
            
        }

        private void listAlumnosEnSala_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

            if (!(cmbColores.SelectedIndex == -1) && !(cmbDocetes.SelectedIndex == -1) && !(cmbTurno.SelectedIndex == -1))
            {
                if (unAula is null)
                {
                    cmbColores.Enabled = false;
                    cmbDocetes.Enabled = false;
                    cmbTurno.Enabled = false;

                    EColor color = EColor.SinSala;
                    switch (cmbColores.Text)
                    {
                        case "Naranja":
                            color = EColor.Naranja;
                            break;
                        case "Rojo":
                            color = EColor.Rojo;
                            break;
                        case "Amarillo":
                            color = EColor.Amarillo;
                            break;
                        case "Verde":
                            color = EColor.Verde;
                            break;
                        default:
                            break;
                    } 
                    unAula = new Aula(color, this.listDocentes[this.cmbDocetes.SelectedIndex], (ETurno)cmbTurno.SelectedIndex);

                    bool existe = false;
                    bool existe2 = false;

                    foreach (Aula item in listAulas)
                    {

                        if (item.ColorSala == unAula.ColorSala && item.Turno == unAula.Turno)
                        {
                            existe = true;
                            unAula = null;
                            break;
                        }
                        else if ((item.ColorSala == EColor.Amarillo || item.ColorSala == EColor.Naranja || item.ColorSala == EColor.Rojo || item.ColorSala == EColor.Verde) && item.Turno == unAula.Turno && item.Docente.Dni == unAula.Docente.Dni)
                        {
                            existe2 = true;
                            unAula = null;
                            break;
                        }
                    }
                    if (existe)
                    {
                        MessageBox.Show("YA EXISTE AULA DE ESE COLOR Y TURNO");
                        cmbColores.Enabled = true;
                        cmbDocetes.Enabled = true;
                        cmbTurno.Enabled = true;
                    }
                    else if (existe2)
                    {
                        MessageBox.Show($"DOCENTE NO DISPONILE EN TURNO {cmbTurno.Text}");
                        cmbColores.Enabled = true;
                        cmbDocetes.Enabled = true;
                        cmbTurno.Enabled = true;
                    }
                }//FIN DE IF

                if (!(unAula is null))
                {
                    cmbColores.Enabled = false;
                    cmbDocetes.Enabled = false;
                    cmbTurno.Enabled = false;

                    if (!(listAlumnosEnSala.Items.Contains(listAlumnosSinSala.SelectedItem)))
                    {
                        if (listAlumnosEnSala.Items.Count < 30)
                        {
                            listAlumnosEnSala.Items.Add(e.Data.GetData(DataFormats.Text));


                            this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex].ColorSala = (EColor)cmbColores.SelectedIndex;
                            if (unAula + this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex])
                            {
                                this.listAlumnosConAula.Add(this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex]);
                                this.listAlumnosSinAula.Remove(this.listAlumnosSinAula[listAlumnosSinSala.SelectedIndex]);
                            }
                            else
                            {
                                MessageBox.Show("NO SE PUDO SUMAR ALUMNO");
                            }

                        }
                        else
                        {
                            MessageBox.Show("EL AULA YA TIENE NO TIENE CAPACIDAD. MAXIMO 30 ALUMNOS.");
                        }
                    }
                    else
                    {
                        //listAlumnosEnSala.Items.Remove(this.listAlumnosSinSala.SelectedItem);
                        MessageBox.Show("SELECCIONA UN ALUMNO QUE NO SE ENCUENTRE EN LA SALA");
                    }

                }
                
            }
            else
            {
               // listAlumnosEnSala.Items.Remove(this.listAlumnosSinSala.SelectedItem);
                MessageBox.Show("PRIMERO SELECCIONA CORRECTAMENTE UN COLOR, TURNO Y DOCENTE");
            }




        }

        /// <summary>
        /// Cambia el color de fondo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColores.Text) // esto ponerlo en el evento del cmbColor cuando elegis un color
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
