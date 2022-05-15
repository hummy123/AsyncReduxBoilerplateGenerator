using System.Text;

namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class Factory
    {
        private string Params
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var name in _parameterNames)
                {
                    sb.AppendLine($"\t\t\t{name}:  ,");
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
