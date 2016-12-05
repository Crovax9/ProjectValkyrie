using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StageUIController : MonoBehaviour {

	public void StageSelected(GameObject selectStage)
	{
		QuestBoard.SetActive (true);
        GameObject.Find("StageName").GetComponent<UILabel>().text = selectStage.name;
        StageUISet(selectStage.name);
        SelectStageIndex = Singleton.Instance.stageData.FindIndex(i => i.GetStageName() == selectStage.name);
        Singleton.Instance.stageData [SelectStageIndex].SelectStage = 1;
	}

	public void CharacterSelectButtonClick()
	{
		QuestBoard.SetActive (false);
		CharacterBoard.SetActive (true);
	}

	public void QuestBackButtonClick()
	{
		QuestBoard.SetActive (false);
        Singleton.Instance.stageData [SelectStageIndex].SelectStage = 0;
	}

	public void CharacterBackButtonClick()
	{
		CharacterBoard.SetActive (false);
		QuestBoard.SetActive (true);
	}

	public void BattleStartButtonClick(GameObject stage)
	{
        if (SelectedCharacterCheck())
        {
            Singleton.Instance.SceneChange(stage.name);
		}
	}

	private bool SelectedCharacterCheck()
	{
        return Singleton.Instance.characterData.Any(characterInfo => characterInfo.SelectedInfo == 1);
	}


	public void StageUISet(string stageName)
	{
        Singleton.Instance.stageData.Where(stageInfo => stageInfo.GetStageName() == stageName).ForEach(stageInfo =>
            {
                stageInfo.GetEnemy().ForEach((enemyName, index) =>
                    {
                        var nItem = enemyName.Equals("null") ? null : enemyName;
                        EnemySlot[index].GetComponent<CharacterSlot>().SetSlot(nItem);
                    });
            });
	}

	public GameObject QuestBoard;
	public GameObject CharacterBoard;

	private int SelectStageIndex;
	public List<GameObject> EnemySlot;
}
