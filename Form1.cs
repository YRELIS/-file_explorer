using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace FileExplorer
{
    public partial class MainForm : Form
    {

        List<string> _pathMove = new List<string>();
        int _moveIndex = -1;
        string _currentPath = "";
        ImageList _imageList = new ImageList();

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadBaseTree();

            _treeView.NodeMouseDoubleClick += _treeView_NodeMouseDoubleClick;
            _listView.DoubleClick += _listView_DoubleClick;

            _pathText.KeyUp += _pathText_KeyUp;
            _goButton.Click += _goButton_Click;

            _backButton.Click += _backButton_Click;
            _forwardButton.Click += _forwardButton_Click;

            _imageList.Images.Add(Image.FromFile("folder.ico"));
            _imageList.Images.Add(Image.FromFile("disk.png"));

            _treeView.ImageList = _imageList;
        }

        private void _goButton_Click(object sender, EventArgs e)
        {
            goPath(_pathText.Text, true);
        }

        private void _forwardButton_Click(object sender, EventArgs e)
        {
            if (_moveIndex == -1 || _pathMove.Count == _moveIndex + 1) return;
            goPath(_pathMove[++_moveIndex]);
        }

        private void _backButton_Click(object sender, EventArgs e)
        {
            if (_moveIndex == -1 || _moveIndex - 1 == -1) return;
            goPath(_pathMove[--_moveIndex]);
        }

        private void _pathText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                goPath(_pathText.Text, true);
            }
        }

        void goPath(string path, bool savePath = false)
        {
            try
            {
                string[] sPath = path.Split('\\');
                string drive = sPath[0] + "\\";

                TreeNode tn = null;
                foreach(TreeNode t in _treeView.Nodes)
                {
                    if(t.Text == drive)
                    {
                        tn = t;
                        break;
                    }
                }

                loadTreeNode(tn);
                for (int i = 1; i < sPath.Length; i++)
                {
                    foreach (TreeNode t in tn.Nodes)
                    {
                        if (t.Text == sPath[i])
                        {
                            tn = t;
                            break;
                        }
                    }
                    loadTreeNode(tn);
                    if (tn == null) throw new Exception();
                }
                if (savePath)
                {
                    _pathMove.RemoveRange(_moveIndex + 1, _pathMove.Count - _moveIndex - 1);
                    _pathMove.Add(path);
                    _moveIndex = _pathMove.Count - 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный путь");
            }

        }

        private void _listView_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection ic = _listView.SelectedItems;
            if(ic.Count > 0)
            {
                try
                {
                    ListViewItem li = ic[0];
                    string type = li.SubItems[2].Text;
                    string fileName = li.Text;
                    string fullFileName = _currentPath + (_currentPath.LastIndexOf('\\') == _currentPath.Length - 1 ? "" : "\\") + fileName + (type == "" ? "" : "." + type);
                    System.Diagnostics.Process.Start(fullFileName);
                }
                catch (Exception)
                {

                }
            }
        }

        void loadTreeNode(TreeNode tn, bool savePath = false)
        {
            if (tn != null)
            {
                string path = tn.Text;
                TreeNode parent = tn.Parent;
                while (parent != null)
                {
                    path = path.Insert(0, parent.Text + (parent.Text.IndexOf('\\') == -1 ? "\\" : ""));
                    parent = parent.Parent;
                }
                try
                {
                    setFilesToListFromDir(path);
                    string[] dirs = getDirsInDir(path);
                    if (tn.Nodes.Count == 0)
                    {
                        foreach (string dir in dirs)
                        {
                            string[] splited = dir.Split('\\');
                            string dirName = splited[splited.Length - 1];
                            tn.Nodes.Add(dirName).ImageIndex = 0;
                        }
                    }
                    _currentPath = path;
                    _pathText.Text = _currentPath;
                    if (savePath) {
                        _pathMove.RemoveRange(_moveIndex + 1, _pathMove.Count - _moveIndex - 1);
                        _pathMove.Add(_currentPath);
                        _moveIndex = _pathMove.Count - 1;
                    }
                    if (_pathMove.Count > 20) _pathMove.RemoveAt(0);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Требуются права администратора");
                }
                catch (Exception)
                {
                    throw;
                }
                tn.Expand();
            }
        }

        private void _treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            loadTreeNode(_treeView.SelectedNode, true);
        }

        void setFilesToListFromDir(string dir)
        {
            _listView.Items.Clear();
            string[] files = Directory.GetFiles(dir);
            foreach(string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string[] name = fi.Name.Split('.');
                for(int i = 1; i < name.Length - 1; i++)
                {
                    name[0] += "." + name[i];
                }
                string[] row = { fi.Length.ToString(), (name.Length > 1 ? name[name.Length - 1] : "") };
                _listView.Items.Add(name[0]).SubItems.AddRange(row);
            }
        }

        string [] getLogicalDrives()
        {
            return Directory.GetLogicalDrives();
        }

        void startProcess(string fullFilePath)
        {
            System.Diagnostics.Process.Start(fullFilePath);
        }

        void loadBaseTree()
        {
            string[] localDirs = getLogicalDrives();
            foreach (string s in localDirs)
            {
                TreeNode tn = _treeView.Nodes.Add(s);
                tn.ImageIndex = 1;
            }
        }

        string[] getDirsInDir(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            return dirs;
        }

        private void _goButton_Click_1(object sender, EventArgs e)
        {

        }

        private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
