namespace ProyectoZ
{
    partial class MainApp
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
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bSetPath = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clean = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDeleteCorchetesF = new System.Windows.Forms.RadioButton();
            this.rbDeleteCorchetesD = new System.Windows.Forms.RadioButton();
            this.rbDeleteSmallFiles = new System.Windows.Forms.RadioButton();
            this.rbDeleteEmptyFolders = new System.Windows.Forms.RadioButton();
            this.bEjecutar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.errors = new System.Windows.Forms.TextBox();
            this.cleanErr = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(157, 17);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(757, 23);
            this.tbPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta de trabajo actual:";
            // 
            // bSetPath
            // 
            this.bSetPath.Location = new System.Drawing.Point(935, 16);
            this.bSetPath.Name = "bSetPath";
            this.bSetPath.Size = new System.Drawing.Size(75, 23);
            this.bSetPath.TabIndex = 2;
            this.bSetPath.Text = "Cambiar";
            this.bSetPath.UseVisualStyleBackColor = true;
            this.bSetPath.Click += new System.EventHandler(this.bSetPath_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(26, 235);
            this.logs.Multiline = true;
            this.logs.Name = "logs";
            this.logs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logs.Size = new System.Drawing.Size(984, 188);
            this.logs.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trazas de la ejecución";
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(865, 198);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(145, 23);
            this.clean.TabIndex = 5;
            this.clean.Text = "Limpiar resultados";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDeleteCorchetesF);
            this.groupBox1.Controls.Add(this.rbDeleteCorchetesD);
            this.groupBox1.Controls.Add(this.rbDeleteSmallFiles);
            this.groupBox1.Controls.Add(this.rbDeleteEmptyFolders);
            this.groupBox1.Location = new System.Drawing.Point(26, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tareas / scripts disponibles";
            // 
            // rbDeleteCorchetesF
            // 
            this.rbDeleteCorchetesF.AutoSize = true;
            this.rbDeleteCorchetesF.Location = new System.Drawing.Point(535, 42);
            this.rbDeleteCorchetesF.Name = "rbDeleteCorchetesF";
            this.rbDeleteCorchetesF.Size = new System.Drawing.Size(158, 19);
            this.rbDeleteCorchetesF.TabIndex = 5;
            this.rbDeleteCorchetesF.TabStop = true;
            this.rbDeleteCorchetesF.Text = "Eliminar [xxx] en ficheros";
            this.rbDeleteCorchetesF.UseVisualStyleBackColor = true;
            // 
            // rbDeleteCorchetesD
            // 
            this.rbDeleteCorchetesD.AutoSize = true;
            this.rbDeleteCorchetesD.Location = new System.Drawing.Point(355, 42);
            this.rbDeleteCorchetesD.Name = "rbDeleteCorchetesD";
            this.rbDeleteCorchetesD.Size = new System.Drawing.Size(160, 19);
            this.rbDeleteCorchetesD.TabIndex = 5;
            this.rbDeleteCorchetesD.TabStop = true;
            this.rbDeleteCorchetesD.Text = "Eliminar [xxx] en carpetas";
            this.rbDeleteCorchetesD.UseVisualStyleBackColor = true;
            // 
            // rbDeleteSmallFiles
            // 
            this.rbDeleteSmallFiles.AutoSize = true;
            this.rbDeleteSmallFiles.Location = new System.Drawing.Point(178, 42);
            this.rbDeleteSmallFiles.Name = "rbDeleteSmallFiles";
            this.rbDeleteSmallFiles.Size = new System.Drawing.Size(157, 19);
            this.rbDeleteSmallFiles.TabIndex = 2;
            this.rbDeleteSmallFiles.TabStop = true;
            this.rbDeleteSmallFiles.Text = "Borrar ficheros pequeños";
            this.rbDeleteSmallFiles.UseVisualStyleBackColor = true;
            // 
            // rbDeleteEmptyFolders
            // 
            this.rbDeleteEmptyFolders.AutoSize = true;
            this.rbDeleteEmptyFolders.Location = new System.Drawing.Point(20, 42);
            this.rbDeleteEmptyFolders.Name = "rbDeleteEmptyFolders";
            this.rbDeleteEmptyFolders.Size = new System.Drawing.Size(139, 19);
            this.rbDeleteEmptyFolders.TabIndex = 1;
            this.rbDeleteEmptyFolders.TabStop = true;
            this.rbDeleteEmptyFolders.Text = "Borrar carpetas vacías";
            this.rbDeleteEmptyFolders.UseVisualStyleBackColor = true;
            // 
            // bEjecutar
            // 
            this.bEjecutar.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bEjecutar.Location = new System.Drawing.Point(395, 172);
            this.bEjecutar.Name = "bEjecutar";
            this.bEjecutar.Size = new System.Drawing.Size(237, 45);
            this.bEjecutar.TabIndex = 0;
            this.bEjecutar.Text = "Ejecutar";
            this.bEjecutar.UseVisualStyleBackColor = true;
            this.bEjecutar.Click += new System.EventHandler(this.bEjecutar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "ERRORES";
            // 
            // errors
            // 
            this.errors.Location = new System.Drawing.Point(26, 455);
            this.errors.Multiline = true;
            this.errors.Name = "errors";
            this.errors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errors.Size = new System.Drawing.Size(984, 85);
            this.errors.TabIndex = 3;
            // 
            // cleanErr
            // 
            this.cleanErr.Location = new System.Drawing.Point(865, 426);
            this.cleanErr.Name = "cleanErr";
            this.cleanErr.Size = new System.Drawing.Size(145, 23);
            this.cleanErr.TabIndex = 5;
            this.cleanErr.Text = "Limpiar errores";
            this.cleanErr.UseVisualStyleBackColor = true;
            this.cleanErr.Click += new System.EventHandler(this.cleanErr_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 557);
            this.Controls.Add(this.cleanErr);
            this.Controls.Add(this.errors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bEjecutar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.bSetPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPath);
            this.Name = "MainApp";
            this.Text = "Utilidades Proyecto Z - by xeviff - versión 3.0";
            this.Shown += new System.EventHandler(this.MainApp_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSetPath;
        private System.Windows.Forms.TextBox logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDeleteSmallFiles;
        private System.Windows.Forms.RadioButton rbDeleteEmptyFolders;
        private System.Windows.Forms.Button bEjecutar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RadioButton rbDeleteCorchetesD;
        private System.Windows.Forms.RadioButton rbDeleteCorchetesF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox errors;
        private System.Windows.Forms.Button cleanErr;
    }
}

