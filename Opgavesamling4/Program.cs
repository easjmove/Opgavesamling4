//Opgave 4.1 Beep
Alarm();
AlarmAntal(5);

void Alarm()
{
    for (int i = 0; i < 3; i++)
    {
        Console.Beep();
    }
}


void AlarmAntal(int antal)
{
    for (int i = 1; i <= antal; i++)//starter på 1 for at kunne gange med 500
    {
        Console.Beep(i * 500, i * 200);
        Thread.Sleep(500);
    }
}

//Opgave 4.2 Tomme tønder
double Volume(double height, double radius)
{
    return Math.PI * Math.Pow(radius, 2) * height;
}

double SurfaceArea(double height, double radius)
{
    return 2 * Math.PI * Math.Pow(radius, 2) + 2 * Math.PI * radius * height;
}
Console.WriteLine("Indtast Højde:");
double height = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Indtast Radius:");
double radius = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"En cylinder på {height} høj og {radius} radius");
Console.WriteLine($"Volume: {Volume(height, radius)}");
Console.WriteLine($"SurfaceArea: {SurfaceArea(height, radius)}");

//Opgave 4.3 Rumskibet
double PopulationIncrease(double population, double percentIncrease)
{
    for (int i = 0; i < 30; i++)
    {
        population *= 1 + (percentIncrease / 100);
    }
    return population;
}

Console.WriteLine("Indtast befolkningstal:");
double population = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Indtast tilvækst i procent:");
double percentIncrease = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"Beregner befolkningstal for 30år for {population} med en tilvækst på {percentIncrease}");
Console.WriteLine(PopulationIncrease(population, percentIncrease));

//Opgave 4.4 Kodeord
char[] lowerCase = ['a', 'b', 'c', 'd'];
char[] upperCase = ['A', 'B', 'C', 'D'];
char[] numbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
char[] specials = ['@', '.', '!', '"', '#'];
List<char> allChars = new List<char>(lowerCase);
allChars.AddRange(upperCase);
allChars.AddRange(numbers);
allChars.AddRange(specials);

string GeneratePassword(int length)
{
    if (length < 12)
    {
        throw new ArgumentException("Hov skal mindst være 12!!!");
    }
    Random rand = new Random();
    char[] password = new char[length];

    password[0] += lowerCase[rand.Next(0, lowerCase.Length)];
    password[1] += upperCase[rand.Next(0, upperCase.Length)];
    password[2] += numbers[rand.Next(0, numbers.Length)];
    password[3] += specials[rand.Next(0, specials.Length)];
    for (int i = 4; i < length; i++)
    {
        password[i] += allChars[rand.Next(0, allChars.Count)];
    }
    rand.Shuffle<char>(password);
    string result = "";
    foreach (char pass in password)
    {
        result += pass;
    }
    return result;
}

Console.WriteLine("Generer password:");
Console.WriteLine(GeneratePassword(12));

//Opgave 4.5 DNA
int HammingDistance(string dna1, string dna2)
{
    int distance = 0;
    for (int i = 0; i < dna1.Length; i++)
    {
        if (dna1[i] != dna2[i])
        {
            distance++;
        }
    }
    return distance;
}

Console.WriteLine("Indtast første DNA string");
string dna1 = Console.ReadLine();
Console.WriteLine("Indtast anden DNA string");
string dna2 = Console.ReadLine();
Console.WriteLine($"Hamming distance: {HammingDistance(dna1, dna2)}");

// Opgave 4.6 Heksen
char[] hexNumbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F'];
void CheckHex(string hexString)
{
    if (hexString.Length != 7)
    {
        Console.WriteLine("Strengen skal være 7 lang, # + 6 hextal");
        return;
    }
    if (hexString[0] != '#')
    {
        Console.WriteLine("Første tegn skal være #");
        return;
    }
    hexString = hexString.ToUpper();
    for (int i = 1; i < hexString.Length; i++)
    {
        if (!hexNumbers.Contains(hexString[i]))
        {
            Console.WriteLine($"Forkert karakter på plads {i}, stopper med at tjekke!");
            return;
        }
    }
    Console.WriteLine("Valid Hex Farve");
}
Console.WriteLine("Indtast Hex farve for check:");
string testHex = Console.ReadLine();
CheckHex(testHex);

//Opgave 4.7
bool CheckForMin12(string password)
{
    return password.Length >= 12;
}

bool CheckForMax64(string password)
{
    return password.Length <= 64;
}

bool ContainsUpperCase(string password)
{
    return password.ContainsAny(upperCase);
}

bool ContainsLowerCase(string password)
{
    return password.ContainsAny(lowerCase);
}

bool ContainsNumber(string password)
{
    return password.ContainsAny(numbers);
}

bool ContainsCharacter(string password)
{
    return password.ContainsAny(specials);
}

bool FourInARow(string password)
{
    char lastChar = char.MinValue;
    int inARow = 0;
    for (int i = 0; i < password.Length; i++)
    {
        if (password[i] == lastChar)
        {
            inARow++;
            if (inARow >= 3)
            {
                return false;
            }
        }
        else
        {
            lastChar = password[i];
            inARow = 0;
        }
    }
    return true;
}

bool IncreasingNumber(string password)
{
    int expectedNumber = int.MinValue;
    int inARow = 0;
    for (int i = 0; i < password.Length; i++)
    {
        if (numbers.Contains(password[i]))
        {
            int currentNumber = int.Parse("" + password[i]);
            if (currentNumber == expectedNumber)
            {
                inARow++;
                if (inARow >= 3)
                {
                    return false;
                }
            }
            else
            {
                inARow = 0;
            }
            expectedNumber = currentNumber + 1;
        }
        else
        {
            expectedNumber = int.MinValue;
            inARow = 0;
        }
    }
    return true;
}

bool CheckWeak(string password)
{
    if (CheckForMin12(password) && CheckForMax64(password)
        && ContainsLowerCase(password) && ContainsNumber(password)
        && ContainsUpperCase(password) && ContainsCharacter(password))
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool CheckStrong(string password)
{
    if (CheckWeak(password) && FourInARow(password) && IncreasingNumber(password))
    {
        return true;
    }
    else
    {
        return false;
    }
}

Console.WriteLine("Indtast Password:");
string password = Console.ReadLine();
if (CheckStrong(password))
{
    Console.WriteLine("Password er stærkt!");
}
else if (CheckWeak(password))
{
    Console.WriteLine("Password er godkendt, men svagt!");
}
else
{
    Console.WriteLine("Password er ikke godkendt!");
}
