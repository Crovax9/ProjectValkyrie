using UnityEngine;
using System.Collections;
using System.Linq;

public class DistanceSearch : MonoBehaviour {

	private const string enemyTag = "enemyAim";
	private const string playerTag = "Player";
	public GameObject target;
	public bool SearchedFlag = false;

	void Update () {
        if (target != null)
        {
            Debug.DrawLine(transform.position, target.transform.position,
                Color.yellow);
        }
        else
        {
            SearchedFlag = false;
            getClosestObject(isSearchingEnemy: transform.CompareTag(playerTag));
        }
	}

    float GetSqrMagnitude(GameObject targetObject) { return (targetObject.transform.position - this.transform.position).sqrMagnitude; }

    void getClosestObject(bool isSearchingEnemy)
    {
        var targetTag = isSearchingEnemy ? enemyTag : playerTag;

        var targetObjects = GameObject.FindGameObjectsWithTag(targetTag).ToList();//TargetObject検索
        var playerCharacter = Singleton.Instance.characterData.Where(CharName => CharName.GetName() == transform.name).SingleOrDefault();//PlayerCharacterの時自分の情報参照

        var myAttackRange = isSearchingEnemy ? playerCharacter.GetRange() : 50; //敵の場合、射程距離は50で固定、PlayerCharacterは自分のデータから射程距離を参照

        var orderedObjectsByDistance = targetObjects.OrderBy(obj => GetSqrMagnitude(obj));//TargetObjectとの距離順番でSort
        var closestObject = orderedObjectsByDistance.Where(obj => GetSqrMagnitude(obj) < myAttackRange).FirstOrDefault();//上でSortしたことの中でAttackRangeの中にあるものSortして一つ目のこと選択

        target = closestObject;
        if (target != null) SearchedFlag = true;
    }
}
