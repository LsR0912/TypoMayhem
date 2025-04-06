# TypoMayhem

TypoMayhem is a WPF application designed to help users improve their typing skills through interactive exercises. The application provides real-time feedback on typing accuracy, highlights correct and incorrect keystrokes, and tracks user progress over customizable session durations.

## Features

- Typing exercises with customizable session durations
- Real-time feedback on typing accuracy
- Visual indication of correct and incorrect keystrokes
- Timer to track session duration
- Commands to start and stop typing sessions
- Calculation and display of Words Per Minute (WPM) and Signs Per Minute (SPM)
- Error count tracking
- Detailed statistics window
- Support for multiple typing courses
- Course management: create, edit, and delete custom typing courses

## Installation

1. Clone the repository:
2. Open the solution in Visual Studio 2022.
3. Build the solution to restore the necessary NuGet packages.
4. Run the application.

## Usage

1. Launch the application.
2. Select a typing course from the available courses.
3. Press the "Start" button to begin a typing session.
4. Type the displayed text as accurately as possible.
5. The application will highlight correct keystrokes in light green and incorrect keystrokes in red.
6. The current position will be highlighted in yellow.
7. The session will end when the timer runs out or when the user presses the "Stop" button.
8. At the end of the session, a statistics window will display detailed typing statistics.


## Dependencies

- .NET 9
- WPF

## Project Structure

- `TypoMayhem/ViewModel/TypingViewModel.cs`: Contains the main logic for the typing exercises, including handling user input, updating the display, and managing the timer.
- `TypoMayhem/View/MainWindow.xaml`: Defines the main user interface layout.
- `TypoMayhem/View/MainWindow.xaml.cs`: Contains the code-behind for the main user interface.
- `TypoMayhem/Commands/RelayCommand.cs`: Implements the `ICommand` interface for handling commands.
- `TypoMayhem/Data/Helpers/TextGenerator.cs`: Provides methods for generating random text for typing exercises.
- `TypoMayhem/Data/Helpers/CourseHandler.cs`: Provides methods for loading and saving typing courses.
- `TypoMayhem/ViewModel/CreateCourseViewModel.cs`: ViewModel for creating new typing courses.
- `TypoMayhem/ViewModel/StatisticsViewModel.cs`: ViewModel for displaying typing statistics.
- `TypoMayhem/View/StatisticsWindow.xaml`: Defines the layout for the statistics window.


## Contributing

Contributions are welcome! Please open an issue or submit a pull request with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
