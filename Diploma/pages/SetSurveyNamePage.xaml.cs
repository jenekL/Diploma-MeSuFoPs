using System.Windows;
using System.Windows.Controls;
using Diploma.models;
using Diploma.repositories;
using Diploma.services;
using Diploma.utils;

namespace Diploma.pages
{
    /// <summary>
    /// Логика взаимодействия для SetSurveyNamePage.xaml
    /// </summary>
    public partial class SetSurveyNamePage : Page
    {
        private Window _parentWindow;

        public SetSurveyNamePage()
        {
            InitializeComponent();
            Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = FindParentWindowUtil.FindParentWindow(this);
        }

        private void CreateSurveyButton_Click(object sender, RoutedEventArgs e)
        {
            Survey survey = SaveSurvey();
            PageNavigationService.Navigate(_parentWindow, new CreateSurveyPage(survey));
        }

        private Survey SaveSurvey()
        {
            var survey = new Survey { Title = surveyName.Text };
            survey.Id = SurveyRepository.Save(survey);
            return survey;
        }
    }
}
