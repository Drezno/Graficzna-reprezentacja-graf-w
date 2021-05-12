using Microsoft.Msagl.Drawing;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.DebugHelpers.Persistence;
using Microsoft.Msagl.Layout.Layered;
using Label = System.Windows.Forms.Label;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;

namespace Graf
{
    public partial class Form1 : Form
    {
        //publiczne zmienne wykorzystywane w całym programie
        //rozmiar macierzy sąsiedztwa
        int currentSizeOfGraph = 0;
        //rozmiar macierzy incydencji ilość wierzchołków
        int currentSizeOfGraphIncidenceN = 0;
        //rozmiar macierzy incydencji ilość krawędzi
        int currentSizeOfGraphIncidenceM = 0;
        //lista kontrolek dla macierzy sąsiedztwa
        List<Label> labelList = new List<Label>();
        //lista kontrolek dla macierzy incydencji
        List<Label> labelListIncidence = new List<Label>();
        //ilość wierzchołków
        int n = 0;
        //ilość krawędzi
        int m = 0;
        //pomocnicze macierze
        string[,] adjacencyMatrix;
        string[,] incidencyMatrix;
        string[] vertexNames;
        List<TextBox> vertexNamesTxt = new List<TextBox>();


        public Form1()
        {
            InitializeComponent();
            /*
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            var Edge = graph.AddEdge("A", "B");
            Edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = ArrowStyle.None;
            Edge = graph.AddEdge("B", "C");
            Edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = ArrowStyle.None;
            Edge = graph.AddEdge("B", "C");
            Edge.LabelText = "TEST";
            Edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = ArrowStyle.None;
            Edge = graph.AddEdge("A", "A");
            Edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = ArrowStyle.None;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            graph.FindNode("C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
            */
        }

        



        /// <summary>
        /// KONTROLKI
        /// </summary>
        /// 
        //____________________________________________________________________________________________________________________________
        
        //MACIERZ SĄSIEDZTWA
        private void UpDown_Adjacency_1_ValueChanged(object sender, EventArgs e)
        {
            //aktualna wartość kontrolki NumericUpDown dla macierzy sąsiedztwa - ilość krawędzi i wierzchołków
            n = (int)UpDown_Adjacency_1.Value;

            changeAdjacencyMatrix();

            //zmienia wymiar również macierzy incydencji
            changeIncidenceMatrix();
            UpDown_Incidence_1.Value = (int)UpDown_Adjacency_1.Value;
        }

        private void button_Adjacency_Click(object sender, EventArgs e)
        {
            createGraphFromAdjacencyMatrix();
        }

        //MACIERZ INCYDENCJI
        //____________________________________________________________________________________________________________________________
        private void UpDown_Incidence_1_ValueChanged(object sender, EventArgs e)
        {
            //aktualna wartość kontrolki NumericUpDown dla macierzy incydencji - ilość wierzchołków
            n = (int)UpDown_Incidence_1.Value;

            changeIncidenceMatrix();
            //zmienia wymiar również macierzy sąsiedztwa
            changeAdjacencyMatrix();
            UpDown_Adjacency_1.Value = (int)UpDown_Incidence_1.Value;
        }

        private void UpDown_Incidence_2_ValueChanged(object sender, EventArgs e)
        {
            //aktualna wartość kontrolki NumericUpDown dla macierzy incydencji - ilość krawędzi
            m = (int)UpDown_Incidence_2.Value;

            changeIncidenceMatrix();
        }

        private void button_Incidence_Click(object sender, EventArgs e)
        {
            createGraphFromIncidenceMatrix();
        }


        /// <summary>
        /// MACIERZ SĄSIEDZTWA
        /// </summary>
        /// 
        //____________________________________________________________________________________________________________________________

