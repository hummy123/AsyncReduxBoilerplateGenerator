using System.Collections.Generic;
using System.Text;

namespace AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models
{
    internal class Widget
    {
        private List<Parameter> _parameters;
        private string _widgetName;

        public Widget(List<Parameter> parameters, string widgetName)
        {
            _parameters=parameters;
            _widgetName=widgetName;
        }

        private string Params
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var param in _parameters)
                {
                    sb.AppendLine($"\tfinal {param.Type} {param.Name};");
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
                foreach (var param in _parameters)
                {
                    sb.AppendLine($"\t\trequired this.{param.Name},");
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
