namespace librarymanager
{
    partial class LibraryManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.findBookPage = new System.Windows.Forms.TabPage();
      this.ManagePage = new System.Windows.Forms.TabPage();
      this.OptionPage = new System.Windows.Forms.TabPage();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.tabControl1.SuspendLayout();
      this.findBookPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.findBookPage);
      this.tabControl1.Controls.Add(this.ManagePage);
      this.tabControl1.Controls.Add(this.OptionPage);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(994, 588);
      this.tabControl1.TabIndex = 0;
      // 
      // findBookPage
      // 
      this.findBookPage.Controls.Add(this.menuStrip1);
      this.findBookPage.Location = new System.Drawing.Point(4, 24);
      this.findBookPage.Name = "findBookPage";
      this.findBookPage.Padding = new System.Windows.Forms.Padding(3);
      this.findBookPage.Size = new System.Drawing.Size(986, 560);
      this.findBookPage.TabIndex = 0;
      this.findBookPage.Text = "Find Book";
      this.findBookPage.UseVisualStyleBackColor = true;
      this.findBookPage.Click += new System.EventHandler(this.tabPage1_Click);
      // 
      // ManagePage
      // 
      this.ManagePage.Location = new System.Drawing.Point(4, 24);
      this.ManagePage.Name = "ManagePage";
      this.ManagePage.Padding = new System.Windows.Forms.Padding(3);
      this.ManagePage.Size = new System.Drawing.Size(986, 560);
      this.ManagePage.TabIndex = 1;
      this.ManagePage.Text = "Manage";
      this.ManagePage.UseVisualStyleBackColor = true;
      // 
      // OptionPage
      // 
      this.OptionPage.Location = new System.Drawing.Point(4, 24);
      this.OptionPage.Name = "OptionPage";
      this.OptionPage.Padding = new System.Windows.Forms.Padding(3);
      this.OptionPage.Size = new System.Drawing.Size(986, 560);
      this.OptionPage.TabIndex = 2;
      this.OptionPage.Text = "Options";
      this.OptionPage.UseVisualStyleBackColor = true;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Location = new System.Drawing.Point(3, 3);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(980, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // LibraryManager
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(992, 583);
      this.Controls.Add(this.tabControl1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "LibraryManager";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tabControl1.ResumeLayout(false);
      this.findBookPage.ResumeLayout(false);
      this.findBookPage.PerformLayout();
      this.ResumeLayout(false);

        }

    #endregion

    private TabControl tabControl1;
    private TabPage findBookPage;
    private TabPage ManagePage;
    private TabPage OptionPage;
    private MenuStrip menuStrip1;
  }
}