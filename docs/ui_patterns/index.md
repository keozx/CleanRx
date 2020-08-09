---
layout: single
title: "UI Patterns"
classes: wide
---

# Command Pattern

Here we will discuss different Command pattern approaches when developing UI user interactions through ICommand interface. 

It is important to define each approach differences so when it is adopted in an organization is easier to break barriers of adopting one framework or the other or part of them. Most organizations will stick to one framework but that is seldom efficient when you need for the best tool for the job. In my opinion, contrary to common belief, mixing up frameworks is actually a good thing, and proper dependency management should remove the clutter around having many tools in a single code base.

## Command framework comparison

The intent here is to compare different Command frameworks out there, most of them of course are part of a bigger framework but breaking it up in small pieces helps in making the right choice on your current situation.

Feature | XF Command | DelegateCommand | AsyncCommand | ReactiveCommand
------------------- | --------- | --- | --- | ---
Create from Task (not async void) | ❌ | ❌ | ✔️ | ✔️ 
Catches unhandled exceptions | ❌ | ❌ | ✔️ | ✔️ 
Observes boolean changes for "CanExecute" behavior through INPC (not RaiseCanExecute) | ❌ | ✔️ | ❌  | ✔️ 
Observes IObservable ticks for "CanExecute" behavior | ❌ | ❌ | ❌ | ✔️ 
Guards against double execution (double tap) | ❌ | ❌ | ❌ | ✔️ 
Allows to retrieve a T result at end of execution | ❌ | ❌ | ❌ | ✔️ 


### Xamarin.Forms **Command**
Based on above comparison, is there any reason to use XF Command? well only for a quick POC or if all you are really going to do is clicking a button and do something simple that does not require any other feature. However there may be some memory save if you are having a lot of simple buttons in a screen.
[](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.command-1?view=xamarin-forms)

### Prism **DelegateCommand**

DelegateCommand is a better Command implementation because allows observing a boolean for CanExecute, but other than that feels like a half-baked implementation of ICommand, not really intended in my opinion for business critical applications.

### AsyncAwaitBestPractices **AsyncCommand**

AsyncCommand comes from package [Async Await Best Practices](https://github.com/brminnick/AsyncAwaitBestPractices) which apart from giving an implementation of ICommand with error handling, prevents the use of async void. Also the library provides for other good stuff like SafeFireAndForget and WeakEventManager.
Unfortunately it does not provide CanExecute observer pattern like DelegateCommand.

### ReactiveUI **ReactiveCommand**

From all, from what you can see in the table [ReactiveCommand](https://www.reactiveui.net/docs/handbook/commands/) is your swiss army knife implementation of ICommand, fully featured and rock solid, you can't go wrong with it, the flexibility of IObservable as consumer and implementer gives us ultimate adaptability. 

One thing that shines from the rest is also that it has built-in execution blocking so it won't allow double tap or double execution if already fired.
