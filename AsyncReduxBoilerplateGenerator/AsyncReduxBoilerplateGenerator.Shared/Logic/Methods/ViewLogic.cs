using System.Text;

namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class ViewModel
    {
        private string Params
        {
            get
            {
                var sb = new StringBuilder();
                for (int i = 0; i < _parameterTypes.Count; i++)
                {
                    var name = _parameterNames[i];
                    var type = _parameterTypes[i];
                    sb.Append($"\n\tfinal {type} {name};");
                }
                return sb.ToString();
            }
        }

        private string VmConstructor
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine($"\n\t_{_widgetName}Vm({{");
                foreach (var name in _parameterNames)
                {
                    sb.AppendLine($"\t\trequired this.{name},");
                }
                sb.AppendLine($"\t}}) : super(equals: \n\t[");

                foreach (var name in _parameterNames)
                {
                    sb.AppendLine($"\t\t{name},");
                }
                sb.AppendLine("\t]);");
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return
                $"class _{_widgetName}Vm extends Vm {{" +
                $"{Params}" +
                $"\n" +
                $"{VmConstructor}" +
                $"}}";
        }
    }
}
