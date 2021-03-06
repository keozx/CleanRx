---
layout: single
title: "UI Patterns"
classes: wide
toc: true
toc_label: "UI Patterns"
toc_icon: "cog"
---

# Command Pattern

Here we will discuss different Command pattern approaches when developing UI user interactions through ICommand interface. 

Sample application is provided in here:
https://github.com/keozx/CleanRx/tree/master/src/samples/Commands

Also you can read the in deep post explaining each approach along with the demo App here:
https://dev.to/keozdev/ui-command-pattern-268n 

It is important to analyze each approach and the differences among them so when it is adopted within a team is easier to break barriers of adopting one framework or the other or small part of it. Most organizations will stick to one framework but that is seldom efficient when you need the best tool to get the job done. In my opinion, contrary to common belief, mixing up frameworks is actually a good thing, linking and proper dependency management should remove the clutter around having many tools in a single code base.

## Command framework comparison

The intent here is to compare different Command frameworks out there, most of them of course are part of a bigger framework but breaking it up in small pieces helps in making the right choice on your current situation.

Feature | XF Command | DelegateCommand | AsyncCommand | ReactiveCommand
------------------- | --------- | --- | --- | ---
Executes a simple bindable Action | ✔️ | ✔️ | ✔️ | ✔️ \<T\>
Create from Task\<T\> (not async void) | ❌ | ❌ | ✔️ | ✔️ 
Retrieve unhandled exceptions | ❌ | ❌ | ✔️ | ✔️ 
Observes boolean changes for "CanExecute" behavior through INPC (not RaiseCanExecute) | ❌ | ✔️ | ❌  | ✔️ *WhenAnyValue
Observes IObservable ticks for "CanExecute" behavior | ❌ | ❌ | ❌ | ✔️ 
Guards against double execution (double tap) | ❌ | ❌ | ❌ | ✔️ 
Returns a \<T\> result at end of execution | ❌ | ❌ | ❌ | ✔️ 
Accessible "CanExecute" state | ❌ | ❌ | ❌ | ✔️ 
Accessible "IsExecuting" state | ❌ | ❌ | ❌ | ✔️ 
Subscribe to Completion and executes handler for \<T\> result | ❌ | ❌ | ❌ | ✔️ 

### Xamarin.Forms `Command`
Based on above comparison, is there any reason to use XF Command? well only for a quick POC or if all you are really going to do is clicking a button and do something simple that does not require any other feature. However there may be some memory save if you are having a lot of simple buttons in a screen. A benchmark comparison coming soon.
[Xamarin Docs](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.command-1?view=xamarin-forms)

### Prism `DelegateCommand`

`DelegateCommand` is a better Command implementation because allows observing a boolean for 'CanExecute', but other than that, feels like a half-baked implementation of `ICommand`, not really intended in my opinion for use in complex apps. [Prism Docs](https://prismlibrary.com/docs/commanding.html)

### AsyncAwaitBestPractices `AsyncCommand`

`AsyncCommand` comes from package [Async Await Best Practices](https://github.com/brminnick/AsyncAwaitBestPractices) which apart from giving an implementation of ICommand with error handling, prevents the use of async void. Also the library provides for other good stuff like `SafeFireAndForget()` and `WeakEventManager` so is a handy package for Task based programming.

Unfortunately it does not provide `CanExecute` observer pattern like `DelegateCommand`, but is capable of catching exceptions if you provide an Error Handler parameter when creating the Command.

### ReactiveUI `ReactiveCommand`

From all, from what you can see in the table [ReactiveCommand](https://www.reactiveui.net/docs/handbook/commands/) is your swiss army knife implementation of `ICommand`, fully featured and rock solid, you can't go wrong with it, the flexibility of `IObservable` as consumer and implementer gives us ultimate adaptability. 

`ReactiveCommand` is also the only one capable of providing a generic typed result, additional to the default parameter in `ICommand`, to allow to retrieve the execution output, this is useful for Unit Testing because often you would want to assert the outcome of an operation starting with the click of a button end to end.

One thing that shines from the rest is also that it has built-in execution blocking so it won't allow double tap or double execution if already fired, whether is a Task or an Action. Also, you can retrieve `CanExecute` and `IsExecuting` states to have better awareness for other components that may need to know execution state.

\*While not directly capable of observing a boolean property, what RxUI Command offers is accepting the more robust `IObservable` type parameter for `CanExecute` behavior. You have to take an extra step to use `WhenAnyValue()` extension to wrap the INPC events from a property into an observable but in a real world application you rarely just watch for a single source, you could chain different observables here without having to notify of Can Execute has changed, so this is handy when having to watch multiple states at once and calculate whether or not the Command should be enabled or disabled.
