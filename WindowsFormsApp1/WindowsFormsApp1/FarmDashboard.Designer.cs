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
            public decimal MarketValue { get; set; }
            public NodeType Type { get; set; }

            public CustomTreeNode(string text, NodeType type, Point location = default, Size size = default, decimal price = default, decimal market_value = default) : base(text)
            {
                Type = type;
                Location = location;
                Size = size;
                Price = price;
                MarketValue = market_value;
                ImageIndex = (int)type;
                ForeColor = type == NodeType.Item ? Color.Black : Color.Brown;
            }

            public CustomTreeNode CreateChild(string text, NodeType type, Point localPosition = default, Size size = default, decimal price = default, decimal market_value = default)
            {
                var globalPosition = new Point(Location.X + localPosition.X, Location.Y + localPosition.Y);
                var childNode = new CustomTreeNode(text, type, globalPosition, size, price, market_value);

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
            this.launch_arduino = new System.Windows.Forms.Button();
            this.scan_farm_button = new System.Windows.Forms.Button();
            this.visit_item_button = new System.Windows.Forms.Button();
            this.arduino_actions_label = new System.Windows.Forms.Label();
            this.rename_button = new System.Windows.Forms.Button();
            this.change_location_button = new System.Windows.Forms.Button();
            this.change_price_button = new System.Windows.Forms.Button();
            this.change_dimensions_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.add_item_container_button = new System.Windows.Forms.Button();
            this.management_panel = new System.Windows.Forms.Panel();
            this.change_market_value_button = new System.Windows.Forms.Button();
            this.market_price_label = new System.Windows.Forms.Label();
            this.purchase_price_label = new System.Windows.Forms.Label();
            this.items_item_containers_label = new System.Windows.Forms.Label();
            this.commands_items_containers_label = new System.Windows.Forms.Label();
            this.add_item_button = new System.Windows.Forms.Button();
            this.visualization_panel_label = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.launch_arduino);
            this.panel1.Controls.Add(this.scan_farm_button);
            this.panel1.Controls.Add(this.visit_item_button);
            this.panel1.Controls.Add(this.arduino_actions_label);
            this.panel1.Location = new System.Drawing.Point(12, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 207);
            this.panel1.TabIndex = 25;
            //
            // launch_arduino
            //
            this.launch_arduino.Location = new System.Drawing.Point(38, 138);
            this.launch_arduino.Name = "launch_arduino";
            this.launch_arduino.Size = new System.Drawing.Size(250, 50);
            this.launch_arduino.TabIndex = 4;
            this.launch_arduino.Text = "Launch Arduino/Microbit";
            this.launch_arduino.UseVisualStyleBackColor = true;
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
            // arduino_actions_label
            //
            this.arduino_actions_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arduino_actions_label.Location = new System.Drawing.Point(-2, -1);
            this.arduino_actions_label.Name = "arduino_actions_label";
            this.arduino_actions_label.Size = new System.Drawing.Size(338, 24);
            this.arduino_actions_label.TabIndex = 1;
            this.arduino_actions_label.Text = "3. Arduino/Microbit Controlled Device Actions";
            //
            // rename_button
            //
            this.rename_button.Location = new System.Drawing.Point(173, 87);
            this.rename_button.Name = "rename_button";
            this.rename_button.Size = new System.Drawing.Size(160, 24);
            this.rename_button.TabIndex = 14;
            this.rename_button.Text = "Rename";
            this.rename_button.UseVisualStyleBackColor = true;
            this.rename_button.Click += new System.EventHandler(this.RenameItemButtonClick);
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
            // treeView1
            //
            this.treeView1.Location = new System.Drawing.Point(3, 48);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(164, 231);
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
            this.management_panel.Controls.Add(this.change_market_value_button);
            this.management_panel.Controls.Add(this.market_price_label);
            this.management_panel.Controls.Add(this.purchase_price_label);
            this.management_panel.Controls.Add(this.items_item_containers_label);
            this.management_panel.Controls.Add(this.commands_items_containers_label);
            this.management_panel.Controls.Add(this.add_item_container_button);
            this.management_panel.Controls.Add(this.add_item_button);
            this.management_panel.Controls.Add(this.treeView1);
            this.management_panel.Controls.Add(this.delete_button);
            this.management_panel.Controls.Add(this.change_dimensions_button);
            this.management_panel.Controls.Add(this.change_price_button);
            this.management_panel.Controls.Add(this.change_location_button);
            this.management_panel.Controls.Add(this.rename_button);
            this.management_panel.Location = new System.Drawing.Point(12, 27);
            this.management_panel.Name = "management_panel";
            this.management_panel.Size = new System.Drawing.Size(338, 387);
            this.management_panel.TabIndex = 22;
            //
            // change_market_value_button
            //
            this.change_market_value_button.Location = new System.Drawing.Point(173, 255);
            this.change_market_value_button.Name = "change_market_value_button";
            this.change_market_value_button.Size = new System.Drawing.Size(160, 24);
            this.change_market_value_button.TabIndex = 38;
            this.change_market_value_button.Text = "Change Market Value";
            this.change_market_value_button.UseVisualStyleBackColor = true;
            this.change_market_value_button.Click += new System.EventHandler(this.change_market_value_button_Click);
            //
            // market_price_label
            //
            this.market_price_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.market_price_label.Location = new System.Drawing.Point(38, 331);
            this.market_price_label.Name = "market_price_label";
            this.market_price_label.Size = new System.Drawing.Size(250, 22);
            this.market_price_label.TabIndex = 37;
            this.market_price_label.Text = "Current Market Value: N/A";
            //
            // purchase_price_label
            //
            this.purchase_price_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchase_price_label.Location = new System.Drawing.Point(38, 309);
            this.purchase_price_label.Name = "purchase_price_label";
            this.purchase_price_label.Size = new System.Drawing.Size(250, 22);
            this.purchase_price_label.TabIndex = 36;
            this.purchase_price_label.Text = "Purchase Price: N/A";
            //
            // items_item_containers_label
            //
            this.items_item_containers_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.items_item_containers_label.Location = new System.Drawing.Point(-1, 0);
            this.items_item_containers_label.Name = "items_item_containers_label";
            this.items_item_containers_label.Size = new System.Drawing.Size(196, 22);
            this.items_item_containers_label.TabIndex = 35;
            this.items_item_containers_label.Text = "1. Items / Item Containers";
            //
            // commands_items_containers_label
            //
            this.commands_items_containers_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commands_items_containers_label.Location = new System.Drawing.Point(173, 48);
            this.commands_items_containers_label.Name = "commands_items_containers_label";
            this.commands_items_containers_label.Size = new System.Drawing.Size(160, 35);
            this.commands_items_containers_label.TabIndex = 34;
            this.commands_items_containers_label.Text = "Commands for Items/Containers";
            this.commands_items_containers_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // visualization_panel_label
            //
            this.visualization_panel_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualization_panel_label.Location = new System.Drawing.Point(356, 5);
            this.visualization_panel_label.Name = "visualization_panel_label";
            this.visualization_panel_label.Size = new System.Drawing.Size(148, 19);
            this.visualization_panel_label.TabIndex = 0;
            this.visualization_panel_label.Text = "2. Visualization";
            //
            // FarmDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1163, 635);
            this.Controls.Add(this.visualization_panel_label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dashboardheading_label);
            this.Controls.Add(this.visualization_panel);
            this.Controls.Add(this.management_panel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FarmDashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.management_panel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label market_price_label;
        private System.Windows.Forms.Button change_market_value_button;

        private System.Windows.Forms.Button launch_arduino;
        private System.Windows.Forms.Label purchase_price_label;

        private System.Windows.Forms.Button visit_item_button;
        private System.Windows.Forms.Button scan_farm_button;

        private System.Windows.Forms.Label arduino_actions_label;

        private System.Windows.Forms.Button rename_button;
        private System.Windows.Forms.Button change_location_button;
        private System.Windows.Forms.Button change_price_button;
        private System.Windows.Forms.Button change_dimensions_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button add_item_container_button;
        private System.Windows.Forms.Panel management_panel;
        private System.Windows.Forms.Button add_item_button;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label dashboardheading_label;

        private System.Windows.Forms.Label commands_items_containers_label;
        private System.Windows.Forms.Label items_item_containers_label;
        private System.Windows.Forms.Label visualization_panel_label;

        private System.Windows.Forms.Panel visualization_panel;

        #endregion
    }
}