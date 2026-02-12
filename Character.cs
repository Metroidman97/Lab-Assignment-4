using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int level;
    public string characterClass;
    public int conScore;
    public string race;
    public bool hasTough;
    public bool hasStout;
    public bool hPAveraged;

    private int conModifier;
    private Character classSelection;
    private Character raceSelection;

    private int finalHP;

    public Character()
    {

    }
    public Character(string name, int level, string characterClass, int conScore, string race)
    {
        this.name = name;
        this.level = level;
        this.characterClass = characterClass;
        this.conScore = conScore;
        this.race = race;
    }
    /*
    public Character(string name, int level, string characterClass, int conScore, string race, bool hasTough)
    {
        this.name = name;
        this.level = level;
        this.characterClass = characterClass;
        this.conScore = conScore;
        this.race = race;
        this.hasTough = hasTough;
    }

    public Character(string name, int level, string characterClass, int conScore, string race, bool hasTough, bool hasStout)
    {
        this.name = name;
        this.level = level;
        this.characterClass = characterClass;
        this.conScore = conScore;
        this.race = race;
        this.hasTough = hasTough;
        this.hasStout = hasStout;
    }
    
    public Character(string name, int level, string characterClass, int conScore, string race, bool hasTough, bool hPAveraged)
    {
        this.name = name;
        this.level = level;
        this.characterClass = characterClass;
        this.conScore = conScore;
        this.race = race;
        this.hasTough = hasTough;
        this.hPAveraged = hPAveraged;
    }

    public Character(string name, int level, string characterClass, int conScore, string race, bool hasStout, bool hPAveraged)
    {
        this.name = name;
        this.level = level;
        this.characterClass = characterClass;
        this.conScore = conScore;
        this.race = race;
        this.hasStout = hasStout;
        this.hPAveraged = hPAveraged;
    }
    */
    public Character(string name, int level, string characterClass, int conScore, string race, bool hasTough, bool hasStout, bool hPAveraged)
    {
        this.name = name;
        this.level = level;
        this.characterClass = characterClass;
        this.conScore = conScore;
        this.race = race;
        this.hasTough = hasTough;
        this.hasStout = hasStout;
        this.hPAveraged = hPAveraged;
    }

    public void CalculateHP()
    {
        GetConModifier();
        GetCharacterClass();
        GetCharacterRace();
    }
    private void GetConModifier()
    {
        if (conScore == 1)
            conModifier = -5;
        else if (conScore == 2 || conScore == 3)
            conModifier = -4;
        else if (conScore == 4 || conScore == 5)
            conModifier = -3;
        else if (conScore == 6 || conScore == 7)
            conModifier = -2;
        else if (conScore == 8 || conScore == 9)
            conModifier = -1;
        else if (conScore == 10 || conScore == 11)
            conModifier = 0;
        else if (conScore == 12 || conScore == 13)
            conModifier = 1;
        else if (conScore == 14 || conScore == 15)
            conModifier = 2;
        else if (conScore == 16 || conScore == 17)
            conModifier = 3;
        else if (conScore == 18 || conScore == 19)
            conModifier = 4;
        else if (conScore == 20 || conScore == 21)
            conModifier = 5;
        else if (conScore == 22 || conScore == 23)
            conModifier = 6;
        else if (conScore == 24 || conScore == 25)
            conModifier = 7;
        else if (conScore == 26 || conScore == 27)
            conModifier = 8;
        else if (conScore == 28 || conScore == 29)
            conModifier = 9;
        else if (conScore == 30)
            conModifier = 10;
    }

    private void GetCharacterClass()
    {
        classSelection = (Character)Activator.CreateInstance(Type.GetType(characterClass));
    }

    private void GetCharacterRace()
    {
        raceSelection = (Character)Activator.CreateInstance(Type.GetType(race));
    }
}
