using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;

namespace Commands
{
    public class DelegateCmdViewModel : BindableBase
    {
        private readonly DeviceService _device;
        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                SetProperty(ref _enabled, value);
            }
        }
        
        private bool _enabledFromEvent;

        private bool EnabledFromEvent
        {
            get => _enabledFromEvent;
            set
            {
                SetProperty(ref _enabledFromEvent, value);
            }
        }

        public DelegateCmdViewModel()
        {
            _device = new DeviceService();
            _device.StartTimer(TimeSpan.FromSeconds(3), OnEvent);
            DelegateCommand = new DelegateCommand<Parameter>(OnClickAsyncVoid, CanExecute)
                .ObservesProperty(() => Enabled)
                .ObservesProperty(() => EnabledFromEvent);
            /* ... and this will cause an exception, is not supported, and it wouldn't take our parameter.
             .ObservesCanExecute(() => Enabled && EnabledFromEvent);
             */
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
        
        public ICommand DelegateCommand { get;}
    }
}