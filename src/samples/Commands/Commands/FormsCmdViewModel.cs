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
    public class FormsCmdViewModel : BindableBase
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
        
        private bool _enabledFromEvent;

        private bool EnabledFromEvent
        {
            get => _enabledFromEvent;
            set
            {
                SetProperty(ref _enabledFromEvent, value);
                (FormsCommand as Command)?.ChangeCanExecute();
            }
        }

        public FormsCmdViewModel()
        {
            _device = new DeviceService();
            _device.StartTimer(TimeSpan.FromSeconds(3), OnEvent);
            FormsCommand = new Command<Parameter>(OnClickAsyncVoid, CanExecute);
        }

        private bool OnEvent()
        {
            EnabledFromEvent = !_enabledFromEvent;
            Debug.WriteLine($"Event triggered: {_enabledFromEvent}");
            return true;
        }

        private bool CanExecute(Parameter obj)
        {
            return Enabled && EnabledFromEvent;
        }

        private async void OnClickAsyncVoid(Parameter obj)
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

        private static void HandleResult(Result result)
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
    }
}