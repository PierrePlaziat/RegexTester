using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTester.MVC
{
    class Model : INotifyPropertyChanged
    {
        #region NOTIFY PROPERTY

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
                Console.WriteLine(DateTime.Now + " Lm Widget Part >>> PropertyChanged : " + property);
            }
        }

        #endregion


        string regex;
        public string Regex
        {
            get { return regex; }
            set { regex = value; RaisePropertyChanged("Regex"); }
        }

        string fileContent;
        public string FileContent
        {
            get { return fileContent; }
            set { fileContent = value; RaisePropertyChanged("FileContent"); }
        }

        List<string> results = new List<string>();
        public List<string> Results
        {
            get { return results; }
            set { results = value; RaisePropertyChanged("Results"); }
        }

    }
}
