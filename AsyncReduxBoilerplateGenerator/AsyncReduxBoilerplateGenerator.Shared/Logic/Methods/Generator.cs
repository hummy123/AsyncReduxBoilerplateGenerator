namespace AsyncReduxBoilerplateGenerator.Logic
{
    public static class Generator
    {
        public static bool SaveFile(String widgetName, String folderPath, List<string> parameterNames, List<string> parameterTypes)
        {
            try
            {
                string basePath = $"{folderPath}\\{widgetName}";
                System.IO.Directory.CreateDirectory(basePath);

                // create file containing state manageent logic
                using (FileStream fs = File.Create($"{basePath}\\{widgetName}Connector.dart"))
                {
                    var connector = new Connector(parameterNames, widgetName);
                    var vm = new ViewModel(parameterNames, parameterTypes, widgetName);
                    var factory = new Factory(parameterNames, widgetName);

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
                    var widget = new Widget(parameterNames, parameterTypes, widgetName);
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
