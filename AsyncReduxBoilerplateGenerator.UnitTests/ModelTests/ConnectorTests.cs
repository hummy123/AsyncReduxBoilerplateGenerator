using AsyncReduxBoilerplateGenerator.Models;
using System.Text.RegularExpressions;

namespace AsyncReduxBoilerplateGenerator.UnitTests.ModelTests
{
    public class ConnectorTests
    {
        [TestClass]
        public class VmTests
        {
            [TestMethod]
            public void ConnectorToString_NoParametersEmpty_AllParametersInString()
            {
                List<Parameter> parameters = new()
                {
                new Parameter("forest", "String"),
                new Parameter("tree", "int")
                };
                var connector = new Connector(parameters, "Forest");

                string expectedOutput = @"
                import 'package:async_redux/async_redux.dart';
                import 'package:flutter/material.dart';
                import 'forest_widget.dart';

                // This is an intermediary logic widget.
                // If you are doing design work, go to ForestWidget
                // to edit the design.

                class ForestConnector extends StatelessWidget {
	                const ForestConnector({Key? key}) : super(key: key);
	                @override
	                Widget build(BuildContext context) {
		                return StoreConnector<AppState, _ForestVm>(
			                vm: () => _ForestFactory(this),
			                builder: (context, vm) => ForestWidget(
				                forest: vm.forest,
				                tree: vm.tree,
			                ),
		                );
	                }
                }";
                var output = connector.ToString();

                expectedOutput = Regex.Replace(expectedOutput, @"\s+", " ");
                output = Regex.Replace(output, @"\s+", " ");
                expectedOutput = expectedOutput.Trim();
                output = output.Trim();

                Assert.AreEqual(expectedOutput, output);
            }
        }
    }
}
