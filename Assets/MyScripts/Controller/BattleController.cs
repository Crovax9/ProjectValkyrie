using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BattleController : MonoBehaviour {

    public List<GameObject> StagePrefab = new List<GameObject>();
    public List<GameObject> CharPrefab = new List<GameObject>();
    public List<Transform> PosTransform = new List<Transform>();


	void Start () {
        var StageInfo = Singleton.Instance.stageData.FindIndex (Info => Info.SelectStage == 1);
		GameObject.Instantiate (StagePrefab [StageInfo]);
        //CharPrefab.Where(c => Singleton.Instance.selectedCharacterList.Any(selectedChar => selectedChar.GetName() == c.transform.name))
        //    .ForEach((c, index) => Instantiate(c, PosTransform[index].position, PosTransform[index].localRotation).name = c.name);
        //CharPrefab.ForEach((c, index) => Singleton.Instance.selectedCharacterList[index])
        CharPrefab.Where(c => Singleton.Instance.selectedCharacterList.Any(selectedChar => selectedChar.GetName() == c.transform.name))
            .ForEach((c, index) => c.transform.localPosition = PosTransform[index].localPosition).ForEach(c => c.SetActive(true));
	}
}