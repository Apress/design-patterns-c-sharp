# Errata for *Design Patterns in C# : A Hands-on Guide with Real-World Examples*

**Chapter 10 Flyweight Pattern**
On **page 135** [Typo]:
 
default case should be as follows:
default:
throw new Exception("Robot Factory can create only **small** and **large** type robots");

**Chapter 10 Flyweight Pattern**
On **page 136** [Typo]:
 
Please remove the unwanted line:
//System.out.println("\nDistinct Robot objects created till
now= "+ NumOfDistinctRobots);

**Chapter 10 Flyweight Pattern**
On **page 140** [Typo]:
 
 Replace the word "If" with "Is".
2. **Is** there any impact because of multithreading?

**Chapter 15 Strategy(Ploicy) Pattern**
On **page 204** [Typo]:
 
The ShowChoice() method body of Context class should be:
public void ShowChoice()
{
 choice.**My**Choice();
}

**Chapter 20 State Pattern**
On **page 281** [sample if-block change]:
 
To avoid multiple if-else blocks, for simplicity, we consider that the TV is in "Off" state now. So, please update the sample code as below:
class TV
{
//Some code before
public void PressOnButton()
{
if(currentState==OFF )
{
Console.WriteLine("You pressed On button. Going from Off to
OnState");
}
if(currentState==**ON** )
{
Console.WriteLine("You pressed **On** button. TV is already in On
state");
}
else
{
Console.WriteLine("You pressed Mute button. TV is already in Off
state, so Mute operation will not work.");
}
//Some code after
}

**Chapter 20 State Pattern**
On **page 277** [Unwanted comment]:
Please ignore the comment line:
//get;set;//Not working as expected

**Chapter 20 State Pattern**
On **page 274** [Unwanted comment]:
Please ignore the comment line below or update it as:
//Initially we'll start from Off state **in this implementation**

