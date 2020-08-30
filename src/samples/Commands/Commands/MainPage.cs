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
                Spacing = 10,
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
                    new Button { Text = "Delegate Command" }
                        .Width(50)
                        .BindCommand(
                            nameof(vm.DelegateCommand),
                            vm,
                            parameterSource: new Parameter
                            {
                                Type = "DelegateCommand",
                            }),
                    new Label { Text = "Enable Commands?" },
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