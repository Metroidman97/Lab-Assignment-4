using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    // Input variables, no actual user input
    string name;
    int level;
    string characterClass;
    int conScore;
    string race;
    bool hasTough;
    bool hasStout;
    bool hPAveraged;
    Artificer newCharacter;             // Even though this automaticaly instantiates an Artificer class, if you do this with any other valid class it should still work

    // Start is called before the first frame update
    void Start()
    {
        name = "Joe";
        level = 15;
        characterClass = "Artificer";   // This variable doesn't actually do anything
        conScore = 18;
        race = "Dwarf";
        hasTough = true;
        hasStout = false;
        hPAveraged = true;

        newCharacter = new Artificer(name, level, characterClass, conScore, race, hasTough, hasStout, hPAveraged);
        newCharacter.CalculateHP();     // Output should be "Name: Joe, Final HP: 195"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
