namespace ООП_КР_24ВП1_Гриднев.Models
{
    /// <summary>
    /// Представляет книгу в библиотечной базе данных.
    /// Хранит библиографические данные и информацию о количестве экземпляров.
    /// </summary>
    public class Book
    {
        /// <summary>Уникальный идентификатор книги в базе данных.</summary>
        public int Id { get; set; }

        /// <summary>Название книги.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Полное имя автора книги.</summary>
        public string AuthorFullName { get; set; } = string.Empty;

        /// <summary>Год написания или издания книги.</summary>
        public int Year { get; set; }

        /// <summary>Литературный жанр книги.</summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>Количество страниц в книге.</summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Доступна ли книга для выдачи
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/> с пустыми строковыми полями.
        /// </summary>
        public Book()
        {
            Title = string.Empty;
            AuthorFullName = string.Empty;
            Genre = string.Empty;
        }
    }
}