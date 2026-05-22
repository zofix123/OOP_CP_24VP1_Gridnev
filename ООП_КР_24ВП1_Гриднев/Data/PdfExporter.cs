using System;
using System.Collections.Generic;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.Data
{
    /// <summary>
    /// Предоставляет статический метод для экспорта списка книг в PDF-документ
    /// с использованием библиотеки QuestPDF.
    /// </summary>
    public static class PdfExporter
    {
        /// <summary>
        /// Генерирует PDF-файл с таблицей книг и сохраняет его по указанному пути.
        /// Документ содержит заголовок, таблицу с данными и подвал с общим количеством записей.
        /// </summary>
        /// <param name="books">Список книг для экспорта. Не должен быть пустым.</param>
        /// <param name="filePath">Путь к файлу, в который будет сохранён PDF.</param>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если список <paramref name="books"/> пуст или равен <see langword="null"/>.
        /// </exception>
        public static void ExportToPdf(List<Book> books, string filePath)
        {
            if (books == null || books.Count == 0)
                throw new InvalidOperationException("Нет данных для экспорта.");

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(10));

                    page.Header()
                        .PaddingBottom(10)
                        .Column(col =>
                        {
                            col.Item().AlignCenter()
                                .Text("База данных «Книги»")
                                .Bold().FontSize(18);

                            col.Item().AlignRight()
                                .Text($"Дата экспорта: {DateTime.Now:dd.MM.yyyy HH:mm}")
                                .FontSize(8).Italic();
                        });

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(4);
                            columns.RelativeColumn(4);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(2);
                        });

                        table.Header(header =>
                        {
                            string[] headers = { "ID", "Название", "Автор", "Год", "Жанр", "Страниц" };
                            foreach (var h in headers)
                                header.Cell().Background(Colors.Blue.Darken2).Padding(3)
                                    .Text(h).Bold().FontColor(Colors.White);
                        });

                        foreach (var book in books)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(book.Id.ToString());
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(book.Title);
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(book.AuthorFullName);
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(book.Year.ToString());
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(book.Genre);
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(book.PageCount.ToString());
                        }
                    });

                    page.Footer()
                        .AlignRight()
                        .Text($"Всего записей: {books.Count}")
                        .FontSize(9).Italic();
                });
            })
            .GeneratePdf(filePath);
        }




        /// <summary>
        /// Экспортирует список должников в PDF-файл.
        /// </summary>
        /// <param name="debtors">Список просроченных выдач для экспорта.</param>
        /// <param name="filePath">Путь для сохранения PDF-файла.</param>
        public static void ExportDebtorsToPdf(List<Loan> debtors, string filePath)
        {
            if (debtors == null || debtors.Count == 0)
                throw new InvalidOperationException("Нет данных для экспорта.");

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(10));

                    page.Header()
                        .PaddingBottom(10)
                        .Column(col =>
                        {
                            col.Item().AlignCenter()
                                .Text("СПИСОК ДОЛЖНИКОВ")
                                .Bold().FontSize(18);

                            col.Item().AlignRight()
                                .Text($"Дата экспорта: {DateTime.Now:dd.MM.yyyy HH:mm}")
                                .FontSize(8).Italic();
                        });

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(4);
                            columns.RelativeColumn(4);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                        });

                        table.Header(header =>
                        {
                            string[] headers = { "ID", "ФИО должника", "Название книги", "Дата выдачи", "Срок возврата", "Дней просрочки" };
                            foreach (var h in headers)
                                header.Cell().Background(Colors.Blue.Darken2).Padding(3)
                                    .Text(h).Bold().FontColor(Colors.White);
                        });

                        foreach (var loan in debtors)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(loan.Id.ToString());
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(loan.ClientName ?? "");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(loan.BookTitle ?? "");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(loan.IssueDate.ToString("dd.MM.yyyy"));
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(loan.DueDate.ToString("dd.MM.yyyy"));
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3).Text(loan.DaysOverdue.ToString());
                        }
                    });

                    page.Footer()
                        .AlignRight()
                        .Text($"Всего должников: {debtors.Count}")
                        .FontSize(9).Italic();
                });
            })
            .GeneratePdf(filePath);
        }



    }
}