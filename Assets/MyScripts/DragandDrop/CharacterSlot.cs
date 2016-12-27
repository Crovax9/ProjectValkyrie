using UnityEngine;
using System.Collections;

public class CharacterSlot : MonoBehaviour {

	UISprite icon;

    private const string selectedCharacter = "SeletedCharacter";
    private const string nonselectedCharacter = "Character";
    const string quest = "Quest";

	string spriteName; //current item

	static string mDraggedItem; // now dragged item

	public void SetSlot(string selectedUIName=null)
	{
		spriteName = selectedUIName;

        if (icon == null)
		{
			icon = transform.GetChild(0).GetComponent<UISprite>();
		}

		if(selectedUIName == null)
		{
			icon.enabled = false;
            //icon.transform.parent.GetComponent<UISprite>().enabled = false;
		}
		else
		{
			icon.enabled = true;
            //icon.transform.parent.GetComponent<UISprite>().enabled = true;
            icon.spriteName = selectedUIName;
            if (icon.transform.parent.name == selectedCharacter)
            {
                int index = Singleton.Instance.characterData.FindIndex (i => i.GetName() == icon.spriteName);
                Singleton.Instance.SetCharacter (index, Singleton.Instance.selectedCharacte);
			}
            else if (icon.transform.parent.name == nonselectedCharacter)
            {
                int index = Singleton.Instance.characterData.FindIndex (i => i.GetName() == icon.spriteName);
                Singleton.Instance.SetCharacter (index, Singleton.Instance.nonSelectedCharacter);
			}
		}
	}
	public void OnClick()
	{
        if (Singleton.Instance.GetSceneInfo() == quest)
        {
            Calculate();   
        }
        else
        {
            ModelSetup();
        }
	}

#if (UNITY_ANDROID||UNITY_IPHONE) && !UNITY_EDITOR
	void OnPress(bool isDown)
	{
		if(isDown)
			Calculate();
	}
	
	void OnDrop (GameObject go)
	{
		Calculate();
	}
#endif

	void Calculate()
	{
		if( mDraggedItem != null )
		{
			// cursor - exist / slot - none		==> drop(equipt)
			if(spriteName == null)
			{
				spriteName = mDraggedItem;
				mDraggedItem = null;
				
				SetSlot(spriteName);
                GameObject.Find("LZInvertoryManager").GetComponent<LZInventoryManager>().SortSetSlot();
				UpdateCursor();

			}
			// cursor - exist / slot - exist	==> replace
			else
			{
				string tempItem = mDraggedItem;
				mDraggedItem = spriteName;
				spriteName = tempItem;
				
				SetSlot(spriteName);
				UpdateCursor();
			}
		}
		// cursor - none / slot - exist		==> pickup
        else if(spriteName != null)
		{
			mDraggedItem = spriteName;
			spriteName = null;
			
			SetSlot();
			UpdateCursor();
		}
	}

    void ModelSetup()
    {
        var SlotCharacterName = transform.GetChild(0).GetComponent<UISprite>().spriteName;
        GameObject.Find("Character").GetComponent<CharacterSelect>().SelectedCharacter(SlotCharacterName);
    }

	void UpdateCursor ()
	{
		if (mDraggedItem != null )
		{
			LZCursor.Set(mDraggedItem);
		}
		else
		{
			LZCursor.Clear();
		}
	}
}
