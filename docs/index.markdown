---
# Feel free to add content and custom Front Matter to this file.
# To modify the layout, see https://jekyllrb.com/docs/themes/#overriding-theme-defaults

layout: splash
title: "CleanRx"
author_profile: true
header:
  overlay_color: "#000"
  overlay_image: "/assets/images/back.png"
  overlay_filter: 0.5
  actions:
    - label: "Show me code!"
      url: "https://github.com/keozx/CleanRx"
excerpt: "Clean Architecture & Design Guidance for .NET with a focus on Mobile and help of Reactive Programming"
classes:
  - landing
  - dark-theme
intro: 
  - excerpt: '> *I believe the main reason behind bad software design existance is we fail to communicate good software design. - Jorge Castro*'
feature_row:
  - image_path: /assets/images/Thumbnail600_400/1.png
    alt: "Example Code"
    title: "Example Code"
    excerpt: 'Explore code examples using SOLID and company. (Soon!)'
    url: "https://github.com/keozx/CleanRx/tree/master/src/samples"
    btn_label: "Explore"
    btn_class: "btn--primary"
  - image_path: /assets/images/Thumbnail600_400/2.png
    alt: "SOLID"
    title: "Design Principles"
    excerpt: 'What SOLID stands for and close related design principles.'
    url: "/solid/"
    btn_label: "Explore"
    btn_class: "btn--primary"
  - image_path: /assets/images/Thumbnail600_400/3.png
    alt: "Testing"
    title: "Testing"
    excerpt: 'Testing guidance on TDD and patterns explained.'
    url: "/testing/"
    btn_label: "Explore"
    btn_class: "btn--primary"
---


## Why?

I want to close the existing gap on having a guidance for real world implementation of Clean Architecture in .NET platforms, specially when using Xamarin and a Reactive paradigm. Also to promote best practices on adaptive code and design principles like DRY, ETC and SOLID as it grows. I am a strong believer that these practices and architecture allow us to write scalable, testable, adaptable and maintainable applications.

I rant about the possible reasons we fail to implement SOLID and company successfully in my blog's [book review on Adaptive Code](
https://www.jorgecastro.dev/posts/book-review-adaptive-code-agile-coding-with-design-patterns-and-solid-principles-4c82/)

{% include feature_row id="intro" type="center" %}

{% include feature_row %}

## Inspiration

CleanRx for .NET is inspired in other efforts on using modern Clean Architecture and SOLID principles in other platforms and general best practices in .NET / C#. I'll give credit as much as I can but if you find something should be referenced properly let me know. The ideas exposed here and the samples will try to be original and evolve as my understanding of the concepts and practical experiences mature. However, I'm using as base any public resource I can find and synthesize concepts based on my readings taking the best of each one I have came across with regarding this subject.

### On Clean Architecture

- [Clean Architecture — Functional Style Use Case Composition with RxJava/Kotlin](https://medium.com/@june.pravin/clean-architecture-functional-style-use-case-composition-with-rxjava-kotlin-898726c97dfe)

- [Architecting Android...The clean way?](https://fernandocejas.com/2014/09/03/architecting-android-the-clean-way/)

- [Architecting Android...Reloaded](https://fernandocejas.com/2018/05/07/architecting-android-reloaded/)

- [Architecting Android...The evolution](https://fernandocejas.com/2015/07/18/architecting-android-the-evolution/)

- [Clean Architecture with reactive use cases](https://medium.com/stepstone-tech/clean-architecture-with-reactive-use-cases-c943d7a8f69c)

### On Reactive Programming

- [ReactiveX](reactive.io)
- [ReactiveUI](reactiveui.net)
  - Kent Boogaart's book: [You, I and Reactive UI](https://www.blurb.com/b/8680442-you-i-and-reactiveui-color-hardcover)

### On Adaptive Code and SOLID principles

- Gary McLean Hall's book: [Adaptive Code: Agile coding with design patterns and SOLID principles](https://www.microsoftpressstore.com/store/adaptive-code-agile-coding-with-design-patterns-and-9781509302581)
- [In Defense of the SOLID Principles](https://blog.ndepend.com/defense-solid-principles/)

### On Support Patterns

- [Prism Modularity](https://github.com/PrismLibrary/Prism/tree/master/Source/Prism/Modularity)
- Allan Ritchie's [Shiny samples](https://github.com/shinyorg/shinysamples) / a good quality code case study

