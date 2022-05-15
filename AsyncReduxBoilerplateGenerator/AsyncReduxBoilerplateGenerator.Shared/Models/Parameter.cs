namespace AsyncReduxBoilerplateGenerator.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Parameter(string name, string type)
        {
            Name=name;
            Type=type;
        }
    }
}
