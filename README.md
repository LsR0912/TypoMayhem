# TypoMayhem

TypoMayhem is a WPF-based typing application designed to improve typing speed and accuracy. It provides real-time feedback, customizable typing courses, and detailed performance statistics to help users enhance their typing skills.

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
- Course management: create, edit, and delete custom typing courses.
- Typing Evaluation: See real-time feedback on typing performance.
- Navigation Bar: Navigate between the typing practice and evaluation UI.

### Typing Session
- **Real-Time Feedback**: Visual indicators for correct, incorrect, and current characters.
- **Statistics Tracking**: Monitor Words Per Minute (WPM), Signs Per Minute (SPM), and error count during sessions.
- **Configurable Session Durations**: Choose from predefined durations (1, 2, 3, 4, 5, or 10 minutes).

### Course Management
- **Custom Courses**: Create, edit, and delete typing courses.
- **Default Course**: Includes a default course for quick start.
- **Dynamic Loading**: Courses are loaded dynamically from the file system.

### Keyboard Input Handling
- **KeyboardHandler Utility**: Processes keyboard input and maps keys to characters, including support for special characters and modifiers (Shift, Alt, Control).

### Statistics
- **Session Summary**: View detailed statistics after each session.
- **Persistent Storage**: Save session statistics locally for future reference.



## Installation

1. Clone the repository:
2. Open the solution in Visual Studio 2022.
3. Build the project to restore dependencies.
4. Run the application.

## Usage

1. Launch the application.
2. Select a typing course from the available courses.
3. Press the "Start" button to begin a typing session.
4. Type the displayed text as accurately as possible.
### StatisticsWindow
Displays session performance, including WPM, SPM, and error count.

---

## Requirements
- **Visual Studio 2022**

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.


## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
