# Gravitrips #

Gravitrips (most famous as Connect Four) is a two-player connection game in which the players first choose a color and then take turns dropping colored discs from the top into a seven-column, six-row vertically suspended grid. The pieces fall straight down, occupying the next available space within the column. The objective of the game is to be the first to form a horizontal, vertical, or diagonal line of four of one’s own discs. 

This project developed for technical assessment for Windows Phone Software Engineer position.  

## How to build/deploy/use solution. ## 
### Requirements ###
Windows 10 build 10240
Visual Studio 2015
Windows Software Development Kit (SDK) for Windows 10 

### Build and run ###
Open Gravitrips.sln n Visual Studio.
Set the StartUp project to Gravitrips.UI, press F5.

## About technical choices ## 
UWP has been chosen because it actual for all devices on Windows 10. App developed on UWP can launched on mobile devices, PC, XBOX and others. 
Game core logic isolated from UI and may be used for web or desktop apps. 
Game class responsible for interaction between players and game field. It independent from realization of game field and player classes.
ClassicGameField contains classical game logic with field 6x7. It's easy to change game field size using inheritance from this class. Otherwise it possible to create another game logic using inheritance from GameFieldBase. 
Strategy pattern used for AI realization because it lets the AI algorithm vary independently from other classes.

## What could be improved or added ##

### Refactoring and code ###
- Create better AI strategies.
- Game and GameField classes could be refactored.  

### Architecture ###
- Change MVVM framework to MvvmCross and isolate ViewModels and other core logic in PCL. This will open up the possibility for creating Android and iOS apps using existing core code.

### UI ###
- App design improving, styles for controls. 
- Game grid and buttons dynamic sizing based on game field properties (ColumnsCount and RowsCount).

### Features ###
- Players color choising. 
- Game statistics.
- Difficulty levels for Single game.

## Links to my other projects ##
These apps I created from scratch. From customer discovery to mobile and backend development. Xamarin and Azure used for it. 
[Зерновозы Android](https://play.google.com/store/apps/details?id=porttranzit.nat.client)
[Зерновозы iOS](itunes.apple.com/ru/app/zernovozy/id1078602962?l=ru&ls=1&mt=8)

Smekay.net - dating service. In this project I led mobile development team. Now this project is dead. 
[Smekay Windows Phone](http://smekaynet.10appstore.net/win10apps.html) 
[Smekay Android](https://play.google.com/store/apps/details?id=com.smekay.android) 

Mobile app for Latvian repairers marketplace.
[Mans Meistars Android](https://play.google.com/store/apps/details?id=mans.meistars) 
