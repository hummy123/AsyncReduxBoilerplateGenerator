﻿using AsyncReduxBoilerplateGenerator.Logic;
using System.Collections.Generic;
using System.Text;

namespace AsyncReduxBoilerplateGenerator.Models
{
    public class Connector
    {
        private List<Parameter> _parameters;
        private string _widgetName;

        public Connector(List<Parameter> parameters, string widgetName)
        {
            this._parameters = parameters;
            this._widgetName = widgetName;
        }

        private string Imports
        {
            get
            {
                return
$@"
import 'package:async_redux/async_redux.dart';
import 'package:flutter/material.dart';
import '{_widgetName.ToSnakeCase()}_widget.dart';

// This is an intermediary logic widget.
// If you are doing design work, go to {_widgetName}Widget
// to edit the design.

";

            }
        }
        private string ConnectorConstructor
        {
            get
            {
                return $"const {_widgetName}Connector" +
                $"({{Key? key}}) : super(key: key);";
            }
        }
        private string BuilderdWidget
        {
            get
            {
                var sb = new StringBuilder($"{_widgetName}Widget(\n");
                foreach (var param in _parameters)
                {
                    sb.AppendLine($"\t\t\t\t{param.Name}: vm.{param.Name},");
                }
                sb.Append("\t\t\t)");
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return
                Imports +
            $"class {_widgetName}Connector extends StatelessWidget {{" +
            $"\n\t{ConnectorConstructor}" +
            $"\n\t@override" +
            $"\n\tWidget build(BuildContext context) {{" +
            $"\n\t\treturn StoreConnector<AppState, _{_widgetName}Vm>(" +
            $"\n\t\t\tvm: () => _{_widgetName}Factory(this)," +
            $"\n\t\t\tbuilder: (context, vm) => {BuilderdWidget}," +
            $"\n\t\t);" +
            $"\n\t}}" +
            $"\n}}\n";
        }
    }
}
