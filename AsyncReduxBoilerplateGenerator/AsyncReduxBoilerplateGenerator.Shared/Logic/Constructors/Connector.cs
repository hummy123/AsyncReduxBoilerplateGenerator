using System.Collections.Generic;

namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class Connector
    {
        private List<string> _parameterNames;
        private string _widgetName;

        public Connector(List<string> parameterNames, string widgetName)
        {
            this._parameterNames = parameterNames;
            this._widgetName = widgetName;
        }
    }
}
