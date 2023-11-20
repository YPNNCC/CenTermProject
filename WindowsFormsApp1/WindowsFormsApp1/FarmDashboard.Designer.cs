using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class FarmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public enum NodeType
        {
            Item,
            ItemContainer
        }

        public class CustomTreeNode : TreeNode
        {
            public Point Location { get; set; }
            public Size Size { get; set; }
            public decimal Price { get; set; }
            public NodeType Type { get; set; }

            public CustomTreeNode(string text, NodeType type, Point location = default, Size size = default, decimal price = default) : base(text)
            {
                Type = type;
                Location = location;
                Size = size;
                Price = price;
                ImageIndex = (int)type;
                ForeColor = type == NodeType.Item ? Color.Black : Color.Brown;
            }

            public CustomTreeNode CreateChild(string text, NodeType type, Point localPosition = default, Size size = default, decimal price = default)
            {
                Point globalPosition = new Point(Location.X + localPosition.X, Location.Y + localPosition.Y);
                CustomTreeNode childNode = new CustomTreeNode(text, type, globalPosition, size, price);

                Nodes.Add(childNode);
                return childNode;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.visualization_panel = new System.Windows.Forms.Panel();
            this.dashboardheading_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scan_farm_button = new System.Windows.Forms.Button();
            this.visit_item_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.change_location_button = new System.Windows.Forms.Button();
            this.change_price_button = new System.Windows.Forms.Button();
            this.change_dimensions_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.add_item_container_button = new System.Windows.Forms.Button();
            this.management_panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.add_item_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.management_panel.SuspendLayout();
            this.SuspendLayout();
            //
            // visualization_panel
            //
            this.visualization_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visualization_panel.Location = new System.Drawing.Point(356, 27);
            this.visualization_panel.Name = "visualization_panel";
            this.visualization_panel.Size = new System.Drawing.Size(800, 600);
            this.visualization_panel.TabIndex = 23;
            this.visualization_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.visualization_panel_Paint);
            //
            // dashboardheading_label
            //
            this.dashboardheading_label.BackColor = System.Drawing.Color.Transparent;
            this.dashboardheading_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardheading_label.Location = new System.Drawing.Point(12, 4);
            this.dashboardheading_label.Name = "dashboardheading_label";
            this.dashboardheading_label.Size = new System.Drawing.Size(202, 20);
            this.dashboardheading_label.TabIndex = 24;
            this.dashboardheading_label.Text = "Farm Dashboard";
            this.dashboardheading_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel1
            //
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.scan_farm_button);
            this.panel1.Controls.Add(this.visit_item_button);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 207);
            this.panel1.TabIndex = 25;
            //
            // scan_farm_button
            //
            this.scan_farm_button.Location = new System.Drawing.Point(38, 82);
            this.scan_farm_button.Name = "scan_farm_button";
            this.scan_farm_button.Size = new System.Drawing.Size(250, 50);
            this.scan_farm_button.TabIndex = 3;
            this.scan_farm_button.Text = "Scan Farm";
            this.scan_farm_button.UseVisualStyleBackColor = true;
            this.scan_farm_button.Click += new System.EventHandler(this.scan_farm_button_Click);
            //
            // visit_item_button
            //
            this.visit_item_button.Location = new System.Drawing.Point(38, 26);
            this.visit_item_button.Name = "visit_item_button";
            this.visit_item_button.Size = new System.Drawing.Size(250, 50);
            this.visit_item_button.TabIndex = 2;
            this.visit_item_button.Text = "Visit Item / Item Container";
            this.visit_item_button.UseVisualStyleBackColor = true;
            this.visit_item_button.Click += new System.EventHandler(this.visit_item_button_Click);
            //
            // label5
            //
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-2, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(338, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "3. Arduino/Microbit Controlled Device Actions";
            //
            // label1
            //
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 24);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            //
            // menuStrip1
            //
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(92, 19);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "miniToolStrip";
            this.menuStrip1.Visible = false;
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(173, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "Rename";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RenameItemButtonClick);
            //
            // change_location_button
            //
            this.change_location_button.Location = new System.Drawing.Point(173, 111);
            this.change_location_button.Name = "change_location_button";
            this.change_location_button.Size = new System.Drawing.Size(160, 24);
            this.change_location_button.TabIndex = 15;
            this.change_location_button.Text = "Change Location ";
            this.change_location_button.UseVisualStyleBackColor = true;
            this.change_location_button.Click += new System.EventHandler(this.ChangeItemLocationButtonClick);
            //
            // change_price_button
            //
            this.change_price_button.Location = new System.Drawing.Point(173, 135);
            this.change_price_button.Name = "change_price_button";
            this.change_price_button.Size = new System.Drawing.Size(160, 24);
            this.change_price_button.TabIndex = 16;
            this.change_price_button.Text = "Change Price";
            this.change_price_button.UseVisualStyleBackColor = true;
            this.change_price_button.Click += new System.EventHandler(this.change_price_button_Click);
            //
            // change_dimensions_button
            //
            this.change_dimensions_button.Location = new System.Drawing.Point(173, 159);
            this.change_dimensions_button.Name = "change_dimensions_button";
            this.change_dimensions_button.Size = new System.Drawing.Size(160, 24);
            this.change_dimensions_button.TabIndex = 17;
            this.change_dimensions_button.Text = "Change Dimensions";
            this.change_dimensions_button.UseVisualStyleBackColor = true;
            this.change_dimensions_button.Click += new System.EventHandler(this.button4_Click);
            //
            // delete_button
            //
            this.delete_button.Location = new System.Drawing.Point(173, 231);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(160, 24);
            this.delete_button.TabIndex = 18;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.DeleteCompButtonClick);
            //
            // label2
            //
            this.label2.Location = new System.Drawing.Point(173, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 19;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            //
            // treeView1
            //
            this.treeView1.Location = new System.Drawing.Point(3, 61);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(164, 321);
            this.treeView1.TabIndex = 31;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_2);
            //
            // add_item_container_button
            //
            this.add_item_container_button.Location = new System.Drawing.Point(173, 207);
            this.add_item_container_button.Name = "add_item_container_button";
            this.add_item_container_button.Size = new System.Drawing.Size(160, 24);
            this.add_item_container_button.TabIndex = 33;
            this.add_item_container_button.Text = "Add Item Container";
            this.add_item_container_button.UseVisualStyleBackColor = true;
            this.add_item_container_button.Click += new System.EventHandler(this.add_item_container_button_Click);
            //
            // management_panel
            //
            this.management_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.management_panel.Controls.Add(this.label4);
            this.management_panel.Controls.Add(this.label3);
            this.management_panel.Controls.Add(this.add_item_container_button);
            this.management_panel.Controls.Add(this.add_item_button);
            this.management_panel.Controls.Add(this.treeView1);
            this.management_panel.Controls.Add(this.label2);
            this.management_panel.Controls.Add(this.delete_button);
            this.management_panel.Controls.Add(this.change_dimensions_button);
            this.management_panel.Controls.Add(this.change_price_button);
            this.management_panel.Controls.Add(this.change_location_button);
            this.management_panel.Controls.Add(this.button1);
            this.management_panel.Location = new System.Drawing.Point(12, 27);
            this.management_panel.Name = "management_panel";
            this.management_panel.Size = new System.Drawing.Size(338, 387);
            this.management_panel.TabIndex = 22;
            //
            // label4
            //
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 22);
            this.label4.TabIndex = 35;
            this.label4.Text = "1. Items / Item Containers";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            //
            // label3
            //
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 35);
            this.label3.TabIndex = 34;
            this.label3.Text = "Commands for Items/Containers";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            //
            // add_item_button
            //
            this.add_item_button.Location = new System.Drawing.Point(173, 183);
            this.add_item_button.Name = "add_item_button";
            this.add_item_button.Size = new System.Drawing.Size(160, 24);
            this.add_item_button.TabIndex = 32;
            this.add_item_button.Text = "Add Item";
            this.add_item_button.UseVisualStyleBackColor = true;
            this.add_item_button.Click += new System.EventHandler(this.add_item_button_Click_1);
            //
            // label6
            //
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(356, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "2. Visualization";
            //
            // FarmDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1163, 635);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dashboardheading_label);
            this.Controls.Add(this.visualization_panel);
            this.Controls.Add(this.management_panel);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FarmDashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.management_panel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button visit_item_button;
        private System.Windows.Forms.Button scan_farm_button;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button change_location_button;
        private System.Windows.Forms.Button change_price_button;
        private System.Windows.Forms.Button change_dimensions_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button add_item_container_button;
        private System.Windows.Forms.Panel management_panel;
        private System.Windows.Forms.Button add_item_button;

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label dashboardheading_label;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel visualization_panel;

        private System.Windows.Forms.Label size1;
        private System.Windows.Forms.Label Vizualization;

        #endregion

        private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox22;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox23;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox24;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox25;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox26;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox27;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox43;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox44;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox45;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox46;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox47;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox48;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox28;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox29;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox30;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox31;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox32;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox33;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox37;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox38;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox39;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox40;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox41;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox42;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox35;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox16;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox17;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox18;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox19;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox20;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox21;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox7;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox9;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox36;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox11;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox12;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox13;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox14;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox34;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox15;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}