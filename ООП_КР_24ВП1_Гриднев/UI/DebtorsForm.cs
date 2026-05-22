using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ООП_КР_24ВП1_Гриднев.Data;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    public partial class DebtorsForm : Form
    {
        private readonly Database db;
        private List<Loan> debtors;

        public DebtorsForm(Database database)
        {
            InitializeComponent();
            db = database;
            debtors = new List<Loan>();
            SetupGrid();
            LoadDebtors();

            btnExportPdf.Click += BtnExportPdf_Click!;
            btnClose.Click += (s, e) => Close();
        }

        private void SetupGrid()
        {
            dgvDebtors.AutoGenerateColumns = false;
            dgvDebtors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDebtors.BackgroundColor = Color.White;

            dgvDebtors.Columns.Clear();

            dgvDebtors.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 40
            });
            dgvDebtors.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClientName",
                HeaderText = "ФИО должника",
                Width = 200
            });
            dgvDebtors.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookTitle",
                HeaderText = "Название книги",
                Width = 200
            });
            dgvDebtors.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IssueDate",
                HeaderText = "Дата выдачи",
                Width = 100
            });
            dgvDebtors.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DueDate",
                HeaderText = "Срок возврата",
                Width = 100
            });
            dgvDebtors.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DaysOverdue",
                HeaderText = "Дней просрочки",
                Width = 120
            });
        }

        private void LoadDebtors()
        {
            debtors = db.GetOverdueLoans();
            dgvDebtors.DataSource = null;
            dgvDebtors.DataSource = debtors;
            lblCount.Text = $"Количество должников: {debtors.Count}";

            foreach (DataGridViewRow row in dgvDebtors.Rows)
            {
                if (row.DataBoundItem is Loan loan && loan.DaysOverdue > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    if (loan.DaysOverdue > 30)
                        row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void BtnExportPdf_Click(object? sender, EventArgs e)
        {
            if (debtors == null || debtors.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "PDF документ (*.pdf)|*.pdf",
                DefaultExt = "pdf",
                FileName = $"Должники_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                Title = "Экспорт списка должников в PDF"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfExporter.ExportDebtorsToPdf(debtors, saveDialog.FileName);
                    MessageBox.Show($"Список должников успешно экспортирован в PDF:\n{saveDialog.FileName}\n\n" +
                                  $"Экспортировано записей: {debtors.Count}",
                                  "Экспорт выполнен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте в PDF:\n{ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}