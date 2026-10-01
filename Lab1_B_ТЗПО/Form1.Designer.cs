namespace Lab1_B_ТЗПО
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblArtist = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpCollectionType = new System.Windows.Forms.GroupBox();
            this.rdoNonGeneric = new System.Windows.Forms.RadioButton();
            this.rdoGeneric = new System.Windows.Forms.RadioButton();
            this.lstTracks = new System.Windows.Forms.ListBox();
            this.btnSortGenre = new System.Windows.Forms.Button();
            this.btnSortDuration = new System.Windows.Forms.Button();
            this.lblSearchArtist = new System.Windows.Forms.Label();
            this.txtSearchArtist = new System.Windows.Forms.TextBox();
            this.btnShowArtist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpCollectionType.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Назва";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(280, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(12, 50);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(58, 15);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Виконавець";
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(100, 47);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(280, 23);
            this.txtArtist.TabIndex = 3;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Location = new System.Drawing.Point(12, 85);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(40, 15);
            this.lblAlbum.TabIndex = 4;
            this.lblAlbum.Text = "Альбом";
            // 
            // txtAlbum
            // 
            this.txtAlbum.Location = new System.Drawing.Point(100, 82);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(280, 23);
            this.txtAlbum.TabIndex = 5;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(12, 120);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(37, 15);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "Жанр";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(100, 117);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(280, 23);
            this.txtGenre.TabIndex = 7;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 155);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(53, 15);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Тривалість";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(100, 152);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(280, 23);
            this.txtDuration.TabIndex = 9;
            this.txtDuration.PlaceholderText = "hh:mm:ss або mm:ss або хвилини";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(100, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(280, 27);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Додати композицію";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpCollectionType
            // 
            this.grpCollectionType.Controls.Add(this.rdoNonGeneric);
            this.grpCollectionType.Controls.Add(this.rdoGeneric);
            this.grpCollectionType.Location = new System.Drawing.Point(400, 12);
            this.grpCollectionType.Name = "grpCollectionType";
            this.grpCollectionType.Size = new System.Drawing.Size(280, 60);
            this.grpCollectionType.TabIndex = 11;
            this.grpCollectionType.TabStop = false;
            this.grpCollectionType.Text = "Тип колекції";
            // 
            // rdoNonGeneric
            // 
            this.rdoNonGeneric.AutoSize = true;
            this.rdoNonGeneric.Checked = true;
            this.rdoNonGeneric.Location = new System.Drawing.Point(15, 23);
            this.rdoNonGeneric.Name = "rdoNonGeneric";
            this.rdoNonGeneric.Size = new System.Drawing.Size(124, 19);
            this.rdoNonGeneric.TabIndex = 12;
            this.rdoNonGeneric.TabStop = true;
            this.rdoNonGeneric.Text = "Stack (non-generic)";
            this.rdoNonGeneric.UseVisualStyleBackColor = true;
            this.rdoNonGeneric.CheckedChanged += new System.EventHandler(this.rdoCollection_CheckedChanged);
            // 
            // rdoGeneric
            // 
            this.rdoGeneric.AutoSize = true;
            this.rdoGeneric.Location = new System.Drawing.Point(145, 23);
            this.rdoGeneric.Name = "rdoGeneric";
            this.rdoGeneric.Size = new System.Drawing.Size(115, 19);
            this.rdoGeneric.TabIndex = 13;
            this.rdoGeneric.Text = "Stack<Track>";
            this.rdoGeneric.UseVisualStyleBackColor = true;
            this.rdoGeneric.CheckedChanged += new System.EventHandler(this.rdoCollection_CheckedChanged);
            // 
            // lstTracks
            // 
            this.lstTracks.FormattingEnabled = true;
            this.lstTracks.HorizontalScrollbar = true;
            this.lstTracks.ItemHeight = 15;
            this.lstTracks.Location = new System.Drawing.Point(12, 230);
            this.lstTracks.Name = "lstTracks";
            this.lstTracks.Size = new System.Drawing.Size(668, 244);
            this.lstTracks.TabIndex = 14;
            // 
            // btnSortGenre
            // 
            this.btnSortGenre.Location = new System.Drawing.Point(400, 80);
            this.btnSortGenre.Name = "btnSortGenre";
            this.btnSortGenre.Size = new System.Drawing.Size(130, 27);
            this.btnSortGenre.TabIndex = 15;
            this.btnSortGenre.Text = "Сортувати за жанром";
            this.btnSortGenre.UseVisualStyleBackColor = true;
            this.btnSortGenre.Click += new System.EventHandler(this.btnSortGenre_Click);
            // 
            // btnSortDuration
            // 
            this.btnSortDuration.Location = new System.Drawing.Point(540, 80);
            this.btnSortDuration.Name = "btnSortDuration";
            this.btnSortDuration.Size = new System.Drawing.Size(140, 27);
            this.btnSortDuration.TabIndex = 16;
            this.btnSortDuration.Text = "Сортувати за тривалістю";
            this.btnSortDuration.UseVisualStyleBackColor = true;
            this.btnSortDuration.Click += new System.EventHandler(this.btnSortDuration_Click);
            // 
            // lblSearchArtist
            // 
            this.lblSearchArtist.AutoSize = true;
            this.lblSearchArtist.Location = new System.Drawing.Point(400, 120);
            this.lblSearchArtist.Name = "lblSearchArtist";
            this.lblSearchArtist.Size = new System.Drawing.Size(96, 15);
            this.lblSearchArtist.TabIndex = 17;
            this.lblSearchArtist.Text = "Пошук виконавця";
            // 
            // txtSearchArtist
            // 
            this.txtSearchArtist.Location = new System.Drawing.Point(400, 140);
            this.txtSearchArtist.Name = "txtSearchArtist";
            this.txtSearchArtist.Size = new System.Drawing.Size(140, 23);
            this.txtSearchArtist.TabIndex = 18;
            // 
            // btnShowArtist
            // 
            this.btnShowArtist.Location = new System.Drawing.Point(545, 138);
            this.btnShowArtist.Name = "btnShowArtist";
            this.btnShowArtist.Size = new System.Drawing.Size(135, 27);
            this.btnShowArtist.TabIndex = 19;
            this.btnShowArtist.Text = "Показати композиції";
            this.btnShowArtist.UseVisualStyleBackColor = true;
            this.btnShowArtist.Click += new System.EventHandler(this.btnShowArtist_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(400, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 27);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(540, 185);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(140, 27);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Завантажити";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 486);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowArtist);
            this.Controls.Add(this.txtSearchArtist);
            this.Controls.Add(this.lblSearchArtist);
            this.Controls.Add(this.btnSortDuration);
            this.Controls.Add(this.btnSortGenre);
            this.Controls.Add(this.lstTracks);
            this.Controls.Add(this.grpCollectionType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Лабораторна: Серіалізація об\'єктів — Варіант 8";
            this.grpCollectionType.ResumeLayout(false);
            this.grpCollectionType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Оголошення контролів (імена використовуються у коді)
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpCollectionType;
        private System.Windows.Forms.RadioButton rdoNonGeneric;
        private System.Windows.Forms.RadioButton rdoGeneric;
        private System.Windows.Forms.ListBox lstTracks;
        private System.Windows.Forms.Button btnSortGenre;
        private System.Windows.Forms.Button btnSortDuration;
        private System.Windows.Forms.Label lblSearchArtist;
        private System.Windows.Forms.TextBox txtSearchArtist;
        private System.Windows.Forms.Button btnShowArtist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}
