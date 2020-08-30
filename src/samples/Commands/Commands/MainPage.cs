using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace Commands
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var vm = new TestViewModel();
            Content = new StackLayout
            {
                Children = { 
                    new Button { Text = "Forms Command" }
                        .Width(50)
                        .BindCommand(
                            nameof(vm.FormsCommand),
                            vm,
                            parameterSource: new Parameter
                            {
                                Type = "Forms",
                            }),
                    new Label { Text = "Enabled Command?" },
                    new Switch()
                        .Bind(nameof(vm.Enabled)),
                },
            };
            BindingContext = vm;
        }
    }

    public class Parameter
    {
        public string Type { get; set; }
    }

    public class Result
    {
        public string Type { get; set; }
    }
}