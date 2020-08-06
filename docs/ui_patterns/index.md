---
layout: single
classes: wide
---

Here we will discuss different Command pattern approaches when developing UI user interactions through ICommand interface. 

It is important to define each approach differences so when it is adopted in an organization is easier to break barriers of adopting one framework or the other or part of them. Most organizations will stick to one framework but that is seldom efficient when you need for the best tool for the job. In my opinion, contrary to common belief, mixing up frameworks is actually a good thing, and proper dependency management should remove the clutter around having many tools in a single code base.

## Command framework comparison

The intent of this section is to compare different Commanding frameworks out there, most of them of course are part of a bigger framework but breaking it up in small pieces helps in making the right choice on your current situation.

Feature | XF Command | DelegateCommand | AsyncCommand | ReactiveCommand
------------------- | --------- | --- | --- | ---
Create from Task (not async void) | ❌ | ❌ | ✔️ | ✔️ 
Catches exceptions | ❌ | ❌ | ✔️ | ✔️ 
Observes boolean changes for "CanExecute" behavior through INPC (not RaiseCanExecute) | ❌ | ✔️ | ❌  | ✔️ 
Observes IObservable ticks for "CanExecute" behavior | ❌ | ❌ | ❌ | ✔️ 
Guards against double execution (double tap) | ❌ | ❌ | ❌ | ✔️ 
Allows to retrieve a T result at end of execution | ❌ | ❌ | ❌ | ✔️ 

### Xamarin.Forms **Command**
Based on above comparison, is there any reason to use XF Command? well only for a quick POC or if all you are really going to do is clicking a button and do something simple that does not require any other feature. However there may be some memory save if you are having a lot of simple buttons in a screen.
https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.command-1?view=xamarin-forms

### Prism **DelegateCommand**

### AsyncAwaitBestPractices **AsyncCommand**

### ReactiveUI **ReacticeCommand**