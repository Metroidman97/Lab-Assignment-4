using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    // Declare variables and get user input
    public string name;                 // Character name
    public int level;                   // Character level. Can be from 1 to 20
    // Character class options
    [SerializeField]
    public string[] characterClass = { "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock" };
    public string characterClassSelect; // Class selection
    public int con;                     // Character CON score. Can be from 1 to 30.
    // Charcter race options
    [SerializeField]
    public string[] race = { "Asimar", "Dragonborn", "Dwarf", "Elf", "Gnome", "Goliath", "Halfling", "Human", "Orc", "Tiefling"};
    public string raceSelect;           // Character race input
    public bool hasTough;               // If the character has the tought feat
    public bool hasStout;               // If the character has the stout feat
    public bool HpAveraged;             // If the player wants their HP averaged or rolled. True is averaged, false is rolled
    
    
    /* My initial idea was to use a dictionary for the class and die types. I decided to go with a switch statement instead.
    private Dictionary<string, int> characterClass = new Dictionary<string, int>()
        {
        { "Artificer", 8 },     // d8
        { "Barbarian", 12 },    // d12
        { "Bard", 8 },          // d8
        { "Cleric", 8 },        // d8
        { "Druid", 8 },         // d8
        { "Fighter", 10 },      // d10
        { "Monk", 8 },          // d8
        { "Ranger", 10 },       // d10
        { "Rogue", 8 },         // d8
        { "Paladin", 10 },      // d10
        { "Sorcerer", 6 },      // d6
        { "Wizard", 6 },        // d6
        { "Warlock", 8 }        // d8
        };
    */

    // Start is called before the first frame update
    void Start()
    {
        CheckClassInput();
        CheckRaceInput();
        CheckLevelInput();
        CheckConInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckClassInput()
    {
        bool match = false; // If the input matches anything in the array
        for (int i = 0; i < characterClass.Length; i++)
        { 
            if (characterClassSelect == characterClass[i])
            {
                match = true; // A proper match has been found
            }
        }

        if (!match)
        {
            Debug.LogError("Class name is invalid");
        }
    }

    void CheckRaceInput()
    {
        bool match = false; // If the input matches anything in the array
        for (int i = 0; i < race.Length; i++)
        {
            if (raceSelect == race[i])
            {
                match = true; // A proper match has been found
            }
        }

        if (!match)
        {
            Debug.LogError("Race name is invalid");
        }
    }

    void CheckLevelInput()
    {
        if (level > 20 || level < 1)
        {
            Debug.LogError("Level value is invalid");
        }
    }

    void CheckConInput()
    {
        if (con > 30 || con < 0)
        {
            Debug.LogError("CON value is invalid");
        }
    }

    void CalculateHP()
    {
        // First, get the type of die used based on the player's class

        // Next, get the constitution modifier

        // Next, roll the die or use the averages, based on the character level. Use preset average values and round everything up to whole numbers.

        // Add any extra modifiers, like feats or race bonuses. 

        // Display the results
    }
}
