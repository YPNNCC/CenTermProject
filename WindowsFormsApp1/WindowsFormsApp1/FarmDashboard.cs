using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            livestockAreaNode.CreateChild("Cow", NodeType.Item, new Point(35, 20), new Size(40, 25), 1500, 3000);
            barnNode.CreateChild("Milk-storage", NodeType.Item, new Point(20, 250), new Size(150, 50), 10000, 20000);

            var commandCenterNode = rootNode.CreateChild("Command-center", NodeType.ItemContainer, new Point(50, 50), new Size(200, 150), 30000);
            commandCenterNode.CreateChild("Drone", NodeType.Item, new Point(25, 25), new Size(50, 50), 1500, 3000);

            rootNode.CreateChild("Crop", NodeType.Item, new Point(600, 300), new Size(150, 250), 30000, 60000);

            treeView1.Nodes.Add(rootNode);
            treeView1.Invalidate();
            treeView1.ExpandAll();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            visualization_panel.Invalidate();
            visualization_panel.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            using (var form = new ChangeDimensionsForm(selectedNode.Size))
            {
                var result = form.ShowDialog();

                if (result != DialogResult.OK) return;

                selectedNode.Size = form.NewSize;
                treeView1.Refresh();
                treeView1.ExpandAll();
                visualization_panel.Refresh();
            }
        }

        private static decimal GetPriceOfAllChildren(CustomTreeNode node)
        {
            return node.Price + node.Nodes.Cast<CustomTreeNode>().Sum(GetPriceOfAllChildren);
        }

        private void treeView1_AfterSelect_2(object sender, TreeViewEventArgs e)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            purchase_price_label.Text = $"Purchase Price: {GetPriceOfAllChildren(selectedNode)}";
            market_price_label.Text = $"Market Value: {(selectedNode.Type == NodeType.Item ? selectedNode.MarketValue.ToString() : "N/A")}";
        }

        private void DrawVisualization(Graphics graphics)
        {
            graphics.Clear(SystemColors.Window);

            foreach (CustomTreeNode node in treeView1.Nodes)
            {
                DrawNode(graphics, node);
            }
        }

        private static void DrawNode(Graphics graphics, CustomTreeNode node)
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
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            selectedNode.Remove();
            treeView1.Refresh();
            treeView1.ExpandAll();
            visualization_panel.Refresh();
        }

        private void RenameItemButtonClick(object sender, EventArgs e)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            using (var form = new RenameForm(selectedNode.Text))
            {
                var result = form.ShowDialog();

                if (result != DialogResult.OK) return;

                selectedNode.Text = form.NewName;
                treeView1.Refresh();
                treeView1.ExpandAll();
                visualization_panel.Refresh();
            }
        }

        private void ChangeItemLocationButtonClick(object sender, EventArgs e)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            using (var form = new ChangeLocationForm(selectedNode.Location))
            {
                var result = form.ShowDialog();

                if (result != DialogResult.OK) return;

                selectedNode.Location = form.NewLocation;
                treeView1.Refresh();
                treeView1.ExpandAll();
                visualization_panel.Refresh();
            }
        }

        public class ChangeDimensionsForm : BaseForm
        {
            private TextBox _textBoxX;
            private TextBox _textBoxY;
            private Label _labelX;
            private Label _labelY;

            public Size NewSize { get; private set; }

            public ChangeDimensionsForm(Size currentSize)
            {
                _textBoxX.Text = currentSize.Width.ToString();
                _textBoxY.Text = currentSize.Height.ToString();
            }

            protected override void InitializeComponent()
            {
                base.InitializeComponent();
                Text = "Change Dimensions";

                _labelX = new Label();
                _labelY = new Label();
                _textBoxX = new TextBox();
                _textBoxY = new TextBox();

                // Label for X
                _labelX.Text = "Width:";
                _labelX.Location = new Point(10, 10);
                _labelX.Size = new Size(50, 20);

                // TextBox for X
                _textBoxX.Location = new Point(70, 10);
                _textBoxX.Size = new Size(100, 20);

                // Label for Y
                _labelY.Text = "Height:";
                _labelY.Location = new Point(200, 10);
                _labelY.Size = new Size(50, 20);

                // TextBox for Y
                _textBoxY.Location = new Point(280, 10);
                _textBoxY.Size = new Size(100, 20);

                BtnOk.Location = new Point(50, 80);
                BtnCancel.Location = new Point(160, 80);

                Controls.Add(_labelX);
                Controls.Add(_textBoxX);
                Controls.Add(_labelY);
                Controls.Add(_textBoxY);
            }

            protected override void btnOK_Click(object sender, EventArgs e)
            {
                base.btnOK_Click(sender, e);

                int.TryParse(_textBoxX.Text, out int width);
                int.TryParse(_textBoxY.Text, out int height);
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

                BtnOk.Location = new Point(50, 80);
                BtnCancel.Location = new Point(160, 80);

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
            protected Button BtnOk;
            protected Button BtnCancel;

            protected BaseForm()
            {
                InitializeComponent();
            }

            protected virtual void InitializeComponent()
            {
                BtnOk = new Button();
                BtnCancel = new Button();

                BtnOk.Text = "OK";
                BtnOk.DialogResult = DialogResult.OK;
                BtnOk.Location = new Point(50, 50);
                BtnOk.Size = new Size(100, 30);

                BtnCancel.Text = "Cancel";
                BtnCancel.DialogResult = DialogResult.Cancel;
                BtnCancel.Location = new Point(160, 50);
                BtnCancel.Size = new Size(100, 30);

                // Form
                AcceptButton = BtnOk;
                CancelButton = BtnCancel;
                StartPosition = FormStartPosition.CenterParent;
                Size = new Size(300, 150);
                MinimumSize = new Size(500, 150);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;

                Controls.Add(BtnOk);
                Controls.Add(BtnCancel);

                BtnOk.Click += btnOK_Click;
                BtnCancel.Click += btnCancel_Click;
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
                    BtnOk?.Dispose();
                    BtnCancel?.Dispose();
                }

                base.Dispose(disposing);
            }
        }

        private void change_price_button_Click(object sender, EventArgs e)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;

            using (var form = new ChangePriceForm(selectedNode.Price))
            {
                var result = form.ShowDialog();

                if (result != DialogResult.OK) return;

                selectedNode.Price = form.NewPrice;
                treeView1.Refresh();
                treeView1.ExpandAll();
                visualization_panel.Refresh();
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

            decimal newPrice;
            decimal marketPrice;
            var newName = "New Item";
            if (type == NodeType.ItemContainer) newName = "New Item Container";
            var newLocation = new Point(0, 0);
            var newSize = new Size(100, 100);

            using (var form = new ChangePriceForm(0))
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) return;
                newPrice = form.NewPrice;
            }

            using (var form = new ChangePriceForm(0))
            {
                form.Text = "Change Market Price";
                var result = form.ShowDialog();
                if (result != DialogResult.OK) return;
                marketPrice = form.NewPrice;
            }

            using (var form = new RenameForm(newName))
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) return;
                newName = form.NewName;
            }

            using (var form = new ChangeLocationForm(newLocation))
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) return;
                newLocation = form.NewLocation;
            }

            using (var form = new ChangeDimensionsForm(newSize))
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) return;
                newSize = form.NewSize;
            }

            selectedNode.CreateChild(newName, type, newLocation, newSize, newPrice, marketPrice);
            treeView1.Refresh();
            treeView1.ExpandAll();
            visualization_panel.Refresh();
        }

        private readonly Queue<CustomTreeNode> _nodesToVisit = new Queue<CustomTreeNode>();
        private Timer _movementTimer;
        private Point _droneStartPosition;
        private Point _droneEndPosition;
        private const int AnimationSteps = 10;
        private int _currentStep;

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

            _droneEndPosition = selectedNode.Location;
            _droneEndPosition.X += selectedNode.Size.Width / 2 - drone.Size.Width / 2;
            _droneEndPosition.Y += selectedNode.Size.Height / 2 - drone.Size.Height / 2;

            MoveDroneTo(drone);

        }

        private void MoveDroneTo(CustomTreeNode drone)
        {
            if (_movementTimer == null)
            {
                _movementTimer = new Timer();
                _movementTimer.Interval = 100;
                _movementTimer.Tick += movementTimer_Tick;
            }

            _droneStartPosition = drone.Location;
            _currentStep = 0;
            _movementTimer.Start();
        }

        private static List<TreeNode> GetAllNodes(TreeNodeCollection nodes)
        {
            var allNodes = new List<TreeNode>();

            foreach (TreeNode node in nodes)
            {
                allNodes.Add(node);
                allNodes.AddRange(GetAllNodes(node.Nodes));
            }

            return allNodes;
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            _currentStep++;

            if (_currentStep <= AnimationSteps)
            {
                var xIncrement = (_droneEndPosition.X - _droneStartPosition.X) / (float)AnimationSteps;
                var yIncrement = (_droneEndPosition.Y - _droneStartPosition.Y) / (float)AnimationSteps;

                var drone = GetAllNodes(treeView1.Nodes).Find(v => v.Text.Contains("Drone")) as CustomTreeNode;
                if (drone == default) return;

                var nextPosition = new Point(
                    _droneStartPosition.X + (int)(xIncrement * _currentStep),
                    _droneStartPosition.Y + (int)(yIncrement * _currentStep));

                drone.Location = nextPosition;

                visualization_panel.Invalidate();
                visualization_panel.Refresh();
                return;
            }

            _movementTimer.Stop();
            if (_nodesToVisit.Count <= 0) return;
            VisitNextItem();
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

            foreach (var node in allNodes) _nodesToVisit.Enqueue(node);
            VisitNextItem();
        }

        private void VisitNextItem()
        {
            if (_nodesToVisit.Count <= 0) return;

            if (!(GetAllNodes(treeView1.Nodes).Find(v => v.Text.Contains("Drone")) is CustomTreeNode drone)) return;

            var nextItem = _nodesToVisit.Dequeue();
            _droneEndPosition = nextItem.Location;
            _droneEndPosition.X += nextItem.Size.Width / 2 - drone.Size.Width / 2;
            _droneEndPosition.Y += nextItem.Size.Height / 2 - drone.Size.Width / 2;
            MoveDroneTo(drone);
        }

        private void change_market_value_button_Click(object sender, EventArgs e)
        {
            if (!(treeView1.SelectedNode is CustomTreeNode selectedNode)) return;
            if (selectedNode.Type != NodeType.Item) return;

            using (var form = new ChangePriceForm(selectedNode.MarketValue))
            {
                form.Text = "Change Market Price";
                var result = form.ShowDialog();

                if (result != DialogResult.OK) return;

                selectedNode.MarketValue = form.NewPrice;

                purchase_price_label.Text = $"Purchase Price: {GetPriceOfAllChildren(selectedNode)}";
                market_price_label.Text = $"Market Value: {selectedNode.MarketValue}";

                treeView1.Refresh();
                treeView1.ExpandAll();
                visualization_panel.Refresh();
            }
        }
    }
}