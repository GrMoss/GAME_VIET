using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DictionaryData 
{
    public int Level; 
    public bool Status;

    public DictionaryData(int level, bool status)
    {
        Level = level;
        Status = status;
    }

}
