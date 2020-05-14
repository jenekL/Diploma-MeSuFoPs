using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diploma.models;
using Diploma.services;

namespace Diploma.elements
{
    /// <summary>
    /// Логика взаимодействия для QuestionAnswerElement.xaml
    /// </summary>
    public partial class QuestionAnswerElement : UserControl
    {
        private const double BetweenPadding = 20;

        public ObservableCollection<Scale> cmbContent { get; set; }
        private List<AnswerScaleElement> answerScales = new List<AnswerScaleElement>();

        private readonly ScaleService _scaleService = new ScaleService();

        public QuestionAnswerElement(long surveyId)
        {
            InitializeComponent();
            cmbContent = new ObservableCollection<Scale>(_scaleService.GetAll(surveyId));

            DataContext = this;
        }

        private void ScaleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(scaleComboBox.SelectedItem is Scale selectedScale))
            {
                return;
            }

            var existingElement = answerScales.ElementAtOrDefault(answerScales.Count - 1);
            var thickness = new Thickness();
            if (existingElement != null)
            {
                thickness.Top = existingElement.Margin.Top + existingElement.ActualHeight;
            }
            else
            {
                thickness.Top = BetweenPadding;
            }

            var answerScaleElement = new AnswerScaleElement(selectedScale)
            {
                Margin = thickness
            };
            mainGrid.Children.Add(answerScaleElement);
            answerScales.Add(answerScaleElement);
            cmbContent.Remove(selectedScale);
        }
    }
}
