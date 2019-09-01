using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextConcatenator
{
    public class Parameters : INotifyPropertyChanged
    {
        #region Private fields

        private string textBetweenFiles;
        private string filePath;
        private string resFileName;
        private bool compareByLength;

        #endregion

        #region Initialization

        public Parameters()
        {
            textBetweenFiles = "";
            filePath = "D:\\";
            resFileName = "D:\\Result.txt";
            compareByLength = false;
        }

        #endregion

        #region Public properties

        public string TextBetweenFiles
        {
            get { return textBetweenFiles; }
            set
            {
                textBetweenFiles = value;
                NotifyPropertyChanged("TextBetweenFiles");
            }
        }

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }

        public string ResFileName
        {
            get { return resFileName; }
            set
            {
                resFileName = value;
                NotifyPropertyChanged("ResFileName");
            }
        }

        public bool CompareByLength
        {
            get { return compareByLength; }
            set
            {
                compareByLength = value;
                NotifyPropertyChanged("CompareByLength");
            }
        }

        #endregion

        #region INotifyPropertyChanged implemetation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
