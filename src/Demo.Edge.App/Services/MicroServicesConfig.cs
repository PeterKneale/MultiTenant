namespace Demo.Edge.App.Services
{
    public class MicroServicesConfig
    {
        public class WidgetOperations
        {
            public static string GetItems() => $"/api/widgets";
        }

        public string Widgets { get; set; }
    }
}
