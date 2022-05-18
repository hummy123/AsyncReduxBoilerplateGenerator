using AsyncReduxBoilerplateGenerator.Logic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AsyncReduxBoilerplateGenerator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new MainPageViewModel();
        }

        public MainPageViewModel ViewModel { get; private set; }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var t = await StateFiles.SaveFileAsync(ViewModel.WidgetName, ViewModel.Parameters.ToList());
            System.Console.WriteLine(t);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Parameters.Add(new Models.Parameter("", ""));
        }
    }
}
