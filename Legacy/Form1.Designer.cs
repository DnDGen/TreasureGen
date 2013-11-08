namespace Dungeon_Maker
{
    partial class DungeonMakerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonMakerForm));
            this.MapText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DoorRadioButton = new System.Windows.Forms.RadioButton();
            this.HallRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.LevelTextBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.LockButton = new System.Windows.Forms.Button();
            this.RegenText = new System.Windows.Forms.RichTextBox();
            this.RegenerateButton = new System.Windows.Forms.Button();
            this.RegenGroupBox = new System.Windows.Forms.GroupBox();
            this.TreasureRadioButton = new System.Windows.Forms.RadioButton();
            this.MonsterRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.RegenGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapText
            // 
            this.MapText.Location = new System.Drawing.Point(13, 88);
            this.MapText.Name = "MapText";
            this.MapText.ReadOnly = true;
            this.MapText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MapText.Size = new System.Drawing.Size(314, 218);
            this.MapText.TabIndex = 0;
            this.MapText.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.DoorRadioButton);
            this.groupBox1.Controls.Add(this.HallRadioButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Starting from";
            // 
            // DoorRadioButton
            // 
            this.DoorRadioButton.AutoSize = true;
            this.DoorRadioButton.Location = new System.Drawing.Point(16, 43);
            this.DoorRadioButton.Name = "DoorRadioButton";
            this.DoorRadioButton.Size = new System.Drawing.Size(48, 17);
            this.DoorRadioButton.TabIndex = 1;
            this.DoorRadioButton.TabStop = true;
            this.DoorRadioButton.Text = "Door";
            this.DoorRadioButton.UseVisualStyleBackColor = true;
            this.DoorRadioButton.CheckedChanged += new System.EventHandler(this.DoorRadioButton_CheckedChanged);
            // 
            // HallRadioButton
            // 
            this.HallRadioButton.AutoSize = true;
            this.HallRadioButton.Location = new System.Drawing.Point(16, 19);
            this.HallRadioButton.Name = "HallRadioButton";
            this.HallRadioButton.Size = new System.Drawing.Size(43, 17);
            this.HallRadioButton.TabIndex = 0;
            this.HallRadioButton.TabStop = true;
            this.HallRadioButton.Text = "Hall";
            this.HallRadioButton.UseVisualStyleBackColor = true;
            this.HallRadioButton.CheckedChanged += new System.EventHandler(this.HallRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(101, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Level:";
            // 
            // LevelTextBox
            // 
            this.LevelTextBox.Location = new System.Drawing.Point(101, 55);
            this.LevelTextBox.Name = "LevelTextBox";
            this.LevelTextBox.Size = new System.Drawing.Size(42, 20);
            this.LevelTextBox.TabIndex = 5;
            this.LevelTextBox.TextChanged += new System.EventHandler(this.LevelTextBox_TextChanged);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateButton.Location = new System.Drawing.Point(149, 13);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(86, 66);
            this.GenerateButton.TabIndex = 8;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // LockButton
            // 
            this.LockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockButton.Location = new System.Drawing.Point(241, 13);
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(86, 66);
            this.LockButton.TabIndex = 9;
            this.LockButton.Text = "Unlock";
            this.LockButton.UseVisualStyleBackColor = true;
            this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // RegenText
            // 
            this.RegenText.Location = new System.Drawing.Point(377, 88);
            this.RegenText.Name = "RegenText";
            this.RegenText.ReadOnly = true;
            this.RegenText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RegenText.Size = new System.Drawing.Size(199, 218);
            this.RegenText.TabIndex = 10;
            this.RegenText.Text = "";
            // 
            // RegenerateButton
            // 
            this.RegenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegenerateButton.Location = new System.Drawing.Point(470, 16);
            this.RegenerateButton.Name = "RegenerateButton";
            this.RegenerateButton.Size = new System.Drawing.Size(106, 66);
            this.RegenerateButton.TabIndex = 11;
            this.RegenerateButton.Text = "Regenerate";
            this.RegenerateButton.UseVisualStyleBackColor = true;
            this.RegenerateButton.Click += new System.EventHandler(this.RegenerateButton_Click);
            // 
            // RegenGroupBox
            // 
            this.RegenGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.RegenGroupBox.Controls.Add(this.TreasureRadioButton);
            this.RegenGroupBox.Controls.Add(this.MonsterRadioButton);
            this.RegenGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RegenGroupBox.Location = new System.Drawing.Point(377, 13);
            this.RegenGroupBox.Name = "RegenGroupBox";
            this.RegenGroupBox.Size = new System.Drawing.Size(87, 66);
            this.RegenGroupBox.TabIndex = 13;
            this.RegenGroupBox.TabStop = false;
            this.RegenGroupBox.Text = "Regenerate";
            // 
            // TreasureRadioButton
            // 
            this.TreasureRadioButton.AutoSize = true;
            this.TreasureRadioButton.Location = new System.Drawing.Point(10, 43);
            this.TreasureRadioButton.Name = "TreasureRadioButton";
            this.TreasureRadioButton.Size = new System.Drawing.Size(67, 17);
            this.TreasureRadioButton.TabIndex = 1;
            this.TreasureRadioButton.TabStop = true;
            this.TreasureRadioButton.Text = "Treasure";
            this.TreasureRadioButton.UseVisualStyleBackColor = true;
            // 
            // MonsterRadioButton
            // 
            this.MonsterRadioButton.AutoSize = true;
            this.MonsterRadioButton.Location = new System.Drawing.Point(10, 20);
            this.MonsterRadioButton.Name = "MonsterRadioButton";
            this.MonsterRadioButton.Size = new System.Drawing.Size(63, 17);
            this.MonsterRadioButton.TabIndex = 0;
            this.MonsterRadioButton.TabStop = true;
            this.MonsterRadioButton.Text = "Monster";
            this.MonsterRadioButton.UseVisualStyleBackColor = true;
            // 
            // DungeonMakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(588, 318);
            this.Controls.Add(this.RegenGroupBox);
            this.Controls.Add(this.RegenerateButton);
            this.Controls.Add(this.RegenText);
            this.Controls.Add(this.LockButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.LevelTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MapText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DungeonMakerForm";
            this.Text = "Dungeon Generator 2.0.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.RegenGroupBox.ResumeLayout(false);
            this.RegenGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MapText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DoorRadioButton;
        private System.Windows.Forms.RadioButton HallRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LevelTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button LockButton;
        private System.Windows.Forms.RichTextBox RegenText;
        private System.Windows.Forms.Button RegenerateButton;
        private System.Windows.Forms.GroupBox RegenGroupBox;
        private System.Windows.Forms.RadioButton TreasureRadioButton;
        private System.Windows.Forms.RadioButton MonsterRadioButton;
    }
}

