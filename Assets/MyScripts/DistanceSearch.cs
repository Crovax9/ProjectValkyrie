using UnityEngine;
using System.Collections;
using System.Linq;

public class DistanceSearch : MonoBehaviour {

	private const string enemyTag = "enemyAim";
	private const string playerTag = "Player";
	public GameObject target;
	public bool SearchedFlag = false;
    public CharDataClass playerStatus;
    public EnemyDataClass enemyStatus;

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
        if (isSearchingEnemy)
        {
            SetDistance();
        }
        else
        {
            int index = Singleton.Instance.enemyData.FindIndex(c => c.GetName() == this.transform.name);
            enemyStatus = Singleton.Instance.enemyData[index];
        }
        var targetTag = isSearchingEnemy ? enemyTag : playerTag;

        var targetObjects = GameObject.FindGameObjectsWithTag(targetTag).ToList();//TargetObject検索

        var myAttackRange = isSearchingEnemy ? playerStatus.GetSetRange : enemyStatus.GetSetRange; //敵の場合、射程距離は50で固定、PlayerCharacterは自分のデータから射程距離を参照

        var orderedObjectsByDistance = targetObjects.OrderBy(obj => GetSqrMagnitude(obj));//TargetObjectとの距離順番でSort
        var closestObject = orderedObjectsByDistance.Where(obj => GetSqrMagnitude(obj) < myAttackRange).FirstOrDefault();//上でSortしたことの中でAttackRangeの中にあるものSortして一つ目のこと選択

        target = closestObject;
        if (target != null) SearchedFlag = true;
    }

    void SetDistance()
    {
        string name = this.transform.name;
        int index = Singleton.Instance.selectedCharacterList.FindIndex(c => c.GetName() == name);
        playerStatus = Singleton.Instance.selectedCharacterList[index];
        switch (index)
        {
            case 0:
                playerStatus.GetSetRange = 20.0f;
                break;

            case 1:
                playerStatus.GetSetRange = 40.0f;
                break;

            case 2:
                playerStatus.GetSetRange = 60.0f;
                break;

            case 3:
                playerStatus.GetSetRange = 80.0f;
                break;

            case 4:
                playerStatus.GetSetRange = 100.0f;
                break;

            default:

                break;
        }
    }

    public void GetDamage(int Attack)
    {
        Debug.Log("SendMessage");
        /*switch(this.transform.tag)
        {
            case enemyTag:

                break;

            case playerTag:

                break;

        }*/
    }
}
