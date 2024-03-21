using System.ComponentModel;

namespace RockRoboVoicePackCreator
{
    partial class RockRoboVoicePackCreatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(RockRoboVoicePackCreatorForm));
            filesListBoxFirst = new ListBox();
            FilesListBoxContextMenuStrip = new ContextMenuStrip(components);
            RemoveRowColorContextStripMenuItem = new ToolStripMenuItem();
            filesListBoxSecond = new ListBox();
            FinalFileModelsListBox = new ListBox();
            addFilesButtonFirst = new Button();
            addFilesButtonSecond = new Button();
            PlayButtonFirst = new Button();
            StopButtonFirst = new Button();
            StopButtonSecond = new Button();
            PlayButtonSecond = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            CreateFromTxtToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            CheckFilesToolStripMenuItem = new ToolStripMenuItem();
            GenerateFilesToolStripMenuItem = new ToolStripMenuItem();
            MarkProcessedLinesInOtherListsStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            FinalFileNameMaskLabel = new Label();
            FinalFileNameMaskTextBox = new TextBox();
            IsUseFileNameFromFinalListCheckBox = new CheckBox();
            DownArrowButtonFirst = new Button();
            UpArrowButtonFirst = new Button();
            UpArrowButtonSecond = new Button();
            DownArrowButtonSecond = new Button();
            FilesListBoxContextMenuStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // filesListBoxFirst
            // 
            filesListBoxFirst.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            filesListBoxFirst.DrawMode = DrawMode.OwnerDrawFixed;
            filesListBoxFirst.FormattingEnabled = true;
            filesListBoxFirst.ItemHeight = 15;
            filesListBoxFirst.Location = new Point(10, 55);
            filesListBoxFirst.Name = "filesListBoxFirst";
            filesListBoxFirst.Size = new Size(277, 304);
            filesListBoxFirst.TabIndex = 0;
            filesListBoxFirst.DrawItem += RowsListBox_DrawItem;
            filesListBoxFirst.SelectedIndexChanged += FilesListBoxFirst_SelectedIndexChanged;
            filesListBoxFirst.MouseDoubleClick += FilesListBoxFirst_MouseDoubleClick;
            filesListBoxFirst.MouseUp += FilesListBoxFirst_RightMouseUp;
            // 
            // FilesListBoxContextMenuStrip
            // 
            FilesListBoxContextMenuStrip.Items.AddRange(new ToolStripItem[] { RemoveRowColorContextStripMenuItem });
            FilesListBoxContextMenuStrip.Name = "FilesListBoxContextMenuStrip";
            FilesListBoxContextMenuStrip.Size = new Size(214, 26);
            // 
            // RemoveRowColorContextStripMenuItem
            // 
            RemoveRowColorContextStripMenuItem.Name = "RemoveRowColorContextStripMenuItem";
            RemoveRowColorContextStripMenuItem.Size = new Size(213, 22);
            RemoveRowColorContextStripMenuItem.Text = "Убрать подкраску строки";
            RemoveRowColorContextStripMenuItem.Click += RemoveRowColorContextStripMenuItem_Click;
            // 
            // filesListBoxSecond
            // 
            filesListBoxSecond.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            filesListBoxSecond.DrawMode = DrawMode.OwnerDrawFixed;
            filesListBoxSecond.FormattingEnabled = true;
            filesListBoxSecond.ItemHeight = 15;
            filesListBoxSecond.Location = new Point(305, 55);
            filesListBoxSecond.Name = "filesListBoxSecond";
            filesListBoxSecond.Size = new Size(277, 304);
            filesListBoxSecond.TabIndex = 1;
            filesListBoxSecond.DrawItem += RowsListBox_DrawItem;
            filesListBoxSecond.SelectedIndexChanged += FilesListBoxSecond_SelectedIndexChanged;
            filesListBoxSecond.MouseDoubleClick += FilesListBoxSecond_MouseDoubleClick;
            filesListBoxSecond.MouseUp += FilesListBoxSecond_RightMouseUp;
            // 
            // FinalFileModelsListBox
            // 
            FinalFileModelsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FinalFileModelsListBox.DrawMode = DrawMode.OwnerDrawFixed;
            FinalFileModelsListBox.FormattingEnabled = true;
            FinalFileModelsListBox.ImeMode = ImeMode.NoControl;
            FinalFileModelsListBox.ItemHeight = 15;
            FinalFileModelsListBox.Location = new Point(598, 55);
            FinalFileModelsListBox.Name = "FinalFileModelsListBox";
            FinalFileModelsListBox.Size = new Size(364, 304);
            FinalFileModelsListBox.TabIndex = 2;
            FinalFileModelsListBox.DrawItem += RowsListBox_DrawItem;
            FinalFileModelsListBox.SelectedIndexChanged += FinalFileModelsListBox_SelectedIndexChanged;
            FinalFileModelsListBox.MouseMove += FinalFileModelsListBox_MouseMove;
            // 
            // addFilesButtonFirst
            // 
            addFilesButtonFirst.Location = new Point(10, 29);
            addFilesButtonFirst.Name = "addFilesButtonFirst";
            addFilesButtonFirst.Size = new Size(111, 23);
            addFilesButtonFirst.TabIndex = 3;
            addFilesButtonFirst.Text = "Изменить список";
            addFilesButtonFirst.UseVisualStyleBackColor = true;
            addFilesButtonFirst.Click += AddFilesButtonFirst_Click;
            // 
            // addFilesButtonSecond
            // 
            addFilesButtonSecond.Location = new Point(305, 29);
            addFilesButtonSecond.Name = "addFilesButtonSecond";
            addFilesButtonSecond.Size = new Size(111, 23);
            addFilesButtonSecond.TabIndex = 4;
            addFilesButtonSecond.Text = "Изменить список";
            addFilesButtonSecond.UseVisualStyleBackColor = true;
            addFilesButtonSecond.Click += AddFilesButtonSecond_Click;
            // 
            // PlayButtonFirst
            // 
            PlayButtonFirst.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PlayButtonFirst.BackgroundImage = Properties.Resources.play_icon;
            PlayButtonFirst.BackgroundImageLayout = ImageLayout.Stretch;
            PlayButtonFirst.Location = new Point(10, 365);
            PlayButtonFirst.Name = "PlayButtonFirst";
            PlayButtonFirst.Size = new Size(23, 23);
            PlayButtonFirst.TabIndex = 5;
            PlayButtonFirst.UseVisualStyleBackColor = true;
            PlayButtonFirst.Click += PlayButtonFirst_Click;
            // 
            // StopButtonFirst
            // 
            StopButtonFirst.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StopButtonFirst.BackgroundImage = Properties.Resources.stop_icon;
            StopButtonFirst.BackgroundImageLayout = ImageLayout.Stretch;
            StopButtonFirst.Location = new Point(39, 365);
            StopButtonFirst.Name = "StopButtonFirst";
            StopButtonFirst.Size = new Size(23, 23);
            StopButtonFirst.TabIndex = 6;
            StopButtonFirst.UseVisualStyleBackColor = true;
            StopButtonFirst.Click += StopButtonFirst_Click;
            // 
            // StopButtonSecond
            // 
            StopButtonSecond.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StopButtonSecond.BackgroundImage = Properties.Resources.stop_icon;
            StopButtonSecond.BackgroundImageLayout = ImageLayout.Stretch;
            StopButtonSecond.Location = new Point(334, 365);
            StopButtonSecond.Name = "StopButtonSecond";
            StopButtonSecond.Size = new Size(23, 23);
            StopButtonSecond.TabIndex = 8;
            StopButtonSecond.UseVisualStyleBackColor = true;
            StopButtonSecond.Click += StopButtonSecond_Click;
            // 
            // PlayButtonSecond
            // 
            PlayButtonSecond.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PlayButtonSecond.BackgroundImage = Properties.Resources.play_icon;
            PlayButtonSecond.BackgroundImageLayout = ImageLayout.Stretch;
            PlayButtonSecond.Location = new Point(305, 365);
            PlayButtonSecond.Name = "PlayButtonSecond";
            PlayButtonSecond.Size = new Size(23, 23);
            PlayButtonSecond.TabIndex = 7;
            PlayButtonSecond.UseVisualStyleBackColor = true;
            PlayButtonSecond.Click += PlayButtonSecond_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { CreateFromTxtToolStripMenuItem, OpenToolStripMenuItem, SaveToolStripMenuItem, CheckFilesToolStripMenuItem, GenerateFilesToolStripMenuItem, MarkProcessedLinesInOtherListsStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(116, 20);
            toolStripMenuItem1.Text = "Итоговый список";
            toolStripMenuItem1.DropDownOpening += ToolStripMenuItem1_DropDownOpening;
            // 
            // CreateFromTxtToolStripMenuItem
            // 
            CreateFromTxtToolStripMenuItem.Name = "CreateFromTxtToolStripMenuItem";
            CreateFromTxtToolStripMenuItem.Size = new Size(369, 22);
            CreateFromTxtToolStripMenuItem.Text = "Создать из списка .txt";
            CreateFromTxtToolStripMenuItem.Click += CreateFromTxtToolStripMenuItem_Click;
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(369, 22);
            OpenToolStripMenuItem.Text = "Открыть...";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(369, 22);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // CheckFilesToolStripMenuItem
            // 
            CheckFilesToolStripMenuItem.Name = "CheckFilesToolStripMenuItem";
            CheckFilesToolStripMenuItem.Size = new Size(369, 22);
            CheckFilesToolStripMenuItem.Text = "Проверить расположение файлов";
            CheckFilesToolStripMenuItem.Visible = false;
            // 
            // GenerateFilesToolStripMenuItem
            // 
            GenerateFilesToolStripMenuItem.Name = "GenerateFilesToolStripMenuItem";
            GenerateFilesToolStripMenuItem.Size = new Size(369, 22);
            GenerateFilesToolStripMenuItem.Text = "Сформировать файлы";
            GenerateFilesToolStripMenuItem.Click += GenerateFilesToolStripMenuItem_Click;
            // 
            // MarkProcessedLinesInOtherListsStripMenuItem
            // 
            MarkProcessedLinesInOtherListsStripMenuItem.Name = "MarkProcessedLinesInOtherListsStripMenuItem";
            MarkProcessedLinesInOtherListsStripMenuItem.Size = new Size(369, 22);
            MarkProcessedLinesInOtherListsStripMenuItem.Text = "Отметить обработанные строки в остальных списках";
            MarkProcessedLinesInOtherListsStripMenuItem.Click += MarkProcessedLinesInOtherListsStripMenuItem_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 8000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 100;
            // 
            // FinalFileNameMaskLabel
            // 
            FinalFileNameMaskLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FinalFileNameMaskLabel.AutoSize = true;
            FinalFileNameMaskLabel.Location = new Point(598, 399);
            FinalFileNameMaskLabel.Margin = new Padding(0);
            FinalFileNameMaskLabel.Name = "FinalFileNameMaskLabel";
            FinalFileNameMaskLabel.Size = new Size(309, 15);
            FinalFileNameMaskLabel.TabIndex = 11;
            FinalFileNameMaskLabel.Text = "Определять наименование конечного файла по маске";
            // 
            // FinalFileNameMaskTextBox
            // 
            FinalFileNameMaskTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FinalFileNameMaskTextBox.Location = new Point(598, 417);
            FinalFileNameMaskTextBox.Name = "FinalFileNameMaskTextBox";
            FinalFileNameMaskTextBox.Size = new Size(364, 23);
            FinalFileNameMaskTextBox.TabIndex = 12;
            // 
            // IsUseFileNameFromFinalListCheckBox
            // 
            IsUseFileNameFromFinalListCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            IsUseFileNameFromFinalListCheckBox.AutoSize = true;
            IsUseFileNameFromFinalListCheckBox.Location = new Point(598, 371);
            IsUseFileNameFromFinalListCheckBox.Name = "IsUseFileNameFromFinalListCheckBox";
            IsUseFileNameFromFinalListCheckBox.Size = new Size(281, 19);
            IsUseFileNameFromFinalListCheckBox.TabIndex = 13;
            IsUseFileNameFromFinalListCheckBox.Text = "Использовать наименование файла из списка";
            IsUseFileNameFromFinalListCheckBox.UseVisualStyleBackColor = true;
            IsUseFileNameFromFinalListCheckBox.CheckedChanged += IsUseFileNameFromFinalListCheckBox_CheckedChanged;
            // 
            // DownArrowButtonFirst
            // 
            DownArrowButtonFirst.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DownArrowButtonFirst.BackgroundImage = Properties.Resources.arrow_down;
            DownArrowButtonFirst.BackgroundImageLayout = ImageLayout.Stretch;
            DownArrowButtonFirst.Location = new Point(68, 365);
            DownArrowButtonFirst.Name = "DownArrowButtonFirst";
            DownArrowButtonFirst.Size = new Size(23, 23);
            DownArrowButtonFirst.TabIndex = 14;
            DownArrowButtonFirst.UseVisualStyleBackColor = true;
            DownArrowButtonFirst.Click += DownArrowButtonFirst_Click;
            // 
            // UpArrowButtonFirst
            // 
            UpArrowButtonFirst.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpArrowButtonFirst.BackgroundImage = Properties.Resources.arrow_up;
            UpArrowButtonFirst.BackgroundImageLayout = ImageLayout.Stretch;
            UpArrowButtonFirst.Location = new Point(97, 365);
            UpArrowButtonFirst.Name = "UpArrowButtonFirst";
            UpArrowButtonFirst.Size = new Size(23, 23);
            UpArrowButtonFirst.TabIndex = 15;
            UpArrowButtonFirst.UseVisualStyleBackColor = true;
            UpArrowButtonFirst.Click += UpArrowButtonFirst_Click;
            // 
            // UpArrowButtonSecond
            // 
            UpArrowButtonSecond.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpArrowButtonSecond.BackgroundImage = Properties.Resources.arrow_up;
            UpArrowButtonSecond.BackgroundImageLayout = ImageLayout.Stretch;
            UpArrowButtonSecond.Location = new Point(392, 365);
            UpArrowButtonSecond.Name = "UpArrowButtonSecond";
            UpArrowButtonSecond.Size = new Size(23, 23);
            UpArrowButtonSecond.TabIndex = 17;
            UpArrowButtonSecond.UseVisualStyleBackColor = true;
            UpArrowButtonSecond.Click += UpArrowButtonSecond_Click;
            // 
            // DownArrowButtonSecond
            // 
            DownArrowButtonSecond.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DownArrowButtonSecond.BackgroundImage = Properties.Resources.arrow_down;
            DownArrowButtonSecond.BackgroundImageLayout = ImageLayout.Stretch;
            DownArrowButtonSecond.Location = new Point(363, 365);
            DownArrowButtonSecond.Name = "DownArrowButtonSecond";
            DownArrowButtonSecond.Size = new Size(23, 23);
            DownArrowButtonSecond.TabIndex = 16;
            DownArrowButtonSecond.UseVisualStyleBackColor = true;
            DownArrowButtonSecond.Click += DownArrowButtonSecond_Click;
            // 
            // RockRoboVoicePackCreatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(984, 461);
            Controls.Add(UpArrowButtonSecond);
            Controls.Add(DownArrowButtonSecond);
            Controls.Add(UpArrowButtonFirst);
            Controls.Add(DownArrowButtonFirst);
            Controls.Add(IsUseFileNameFromFinalListCheckBox);
            Controls.Add(FinalFileNameMaskTextBox);
            Controls.Add(FinalFileNameMaskLabel);
            Controls.Add(StopButtonSecond);
            Controls.Add(PlayButtonSecond);
            Controls.Add(StopButtonFirst);
            Controls.Add(PlayButtonFirst);
            Controls.Add(addFilesButtonSecond);
            Controls.Add(addFilesButtonFirst);
            Controls.Add(FinalFileModelsListBox);
            Controls.Add(filesListBoxSecond);
            Controls.Add(filesListBoxFirst);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1000, 500);
            Name = "RockRoboVoicePackCreatorForm";
            Text = "RockRoboVoicePackCreator";
            FilesListBoxContextMenuStrip.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox filesListBoxFirst;
        private ListBox filesListBoxSecond;
        private ListBox FinalFileModelsListBox;
        private Button addFilesButtonFirst;
        private Button addFilesButtonSecond;
        private Button PlayButtonFirst;
        private Button StopButtonFirst;
        private Button StopButtonSecond;
        private Button PlayButtonSecond;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem CheckFilesToolStripMenuItem;
        private ToolStripMenuItem CreateFromTxtToolStripMenuItem;
        private ToolTip toolTip1;
        private ToolStripMenuItem GenerateFilesToolStripMenuItem;
        private Label FinalFileNameMaskLabel;
        private TextBox FinalFileNameMaskTextBox;
        private CheckBox IsUseFileNameFromFinalListCheckBox;
        private ContextMenuStrip FilesListBoxContextMenuStrip;
        private ToolStripMenuItem RemoveRowColorContextStripMenuItem;
        private Button DownArrowButtonFirst;
        private Button UpArrowButtonFirst;
        private Button UpArrowButtonSecond;
        private Button DownArrowButtonSecond;
        private ToolStripMenuItem MarkProcessedLinesInOtherListsStripMenuItem;
    }
}