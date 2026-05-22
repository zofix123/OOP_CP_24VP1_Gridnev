using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Вкладки
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabLoans;

        // Вкладка Книги
        private System.Windows.Forms.DataGridView dgvBooks;
        public System.Windows.Forms.Panel panelBooksTop;
        private System.Windows.Forms.Button btnResetBooks;
        private System.Windows.Forms.GroupBox groupSortOrder;
        private System.Windows.Forms.RadioButton rbDesc;
        private System.Windows.Forms.RadioButton rbAsc;
        private System.Windows.Forms.Button btnFilterGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.Label lblSearchBook;

        // Вкладка Клиенты
        private System.Windows.Forms.DataGridView dgvClients;
        public System.Windows.Forms.Panel panelClientsSearch;
        private System.Windows.Forms.TextBox txtSearchClient;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.Label lblSearchClient;

        // Вкладка Выдачи
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnShowDebtors;
        private System.Windows.Forms.Button btnRefreshLoans;

        // Общие кнопки (переиспользуемые)
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        // Кнопки БД
        private System.Windows.Forms.Button btnDeleteDatabase;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnExportPdf;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabBooks = new TabPage();
            dgvBooks = new DataGridView();
            panelBooksTop = new Panel();
            btnResetBooks = new Button();
            groupSortOrder = new GroupBox();
            rbDesc = new RadioButton();
            rbAsc = new RadioButton();
            btnFilterGenre = new Button();
            lblGenre = new Label();
            cmbGenre = new ComboBox();
            lblSort = new Label();
            cmbSort = new ComboBox();
            btnSearchBook = new Button();
            txtSearchBook = new TextBox();
            lblSearchBook = new Label();
            tabClients = new TabPage();
            dgvClients = new DataGridView();
            panelClientsSearch = new Panel();
            lblSearchClient = new Label();
            txtSearchClient = new TextBox();
            btnSearchClient = new Button();
            tabLoans = new TabPage();
            dgvLoans = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnIssueBook = new Button();
            btnReturnBook = new Button();
            btnShowDebtors = new Button();
            btnRefreshLoans = new Button();
            btnDeleteDatabase = new Button();
            btnSaveToFile = new Button();
            btnExportPdf = new Button();
            tabControl.SuspendLayout();
            tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panelBooksTop.SuspendLayout();
            groupSortOrder.SuspendLayout();
            tabClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            panelClientsSearch.SuspendLayout();
            tabLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabBooks);
            tabControl.Controls.Add(tabClients);
            tabControl.Controls.Add(tabLoans);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 600);
            tabControl.TabIndex = 0;
            // 
            // tabBooks
            // 
            tabBooks.Controls.Add(dgvBooks);
            tabBooks.Controls.Add(panelBooksTop);
            tabBooks.Location = new Point(4, 29);
            tabBooks.Margin = new Padding(3, 4, 3, 4);
            tabBooks.Name = "tabBooks";
            tabBooks.Size = new Size(992, 567);
            tabBooks.TabIndex = 0;
            tabBooks.Text = "Книги";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeight = 29;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(0, 125);
            dgvBooks.Margin = new Padding(3, 4, 3, 4);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(992, 442);
            dgvBooks.TabIndex = 1;
            // 
            // panelBooksTop
            // 
            panelBooksTop.Controls.Add(btnResetBooks);
            panelBooksTop.Controls.Add(groupSortOrder);
            panelBooksTop.Controls.Add(btnFilterGenre);
            panelBooksTop.Controls.Add(lblGenre);
            panelBooksTop.Controls.Add(cmbGenre);
            panelBooksTop.Controls.Add(lblSort);
            panelBooksTop.Controls.Add(cmbSort);
            panelBooksTop.Controls.Add(btnSearchBook);
            panelBooksTop.Controls.Add(txtSearchBook);
            panelBooksTop.Controls.Add(lblSearchBook);
            panelBooksTop.Dock = DockStyle.Top;
            panelBooksTop.Location = new Point(0, 0);
            panelBooksTop.Margin = new Padding(3, 4, 3, 4);
            panelBooksTop.Name = "panelBooksTop";
            panelBooksTop.Size = new Size(992, 125);
            panelBooksTop.TabIndex = 0;
            // 
            // btnResetBooks
            // 
            btnResetBooks.Location = new Point(870, 69);
            btnResetBooks.Margin = new Padding(3, 4, 3, 4);
            btnResetBooks.Name = "btnResetBooks";
            btnResetBooks.Size = new Size(100, 38);
            btnResetBooks.TabIndex = 9;
            btnResetBooks.Text = "Сброс";
            btnResetBooks.UseVisualStyleBackColor = true;
            btnResetBooks.Click += btnResetBooks_Click;
            // 
            // groupSortOrder
            // 
            groupSortOrder.Controls.Add(rbDesc);
            groupSortOrder.Controls.Add(rbAsc);
            groupSortOrder.Location = new Point(316, 54);
            groupSortOrder.Margin = new Padding(3, 4, 3, 4);
            groupSortOrder.Name = "groupSortOrder";
            groupSortOrder.Padding = new Padding(3, 4, 3, 4);
            groupSortOrder.Size = new Size(200, 67);
            groupSortOrder.TabIndex = 8;
            groupSortOrder.TabStop = false;
            groupSortOrder.Text = "Порядок";
            // 
            // rbDesc
            // 
            rbDesc.AutoSize = true;
            rbDesc.Location = new Point(6, 43);
            rbDesc.Margin = new Padding(3, 4, 3, 4);
            rbDesc.Name = "rbDesc";
            rbDesc.Size = new Size(127, 24);
            rbDesc.TabIndex = 1;
            rbDesc.Text = "По убыванию";
            rbDesc.UseVisualStyleBackColor = true;
            rbDesc.CheckedChanged += rbSortOrder_CheckedChanged;
            // 
            // rbAsc
            // 
            rbAsc.AutoSize = true;
            rbAsc.Checked = true;
            rbAsc.Location = new Point(6, 22);
            rbAsc.Margin = new Padding(3, 4, 3, 4);
            rbAsc.Name = "rbAsc";
            rbAsc.Size = new Size(146, 24);
            rbAsc.TabIndex = 0;
            rbAsc.TabStop = true;
            rbAsc.Text = "По возрастанию";
            rbAsc.UseVisualStyleBackColor = true;
            rbAsc.CheckedChanged += rbSortOrder_CheckedChanged;
            // 
            // btnFilterGenre
            // 
            btnFilterGenre.Location = new Point(540, 69);
            btnFilterGenre.Margin = new Padding(3, 4, 3, 4);
            btnFilterGenre.Name = "btnFilterGenre";
            btnFilterGenre.Size = new Size(100, 38);
            btnFilterGenre.TabIndex = 7;
            btnFilterGenre.Text = "Фильтр";
            btnFilterGenre.UseVisualStyleBackColor = true;
            btnFilterGenre.Click += btnFilterGenre_Click;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(536, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(51, 20);
            lblGenre.TabIndex = 6;
            lblGenre.Text = "Жанр:";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Items.AddRange(new object[] { "Роман", "Повесть", "Рассказ", "Поэзия", "Драма", "Фантастика", "Детектив", "Учебник", "Научная литература", "Справочник", "Энциклопедия", "Биография", "Исторический роман", "Приключения", "Триллер", "Ужасы", "Юмористическая проза", "Публицистика" });
            cmbGenre.Location = new Point(536, 23);
            cmbGenre.Margin = new Padding(3, 4, 3, 4);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(150, 28);
            cmbGenre.TabIndex = 5;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Location = new Point(316, 0);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(95, 20);
            lblSort.TabIndex = 4;
            lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "Название", "Автор", "Год", "Жанр", "Страниц", "Доступность" });
            cmbSort.Location = new Point(316, 23);
            cmbSort.Margin = new Padding(3, 4, 3, 4);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(150, 28);
            cmbSort.TabIndex = 3;
            cmbSort.SelectedIndexChanged += cmbSort_SelectedIndexChanged;
            // 
            // btnSearchBook
            // 
            btnSearchBook.Location = new Point(196, 22);
            btnSearchBook.Margin = new Padding(3, 4, 3, 4);
            btnSearchBook.Name = "btnSearchBook";
            btnSearchBook.Size = new Size(80, 30);
            btnSearchBook.TabIndex = 2;
            btnSearchBook.Text = "Поиск";
            btnSearchBook.UseVisualStyleBackColor = true;
            btnSearchBook.Click += btnSearchBook_Click;
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(11, 23);
            txtSearchBook.Margin = new Padding(3, 4, 3, 4);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(180, 27);
            txtSearchBook.TabIndex = 1;
            // 
            // lblSearchBook
            // 
            lblSearchBook.AutoSize = true;
            lblSearchBook.Location = new Point(8, 0);
            lblSearchBook.Name = "lblSearchBook";
            lblSearchBook.Size = new Size(55, 20);
            lblSearchBook.TabIndex = 0;
            lblSearchBook.Text = "Поиск:";
            // 
            // tabClients
            // 
            tabClients.Controls.Add(dgvClients);
            tabClients.Controls.Add(panelClientsSearch);
            tabClients.Location = new Point(4, 29);
            tabClients.Margin = new Padding(3, 4, 3, 4);
            tabClients.Name = "tabClients";
            tabClients.Size = new Size(992, 567);
            tabClients.TabIndex = 1;
            tabClients.Text = "Клиенты";
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.ColumnHeadersHeight = 29;
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.Location = new Point(0, 50);
            dgvClients.Margin = new Padding(3, 4, 3, 4);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(992, 517);
            dgvClients.TabIndex = 1;
            // 
            // panelClientsSearch
            // 
            panelClientsSearch.Controls.Add(lblSearchClient);
            panelClientsSearch.Controls.Add(txtSearchClient);
            panelClientsSearch.Controls.Add(btnSearchClient);
            panelClientsSearch.Dock = DockStyle.Top;
            panelClientsSearch.Location = new Point(0, 0);
            panelClientsSearch.Margin = new Padding(3, 4, 3, 4);
            panelClientsSearch.Name = "panelClientsSearch";
            panelClientsSearch.Size = new Size(992, 50);
            panelClientsSearch.TabIndex = 2;
            // 
            // lblSearchClient
            // 
            lblSearchClient.AutoSize = true;
            lblSearchClient.Location = new Point(10, 15);
            lblSearchClient.Name = "lblSearchClient";
            lblSearchClient.Size = new Size(55, 20);
            lblSearchClient.TabIndex = 0;
            lblSearchClient.Text = "Поиск:";
            // 
            // txtSearchClient
            // 
            txtSearchClient.Location = new Point(70, 12);
            txtSearchClient.Margin = new Padding(3, 4, 3, 4);
            txtSearchClient.Name = "txtSearchClient";
            txtSearchClient.Size = new Size(200, 27);
            txtSearchClient.TabIndex = 1;
            // 
            // btnSearchClient
            // 
            btnSearchClient.Location = new Point(280, 11);
            btnSearchClient.Margin = new Padding(3, 4, 3, 4);
            btnSearchClient.Name = "btnSearchClient";
            btnSearchClient.Size = new Size(80, 30);
            btnSearchClient.TabIndex = 2;
            btnSearchClient.Text = "Поиск";
            btnSearchClient.UseVisualStyleBackColor = true;
            btnSearchClient.Click += btnSearchClient_Click;
            // 
            // tabLoans
            // 
            tabLoans.Controls.Add(dgvLoans);
            tabLoans.Location = new Point(4, 29);
            tabLoans.Margin = new Padding(3, 4, 3, 4);
            tabLoans.Name = "tabLoans";
            tabLoans.Size = new Size(992, 567);
            tabLoans.TabIndex = 2;
            tabLoans.Text = "Выдачи";
            // 
            // dgvLoans
            // 
            dgvLoans.AllowUserToAddRows = false;
            dgvLoans.AllowUserToDeleteRows = false;
            dgvLoans.ColumnHeadersHeight = 29;
            dgvLoans.Dock = DockStyle.Fill;
            dgvLoans.Location = new Point(0, 0);
            dgvLoans.Margin = new Padding(3, 4, 3, 4);
            dgvLoans.Name = "dgvLoans";
            dgvLoans.ReadOnly = true;
            dgvLoans.RowHeadersWidth = 51;
            dgvLoans.Size = new Size(992, 567);
            dgvLoans.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 612);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(150, 612);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 38);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(290, 612);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 38);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnIssueBook
            // 
            btnIssueBook.Location = new Point(12, 612);
            btnIssueBook.Margin = new Padding(3, 4, 3, 4);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(120, 38);
            btnIssueBook.TabIndex = 4;
            btnIssueBook.Text = "Выдать книгу";
            btnIssueBook.UseVisualStyleBackColor = true;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Location = new Point(142, 612);
            btnReturnBook.Margin = new Padding(3, 4, 3, 4);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(120, 38);
            btnReturnBook.TabIndex = 5;
            btnReturnBook.Text = "Вернуть книгу";
            btnReturnBook.UseVisualStyleBackColor = true;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnShowDebtors
            // 
            btnShowDebtors.BackColor = Color.LightCoral;
            btnShowDebtors.Location = new Point(272, 612);
            btnShowDebtors.Margin = new Padding(3, 4, 3, 4);
            btnShowDebtors.Name = "btnShowDebtors";
            btnShowDebtors.Size = new Size(130, 38);
            btnShowDebtors.TabIndex = 6;
            btnShowDebtors.Text = "Должники";
            btnShowDebtors.UseVisualStyleBackColor = false;
            btnShowDebtors.Click += btnShowDebtors_Click;
            // 
            // btnRefreshLoans
            // 
            btnRefreshLoans.Location = new Point(412, 612);
            btnRefreshLoans.Margin = new Padding(3, 4, 3, 4);
            btnRefreshLoans.Name = "btnRefreshLoans";
            btnRefreshLoans.Size = new Size(94, 38);
            btnRefreshLoans.TabIndex = 7;
            btnRefreshLoans.Text = "Обновить";
            btnRefreshLoans.UseVisualStyleBackColor = true;
            btnRefreshLoans.Click += btnRefreshLoans_Click;
            // 
            // btnDeleteDatabase
            // 
            btnDeleteDatabase.BackColor = Color.LightCoral;
            btnDeleteDatabase.Location = new Point(12, 662);
            btnDeleteDatabase.Margin = new Padding(3, 4, 3, 4);
            btnDeleteDatabase.Name = "btnDeleteDatabase";
            btnDeleteDatabase.Size = new Size(130, 38);
            btnDeleteDatabase.TabIndex = 8;
            btnDeleteDatabase.Text = "Удалить БД";
            btnDeleteDatabase.UseVisualStyleBackColor = false;
            btnDeleteDatabase.Click += btnDeleteDatabase_Click;
            // 
            // btnSaveToFile
            // 
            btnSaveToFile.Location = new Point(150, 662);
            btnSaveToFile.Margin = new Padding(3, 4, 3, 4);
            btnSaveToFile.Name = "btnSaveToFile";
            btnSaveToFile.Size = new Size(160, 38);
            btnSaveToFile.TabIndex = 9;
            btnSaveToFile.Text = "Сохранить БД в файл";
            btnSaveToFile.UseVisualStyleBackColor = true;
            btnSaveToFile.Click += btnSaveToFile_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = Color.LightGreen;
            btnExportPdf.Location = new Point(320, 662);
            btnExportPdf.Margin = new Padding(3, 4, 3, 4);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(300, 38);
            btnExportPdf.TabIndex = 10;
            btnExportPdf.Text = "Экспорт книг в PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 719);
            Controls.Add(btnExportPdf);
            Controls.Add(btnSaveToFile);
            Controls.Add(btnDeleteDatabase);
            Controls.Add(btnRefreshLoans);
            Controls.Add(btnShowDebtors);
            Controls.Add(btnReturnBook);
            Controls.Add(btnIssueBook);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(tabControl);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1016, 756);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Библиотечная система «Книги»";
            FormClosing += MainForm_FormClosing;
            tabControl.ResumeLayout(false);
            tabBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panelBooksTop.ResumeLayout(false);
            panelBooksTop.PerformLayout();
            groupSortOrder.ResumeLayout(false);
            groupSortOrder.PerformLayout();
            tabClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            panelClientsSearch.ResumeLayout(false);
            panelClientsSearch.PerformLayout();
            tabLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
            ResumeLayout(false);
        }
    }
}