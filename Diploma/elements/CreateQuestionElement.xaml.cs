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
using Diploma.elements;
using Diploma.models;
using Diploma.pages;
using Diploma.repositories;
using Diploma.services;
using Diploma.utils;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для QuestionElement.xaml
    /// </summary>
    public partial class CreateQuestionElement : UserControl
    {
        public ObservableCollection<QuestionType> cmbContent { get; set; }
        private readonly QuestionTypeService _questionTypeService = new QuestionTypeService();
        private List<QuestionAnswerElement> questionAnswerElements = new List<QuestionAnswerElement>();

        private Page parentPage;
        private long surveyId;
        private long questionId;
        private Window _parentWindow;

        public CreateQuestionElement(Page parentPage, long surveyId)
        {
            InitializeComponent();
            cmbContent = new ObservableCollection<QuestionType>(_questionTypeService.GetAll());

            DataContext = this;
            Loaded += MainView_Loaded;

            this.parentPage = parentPage;
            this.surveyId = surveyId;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = FindParentWindowUtil.FindParentWindow(this);
        }

        private void DefineAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigationService.Navigate(_parentWindow, new QuestionAnswersPage(parentPage, surveyId));
        }
    }
}
