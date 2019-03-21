namespace MG
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtCamelSingular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCamelPlural = new System.Windows.Forms.TextBox();
            this.txtCapitalPlural = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbIAppSericeGenerator = new System.Windows.Forms.RichTextBox();
            this.txtCapitalSingular = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveOnDisk = new System.Windows.Forms.Button();
            this.rtbAppSericeGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbEntityDtoGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbEntityUpdateDtoGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbEntityCreateDtoGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbIndexJsGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbIndexCshtmlGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbCreateJsGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbCreateCsHtmlGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbUpdateJsGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbUpdateCsHtmlGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbPermissionNameGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbAutorizationProviderGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbAppJsGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbNavigationProviderGenerator = new System.Windows.Forms.RichTextBox();
            this.rtbMenuNavBarGenerator = new System.Windows.Forms.RichTextBox();
            this.lbxCombos = new System.Windows.Forms.ListBox();
            this.btnAgregarCombo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRelateFieldDisplay = new System.Windows.Forms.TextBox();
            this.txtRelateFieldValue = new System.Windows.Forms.TextBox();
            this.txtRelateEntity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFaIcon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.Localizations = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(182, 125);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(158, 34);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtCamelSingular
            // 
            this.txtCamelSingular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamelSingular.Location = new System.Drawing.Point(182, 14);
            this.txtCamelSingular.Name = "txtCamelSingular";
            this.txtCamelSingular.Size = new System.Drawing.Size(158, 26);
            this.txtCamelSingular.TabIndex = 1;
            this.txtCamelSingular.TextChanged += new System.EventHandler(this.txtEntityNameSingular_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entity name Singular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Entity name plural camell case";
            // 
            // txtCamelPlural
            // 
            this.txtCamelPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamelPlural.Location = new System.Drawing.Point(182, 70);
            this.txtCamelPlural.Name = "txtCamelPlural";
            this.txtCamelPlural.Size = new System.Drawing.Size(158, 26);
            this.txtCamelPlural.TabIndex = 5;
            // 
            // txtCapitalPlural
            // 
            this.txtCapitalPlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapitalPlural.Location = new System.Drawing.Point(182, 97);
            this.txtCapitalPlural.Name = "txtCapitalPlural";
            this.txtCapitalPlural.Size = new System.Drawing.Size(158, 26);
            this.txtCapitalPlural.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Entity name plural capital case";
            // 
            // rtbIAppSericeGenerator
            // 
            this.rtbIAppSericeGenerator.Location = new System.Drawing.Point(12, 162);
            this.rtbIAppSericeGenerator.Name = "rtbIAppSericeGenerator";
            this.rtbIAppSericeGenerator.Size = new System.Drawing.Size(328, 68);
            this.rtbIAppSericeGenerator.TabIndex = 3;
            this.rtbIAppSericeGenerator.Text = "";
            this.rtbIAppSericeGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // txtCapitalSingular
            // 
            this.txtCapitalSingular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapitalSingular.Location = new System.Drawing.Point(182, 41);
            this.txtCapitalSingular.Name = "txtCapitalSingular";
            this.txtCapitalSingular.Size = new System.Drawing.Size(158, 26);
            this.txtCapitalSingular.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Entity name singular capital case";
            // 
            // btnSaveOnDisk
            // 
            this.btnSaveOnDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOnDisk.Location = new System.Drawing.Point(1129, 7);
            this.btnSaveOnDisk.Name = "btnSaveOnDisk";
            this.btnSaveOnDisk.Size = new System.Drawing.Size(75, 127);
            this.btnSaveOnDisk.TabIndex = 3;
            this.btnSaveOnDisk.Text = "Save";
            this.btnSaveOnDisk.UseVisualStyleBackColor = true;
            this.btnSaveOnDisk.Click += new System.EventHandler(this.btnSaveOnDisk_Click);
            // 
            // rtbAppSericeGenerator
            // 
            this.rtbAppSericeGenerator.Location = new System.Drawing.Point(12, 236);
            this.rtbAppSericeGenerator.Name = "rtbAppSericeGenerator";
            this.rtbAppSericeGenerator.Size = new System.Drawing.Size(328, 62);
            this.rtbAppSericeGenerator.TabIndex = 3;
            this.rtbAppSericeGenerator.Text = "";
            this.rtbAppSericeGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbEntityDtoGenerator
            // 
            this.rtbEntityDtoGenerator.Location = new System.Drawing.Point(12, 304);
            this.rtbEntityDtoGenerator.Name = "rtbEntityDtoGenerator";
            this.rtbEntityDtoGenerator.Size = new System.Drawing.Size(328, 70);
            this.rtbEntityDtoGenerator.TabIndex = 3;
            this.rtbEntityDtoGenerator.Text = "";
            this.rtbEntityDtoGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbEntityUpdateDtoGenerator
            // 
            this.rtbEntityUpdateDtoGenerator.Location = new System.Drawing.Point(12, 380);
            this.rtbEntityUpdateDtoGenerator.Name = "rtbEntityUpdateDtoGenerator";
            this.rtbEntityUpdateDtoGenerator.Size = new System.Drawing.Size(328, 75);
            this.rtbEntityUpdateDtoGenerator.TabIndex = 3;
            this.rtbEntityUpdateDtoGenerator.Text = "";
            this.rtbEntityUpdateDtoGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbEntityCreateDtoGenerator
            // 
            this.rtbEntityCreateDtoGenerator.Location = new System.Drawing.Point(12, 461);
            this.rtbEntityCreateDtoGenerator.Name = "rtbEntityCreateDtoGenerator";
            this.rtbEntityCreateDtoGenerator.Size = new System.Drawing.Size(328, 72);
            this.rtbEntityCreateDtoGenerator.TabIndex = 3;
            this.rtbEntityCreateDtoGenerator.Text = "";
            this.rtbEntityCreateDtoGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbIndexJsGenerator
            // 
            this.rtbIndexJsGenerator.Location = new System.Drawing.Point(12, 539);
            this.rtbIndexJsGenerator.Name = "rtbIndexJsGenerator";
            this.rtbIndexJsGenerator.Size = new System.Drawing.Size(328, 68);
            this.rtbIndexJsGenerator.TabIndex = 3;
            this.rtbIndexJsGenerator.Text = "";
            this.rtbIndexJsGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbIndexCshtmlGenerator
            // 
            this.rtbIndexCshtmlGenerator.Location = new System.Drawing.Point(346, 162);
            this.rtbIndexCshtmlGenerator.Name = "rtbIndexCshtmlGenerator";
            this.rtbIndexCshtmlGenerator.Size = new System.Drawing.Size(420, 68);
            this.rtbIndexCshtmlGenerator.TabIndex = 3;
            this.rtbIndexCshtmlGenerator.Text = "";
            this.rtbIndexCshtmlGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbCreateJsGenerator
            // 
            this.rtbCreateJsGenerator.Location = new System.Drawing.Point(346, 236);
            this.rtbCreateJsGenerator.Name = "rtbCreateJsGenerator";
            this.rtbCreateJsGenerator.Size = new System.Drawing.Size(420, 62);
            this.rtbCreateJsGenerator.TabIndex = 3;
            this.rtbCreateJsGenerator.Text = "";
            this.rtbCreateJsGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbCreateCsHtmlGenerator
            // 
            this.rtbCreateCsHtmlGenerator.Location = new System.Drawing.Point(346, 304);
            this.rtbCreateCsHtmlGenerator.Name = "rtbCreateCsHtmlGenerator";
            this.rtbCreateCsHtmlGenerator.Size = new System.Drawing.Size(420, 68);
            this.rtbCreateCsHtmlGenerator.TabIndex = 3;
            this.rtbCreateCsHtmlGenerator.Text = "";
            this.rtbCreateCsHtmlGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbUpdateJsGenerator
            // 
            this.rtbUpdateJsGenerator.Location = new System.Drawing.Point(346, 378);
            this.rtbUpdateJsGenerator.Name = "rtbUpdateJsGenerator";
            this.rtbUpdateJsGenerator.Size = new System.Drawing.Size(420, 77);
            this.rtbUpdateJsGenerator.TabIndex = 3;
            this.rtbUpdateJsGenerator.Text = "";
            this.rtbUpdateJsGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbUpdateCsHtmlGenerator
            // 
            this.rtbUpdateCsHtmlGenerator.Location = new System.Drawing.Point(346, 461);
            this.rtbUpdateCsHtmlGenerator.Name = "rtbUpdateCsHtmlGenerator";
            this.rtbUpdateCsHtmlGenerator.Size = new System.Drawing.Size(420, 72);
            this.rtbUpdateCsHtmlGenerator.TabIndex = 3;
            this.rtbUpdateCsHtmlGenerator.Text = "";
            this.rtbUpdateCsHtmlGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbPermissionNameGenerator
            // 
            this.rtbPermissionNameGenerator.Location = new System.Drawing.Point(784, 162);
            this.rtbPermissionNameGenerator.Name = "rtbPermissionNameGenerator";
            this.rtbPermissionNameGenerator.Size = new System.Drawing.Size(420, 68);
            this.rtbPermissionNameGenerator.TabIndex = 3;
            this.rtbPermissionNameGenerator.Text = "";
            this.rtbPermissionNameGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbAutorizationProviderGenerator
            // 
            this.rtbAutorizationProviderGenerator.Location = new System.Drawing.Point(784, 236);
            this.rtbAutorizationProviderGenerator.Name = "rtbAutorizationProviderGenerator";
            this.rtbAutorizationProviderGenerator.Size = new System.Drawing.Size(420, 62);
            this.rtbAutorizationProviderGenerator.TabIndex = 3;
            this.rtbAutorizationProviderGenerator.Text = "";
            this.rtbAutorizationProviderGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbAppJsGenerator
            // 
            this.rtbAppJsGenerator.Location = new System.Drawing.Point(784, 304);
            this.rtbAppJsGenerator.Name = "rtbAppJsGenerator";
            this.rtbAppJsGenerator.Size = new System.Drawing.Size(420, 68);
            this.rtbAppJsGenerator.TabIndex = 3;
            this.rtbAppJsGenerator.Text = "";
            this.rtbAppJsGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbNavigationProviderGenerator
            // 
            this.rtbNavigationProviderGenerator.Location = new System.Drawing.Point(784, 378);
            this.rtbNavigationProviderGenerator.Name = "rtbNavigationProviderGenerator";
            this.rtbNavigationProviderGenerator.Size = new System.Drawing.Size(420, 77);
            this.rtbNavigationProviderGenerator.TabIndex = 3;
            this.rtbNavigationProviderGenerator.Text = "";
            this.rtbNavigationProviderGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // rtbMenuNavBarGenerator
            // 
            this.rtbMenuNavBarGenerator.Location = new System.Drawing.Point(784, 461);
            this.rtbMenuNavBarGenerator.Name = "rtbMenuNavBarGenerator";
            this.rtbMenuNavBarGenerator.Size = new System.Drawing.Size(420, 72);
            this.rtbMenuNavBarGenerator.TabIndex = 3;
            this.rtbMenuNavBarGenerator.Text = "";
            this.rtbMenuNavBarGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxGeneral_MouseClick);
            // 
            // lbxCombos
            // 
            this.lbxCombos.FormattingEnabled = true;
            this.lbxCombos.Location = new System.Drawing.Point(784, 7);
            this.lbxCombos.Name = "lbxCombos";
            this.lbxCombos.Size = new System.Drawing.Size(339, 95);
            this.lbxCombos.TabIndex = 5;
            // 
            // btnAgregarCombo
            // 
            this.btnAgregarCombo.Location = new System.Drawing.Point(117, 92);
            this.btnAgregarCombo.Name = "btnAgregarCombo";
            this.btnAgregarCombo.Size = new System.Drawing.Size(285, 28);
            this.btnAgregarCombo.TabIndex = 3;
            this.btnAgregarCombo.Text = "Agregar Combo";
            this.btnAgregarCombo.UseVisualStyleBackColor = true;
            this.btnAgregarCombo.Click += new System.EventHandler(this.btnAgregarCombo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRelateFieldDisplay);
            this.panel1.Controls.Add(this.txtRelateFieldValue);
            this.panel1.Controls.Add(this.txtRelateEntity);
            this.panel1.Controls.Add(this.btnAgregarCombo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(360, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 123);
            this.panel1.TabIndex = 2;
            // 
            // txtRelateFieldDisplay
            // 
            this.txtRelateFieldDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelateFieldDisplay.Location = new System.Drawing.Point(117, 64);
            this.txtRelateFieldDisplay.Name = "txtRelateFieldDisplay";
            this.txtRelateFieldDisplay.Size = new System.Drawing.Size(285, 26);
            this.txtRelateFieldDisplay.TabIndex = 2;
            this.txtRelateFieldDisplay.TextChanged += new System.EventHandler(this.txtRelateFieldDisplay_TextChanged);
            // 
            // txtRelateFieldValue
            // 
            this.txtRelateFieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelateFieldValue.Location = new System.Drawing.Point(117, 37);
            this.txtRelateFieldValue.Name = "txtRelateFieldValue";
            this.txtRelateFieldValue.Size = new System.Drawing.Size(285, 26);
            this.txtRelateFieldValue.TabIndex = 1;
            this.txtRelateFieldValue.TextChanged += new System.EventHandler(this.txtRelateFieldValue_TextChanged);
            // 
            // txtRelateEntity
            // 
            this.txtRelateEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelateEntity.Location = new System.Drawing.Point(117, 10);
            this.txtRelateEntity.Name = "txtRelateEntity";
            this.txtRelateEntity.Size = new System.Drawing.Size(285, 26);
            this.txtRelateEntity.TabIndex = 0;
            this.txtRelateEntity.TextChanged += new System.EventHandler(this.txtRelateEntity_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Field to Display";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Field Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Relate Entity Singular";
            // 
            // txtFaIcon
            // 
            this.txtFaIcon.Location = new System.Drawing.Point(830, 114);
            this.txtFaIcon.Name = "txtFaIcon";
            this.txtFaIcon.Size = new System.Drawing.Size(293, 20);
            this.txtFaIcon.TabIndex = 9;
            this.txtFaIcon.Text = "fa-home";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(781, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Fa Icon";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.Location = new System.Drawing.Point(24, 130);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(146, 26);
            this.txtProjectName.TabIndex = 1;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtEntityNameSingular_TextChanged);
            // 
            // Localizations
            // 
            this.Localizations.Location = new System.Drawing.Point(784, 539);
            this.Localizations.Name = "Localizations";
            this.Localizations.Size = new System.Drawing.Size(420, 68);
            this.Localizations.TabIndex = 10;
            this.Localizations.Text = "";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 748);
            this.Controls.Add(this.Localizations);
            this.Controls.Add(this.txtFaIcon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbxCombos);
            this.Controls.Add(this.btnSaveOnDisk);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtbMenuNavBarGenerator);
            this.Controls.Add(this.rtbUpdateCsHtmlGenerator);
            this.Controls.Add(this.rtbNavigationProviderGenerator);
            this.Controls.Add(this.rtbUpdateJsGenerator);
            this.Controls.Add(this.rtbEntityCreateDtoGenerator);
            this.Controls.Add(this.rtbAppJsGenerator);
            this.Controls.Add(this.rtbCreateCsHtmlGenerator);
            this.Controls.Add(this.rtbEntityUpdateDtoGenerator);
            this.Controls.Add(this.rtbAutorizationProviderGenerator);
            this.Controls.Add(this.rtbCreateJsGenerator);
            this.Controls.Add(this.rtbEntityDtoGenerator);
            this.Controls.Add(this.rtbPermissionNameGenerator);
            this.Controls.Add(this.rtbIndexCshtmlGenerator);
            this.Controls.Add(this.rtbIndexJsGenerator);
            this.Controls.Add(this.rtbAppSericeGenerator);
            this.Controls.Add(this.rtbIAppSericeGenerator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCapitalSingular);
            this.Controls.Add(this.txtCapitalPlural);
            this.Controls.Add(this.txtCamelPlural);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.txtCamelSingular);
            this.Controls.Add(this.btnGenerate);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmPrincipal_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtCamelSingular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCamelPlural;
        private System.Windows.Forms.TextBox txtCapitalPlural;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbIAppSericeGenerator;
        private System.Windows.Forms.TextBox txtCapitalSingular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveOnDisk;
        private System.Windows.Forms.RichTextBox rtbAppSericeGenerator;
        private System.Windows.Forms.RichTextBox rtbEntityDtoGenerator;
        private System.Windows.Forms.RichTextBox rtbEntityUpdateDtoGenerator;
        private System.Windows.Forms.RichTextBox rtbEntityCreateDtoGenerator;
        private System.Windows.Forms.RichTextBox rtbIndexJsGenerator;
        private System.Windows.Forms.RichTextBox rtbIndexCshtmlGenerator;
        private System.Windows.Forms.RichTextBox rtbCreateJsGenerator;
        private System.Windows.Forms.RichTextBox rtbCreateCsHtmlGenerator;
        private System.Windows.Forms.RichTextBox rtbUpdateJsGenerator;
        private System.Windows.Forms.RichTextBox rtbUpdateCsHtmlGenerator;
        private System.Windows.Forms.RichTextBox rtbPermissionNameGenerator;
        private System.Windows.Forms.RichTextBox rtbAutorizationProviderGenerator;
        private System.Windows.Forms.RichTextBox rtbAppJsGenerator;
        private System.Windows.Forms.RichTextBox rtbNavigationProviderGenerator;
        private System.Windows.Forms.RichTextBox rtbMenuNavBarGenerator;
        private System.Windows.Forms.ListBox lbxCombos;
        private System.Windows.Forms.Button btnAgregarCombo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRelateFieldDisplay;
        private System.Windows.Forms.TextBox txtRelateFieldValue;
        private System.Windows.Forms.TextBox txtRelateEntity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFaIcon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.RichTextBox Localizations;
    }
}

