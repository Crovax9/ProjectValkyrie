using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class BattleStatus
{
    public int _HP;
    public int _Attack;
    public int _MagicAttack;

}

public class PlayerStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string[] _name = this.transform.name.Split("("[0]);
        PlayerCharBattleStatus._HP = Singleton.Instance.characterData.Where(CName => CName.GetName() == _name[0]).Select(HP => HP.GetHealthPoint()).SingleOrDefault();
        PlayerCharBattleStatus._Attack = Singleton.Instance.characterData.Where(CName => CName.GetName() == _name[0]).Select(Attack => Attack.GetAttack()).SingleOrDefault();
        PlayerCharBattleStatus._MagicAttack = Singleton.Instance.characterData.Where(CName => CName.GetName() == _name[0]).Select(MagicAttack => MagicAttack.GetMagicAttack()).SingleOrDefault();
        Debug.Log(_name[0]);
	}


    BattleStatus PlayerCharBattleStatus = new BattleStatus();
}
