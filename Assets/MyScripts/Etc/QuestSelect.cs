using UnityEngine;
using System.Collections;

//MainUIでQuestButtonをClickした時のcode
public class QuestSelect : MonoBehaviour {

    private const string buttonName = "Quest";

    void OnClick()
    {
        QuestButtonSelect();
    }

    private void QuestButtonSelect()
    {
        Singleton.Instance.SceneChange(buttonName);
    }
}