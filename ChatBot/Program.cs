using System;
using System.Media;
using System.Speech.Synthesis;
using System.Threading;

namespace ChatBot
{
    class Program
    {
        
        static string userName;

        static void Main(string[] args)
        {
            
            // Logo
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
>>=====================================================================================================================================================<<
||                                                                                                                                                     ||
||  ________       ___    ___  ________   _______    ________   ________   _______    ________   ___  ___   ________   ___   _________     ___    ___  ||
|| |\   ____\     |\  \  /  /||\   __  \ |\  ___ \  |\   __  \ |\   ____\ |\  ___ \  |\   ____\ |\  \|\  \ |\   __  \ |\  \ |\___   ___\  |\  \  /  /| ||
|| \ \  \___|     \ \  \/  / /\ \  \|\ /_\ \   __/| \ \  \|\  \\ \  \___|_\ \   __/| \ \  \___| \ \  \\\  \\ \  \|\  \\ \  \\|___ \  \_|  \ \  \/  / / ||
||  \ \  \         \ \    / /  \ \   __  \\ \  \_|/__\ \   _  _\\ \_____  \\ \  \_|/__\ \  \     \ \  \\\  \\ \   _  _\\ \  \    \ \  \    \ \    / /  ||
||   \ \  \____     \/  /  /    \ \  \|\  \\ \  \_|\ \\ \  \\  \|\|____|\  \\ \  \_|\ \\ \  \____ \ \  \\\  \\ \  \\  \|\ \  \    \ \  \    \/  /  /   ||
||    \ \_______\ __/  / /       \ \_______\\ \_______\\ \__\\ _\  ____\_\  \\ \_______\\ \_______\\ \_______\\ \__\\ _\ \ \__\    \ \__\ __/  / /     ||
||     \|_______||\___/ /         \|_______| \|_______| \|__|\|__||\_________\\|_______| \|_______| \|_______| \|__|\|__| \|__|     \|__||\___/ /      ||
||               \|___|/                                          \|_________|                                                           \|___|/       ||
||  ________   ___  ___   ________   _________   ________   ________   _________                                                                       ||
|| |\   ____\ |\  \|\  \ |\   __  \ |\___   ___\|\   __  \ |\   __  \ |\___   ___\                                                                     ||
|| \ \  \___| \ \  \\\  \\ \  \|\  \\|___ \  \_|\ \  \|\ /_\ \  \|\  \\|___ \  \_|                                                                     ||
||  \ \  \     \ \   __  \\ \   __  \    \ \  \  \ \   __  \\ \  \\\  \    \ \  \                                                                      ||
||   \ \  \____ \ \  \ \  \\ \  \ \  \    \ \  \  \ \  \|\  \\ \  \\\  \    \ \  \                                                                     ||
||    \ \_______\\ \__\ \__\\ \__\ \__\    \ \__\  \ \_______\\ \_______\    \ \__\                                                                    ||
||     \|_______| \|__|\|__| \|__|\|__|     \|__|   \|_______| \|_______|     \|__|                                                                    ||
||                                                                                                                                                     ||
>>=====================================================================================================================================================<<");
            Console.ResetColor();
            Console.WriteLine();

            // Voice greeting
            try
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\Sithobile Mkhabela\OneDrive\Documentos\IIE MSA\2025\Semester 1\PROG6221\PROG6221_POE_PART1_ST10448774\ChatBot\bin\Debug\VoiceAudio.wav");
                player.Load();
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ Could not play greeting audio: " + ex.Message);
                Console.ResetColor();
            }

            //Welcome message
            Console.WriteLine("\n<<<<<<<<<<  Welcome to the Cybersecurity Chatbot!  >>>>>>>>>>");
            Console.WriteLine();
            
            Console.Write("\nEnter your username: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            userName = Console.ReadLine().Trim() ?? "User";
            Console.ResetColor();
            TypeWrite("Nice to meet you, " + userName + "!", 30);
            Console.WriteLine();
            
            StartChat();

        }

        static void StartChat()
        {
            Console.WriteLine("\nYou can ask me questions like:");
            Console.WriteLine("- How are you?");
            Console.WriteLine("- What's your purpose?");
            Console.WriteLine("- Tell me about phishing");
            Console.WriteLine("- What is password safety?");
            Console.WriteLine("- What is safe browsing?");
            Console.WriteLine("Type 'exit' or 'bye' to leave.\n");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>\n" + "\n Start the chat:\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(userName + ": ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("I didn't catch that. Can you rephrase?");
                    continue;
                }

                input = input.ToLower(); 

                if (input == "exit" || input == "bye")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeWrite("<<<<<<<<<<  Goodbye, " + userName + "! Stay safe online.  >>>>>>>>>>", 40);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(new string('=', 154));
                    Console.ResetColor();
                    break;
                }
                
