using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ООП_КР_24ВП1_Гриднев.Data;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    /// <summary>
    /// Главная форма приложения. Реализует многовкладочный интерфейс управления библиотекой:
    /// вкладки «Книги», «Клиенты» и «Выдачи».
    /// Координирует взаимодействие между базой данных и элементами управления.
    /// </summary>
    public partial class MainForm : Form
    {
        private Database? db;
        private List<Book> currentBooks = new List<Book>();
        private List<Client> currentClients = new List<Client>();
        private List<Loan> currentLoans = new List<Loan>();
        private readonly string dbPath = "books.db";

        /// <summary>
        /// Инициализирует главную форму: открывает базу данных, настраивает таблицы
        /// и загружает начальные данные. Подписывается на событие переключения вкладок
        /// и устанавливает обработчики для вкладки «Книги».
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            db = new Database(dbPath);
            SetupBooksGrid();
            SetupClientsGrid();
            SetupLoansGrid();
            LoadAllData();

            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            SetBookHandlers();
            SetInitialButtonVisibility();
        }

        /// <summary>
        /// Устанавливает видимость кнопок при первом запуске (активна вкладка Книги)
        /// </summary>
        private void SetInitialButtonVisibility()
        {
            // Скрываем все кнопки
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnIssueBook.Visible = false;
            btnReturnBook.Visible = false;
            btnShowDebtors.Visible = false;
            btnRefreshLoans.Visible = false;

            // Панели поиска
            panelBooksTop.Visible = true;
            panelClientsSearch.Visible = false;

            // Показываем кнопки для вкладки Книги (активная по умолчанию)
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
        }


        // Переключение вкладок

        /// <summary>
        /// Обрабатывает переключение между вкладками.
        /// Снимает обработчики кнопок Add/Edit/Delete, скрывает/показывает панели
        /// и устанавливает новые обработчики в соответствии с активной вкладкой.
        /// </summary>
        private void TabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Отписываемся от событий
            btnAdd.Click -= BtnAdd_Book;
            btnAdd.Click -= BtnAdd_Client;
            btnEdit.Click -= BtnEdit_Book;
            btnEdit.Click -= BtnEdit_Client;
            btnDelete.Click -= BtnDelete_Book;
            btnDelete.Click -= BtnDelete_Client;

            // Скрываем все панели поиска
            panelBooksTop.Visible = false;
            panelClientsSearch.Visible = false;

            // Скрываем все кнопки
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnIssueBook.Visible = false;
            btnReturnBook.Visible = false;
            btnShowDebtors.Visible = false;
            btnRefreshLoans.Visible = false;

            switch (tabControl.SelectedIndex)
            {
                case 0: // Вкладка Книги
                    panelBooksTop.Visible = true;
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    SetBookHandlers();
                    break;
                case 1: // Вкладка Клиенты
                    panelClientsSearch.Visible = true;
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    SetClientHandlers();
                    break;
                case 2: // Вкладка Выдачи
                    btnIssueBook.Visible = true;
                    btnReturnBook.Visible = true;
                    btnShowDebtors.Visible = true;
                    btnRefreshLoans.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Устанавливает подписи кнопок и привязывает обработчики для работы с книгами.
        /// </summary>
        private void SetBookHandlers()
        {
            btnAdd.Text = "Добавить книгу";
            btnEdit.Text = "Изменить книгу";
            btnDelete.Text = "Удалить книгу";

            btnAdd.Click += BtnAdd_Book;
            btnEdit.Click += BtnEdit_Book;
            btnDelete.Click += BtnDelete_Book;
        }

        /// <summary>
        /// Устанавливает подписи кнопок и привязывает обработчики для работы с клиентами.
        /// </summary>
        private void SetClientHandlers()
        {
            btnAdd.Text = "Добавить клиента";
            btnEdit.Text = "Изменить клиента";
            btnDelete.Text = "Удалить клиента";

            btnAdd.Click += BtnAdd_Client;
            btnEdit.Click += BtnEdit_Client;
            btnDelete.Click += BtnDelete_Client;
        }


        // Настройка таблиц

        /// <summary>
        /// Определяет столбцы и параметры отображения таблицы книг (<c>dgvBooks</c>).
        /// </summary>
        private void SetupBooksGrid()
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.Columns.Clear();

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 40 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Название", Width = 150 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AuthorFullName", HeaderText = "Автор", Width = 150 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = "Год", Width = 60 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genre", HeaderText = "Жанр", Width = 100 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PageCount", HeaderText = "Страниц", Width = 70 });
            dgvBooks.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsAvailable", HeaderText = "Доступна", Width = 70, ReadOnly = true });

            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
        }

        /// <summary>
        /// Определяет столбцы и параметры отображения таблицы клиентов (<c>dgvClients</c>).
        /// </summary>
        private void SetupClientsGrid()
        {
            dgvClients.AutoGenerateColumns = false;
            dgvClients.Columns.Clear();

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 40 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "ФИО", Width = 200 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Телефон", Width = 120 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Адрес", Width = 200 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RegistrationDate", HeaderText = "Дата регистрации", Width = 120 });

            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
        }

        /// <summary>
        /// Определяет столбцы и параметры отображения таблицы выдач (<c>dgvLoans</c>).
        /// Подписывается на событие форматирования ячеек для подсветки просрочек.
        /// </summary>
        private void SetupLoansGrid()
        {
            dgvLoans.AutoGenerateColumns = false;
            dgvLoans.Columns.Clear();

            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 40 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookTitle", HeaderText = "Книга", Width = 180 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClientName", HeaderText = "Клиент", Width = 180 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueDate", HeaderText = "Дата выдачи", Width = 90 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DueDate", HeaderText = "Срок возврата", Width = 100 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DaysOverdue", HeaderText = "Просрочка (дней)", Width = 120 });

            dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoans.MultiSelect = false;
            dgvLoans.CellFormatting += DgvLoans_CellFormatting;
        }

        /// <summary>
        /// Обрабатывает форматирование ячейки «Просрочка (дней)» в таблице выдач:
        /// выделяет ячейку красным фоном и тёмно-красным текстом при ненулевом значении просрочки.
        /// </summary>
        private void DgvLoans_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoans.Columns[e.ColumnIndex].DataPropertyName == "DaysOverdue" && e.Value != null)
            {
                int days = Convert.ToInt32(e.Value);
                if (days > 0)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        // Загрузка данных

        /// <summary>
        /// Перезагружает данные во всех трёх таблицах: книги, клиенты и активные выдачи.
        /// </summary>
        private void LoadAllData()
        {
            LoadBooks();
            LoadClients();
            LoadLoans();
        }

        /// <summary>
        /// Загружает список книг в таблицу <c>dgvBooks</c>.
        /// Если список не передан явно, запрашивает все книги из базы данных.
        /// </summary>
        /// <param name="books">Готовый список книг, или <see langword="null"/> для загрузки всех книг.</param>
        private void LoadBooks(List<Book>? books = null)
        {
            if (db == null) return;
            currentBooks = books ?? db.GetAllBooks();
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = currentBooks;
        }

        /// <summary>
        /// Загружает список клиентов в таблицу <c>dgvClients</c>.
        /// Если список не передан явно, запрашивает всех клиентов из базы данных.
        /// </summary>
        /// <param name="clients">Готовый список клиентов, или <see langword="null"/> для загрузки всех клиентов.</param>
        private void LoadClients(List<Client>? clients = null)
        {
            if (db == null) return;
            currentClients = clients ?? db.GetAllClients();
            dgvClients.DataSource = null;
            dgvClients.DataSource = currentClients;
        }

        /// <summary>
        /// Загружает список активных выдач в таблицу <c>dgvLoans</c>.
        /// Если список не передан явно, запрашивает активные выдачи из базы данных.
        /// </summary>
        /// <param name="loans">Готовый список выдач, или <see langword="null"/> для загрузки активных выдач.</param>
        private void LoadLoans(List<Loan>? loans = null)
        {
            if (db == null) return;
            currentLoans = loans ?? db.GetActiveLoans();
            dgvLoans.DataSource = null;
            dgvLoans.DataSource = currentLoans;
        }

        /// <summary>
        /// Применяет сортировку к списку книг по выбранному полю и направлению.
        /// </summary>
        private void ApplySorting()
        {
            if (db == null) return;
            string? displayName = cmbSort.SelectedItem?.ToString();
            if (displayName == null) return;

            // Преобразуем отображаемое название в имя поля базы данных
            string sortBy = displayName switch
            {
                "Название" => "Title",
                "Автор" => "Author",
                "Год" => "Year",
                "Жанр" => "Genre",
                "Страниц" => "PageCount",
                "Доступность" => "isAvailable",
                _ => "Title"
            };

            bool asc = rbAsc.Checked;
            LoadBooks(db.GetSortedBooks(sortBy, asc));
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Добавить книгу».
        /// Открывает <see cref="BookForm"/> и сохраняет новую книгу при подтверждении.
        /// </summary>
        private void BtnAdd_Book(object? sender, EventArgs e)
        {
            if (db == null) return;
            using var form = new BookForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.AddBook(form.Book);
                LoadBooks();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Изменить книгу».
        /// Открывает <see cref="BookForm"/> для выбранной строки и сохраняет изменения при подтверждении.
        /// </summary>
        private void BtnEdit_Book(object? sender, EventArgs e)
        {
            if (db == null) return;
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var book = dgvBooks.SelectedRows[0].DataBoundItem as Book;
            if (book == null) return;

            // Убрали получение issuedCopies, так как полей TotalCopies/AvailableCopies больше нет
            using var form = new BookForm(book);
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.UpdateBook(form.Book);
                LoadBooks();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Удалить книгу».
        /// Запрашивает подтверждение и удаляет выбранную книгу из базы данных.
        /// </summary>
        private void BtnDelete_Book(object? sender, EventArgs e)
        {
            if (db == null) return;
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var book = dgvBooks.SelectedRows[0].DataBoundItem as Book;
            if (book == null) return;

            if (MessageBox.Show($"Удалить книгу \"{book.Title}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.DeleteBook(book.Id);
                LoadBooks();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Добавить клиента».
        /// Открывает <see cref="ClientForm"/> и сохраняет нового клиента при подтверждении.
        /// </summary>
        private void BtnAdd_Client(object? sender, EventArgs e)
        {
            if (db == null) return;
            using var form = new ClientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.AddClient(form.Client);
                LoadClients();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Изменить клиента».
        /// Открывает <see cref="ClientForm"/> для выбранной строки и сохраняет изменения при подтверждении.
        /// </summary>
        private void BtnEdit_Client(object? sender, EventArgs e)
        {
            if (db == null) return;
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var client = dgvClients.SelectedRows[0].DataBoundItem as Client;
            if (client == null) return;

            using var form = new ClientForm(client);
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.UpdateClient(form.Client);
                LoadClients();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Удалить клиента».
        /// Запрашивает подтверждение и удаляет выбранного клиента из базы данных.
        /// </summary>
        private void BtnDelete_Client(object? sender, EventArgs e)
        {
            if (db == null) return;
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var client = dgvClients.SelectedRows[0].DataBoundItem as Client;
            if (client == null) return;

            if (MessageBox.Show($"Удалить клиента \"{client.FullName}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.DeleteClient(client.Id);
                LoadClients();
            }
        }

        // Поиск

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска книг.
        /// При пустом запросе загружает все книги, иначе — результаты поиска.
        /// </summary>
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            string? query = txtSearchBook.Text?.Trim();
            if (string.IsNullOrEmpty(query))
                LoadBooks();
            else
                LoadBooks(db.SearchBooks(query));
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска клиентов.
        /// При пустом запросе загружает всех клиентов, иначе — результаты поиска.
        /// </summary>
        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            string? query = txtSearchClient.Text?.Trim();
            if (string.IsNullOrEmpty(query))
                LoadClients();
            else
                LoadClients(db.SearchClients(query));
        }

        /// <summary>
        /// Обрабатывает изменение поля сортировки: немедленно применяет сортировку.
        /// </summary>
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) => ApplySorting();

        /// <summary>
        /// Обрабатывает переключение направления сортировки: немедленно применяет сортировку.
        /// </summary>
        private void rbSortOrder_CheckedChanged(object sender, EventArgs e) => ApplySorting();

        /// <summary>
        /// Обрабатывает нажатие кнопки фильтрации по жанру.
        /// При пустом выборе загружает все книги, иначе — отфильтрованные по жанру.
        /// </summary>
        private void btnFilterGenre_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            string? genre = cmbGenre.Text?.Trim();
            if (string.IsNullOrEmpty(genre))
                LoadBooks();
            else
                LoadBooks(db.FilterByGenre(genre));
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки сброса фильтров и сортировки.
        /// Очищает поля поиска/фильтра и загружает все книги.
        /// </summary>
        private void btnResetBooks_Click(object sender, EventArgs e)
        {
            txtSearchBook.Clear();
            cmbGenre.SelectedIndex = -1;
            cmbSort.SelectedIndex = -1;
            rbAsc.Checked = true;
            LoadBooks();
        }

        // Выдачи

        /// <summary>
        /// Обрабатывает нажатие кнопки «Выдать книгу».
        /// Открывает <see cref="IssueBookForm"/> и перезагружает все данные при успешной выдаче.
        /// </summary>
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            using var form = new IssueBookForm(db);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAllData();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Вернуть книгу».
        /// Проверяет, что выбрана невозвращённая выдача, запрашивает подтверждение
        /// и регистрирует возврат в базе данных.
        /// </summary>
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите выдачу для возврата.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var loan = dgvLoans.SelectedRows[0].DataBoundItem as Loan;
            if (loan == null)
            {
                MessageBox.Show("Ошибка получения данных о выдаче.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Подтвердить возврат книги \"{loan.BookTitle}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.ReturnBook(loan.Id);
                LoadLoans();  // Обновляем только список выдач, книги не меняются
                LoadBooks();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Должники».
        /// Открывает форму <see cref="DebtorsForm"/> с отчётом по просроченным выдачам.
        /// </summary>
        private void btnShowDebtors_Click(object sender, EventArgs e)
        {
            using var form = new DebtorsForm(db!);
            form.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Обновить» на вкладке выдач.
        /// Перезагружает список активных выдач.
        /// </summary>
        private void btnRefreshLoans_Click(object sender, EventArgs e)
        {
            LoadLoans();
        }

        // ==================== БАЗА ДАННЫХ ====================

        /// <summary>
        /// Обрабатывает нажатие кнопки «Удалить базу данных».
        /// После подтверждения полностью удаляет и пересоздаёт БД.
        /// </summary>
        private void btnDeleteDatabase_Click(object sender, EventArgs e)
        {
            if (db == null) return;

            if (MessageBox.Show("Вы уверены, что хотите удалить базу данных?\nВсе записи будут безвозвратно удалены!",
                "Подтверждение удаления БД", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    db.DeleteDatabase();
                    LoadAllData();
                    MessageBox.Show("База данных успешно удалена и создана заново.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Сохранить в файл».
        /// Открывает диалог сохранения и копирует файл БД по выбранному пути.
        /// </summary>
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (db == null) return;

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Файлы базы данных SQLite (*.db)|*.db|Все файлы (*.*)|*.*",
                DefaultExt = "db",
                FileName = "books_backup.db",
                Title = "Сохранить базу данных в файл"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    db.SaveToFile(saveDialog.FileName);
                    MessageBox.Show($"База данных успешно сохранена в файл:\n{saveDialog.FileName}", "Сохранение выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Экспорт в PDF».
        /// Открывает диалог сохранения и экспортирует текущий список книг в PDF-файл.
        /// </summary>
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (currentBooks == null || currentBooks.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "PDF документ (*.pdf)|*.pdf",
                DefaultExt = "pdf",
                FileName = $"Книги_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                Title = "Экспорт данных в PDF"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfExporter.ExportToPdf(currentBooks, saveDialog.FileName);
                    MessageBox.Show($"Данные успешно экспортированы в PDF:\n{saveDialog.FileName}\n\nЭкспортировано записей: {currentBooks.Count}",
                        "Экспорт выполнен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте в PDF:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает закрытие главной формы.
        /// Освобождает ресурсы соединения с базой данных.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            db?.Dispose();
        }







    }
}