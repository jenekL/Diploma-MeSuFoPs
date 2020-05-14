using System;
using System.Collections.Generic;
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

namespace Diploma.elements
{
    /// <summary>
    /// Логика взаимодействия для AnswerScaleElement.xaml
    /// </summary>
    public partial class AnswerScaleElement : UserControl
    {
        private Scale scaleObject;

        public AnswerScaleElement(Scale scale)
        {
            InitializeComponent();
            this.scaleObject = scale;
            this.scale.Text = scale.Title;
        }
    }
}
