using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleUIController : MonoBehaviour {

    public UIAtlas atlas;

    public List<CharacterSlot> characterUISlot;

    public List<GameObject> outComeUI; 

    void Start()
    {
        StartCoroutine("BattleStartUICoroutine");

        SetupCharacterSlot();
    }

    public void SetoutComeUI()
    {
        StartCoroutine("OutComeUICoroutine");
    }
    IEnumerator OutComeUICoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        if (GameObject.FindWithTag("Player") == null)
        {
            outComeUI[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            outComeUI[1].SetActive(false);
        }
        else if (GameObject.FindWithTag("enemyAim") == null)
        {
            outComeUI[2].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            outComeUI[2].SetActive(false);
        }
    }

    void SetupCharacterSlot()
    {
        Singleton.Instance.selectedCharacterList.ForEach((name, index) => characterUISlot[index].SetSlot(name.GetName()));
    }

    IEnumerator BattleStartUICoroutine()
    {
        outComeUI[0].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        outComeUI[0].SetActive(false);
    }
}
