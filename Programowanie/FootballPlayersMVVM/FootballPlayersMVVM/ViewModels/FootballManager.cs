using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayersMVVM.ViewModels
{
    using BaseClass;
    using System.Windows.Input;

    internal class FootballManager : ViewModelBase
    {
        public FootballManager()
        {

        }

        public decimal? FirstArg { get; set; }
        public decimal? SecondArg { get; set; }
        public string SymbolOfCurrentOperation { get; set; }

        private decimal? result = null;
        public decimal? Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                onPropertyChanged(nameof(Result));
            }
        }
        private ICommand _clear = null;
        public ICommand Clear
        {
            get
            {
                if (_clear == null)
                {
                    _clear = new RelayCommand(
                        arg => { Result = null; },

                        arg => true

                        );
                }
                return _clear;
            }
        }

    }
}
