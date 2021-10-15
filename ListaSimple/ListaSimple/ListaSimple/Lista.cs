﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ListaSimple
{
    class Lista
    {
        private Nodo head;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }
        public Lista()
        {
            head = null;
        }
        public void Agregar(Nodo n)
        {
            if (head == null)
            {
                head = n;
                return;
            }
            if (n.Numero < head.Numero)
            {
                n.Siguiente = head;
                head = n;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (n.Numero < h.Siguiente.Numero)
                {
                    break;
                }
                h = h.Siguiente;
            }
                n.Siguiente = h.Siguiente;
                h.Siguiente = n;
        }
        public void Guardar()
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
            string path = @"c:\testListaSimple.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                while (h != null)
                {
                    sw.WriteLine(h.Numero + "-" + h.Nombre + "-" + h.Telefono);
                    h = h.Siguiente;
                }  
            }
            return;
        }
        public void Cargar(string nombreArchivo)
        {
            nombreArchivo = "testListaSimple";
            string[] lineas = File.ReadAllLines(@"c:\" + nombreArchivo + ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int numero = int.Parse(datos[0]);
                string nombre = datos[1];
                string telefono = datos[2];
                Nodo n = new Nodo(numero, nombre, telefono);
                Agregar(n);
            }
        }
        public void Eliminar (int d)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == d)
            {
                head = head.Siguiente;
                return;
            }
            Nodo h = Head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    break;
                }
                h = h.Siguiente;
            }
            if (h.Siguiente != null)
            {
                h.Siguiente = h.Siguiente.Siguiente;
            }
        }
        
        public void Mostrar(ListBox lista)
        {
            Nodo h = head;
            lista.Items.Clear();
            while (h != null)
            {
                lista.Items.Add(h.ToString());
                h = h.Siguiente;
            }

        }
        public bool Buscar(int d, ref Nodo b)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Numero == d)
            {
                b = head;
                return true;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    b = h.Siguiente;
                    return true;
                }
                h = h.Siguiente;
            }
            return false;
        }
        public void Modificar (int d, string n, string t)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == d)
            {
                head.Nombre = n;
                head.Telefono = t;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    h.Siguiente.Nombre = n;
                    h.Siguiente.Telefono = t;
                    return;
                }
                h = h.Siguiente;
            }
            return;
        }
    
        public override string ToString()
        {
            string listaTexto = "";
            Nodo h = head;
            while (h != null)
            {
                listaTexto += h.ToString() + " ";
                h = h.Siguiente;
            }
            return listaTexto; 
        }
    }
}
