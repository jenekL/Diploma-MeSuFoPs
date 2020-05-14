using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using Diploma.elements;

namespace Diploma.pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionAnswersPage.xaml
    /// </summary>
    public partial class QuestionAnswersPage : Page
    {
        private const double LeftPadding = 90;
        private const double BetweenPadding = 20;

        private readonly List<QuestionAnswerElement> _answerElements = new List<QuestionAnswerElement>();

        private readonly Grid scrollGrid = new Grid();
        private Page previousPage;
        private long surveyId;

        public QuestionAnswersPage(Page previousPage, long surveyId)
        {
            InitializeComponent();

            this.previousPage = previousPage;
            this.surveyId = surveyId;
        }

        private void AddAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            var existingElement = _answerElements.ElementAtOrDefault(_answerElements.Count - 1);
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
            var element = new QuestionAnswerElement(surveyId)
            {
                Margin = thickness,
                number = { Text = (_answerElements.Count + 1).ToString() }
            };
            _answerElements.Add(element);
            scrollGrid.Children.Add(element);
            scrollView.Content = scrollGrid;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //todo save data here
            NavigationService.Navigate(previousPage);
        }
    }
}
