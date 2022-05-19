using AsyncReduxBoilerplateGenerator.Models;
using AsyncReduxBoilerplateGenerator.Models.Boilerplate_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;


namespace AsyncReduxBoilerplateGenerator.Logic
{
    internal class StateFiles
    {
        public static async Task<bool> SaveFileAsync(string widgetName, List<Parameter> parameters)
        {
            try
            {
                var folderPicker = new FolderPicker();
                folderPicker.FileTypeFilter.Add("*");
                StorageFolder parentFolder = await folderPicker.PickSingleFolderAsync();
                if (parentFolder == null)
                {
                    return false;
                }
                var folder = await parentFolder.CreateFolderAsync(widgetName);
                var file = await folder.CreateFileAsync($"{widgetName}Connector.dart");

                var connector = new Connector(parameters, widgetName);
                var vm = new Vm(parameters, widgetName);
                var factory = new Factory(parameters, widgetName);

                var sb = new StringBuilder();
                sb.AppendLine(connector.ToString());
                sb.AppendLine(vm.ToString());
                sb.AppendLine(factory.ToString());

                await FileIO.WriteTextAsync(file, sb.ToString());

                // widget
                var widget = new Widget(parameters, widgetName);
                file = await folder.CreateFileAsync($"{widgetName}Widget.dart");
                await FileIO.WriteTextAsync(file, widget.ToString());
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
