using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    partial class BookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.NumericUpDown numPages;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblPages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.numPages = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPages)).BeginInit();
            this.SuspendLayout();

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(180, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 22);
            this.txtTitle.TabIndex = 0;

            // txtAuthor
            this.txtAuthor.Location = new System.Drawing.Point(180, 60);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(300, 22);
            this.txtAuthor.TabIndex = 1;

            // numYear
            this.numYear.Location = new System.Drawing.Point(180, 100);
            this.numYear.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            this.numYear.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 22);
            this.numYear.TabIndex = 2;
            this.numYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });

            // cmbGenre
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(Genres.List.ToArray());
            this.cmbGenre.Location = new System.Drawing.Point(180, 140);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(200, 24);
            this.cmbGenre.TabIndex = 3;

            // numPages
            this.numPages.Location = new System.Drawing.Point(180, 180);
            this.numPages.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numPages.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPages.Name = "numPages";
            this.numPages.Size = new System.Drawing.Size(120, 22);
            this.numPages.TabIndex = 4;
            this.numPages.Value = new decimal(new int[] { 100, 0, 0, 0 });

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(180, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(73, 16);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Название:";

            // lblAuthor
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(30, 63);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(45, 16);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "Автор:";

            // lblYear
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(30, 103);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(34, 16);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "Год:";

            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(30, 143);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(44, 16);
            this.lblGenre.TabIndex = 10;
            this.lblGenre.Text = "Жанр:";

            // lblPages
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(30, 183);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(114, 16);
            this.lblPages.TabIndex = 11;
            this.lblPages.Text = "Кол-во страниц:";

            // BookForm
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 291);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numPages);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Книга";
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}