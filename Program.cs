/*Phase 1:
    console.writeline a greeting
    create class to store team member name, courage factor, and skill level
    write line (x3) to get the team member details from the user and store it for later use
    writeline the class properties
*/
/*Phase 2: 
    Create a list to store team members
    create team member creation logic in a while loop
        when valid team member is created, add to list
        break loop when blank name is entered 
    Display team member amount using .Count on team member list
    foreach on list of team members to display each members info
*/
/* Phase 3:
    Initialize bank difficulty int as 100
    Remove logic for displaying team member information and count
    Sum skill levels of all team members and store
    Compare skill level sum to bank difficulty
        If Skill Level is greater, print victory message
        Else, print failure message
*/
/* Phase 4:
    initialize Random int luck variable between -10 and 10
    add luck to bank difficulty
    display team combined skill level
    display bank difficulty
*/
/*Phase 5:
    Prompt user number of times the program should run
    Adjust program to run through loop the amount of times the user has selected
    Run scenario multiple times using a loop
*/
/*Phase 6:
    Prompt user for bank's difficulty level
    Initialize variables for tracking wins and losses at 0
    In each scenario loop
        If win, increment win count
        If loss, increment loss count
    Display wins and losses
*/

bool keepLooping = true;
List<TeamMember> teamMembers = new List<TeamMember>();


Console.WriteLine("Plan Your Heist!");


int bankLevel = 0;
Console.WriteLine("\nHow difficult is the bank?");
while (bankLevel == 0)
{
    Console.WriteLine("Difficulty:");
    try
    {
        bankLevel = int.Parse(Console.ReadLine().Trim());
    }
    catch (FormatException)
    {
        Console.WriteLine("Please input an integer!");
    }
}


while (keepLooping)
{
    bool validResult = false;
    TeamMember teamMember = new TeamMember();

    Console.WriteLine("What is the team member's name?");
    string response = Console.ReadLine();
    if (response == "")
    {
        break;
    }
    teamMember.Name = response;
    while (!validResult)
    {
        try
        {
            Console.WriteLine("With a maximum of 50, what is the team member's skill level?");
            int userResponse = int.Parse(Console.ReadLine());
            if (userResponse >= 1 && userResponse <= 50)
            {
                teamMember.SkillLevel = userResponse;
                validResult = true;
            }
            else
            {
                Console.WriteLine("That was not a valid response. Please enter a number between 1 and 50");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("That was not a valid response. Your response needs to be a number, dumbdumb.");
        }
    }
    validResult = false;
    while (!validResult)
    {
        try
        {
            Console.WriteLine("On a scale of 0.0 to 2.0, what is the team member's courage factor?");
            decimal userResponse = decimal.Parse(Console.ReadLine());
            if (userResponse >= 0.0M && userResponse <= 2.0M)
            {
                teamMember.CourageFactor = userResponse;
                validResult = true;
            }
            else
            {
                Console.WriteLine("That response was not within range. Please enter a number between 0.0 and 2.0");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("That was not a valid response. Please enter a decimal. Stupid.");
        }
    }
    teamMembers.Add(teamMember);
}

Console.WriteLine("Please choose number of times to run heist!");
int trialRunCount = 0;
while(trialRunCount == 0)
{
    try
    {
        trialRunCount = int.Parse(Console.ReadLine());
    }
    catch(FormatException)
    {
        Console.WriteLine("Please enter an integer");
    }
}

Random random = new Random();
int TeamSkillLevel = teamMembers.Sum(teamMember => teamMember.SkillLevel);
int winCount = 0;
int lossCount = 0;

for(int i = 0; i < trialRunCount; i++)
{
    int luckValue = random.Next(-10, 11);
    int BankDifficulty = bankLevel + luckValue;

    Console.WriteLine($"Trial run #:{i + 1}");
    Console.WriteLine($"Total Team Skill Level: {TeamSkillLevel}");
    Console.WriteLine($"Bank Difficulty: {BankDifficulty}\n");

    if (TeamSkillLevel > BankDifficulty)
    {
        Console.WriteLine("You got your hands on monopoly money, great job!\n");
        winCount++;
    }
    else
    {
        Console.WriteLine("Not even your mother loves you now, failures.\n");
        lossCount++;
    }
}

Console.WriteLine($"Total Wins: {winCount}");
Console.WriteLine($"Total Losses: {lossCount}");