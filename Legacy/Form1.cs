using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dungeon_Maker
{
    public partial class DungeonMakerForm : Form
    {
        int Level;
        bool StartInHall;
        
        public DungeonMakerForm()
        {
            InitializeComponent();
            HallRadioButton.Checked = true;
            LockButton.Enabled = false;
        }

        private void HallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (HallRadioButton.Checked)
                StartInHall = true;
        }

        private void DoorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DoorRadioButton.Checked)
                StartInHall = false;
        }

        private void LevelTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (char character in LevelTextBox.Text.ToCharArray())
            {
                if (character < '0' || character > '9')
                {
                    MessageBox.Show("Error: Not a Number.");
                    LevelTextBox.Clear();
                    return;
                }
            }

            if (LevelTextBox.Text != "")
            {
                try
                {
                    Level = Convert.ToInt16(LevelTextBox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Try a REAL number this time, bozo.");
                    LevelTextBox.Clear();
                }
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            MapText.Clear();
            Random random = new Random();

            if (Level == 0)
            {
                MessageBox.Show("Error: invalid level", "Error: input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (StartInHall)
                MapText.Text = Dungeon.GenerateFromHall(Level, ref random);
            else
                MapText.Text = Dungeon.GenerateFromDoor(Level, ref random);

            GenerateButton.Enabled = false;
            LockButton.Enabled = true;
            RegenerateButton.Enabled = true;
            RegenGroupBox.Enabled = true;
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            GenerateButton.Enabled = true;
            LockButton.Enabled = false;
            RegenGroupBox.Enabled = false;
            RegenerateButton.Enabled = false;
            RegenText.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateButton.Enabled = true;
            LockButton.Enabled = false;
            RegenGroupBox.Enabled = false;
            RegenerateButton.Enabled = false;
        }

        private void RegenerateButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            if (MonsterRadioButton.Checked)
                RegenText.Text = Encounter.Generate(Level, ref random);
            else
                RegenText.Text = Treasure.Generate(Level, ref random);
        }
    }
}