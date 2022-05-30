using AsyncReduxBoilerplateGenerator.Models;
using AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models;
using System.Text.RegularExpressions;

namespace AsyncReduxBoilerplateGenerator.UnitTests.ModelTests
{
    [TestClass]
    public class WidgetTests
    {
        [TestMethod]
        public void WidgetToString_NoParametersEmpty_AllParametersInString()
        {
            List<Parameter> parameters = new()
            {
            new Parameter("forest", "String"),
            new Parameter("tree", "int")
            };
            var widget = new Widget(parameters, "Forest");

            string expectedOutput = @"
            import 'package:flutter/material.dart';

            class ForestWidget extends StatelessWidget {
	            final String forest;
	            final int tree;

	            const ForestWidget({
		            key,
		            required this.forest,
		            required this.tree,
	            }) : super(key: key);

	            @override
	            Widget build(BuildContext context) {
		            return Container();
	            }
            }
            ";
            var output = widget.ToString();

            // replace all whitespace (normal " " space, tabs, newlines, etc.)
            // with a single whitespace so formatting isn't an issue in comparison.
            // Remove any trailing/leading whitespace too.
            expectedOutput = Regex.Replace(expectedOutput, @"\s+", " ");
            output = Regex.Replace(output, @"\s+", " ");
            expectedOutput = expectedOutput.Trim();
            output = output.Trim();

            Assert.AreEqual(expectedOutput, output);
        }
    }
}