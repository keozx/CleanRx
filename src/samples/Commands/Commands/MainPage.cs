using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace Commands
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var formsVm = new FormsCmdViewModel();
            var delegateVm = new DelegateCmdViewModel();
            Content = new StackLayout
            {
                Spacing = 10,
                Children = 
                { 
                    new ContentView
                    { 
                        BindingContext = formsVm,
                        Content = new StackLayout
                        {
                            BindingContext = formsVm,
                            Children =
                            {
                                new Button { Text = "Forms Command" }
                                    .Width(50)
                                    .BindCommand(
                                        nameof(formsVm.FormsCommand),
                                        formsVm,
                                        parameterSource: new Parameter
                                        {
                                            Type = "Forms",
                                        }),
                                new Label { Text = "Enable Command?" },
                                new Switch()
                                    .Bind(nameof(formsVm.Enabled)),
                            },
                        },
                    },
                    new ContentView
                    { 
                        BindingContext = delegateVm,
                        Content = new StackLayout
                        {
                            BindingContext = delegateVm,
                            Children =
                            {
                                new Button { Text = "Delegate Command" }
                                    .Width(50)
                                    .BindCommand(
                                        nameof(delegateVm.DelegateCommand),
                                        delegateVm,
                                        parameterSource: new Parameter
                                        {
                                            Type = "DelegateCommand",
                                        }),
                                new Label { Text = "Enable Command?" },
                                new Switch()
                                    .Bind(nameof(delegateVm.Enabled)),
                            },
                        },
                    },
                },
            };
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