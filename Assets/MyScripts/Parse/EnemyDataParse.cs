using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyDataClass
{
    private readonly string mName;
    private readonly int mAttack;
    private int mHealthPoint;
    private float mRange;
    private int mSelectedInfo;

    public EnemyDataClass(string name, int attack, int healthPoint, float range, int selectedInfo)
    {
        mName = name;
        mAttack = attack;
        mHealthPoint = healthPoint;
        mRange = range;
        mSelectedInfo = selectedInfo;
    }

    public string GetName() { return mName; }
    public int GetAttack(){ return mAttack; }
    //public int GetHealthPoint() { return mHealthPoint; }

    public int GetSetHealthPoint
    {
        get
        {
            return mHealthPoint;
        }
        set
        {
            mHealthPoint = value;   
        }
    }
    public float GetSetRange
    { 
        get
        {
            return mRange;
        }
        set
        {
            mRange = value;
        }
    }
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

public class EnemyDataParse : MonoBehaviour {

    void Start () {
        if (Singleton.Instance.enemyData.Count == 0)
        {
            List<Dictionary<string,object>> data = CSVReader.Read("EnemyDataTable");
            for(var i=0; i< data.Count; i++)
            {
                EnemyDataClass Data = new EnemyDataClass((string)data [i] ["Name"], (int)data [i] ["Attack"], (int)data [i] ["HP"], Convert.ToSingle(data[i]["Range"]), (int)data[i]["StageInfo"]);
                Singleton.Instance.enemyData.Add (Data);
            }
        }
    }
}