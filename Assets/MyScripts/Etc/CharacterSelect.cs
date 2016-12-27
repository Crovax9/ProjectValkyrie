using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CharacterSelect : MonoBehaviour {

    public List<GameObject> playerCharacter = new List<GameObject>();

    public void SelectedCharacter(string characterName)
    {
        playerCharacter.ForEach(Model => Model.SetActive(false));
        var selectedObject = playerCharacter.Where(charName => charName.transform.name == characterName).SingleOrDefault();
        selectedObject.SetActive(true);
    }

    void SelectedCharacterInfo()
    {

    }
}
