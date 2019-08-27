using System.Text.RegularExpressions;
using System.Windows;

namespace RegexTester.MVC
{
    /// <summary>
    /// Logique d'interaction pour View.xaml
    /// </summary>
    public partial class View : Window
    {
        Model model = new Model();

        public View()
        {
            InitializeComponent();
            DataContext = model;
            Show();
        }

        private void ButtonExec_Click(object sender, RoutedEventArgs e)
        {

            RegexOptions options = 0;
            if (Check_None.IsChecked == true) options = options | RegexOptions.None;
            if (Check_Compiled.IsChecked == true) options = options | RegexOptions.Compiled;
            if (Check_CultureInvariant.IsChecked == true) options = options | RegexOptions.CultureInvariant;
            if (Check_ECMAScript.IsChecked == true) options = options | RegexOptions.ECMAScript;
            if (Check_ExplicitCapture.IsChecked == true) options = options | RegexOptions.ExplicitCapture;
            if (Check_IgnoreCase.IsChecked == true) options = options | RegexOptions.IgnoreCase;
            if (Check_IgnorePatternWhitespace.IsChecked == true) options = options | RegexOptions.IgnorePatternWhitespace;
            if (Check_Multiline.IsChecked == true) options = options | RegexOptions.Multiline;
            if (Check_RightToLeft.IsChecked == true) options = options | RegexOptions.RightToLeft;
            if (Check_Singleline.IsChecked == true) options = options | RegexOptions.Singleline;

            Regex regex;
            Match match;
            MatchCollection matchCollection;
            
            regex = new Regex(@""+model.Regex, options);
            matchCollection = regex.Matches(model.FileContent);

            model.Results.Clear();
            model.Results.Add("Result Count : "+ matchCollection.Count+"\n\n");
            if (matchCollection.Count > 0)
            {
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    match = matchCollection[i];
                    {
                        model.Results.Add(match.Value);
                    }
                }
            }
            LB.Items.Refresh();
        }
    }
}
