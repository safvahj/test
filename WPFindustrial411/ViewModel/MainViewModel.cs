using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFindustrial411.Base;

namespace WPFindustrial411.ViewModel
{
    public class MainViewModel:NotifyPropertyBase
    { 
        private UIElement _mainContent;

        public UIElement MainContent
        {
            get { return _mainContent; }
            set 
            {
                Set<UIElement>(ref _mainContent, value);
            }
        }

        public CommandBase TabChangedCommand{ get; set; }


        public MainViewModel()
        {
            TabChangedCommand = new CommandBase((o) =>
            {
                string[] strValues=o.ToString().Split('|');
                Assembly assembly = Assembly.LoadFrom(strValues[0]);
                Type type=assembly.GetType(strValues[1]);
                this.MainContent = (UIElement)Activator.CreateInstance(type);
            });
        }
    }
}