                RespondToInput(input);
                
            }
        }

        static void RespondToInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            if (input.Contains("hey") || input.Contains("hello"))
            {
                Console.WriteLine("Hey there!\n");
                
            }
            else if (input.Contains("how are you"))
            {
                Console.WriteLine("I'm as good as a chatbot can be. How are you?\n");
                
            }
            else if (input.Contains("good") || input.Contains("great") || input.Contains("amazing") || input.Contains("fine"))
            {
                Console.WriteLine("That's good to know. How can I make your day better?\n");

            }
            else if (input.Contains("not good") || input.Contains("bad") || input.Contains("sad") || input.Contains("angry"))
            {
                Console.WriteLine("I'm sorry to hear that. How can I make your day better?\n");
                
            }
            else if (input.Contains("your purpose") || input.Contains("what do you do") || input.Contains("help"))
            {
                Console.WriteLine("I'm here to help you stay safe online. You can ask me about cybersecurity.\n");
                
            }
            else if ((input.Contains("what can") && input.Contains("ask")) || input.Contains("topics"))
            {
                Console.WriteLine("You can ask me about phishing, password safety, or safe browsing.\n");
                
            }
            else if ((input.Contains("define") || input.Contains("what is") || input.Contains("about")) && input.Contains("cybersecurity"))
            {
                Console.WriteLine("Cybersecurity is the practice of protecting systems, networks, and data from digital attacks.\n");
                
            }
            else if ((input.Contains("define") || input.Contains("what is") || input.Contains("about")) && input.Contains("phishing"))
            {
                Console.WriteLine("Phishing is a cyberattack where attackers impersonate trusted entities to trick people into revealing sensitive information.\n");
                
            }
            else if ((input.Contains("how") || input.Contains("safe") || input.Contains("precautions")) && input.Contains("phishing"))
            {
                Console.WriteLine("Safety precautions against phishing include:");
                Console.WriteLine("- Don't share personal info with unknown sources");
                Console.WriteLine("- Use strong, unique passwords");
                Console.WriteLine("- Enable multi-factor authentication");
                Console.WriteLine("- Avoid clicking on suspicious links or email attachments\n");
               
            }
            else if (input.Contains("types") || input.Contains("examples") && input.Contains("phishing"))
            {
                Console.WriteLine("Examples of phishing include:");
                Console.WriteLine("- Email phishing");
                Console.WriteLine("- Spear phishing");
                Console.WriteLine("- Smishing (SMS phishing)");
                Console.WriteLine("- Vishing (voice phishing)");
                Console.WriteLine("- Clone phishing\n");
                
            }
            else if ((input.Contains("define") || input.Contains("what is")) && input.Contains("password safety"))
            {
                Console.WriteLine("Password safety means using good habits to protect your accounts and sensitive information.\n");
                
            }
            else if ((input.Contains("practice") || (input.Contains("practices") || input.Contains("how") || input.Contains("precautions")) && input.Contains("password"))
            {
                Console.WriteLine("Password safety practices include:");
                Console.WriteLine("- Use strong, complex passwords");
                Console.WriteLine("- Avoid writing down or sharing passwords");
                Console.WriteLine("- Use a password manager\n");
                
            }
            else if ((input.Contains("what is") || input.Contains("safe browsing")) && input.Contains("safe"))
            {
                Console.WriteLine("Safe browsing is using tools and habits that protect you from online threats.\n");
                
            }
            else if ((input.Contains("practice") || input.Contains("practices") && input.Contains("safe browsing"))
            {
                Console.WriteLine("Safe browsing practices include:");
                Console.WriteLine("- Keep antivirus software updated");
                Console.WriteLine("- Check that website URLs are correct");
                Console.WriteLine("- Use HTTPS-secured sites");
                Console.WriteLine("- Don't click suspicious links or ads\n");
                
            }
            else if (input.Contains("tools") && input.Contains("safe browsing"))
            {
                Console.WriteLine("Tools used for safe browsing include:");
                Console.WriteLine("- Google Safe Browsing (used by Chrome and Firefox)");
                Console.WriteLine("- Microsoft Defender SmartScreen (used by Edge)");
                Console.WriteLine("- Antivirus software with web protection features\n");
                
            }
            else
            {
                Console.WriteLine("Hmm... I didn’t quite understand that. Can you rephrase?");
                
            }

            Console.ResetColor();
        }

        static void TypeWrite(string text, int delayMs)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
    }
}
