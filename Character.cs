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

    protected int finalHP;

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
    /*
    public void CalculateHP()
    {
        GetCharacterClass();
        GetCharacterRace();

        for (int i = 1; i <= level; i++)
        {
            int tempHP;

            if (hPAveraged)
            {
                tempHP = classSelection.dieType + raceSelection.hPBonus;
                finalHP += tempHP;
            }
        }

        Debug.Log("Final HP: " + finalHP + ", Die type: " + classSelection.dieType + ", Race bonus: " + raceSelection.hPBonus);
    }
    */
    protected int GetConModifier()
    {
        if (conScore == 1)
            return -5;
        else if (conScore == 2 || conScore == 3)
            return -4;
        else if (conScore == 4 || conScore == 5)
            return -3;
        else if (conScore == 6 || conScore == 7)
            return -2;
        else if (conScore == 8 || conScore == 9)
            return -1;
        else if (conScore == 10 || conScore == 11)
            return 0;
        else if (conScore == 12 || conScore == 13)
            return 1;
        else if (conScore == 14 || conScore == 15)
            return 2;
        else if (conScore == 16 || conScore == 17)
            return 3;
        else if (conScore == 18 || conScore == 19)
            return 4;
        else if (conScore == 20 || conScore == 21)
            return 5;
        else if (conScore == 22 || conScore == 23)
            return 6;
        else if (conScore == 24 || conScore == 25)
            return 7;
        else if (conScore == 26 || conScore == 27)
            return 8;
        else if (conScore == 28 || conScore == 29)
            return 9;
        else if (conScore == 30)
            return 10;
        else
            return 0;
    }
    /*
    private void GetCharacterClass()
    {
        //var classSelection = (Character)Activator.CreateInstance(Type.GetType(characterClass));
        
       switch (characterClass)
       {
           case "Artificer":
               classSelection = new Artificer();
                   break;
       }
       
        //classSelection = CharacterFactory.Create(characterClass);
    }

    private void GetCharacterRace()
    {
        //raceSelection = (Character)Activator.CreateInstance(Type.GetType(race));
        //raceSelection = RaceFactory.Create(race);
    }
    */
    protected int GetToughBonus()
    {
        if (hasTough)
            return 2;
        else
            return 0;
    }

    protected int GetStoutBonus()
    {
        if (hasStout)
            return 1;
        else
            return 0;
    }

    protected int GetRaceBonus()
    {
        switch (race.ToLower())
        {
            case "dwarf":
                return 2;
            case "ork":
                return 1;
            case "goliath":
                return 1;
            default:
                return 0;
        }
    }
}
