namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class ViewModel
    {
        private List<string> _parameterNames;
        private List<string> _parameterTypes;
        private string _widgetName;

        public ViewModel(List<string> parameterNames, List<Parameter> parameterTypes, string widgetName)
        {
            _parameterNames = parameterNames;
            _parameterTypes = parameterTypes;
            _widgetName = widgetName;
        }
    }
}
