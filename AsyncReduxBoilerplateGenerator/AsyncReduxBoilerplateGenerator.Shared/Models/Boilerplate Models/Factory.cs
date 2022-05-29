using System.Collections.Generic;
using System.Text;

namespace AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models
{
    public class Factory
    {
        string _widgetName;
        private List<Parameter> _parameters;

        public Factory(List<Parameter> parameters, string widgetName)
        {
            _widgetName=widgetName;
            _parameters=parameters;
        }

        private string Params
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var param in _parameters)
                {
                    sb.AppendLine($"\t\t\t{param.Name}:  ,");
                }
                return sb.ToString();
            }
        }
        public override string ToString()
        {
            return
                $"\nclass _{_widgetName}Factory extends VmFactory<AppState, {_widgetName}Connector> {{" +
                $"\n\t_{_widgetName}Factory(widget) : super(widget);" +
                $"\n" +
                $"\n\t@override" +
                $"\n\t_{_widgetName}Vm fromStore() {{" +
                $"\n\t\t// todo: return values needed for vm from store" +
                $"\n\t\tthrow UnimplementedError();" +
                $"\n\t\treturn _{_widgetName}Vm(" +
                $"\n{Params}" +
                $"\t\t);" +
                $"\n\t}}" +
                $"\n}}";
        }
    }
}
