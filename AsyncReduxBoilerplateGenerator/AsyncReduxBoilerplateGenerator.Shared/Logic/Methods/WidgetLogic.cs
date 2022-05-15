/*
namespace AsyncReduxBoilerplateGenerator.Logic
{
    public partial class Widget
    {
        private string Params
        {
            get
            {
                var sb = new StringBuilder();
                for (int i = 0; i < _parameterNames.Count; i++)
                {
                    var name = _parameterNames[i];
                    var type = _parameterTypes[i];
                    sb.AppendLine($"\tfinal {type} {name};");
                }
                return sb.ToString();
            }
        }

        private string Constructor
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine($"\n\tconst {_widgetName}Widget({{");
                sb.AppendLine("\t\tkey,");
                foreach (var name in _parameterNames)
                {
                    sb.AppendLine($"\t\trequired this.{name},");
                }
                sb.AppendLine("\t}) : super(key: key);");
                return sb.ToString();
            }
        }

        private string WidgetBuilder
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("\n\t@override");
                sb.AppendLine("\tWidget build(BuildContext context) {");
                sb.AppendLine("\t\treturn Container();");
                sb.AppendLine("\t}");
                return sb.ToString();
            }
        }
        public override string ToString()
        {
            return
                "import 'package:flutter/material.dart';\n" +
                $"\nclass {_widgetName}Widget extends StatelessWidget {{\n" +
                Params +
                Constructor +
                WidgetBuilder +
                $"}}";
        }
    }
}
*/