# Release Notes for TypoMayhem v1.0.0

## Release Date: March 27, 2025

## Overview

We are excited to announce the release of TypoMayhem v1.0.0! This initial release includes a variety of features designed to help users improve their typing skills through interactive exercises and real-time feedback.

## New Features

- **Typing Exercises**: Users can practice typing with randomly generated sentences.
- **Session Durations**: Customizable session durations ranging from 1 to 10 minutes.
- **Real-Time Feedback**: Visual indication of correct (light green) and incorrect (red) keystrokes.
- **Current Position Highlighting**: The current typing position is highlighted in yellow.
- **Timer**: A countdown timer to track the duration of the typing session.
- **Commands**: Start and stop typing sessions using commands.
- **Text Display**: Dynamic text display with background color changes and drop shadow effects for better visibility.

## Improvements

- **User Input Handling**: Improved handling of user input, including support for shift key detection and space key.
- **Display Updates**: Enhanced display updates to reflect the current typing status and errors.
- **Error Tracking**: Tracks incorrect positions and provides visual feedback.

## Bug Fixes

- **Timer Issues**: Fixed issues related to the timer not starting or stopping correctly.
- **Display Reset**: Ensured the display resets correctly when a new session starts or stops.

## Known Issues

- **Case Sensitivity**: The application currently does not handle case sensitivity for non-alphabetic characters.
- **Special Characters**: Limited support for special characters in the typing exercises.

## Contributing

We welcome contributions! Please open an issue or submit a pull request with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

Thank you for using TypoMayhem! We hope you enjoy improving your typing skills with our application.


# Release Notes for TypoMayhem v2.0.0

## Release Date: March 28, 2025

## Overview

We are pleased to announce the release of TypoMayhem v2.0.0! This release introduces new features, improvements, and bug fixes to enhance the user experience and provide more detailed typing statistics.

## New Features

- **Typing Statistics**: Added calculation and display of Words Per Minute (WPM) and Signs Per Minute (SPM) at the end of each session.
- **Error Count**: Tracks and displays the number of errors made during a typing session.
- **Statistics Window**: A new window that shows detailed statistics, including session duration, error count, WPM, and SPM.

## Improvements

- **Enhanced Display Updates**: Improved the visual feedback for correct and incorrect keystrokes.
- **Session Reset**: Enhanced the reset functionality to clear the display and update statistics at the end of each session.
- **User Input Handling**: Improved handling of user input, including better detection of shift key and space key.

## Bug Fixes

- **Timer Issues**: Fixed issues related to the timer not starting or stopping correctly.
- **Display Reset**: Ensured the display resets correctly when a new session starts or stops.
- **WPM Calculation**: Fixed the calculation of Words Per Minute to handle cases where there are no spaces in the input.

## Known Issues

- **Case Sensitivity**: The application currently does not handle case sensitivity for non-alphabetic characters.
- **Special Characters**: Limited support for special characters in the typing exercises.


# Release Notes for TypoMayhem v3.0.0

## Release Date: April 06, 2025

## Overview

We are excited to announce the release of TypoMayhem v3.0.0! This release introduces new features, improvements, and bug fixes to enhance the user experience and provide more flexibility in typing practice.

## New Features

- **Typing Courses**: Added support for multiple typing courses. Users can now create, edit, and delete custom typing courses.
- **Course Management**: New commands and UI elements for managing typing courses, including creating new courses, editing existing courses, and deleting courses.
- **Course Selection**: Users can select a typing course from a list of available courses to practice with.

## Improvements

- **Session Events**: Added `SessionStarted` and `SessionEnded` events to notify when a typing session starts and ends.
- **Session Reset**: Enhanced the reset functionality to clear the display and update statistics at the end of each session.

## Bug Fixes

- **Display Reset**: Ensured the display resets correctly when a new session starts or stops.
- **WPM Calculation**: Fixed the calculation of Words Per Minute to handle cases where there are no spaces in the input.

## Known Issues

- **Case Sensitivity**: The application currently does not handle case sensitivity for non-alphabetic characters.
- **Special Characters**: Limited support for special characters in the typing exercises.


# Release Notes - TypoMayhem v4.0.0

## Overview
TypoMayhem v4.0.0 introduces significant new features, improvements, and bug fixes to enhance the typing experience. This release focuses on providing better session management, detailed performance tracking, and robust course management capabilities.

## New Features

### Keyboard Input Handling
- **KeyboardHandler Integration**: 
  - Added the `KeyboardHandler` utility to process keyboard input and map keys to characters.
  - Supports special characters, numeric keys, and modifiers like Shift, Alt, and Control.
  - Handles locale-specific characters such as `ä`, `ö`, `ü`, and `ß`.

### Course Management
- **Custom Courses**: Create, edit, and delete custom typing courses directly within the application.
- **Default Course**: A default course is included for quick start.
- **Dynamic Course Loading**: Courses are now loaded dynamically from the file system.

### Statistics Tracking
- **Session Summary**: View detailed session statistics, including error count, WPM, and SPM, in a dedicated statistics window.
- **Persistent Statistics**: Save session statistics locally for future reference.

## Improvements
- **UI Enhancements**:
  - Improved text rendering with background highlights and drop shadow effects for better readability.
  - Enhanced user feedback during typing sessions.
- **Codebase Refactoring**:
  - Optimized `TypingViewModel` for better maintainability and performance.
  - Improved separation of concerns by delegating course handling to `CourseHandler`.

## Bug Fixes
- Fixed an issue where incorrect positions were not cleared after generating a new sentence.
- Resolved a crash when attempting to edit or delete the default course.
- Addressed minor UI glitches in the statistics window.
- Corrected WPM and SPM calculations to ensure accuracy.

## Notes
This release marks a major milestone in TypoMayhem's development, focusing on usability, performance, and extensibility. We hope you enjoy the new features and improvements in v4.0.0!


# Release Notes - TypoMayhem v5.0.0

## New Features
- **Typing Evaluation Enhancements**: Introduced advanced typing evaluation logic for improved accuracy and feedback.
- **Navigation Buttons**: Added the `NavButton` class for better usability and consistent styling.

## Improvements
- **UI Modernization**: Updated themes in `Generic.xaml` to deliver a more polished and cohesive user interface.
- **Performance Optimization**: Enhanced the efficiency of `EvaluationHandler` and `CourseHandler` for faster data processing and reduced latency.

## Bug Fixes
- Fixed a crash issue in the `TypingEvaluation` page during rapid input scenarios.
- Resolved incorrect data display in the `UserStatistic` model within the statistics window.
- Addressed layout inconsistencies in `MainWindow.xaml` and `StatisticsWindow.xaml`.



