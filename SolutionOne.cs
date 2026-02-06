using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    // Declare variables and get user input
    public string characterName;        // Character name
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
    
    
    /* My initial idea was to use a dictionary for the class and die types. I decided to go with a series of if else statements instead.
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
        // Input validation functions
        CheckClassInput();
        CheckRaceInput();
        CheckLevelInput();
        CheckConInput();

        CalculateHP();
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
        int die = 6;            // The hit die type
        int dieAverage = 4;     // The expected value of each die type, rounded up
        int CONscore = 1;       // The constitution modifier
        int raceBonus = 0;      // The race bonus for dwarves, orcs, and goliaths
        int toughBonus = 0;     // Bonuses for the tough and stout feats
        int stoutBonus = 0;
        int finalHP = 0;        // The final calculated HP value

        // First, get the type of die used based on the player's class. Use preset average values and round everything up to whole numbers.
        if (characterClassSelect == "Sorcerer" || characterClassSelect == "Wizard")
        {
            die = 6;
            dieAverage = 4;     // Real average is 3.5
        }
        else if (characterClassSelect == "Artificer" || characterClassSelect == "Bard" || characterClassSelect == "Cleric" || characterClassSelect == "Druid" || characterClassSelect == "Monk" || characterClassSelect == "Rogue" || characterClassSelect == "Warlock")
        {
            die = 8;
            dieAverage = 5;     // Real average is 4.5
        }
        else if (characterClassSelect == "Fighter" || characterClassSelect == "Ranger" || characterClassSelect == "Paladin")
        {
            die = 10;
            dieAverage = 6;     // Real average is 5.5
        }
        else if (characterClassSelect == "Barbarian")
        {
            die = 12;
            dieAverage = 7;     // Real average is 6.5
        }

        // Next, get the constitution modifier
        if (con == 1)
            CONscore = -5;
        else if (con == 2 || con == 3)
            CONscore = -4;
        else if (con == 4 || con == 5)
            CONscore = -3;
        else if (con == 6 || con == 7)
            CONscore = -2;
        else if (con == 8 || con == 9)
            CONscore = -1;
        else if (con == 10 || con == 11)
            CONscore = 0;
        else if (con == 12 || con == 13)
            CONscore = 1;
        else if (con == 14 || con == 15)
            CONscore = 2;
        else if (con == 16 || con == 17)
            CONscore = 3;
        else if (con == 18 || con == 19)
            CONscore = 4;
        else if (con == 20 || con == 21)
            CONscore = 5;
        else if (con == 22 || con == 23)
            CONscore = 6;
        else if (con == 24 || con == 25)
            CONscore = 7;
        else if (con == 26 || con == 27)
            CONscore = 8;
        else if (con == 28 || con == 29)
            CONscore = 9;
        else if (con == 30)
            CONscore = 10;

        // Next, add any extra modifiers, like feats or race bonuses.
        if (raceSelect == "Dwarf")
        {
            raceBonus = 2;
        }
        else if (raceSelect == "Orc" || raceSelect == "Goliath")
        {
            raceBonus = 1;
        }

        if (hasTough)
        {
            toughBonus = 2;
        }

        if (hasStout)
        {
            stoutBonus = 1;
        }

        // Roll the die or use the averages, based on the character level. 
        for (int i = 1; i <= level; i++)
        {
            int tempHP; // Temporarily store the calculated value for the current loop iteration, and then add it to the final HP value

            if (HpAveraged)
            {
                tempHP = dieAverage + CONscore + raceBonus + toughBonus + stoutBonus;
                finalHP += tempHP;
            }
            else if (!HpAveraged)
            {
                tempHP = Random.Range(1, die + 1) + CONscore + raceBonus + toughBonus + stoutBonus;
                finalHP += tempHP;
            }
        }

        // Display the results
        Debug.Log("Your character, " + characterName + " the " + raceSelect + " " + characterClassSelect + ", has " + finalHP + " HP.");
    }
}
