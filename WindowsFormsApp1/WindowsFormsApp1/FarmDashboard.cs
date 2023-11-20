using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FarmDashboard : Form
    {
        // SINGLETON CODE:
        private static FarmDashboard _instance;
        public static FarmDashboard Instance => _instance ?? (_instance = new FarmDashboard());

        private FarmDashboard()
        {
            InitializeComponent();

            var rootNode = new CustomTreeNode("Root", NodeType.ItemContainer, new Point(0, 0), new Size(800, 600));

            var barnNode = rootNode.CreateChild("Barn", NodeType.ItemContainer, new Point(50, 275), new Size(500, 300), 50000);
            var livestockAreaNode = barnNode.CreateChild("Live-stock Area", NodeType.ItemContainer, new Point(20, 20), new Size(150, 100), 20000);
            var cowNode = livestockAreaNode.CreateChild("Cow", NodeType.Item, new Point(35, 20), new Size(40, 25), 1500);
            var milkStorageNode = barnNode.CreateChild("Milk-storage", NodeType.Item, new Point(20, 250), new Size(150, 50), 10000);

            var commandCenterNode = rootNode.CreateChild("Command-center", NodeType.ItemContainer, new Point(50, 50), new Size(200, 150), 30000);
            var droneNode = commandCenterNode.CreateChild("Drone", NodeType.Item, new Point(25, 25), new Size(50, 50), 1500);

            var cropNode = rootNode.CreateChild("Crop", NodeType.Item, new Point(600, 300), new Size(150, 250), 30000);

            treeView1.Nodes.Add(rootNode);
            treeView1.Invalidate();
            treeView1.ExpandAll();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            visualization_panel.Invalidate();
            visualization_panel.Refresh();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode is CustomTreeNode selectedNode)
            {
                using (var form = new ChangeDimensionsForm(selectedNode.Size))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        selectedNode.Size = form.NewSize;
                        treeView1.Refresh();
                        treeView1.ExpandAll();
                        visualization_panel.Refresh();
                    }
                }
            }
        }

        private void treeView1_AfterSelect_2(object sender, TreeViewEventArgs e)
        {

        }

        private void DrawVisualization(Graphics graphics)
        {
            graphics.Clear(SystemColors.Window);

            foreach (CustomTreeNode node in treeView1.Nodes)
            {
                DrawNode(graphics, node);
            }
        }

        private void DrawNode(Graphics graphics, CustomTreeNode node)
        {
            var rect = new Rectangle(node.Location, node.Size);
            graphics.DrawRectangle(Pens.Black, rect);

            using (var font = new Font("Arial", 8))
            {
                graphics.DrawString($"{node.Text} ({node.Size.Width}, {node.Size.Height})", font, Brushes.Black, node.Location);
            }

            foreach (CustomTreeNode childNode in node.Nodes)
            {
                DrawNode(graphics, childNode);
            }
        }

        private void visualization_panel_Paint(object sender, PaintEventArgs e)
        {
            DrawVisualization(e.Graphics);
        }

        private void DeleteCompButtonClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode is CustomTreeNode selectedNode)
            {
                selectedNode.Remove();
                treeView1.Refresh();
                treeView1.ExpandAll();
                visualization_panel.Refresh();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void RenameItemButtonClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode is CustomTreeNode selectedNode)
            {
                using (var form = new RenameForm(selectedNode.Text))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        selectedNode.Text = form.NewName;
                        treeView1.Refresh();
                        treeView1.ExpandAll();
                        visualization_panel.Refresh();
                    }
                }
            }
        }

        private void ChangeItemLocationButtonClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode is CustomTreeNode selectedNode)
            {
                using (var form = new ChangeLocationForm(selectedNode.Location))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        selectedNode.Location = form.NewLocation;
                        treeView1.Refresh();
                        treeView1.ExpandAll();
                        visualization_panel.Refresh();
                    }
                }
            }
        }

        public class ChangeDimensionsForm : BaseForm
        {
            private TextBox textBoxX;
            private TextBox textBoxY;
            private Label labelX;
            private Label labelY;

            public Size NewSize { get; private set; }

            public ChangeDimensionsForm(Size currentSize)
            {
                textBoxX.Text = currentSize.Width.ToString();
                textBoxY.Text = currentSize.Height.ToString();
            }

            protected override void InitializeComponent()
            {
                base.InitializeComponent();
                Text = "Change Dimensions";

                labelX = new Label();
                labelY = new Label();
                textBoxX = new TextBox();
                textBoxY = new TextBox();

                // Label for X
                labelX.Text = "Width:";
                labelX.Location = new Point(10, 10);
                labelX.Size = new Size(50, 20);

                // TextBox for X
                textBoxX.Location = new Point(70, 10);
                textBoxX.Size = new Size(100, 20);

                // Label for Y
                labelY.Text = "Height:";
                labelY.Location = new Point(200, 10);
                labelY.Size = new Size(50, 20);

                // TextBox for Y
                textBoxY.Location = new Point(280, 10);
                textBoxY.Size = new Size(100, 20);

                btnOK.Location = new Point(50, 80);
                btnCancel.Location = new Point(160, 80);

                Controls.Add(labelX);
                Controls.Add(textBoxX);
                Controls.Add(labelY);
                Controls.Add(textBoxY);
            }

            protected override void btnOK_Click(object sender, EventArgs e)
            {
                base.btnOK_Click(sender, e);

                int.TryParse(textBoxX.Text, out int width);
                int.TryParse(textBoxY.Text, out int height);
                NewSize = new Size(width, height);
            }
        }



        public class ChangeLocationForm : BaseForm
        {
            private TextBox textBoxX;
            private TextBox textBoxY;
            private Label labelX;
            private Label labelY;

            public Point NewLocation { get; private set; }

            public ChangeLocationForm(Point currentLocation)
            {
                textBoxX.Text = currentLocation.X.ToString();
                textBoxY.Text = currentLocation.Y.ToString();
            }

            protected override void InitializeComponent()
            {
                base.InitializeComponent();
                Text = "Change Location";

                labelX = new Label();
                labelY = new Label();
                textBoxX = new TextBox();
                textBoxY = new TextBox();

                // Label for X
                labelX.Text = "X:";
                labelX.Location = new Point(10, 10);
                labelX.Size = new Size(20, 20);

                // TextBox for X
                textBoxX.Location = new Point(40, 10);
                textBoxX.Size = new Size(100, 20);

                // Label for Y
                labelY.Text = "Y:";
                labelY.Location = new Point(150, 10);
                labelY.Size = new Size(20, 20);

                // TextBox for Y
                textBoxY.Location = new Point(180, 10);
                textBoxY.Size = new Size(100, 20);

                btnOK.Location = new Point(50, 80);
                btnCancel.Location = new Point(160, 80);

                Controls.Add(labelX);
                Controls.Add(textBoxX);
                Controls.Add(labelY);
                Controls.Add(textBoxY);
            }

            protected override void btnOK_Click(object sender, EventArgs e)
            {
                base.btnOK_Click(sender, e);

                int.TryParse(textBoxX.Text, out int x);
                int.TryParse(textBoxY.Text, out int y);
                NewLocation = new Point(x, y);
            }
        }

        public class RenameForm : BaseForm
        {
            private TextBox textBox;

            public string NewName { get; private set; }

            public RenameForm(string currentName)
            {
                textBox.Text = currentName;
            }

            protected override void InitializeComponent()
            {
                base.InitializeComponent();
                Text = "Rename";

                textBox = new TextBox();

                // TextBox
                textBox.Location = new Point(10, 10);
                textBox.Size = new Size(100, 20);
                textBox.Text = NewName;
                Controls.Add(textBox);
            }

            protected override void btnOK_Click(object sender, EventArgs e)
            {
                base.btnOK_Click(sender, e);
                NewName = textBox.Text;
            }
        }

        public class ChangePriceForm : BaseForm
        {
            private TextBox textBox;

            public decimal NewPrice { get; private set; }

            public ChangePriceForm(decimal currentPrice)
            {
                textBox.Text = currentPrice.ToString();
            }

            protected override void InitializeComponent()
            {
                base.InitializeComponent();
                Text = "Change Price";

                textBox = new TextBox();

                // TextBox
                textBox.Location = new Point(10, 10);
                textBox.Size = new Size(100, 20);
                Controls.Add(textBox);
            }

            protected override void btnOK_Click(object sender, EventArgs e)
            {
                base.btnOK_Click(sender, e);
                NewPrice = decimal.Parse(textBox.Text);
            }
        }

        public class BaseForm : Form
        {
            public Button btnOK;
            public Button btnCancel;

            public BaseForm()
            {
                InitializeComponent();
            }

            protected virtual void InitializeComponent()
            {
                btnOK = new Button();
                btnCancel = new Button();

                btnOK.Text = "OK";
                btnOK.DialogResult = DialogResult.OK;
                btnOK.Location = new Point(50, 50);
                btnOK.Size = new Size(100, 30);

                btnCancel.Text = "Cancel";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(160, 50);
                btnCancel.Size = new Size(100, 30);

                // Form
                AcceptButton = btnOK;
                CancelButton = btnCancel;
                StartPosition = FormStartPosition.CenterParent;
                Size = new Size(300, 150);
                MinimumSize = new Size(500, 150);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;

                Controls.Add(btnOK);
                Controls.Add(btnCancel);

                btnOK.Click += btnOK_Click;
                btnCancel.Click += btnCancel_Click;
            }

            protected virtual void btnOK_Click(object sender, EventArgs e)
            {
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                Close();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    btnOK?.Dispose();
                    btnCancel?.Dispose();
                }

                base.Dispose(disposing);
            }
        }

        private void change_price_button_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode is CustomTreeNode selectedNode)
            {
                using (var form = new ChangePriceForm(selectedNode.Price))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        selectedNode.Price = form.NewPrice;
                        treeView1.Refresh();
                        treeView1.ExpandAll();
                        visualization_panel.Refresh();
                    }
                }
            }
        }

        private void add_item_button_Click_1(object sender, EventArgs e)
        {
            HandleAddObject(NodeType.Item);
        }

        private void add_item_container_button_Click(object sender, EventArgs e)
        {
            HandleAddObject(NodeType.ItemContainer);
        }

        private void HandleAddObject(NodeType type)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            var newPrice = 0m;
            var newName = "New Item";
            if (type == NodeType.ItemContainer) newName = "New Item Container";
            var newLocation = new Point(0, 0);
            var newSize = new Size(100, 100);

            using (var form = new ChangePriceForm(0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) newPrice = form.NewPrice;
                if (result == DialogResult.Cancel) return;
            }

            using (var form = new RenameForm(newName))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) newName = form.NewName;
                if (result == DialogResult.Cancel) return;
            }

            using (var form = new ChangeLocationForm(newLocation))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) newLocation = form.NewLocation;
                if (result == DialogResult.Cancel) return;
            }

            using (var form = new ChangeDimensionsForm(newSize))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) newSize = form.NewSize;
                if (result == DialogResult.Cancel) return;
            }

            selectedNode.CreateChild(newName, type, newLocation, newSize, newPrice);
            treeView1.Refresh();
            treeView1.ExpandAll();
            visualization_panel.Refresh();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private Queue<CustomTreeNode> nodesToVisit = new Queue<CustomTreeNode>();
        private Timer movementTimer;
        private Point droneStartPosition;
        private Point droneEndPosition;
        private int animationSteps = 10;
        private int currentStep = 0;

        private void visit_item_button_Click(object sender, EventArgs e)
        {
            var treeSelected = treeView1.SelectedNode;
            if (!(treeSelected is CustomTreeNode selectedNode))
            {
                MessageBox.Show("Please select an item to visit");
                return;
            }

            var drone = GetAllNodes(treeView1.Nodes).Find(v => v.Text.Contains("Drone")) as CustomTreeNode;
            if (drone == default)
            {
                MessageBox.Show("No drone found");
                return;
            }

            droneEndPosition = selectedNode.Location;
            droneEndPosition.X += selectedNode.Size.Width / 2 - drone.Size.Width / 2;
            droneEndPosition.Y += selectedNode.Size.Height / 2 - drone.Size.Height / 2;

            MoveDroneTo(drone);

        }

        private void MoveDroneTo(CustomTreeNode drone)
        {
            if (movementTimer == null)
            {
                movementTimer = new Timer();
                movementTimer.Interval = 100;
                movementTimer.Tick += movementTimer_Tick;
            }

            droneStartPosition = drone.Location;
            currentStep = 0;
            movementTimer.Start();
        }

        private List<TreeNode> GetAllNodes(TreeNodeCollection nodes)
        {
            List<TreeNode> allNodes = new List<TreeNode>();

            foreach (TreeNode node in nodes)
            {
                allNodes.Add(node); // Add the current node
                allNodes.AddRange(GetAllNodes(node.Nodes)); // Recursively add child nodes
            }

            return allNodes;
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            currentStep++;

            if (currentStep <= animationSteps)
            {
                float xIncrement = (droneEndPosition.X - droneStartPosition.X) / (float)animationSteps;
                float yIncrement = (droneEndPosition.Y - droneStartPosition.Y) / (float)animationSteps;

                var drone = GetAllNodes(treeView1.Nodes).Find(v => v.Text.Contains("Drone")) as CustomTreeNode;
                if (drone == default) return;

                var nextPosition = new Point(
                    droneStartPosition.X + (int)(xIncrement * currentStep),
                    droneStartPosition.Y + (int)(yIncrement * currentStep));

                drone.Location = nextPosition;

                visualization_panel.Invalidate();
                visualization_panel.Refresh();
            }
            else
            {
                movementTimer.Stop();
                if (nodesToVisit.Count > 0)
                {
                    VisitNextItem();
                }
            }
        }

        private void scan_farm_button_Click(object sender, EventArgs e)
        {
            var drone = GetAllNodes(treeView1.Nodes).Find(v => v.Text.Contains("Drone")) as CustomTreeNode;
            if (drone == default)
            {
                MessageBox.Show("No drone found");
                return;
            }

            var allNodes = GetAllNodes(treeView1.Nodes)
                .OfType<CustomTreeNode>()
                .Where(node => !node.Text.Contains("Drone"));

            foreach (var node in allNodes)
            {
                nodesToVisit.Enqueue(node);
            }

            VisitNextItem();
        }

        private void VisitNextItem()
        {
            if (nodesToVisit.Count <= 0) return;

            var drone = GetAllNodes(treeView1.Nodes).Find(v => v.Text.Contains("Drone")) as CustomTreeNode;
            if (drone == default) return;

            var nextItem = nodesToVisit.Dequeue();
            droneEndPosition = nextItem.Location;
            droneEndPosition.X += nextItem.Size.Width / 2 - drone.Size.Width / 2;
            droneEndPosition.Y += nextItem.Size.Height / 2 - drone.Size.Width / 2;
            MoveDroneTo(drone);
        }
    }
}