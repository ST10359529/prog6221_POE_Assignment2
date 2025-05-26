using System;
using System.Media;




namespace CybersecurityAwarenessChatbot
{
    static class Utilities
    {
        public static void DisplayAsciiArt()
        {
            string asciiArt = @"
  ______  ____  ____  ______   ________  _______      ______       _     _________  ________  _______     
 .' ___  ||_  _||_  _||_   _ \ |_   __  ||_   __ \   .' ___  |     / \   |  _   _  ||_   __  ||_   __ \    
/ .'   \_|  \ \  / /    | |_) |  | |_ \_|  | |__) | / .'   \_|    / _ \  |_/ | | \_|  | |_ \_|  | |__) |   
| |          \ \/ /     |  __'.  |  _| _   |  __ /  | |   ____   / ___ \     | |      |  _| _   |  __ /    
\ `.___.'\   _|  |_    _| |__) |_| |__/ | _| |  \ \_\ `.___]  |_/ /   \ \_  _| |_    _| |__/ | _| |  \ \_  
 `.____ .'  |______|  |_______/|________||____| |___|`._____.'|____| |____||_____|  |________||____| |___| 
";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(asciiArt);
            Console.ResetColor(); // Reset to default color
        }

        public static void PlayVoiceGreeting()
        {
            try {

                using (SoundPlayer player = new SoundPlayer("ElevenLabs_2025-04-22_converted.wav"))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing greeting: " + ex.Message);
            }
        }
    }
};



