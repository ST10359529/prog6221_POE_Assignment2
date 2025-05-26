Cybersecurity Awareness Chatbot:

-Overview

This is a console-based Cybersecurity Awareness Chatbot developed in C#. Its primary purpose is to educate users about online safety by providing dynamic and static responses based on user input. The chatbot also remembers user interests to deliver a personalized experience.

-Features

Static Responses: Predefined replies for common greetings and questions.

Dynamic Responses: Topic-based tips on passwords, phishing, privacy, scams, and safe browsing.

Sentiment Detection: Recognizes emotional tone (e.g., worried, curious) and tailors responses accordingly.

Memory Feature: Remembers user interests and topics discussed for future personalization.

Technologies Used

C#

.NET Console Application

Visual Studio 2022

How to Use

Open the project in Visual Studio 2022.

Build and run the application.

Interact with the chatbot via the console.

Type relevant cybersecurity topics (e.g., "phishing", "password") to receive tips.

Use the command recall to display topics the chatbot remembers.

Type exit to end the session.

Example Commands

Hello

What is your purpose?

I'm worried about phishing

Tell me something about password security

Recall

Exit

Chatbot Personalization

The chatbot stores user interests in-memory during the session and uses this to:

Remember what topics the user has discussed.

Provide customized messages and suggestions.

Limitations

The chatbot does not use persistent storage; memory is session-based.

Sentiment analysis is basic and keyword-based.

Future Enhancements

Add persistent memory using file or database storage.

Improve sentiment analysis using NLP techniques.

Develop a GUI version using WinForms or WPF.

Author

Developed by [Your Name] for educational and awareness purposes.

License

This project is open-source and free to use for non-commercial purposes.
