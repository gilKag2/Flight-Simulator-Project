using FlightSimulator.ViewModels;
using System.Windows.Controls;


namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for ManuelView.xaml
    /// </summary>
    public partial class ManuelView : UserControl
    {
        public ManuelView()
        {
            InitializeComponent();
            DataContext = new ManualViewModel();

            //{Binding VM_aileron}
        }
    }
}
