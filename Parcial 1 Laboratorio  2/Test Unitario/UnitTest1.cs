using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Clifton.Manuel;

namespace Test_Unitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(PersonaInvalidaException))]
        public void PersonaSinDniValido()
        {
            Alumno a1 = new Alumno("Pepe", "Pompin", 0, false, 25410);
        }

        [TestMethod]
        [ExpectedException(typeof(PersonaInvalidaException))]
        public void PersonaSinNombreValido()
        {
            Alumno a1 = new Alumno("", "Pompin", 0, false, 25410);
        }

        [TestMethod]
        [ExpectedException(typeof(PersonaInvalidaException))]
        public void PersonaSinApellidoValido()
        {
            Alumno a1 = new Alumno("Pepe", "", 0, false, 25410);
        }

        [TestMethod]
        [ExpectedException(typeof(PersonaInvalidaException))]
        public void PersonaSinCuotaValida()
        {
            Alumno a1 = new Alumno("Pepe", "", 0, false, 0);
        }

        [TestMethod]
        public void AltaAlumnoValido()
        {
            Alumno a1 = new Alumno("Pepe", "Pompin", 16547809, false, 25410);

            if (ValidarPersona(a1))  // Agregar  funcion para validar datos del alumno
            {
                Assert.IsNotNull(a1);
            }

        }

        public bool ValidarPersona(Persona p)
        {
            bool flag = false;

            if (p.Dni > 1000000 && Validaciones.ValidarString(p.Nombre) && Validaciones.ValidarString(p.Apellido) )
            {
                flag = true;
            }
            return flag;
        }

        [TestMethod]
        public void PersonaDniValido()
        {
            Alumno a1 = new Alumno("Pepe", "Pompin", 16547809, false, 25410);

            Assert.IsNotNull(a1);
        }

        [TestMethod]
        public void PersonaNombreValido()
        {
            Alumno a1 = new Alumno("Pepe", "Pompin", 16547809, false, 25410);

            Assert.IsNotNull(a1);
        }

        [TestMethod]
        public void PersonaApellidoValido()
        {
            Alumno a1 = new Alumno("Pepe", "Pompin", 16547809, false, 25410);

            Assert.IsNotNull(a1);
        }


        [TestMethod]
        public void Crear50Profesores()
        {
            FrmPrincipal menuPrincipal = new FrmPrincipal();

            menuPrincipal.harcodear();

            Assert.IsTrue(menuPrincipal.docentes.Count == 5 && menuPrincipal.alumnosSinAula.Count == 50);

        }

        //+alumno
        public void AulaSinAlumnos()
        {
            FrmPrincipal menuPrincipal = new FrmPrincipal();

            menuPrincipal.harcodear();

            Aula aula = new Aula(EColor.Amarillo, menuPrincipal.docentes[0] ,ETurno.Tarde);

            Assert.IsTrue(menuPrincipal.docentes.Count == 5 && menuPrincipal.alumnosSinAula.Count == 50);

        }












    }//
}//
