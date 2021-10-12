using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ListaSimple
{
    public partial class Form1 : Form
    {
        Lista miLista;
        Graphics graficos;
        public Form1()
        {
            InitializeComponent();
            miLista = new Lista();
            graficos = this.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
            int d = int.Parse(txtNumero.Text);
            string nombre = txtNombre.Text;
            string telefono = txtTelefono.Text;
            Nodo n = new Nodo(d,nombre, telefono);
            miLista.Agregar(n);
            txtNumero.Clear();
            txtNumero.Focus();
            txtNombre.Clear();
            txtTelefono.Clear();
            miLista.Mostrar(lsbLista);
            miLista.Guardar("testListaSimple");
                for (int i = 0; i < lsbLista.Items.Count; i++)
                {
                    DibujarRectangulo(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            //MessageBox.Show(miLista + "");
        }
        public void DibujarRectangulo(int x)
        {
            Pen pluma = new Pen(Color.Black, 3);
            Rectangle rectangulo = new Rectangle(10+(x*120), 400, 100, 50);
            graficos.DrawRectangle(pluma, rectangulo);
            graficos.DrawLine(pluma, 80 + (x * 120), 400, 80 + (x * 120), 450);
            graficos.DrawLine(pluma, 95 + (x * 120), 425, 130 + (x * 120), 425);
        }
        public void EliminarRectangulo(int y)
        {
            Pen plumas = new Pen(BackColor, 3);
            Rectangle rectangulos = new Rectangle(10 + (y * 120), 400, 100, 50);
            graficos.DrawRectangle(plumas, rectangulos);
            graficos.DrawLine(plumas, 80 + (y * 120), 400, 80 + (y * 120), 450);
            graficos.DrawLine(plumas, 95 + (y * 120), 425, 130 + (y * 120), 425);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                miLista.Eliminar(d);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lsbLista);
                for (int i = 0; i < lsbLista.Items.Count; i++)
                {
                    EliminarRectangulo(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " +ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                Nodo b = new Nodo();
                if (miLista.Buscar(d, ref b))
                {
                    txtNombre.Text = b.Nombre;
                    txtTelefono.Text = b.Telefono;
                    //MessageBox.Show("Existe ");
                }
                else
                {
                    txtNombre.Clear();
                    txtTelefono.Clear();
                    MessageBox.Show("NO Existe ");
                }
                txtNumero.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                miLista.Modificar(d, txtNombre.Text, txtTelefono.Text);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lsbLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lista lc = new Lista();
            lc.Cargar("testListaSimple");
            lsbLista.Items.Add(lc.ToString());
        }
    }
}
