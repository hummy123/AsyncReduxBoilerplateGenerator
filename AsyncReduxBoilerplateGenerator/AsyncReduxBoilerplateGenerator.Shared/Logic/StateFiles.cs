using AsyncReduxBoilerplateGenerator.Models;
using AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;


namespace AsyncReduxBoilerplateGenerator.Logic
{
    internal class StateFiles
    {
        public static async Task<bool> SaveFileAsync(string widgetName, List<Parameter> parameters)
        {
            try
            {
                // add non-empty parameters to new list
                List<Parameter> _parameters = new List<Parameter>();
                foreach (var param in parameters)
                {
                    if (!String.IsNullOrWhiteSpace(param.Name)
                        && !String.IsNullOrWhiteSpace(param.Type))
                    {
                        _parameters.Add(param);
                    }
                }

                if (_parameters.Count == 0)
                {
                    throw new ArgumentException("Given parameters must have a type and a name.");
                }

                var folderPicker = new FolderPicker();
                folderPicker.FileTypeFilter.Add("*");

                StorageFolder parentFolder = await folderPicker.PickSingleFolderAsync();
                if (parentFolder == null)
                {
                    return false;
                }
                var widgetSnakeCase = widgetName.ToSnakeCase();
                var folder = await parentFolder.CreateFolderAsync(widgetSnakeCase);

                var file = await folder.CreateFileAsync($"{widgetSnakeCase}_connector.dart");

                var connector = new Connector(_parameters, widgetName, widgetSnakeCase);
                var vm = new Vm(_parameters, widgetName);
                var factory = new Factory(_parameters, widgetName);
                var widget = new Widget(_parameters, widgetName);

                var sb = new StringBuilder();
                sb.AppendLine(connector.ToString());
                sb.AppendLine(vm.ToString());
                sb.AppendLine(factory.ToString());

#if HAS_UNO_WASM
                sb.AppendLine(widget.ToString());
                await FileIO.WriteTextAsync(file, sb.ToString());
#else
                await FileIO.WriteTextAsync(file, sb.ToString());
                file = await folder.CreateFileAsync($"{widgetSnakeCase}_widget.dart");
                await FileIO.WriteTextAsync(file, widget.ToString());
                await Launcher.LaunchFolderAsync(folder);
#endif
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
