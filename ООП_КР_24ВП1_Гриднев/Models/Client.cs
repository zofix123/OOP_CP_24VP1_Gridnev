using System;

namespace ООП_КР_24ВП1_Гриднев.Models
{
    /// <summary>
    /// Представляет читателя (клиента) библиотеки.
    /// Хранит контактные данные и дату регистрации.
    /// </summary>
    public class Client
    {
        /// <summary>Уникальный идентификатор клиента в базе данных.</summary>
        public int Id { get; set; }

        /// <summary>Полное имя клиента.</summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>Контактный номер телефона клиента.</summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>Адрес проживания клиента.</summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>Дата регистрации клиента в библиотеке. По умолчанию — текущее время.</summary>
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}