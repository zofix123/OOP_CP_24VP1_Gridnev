using System;
using System.Windows.Forms;
using ООП_КР_24ВП1_Гриднев.Models;

namespace ООП_КР_24ВП1_Гриднев.UI
{
    /// <summary>
    /// Диалоговая форма для добавления нового клиента или редактирования существующего.
    /// После закрытия с результатом <see cref="DialogResult.OK"/>
    /// заполненный объект <see cref="Client"/> доступен через свойство <see cref="Client"/>.
    /// </summary>
    public partial class ClientForm : Form
    {
        /// <summary>
        /// Объект клиента, сформированный по данным формы.
        /// При редактировании содержит изменённые данные переданного объекта;
        /// при добавлении — новый объект.
        /// </summary>
        public Client Client { get; private set; }

        /// <summary>
        /// Инициализирует форму.
        /// При передаче существующего клиента заполняет поля его данными и устанавливает заголовок «Редактирование клиента».
        /// При отсутствии аргумента открывает пустую форму с заголовком «Добавление клиента».
        /// </summary>
        /// <param name="client">Клиент для редактирования, или <see langword="null"/> для создания нового.</param>
        public ClientForm(Client? client = null)
        {
            InitializeComponent();
            txtPhone.KeyPress += TxtPhone_KeyPress;

            if (client != null)
            {
                Client = client;
                txtFullName.Text = client.FullName;
                txtPhone.Text = client.Phone;
                txtAddress.Text = client.Address;
                Text = "Редактирование клиента";
            }
            else
            {
                Client = new Client();
                Text = "Добавление клиента";
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Сохранить».
        /// Проверяет заполнение обязательного поля ФИО.
        /// При успешной проверке записывает данные в свойство <see cref="Client"/>
        /// и закрывает форму с результатом <see cref="DialogResult.OK"/>.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Client.FullName = txtFullName.Text.Trim();
            Client.Phone = txtPhone.Text.Trim();
            Client.Address = txtAddress.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void TxtPhone_KeyPress(object? sender, KeyPressEventArgs e)
        {
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isBackspace = e.KeyChar == (char)Keys.Back;
            if (!isDigit && !isBackspace)
                e.Handled = true;
        }
    }
}