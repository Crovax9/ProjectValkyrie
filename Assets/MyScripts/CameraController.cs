using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = player.transform.FindChild(Singleton.Instance.selectedCharacterList[0].GetName()).gameObject;
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.position = player.transform.position + offset;
        }
	}

    public void GetFollowPlayer()
    {
        var target = GameObject.Find("PlayerCharacter").transform.FindChild(Singleton.Instance.selectedCharacterList[0].GetName()).gameObject;
        player = target;
        offset = transform.position - player.transform.position;
    }
}
