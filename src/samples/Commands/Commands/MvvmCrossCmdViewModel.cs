using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;
using MvvmCross.Commands;
using Prism.Mvvm;
using Prism.Services;

namespace Commands
{
    public class MvvmCrossCmdViewModel : BindableBase
    {
        private readonly DeviceService _device;
        private bool _enabled;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                SetProperty(ref _enabled, value);
                (MvxCommand as MvxAsyncCommand<Parameter>)?.RaiseCanExecuteChanged();
            }
        }

        private bool _enabledFromEvent;

        private bool EnabledFromEvent
        {
            get => _enabledFromEvent;
            set
            {
                SetProperty(ref _enabledFromEvent, value);
                (MvxCommand as MvxAsyncCommand<Parameter>)?.RaiseCanExecuteChanged();
            }
        }

        public MvvmCrossCmdViewModel()
        {
            _device = new DeviceService();
            _device.StartTimer(TimeSpan.FromSeconds(3), OnEvent);
            MvxCommand = new MvxAsyncCommand<Parameter>(
                OnClickAsyncTask,
                CanExecute,
                false);
        }

        private bool OnEvent()
        {
            EnabledFromEvent = !_enabledFromEvent;
            Debug.WriteLine($"Event triggered: {_enabledFromEvent}");
            return true;
        }

        private bool CanExecute(object obj)
        {
            return Enabled && EnabledFromEvent;
        }

        private async Task OnClickAsyncTask(Parameter obj)
        {
            try
            {
                // Ideally, we would return the Task instead of awaiting here,
                // but we would not be able to retrieve the Result at Command level
                var result = await ImportantTask(obj).ConfigureAwait(false);
                HandleResult(result);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Expected Exception handled! {ex}");
            }
        }


        private void OnError(Exception ex)
        {
            Debug.WriteLine($"Exception from handler! {ex}");
            // This is an unrecoverable state of the app!
            throw ex;
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
        
        public ICommand MvxCommand { get;}
    }
}