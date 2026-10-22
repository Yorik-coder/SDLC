using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeLoudnessCalculator
{
    public class InputForm : Form
    {
        public TextBox txtTalk;
        public TextBox txtMusic;
        public TextBox txtSwear;
        public Button btnSave;
        public Button btnCancel;

        public InputForm(int currentTalk, int currentMusic, int currentSwear)
        {
            InitializeComponent();

            // Восстановление последних введенных данных
            txtTalk.Text = currentTalk.ToString();
            txtMusic.Text = currentMusic.ToString();
            txtSwear.Text = currentSwear.ToString();
        }

        private void InitializeComponent()
        {
            this.Text = "Ввод данных громкости";
            this.ClientSize = new Size(360, 220);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblTalk = new Label { Text = "Разговоров в день:", Location = new Point(20, 20), AutoSize = true };
            txtTalk = new TextBox { Location = new Point(220, 17), Width = 100 };

            Label lblMusic = new Label { Text = "Прослушиваний музыки:", Location = new Point(20, 60), AutoSize = true };
            txtMusic = new TextBox { Location = new Point(220, 57), Width = 100 };

            Label lblSwear = new Label { Text = "Ругательств в день:", Location = new Point(20, 100), AutoSize = true };
            txtSwear = new TextBox { Location = new Point(220, 97), Width = 100 };

            btnSave = new Button { Text = "Сохранить", Location = new Point(40, 150), DialogResult = DialogResult.OK, Width = 100 };
            btnCancel = new Button { Text = "Отмена", Location = new Point(160, 150), DialogResult = DialogResult.Cancel, Width = 100 };

            this.Controls.AddRange(new Control[] { lblTalk, txtTalk, lblMusic, txtMusic, lblSwear, txtSwear, btnSave, btnCancel });
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }
    }
}