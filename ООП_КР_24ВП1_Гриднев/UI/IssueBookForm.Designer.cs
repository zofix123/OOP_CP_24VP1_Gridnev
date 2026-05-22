namespace ООП_КР_24ВП1_Гриднев.UI
{
    partial class IssueBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblDays;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            this.SuspendLayout();

            // cmbBook
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(120, 20);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(300, 24);
            this.cmbBook.TabIndex = 0;

            // cmbClient
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(120, 60);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(300, 24);
            this.cmbClient.TabIndex = 1;

            // numDays
            this.numDays.Location = new System.Drawing.Point(120, 100);
            this.numDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDays.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(80, 22);
            this.numDays.TabIndex = 2;
            this.numDays.Value = new decimal(new int[] { 14, 0, 0, 0 });

            // btnIssue
            this.btnIssue.Location = new System.Drawing.Point(120, 150);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(100, 30);
            this.btnIssue.TabIndex = 3;
            this.btnIssue.Text = "Выдать";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(230, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;

            // lblBook
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(30, 23);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(50, 16);
            this.lblBook.TabIndex = 5;
            this.lblBook.Text = "Книга:";

            // lblClient
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(30, 63);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(55, 16);
            this.lblClient.TabIndex = 6;
            this.lblClient.Text = "Клиент:";

            // lblDays
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(30, 103);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(85, 16);
            this.lblDays.TabIndex = 7;
            this.lblDays.Text = "Срок (дней):";

            // IssueBookForm
            this.AcceptButton = this.btnIssue;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(454, 201);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.numDays);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.cmbBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выдача книги";
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}