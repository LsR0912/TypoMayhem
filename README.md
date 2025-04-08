# TypoMayhem

TypoMayhem is a WPF-based typing application designed to improve typing speed and accuracy. It provides real-time feedback, customizable typing courses, and detailed performance statistics to help users enhance their typing skills.

---

## Features

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

---

## Installation

1. Clone the repository:
2. Open the solution in Visual Studio 2022.
3. Build the project to restore dependencies.
4. Run the application.

---

## Usage

1. Launch the application.
2. Select a typing course or create a new one.
3. Set the session duration and press "Start" to begin typing.
4. View real-time feedback and statistics during the session.
5. After the session ends, review your performance in the statistics window.

---

## Project Structure

- **ViewModel**: Contains the core logic for managing typing sessions, courses, and statistics.
- **View**: Includes WPF XAML files for the user interface.
- **Model**: Defines data structures like `TypingCourse` and `UserStatistic`.
- **Helpers**: Utility classes such as `KeyboardHandler`, `TextGenerator`, and `CourseHandler`.
- **Commands**: Implements reusable command patterns like `RelayCommand`.

---

## Key Components

### TypingViewModel
Manages the typing session, including real-time feedback, session statistics, and course selection.

### KeyboardHandler
Processes keyboard input and maps keys to characters, supporting special characters like `ä`, `ö`, `ü`, and `ß`.

### TextGenerator
Generates random sentences from the selected course for typing practice.

### StatisticsWindow
Displays session performance, including WPM, SPM, and error count.

---

## Requirements

- **.NET 9**
- **C# 13.0**
- **Visual Studio 2022**

---

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.