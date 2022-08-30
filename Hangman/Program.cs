//Written by Filip Hellgren & Max Ganerud

List<char> availableChars;
List<char> usedChars;

string chosenWord;
string wordDisplay;

char GetCharacterInput() {
    char input;
    bool isValidChar = false;
    do {
        System.Console.WriteLine("\nThe available characters are: \n" + String.Join(", ", availableChars));
        Console.Write("Please input a character: ");
        input = Char.ToUpper(Console.ReadKey().KeyChar);

        Console.WriteLine();

        isValidChar = availableChars.Contains(input);
        if (!isValidChar) {
            Console.WriteLine("Invalid character!");
            
        }
    } while (!isValidChar);
    availableChars.Remove(input);
    usedChars.Add(input);

    return input;
}

string GetStringInput(string prompt, string[] choices=null) {
    string input = null;
    bool isValidInput = choices == null;
    do {
        Console.Write(prompt);
        input = Console.ReadLine().ToUpper();

        if (choices != null) {
            isValidInput = choices.Contains(input);
            if (!isValidInput) {
                System.Console.WriteLine("Your input is invalid!");
            }
        }
    } while (!isValidInput);
    return input;
}

void ReplaceCharacters(char character) {
    int startAt = 0;
    int indexOfChar;
    do {
        indexOfChar = chosenWord.IndexOf(character, startAt);
        startAt = Math.Max(0, indexOfChar) + 1;

        if (indexOfChar != -1) {
            wordDisplay = wordDisplay.Remove(indexOfChar * 2, 1).Insert(indexOfChar * 2, character.ToString());
        }
    } while(indexOfChar != -1);
}

void CreateWordDisplay() {
    wordDisplay = "";
    foreach (char character in chosenWord) 
    {
        if (character == ' ') {
            wordDisplay += "- ";
        } else if(availableChars.Contains(character)) {
            wordDisplay += "_ ";
        } else {
            wordDisplay += character + " ";
        }
    }
}

void PrintGameState() {
    System.Console.Clear();
    System.Console.WriteLine(wordDisplay);
}

void StartGame() {
    availableChars = new List<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    usedChars = new List<char>();
    
    string prompt = "Choose the word to be guessed! : ";
    chosenWord = GetStringInput(prompt);
    CreateWordDisplay();

    while (true) {
        PrintGameState();
        char character = GetCharacterInput();
        ReplaceCharacters(character);
    }
}

while (true) {
    StartGame();

    string prompt = "Keep playing [Y:N]: ";
    string[] choices = {"Y", "N"};

    string keepPlaying = GetStringInput(prompt,  choices);
    if (keepPlaying == "N") {
        break;
    }
}