using Actividad.src;
using Actividad.view;
using System.Drawing;

namespace Actividad
{
    public partial class Form1 : Form
    {
        CentralDatos centralDatos;
        public Form1()
        {
            InitializeComponent();

            centralDatos = new CentralDatos(new InscripcionesPersonas(), new CursosInscritos(), new CursosProfesores());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una nueva pesta�a
            TabPage nuevaPesta�a = new TabPage();
            nuevaPesta�a.Text = "Pesta�a " + (tabControl1.TabCount + 1);

            // Obtener el tipo de formulario seleccionado en el ComboBox
            string tipoFormulario = nuevaClaseCombo.SelectedItem.ToString();

            // Instanciar el formulario correspondiente
            UserControl formulario = null;
            switch (tipoFormulario)
            {
                case "Estudiante":
                    formulario = new EstudianteForm(centralDatos);
                    break;
                case "Persona":
                    formulario = new PersonaForm(centralDatos);
                    break;
                case "Programa":
                    formulario = new ProgramaForm(centralDatos);
                    break;
                case "Facultad":
                    formulario = new FacultadForm(centralDatos);
                    break;
                case "Profesor":
                    formulario = new ProfesorForm(centralDatos);
                    break;
                case "Curso":
                    formulario = new CursoForm(centralDatos);
                    break;
                case "Inscripcion":
                    formulario = new InscripcionForm(centralDatos);
                    break;
                case "Curso con profesor":
                    formulario = new CursoProfesorForm(centralDatos);
                    break;
                default:
                    MessageBox.Show("Selecciona un tipo v�lido.");
                    return;
            }

            // Configurar el formulario para que se muestre dentro de la pesta�a
            formulario.BorderStyle = BorderStyle.None; // Quitar bordes del formulario
            formulario.Dock = DockStyle.Fill; // Hacer que el formulario ocupe toda la pesta�a

            // Agregar el formulario a la nueva pesta�a
            nuevaPesta�a.Controls.Add(formulario);

            // Mostrar el formulario
            formulario.Show();

            // Agregar la nueva pesta�a al TabControl
            tabControl1.TabPages.Add(nuevaPesta�a);

            // Seleccionar la nueva pesta�a autom�ticamente
            tabControl1.SelectedTab = nuevaPesta�a;
        }
    }
}
