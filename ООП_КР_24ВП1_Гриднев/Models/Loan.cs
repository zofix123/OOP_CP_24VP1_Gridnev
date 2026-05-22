using System;

namespace ООП_КР_24ВП1_Гриднев.Models
{
    /// <summary>
    /// Представляет запись о выдаче книги клиенту.
    /// Содержит даты выдачи и возврата, а также вычисляемые свойства для определения просрочки.
    /// </summary>
    public class Loan
    {
        /// <summary>Уникальный идентификатор записи о выдаче в базе данных.</summary>
        public int Id { get; set; }

        /// <summary>Идентификатор выданной книги.</summary>
        public int BookId { get; set; }

        /// <summary>Идентификатор клиента, которому выдана книга.</summary>
        public int ClientId { get; set; }

        /// <summary>Дата выдачи книги. По умолчанию — текущее время.</summary>
        public DateTime IssueDate { get; set; } = DateTime.Now;

        /// <summary>Дата, до которой книга должна быть возвращена. По умолчанию — через 14 дней от текущего времени.</summary>
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);

        /// <summary>
        /// Дата фактического возврата книги.
        /// Значение <see langword="null"/> означает, что книга ещё не возвращена.
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>Название книги. Используется для отображения в интерфейсе без дополнительных запросов к БД.</summary>
        public string BookTitle { get; set; } = string.Empty;

        /// <summary>Полное имя клиента. Используется для отображения в интерфейсе без дополнительных запросов к БД.</summary>
        public string ClientName { get; set; } = string.Empty;

        /// <summary>
        /// Возвращает <see langword="true"/>, если книга не возвращена и срок возврата истёк.
        /// </summary>
        public bool IsOverdue => ReturnDate == null && DateTime.Now > DueDate;

        /// <summary>
        /// Возвращает количество дней просрочки.
        /// Если книга не просрочена или уже возвращена, возвращает 0.
        /// </summary>
        public int DaysOverdue => IsOverdue ? (DateTime.Now - DueDate).Days : 0;
    }
}