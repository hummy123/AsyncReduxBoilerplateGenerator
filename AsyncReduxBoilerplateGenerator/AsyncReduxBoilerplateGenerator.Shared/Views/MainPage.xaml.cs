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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.Content = ViewModel.WidgetName;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Parameters.Add(new Models.Parameter("", ""));
        }
    }
}
