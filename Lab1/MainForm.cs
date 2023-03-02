using System;
using System.Windows.Forms;
using Lab1.Service;

namespace Lab1
{
    public partial class MainForm : Form
    {
        const string statusPrefix = "Статус: ";
        
        const string warnEmptyUsername = "имя пользователя не может быть пустым";
    
        const string infoPressSelectUser = "нажмите выбрать пользователя или соответствующий пункт меню";
        const string infoPressUsername = "введите имя пользователя";
        const string infoUserSelected = "работа от имени пользователя: ";

        const string infoSignedDoc = "Подписанный документ: ";

        string documentText;
        string username;
        string formTitle;

        DocumentService service;

        public MainForm()
        {
            InitializeComponent();

            service = new DocumentService();
            formTitle = Text;

            disableServiceControls();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUserSelect_Click(object sender, EventArgs e)
        {
            menuSelect_Click(sender, e);
        }

        private void menuSelect_Click(object sender, EventArgs e)
        {
            if (!service.ExistUserContainer(username))
            {
                var result = MessageBox.Show($"Отсутствует контейнер для пользователя: {username}. Создать новый контейнер?", 
                    "Создание нового контейнера пользователя", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK) 
                {
                    return;
                }
            }
            service.CreateUserContainer(username);

            btnLoadDoc.Enabled = true;

            menuLoad.Enabled = true;
          
            menuCreate.Enabled = true;
            menuExport.Enabled = true;
            menuImport.Enabled = true;
            menuDelete.Enabled = true;

            tbUsername.ReadOnly = true;

            btnUserSelect.Visible = false;
            btnChangeUser.Visible = true;

            MessageBox.Show($"Вы вошли от имени пользователя: {username}", 
                "Совершен вход", MessageBoxButtons.OK);

            tbOpStatus.Text = statusPrefix + infoUserSelected + username;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            username = tbUsername.Text.Trim();

            if (tbUsername.Text.Trim().Equals(string.Empty)) 
            {
                tbOpStatus.Text = statusPrefix + warnEmptyUsername;
                menuSelect.Enabled = false;
                btnUserSelect.Enabled = false;
                return;
            }
            tbOpStatus.Clear();

            menuSelect.Enabled = true;
            btnUserSelect.Enabled = true;
            tbOpStatus.Text = statusPrefix + infoPressSelectUser;
        }

        private void menuCreate_Click(object sender, EventArgs e)
        {
            btnSaveDoc.Enabled = true;

            tbDocContent.Clear();
            tbDocContent.Enabled = true;

            btnSaveDoc.Enabled = true;

            menuSave.Enabled = true;
            menuClearContent.Enabled = true;

            tbDocContent.Focus();

            Text = infoSignedDoc + username;
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            documentText = tbDocContent.Text.Trim();

            var saveDialog = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = DocumentService.GetDocumentExtensionDesc(),
                Title = "Сохранить подписанный документ",
            };
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = saveDialog.FileName;

            try
            {
                service.SaveDocument(new DocumentPayload()
                {
                    filename = filename,
                    username = username,
                    text = documentText,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                return;
            }
        }

        private void menuExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = DocumentService.GetPublicKeyExtensionDesc(),
                Title = "Сохранить открытый ключ",
                FileName = username,
            };
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            };
            string filename = saveDialog.FileName;

            try
            {
                service.ExportPublicKey(new PublicKeyPayload()
                {
                    filename = filename,
                    username = username,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                return;
            }
        }

        private void menuImport_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = DocumentService.GetPublicKeyExtensionDesc(),
            };
            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = openDialog.FileName;

            try
            {
                service.ImportPublicKey(new PublicKeyPayload()
                {
                    filename = filename,
                    username = username,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnSaveDoc_Click(object sender, EventArgs e)
        {
            menuSave_Click(sender, e);
        }

        private void btnLoadDoc_Click(object sender, EventArgs e)
        {
            menuLoad_Click(sender, e);
        }

        private void menuLoad_Click(object sender, EventArgs e)
        {
            DocumentPayload loadResult;

            var openDialog = new OpenFileDialog
            {
                Filter = DocumentService.GetDocumentExtensionDesc(),
            };
            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = openDialog.FileName;

            try
            {
                loadResult = service.LoadDocument(new DocumentPayload()
                {
                    filename = filename,
                    username = username,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                return;
            }


            tbDocContent.Enabled = true;
            tbDocContent.Text = loadResult.text;

            Text = infoSignedDoc + username;
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Все несохраненные изменения будут утеряны. Продолжить?",
                "Сменить пользователя", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }
            disableServiceControls();
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                service.DeleteKeyPair(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                return;
            }
            finally
            {
                disableServiceControls();
            }
        }

        private void disableServiceControls()
        {
            Text = formTitle;

            tbUsername.Clear();
            tbUsername.ReadOnly = false;

            menuSelect.Enabled = false;
            btnUserSelect.Enabled = false;

            btnLoadDoc.Enabled = false;
            btnSaveDoc.Enabled = false;

            tbDocContent.Enabled = false;
            tbDocContent.Clear();

            menuCreate.Enabled = false;
            menuSave.Enabled = false;
            menuLoad.Enabled = false;

            menuExport.Enabled = false;
            menuImport.Enabled = false;
            menuDelete.Enabled = false;

            menuClearContent.Enabled = false;   

            btnChangeUser.Visible = false;
            btnUserSelect.Visible = true;

            tbUsername.Focus();

            tbOpStatus.Text = statusPrefix + infoPressUsername;
        }

        private void menuClearContent_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Все несохраненные изменения будут утеряны. Продолжить?",
                "Очистить поле ввода", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }
            tbDocContent.Clear();
        }
    }
}
