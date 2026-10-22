using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeLoudnessCalculator
{
    public class MainForm : Form
    {
        private readonly LifeNoiseModel _model;
        private readonly LifeNoiseController _controller;

        private Label lblTalkResult;
        private Label lblMusicResult;
        private Label lblSwearResult;
        private Label lblScoreResult;
        private Label lblRecommendationResult;
        private Button btnOpenInput;

        public MainForm(LifeNoiseModel model)
        {
            _model = model;
            _controller = new LifeNoiseController(_model, this);

            InitializeComponent();

            // Подписка Главного Представления на событие Активной Модели
            _model.ModelChanged += OnModelChanged;

            // Первоначальное отображение
            UpdateView();
        }

        private void InitializeComponent()
        {
            this.Text = "Калькулятор громкости жизни";
            this.ClientSize = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterScreen;

            btnOpenInput = new Button
            {
                Text = "Ввести данные",
                Location = new Point(130, 20),
                Size = new Size(160, 40),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnOpenInput.Click += (s, e) => _controller.OpenInputWindow();

            GroupBox gbResults = new GroupBox
            {
                Text = "Результаты оценки",
                Location = new Point(20, 80),
                Size = new Size(380, 210)
            };

            lblTalkResult = new Label { Location = new Point(20, 30), AutoSize = true, Font = new Font("Arial", 9) };
            lblMusicResult = new Label { Location = new Point(20, 60), AutoSize = true, Font = new Font("Arial", 9) };
            lblSwearResult = new Label { Location = new Point(20, 90), AutoSize = true, Font = new Font("Arial", 9) };
            lblScoreResult = new Label { Location = new Point(20, 120), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            lblRecommendationResult = new Label { Location = new Point(20, 155), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.DarkBlue };

            gbResults.Controls.AddRange(new Control[] {
                lblTalkResult, lblMusicResult, lblSwearResult, lblScoreResult, lblRecommendationResult
            });

            this.Controls.Add(btnOpenInput);
            this.Controls.Add(gbResults);
        }

        // Обработчик события изменения модели
        private void OnModelChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        // Обновление интерфейса на основе текущих данных Модели
        private void UpdateView()
        {
            lblTalkResult.Text = $"Разговоров в день: {_model.TalkCount}";
            lblMusicResult.Text = $"Музыки в день: {_model.MusicCount}";
            lblSwearResult.Text = $"Ругательств в день: {_model.SwearCount}";
            lblScoreResult.Text = $"Общий уровень шума: {_model.NoiseScore} дБ (условных)";
            lblRecommendationResult.Text = $"Рекомендация: {_model.Recommendation}";
        }
    }
}