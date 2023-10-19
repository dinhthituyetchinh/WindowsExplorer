using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemWindowExplorer
{
    public partial class frmWindowExplorer : Form
    {
        public frmWindowExplorer()
        {
            InitializeComponent();
        }

        private void frmWindowExplorer_Load(object sender, EventArgs e)
        {
            treeView1.TabStop = false;

        }
        public IEnumerable<TreeNode> GetChildren(TreeNode Parent)
        {
            return Parent.Nodes.Cast<TreeNode>().Concat(
                   Parent.Nodes.Cast<TreeNode>().SelectMany(GetChildren));
        }
        static Dictionary<string, int> keyValuePairs = new Dictionary<string, int>()
            {
                {"New Folder", 16 },
                {"txt", 14},
                { "rar", 17 },
                {"Picture", 7},
                {"GitHub", 11},
                {"VS Code", 13},
                {"Chrome", 15},
                {"Video", 6},
                {"Music", 9}
            };

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                if (e.Node.Nodes.Count > 4)
                {
                    break;
                }
                TreeNode treeNode = new TreeNode();
                //treeNode.Text =  keyValuePairs.Keys.ToList().OrderBy(s => Guid.NewGuid()).ToList().FirstOrDefault();
                treeNode.ImageIndex = keyValuePairs.Values.ToList().OrderBy(s => Guid.NewGuid()).ToList().FirstOrDefault();
                treeNode.Name = "2" + keyValuePairs.Keys.ToList().OrderBy(s => Guid.NewGuid()).ToList().FirstOrDefault();
                e.Node.Nodes.Add(treeNode);

            }

            string selectedNodeText = e.Node.Text;
            var child = GetChildren(e.Node);
            int index = 0;
            int count = 0;
            foreach (var item in child)
            {
                if (item.Name.StartsWith("1"))
                {
                    index = 1;
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.ImageIndex = item.ImageIndex;
                    listViewItem.Text = item.Text;
                    listView1.Items.Add(listViewItem);
                    count++;                  
                }
            }
            toolStripStatusLabel1.Text = count.ToString() + " items";
            if (index == 1)
            {
                return;
            }
            foreach (var item in child)
            {
                if (item.Name.StartsWith("2"))
                {
                    index = 2;
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.ImageIndex = item.ImageIndex;
                    listViewItem.Text = item.Text;
                    listView1.Items.Add(listViewItem);
                    count++;
                }
            }
            toolStripStatusLabel1.Text = count.ToString() + " items";
            if (index == 2)
            {
                return;
            }
            foreach (var item in child)
            {
                if (item.Name.StartsWith("3"))
                {

                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.ImageIndex = item.ImageIndex;
                    listViewItem.Text = item.Text;
                    listView1.Items.Add(listViewItem);
                    count++;
                }
            }
            toolStripStatusLabel1.Text = count.ToString() + " items";

        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            //if(treeView1.Nodes[1].Name == "NodeThisPC")
            //{
            //    MessageBox.Show("abc");
            //}
        }
        private void XoaTreeNode(TreeNode node)
        {
            if (node != null)
            {
                if (node.Parent != null)
                {
                    node.Parent.Nodes.Remove(node);
                }
                else
                {
                    treeView1.Nodes.Remove(node);
                }
            }
        }
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.Remove();
            }

        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
