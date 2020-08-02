# Requirements

## Project

https://github.com/keozx/CleanRx/projects/1

## Location Log

- A user should be able to create a new Log entry for place he has been at, including:
    - Standard Date and Time
    - Location description
    - Current GPS coordinates if desired

- A user should be able to see the log of his past 15 days and above of history in form of a list ordered ascending of Date and Time with each item showing:
    - Location description
    - Date and Time string
    
- A user should be able to filter the log list by:
    - Date
    - Last 15 days
    
- A user should be able to sort the log list by:
    - Date ascending
    - Date descending

- The Location Log should not be shared online however is allowed to be shared by user command, the database used may be a local SQL database or document db.

- Using the Exposure Notification APIs from Google and Apple https://devblogs.microsoft.com/xamarin/contact-tracing-exposure-notification-api/ we can have additional open source implementations like:
    - Provide a way to notify of infection from COVID-19
    - Store anonymous notification that identifies the device of the person exposed in the Cloud
    - Notify of users exposed to nearby COVID-19 infected people they come in contact with as intended by the API

> NOTE: The above functionality is intended for reference only, no liability shall be extended to any code or developers work taken from this reference project.
