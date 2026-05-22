using System;
using System.Linq;
using System.Windows.Forms;
using ООП_КР_24ВП1_Гриднев.Data;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    /// <summary>
    /// Диалоговая форма для оформления выдачи книги клиенту.
    /// Отображает выпадающие списки книг и клиентов,
    /// а также поле для ввода срока выдачи в днях.
    /// </summary>
    public partial class IssueBookForm : Form
    {
        private Database db;

        /// <summary>
        /// Инициализирует форму выдачи книги и загружает данные из базы данных.
        /// </summary>
        /// <param name="database">Экземпляр базы данных для загрузки и сохранения данных.</param>
        public IssueBookForm(Database database)
        {
            InitializeComponent();
            db = database;
            LoadData();
        }

        /// <summary>
        /// Загружает в выпадающие списки все книги и всех клиентов.
        /// </summary>
        private void LoadData()
        {
            var allBooks = db.GetAllBooks();
            cmbBook.DataSource = allBooks;
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "Id";

            var clients = db.GetAllClients();
            cmbClient.DataSource = clients;
            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "Id";
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Выдать».
        /// Проверяет выбор книги и клиента, вызывает метод выдачи через базу данных.
        /// При успехе закрывает форму с результатом <see cref="DialogResult.OK"/>.
        /// </summary>
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (cmbBook.SelectedValue == null || cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу и клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = (int)cmbBook.SelectedValue;
            int clientId = (int)cmbClient.SelectedValue;
            int days = (int)numDays.Value;

            if (db.IssueBook(bookId, clientId, days))
            {
                MessageBox.Show("Книга выдана успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Невозможно выдать книгу. Возможно, клиент уже имеет эту книгу на руках.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}