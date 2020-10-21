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
            var asyncVm = new AsyncCmdViewModel();
            var rxVm = new ReactiveCmdViewModel();
            var mvxVm = new MvvmCrossCmdViewModel();
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
                                    .Height(50)
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
                                    .Height(50)
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
                    new ContentView
                    { 
                        BindingContext = asyncVm,
                        Content = new StackLayout
                        {
                            BindingContext = asyncVm,
                            Children =
                            {
                                new Button { Text = "Async Command" }
                                    .Width(50)
                                    .Height(50)
                                    .BindCommand(
                                        nameof(asyncVm.AsyncCommand),
                                        asyncVm,
                                        parameterSource: new Parameter
                                        {
                                            Type = "AsyncCommand",
                                        }),
                                new Label { Text = "Enable Command?" },
                                new Switch()
                                    .Bind(nameof(asyncVm.Enabled)),
                            },
                        },
                    },
                    new ContentView
                    { 
                        BindingContext = rxVm,
                        Content = new StackLayout
                        {
                            BindingContext = rxVm,
                            Children =
                            {
                                new Button { Text = "Reactive Command" }
                                    .Width(50)
                                    .Height(50)
                                    .BindCommand(
                                        nameof(rxVm.RxCommand),
                                        rxVm,
                                        parameterSource: new Parameter
                                        {
                                            Type = "ReactiveCommand",
                                        }),
                                new Label { Text = "Enable Command?" },
                                new Switch()
                                    .Bind(nameof(rxVm.Enabled)),
                            },
                        },
                    },
                    new ContentView
                    { 
                        BindingContext = mvxVm,
                        Content = new StackLayout
                        {
                            BindingContext = mvxVm,
                            Children =
                            {
                                new Button { Text = "MvvmCross Command" }
                                    .Width(50)
                                    .Height(50)
                                    .BindCommand(
                                        nameof(mvxVm.MvxCommand),
                                        mvxVm,
                                        parameterSource: new Parameter
                                        {
                                            Type = "MvxCommand",
                                        }),
                                new Label { Text = "Enable Command?" },
                                new Switch()
                                    .Bind(nameof(mvxVm.Enabled)),
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