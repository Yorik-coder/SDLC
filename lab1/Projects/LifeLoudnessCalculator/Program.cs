using System;
using System.Windows.Forms;

namespace LifeLoudnessCalculator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Инициализация Active Model и Главной Формы
            LifeNoiseModel model = new LifeNoiseModel();
            MainForm mainForm = new MainForm(model);

            Application.Run(mainForm);
        }
    }
}