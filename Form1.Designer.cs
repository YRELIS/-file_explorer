namespace FileExplorer
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._backButton = new System.Windows.Forms.Button();
            this._forwardButton = new System.Windows.Forms.Button();
            this._pathText = new System.Windows.Forms.TextBox();
            this._goButton = new System.Windows.Forms.Button();
            this._listView = new System.Windows.Forms.ListView();
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._treeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(13, 12);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(27, 23);
            this._backButton.TabIndex = 0;
            this._backButton.Text = "<-";
            this._backButton.UseVisualStyleBackColor = true;
            // 
            // _forwardButton
            // 
            this._forwardButton.Location = new System.Drawing.Point(46, 12);
            this._forwardButton.Name = "_forwardButton";
            this._forwardButton.Size = new System.Drawing.Size(27, 23);
            this._forwardButton.TabIndex = 0;
            this._forwardButton.Text = "->";
            this._forwardButton.UseVisualStyleBackColor = true;
            // 
            // _pathText
            // 
            this._pathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pathText.Location = new System.Drawing.Point(80, 12);
            this._pathText.Name = "_pathText";
            this._pathText.Size = new System.Drawing.Size(582, 20);
            this._pathText.TabIndex = 1;
            this._pathText.Text = "Мой компьютер";
            // 
            // _goButton
            // 
            this._goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._goButton.Location = new System.Drawing.Point(668, 12);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(30, 23);
            this._goButton.TabIndex = 2;
            this._goButton.Text = "Go";
            this._goButton.UseVisualStyleBackColor = true;
            this._goButton.Click += new System.EventHandler(this._goButton_Click_1);
            // 
            // _listView
            // 
            this._listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file,
            this.size,
            this.type});
            this._listView.Location = new System.Drawing.Point(199, 58);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(499, 363);
            this._listView.TabIndex = 3;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.SelectedIndexChanged += new System.EventHandler(this._listView_SelectedIndexChanged);
            // 
            // file
            // 
            this.file.Text = "Файл";
            this.file.Width = 183;
            // 
            // size
            // 
            this.size.Text = "Размер (МБ)";
            this.size.Width = 109;
            // 
            // type
            // 
            this.type.Text = "Тип";
            this.type.Width = 98;
            // 
            // _treeView
            // 
            this._treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._treeView.Location = new System.Drawing.Point(13, 58);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(180, 363);
            this._treeView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Каталоги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Файлы";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._treeView);
            this.Controls.Add(this._listView);
            this.Controls.Add(this._goButton);
            this.Controls.Add(this._pathText);
            this.Controls.Add(this._forwardButton);
            this.Controls.Add(this._backButton);
            this.Name = "MainForm";
            this.Text = "Файловый менеджер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Button _forwardButton;
        private System.Windows.Forms.TextBox _pathText;
        private System.Windows.Forms.Button _goButton;
        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader type;
    }
}

