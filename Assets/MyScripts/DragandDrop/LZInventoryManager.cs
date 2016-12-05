using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LZInventoryManager : MonoBehaviour {

	public UIAtlas atlas;
	public List<CharacterSlot> nonselectedSlots;
	public List<CharacterSlot> selectedSlots;
	

	void Start()
	{
		Invoke("SetupEquiptSlot", 0.5f);
	}

	public void SetupEquiptSlot()
	{
        Singleton.Instance.characterData.ForEach((name, index) => nonselectedSlots[index].SetSlot(name.GetName()));
		SortSetSlot ();
	}


	public void SortSetSlot()
	{
        selectedSlots.ForEach(initialization => initialization.SetSlot());
        nonselectedSlots.ForEach(initialization => initialization.SetSlot());

        Singleton.Instance.selectedCharacterList.ForEach((name, index) => selectedSlots[index].SetSlot(name.GetName()));
        Singleton.Instance.selectedCharacterList.Clear();

        Singleton.Instance.nonselectedCharacterList.ForEach((name, index) => nonselectedSlots[index].SetSlot(name.GetName()));
        Singleton.Instance.nonselectedCharacterList.Clear();
	}
}
