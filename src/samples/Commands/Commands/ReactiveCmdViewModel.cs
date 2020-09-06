using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;
using Prism.Mvvm;
using Prism.Services;
using ReactiveUI;

namespace Commands
{
    public class ReactiveCmdViewModel : BindableBase
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

        public ReactiveCmdViewModel()
        {
            _device = new DeviceService();
            _device.StartTimer(TimeSpan.FromSeconds(3), OnEvent);
            RxCommand = ReactiveCommand
                .CreateFromTask<Parameter, Result>(
                    ImportantTask,
                    CanExecute());
            RxCommand
                .Subscribe(HandleResult);
            RxCommand
                .ThrownExceptions
                .Subscribe(OnError);
        }

        private bool OnEvent()
        {
            EnabledFromEvent = !_enabledFromEvent;
            Debug.WriteLine($"Event triggered: {_enabledFromEvent}");
            return true;
        }

        private IObservable<bool> CanExecute()
        {
            // Mimicking DelegateCommand with WhenAnyValue here:
            return this.ObservesProperty(
                () => Enabled,
                () => EnabledFromEvent);
    
            /* Same as this:
            return this.WhenAnyValue(
                vm => vm.Enabled,
                vm => vm.EnabledFromEvent,
                (enabled, enabledEvent) => enabled && enabledEvent);
                */
        }

        /// <summary>
        /// You can use this method instead of handling the InvalidOperationException on ThrownExceptions
        /// </summary>
        private async Task<Result> OnClickAsyncTask(Parameter obj)
        {
            try
            {
                return await ImportantTask(obj).ConfigureAwait(false);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Expected Exception handled! {ex}");
                return default;
            }
        }

        private void OnError(Exception ex)
        {
            if (ex is InvalidOperationException)
            {
                Debug.WriteLine($"Expected Exception handled! {ex}");
            }
            else
            {
                Debug.WriteLine($"Exception from handler! {ex}");
                // This is an unrecoverable state of the app!
                RxApp.DefaultExceptionHandler.OnNext(ex);
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
        
        public ReactiveCommand<Parameter, Result> RxCommand { get;}
    }
}