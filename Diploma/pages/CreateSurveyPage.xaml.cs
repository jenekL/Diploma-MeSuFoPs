using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Diploma.models;
using Diploma.repositories;

namespace Diploma
{
    public partial class CreateSurveyPage : Page
    {
        private const double LeftPadding = 90;
        private const double BetweenPadding = 20;

        private readonly List<CreateQuestionElement> _questionElements = new List<CreateQuestionElement>();

        private readonly Grid scrollGrid = new Grid();
        private readonly Survey _survey;

        public CreateSurveyPage(Survey survey)
        {
            InitializeComponent();
            _survey = survey;
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            var existingElement = _questionElements.ElementAtOrDefault(_questionElements.Count - 1);
            var thickness = new Thickness();
            if (existingElement != null)
            {
                thickness.Top = existingElement.Margin.Top + existingElement.ActualHeight;
            }
            else
            {
                thickness.Top = BetweenPadding;
            }
            thickness.Left = LeftPadding;
            var element = new CreateQuestionElement(this, _survey.Id)
            {
                Margin = thickness,
                number = { Text = (_questionElements.Count + 1).ToString() }
            };
            _questionElements.Add(element);
            scrollGrid.Children.Add(element);
            ScrollView.Content = scrollGrid;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _questionElements.ForEach(element =>
            {
                Question question = new Question
                {
                    SurveyId = _survey.Id,
                    Title = element.question.Text,
                    QuestionNum = Convert.ToInt64(element.number.Text),
                    QuestionTypeId = ((QuestionType)element.questionType.SelectedItem).Id
                };
                QuestionRepository.Save(question);
            });
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            Scale scale = new Scale
            {
                Title = scaleName.Text,
                SurveyId = _survey.Id
            };
            if (ScaleRepository.GetBySurveyIdAndTitle(scale) == null)
            {
                ScaleRepository.Save(scale);
                scalesList.Items.Add(scale.Title);

                scaleName.Text = "";
            }
            else
            {
                MessageBox.Show("Такая шкала уже существует.");
            }
        }

        private void DeleteScale_Click(object sender, RoutedEventArgs e)
        {
            var toRemove = new List<string>();
            foreach (var selectedItem in scalesList.SelectedItems)
            {
                ScaleRepository.Delete(_survey.Id, selectedItem.ToString());
                toRemove.Add(selectedItem.ToString());
            }

            toRemove.ForEach(remove => scalesList.Items.Remove(remove));
        }
    }
}
