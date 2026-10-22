using System;

namespace LifeLoudnessCalculator
{
    public class LifeNoiseModel
    {
        // Входные данные
        public int TalkCount { get; private set; } = 0;
        public int MusicCount { get; private set; } = 0;
        public int SwearCount { get; private set; } = 0;

        // Рассчитанные величины
        public int NoiseScore { get; private set; } = 0;
        public string Recommendation { get; private set; } = "Нет данных";

        // Событие активной модели для уведомления Представлений (View)
        public event EventHandler ModelChanged;

        public void UpdateData(int talk, int music, int swear)
        {
            // Валидация значений на уровне модели
            if (talk < 0 || music < 0 || swear < 0)
            {
                throw new ArgumentException("Значения не могут быть отрицательными.");
            }

            TalkCount = talk;
            MusicCount = music;
            SwearCount = swear;

            CalculateNoiseAndRecommendation();

            // Уведомляем всех подписчиков (View) об изменении состояния модели
            OnModelChanged();
        }

        private void CalculateNoiseAndRecommendation()
        {
            // Расчет индекса шума
            NoiseScore = (TalkCount * 1) + (MusicCount * 2) + (SwearCount * 3);

            // Оценка и рекомендация: беруши или караоке
            if (NoiseScore >= 15)
            {
                Recommendation = "Рекомендуются БЕРУШИ \nУровень шума высок!";
            }
            else
            {
                Recommendation = "Рекомендуется КАРАОКЕ \nДобавьте громких эмоций!";
            }
        }

        protected virtual void OnModelChanged()
        {
            ModelChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}