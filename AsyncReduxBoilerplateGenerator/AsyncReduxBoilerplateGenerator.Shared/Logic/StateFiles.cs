using AsyncReduxBoilerplateGenerator.Models;
using AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AsyncReduxBoilerplateGenerator.Logic
{
    internal class StateFiles
    {
        public static bool SaveFile(string widgetName, string folderPath, List<Parameter> parameters)
        {
            try
            {
                string basePath = $"{folderPath}\\{widgetName}";
                System.IO.Directory.CreateDirectory(basePath);

                // create file containing state manageent logic
                using (FileStream fs = File.Create($"{basePath}\\{widgetName}Connector.dart"))
                {
                    var connector = new Connector(parameters, widgetName);
                    var vm = new Vm(parameters, widgetName);
                    var factory = new Factory(parameters, widgetName);

                    var sb = new StringBuilder();
                    sb.AppendLine(connector.ToString());
                    sb.AppendLine(vm.ToString());
                    sb.AppendLine(factory.ToString());

                    byte[] bytes = new UTF8Encoding(true).GetBytes(sb.ToString());
                    fs.Write(bytes, 0, bytes.Length);
                }

                // create file containing pure widget
                using (FileStream fs = File.Create($"{basePath}\\{widgetName}Widget.dart"))
                {
                    var widget = new Widget(parameters, widgetName);
                    byte[] bytes = new UTF8Encoding(true).GetBytes(widget.ToString());
                    fs.Write(bytes, 0, bytes.Length);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
