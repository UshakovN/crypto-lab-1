namespace Lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menyKeyManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnSaveDoc = new System.Windows.Forms.Button();
            this.btnLoadDoc = new System.Windows.Forms.Button();
            this.btnUserSelect = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tbDocContent = new System.Windows.Forms.RichTextBox();
            this.tbOpStatus = new System.Windows.Forms.TextBox();
            this.menuClearContent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menyKeyManage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(573, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreate,
            this.menuLoad,
            this.menuSave,
            this.menuClearContent,
            this.menuExit,
            this.menuAbout});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 26);
            this.menuFile.Text = "Файл";
            // 
            // menuCreate
            // 
            this.menuCreate.Name = "menuCreate";
            this.menuCreate.Size = new System.Drawing.Size(239, 26);
            this.menuCreate.Text = "Создать";
            this.menuCreate.Click += new System.EventHandler(this.menuCreate_Click);
            // 
            // menuLoad
            // 
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.Size = new System.Drawing.Size(239, 26);
            this.menuLoad.Text = "Загрузить";
            this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(239, 26);
            this.menuSave.Text = "Сохранить";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(239, 26);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(239, 26);
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // menyKeyManage
            // 
            this.menyKeyManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
            this.menuImport,
            this.menuDelete,
            this.menuSelect});
            this.menyKeyManage.Name = "menyKeyManage";
            this.menyKeyManage.Size = new System.Drawing.Size(175, 26);
            this.menyKeyManage.Text = "Управление ключами";
            // 
            // menuExport
            // 
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(271, 26);
            this.menuExport.Text = "Экспорт открытого ключа";
            this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
            // 
            // menuImport
            // 
            this.menuImport.Name = "menuImport";
            this.menuImport.Size = new System.Drawing.Size(271, 26);
            this.menuImport.Text = "Импорт открытого ключа";
            this.menuImport.Click += new System.EventHandler(this.menuImport_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(271, 26);
            this.menuDelete.Text = "Удаление пары ключей";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuSelect
            // 
            this.menuSelect.Name = "menuSelect";
            this.menuSelect.Size = new System.Drawing.Size(271, 26);
            this.menuSelect.Text = "Выбор закрытого ключа";
            this.menuSelect.Click += new System.EventHandler(this.menuSelect_Click);
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.btnChangeUser);
            this.panelMain.Controls.Add(this.btnSaveDoc);
            this.panelMain.Controls.Add(this.btnLoadDoc);
            this.panelMain.Controls.Add(this.btnUserSelect);
            this.panelMain.Controls.Add(this.labelUsername);
            this.panelMain.Controls.Add(this.tbUsername);
            this.panelMain.Location = new System.Drawing.Point(11, 38);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(551, 81);
            this.panelMain.TabIndex = 2;
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(208, 19);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(121, 45);
            this.btnChangeUser.TabIndex = 7;
            this.btnChangeUser.Text = "Сменить пользователя";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // btnSaveDoc
            // 
            this.btnSaveDoc.Location = new System.Drawing.Point(441, 19);
            this.btnSaveDoc.Name = "btnSaveDoc";
            this.btnSaveDoc.Size = new System.Drawing.Size(100, 45);
            this.btnSaveDoc.TabIndex = 6;
            this.btnSaveDoc.Text = "Сохранить документ";
            this.btnSaveDoc.UseVisualStyleBackColor = true;
            this.btnSaveDoc.Click += new System.EventHandler(this.btnSaveDoc_Click);
            // 
            // btnLoadDoc
            // 
            this.btnLoadDoc.Location = new System.Drawing.Point(335, 19);
            this.btnLoadDoc.Name = "btnLoadDoc";
            this.btnLoadDoc.Size = new System.Drawing.Size(100, 45);
            this.btnLoadDoc.TabIndex = 5;
            this.btnLoadDoc.Text = "Загрузить документ";
            this.btnLoadDoc.UseVisualStyleBackColor = true;
            this.btnLoadDoc.Click += new System.EventHandler(this.btnLoadDoc_Click);
            // 
            // btnUserSelect
            // 
            this.btnUserSelect.Location = new System.Drawing.Point(208, 19);
            this.btnUserSelect.Name = "btnUserSelect";
            this.btnUserSelect.Size = new System.Drawing.Size(121, 45);
            this.btnUserSelect.TabIndex = 4;
            this.btnUserSelect.Text = "Выбрать пользователя";
            this.btnUserSelect.UseVisualStyleBackColor = true;
            this.btnUserSelect.Click += new System.EventHandler(this.btnUserSelect_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(37, 15);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(129, 16);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Имя пользователя";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(14, 34);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(184, 22);
            this.tbUsername.TabIndex = 3;
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            // 
            // panelContent
            // 
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Controls.Add(this.tbDocContent);
            this.panelContent.Location = new System.Drawing.Point(12, 137);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(550, 386);
            this.panelContent.TabIndex = 7;
            // 
            // tbDocContent
            // 
            this.tbDocContent.Location = new System.Drawing.Point(9, 10);
            this.tbDocContent.Name = "tbDocContent";
            this.tbDocContent.Size = new System.Drawing.Size(527, 358);
            this.tbDocContent.TabIndex = 0;
            this.tbDocContent.Text = "";
            // 
            // tbOpStatus
            // 
            this.tbOpStatus.Location = new System.Drawing.Point(12, 529);
            this.tbOpStatus.Name = "tbOpStatus";
            this.tbOpStatus.ReadOnly = true;
            this.tbOpStatus.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbOpStatus.Size = new System.Drawing.Size(550, 22);
            this.tbOpStatus.TabIndex = 8;
            // 
            // menuClearContent
            // 
            this.menuClearContent.Name = "menuClearContent";
            this.menuClearContent.Size = new System.Drawing.Size(239, 26);
            this.menuClearContent.Text = "Очистить поле ввода";
            this.menuClearContent.Click += new System.EventHandler(this.menuClearContent_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 561);
            this.Controls.Add(this.tbOpStatus);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "А-05-19 Ушаков Никита ЛР-1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuCreate;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menyKeyManage;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuImport;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuSelect;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button btnSaveDoc;
        private System.Windows.Forms.Button btnLoadDoc;
        private System.Windows.Forms.Button btnUserSelect;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.RichTextBox tbDocContent;
        private System.Windows.Forms.TextBox tbOpStatus;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.ToolStripMenuItem menuClearContent;
    }
}

