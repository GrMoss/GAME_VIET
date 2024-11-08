using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharaterData : ScriptableObject
{
    public List<Charater> charaters;

    public Charater GetCharater(int gender)
    {
        return charaters.Find(x => x.gender == gender);
    }
}
