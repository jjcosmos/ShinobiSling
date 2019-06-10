using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelTracker
{
    public static bool Level0Complete;
    public static bool Level1Complete;
    public static bool Level2Complete;
    public static bool Level3Complete;
    public static bool Level4Complete;
    public static bool Level5Complete;


    public static bool Level0Marathon;
    public static bool Level1Marathon;
    public static bool Level2Marathon;
    public static bool Level3Marathon;
    public static bool Level4Marathon;
    public static bool Level5Marathon;


    public static bool GetAllComplete()
    {
        if(Level0Complete && Level1Complete && Level2Complete && Level3Complete && Level4Complete && Level5Complete)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool GetAllMarathon()
    {
        if (Level0Marathon && Level1Marathon && Level2Marathon && Level3Marathon && Level4Marathon && Level5Marathon)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
