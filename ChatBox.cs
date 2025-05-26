using System;
using System.Collections.Generic;
using System.Threading;

namespace CybersecurityAwarenessChatbot
{
    class ChatBox
    {
        // responses for fixed user inputs
        public Dictionary<string, string> StaticResponses { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "hello", "Hello!" },
            { "how are you", "I'm good, but I'm just a ChatBox. I don't have feelings, but I'm here to help you stay safe online!" },
            { "purpose", "My purpose is to educate you about cybersecurity and help you avoid online threats and hacking." },
            { "what is your purpose", "My purpose is to educate you about cybersecurity and help you avoid online threats and hacking." }
        };

        
        private readonly Dictionary<string, Action<string>> dynamicResponses;

        // Stores topics the user has shown interest in
        private readonly List<string> userInterests = new List<string>();

        public ChatBox()
        {
            // response actions for different cybersecurity topics
            dynamicResponses = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "password", (sentiment) => GiveRandomPasswordTip(sentiment) },
                { "phishing", (sentiment) => GiveRandomPhishingTip(sentiment) },
                { "privacy", (sentiment) => GiveRandomPrivacyTip(sentiment) },
                { "scam", (sentiment) => GiveRandomScamTip(sentiment) },
                { "scamming", (sentiment) => GiveRandomScamTip(sentiment) },
                { "safe browsing", (sentiment) => GiveRandomSafeBrowsingTip(sentiment) },
                { "browsing", (sentiment) => GiveRandomSafeBrowsingTip(sentiment) }
            };
        }

        // Starts the chatbot interaction loop
        public void StartConversation()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                TypeOut("What would you like to know about? (Type 'exit' to quit)", 30);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine().ToLower(); 
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    PrintChatbotResponse("I didn't quite understand that. Could you rephrase?");
                }
                else if (userInput == "exit")
                {
                    PrintChatbotResponse("Thank you for using the CYBER BOT. Stay safe online!");
                    break;
                }
                else if (userInput == "recall")
                {
                    RecallUserInterests(); // Shows remembered interests
                }
                else
                {
                    RespondToUser(userInput); 
                }
            }
        }

        
        private void RespondToUser(string input)
        {
            
            foreach (var pair in StaticResponses)
            {
                if (input.Contains(pair.Key))
                {
                    PrintChatbotResponse(pair.Value);
                    return;
                }
            }

            // Detects user sentiment from input
            string detectedSentiment = DetectSentiment(input);

            // Checks for keyword and respond accordingly
            foreach (var pair in dynamicResponses)
            {
                if (input.Contains(pair.Key))
                {
                    // Store the interest if not already remembered
                    if (!userInterests.Contains(pair.Key))
                    {
                        userInterests.Add(pair.Key);
                        PrintChatbotResponse($"Great! I'll remember that you're interested in {pair.Key}.");
                    }

                    
                    pair.Value.Invoke(detectedSentiment);
                    return;
                }
            }

            // Fallback response if nothing matches
            PrintChatbotResponse("I didn't quite understand that. Could you rephrase or ask something else about cybersecurity?");
        }

        // Simple keyword-based sentiment detection
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried"))
                return "worried";
            else if (input.Contains("frustrated"))
                return "frustrated";
            else if (input.Contains("curious"))
                return "curious";
            else if (input.Contains("nervous"))
                return "nervous";
            else if (input.Contains("scared"))
                return "scared";

            return "neutral";
        }

        // Displays remembered user interests
        private void RecallUserInterests()
        {
            if (userInterests.Count == 0)
            {
                PrintChatbotResponse("I don't remember anything yet.");
            }
            else
            {
                PrintChatbotResponse("Here's what I remember you're interested in:");
                foreach (var interest in userInterests)
                {
                    Console.WriteLine($"- {interest}");
                }
            }
        }

       
        private void PrintChatbotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeOut("Chatbot: " + message, 30);
            Console.ResetColor();
        }

        // Outputs text slowly for effect
        private void TypeOut(string message, int delay)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        //  Password tips
        private void GiveRandomPasswordTip(string sentiment)
        {
            List<string> passwordTips = new List<string>
            {
                "Don’t reuse passwords across different accounts.",
                "Use a passphrase instead of a single word. It’s longer and harder to crack.",
                "Enable two-factor authentication wherever possible. Use Microsoft Authenticator, Google Authenticator, etc.",
                "Avoid using easily guessed passwords like '123456', 'password', or your name.",
                "Use a password manager to generate and store strong, unique passwords.",
                "Update your passwords regularly, especially for sensitive accounts.",
                "Don’t share your passwords with anyone—even trusted friends and family."
            };

            PrintSentimentIntro(sentiment, "password");
            PrintChatbotResponse(GetRandomTip(passwordTips));
        }

        // Phishing tips
        private void GiveRandomPhishingTip(string sentiment)
        {
            List<string> phishingTips = new List<string>
            {
                "Enable multi-factor authentication to add an extra layer of security.",
                "Report suspicious emails to your IT department or email provider.",
                "Never download attachments from unknown or unexpected sources.",
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Check the sender's email address carefully—slight misspellings can be a red flag.",
                "Avoid clicking on suspicious links. Hover over them to see the actual URL.",
                "Look for poor grammar and urgent language in messages—it's a common phishing tactic."
            };

            PrintSentimentIntro(sentiment, "phishing");
            PrintChatbotResponse(GetRandomTip(phishingTips));
        }

        //  Privacy tips
        private void GiveRandomPrivacyTip(string sentiment)
        {
            List<string> privacyTips = new List<string>
            {
                "Limit the amount of personal information you share on social media.",
                "Review app permissions regularly and disable ones you don't need.",
                "Use a VPN when browsing on public Wi-Fi.",
                "Clear your browser history and cookies regularly.",
                "Disable location tracking in apps that don't require it.",
                "Turn off microphone and camera access for apps you're not actively using.",
                "Keep your operating system and apps updated to protect against vulnerabilities."
            };

            PrintSentimentIntro(sentiment, "privacy");
            PrintChatbotResponse(GetRandomTip(privacyTips));
        }

        // Scam/scamming tips
        private void GiveRandomScamTip(string sentiment)
        {
            List<string> scamTips = new List<string>
            {
                "Watch out for deals that seem too good to be true—they probably are.",
                "Never share personal or financial information with unverified parties.",
                "If you're being hurried into a decision, it's most likely a scam.",
                "Research unfamiliar companies or individuals before doing business with them.",
                "Make secure payments—never pay by wire transfer or gift card.",
                "Verify suspicious messages by contacting the individual or business directly through a trusted method.",
                "Stay up to date with your antivirus and software to help block recognized scams."
            };

            PrintSentimentIntro(sentiment, "scamming");
            PrintChatbotResponse(GetRandomTip(scamTips));
        }

        //  Safe browsing tips
        private void GiveRandomSafeBrowsingTip(string sentiment)
        {
            List<string> browsingTips = new List<string>
            {
                "Always check for HTTPS in the URL before entering personal data.",
                "Keep your browser up to date to ensure you're protected from known vulnerabilities.",
                "Use an ad-blocker to prevent malicious ads from redirecting you to harmful sites.",
                "Don’t download files from untrusted websites.",
                "Use private browsing mode on shared devices.",
                "Avoid logging into sensitive accounts from public computers or unsecured Wi-Fi.",
                "Use strong antivirus software that includes web protection features."
            };

            PrintSentimentIntro(sentiment, "safe browsing");
            PrintChatbotResponse(GetRandomTip(browsingTips));
        }

        // Randomly selects a tip from the provided list
        private string GetRandomTip(List<string> tips)
        {
            Random rand = new Random();
            return tips[rand.Next(tips.Count)];
        }

        
        private void PrintSentimentIntro(string sentiment, string topic)
        {
            switch (sentiment)
            {
                case "worried":
                    PrintChatbotResponse($"It's completely understandable to feel worried about {topic}. Let me help you feel more secure.");
                    break;
                case "frustrated":
                    PrintChatbotResponse($"Frustration is common when dealing with {topic}. You're not alone, and I’m here to guide you.");
                    break;
                case "curious":
                    PrintChatbotResponse($"Curiosity is great! Let's explore more about {topic} together.");
                    break;
                default:
                   
                    if (userInterests.Contains(topic))
                        PrintChatbotResponse($"Since you're interested in {topic}, here's a tip: ");
                    break;
            }
        }
    }
}
