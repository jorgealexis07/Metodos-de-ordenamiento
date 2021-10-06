using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Metodos_de_ordenamiento
{
    public partial class Internos : Form
    {
        //variables de tiempo
        public double tb;
        public double ts;
        public double tshell;
        public double tid;
        public double tqs;
        public double tsd;
        public double ths;
        private double tmp;
        public double[] nAleatorios;
        public int n;
        int h;
        //Datos para graficar Burbuja
        //ordenada
        public double co;
        public double mo;
        //Desordenada
        public double cd;
        public double md;
        //orden inverso
        public double ci;
        public double mi;

        //Datos para graficar InsercionDirecta
        //ordenada
        public double coID;
        public double moID;
        //Desordenada
        public double cdID;
        public double mdID;
        //orden inverso
        public double ciID;
        public double miID;

        //Datos para graficar SeleccionDirecta
        //ordenada
        public double coSD;
        public double moSD;
        //Desordenada
        public double cdSD;
        public double mdSD;
        //orden inverso
        public double ciSD;
        public double miSD;

        //Datos para graficar QuickSort
        //ordenada
        public double coQS;
        
        //orden inverso
        public double ciQS;
        



        public Internos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            n = Convert.ToInt32(textBox1.Text);
            GenNumCarga(n);
            h = n;
            OrdenarQuicksort(nAleatorios, 0, nAleatorios.Length - 1);
            OrdenarBurbuja(nAleatorios);
            OrdenarShake(nAleatorios);
            OrdenarInsercionDirecta(nAleatorios);
            OrdenarSeleccionDirecta(nAleatorios);
            OrdenarShell(nAleatorios);
            
           
            HeapSort(nAleatorios);
            //funcion para grafica
            Grafica();
            


        }

        public void GenNumCarga(int n)
        {

            //listBox1.Items.Clear();

            Random r = new Random();
            nAleatorios = new double[n];

            for (int i = 0; i < nAleatorios.Length; i++)
            {
                nAleatorios[i] = r.Next(1, 500);
                //listBox1.Items.Add(r.Next(1, 100));
                //listBox1.Items.Add(nAleatorios[i]);
            }
        }

        public void OrdenarBurbuja(double[] nAleatorios)
        {

            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            for (int i = 0; i < nAleatorios.Length - 1; i++)
            {
                for (int j = 0; j < nAleatorios.Length - 1; j++)
                {
                    if (nAleatorios[j] > nAleatorios[j + 1])
                    {
                        tmp = nAleatorios[j];
                        nAleatorios[j] = nAleatorios[j + 1];
                        nAleatorios[j + 1] = tmp;

                    }
                }
            }


            listBox1.Items.Clear();
            for (int j = 0; j < nAleatorios.Length; j++)
            {
                listBox1.Items.Add(nAleatorios[j]);
            }
            timer.endTimeMeasure();

            label2.Text = timer.getElapsedTime().TotalMilliseconds.ToString()+ " ms";
            tb = timer.getElapsedTime().TotalMilliseconds;

            //Ordenada
            //C
            co = ((n * n) - n) / (float)2;
            
            //M 0
            mo = 0;
            //Desordenada
            //C
            cd = ((n * n) - n) / (float)2;
            //M 
            md = 0.75 * ((n * n) - n);
            
            //Orden Inverso
            //C 
            ci = ((n * n) - n) / (float)2;
            //M 
            mi = 1.5 * ((n * n) - n);
            { return; }
        }

        public void OrdenarShake(double[] nAleatorios)
        {
            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            int N = nAleatorios.Length;
            int limSuperior = N - 1;
            while (0 <= limSuperior)
            {
                for (int j = 0; j < limSuperior; j++)
                {
                    if (nAleatorios[j] > nAleatorios[j + 1])
                    {
                        tmp = nAleatorios[j];
                        nAleatorios[j] = nAleatorios[j + 1];
                        nAleatorios[j + 1] = tmp;
                    }
                }
                limSuperior--;
                for (int j = limSuperior; j > 0; j--)
                {
                    if (nAleatorios[j] < nAleatorios[j - 1])
                    {
                        tmp = nAleatorios[j];
                        nAleatorios[j] = nAleatorios[j - 1];
                        nAleatorios[j - 1] = tmp;
                    }

                }

            }
            listBox2.Items.Clear();
            for (int j = 0; j < nAleatorios.Length; j++)
            {
                listBox2.Items.Add(nAleatorios[j]);
            }

            timer.endTimeMeasure();
            /*listBox3.Items.Clear();
            listBox3.Items.Add(timer.getElapsedTime().TotalMilliseconds);*/
            label3.Text = timer.getElapsedTime().TotalMilliseconds.ToString()+" ms";
            ts = timer.getElapsedTime().TotalMilliseconds;
            { return; }
        }
        public void OrdenarInsercionDirecta(double[] nAleatorios)
        {
            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            double auxili;
            int j;
            for (int i = 0; i < nAleatorios.Length; i++)
            {
                auxili = nAleatorios[i];
                j = i - 1;
                while (j >= 0 && nAleatorios[j] > auxili)
                {
                    nAleatorios[j + 1] = nAleatorios[j];
                    j--;
                }
                nAleatorios[j + 1] = auxili;
            }
            listBox3.Items.Clear();
            for (j = 0; j < nAleatorios.Length; j++)
            {
                listBox3.Items.Add(nAleatorios[j]);
            }

            timer.endTimeMeasure();
            label7.Text = timer.getElapsedTime().TotalMilliseconds.ToString() + " ms";
            tid = timer.getElapsedTime().TotalMilliseconds;

            //Ordenada
            //C
            coID = n - 1;
            //M 0
            //Desordenada
            //C
            cdID = ((n * n) + n - 2) / (float)4;
            //M 
            mdID = ((n * n) - n) / (float)4;
            //Orden Inverso
            //C 
            ciID = ((n * n) - n) / (float)2;
            //M 
            miID = ((n * n) - n) / (float)2;

            { return; }
        }

        public void OrdenarSeleccionDirecta(double[] nAleatorios)
        {
            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            int i, j, min;
            double auxiliar;


            for (i = 0; i < nAleatorios.Length - 1; i++)
            {

                min = i;
                for (j = i + 1; j < nAleatorios.Length; j++)
                {
                    if (nAleatorios[j] < nAleatorios[min])
                        min = j;
                }


                if (min != i)
                {
                    auxiliar = nAleatorios[i];
                    nAleatorios[i] = nAleatorios[min];
                    nAleatorios[min] = auxiliar;
                }
            }
            listBox4.Items.Clear();
            for (j = 0; j < nAleatorios.Length; j++)
            {
                listBox4.Items.Add(nAleatorios[j]);
            }

            timer.endTimeMeasure();
            label9.Text = timer.getElapsedTime().TotalMilliseconds.ToString() + " ms";
            tsd = timer.getElapsedTime().TotalMilliseconds;
            //Ordenada
            //C
            coSD = ((n * n) - n) / (float)2;
            //M 
            moSD = n - 1;
            //Desordenada
            //C
            cdSD = ((n * n) - n) / (float)2;
            //M 
            mdSD = n - 1;
            //Orden Inverso
            //C 
            ciSD = ((n * n) - n) / (float)2;
            //M 
            miSD = n - 1;
            { return; }
        }


        public void OrdenarShell(double[] nAleatorios)
        {
            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            int salto = 0;
            int sw = 0;
            double aux = 0;
            int x = 0;
            salto = nAleatorios.Length / 2;
            while (salto > 0)
            {
                sw = 1;
                while (sw != 0)
                {
                    sw = 0;
                    x = 1;
                    while (x <= (nAleatorios.Length - salto))
                    {
                        if (nAleatorios[x - 1] > nAleatorios[(x - 1) + salto])
                        {
                            aux = nAleatorios[(x - 1) + salto];
                            nAleatorios[(x - 1) + salto] = nAleatorios[x - 1];
                            nAleatorios[(x - 1)] = aux;
                            sw = 1;
                        }
                        x++;
                    }
                }
                salto = salto / 2;
            }
            listBox5.Items.Clear();
            for (int j = 0; j < nAleatorios.Length; j++)
            {
                listBox5.Items.Add(nAleatorios[j]);
            }

            timer.endTimeMeasure();
            label11.Text = timer.getElapsedTime().TotalMilliseconds.ToString() + " ms";
            tshell = timer.getElapsedTime().TotalMilliseconds;
            { return; }
        }

        public void OrdenarQuicksort(double[] nAleatorios, int ind_izq, int ind_der)
        {
            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            
                int i, j; /* variables indice del vector */
                double elem; /* contiene un elemento del vector */
                i = ind_izq;
                j = ind_der;
                elem = nAleatorios[(ind_izq + ind_der) / 2];
                do
                {
                    while (nAleatorios[i] < elem) //recorrido del vector hacia la derecha
                        i++;
                    while (elem < nAleatorios[j]) // recorrido del vector hacia la izquierda
                        j--;
                    if (i <= j) /* intercambiar */
                    {
                        double aux; /* variable auxiliar */
                        aux = nAleatorios[i];
                    nAleatorios[i] = nAleatorios[j];
                    nAleatorios[j] = aux;
                        i++;
                        j--;
                    }
                } while (i <= j);
                if (ind_izq < j) { OrdenarQuicksort(nAleatorios, ind_izq, j); } //Llamadas recursivas
                if (i < ind_der) { OrdenarQuicksort(nAleatorios, i, ind_der); }
            /*
            listBox6.Items.Clear();
            for (j = 0; j < nAleatorios.Length; j++)
            {
                listBox6.Items.Add(nAleatorios[j]);
            }
            */

            timer.endTimeMeasure();
            label13.Text = timer.getElapsedTime().TotalMilliseconds.ToString() + " ms";
            tqs = timer.getElapsedTime().TotalMilliseconds;

            //Ordenada
            //C
            coQS = (n - 1) * Math.Log(n);
            //Orden Inverso
            //C 
            ciQS = ((n * n) - n) / (float)2-1;
            { return; }
        }

        public void HeapSort(double[] nAleatorios)
        {
            ElapsedTime timer = new ElapsedTime();
            timer.startTimeMeasure();
            //Build-Max-Heap
            int heapSize = nAleatorios.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(nAleatorios, heapSize, p);

            for (int i = nAleatorios.Length - 1; i > 0; i--)
            {
                //Swap
                double temp = nAleatorios[i];
                nAleatorios[i] = nAleatorios[0];
                nAleatorios[0] = temp;

                heapSize--;
                MaxHeapify(nAleatorios, heapSize, 0);
            }

            listBox7.Items.Clear();
            for (int j = 0; j < nAleatorios.Length; j++)
            {
                listBox7.Items.Add(nAleatorios[j]);
            }

            timer.endTimeMeasure();
            label17.Text = timer.getElapsedTime().TotalMilliseconds.ToString() + " ms";
            ths = timer.getElapsedTime().TotalMilliseconds;


        }

        private static void MaxHeapify(double[] nAleatorios, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && nAleatorios[left] > nAleatorios[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && nAleatorios[right] > nAleatorios[largest])
                largest = right;

            if (largest != index)
            {
                double temp = nAleatorios[index];
                nAleatorios[index] = nAleatorios[largest];
                nAleatorios[largest] = temp;

                MaxHeapify(nAleatorios, heapSize, largest);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Internos_Load(object sender, EventArgs e)
        {
           
        }
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public void Grafica()
        {
            
            //chart1.Titles.Add("Metodos");
            //burbuja
            //Combinaciones 
            //Muestra dato
            chart1.Series["Ordenada"].IsValueShownAsLabel = true;
            chart1.Series["Desordenada"].IsValueShownAsLabel = true;
            chart1.Series["OrdenInverso"].IsValueShownAsLabel = true;

            chart1.Series["Ordenada"].Points.AddXY("Bubuja C", co);
            chart1.Series["Desordenada"].Points.AddXY("Burbuja C", cd);
            chart1.Series["OrdenInverso"].Points.AddXY("Burbuja C", ci);
           
            //Movimientos
            chart1.Series["Ordenada"].Points.AddXY("M", mo);
            chart1.Series["Desordenada"].Points.AddXY("M", md);
            chart1.Series["OrdenInverso"].Points.AddXY("M", mi);


            //Combinaciones Insercion Directa
            chart1.Series["Ordenada"].Points.AddXY("Insercion Directa C", coID);
            chart1.Series["Desordenada"].Points.AddXY("Insercion Directa C", cdID);
            chart1.Series["OrdenInverso"].Points.AddXY("Insercion Directa C", ciID);
            
            //Movimientos
            chart1.Series["Ordenada"].Points.AddXY("M", moID);
            chart1.Series["Desordenada"].Points.AddXY("M", mdID);
            chart1.Series["OrdenInverso"].Points.AddXY("M", miID);
            

            //Comparaciones Seleccion Directa
            chart1.Series["Ordenada"].Points.AddXY("Seleccion Directa C", coSD);
            chart1.Series["Desordenada"].Points.AddXY("Seleccion Directa C", cdSD);
            chart1.Series["OrdenInverso"].Points.AddXY("Seleccion Directa C", ciSD);

            //Movimientos
            chart1.Series["Ordenada"].Points.AddXY("M", moSD);
            chart1.Series["Desordenada"].Points.AddXY("M", mdSD);
            chart1.Series["OrdenInverso"].Points.AddXY("M", miSD);
           

            //combinaciones QuickSort
            //Muestra dato
            /*
            chart1.Series["Ordenada"].IsValueShownAsLabel = true;
            chart1.Series["OrdenInverso"].IsValueShownAsLabel = true;*/

            chart1.Series["Ordenada"].Points.AddXY("QuickSort C", coQS);
            chart1.Series["OrdenInverso"].Points.AddXY("QuickSort C", coQS);

        }
        public void Graficat()
        {
            GraphTiempoM_E graph = new GraphTiempoM_E();
            
            //cambiar la combinacion de colores
            graph.chart2.Palette = ChartColorPalette.Chocolate;

            graph.chart2.Titles.Add("Tiempo de Ejecucion");

            //Cantidades
            graph.chart2.Series["Metodos"].Points.AddXY("Burbuja", tb);
            graph.chart2.Series["Metodos"].Points.AddXY("Insercion Directa", tid);
            graph.chart2.Series["Metodos"].Points.AddXY("Seleccion Directa", tsd);
            graph.chart2.Series["Metodos"].Points.AddXY("Shake Sort", ts);
            graph.chart2.Series["Metodos"].Points.AddXY("Shell Sort", tshell);
            graph.chart2.Series["Metodos"].Points.AddXY("Quick Sort", tqs);
            graph.chart2.Series["Metodos"].Points.AddXY("Head Sort", ths);
            graph.Show();
            
        }

            private void button2_Click(object sender, EventArgs e)
        {
          //limpia todos los datos de la grafica para poder generar nuevos datos
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graficat();
        }
    }
} 