        private void changeAdjacencyMatrix()
        {
            //jeśli podana liczba wierzchołków jest większa od poprzedniej liczby to dodaj kolejny wierzchołek do listy
            //(dynamiczne dodawanie kolejnych elementów do "pseudo-macierzy")
            if (n > currentSizeOfGraph)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        //jeśli już istnieje taki element na liście to pomiń, inaczej dodaj nowy element
                        //kontrolka wyświetlana w macierzy sąsiedztwa
                        if (!labelList.Any(item => item.Name == $"a.{i.ToString("D2")}.{j.ToString("D2")}"))
                        {
                            //.ToString("D2") dodaje przed pojedynczymi liczbami 0 np zamiast "4" wpisuje "04"
                            labelList.Add(lbl($"a.{i.ToString("D2")}.{j.ToString("D2")}"));
                        }
                    }
                    //dodanie pola tekstowego nazwy wierzchołka w macierzy sąsiedztwa - dodanie pola z nazwą
                    if (!vertexNamesTxt.Any(item => item.Name == $"textBoxVertex.{i}"))
                    {
                        vertexNamesTxt.Add(txtVertex($"textBoxVertex.{i}", i.ToString()));
                    }
                }
                /*
                for (int i = 1; i <= n; i++)
                {
                    //pole tekstowe nazwy wierzchołka w macierzy sąsiedztwa - dodanie pola z nazwą
                    if (!vertexNamesTxt.Any(item => item.Name == $"textBoxVertex.{i}"))
                    {
                        vertexNamesTxt.Add(txtVertex($"textBoxVertex.{i}", i.ToString()));
                    }
                }
                */
            }
            //jeśli użytkownik zmniejszył rozmiar macierzy to usuń nadmiarowe elementy z listy
            else if (n < currentSizeOfGraph)
            {
                //usuwanie nadmiarowych kolumn
                for (int i = currentSizeOfGraph; i > 0; i--)
                {
                    for (int j = currentSizeOfGraph; j > n; j--)
                    {
                        labelList.RemoveAll(item => item.Name == $"a.{i.ToString("D2")}.{j.ToString("D2")}");

                    }
                }
                //usuwanie nadmiarowych wierszy
                for (int i = currentSizeOfGraph; i > n; i--)
                {
                    for (int j = currentSizeOfGraph; j > 0; j--)
                    {
                        labelList.RemoveAll(item => item.Name == $"a.{i.ToString("D2")}.{j.ToString("D2")}");
                        
                        //usuwanie nazwy wierzchołków
                        vertexNamesTxt.RemoveAll(item => item.Name == $"textBoxVertex.{i}");
                    }
                }
            }

            //sortowanie listy
            labelList.Sort((x, y) => x.Name.CompareTo(y.Name));


            //wyświetlenie zawartości macierzy - testowanie
            foreach (var elem in vertexNamesTxt)
            {
                Debug.WriteLine(elem.Name);
            }
            Debug.WriteLine($"__________N = {n}, list size = {vertexNamesTxt.Count()}");
            


            //wyświetlenie macierzy sąsiedztwa
            Refresh_FlowControlPanel(flowLayoutPanel1,labelList);
            //wyświetlenie listy nazw wierzchołków w liście
            changeVertexName(flowLaoutPanel_VertexName_1,vertexNamesTxt);

            currentSizeOfGraph = n;
        }

        private void FindSimmetricalElement(Label label)
        {
            //bierze numer kolumny i wiersza z nazwy kontrolki
            string[] rowAndColumn = label.Name.Split('.');
            int row = Int16.Parse(rowAndColumn[1]);
            int column = Int16.Parse(rowAndColumn[2]);

            labelList.Find(item => item.Name == $"a.{column.ToString("D2")}.{row.ToString("D2")}").Text = label.Text;
        }

        private void createGraphFromAdjacencyMatrix()
        {
            //wykorzystana biblioteka MSAGL w celu prezentacji grafów

            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");



            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    var item = labelList.FirstOrDefault(o => o.Name == $"a.{i.ToString("D2")}.{j.ToString("D2")}");
                    if (item != null)
                    {
                        if (item.Text == "0")
                        {
                            string from_to = vertexNamesTxt[i - 1].Text;
                            graph.AddNode(from_to);
                        }
                            
                        else
                        {
                            int numberOfEdges = Int16.Parse(item.Text);
                            //bierze numer kolumny i wiersza z nazwy kontrolki i następnie traktuje jako nazwy wierzchołków i dodaje między nimi krawędzie
                            string[] rowAndColumn = item.Name.Split('.');
                            int ii = Int16.Parse(rowAndColumn[1]);
                            int jj = Int16.Parse(rowAndColumn[2]);

                            string from = vertexNamesTxt[ii - 1].Text;
                            string to = vertexNamesTxt[jj - 1].Text;

                            for (int index = numberOfEdges; index > 0; index--)
                                graph.AddEdge(from, to).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        }
                    }
                }
            }

            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();
        }

        /// <summary>
        /// MACIERZ INCYDENCJI
        /// </summary>
        /// 
        //____________________________________________________________________________________________________________________________
        
        private void changeIncidenceMatrix()
        {
            if(n > currentSizeOfGraphIncidenceN || m > currentSizeOfGraphIncidenceM)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        //jeśli już istnieje taki element na liście to pomiń, inaczej dodaj nowy element
                        if (!labelListIncidence.Any(item => item.Name == $"b.{i.ToString("D2")}.{j.ToString("D2")}"))
                        {
                            //.ToString("D2") dodaje przed pojedynczymi liczbami 0 np zamiast "4" wpisuje "04"
                            labelListIncidence.Add(lbl($"b.{i.ToString("D2")}.{j.ToString("D2")}"));
                        }
                    }
                    //dodanie pola tekstowego nazwy wierzchołka w macierzy sąsiedztwa - dodanie pola z nazwą
                    if (!vertexNamesTxt.Any(item => item.Name == $"textBoxVertex.{i}"))
                    {
                        vertexNamesTxt.Add(txtVertex($"textBoxVertex.{i}", i.ToString()));
                    }
                }
            }
            else if (m < currentSizeOfGraphIncidenceM)
            {
                //usuwanie nadmiarowych kolumn
                for (int i = currentSizeOfGraphIncidenceN; i > 0; i--)
                {
                    for (int j = currentSizeOfGraphIncidenceM; j > m; j--)
                    {
                        labelListIncidence.RemoveAll(item => item.Name == $"b.{i.ToString("D2")}.{j.ToString("D2")}");
                    }
                }
            }
            else if (n < currentSizeOfGraphIncidenceN)
            {
                //usuwanie nadmiarowych wierszy
                for (int i = currentSizeOfGraphIncidenceN; i > n; i--)
                {
                    for (int j = currentSizeOfGraphIncidenceM; j > 0; j--)
                    {
                        labelListIncidence.RemoveAll(item => item.Name == $"b.{i.ToString("D2")}.{j.ToString("D2")}");

                        //usuwanie nazwy wierzchołków
                        vertexNamesTxt.RemoveAll(item => item.Name == $"textBoxVertex.{i}");
                    }
                }
            }

            labelListIncidence.Sort((x, y) => x.Name.CompareTo(y.Name));


            //wyświetlenie zawartości macierzy - testowanie
            foreach (Label elem in labelListIncidence)
            {
                Debug.WriteLine(elem.Name);
            }
            Debug.WriteLine($"__________N = {n}, list size = {labelListIncidence.Count()}");
            


            //wyświetlenie macierzy incydencji
            Refresh_FlowControlPanel(flowLayoutPanel_Incidence,labelListIncidence);

            //wyświetlenie listy nazw wierzchołków w liście
            changeVertexName(flowLaoutPanel_VertexName_2, vertexNamesTxt);

            currentSizeOfGraphIncidenceN = n;
            currentSizeOfGraphIncidenceM = m;
        }


        private void createGraphFromIncidenceMatrix()
        {
            //TODO - zrobić wywołanie funkcji createGraphFromAdjacenceMatrix - zmiana macierzy incydencji na macierz sąsiedztwa
            //wykorzystana biblioteka MSAGL w celu prezentacji grafów

            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            Label temp = null;

            //iteruje po kolumnach a nie wierszach
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    var item = labelListIncidence.FirstOrDefault(o => o.Name == $"b.{j.ToString("D2")}.{i.ToString("D2")}");
                    //jeśli natrafiono na jedynkę, to znaczy że w obecnej kolumnie znajduje się kolejna jedynka
                    //czyli znaleźliśmy początek skąd wychodzi krawędź, ale trzeba znaleźć jescze dokąd ta krawędź "idzie"
                    if (item.Text == "1")
                    {
                        //jeśli znaleziono jedynkę i temp nie jest nullem, to znaczy że w danej kolumnie znaleziono dokąd idzie krawędź
                        if (temp!=null)
                        {
                            int ii = Int16.Parse(temp.Name.Split('.')[1]);
                            int jj = Int16.Parse(item.Name.Split('.')[1]);

                            string from = vertexNamesTxt[ii - 1].Text;
                            string to = vertexNamesTxt[jj - 1].Text;
                            
                            //string from = temp.Name.Split('.')[1];
                            //string to = item.Name.Split('.')[1];

                            graph.AddEdge(from, to).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;

                            temp = null;
                            break;
                        }
                        //jeśli znaleziono jedynkę i temp jest nullem, to znaczy że w danej kolumnie znaleziono skąd wychodzi krawędź
                        if (temp == null)
                            temp = item;
                    }
                }
            }

            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();
        }


        /// <summary>
        /// LISTA SĄSIEDZTWA
        /// </summary>
        /// 
        //____________________________________________________________________________________________________________________________


        ///
        //uabstrakcyjnione(? nwm czy dobre słowo) metody
        ///
        //___________________________________________________________________________________________________________________________________
        private void Refresh_FlowControlPanel(FlowLayoutPanel flow, List<Label> list)
        {
            //za każdym razem odświeża panel z kontrolkami zależnie od rozmiarów macierzy 
            //podanych przez użytkownika - dynamiczne wyświetlanie kontrolek
            flow.Controls.Clear();
            list.ForEach(item => flow.SetFlowBreak(item, false));
            //Debug.WriteLine($"__________________________");

            for (int j = 0; j < list.Count(); j++)
            {
                flow.Controls.Add(list[j]);

                //string temp = list[j].Name.Split('.')[1];
                //Debug.WriteLine($"środkowa wartość {j+1}: {temp} labela {list[j].Name}");

                
                if (j < list.Count()-1 && list[j].Name.Split('.')[1] != list[j+1].Name.Split('.')[1])
                {
                    //Nazwa kontrolki labela to x.yy.zz gdzie x oznacza typ macierzy (sąsiedztwa - a, incydencji - b)
                    //yy oznacza numer wiersza a zz oznacza numer kolumny. Komenda list[j].Name.Split('.')[1] bierze element z listy
                    //w tym wyypadku label o nazwie np a.01.12 i następnie bierze z tej nazwy środkowy element czyli numer wiersza
                    //01 i porównuje z następnym elementem, jeśli następny element ma inną wartość wiersza np 02, oznacza to,
                    //że należy przypisać flowbreaka
                    //

                    //Jeśli zwiększyliśmy dynamicznie ilość wierzchołków n, to upewnia się że poprzedni wierzchołek
                    //nie ma przypisanego FlowBreaka - upewnia się że poprzednia kontrolka nie niszczy układu macierzy
                    //(nie dodaje nowych kontrolek w odpowiednich wierszach do nowych wierszy a nie do tych do których powinny należeć)
                    //
                    //Zilustrowanie problemu:
                    //
                    //a)Przed usuwaniem przypisania FlowBreaka
                    //N = 3   X11 X12 X13  ->  N = 4  X11 X12 X13
                    //        X21 X22 X23             X14
                    //        X31 X32 X33             X21 X22 X23
                    //                                X24
                    //                                X31 X32 X33
                    //                                X34
                    //                                X41 X42 X43 X44
                    //
                    //b)Po usunięciu przypisania FlowBreaka do poprzedniej kontrolki:
                    //N = 3   X11 X12 X13  ->  N = 4  X11 X12 X13 X14
                    //        X21 X22 X23             X21 X22 X23 X24
                    //        X31 X32 X33             X31 X32 X33 X34
                    //                                X41 X42 X43 X44
                    //
                    flow.SetFlowBreak(list[j], true);
                    //flow.SetFlowBreak(list[j-1], false);
                }
            }
        }

        //tworzenie nowej kontrolki Label w kontrolce FlowLayoutPanel
        Label lbl(string i)
        {
            //tworzenie nowej kontrolki z którą można wchodzić w interakcję w macierzy sąsiedztwa oraz incydencji
            Label l = new Label();

            l.Name = i.ToString();
            l.Width = 30;
            l.Height = 30;
            l.BorderStyle = BorderStyle.FixedSingle;
            l.BackColor = Color.LightGray;
            l.Font = new Font("Arial", 12, FontStyle.Regular);
            l.AutoSize = false;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Text = 0.ToString();
            //l.Text = i.ToString();
            l.Click += new EventHandler(customLabel_Click);


            return l;
        }

        private void changeVertexName(FlowLayoutPanel flow, List<TextBox> vertexNames_)
        {
            //uaktualnianie flow control panel w którym znajdują się nazwy wierzchołków
            flow.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                var item = lblVertex($"labelVertex.{i + 1}", $"Wierzchołek {i + 1}");
                flow.Controls.Add(item);
                flow.SetFlowBreak(item, true);

                flow.Controls.Add(vertexNames_[i]);
                flow.SetFlowBreak(vertexNames_[i], true);
            }
        }

        Label lblVertex(string i,string j)
        {
            //tworzenie nowej kontrolki wyświetlającej numer wierzchołka w liście nazw wierzchołków
            Label l = new Label();

            l.Name = i.ToString();
            l.Width = 410;
            l.Height = 30;
            l.Font = new Font("Arial", 12, FontStyle.Regular);
            l.AutoSize = false;
            l.Text = j;

            return l;
        }

        TextBox txtVertex(string i, string defaultName)
        {
            //tworzenie nowej kontrolki nazwania wierzchołka w liście nazw wierzchołków
            TextBox t = new TextBox();

            t.Name = i.ToString();
            t.Width = 410;
            t.Height = 30;
            t.Font = new Font("Arial", 12, FontStyle.Regular);
            t.Text = defaultName;

            return t;
        }

        //customowy EventHandler kontrolek macierzy sąsiedztwa
        private void customLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            bool isItAdjacencyMatrix = false;

            //określenie z której macierzy (sąsiedztwa/incydencji) się korzysta w tej chwili
            if(label.Name.Substring(0,1)=="a")
            {
                isItAdjacencyMatrix = true;
            }
            else
            {
                isItAdjacencyMatrix = false;
            }


            //sprawia że możliwe staje się rozróżnienie pomiędzy lewym a prawym przyciskiem myszy
            MouseEventArgs me = (MouseEventArgs)e;
            //lewy przycisk - zwiększanie ilości krawędzi o 1
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int temp = Int16.Parse(label.Text);
                temp++;
                label.Text = temp.ToString();
                //zmień wartość symetrycznie diagonalnie jedynie gdy mamy do czynienia z macierzą sąsiedztwa
                if(isItAdjacencyMatrix)
                    FindSimmetricalElement(label);

            }
            //prawy przycisk - zmniejszanie ilości krawędzi o 1
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int temp = Int16.Parse(label.Text);
                if (temp > 0)
                    temp--;
                label.Text = temp.ToString();
                if (isItAdjacencyMatrix)
                    FindSimmetricalElement(label);
            }
            //środkowy przycisk - zerowanie ilości krawędzi
            if (me.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                label.Text = 0.ToString();
                if (isItAdjacencyMatrix)
                    FindSimmetricalElement(label);
            }
        }
    }
}
