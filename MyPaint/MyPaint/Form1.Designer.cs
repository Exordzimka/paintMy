﻿namespace MyPaint
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SelectB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Rectangle = new System.Windows.Forms.ToolStripButton();
            this.Ellipse = new System.Windows.Forms.ToolStripButton();
            this.RememberedComposites = new System.Windows.Forms.ToolStripDropDownButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.объединитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разъединитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запомнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.SelectB, this.toolStripSeparator1, this.Rectangle, this.Ellipse, this.RememberedComposites});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1036, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SelectB
            // 
            this.SelectB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectB.Image = ((System.Drawing.Image) (resources.GetObject("SelectB.Image")));
            this.SelectB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectB.Name = "SelectB";
            this.SelectB.Size = new System.Drawing.Size(23, 22);
            this.SelectB.Text = "toolStripButton1";
            this.SelectB.Click += new System.EventHandler(this.SelectB_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Rectangle
            // 
            this.Rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rectangle.Image = ((System.Drawing.Image) (resources.GetObject("Rectangle.Image")));
            this.Rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(23, 22);
            this.Rectangle.Text = "toolStripButton2";
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click_1);
            // 
            // Ellipse
            // 
            this.Ellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Ellipse.Image = ((System.Drawing.Image) (resources.GetObject("Ellipse.Image")));
            this.Ellipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(23, 22);
            this.Ellipse.Text = "toolStripButton3";
            this.Ellipse.Click += new System.EventHandler(this.Ellipse_Click_1);
            // 
            // RememberedComposites
            // 
            this.RememberedComposites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RememberedComposites.Image = ((System.Drawing.Image) (resources.GetObject("RememberedComposites.Image")));
            this.RememberedComposites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RememberedComposites.Name = "RememberedComposites";
            this.RememberedComposites.Size = new System.Drawing.Size(29, 22);
            this.RememberedComposites.Text = "toolStripDropDownButton1";
            this.RememberedComposites.ToolTipText = "RememberedComposites";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(121, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 533);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 49);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(106, 533);
            this.treeView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.объединитьToolStripMenuItem, this.разъединитьToolStripMenuItem, this.запомнитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // объединитьToolStripMenuItem
            // 
            this.объединитьToolStripMenuItem.Enabled = false;
            this.объединитьToolStripMenuItem.Name = "объединитьToolStripMenuItem";
            this.объединитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.объединитьToolStripMenuItem.Text = "Объединить";
            this.объединитьToolStripMenuItem.Click += new System.EventHandler(this.объединитьToolStripMenuItem_Click);
            // 
            // разъединитьToolStripMenuItem
            // 
            this.разъединитьToolStripMenuItem.Enabled = false;
            this.разъединитьToolStripMenuItem.Name = "разъединитьToolStripMenuItem";
            this.разъединитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.разъединитьToolStripMenuItem.Text = "Разъединить";
            this.разъединитьToolStripMenuItem.Click += new System.EventHandler(this.разъединитьToolStripMenuItem_Click);
            // 
            // запомнитьToolStripMenuItem
            // 
            this.запомнитьToolStripMenuItem.Name = "запомнитьToolStripMenuItem";
            this.запомнитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.запомнитьToolStripMenuItem.Text = "Запомнить";
            this.запомнитьToolStripMenuItem.Click += new System.EventHandler(this.запомнитьToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 582);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton Ellipse;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton Rectangle;
        private System.Windows.Forms.ToolStripDropDownButton RememberedComposites;
        private System.Windows.Forms.ToolStripButton SelectB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem запомнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объединитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разъединитьToolStripMenuItem;

        #endregion
    }
}

