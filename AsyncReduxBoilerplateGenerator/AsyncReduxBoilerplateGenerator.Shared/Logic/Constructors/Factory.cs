using System.Collections.Generic;

namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class Factory
    {
        string _widgetName;
        private List<string> _parameterNames;

        public Factory(List<string> parameterNames, string widgetName)
        {
            _widgetName=widgetName;
            _parameterNames=parameterNames;
        }
    }
}
