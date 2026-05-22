using System;
using System.Windows.Forms;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    /// <summary>
    /// Диалоговая форма для добавления новой книги или редактирования существующей.
    /// </summary>
    public partial class BookForm : Form
    {
        /// <summary>
        /// Объект книги, сформированный по данным формы.
        /// </summary>
        public Book Book { get; private set; }

        private readonly bool isEditMode = false;

        /// <summary>
        /// Инициализирует форму.
        /// </summary>
        /// <param name="book">Книга для редактирования, или <see langword="null"/> для создания новой.</param>
        public BookForm(Book? book = null)
        {
            InitializeComponent();

            if (book != null)
            {
                isEditMode = true;
                Book = new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorFullName = book.AuthorFullName,
                    Year = book.Year,
                    Genre = book.Genre,
                    PageCount = book.PageCount
                };

                txtTitle.Text = book.Title;
                txtAuthor.Text = book.AuthorFullName;
                numYear.Value = book.Year;

                if (!string.IsNullOrEmpty(book.Genre))
                {
                    int index = cmbGenre.FindStringExact(book.Genre);
                    if (index >= 0)
                    {
                        cmbGenre.SelectedIndex = index;
                    }
                }
                else
                {
                    cmbGenre.SelectedIndex = 0;
                }

                numPages.Value = book.PageCount;

                Text = "Редактирование книги";
            }
            else
            {
                Book = new Book();
                cmbGenre.SelectedIndex = 0;
                Text = "Добавление книги";
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Сохранить».
        /// Выполняет валидацию всех полей.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название книги.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Введите ФИО автора.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return;
            }

            if (cmbGenre.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите жанр книги.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGenre.Focus();
                return;
            }

            Book.Title = txtTitle.Text.Trim();
            Book.AuthorFullName = txtAuthor.Text.Trim();
            Book.Year = (int)numYear.Value;
            Book.Genre = cmbGenre.SelectedItem?.ToString() ?? string.Empty;
            Book.PageCount = (int)numPages.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}