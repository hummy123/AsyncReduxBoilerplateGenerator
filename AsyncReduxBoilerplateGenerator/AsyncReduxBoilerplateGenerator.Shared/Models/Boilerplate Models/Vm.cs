﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncReduxBoilerplateGenerator.Models
{
    public class Vm
    {
        private List<Parameter> _parameters;
        private string _widgetName;

        public Vm(List<Parameter> parameters, string widgetName)
        {
            _parameters = parameters;
            _widgetName = widgetName;
        }

        private string Params
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var param in _parameters)
                {
                    sb.Append($"\n\tfinal {param.Type} {param.Name};");
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
                foreach (var param in _parameters)
                {
                    sb.AppendLine($"\t\trequired this.{param.Name},");
                }
                sb.AppendLine($"\t}}) : super(equals: \n\t[");

                foreach (var param in _parameters)
                {
                    // don't want to add functions to equals list
                    // as this is not valid, so skip adding if type is function.
                    bool containsVC = param.Type.IndexOf("VoidCallback", StringComparison.OrdinalIgnoreCase) >= 0;
                    bool containsFunc = param.Type.IndexOf("Function", StringComparison.OrdinalIgnoreCase) >= 0;
                    if (containsVC || containsFunc)
                    {
                        continue;
                    }
                    sb.AppendLine($"\t\t{param.Name},");
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
