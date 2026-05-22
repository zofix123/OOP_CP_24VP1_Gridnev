namespace ООП_КР_24ВП1_Гриднев.UI
{
    partial class DebtorsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDebtors;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvDebtors = new System.Windows.Forms.DataGridView();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtors)).BeginInit();
            this.SuspendLayout();

            this.dgvDebtors.AllowUserToAddRows = false;
            this.dgvDebtors.AllowUserToDeleteRows = false;
            this.dgvDebtors.Location = new System.Drawing.Point(12, 80);
            this.dgvDebtors.Name = "dgvDebtors";
            this.dgvDebtors.ReadOnly = true;
            this.dgvDebtors.Size = new System.Drawing.Size(860, 400);
            this.dgvDebtors.TabIndex = 0;

            this.btnExportPdf.BackColor = System.Drawing.Color.LightGreen;
            this.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPdf.Location = new System.Drawing.Point(12, 500);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(150, 35);
            this.btnExportPdf.TabIndex = 1;
            this.btnExportPdf.Text = "Экспорт в PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;

            this.btnClose.Location = new System.Drawing.Point(180, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "СПИСОК ДОЛЖНИКОВ";

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(12, 50);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(152, 17);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Количество должников: 0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.dgvDebtors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebtorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчет по должникам";

            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}