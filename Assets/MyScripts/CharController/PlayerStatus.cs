using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerStatus : MonoBehaviour {

    public CharDataClass battleStatus;

	void Start () {
        string name = this.transform.name;
        battleStatus = Singleton.Instance.selectedCharacterList.Where(c => c.GetName() == name).ElementAtOrDefault(0);
        Debug.Log(battleStatus.GetName());
	}
}
