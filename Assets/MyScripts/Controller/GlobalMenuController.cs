using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GlobalMenuController : MonoBehaviour {

	void Start () {
        tweenPosition = GetComponentsInChildren<TweenPosition>().ToList();
	}

	public void MenuTween()
	{
        foreach (TweenPosition tween in tweenPosition)
        {
			if (!MenuOnOff) {
				tween.PlayForward ();
			} else {
				tween.PlayReverse ();
			}
		}
		MenuOnOff = !MenuOnOff;
	}

	public void GlobalMenuSelect(GameObject _obj)
	{
        Singleton.Instance.SceneChange (_obj.name);
	}

	private List<TweenPosition> tweenPosition;
	private bool MenuOnOff = false;
}
