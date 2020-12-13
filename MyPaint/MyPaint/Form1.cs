using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MyPaint.Creators;
using MyPaint.Figures;
using MyPaint.Selecting;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private string state = "Select";
        private readonly Picture picture;
        private readonly Dictionary<string, Creator> creatorDictionary;
        private Creator creator;

        public Form1()
        {
            InitializeComponent();
            picture = new Picture();
            creatorDictionary = new Dictionary<string, Creator>();
            creatorDictionary.Add("Rectangle", new RectangleCreator());
            creatorDictionary.Add("Ellipse", new EllipseCreator());
            creatorDictionary.Add("Composite", new CompositeCreator());
            creatorDictionary.Add("Prototype", new PrototypeCreator());
            creatorDictionary.Add("Select", null);
        }

        private void Rectangle_Click_1(object sender, EventArgs e)
        {
            state = "Rectangle";
            picture.Manipulator.Attach(null);
            Refresh();
        }

        private void Ellipse_Click_1(object sender, EventArgs e)
        {
            state = "Ellipse";
            picture.Manipulator.Attach(null);
            Refresh();
        }

        private void SelectB_Click_1(object sender, EventArgs e)
        {
            state = "Select";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            picture.Draw(e.Graphics);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                picture.MouseDown();
                picture.Manipulator.SetSelectedHandler(null);
                Figure selectedFigure = picture.GetFigure(e.X, e.Y);
                if (creatorDictionary[state] != null)
                {
                    if (state == "Prototype")
                    {
                        picture.Add(creator.CreateFigure(e.X, e.Y, 0, 0).Clone());
                        treeView1.Nodes.Add(new TreeNode(picture.getFigures().Last().GetType().Name));
                    }
                    else
                    {
                        creator = creatorDictionary[state];
                        picture.Add(creator.CreateFigure(e.X, e.Y, 40, 50));
                        treeView1.Nodes.Add(new TreeNode(picture.getFigures().Last().GetType().Name));
                    }
                }
                else if (selectedFigure != null && !(selectedFigure is Handler))
                {
                    picture.Manipulator.Attach(picture.GetFigure(e.X, e.Y));
                    picture.Manipulator.SetSelectedHandler(picture.Manipulator.GetHandlers[0]);
                    picture.Manipulator.SetTouchPoint(e.X, e.Y);
                }
                else if (selectedFigure != null)
                {
                    picture.Manipulator.SetSelectedHandler(selectedFigure);
                    picture.Manipulator.SetTouchPoint(e.X, e.Y);
                }
                else
                    picture.Manipulator.Attach(null);

                Refresh();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (picture.Manipulator.Selected != null && picture.MouseIsDown)
            {
                picture.Manipulator.Drag(e.X, e.Y);
                Refresh();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            picture.MouseUp();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
                picture.Undo();
            else if (e.Control)
                picture.CtrlDown();
            Refresh();
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 17 && picture.CtrlIsDown)
                picture.CtrlUp();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            объединитьToolStripMenuItem.Enabled = false;
            разъединитьToolStripMenuItem.Enabled = false;
            if ((e.Button & MouseButtons.Right) == 0) return;
            if (picture.Manipulator.Selected.Figures.Count > 1)
            {
                объединитьToolStripMenuItem.Enabled = true;
            }
            else if (picture.Manipulator.Selected.Figures.Count == 1 &&
                     picture.Manipulator.Selected.Figures[0] is Composite)
            {
                разъединитьToolStripMenuItem.Enabled = true;
            }
            contextMenuStrip1.Show(panel1, new Point(e.X, e.Y));
        }

        private void объединитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.Group(picture.Manipulator.Selected);
            объединитьToolStripMenuItem.Enabled = false;
            Refresh();
        }

        private void разъединитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.Ungroup((Composite) picture.Manipulator.Selected.Figures[0]);
            разъединитьToolStripMenuItem.Enabled = false;
            Refresh();
        }

        private void запомнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.RememberComposite(picture.Manipulator.Selected.Clone());
            RememberedComposites.DropDownItems.Clear();
            foreach (var rememberedComposite in picture.GetRememberedComposites)
            {
                ToolStripDropDownButton downButton = new ToolStripDropDownButton(rememberedComposite.Key);
                downButton.Click += RememberedCompositeClick;
                RememberedComposites.DropDownItems.Add(downButton);
            }

            //запомнитьToolStripMenuItem.Enabled = false;
            Refresh();
        }

        private void RememberedCompositeClick(object sender, EventArgs e)
        {
            ToolStripDropDownButton senderButton = (ToolStripDropDownButton) sender;
            state = "Prototype";
            picture.RememberFigure(picture.GetRememberedComposites[senderButton.Text]);
            PrototypeCreator prototypeCreator = new PrototypeCreator();
            prototypeCreator.RememberComposite(picture.RememberedFigure().Clone());
            creator = prototypeCreator;
        }
    }
}