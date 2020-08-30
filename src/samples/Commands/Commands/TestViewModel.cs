using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Xamarin.Forms;

namespace Commands
{
    public class TestViewModel : BindableBase
    {
        private readonly DeviceService _device;
        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                SetProperty(ref _enabled, value);
                (FormsCommand as Command)?.ChangeCanExecute();
            }
        }
        
        private bool _enabledfromEvent;

        private bool EnabledFromEvent
        {
            get => _enabledfromEvent;
            set
            {
                SetProperty(ref _enabledfromEvent, value);
                (FormsCommand as Command)?.ChangeCanExecute();
            }
        }

        public TestViewModel()
        {
            _device = new DeviceService();
            _device.StartTimer(TimeSpan.FromSeconds(3), OnEvent);
            FormsCommand = new Command<Parameter>(OnForms, CanExecute);
            DelegateCommand = new DelegateCommand<Parameter>(OnForms, CanExecute)
                .ObservesProperty(() => Enabled)
                .ObservesProperty(() => EnabledFromEvent);
            /* ... and this will cause an exception, is not supported, and it wouldn't take our parameter.
             .ObservesCanExecute(() => Enabled && EnabledFromEvent);
             */
        }

        private bool OnEvent()
        {
            EnabledFromEvent = !_enabledfromEvent;
            Debug.WriteLine($"Event triggered: {_enabledfromEvent}");
            return true;
        }

        bool CanExecute(Parameter obj)
        {
            return Enabled && EnabledFromEvent;
        }

        private async void OnForms(Parameter obj)
        {
            // We have to await the Task and try/catch this async void,
            // otherwise we would not catch exceptions on the ImportantTask handler, 
            // like when we don't change Enabled in the Main Thread, then our app wouldn't make a noise!
            try
            {
                Enabled = false;
                try
                {
                    var result = await ImportantTask(obj).ConfigureAwait(false);
                    HandleResult(result);
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine($"Expected Exception handled! {ex}");
                }
                finally
                {
                    // If you did this you would run into threading exception,
                    // shows our point above.
                    // Enabled = true;
                    _device.BeginInvokeOnMainThread(() => Enabled = true);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception from handler! {ex}");
                // This is an unrecoverable state of the app!
                throw;
            }
        }

        private void HandleResult(Result result)
        {
            Debug.WriteLine($"Result is {result.Type}");
        }

        private static async Task<Result> ImportantTask(Parameter parameter)
        {
            Debug.WriteLine($"Command executed from {parameter?.Type}");
            await Task.Delay(3000);
            var rnd = new Random().Next(10);
            if (rnd > 5)
            {
                Debug.WriteLine("Exception! Because it can happen");
                throw new InvalidOperationException();
            }
            return new Result{ Type = parameter?.Type };
        }

        public ICommand FormsCommand { get;}
        public ICommand DelegateCommand { get;}
    }
}