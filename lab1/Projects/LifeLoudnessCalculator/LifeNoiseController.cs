using System;
using System.Windows.Forms;

namespace LifeLoudnessCalculator
{
    public class LifeNoiseController
    {
        private readonly LifeNoiseModel _model;
        private readonly Form _parentForm;

        public LifeNoiseController(LifeNoiseModel model, Form parentForm)
        {
            _model = model;
            _parentForm = parentForm;
        }

        public void OpenInputWindow()
        {
            // Создаем окно ввода, передавая в него текущие запомненные данные из Модели
            using (InputForm inputForm = new InputForm(_model.TalkCount, _model.MusicCount, _model.SwearCount))
            {
                if (inputForm.ShowDialog(_parentForm) == DialogResult.OK)
                {
                    // Обработка и валидация ввода
                    if (int.TryParse(inputForm.txtTalk.Text, out int talk) &&
                        int.TryParse(inputForm.txtMusic.Text, out int music) &&
                        int.TryParse(inputForm.txtSwear.Text, out int swear) &&
                        talk >= 0 && music >= 0 && swear >= 0)
                    {
                        // Передаем валидные данные в модель
                        _model.UpdateData(talk, music, swear);
                    }
                    else
                    {
                        // Показываем сообщение об ошибке согласно требованию варианта
                        MessageBox.Show(
                            "Ошибка ввода! Пожалуйста, введите корректные целые неотрицательные числа.",
                            "Ошибка некорректных данных",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
    }
}