using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.Data
{
    /// <summary>
    /// Предоставляет доступ к базе данных SQLite и реализует операции CRUD
    /// для сущностей <see cref="Book"/>, <see cref="Client"/> и <see cref="Loan"/>.
    /// Реализует <see cref="IDisposable"/> для корректного освобождения соединения с БД.
    /// </summary>
    public class Database : IDisposable
    {
        private readonly string connectionString;
        private SQLiteConnection? connection;
        private string currentDbPath;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Database"/>.
        /// Если файл базы данных по указанному пути не существует, создаёт его.
        /// Открывает соединение и инициализирует схему таблиц.
        /// </summary>
        /// <param name="dbFilePath">Путь к файлу базы данных SQLite.</param>
        public Database(string dbFilePath)
        {
            currentDbPath = dbFilePath;

            if (!File.Exists(dbFilePath))
                SQLiteConnection.CreateFile(dbFilePath);

            connectionString = $"Data Source={dbFilePath};Version=3;";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            CreateTablesIfNotExist();
        }

        /// <summary>
        /// Создаёт таблицы Books, Clients и Loans, если они ещё не существуют в базе данных.
        /// </summary>
        private void CreateTablesIfNotExist()
        {
            if (connection == null) return;

            string sql = @"
        CREATE TABLE IF NOT EXISTS Books (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            AuthorFullName TEXT NOT NULL,
            Year INTEGER NOT NULL,
            Genre TEXT NOT NULL,
            PageCount INTEGER NOT NULL,
            isAvailable BOOLEAN NOT NULL DEFAULT TRUE
        );

        CREATE TABLE IF NOT EXISTS Clients (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FullName TEXT NOT NULL,
            Phone TEXT NOT NULL,
            Address TEXT NOT NULL,
            RegistrationDate TEXT NOT NULL
        );

        CREATE TABLE IF NOT EXISTS Loans (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            BookId INTEGER NOT NULL,
            ClientId INTEGER NOT NULL,
            IssueDate TEXT NOT NULL,
            DueDate TEXT NOT NULL,
            ReturnDate TEXT,
            FOREIGN KEY (BookId) REFERENCES Books (Id),
            FOREIGN KEY (ClientId) REFERENCES Clients (Id)
        );";

            using var cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        // Книги

        /// <summary>
        /// Добавляет новую книгу в базу данных.
        /// </summary>
        /// <param name="book">Объект книги для сохранения.</param>
        public void AddBook(Book book)
        {
            if (connection == null) return;

            string sql = @"INSERT INTO Books (Title, AuthorFullName, Year, Genre, PageCount) 
                           VALUES (@title, @author, @year, @genre, @pages)";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.AuthorFullName);
            cmd.Parameters.AddWithValue("@year", book.Year);
            cmd.Parameters.AddWithValue("@genre", book.Genre);
            cmd.Parameters.AddWithValue("@pages", book.PageCount);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновляет все поля существующей книги по её идентификатору.
        /// </summary>
        /// <param name="book">Объект книги с обновлёнными данными.</param>
        public void UpdateBook(Book book)
        {
            if (connection == null) return;

            string sql = @"UPDATE Books 
                           SET Title=@title, AuthorFullName=@author, Year=@year, 
                               Genre=@genre, PageCount=@pages
                           WHERE Id=@id";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.AuthorFullName);
            cmd.Parameters.AddWithValue("@year", book.Year);
            cmd.Parameters.AddWithValue("@genre", book.Genre);
            cmd.Parameters.AddWithValue("@pages", book.PageCount);

            cmd.Parameters.AddWithValue("@id", book.Id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Удаляет книгу из базы данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги для удаления.</param>
        public void DeleteBook(int id)
        {
            if (connection == null) return;
            string sql = "DELETE FROM Books WHERE Id = @id";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Возвращает список всех книг из базы данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Book"/>.</returns>
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            if (connection == null) return books;

            string sql = "SELECT * FROM Books";
            using var cmd = new SQLiteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(ReadBook(reader));
            }
            return books;
        }

        /// <summary>
        /// Выполняет поиск книг по строке запроса среди полей Title, AuthorFullName, Genre и Year.
        /// </summary>
        /// <param name="query">Поисковая строка.</param>
        /// <returns>Список книг, соответствующих запросу.</returns>
        public List<Book> SearchBooks(string query)
        {
            var books = new List<Book>();
            if (connection == null) return books;

            string sql = @"SELECT * FROM Books 
                           WHERE Title LIKE @q OR AuthorFullName LIKE @q 
                           OR Genre LIKE @q OR CAST(Year AS TEXT) LIKE @q";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@q", $"%{query}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(ReadBook(reader));
            }
            return books;
        }

        /// <summary>
        /// Возвращает список всех книг, отсортированных по указанному полю.
        /// </summary>
        /// <param name="sortBy">
        /// Имя поля для сортировки: "Title", "Author", "Year", "Genre", "Pages".
        /// Любое другое значение даёт сортировку по Id.
        /// </param>
        /// <param name="ascending">
        /// <see langword="true"/> для сортировки по возрастанию, <see langword="false"/> — по убыванию.
        /// </param>
        /// <returns>Отсортированный список объектов <see cref="Book"/>.</returns>
        public List<Book> GetSortedBooks(string sortBy, bool ascending = true)
        {
            var books = new List<Book>();
            if (connection == null) return books;

            string order = ascending ? "ASC" : "DESC";
            string column = sortBy switch
            {
                "Title" => "Title",
                "Author" => "AuthorFullName",
                "Year" => "Year",
                "Genre" => "Genre",
                "Pages" => "PageCount",
                "isAvailable" => "isAvailable",
                _ => "Id"
            };

            string sql = $"SELECT * FROM Books ORDER BY {column} {order}";
            using var cmd = new SQLiteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(ReadBook(reader));
            }
            return books;
        }

        /// <summary>
        /// Создаёт объект <see cref="Book"/> из текущей строки <see cref="SQLiteDataReader"/>.
        /// </summary>
        /// <param name="reader">Открытый ридер, установленный на нужную строку.</param>
        /// <returns>Заполненный объект <see cref="Book"/>.</returns>
        private Book ReadBook(SQLiteDataReader reader)
        {
            return new Book
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"]?.ToString() ?? string.Empty,
                AuthorFullName = reader["AuthorFullName"]?.ToString() ?? string.Empty,
                Year = Convert.ToInt32(reader["Year"]),
                Genre = reader["Genre"]?.ToString() ?? string.Empty,
                PageCount = Convert.ToInt32(reader["PageCount"]),
                IsAvailable = Convert.ToBoolean(reader["isAvailable"])

            };
        }


        // Клиенты

        /// <summary>
        /// Добавляет нового клиента в базу данных.
        /// </summary>
        /// <param name="client">Объект клиента для сохранения.</param>
        public void AddClient(Client client)
        {
            if (connection == null) return;

            string sql = @"INSERT INTO Clients (FullName, Phone, Address, RegistrationDate) 
                           VALUES (@name, @phone, @address, @date)";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", client.FullName);
            cmd.Parameters.AddWithValue("@phone", client.Phone);
            cmd.Parameters.AddWithValue("@address", client.Address);
            cmd.Parameters.AddWithValue("@date", client.RegistrationDate.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновляет данные существующего клиента по его идентификатору.
        /// </summary>
        /// <param name="client">Объект клиента с обновлёнными данными.</param>
        public void UpdateClient(Client client)
        {
            if (connection == null) return;

            string sql = @"UPDATE Clients 
                           SET FullName=@name, Phone=@phone, Address=@address 
                           WHERE Id=@id";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", client.FullName);
            cmd.Parameters.AddWithValue("@phone", client.Phone);
            cmd.Parameters.AddWithValue("@address", client.Address);
            cmd.Parameters.AddWithValue("@id", client.Id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Удаляет клиента из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента для удаления.</param>
        public void DeleteClient(int id)
        {
            if (connection == null) return;
            string sql = "DELETE FROM Clients WHERE Id = @id";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Возвращает список всех клиентов, упорядоченных по полному имени.
        /// </summary>
        /// <returns>Список объектов <see cref="Client"/>.</returns>
        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();
            if (connection == null) return clients;

            string sql = "SELECT * FROM Clients ORDER BY FullName";
            using var cmd = new SQLiteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new Client
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FullName = reader["FullName"]?.ToString() ?? string.Empty,
                    Phone = reader["Phone"]?.ToString() ?? string.Empty,
                    Address = reader["Address"]?.ToString() ?? string.Empty,
                    RegistrationDate = DateTime.Parse(reader["RegistrationDate"]?.ToString() ?? DateTime.Now.ToString())
                });
            }
            return clients;
        }

        /// <summary>
        /// Выполняет поиск клиентов по строке запроса среди полей FullName, Phone и Address.
        /// </summary>
        /// <param name="query">Поисковая строка.</param>
        /// <returns>Список клиентов, соответствующих запросу.</returns>
        public List<Client> SearchClients(string query)
        {
            var clients = new List<Client>();
            if (connection == null) return clients;

            string sql = "SELECT * FROM Clients WHERE FullName LIKE @q OR Phone LIKE @q OR Address LIKE @q";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@q", $"%{query}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new Client
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FullName = reader["FullName"]?.ToString() ?? string.Empty,
                    Phone = reader["Phone"]?.ToString() ?? string.Empty,
                    Address = reader["Address"]?.ToString() ?? string.Empty,
                    RegistrationDate = DateTime.Parse(reader["RegistrationDate"]?.ToString() ?? DateTime.Now.ToString())
                });
            }
            return clients;
        }

        // Выдачи

        /// <summary>
        /// Выдаёт книгу клиенту на указанное количество дней.
        /// Создаёт запись о выдаче, предварительно проверив, что клиент ещё не взял эту книгу.
        /// </summary>
        /// <param name="bookId">Идентификатор выдаваемой книги.</param>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <param name="days">Срок выдачи в днях. По умолчанию 14.</param>
        /// <returns>
        /// <see langword="true"/>, если выдача прошла успешно;
        /// <see langword="false"/>, если клиент уже имеет эту книгу на руках.
        /// </returns>
        public bool IssueBook(int bookId, int clientId, int days = 14)
        {
            if (connection == null) return false;

            // Проверка: книга вообще доступна?
            string availSql = "SELECT isAvailable FROM Books WHERE Id = @bookId";
            using var availCmd = new SQLiteCommand(availSql, connection);
            availCmd.Parameters.AddWithValue("@bookId", bookId);
            var availResult = availCmd.ExecuteScalar();
            if (availResult == null || !Convert.ToBoolean(availResult))
                return false; // Книга уже выдана кому-то другому

            // Проверка: этот клиент уже не взял её?
            string checkSql = @"SELECT COUNT(*) FROM Loans 
                        WHERE BookId = @bookId AND ClientId = @clientId AND ReturnDate IS NULL";
            using var checkCmd = new SQLiteCommand(checkSql, connection);
            checkCmd.Parameters.AddWithValue("@bookId", bookId);
            checkCmd.Parameters.AddWithValue("@clientId", clientId);
            if ((long)checkCmd.ExecuteScalar() > 0)
                return false;

            // Выдаём книгу
            string sql = @"INSERT INTO Loans (BookId, ClientId, IssueDate, DueDate) 
                   VALUES (@bookId, @clientId, @issueDate, @dueDate)";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            cmd.Parameters.AddWithValue("@issueDate", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(days).ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();

            // Помечаем книгу как недоступную
            string updateSql = "UPDATE Books SET isAvailable = 0 WHERE Id = @bookId";
            using var updateCmd = new SQLiteCommand(updateSql, connection);
            updateCmd.Parameters.AddWithValue("@bookId", bookId);
            updateCmd.ExecuteNonQuery();

            return true;
        }
        /// <summary>
        /// Регистрирует возврат книги: проставляет текущую дату возврата.
        /// Обновления количества экземпляров не требуется.
        /// </summary>
        /// <param name="loanId">Идентификатор записи о выдаче.</param>
        public void ReturnBook(int loanId)
        {
            if (connection == null) return;

            // Узнаём BookId по записи выдачи
            string getBookSql = "SELECT BookId FROM Loans WHERE Id = @id";
            using var getCmd = new SQLiteCommand(getBookSql, connection);
            getCmd.Parameters.AddWithValue("@id", loanId);
            var bookIdResult = getCmd.ExecuteScalar();
            if (bookIdResult == null) return;
            int bookId = Convert.ToInt32(bookIdResult);

            // Фиксируем дату возврата
            string sql = "UPDATE Loans SET ReturnDate = @date WHERE Id = @id";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@id", loanId);
            cmd.ExecuteNonQuery();

            // Возвращаем книгу в доступные
            string updateSql = "UPDATE Books SET isAvailable = 1 WHERE Id = @bookId";
            using var updateCmd = new SQLiteCommand(updateSql, connection);
            updateCmd.Parameters.AddWithValue("@bookId", bookId);
            updateCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Возвращает запись о выдаче по её идентификатору,
        /// включая название книги и имя клиента.
        /// </summary>
        /// <param name="loanId">Идентификатор записи о выдаче.</param>
        /// <returns>Объект <see cref="Loan"/> или <see langword="null"/>, если запись не найдена.</returns>
        public Loan? GetLoanById(int loanId)
        {
            if (connection == null) return null;

            string sql = @"SELECT l.*, b.Title as BookTitle, c.FullName as ClientName 
                   FROM Loans l 
                   JOIN Books b ON l.BookId = b.Id 
                   JOIN Clients c ON l.ClientId = c.Id 
                   WHERE l.Id = @id";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", loanId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ReadLoan(reader);
            }
            return null;
        }

        /// <summary>
        /// Возвращает список активных выдач (книги, которые ещё не возвращены),
        /// упорядоченных по сроку возврата.
        /// </summary>
        /// <returns>Список активных объектов <see cref="Loan"/>.</returns>
        public List<Loan> GetActiveLoans()
        {
            var loans = new List<Loan>();
            if (connection == null) return loans;

            string sql = @"SELECT l.*, b.Title as BookTitle, c.FullName as ClientName 
                   FROM Loans l 
                   JOIN Books b ON l.BookId = b.Id 
                   JOIN Clients c ON l.ClientId = c.Id 
                   WHERE l.ReturnDate IS NULL 
                   ORDER BY l.DueDate";
            using var cmd = new SQLiteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                loans.Add(ReadLoan(reader));
            }
            return loans;
        }

        /// <summary>
        /// Возвращает список просроченных выдач: книги не возвращены и срок возврата истёк.
        /// Список упорядочен по сроку возврата.
        /// </summary>
        /// <returns>Список просроченных объектов <see cref="Loan"/>.</returns>
        public List<Loan> GetOverdueLoans()
        {
            var loans = new List<Loan>();
            if (connection == null) return loans;

            string sql = @"SELECT l.*, b.Title as BookTitle, c.FullName as ClientName 
                   FROM Loans l 
                   JOIN Books b ON l.BookId = b.Id 
                   JOIN Clients c ON l.ClientId = c.Id 
                   WHERE l.ReturnDate IS NULL AND l.DueDate < @today 
                   ORDER BY l.DueDate";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@today", DateTime.Now.ToString("yyyy-MM-dd"));
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                loans.Add(ReadLoan(reader));
            }
            return loans;
        }

        /// <summary>
        /// Возвращает историю всех выдач конкретного клиента,
        /// упорядоченную по дате выдачи (новые первыми).
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <returns>Список объектов <see cref="Loan"/> для указанного клиента.</returns>
        public List<Loan> GetClientLoans(int clientId)
        {
            var loans = new List<Loan>();
            if (connection == null) return loans;

            string sql = @"SELECT l.*, b.Title as BookTitle, c.FullName as ClientName 
                   FROM Loans l 
                   JOIN Books b ON l.BookId = b.Id 
                   JOIN Clients c ON l.ClientId = c.Id 
                   WHERE l.ClientId = @clientId 
                   ORDER BY l.IssueDate DESC";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                loans.Add(ReadLoan(reader));
            }
            return loans;
        }

        /// <summary>
        /// Создаёт объект <see cref="Loan"/> из текущей строки <see cref="SQLiteDataReader"/>.
        /// Ожидает, что запрос содержит алиасы BookTitle и ClientName.
        /// </summary>
        /// <param name="reader">Открытый ридер, установленный на нужную строку.</param>
        /// <returns>Заполненный объект <see cref="Loan"/>.</returns>
        private Loan ReadLoan(SQLiteDataReader reader)
        {
            var loan = new Loan
            {
                Id = Convert.ToInt32(reader["Id"]),
                BookId = Convert.ToInt32(reader["BookId"]),
                ClientId = Convert.ToInt32(reader["ClientId"]),
                IssueDate = DateTime.Parse(reader["IssueDate"]?.ToString() ?? DateTime.Now.ToString()),
                DueDate = DateTime.Parse(reader["DueDate"]?.ToString() ?? DateTime.Now.ToString()),
                BookTitle = reader["BookTitle"]?.ToString() ?? string.Empty,
                ClientName = reader["ClientName"]?.ToString() ?? string.Empty
            };

            if (reader["ReturnDate"] != DBNull.Value)
            {
                loan.ReturnDate = DateTime.Parse(reader["ReturnDate"].ToString()!);
            }

            return loan;
        }


        /// <summary>
        /// Возвращает список книг, принадлежащих указанному жанру.
        /// </summary>
        /// <param name="genre">Название жанра для фильтрации.</param>
        /// <returns>Список книг заданного жанра.</returns>
        public List<Book> FilterByGenre(string genre)
        {
            var books = new List<Book>();
            if (connection == null) return books;

            string sql = "SELECT * FROM Books WHERE Genre = @genre";
            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@genre", genre);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(ReadBook(reader));
            }
            return books;
        }

        /// <summary>
        /// Полностью удаляет и пересоздаёт базу данных, очищая все таблицы.
        /// После выполнения соединение с БД восстанавливается автоматически.
        /// </summary>
        public void DeleteDatabase()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            if (File.Exists(currentDbPath))
                File.Delete(currentDbPath);

            SQLiteConnection.CreateFile(currentDbPath);
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            CreateTablesIfNotExist();
        }

        /// <summary>
        /// Сохраняет (копирует) файл базы данных по указанному пути назначения.
        /// На время копирования соединение закрывается и затем восстанавливается.
        /// </summary>
        /// <param name="destinationPath">Путь для сохранения резервной копии файла БД.</param>
        public void SaveToFile(string destinationPath)
        {
            if (connection == null) return;

            connection.Close();
            connection.Dispose();
            connection = null;

            try
            {
                File.Copy(currentDbPath, destinationPath, true);
            }
            finally
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
            }
        }

        /// <summary>
        /// Закрывает и освобождает соединение с базой данных.
        /// </summary>
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
    }
}