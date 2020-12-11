using LightsOutWpf.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace LightsOutWpf.Shared
{
    public class Light : INotifyPropertyChanged
    {      
        private bool lit;
        public bool Lit
        {
            get => lit; set
            {
                if (lit == value)
                { return; }
                lit = value;
                OnPropertyChanged();
            }
        }

        public ICommand LightPressedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Light(IGameFieldService gameFieldService)
        {
          
            LightPressedCommand = new SimpleCommand()
            {
                CanExecuteDelegate = (param) => true
            ,
                ExecuteDelegate = (param) =>
                {
                    Lit = !Lit;
                    gameFieldService.FlipLights(this);
                }
            };
        }
    }
}