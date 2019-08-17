using LiteDB;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiteDBBrowser
{
    public partial class FrmBrowseDB : Form
    {
        private readonly Size TvDBOffset;

        public FrmBrowseDB()
        {
            InitializeComponent();
            TvDBOffset = Size - TvDB.Size;
            LblNodeCount.Text = string.Empty;
        }

        private void FrmBrowseDB_Resize(object sender, EventArgs e)
        {
            TvDB.Size = Size - TvDBOffset;
        }

        private void BtnOpenDatabase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DereferenceLinks = true,
                Multiselect = false,
                ShowHelp = false,
                ShowReadOnly = false,
                SupportMultiDottedExtensions = true,
                Title = "Please choose a LiteDB to open"
            })
            {
                DialogResult result = ofd.ShowDialog(this);
                if ((result == DialogResult.OK) || (result == DialogResult.Yes))
                {
                    string pwd = string.Empty;
                    if (!ValidDB(ofd.FileName))
                    {
                        MessageBox.Show("This does not appear to be a valid LiteDB database.");
                        return;
                    }
                    if (NeedPassword(ofd.FileName))
                    {
                        using (FrmPassword pwdDlg = new FrmPassword())
                        {
                            pwdDlg.ShowDialog(this);
                            pwd = pwdDlg.TbPassword.Text;
                        }
                        if (!PasswordCorrect(ofd.FileName, pwd))
                        {
                            MessageBox.Show("It appears that this password is incorrect.");
                            return;
                        }
                        DBParse db = new DBParse();
                        TvDB.Nodes.Clear();
                        db.GetCollections(ofd.FileName, pwd).ForEach(n => TvDB.Nodes.Add(n));
                        TvDB.Nodes.OfType<TreeNode>().ToList().ForEach(n =>
                        {
                            TreeNode placeHolder = new TreeNode("Placeholder");
                            n.Nodes.Add(placeHolder);
                            Tuple<bool, string, string> data = new Tuple<bool, string, string>(false, ofd.FileName, pwd);
                            n.Tag = data;
                        });
                    }
                }
            }
        }

        private void ParseMethod(TreeNode n
            , string fileName
            , string password)
        {
            DBParse db = new DBParse();
            db.ParseCollection(n, fileName, password);
            Tuple<bool, string, string> data = n.Tag as Tuple<bool, string, string>;
            n.Tag = new Tuple<bool, string, string>(true, data.Item2, data.Item3);
            SlStatus.Text = "Complete";
        }

        private bool ValidDB(string fileName)
        {
            try
            {
                using (LiteEngine engine = new LiteEngine(fileName))
                {
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not a LiteDB database")) return false;
            }
            return true;
        }

        private bool NeedPassword(string fileName)
        {
            try
            {
                using (LiteEngine engine = new LiteEngine(fileName))
                {
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Invalid database password.")) return true;
            }
            return false;
        }

        private bool PasswordCorrect(string fileName, string password)
        {
            try
            {
                using (LiteEngine engine = new LiteEngine(fileName, password))
                {
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Invalid database password.")) return false;
            }
            return true;
        }

        private void FrmBrowseDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TvDB_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (!(e.Node.Tag is null))
            {
                Tuple<bool, string, string> data = e.Node.Tag as Tuple<bool, string, string>;
                if (!data.Item1)
                {
                    SlStatus.Text = "Processing . . .";
                    Application.DoEvents();
                    e.Node.Nodes.RemoveAt(0);
                    TvDB.SuspendLayout();
                    ParseMethod(e.Node, data.Item2, data.Item3);
                    TvDB.ResumeLayout(false);
                    int nodeCount = 0;
                    TvDB.Nodes.OfType<TreeNode>().ToList().ForEach(n =>
                    {
                        nodeCount += (n.GetNodeCount(true) + 1);
                    });
                    LblNodeCount.Text = $"Current node count: {nodeCount}";
                }
            }
        }
    }
}