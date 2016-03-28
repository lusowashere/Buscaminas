using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        public static int filas, columnas, minas, destapadas, segundos;
        public int recordFacil, recordMedio, recordDificil;

        public string modoPartida;

        public static boton[,] matrizBotones;

        int nuevasFil, nuevasCol, nuevasMin;

        public Form1()
        {
            InitializeComponent();

            leerRecords();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            modoPartida = "Facil";
            nuevaPartida(8, 8, 10);
        }

        private void nuevaPartida(int fil, int col,int min)//crea el tablero
        {
            borrar();

            destapadas = 0;
            minas = min;
            filas=fil;
            columnas=col;
            if (minas > filas * columnas)
            {
                MessageBox.Show("Has puesto demasiadas minas");
            }
            else
            {
                matrizBotones=new boton[filas,columnas];
                //aquí hay que programar todo lo de que distribuya las minas y de los números a las casillas

                Random rnd=new Random();

                Boolean[,] matrizMinas = new Boolean[filas, columnas];

                for (int i1=0; i1 < filas; i1++)
                {
                    for (int j1=0; j1 < columnas; j1++) { matrizMinas[i1, j1] = false; }
                }

                int numeroRealDeMinas=0;

                for (int minasColocadas = 0; minasColocadas < minas; minasColocadas++)
                {
                    bool faltaColocar = true;
                    int contador = 0;
                    while (faltaColocar && contador < 100)
                    {
                        int f, c;
                        f = rnd.Next(filas);
                        c = rnd.Next(columnas);
                        if (!matrizMinas[f, c])
                        {
                            matrizMinas[f, c] = true;
                            faltaColocar = false;
                        }
                        contador += 1;
                    }
                    if (!faltaColocar) { numeroRealDeMinas += 1; }
                }

                //MessageBox.Show("Minas totales:" + numeroRealDeMinas);

                int[,] numerosInt = new int[filas, columnas];
                string[,] numerosString = new string[filas, columnas];

                for(int i2=0;i2<filas;i2++){
                    for(int j2=0;j2<filas;j2++){
                        if(matrizMinas[i2,j2]){numerosInt[i2,j2]=3000;}
                        else{
                            int sumaMinas=0;
                            for(int m=-1;m<2;m++){
                                for(int n=-1;n<2;n++){
                                    try 
	                                    {	
                                            if(matrizMinas[i2+m,j2+n]){
                                                sumaMinas+=1;
                                            }
	                                    }
	                                    catch (Exception)//suponiendo que fuera un borde
	                                    {
		
		                                    sumaMinas+=0;
	                                    }
                                }
                            }
                            numerosInt[i2,j2]=sumaMinas;
                        }
                    }
                }


                for(int i3=0;i3<filas;i3++){
                    for(int j3=0;j3<filas;j3++){
                        numerosString[i3,j3]=numerosInt[i3,j3].ToString();
                        if(numerosInt[i3,j3]==0){numerosString[i3,j3]="";
                        }
                    }
                }
                //Aquí se crean los botones
                int tamaño;
                if (filas > columnas)
                {
                    tamaño = panel1.Height / filas;
                }
                else { tamaño = panel1.Width / columnas; }

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < filas; j++)
                    {
                        matrizBotones[i, j] = new boton(matrizMinas[i,j], numerosString[i,j], i, j, panel1, tamaño,this);
                    }
                }
                timer1.Enabled = true;
                segundos = 0;
            }
        }//fin de la función nueva partida

        public static void mostrarTodo()
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    matrizBotones[i, j].mostrar();
                }
            }
        }

        public static void apretarAlrededor(int fil, int col)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    try
                    {
                        matrizBotones[fil+i,col+j].pulsar();

                    }
                    catch (Exception)
                    {
                        
                       
                    }
                    
                }
            }
        }

        public void borrar()
        {
            panel1.Controls.Clear();
        }


        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void medioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modoPartida = "Medio";
            nuevaPartida(16, 16, 40);

        }

        private void dificilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modoPartida = "Dificil";
            nuevaPartida(16, 30, 99);
        }

        private void personalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modoPartida = "Personalizado";

            Form formularioNueva=new Form();
            formularioNueva.Height = 400;
            formularioNueva.Width = 400;
            formularioNueva.Text = "Partida personalizada";
            formularioNueva.Show();

            SplitContainer part = new SplitContainer();
            part.Orientation = Orientation.Horizontal;
            formularioNueva.Controls.Add(part);
            SplitContainer partido = new SplitContainer();
            partido.Orientation=Orientation.Horizontal;
            part.Panel1.Controls.Add(partido);
            SplitContainer partido2 = new SplitContainer();
            partido2.Orientation = Orientation.Vertical;
            partido.Panel1.Controls.Add(partido2);
            Label lab1 = new Label();
            lab1.Text = "Filas";
            partido2.Panel1.Controls.Add(lab1);
            NumericUpDown numFil = new NumericUpDown();
            partido2.Panel2.Controls.Add(numFil);
            Label lab2 = new Label();
            lab2.Text="Columnas";
            SplitContainer partido3 = new SplitContainer();
            partido3.Orientation = Orientation.Vertical;
            
            partido3.Panel1.Controls.Add(lab2);
            NumericUpDown numcol = new NumericUpDown();
            partido3.Panel2.Controls.Add(numcol);

            partido.Panel2.Controls.Add(partido3);

            SplitContainer partido4 = new SplitContainer();
            partido4.Orientation = Orientation.Horizontal;
            partido4.Dock = DockStyle.Fill;

            part.Panel2.Controls.Add(partido4);

            SplitContainer partido5 = new SplitContainer();
            partido5.Orientation = Orientation.Vertical;
            partido5.Dock = DockStyle.Fill;
            partido4.Panel1.Controls.Add(partido5);

            Label lab3 = new Label();
            lab3.Text = "Minas";
            lab3.Dock = DockStyle.Bottom;
            partido5.Panel1.Controls.Add(lab3);
            NumericUpDown numMin = new NumericUpDown();
            numMin.Dock = DockStyle.Bottom;
            partido5.Panel2.Controls.Add(numMin);

            Button bot2 = new Button();
            bot2.Text="Empezar";

            partido4.Panel2.Controls.Add(bot2);

            bot2.Click += new EventHandler(bot2_Click);

            bot2.Dock = DockStyle.Right;

            partido.Dock = DockStyle.Fill;
            part.Dock = DockStyle.Fill;
            partido2.Dock = DockStyle.Fill;
            partido3.Dock = DockStyle.Fill;
            lab1.Dock = DockStyle.Bottom;
            numcol.Dock = DockStyle.Bottom;
            lab2.Dock = DockStyle.Bottom;
            numFil.Dock = DockStyle.Bottom;

            nuevasCol = 10;
            nuevasFil = 10;
            nuevasMin = 20;
            numcol.Value = nuevasCol;
            numFil.Value = nuevasFil;
            numMin.Value = nuevasMin;

            numcol.ValueChanged += new EventHandler(numcol_ValueChanged);
            numFil.ValueChanged += new EventHandler(numFil_ValueChanged);
            numMin.ValueChanged += new EventHandler(numMin_ValueChanged);
        }

        void numMin_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown a = (NumericUpDown)sender;
            nuevasMin = (int)a.Value;
        }

        void numFil_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown a = (NumericUpDown)sender;
            nuevasFil = (int)a.Value;
        }

        void numcol_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown a=(NumericUpDown) sender;
            nuevasCol = (int) a.Value;
            
        }

        void bot2_Click(object sender, EventArgs e)
        {
            nuevaPartida(nuevasFil, nuevasCol, nuevasMin);
            
        }

        public static int contarEnabledFalse()
        {
            int contador = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (!matrizBotones[i, j].getEnabled())
                    {
                        contador += 1;
                    }
                }
            }
            return contador;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos = segundos + 1;
            Tiempo.Text = funcionesAux.tiempo(segundos);
        }

        public void timerOff()
        {
            timer1.Enabled = false;
            Tiempo.Text = "";
            segundos = 0;
        }

        public int getSegundos() { return segundos; }

        /// <summary>
        /// Guarda los records en un archivo externo
        /// </summary>
        public void guardarRecords()
        {
            String ruta = "recordsBuscaminas.lus";

            if (!File.Exists(ruta))//hay que crear la ruta
            {
                FileStream fs = File.Create(ruta);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine("Facil");
            sw.WriteLine(recordFacil);
            sw.WriteLine("Medio");
            sw.WriteLine(recordMedio);
            sw.WriteLine("Dificil");
            sw.WriteLine(recordDificil);
            sw.Close();            

        }//fin de la función guardarRecords

        /// <summary>
        /// lee el archivo con los records y transfiere los valores a las variables
        /// </summary>
        public void leerRecords()
        {
            string ruta = "recordsBuscaminas.lus";
            if (File.Exists(ruta))
            {
                string aux;//para saltarse las líneas donde pone "facil","medio" y "dificil"
                StreamReader sr = new StreamReader(ruta);
                aux = sr.ReadLine();
                recordFacil = Convert.ToInt32(sr.ReadLine());
                aux = sr.ReadLine();
                recordMedio = Convert.ToInt32(sr.ReadLine());
                aux = sr.ReadLine();
                recordDificil = Convert.ToInt32(sr.ReadLine());
            }
            else
            {
                recordFacil = 1000000;//para que sea casi seguro que se bate
                recordMedio = 1000000;
                recordDificil = 10000000;
            }
        }//fin de la función leerRecords

        /// <summary>
        /// devuelve el record según la variable "modoPartida"
        /// </summary>
        /// <returns></returns>
        public int getRecord()
        {
            if (modoPartida == "Dificil")
            {
                return recordDificil;
            }
            else if (modoPartida == "Medio")
            {
                return recordMedio;
            }
            else
            {
                return recordFacil;
            }
        }

        /// <summary>
        /// cambia el record asociado a la dificultad "modoPartida"
        /// </summary>
        /// <param name="nuevoRecord">nuevo record en segundos</param>
        public void setRecord(int nuevoRecord)
        {
            switch (modoPartida)
            {
                case "Dificil":
                    recordDificil = nuevoRecord;
                    break;
                case "Medio":
                    recordMedio = nuevoRecord;
                    break;
                case "Facil":
                    recordFacil = nuevoRecord;
                    break;
                default://no se hace nada
                    break;
            }
        }

    }//fin de la clase form1

    public class boton
    {
        Boolean mina;
        int fila, columna;
        string numero;
        Button bot;
        Form1 formulario;

        public boton(Boolean tieneMina, string numero, int fil, int col, Panel contenedor, int tamaño, Form1 este)
        {
            mina=tieneMina;
            Button a = new Button();
            bot = a;
            fila = fil;
            columna = col;
            this.numero=numero;
            bot.Height = tamaño;
            bot.Width = tamaño;
            //bot.Click += new EventHandler(bot_Click);
            bot.MouseDown += new MouseEventHandler(bot_MouseDown);
            
            contenedor.Controls.Add(bot);
            bot.Left = columna * tamaño;
            bot.Top = fila * tamaño;
            bot.FlatStyle = FlatStyle.Popup;
            bot.BackColor = Color.Gray;
            float tamFuente;
            double f = tamaño * 0.4;
            tamFuente = (float)f;


            bot.Font = new Font(bot.Font.Name, tamFuente/*bot.Font.Size+10*/, FontStyle.Bold);

            formulario = este;
            
        }

        public Boolean getEnabled(){
            return bot.Enabled;
        }

        void bot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                bot.BackColor = Color.Orange;

            }
            else
            {
                if (mina)
                {
                    MessageBox.Show("¡¡BOOOM!!");
                    Form1.mostrarTodo();
                    bot.BackColor = Color.Red;
                }
                else
                {
                    if (numero == "")
                    {
                        bot.Text = numero;
                        bot.FlatStyle = FlatStyle.Flat;
                        bot.BackColor = Color.Empty;
                        bot.Enabled = false;
                        Form1.apretarAlrededor(fila, columna);
                        
                    }
                    else
                    {
                        bot.Text = numero;
                        bot.FlatStyle = FlatStyle.Flat;
                        bot.BackColor = Color.Empty;
                        //bot.ForeColor = selColor();
                        bot.Enabled = false;
                    }
                    comprobar();
                }

            }
        }//cierre de la funcion mousedown

        public void pulsar(){
            if (mina) { 
                
                Form1.mostrarTodo();
                bot.BackColor = Color.Red;
                MessageBox.Show("¡¡BOOOM!!");
                
            }
            else
            {
                if (numero == "" && bot.Enabled==true)
                {
                    bot.Text = numero;
                    bot.FlatStyle = FlatStyle.Flat;
                    bot.BackColor = Color.Empty;
                    bot.Enabled = false;
                    Form1.apretarAlrededor(fila, columna);
                }
                else
                {
                    bot.Text = numero;
                    bot.FlatStyle = FlatStyle.Flat;
                    bot.BackColor = Color.Empty;
                    bot.Enabled = false;
                    comprobar();
                }
                
            }

        }//cierre de la funcion pulsar


        void bot_Click(object sender, EventArgs e)
        {
            

            if (mina) { 
                MessageBox.Show("¡¡BOOOM!!");
                Form1.mostrarTodo();
                formulario.timerOff();
                bot.BackColor = Color.Red;
            }
            else
            {
                bot.Text = numero;
                bot.FlatStyle = FlatStyle.Flat;
                bot.BackColor = Color.Empty;
                bot.Enabled = false;
                comprobar();
            }
        }//cierre de la funcion click

        public void mostrar()
        {
            if (mina)
            {
                bot.Text = "X";
                bot.Enabled = false;
            }
            else
            {
                bot.Text = numero;
                bot.FlatStyle = FlatStyle.Flat;
                bot.BackColor = Color.Empty;
                bot.Enabled = false;
                //comprobar();
            }
        }//cierre de la función mostrar

        public void comprobar()
        {
            int totales, destapadas, minas;
            totales = Form1.filas * Form1.columnas;
            minas = Form1.minas;
            destapadas = Form1.contarEnabledFalse();
            if (destapadas == totales - minas) //se ganó
            {

                string texto;

                texto = "¡¡GANASTE!! \n tiempo total: " + funcionesAux.tiempo(formulario.getSegundos());

                if (formulario.modoPartida != "Personalizado" && formulario.getSegundos() < formulario.getRecord())//nuevo record
                {
                    texto = texto + "\n ¡Nuevo record!";
                    formulario.setRecord(formulario.getSegundos());
                    formulario.guardarRecords();

                }
                else
                {
                    if (formulario.modoPartida != "Personalizado")
                    {
                        texto = texto + "\n Record actual: " + funcionesAux.tiempo(formulario.getRecord());
                    }
                }

                MessageBox.Show(texto);
                formulario.timerOff();

                Form1.mostrarTodo();
                
            }
            else
            {
                Form1.destapadas = destapadas;
            }
        }//cierre de la función comprobar

        private Color selColor()
        {
            switch (numero)
            {
                case "1":
                    return Color.Blue;
                    //break;
                case "2":
                    return Color.Green;
                    //break;
                case "3":
                    return Color.Brown;
                    //break;
                case "4":
                    return Color.Purple;
                    //break;
                case "5":
                    return Color.Red;
                    //break;
                default:
                    return Color.Black;
                    //break;
            }
        }//cierre de la función selColor

    }//cierre de la clase boton

    public class funcionesAux
    {
        /// <summary>
        /// Convierte una cantidad de segundos en un string de la forma hh:mm:ss
        /// </summary>
        /// <param name="segundos">tiempo total en segundos</param>
        /// <returns></returns>
        public static string tiempo(int segundos)
        {
            string valor;
            valor = "";

            //primero las horas, que no siempre estarán
            if (segundos > 3600)
            {
                int horas;
                horas = Convert.ToInt32(segundos / 3600);
                valor = Convert.ToString(horas)+":";
            }

            //ahora los minutos
            int restoHoras, minutos;
            restoHoras = segundos % 3600;

            minutos = Convert.ToInt32(restoHoras / 60);
            valor = valor + ponerCeros(minutos)+":";

            //finalmente los segundos
            int restoMinutos;
            restoMinutos = restoHoras % 60;
            valor = valor + ponerCeros(restoMinutos);



            return valor;
        }

        /// <summary>
        /// clásico poner un cero antes si sólo tiene un dígito
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string ponerCeros(int numero)
        {
            string aux = Convert.ToString(numero);

            if (numero < 10) { aux = "0" + aux; }

            return aux;
        }
    }
}
