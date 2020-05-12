﻿using Entidades;
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
    public partial class FrmAltaAlumno : Form
    {
        public List<Responsable> listResponsables;
        public Alumno unAlumno;
        public int legajoAlumno;
        public FrmAltaAlumno()
        {
            InitializeComponent();
        }
        public FrmAltaAlumno(List<Responsable> responsables,int legajo):this()
        {
            listResponsables = responsables;
            legajoAlumno = legajo;
        }

        private void FrmAltaAlumno_Load(object sender, EventArgs e)
        {
            foreach (Responsable item in listResponsables)
            {
                listBoxResponsables.Items.Add($"{item.Nombre} {item.Apellido} - Parentesco: {item.Parentesco}");
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool sexo;
            if (Validaciones.ValidarString(txtNombre.Text) &&
                Validaciones.ValidarString(txtApellido.Text) &&
                Validaciones.ValidarString(txtDni.Text) &&
                Validaciones.ValidarString(cmbSexo.Text) &&
                Validaciones.ValidarString(numPrecio.Text) 
               )
            {
                if (this.listBoxResponsables.SelectedIndex != -1)
                {
                    if (Validaciones.ValidarFlotante(numPrecio.Text, 100000, 2500))
                    {
                        if (cmbSexo.Text == "Femenino")
                        {
                            sexo = true;
                        }
                        else
                        {
                            sexo = false;
                        }
                        unAlumno = new Alumno(txtNombre.Text, txtApellido.Text, int.Parse(txtDni.Text), sexo, float.Parse(numPrecio.Value.ToString()));
                        unAlumno.Responsable = this.listResponsables[listBoxResponsables.SelectedIndex];
                        unAlumno.Legajo = legajoAlumno;
                        legajoAlumno++;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("El precio minimo es de 2500 y maximo 100000");
                    }
                    
                }else
                {
                    MessageBox.Show("Debe seleccionar un responsable, porque llamamos a un asistente social para el NIÑE");
                }
               
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }//
}//
