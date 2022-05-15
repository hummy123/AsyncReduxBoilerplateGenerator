namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class Widget
    {
        private List<string> _parameterNames;
        private List<string> _parameterTypes;
        private string _widgetName;

        public Widget(List<string> parameterNames, List<string> parameterTypes, string widgetName)
        {
            _parameterNames=parameterNames;
            _parameterTypes=parameterTypes;
            _widgetName=widgetName;
        }
    }
}
