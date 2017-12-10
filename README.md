# Mobile-App-Dev-Project-Yr-4
Repo for my UWP project

+ [Introduction](#introduction)
+  [UI Framework](#UI-Framework)
+ [Mobile Services ](#Mobile-Services)
+ [API's Used](#API's-Used)
+ [Project Specification](#project-specification)


## Introduction
 
This app is a UWP applciation used for cryptocurrency news and price information. The app also features a login section which will be used for future functionality.

### UI Framework

The UI of the project was built using XAML and C#. The projects follows an MVVM project design.
The views handle the presentation and changes to the presentation like opening links. 
Business logic and backend code is placed into the Model and ViewModel to isolate the View from the business logic.

The [GalaSoft.Mvvm](https://github.com/lbugnion/mvvmlight/tree/master/GalaSoft.MvvmLight) framework was used to help build a light archetecture that can be extended in the future. 

The UI used is a part of the [Telerik UI for UWP Framework](https://www.telerik.com/universal-windows-platform-ui)


## Mobile Services

The Mobile services used for the project in clude API's and a self hosted instance on Azure.

#### Self Hosted DB:
Azure has been used to host a database for both storage and retrevial or data and login functionalities. 
The database used is CouchDD which is used in conjuction with Docker to speed up deployment/ make additional server setup quicker. 

I am utilsing the `couch-per-user plugin` for couchdb. This means that when a user creates an account in the db, they are assigned a private database accessible to only them. This ensure the safety of the users data and segregates the data nicely into different DB's. 
Here is a link to docker to [learn more](https://www.docker.com)
Here is also a link to the [docker container I am using in my build.](https://hub.docker.com/r/apache/couchdb/) 


## API's Used

CryptoCoinNews :
Crypto coin news provide an api for all the news on their platform. This api has been optimised by the crew at [NewsApi](https://newsapi.org). News API combine over 5000 news sources to create one single spec for all these different news sources. Standardising the way we programmatically get news.

 

## Project Specification
### Overview
In this project you will create a web application in Python to recognise digits in images.
Users will be able to visit the web application through their browser, submit (or draw) an image containing a single digit, and the web application will respond with the digit contained in the image.
You should use [tensorflow](https://www.tensorflow.org/) and [flask](http://flask.pocoo.org/) to do this.
Note that accuracy of approximately 99% is considered excellent in recognising digits, so it is okay if your algorithm gets it wrong sometimes.

### Instructions
Create a Windows 10 UWP App.  The application should incorporate the following elements: 
+ A responsive UI across the Windows 10 devices.  There are some available for testing and this includes the IoT core, mobile devices, tablet and PC.  This includes Visual State Management and using available SDKs for individual device types. 
+ A UI that has been well designed and is fit for purpose.  User Experience should be carefully considered while developing the application.  The User Experience should be consistent across devices. 
+ Mobile services for data storage and retrieval. The cloud service does not have to be written in C# to be able to interact with a UWP.  The preferred cloud to use is Azure.
+ Use of the MVVM design pattern in the development approach.  

### Submission
To submit your project, you must make your git repository available using a git hosting service like [GitHub](https://github.com/) or [GitLab](https://gitlab.com).
