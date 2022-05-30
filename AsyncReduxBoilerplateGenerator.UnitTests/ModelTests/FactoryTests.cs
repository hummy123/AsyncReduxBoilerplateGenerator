using AsyncReduxBoilerplateGenerator.Models;
using AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models;
using System.Text.RegularExpressions;

namespace AsyncReduxBoilerplateGenerator.UnitTests.ModelTests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void ConnectorToString_NoParametersEmpty_AllParametersInString()
        {
            List<Parameter> parameters = new()
                {
                new Parameter("forest", "String"),
                new Parameter("tree", "int")
                };
            var factory = new Factory(parameters, "Forest");

            string expectedOutput = @"
            class _ForestFactory extends VmFactory<AppState, ForestConnector> {
	            _ForestFactory(widget) : super(widget);

	            @override
	            _ForestVm fromStore() {
		            // todo: return values needed for vm from store
		            throw UnimplementedError();
		            return _ForestVm(
			            forest:  ,
			            tree:  ,
		            );
	            }
            }";
            string output = factory.ToString();
            expectedOutput = Regex.Replace(expectedOutput, @"\s+", " ");
            output = Regex.Replace(output, @"\s+", " ");
            expectedOutput = expectedOutput.Trim();
            output = output.Trim();
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
