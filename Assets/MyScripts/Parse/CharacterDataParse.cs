using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharDataClass
{
    private readonly string mName;
    private readonly int mAttack;
    private readonly int mMagicAttack;
    private readonly int mHealthPoint;
    private readonly float mRange;
    private int mSelectedInfo;

    public CharDataClass(string name, int attack, int magicattack, int healthPoint, float range, int selectedInfo)
    {
        mName = name;
        mAttack = attack;
        mMagicAttack = magicattack;
        mHealthPoint = healthPoint;
        mRange = range;
        mSelectedInfo = selectedInfo;
    }

    public string GetName() { return mName; }
    public int GetAttack(){ return mAttack; }
    public int GetMagicAttack() { return mMagicAttack; }
    public int GetHealthPoint() { return mHealthPoint; }
    public float GetRange(){ return mRange; }
    public int SelectedInfo
    {
        get
        {
            return mSelectedInfo;
        }
        set
        {
            mSelectedInfo = value;
        }
    }
}

public class CharacterDataParse : MonoBehaviour {

	void Start () {
        if (Singleton.Instance.characterData.Count == 0)
        {
            List<Dictionary<string,object>> data = CSVReader.Read("PlayerCharacterTable");

            for(var i=0; i< data.Count; i++)
            {
                CharDataClass Data = new CharDataClass((string)data [i] ["Name"], (int)data [i] ["Attack"], (int)data [i] ["MagicAttack"], (int)data [i] ["HP"], Convert.ToSingle(data[i]["Range"]), (int)data[i]["DeckInfo"]);
                Singleton.Instance.characterData.Add (Data);
            }
        }
	}
}
