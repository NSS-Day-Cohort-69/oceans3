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
foreach on list of team members to display each members info*/

bool keepLooping = true;
List<TeamMember> teamMembers = new List<TeamMember>();

Console.WriteLine("Plan Your Heist!");

while(keepLooping)
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


Console.WriteLine($"There {(teamMembers.Count == 1 ? $"is {teamMembers.Count} member" : $"are {teamMembers.Count} members")} on the team!");
foreach(TeamMember teamMember in teamMembers)
{
    Console.WriteLine(@$"
    Name: {teamMember.Name}
    Skill Level: {teamMember.SkillLevel}
    Courage Factor: {teamMember.CourageFactor}");
}