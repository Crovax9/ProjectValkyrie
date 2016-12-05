using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageDataClass{

    private readonly string mStageName;
    private readonly List<string> mEnemy = new List<string>();
    private int mSelectStage;

    public StageDataClass(string stageName, List<string> enemyData, int selectStage)
    {
        mStageName = stageName;
        mEnemy = enemyData;
        mSelectStage = selectStage;
    }

    public string GetStageName() { return mStageName; }
    public List<string> GetEnemy() { return mEnemy; }

    public int SelectStage
    {
        get
        {
            return mSelectStage;
        }
        set
        {
            mSelectStage = value;
        }
    }
}

public class StageInfoParse : MonoBehaviour {

	void Start () {
        if (Singleton.Instance.stageData.Count == 0)
        {
            List<Dictionary<string,object>> data = CSVReader.Read("Deck");

            for(var i=0; i< data.Count; i++){
                List<string> enemyName = new List<string>();
                enemyName.Add((string)data[i]["Char1"]);
                enemyName.Add((string)data[i]["Char2"]);
                enemyName.Add((string)data[i]["Char3"]);
                enemyName.Add((string)data[i]["Char4"]);
                enemyName.Add((string)data[i]["Char5"]);
                StageDataClass Data = new StageDataClass((string)data[i]["StageName"], enemyName, (int)data[i]["SetStage"]);
                Singleton.Instance.stageData.Add (Data);
            }
        }
	}
}
