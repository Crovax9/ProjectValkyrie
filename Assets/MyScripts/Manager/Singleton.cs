using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

//Singleton SceneManager
public class Singleton{

    public List<CharDataClass> characterData = new List<CharDataClass>();
    public List<CharDataClass> selectedCharacterList;
    public List<CharDataClass> nonselectedCharacterList;

    public readonly int selectedCharacte = 1;
    public readonly int nonSelectedCharacter = 0;

    public List<StageDataClass> stageData = new List<StageDataClass>();


	//Singleton
    private static Singleton _instance = null;

    public static Singleton Instance
	{
		get{
            if (_instance == null) _instance = new Singleton();
			return _instance;
		}
	}

	public void SceneChange(string menuName)
	{
		Debug.Log (menuName);
        System.GC.Collect();
		SceneManager.LoadScene (menuName);
	}

    public string GetSceneInfo()
    {
        return SceneManager.GetActiveScene().name;
    }

	public void SetCharacter(int characterIndex, int value)
	{
        characterData [characterIndex].SelectedInfo = value;
        SortByDistanceThenByHealthPoint();
	}

    public void SetCharacter()
    {
        SortByDistanceThenByHealthPoint();
    }
        
    private void SortByDistanceThenByHealthPoint()
    {
        var orderedCharacterInfo = characterData.OrderBy(x => x.GetSetRange).ThenByDescending(x => x.GetHealthPoint());
        selectedCharacterList = orderedCharacterInfo.Where(obj => obj.SelectedInfo == selectedCharacte).ToList();
        nonselectedCharacterList = orderedCharacterInfo.Where(obj => obj.SelectedInfo == nonSelectedCharacter).ToList();
    }
}
