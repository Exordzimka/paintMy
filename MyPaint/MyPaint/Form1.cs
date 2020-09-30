using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyPaint.Creators;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private string state = "Select";
        private FigureManager figureManager;
        private Dictionary<String, Creator> creatorDictionary;
        public Form1()
        {
            InitializeComponent();
            figureManager = new FigureManager();
            creatorDictionary = new Dictionary<string, Creator>();
            creatorDictionary.Add("Rectangle", new RectangleCreator());
            creatorDictionary.Add("Ellipse", new EllipseCreator());
            creatorDictionary.Add("Select", null);

        }

        private void Rectangle_Click_1(object sender, EventArgs e)
        {
            state = "Rectangle";
            figureManager.Manipulator.Attach(null); 
            Refresh();
        }

        private void Ellipse_Click_1(object sender, EventArgs e)
        {
            state = "Ellipse"; 
            figureManager.Manipulator.Attach(null);
            Refresh();
        }

        private void SelectB_Click_1(object sender, EventArgs e)
        {
            state = "Select";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            figureManager.Draw(e.Graphics);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            figureManager.MouseDown();
            if (creatorDictionary[state] != null)
            {
                figureManager.Add(creatorDictionary[state].CreateFigure(e.X, e.Y, 40, 50));
            }
            else if (figureManager.GetFigure(e.X, e.Y) != null)
            {
                figureManager.Manipulator.Attach(figureManager.GetFigure(e.X, e.Y));
                figureManager.Manipulator.SetTouchPoint(e.X, e.Y);
            }
            else
                figureManager.Manipulator.Attach(null);
            Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (figureManager.Manipulator.Selected != null && figureManager.MouseIsDown)
            {
                figureManager.Manipulator.Drag(e.X, e.Y);
                Refresh();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            figureManager.MouseUp();
        }
    }
}
