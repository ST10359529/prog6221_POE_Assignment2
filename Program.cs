using System;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities.DisplayAsciiArt();
            Utilities.PlayVoiceGreeting();

            Console.WriteLine("Please enter your name:");
            string userName = Console.ReadLine();
            Console.WriteLine($"\nHello, {userName}! Welcome to the \u001b[1mCYBER BOT\u001b[0m. I'm here to help you stay safe online.\n");

            ChatBox chatBot = new ChatBox();
            chatBot.StartConversation();
        }
    }
}

// 1. National Cyber Security Centre (NCSC). Password Guidance. https://www.ncsc.gov.uk/collection/passwords [Accessed 23 Apr. 2025].

// 2. Cybersecurity & Infrastructure Security Agency (CISA). Phishing Guidance. https://www.cisa.gov/news-events/news/avoiding-social-engineering-and-phishing-attacks [Accessed 23 Apr. 2025].

// 3. Norton. How to Protect Your Privacy Online. https://us.norton.com/blog/privacy [Accessed 23 Apr. 2025].

// 4. torjk.com, n.d.Text to ASCII Art Generator(TAAG). [online]. Available at: https://patorjk.com/software/taag/#p=display&f=Varsity&t=CyberGater [Accessed 23 Apr. 2025].

// 5. Google Safety Center. Safe Browsing Tips. https://safety.google/intl/en_uk/staying-safe-online/ [Accessed 26 May 2025].

// 6. Lecture series. (2025). GitHub Actions Workflow via Visual Studio [Online video]. Available at: https://www.youtube.com/watch?v=zbNmx75Cfs0 [Accessed 23 Apr. 2025].

// 8. StaySafeOnline.org. Online Safety Basics. https://staysafeonline.org/stay-safe-online/online-safety-basics/ [Accessed 26 May 2025].

// 9. Avast. How to Spot a Phishing Email. https://www.avast.com/c-phishing [Accessed 26 May 2025].

// 10. Mozilla Foundation. Privacy Tips. https://foundation.mozilla.org/en/privacynotincluded/tips/ [Accessed 26 May 2025].

// 11.GeeksforGeeks, 2023. C++ Pointers. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/cpp-pointers/ [Accessed 26 May 2025].

