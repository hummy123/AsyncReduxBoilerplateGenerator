using AsyncReduxBoilerplateGenerator.Models;
using System.Text.RegularExpressions;

namespace AsyncReduxBoilerplateGenerator.UnitTests.ModelTests
{
    [TestClass]
    public class VmTests
    {
        [TestMethod]
        public void VmToString_NoParametersEmpty_AllParametersInString()
        {
            List<Parameter> parameters = new()
            {
            new Parameter("forest", "String"),
            new Parameter("tree", "int")
            };
            var vm = new Vm(parameters, "Forest");

            string expectedOutput = @"
            class _ForestVm extends Vm {
	            final String forest;
	            final int tree;

	            _ForestVm({
		            required this.forest,
		            required this.tree,
	            }) : super(equals: 
	            [
		            forest,
		            tree,
	            ]);
            }";
            var output = vm.ToString();

            expectedOutput = Regex.Replace(expectedOutput, @"\s+", " ");
            output = Regex.Replace(output, @"\s+", " ");
            expectedOutput = expectedOutput.Trim();
            output = output.Trim();

            Assert.AreEqual(expectedOutput, output);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
