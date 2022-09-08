using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CharacterSelector : MonoBehaviour
{
    
    public static CharacterSelector Instance;
    
    
    public GameObject[] playerObjects;
    public string[] names;
    public TextMeshProUGUI characterName;
    public int selectedCharacter = 0;
    public string gameScene = "latest gameplay scene";
    private string selectedCharacterDataName ="SelectedCharacter";

    void Awake(){
        Instance = this;
    }
    void Start()
    {
        HideAllCharacters();
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        characterName.text = PlayerPrefs.GetString("Default", names[selectedCharacter]);
        playerObjects[selectedCharacter].SetActive(true);
    }
    private void HideAllCharacters()
    {
        foreach(GameObject g in playerObjects)
        {
            g.SetActive(false);
        }
    }
    public void NextCharacter()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;

        if(selectedCharacter >= playerObjects.Length)
        {
            selectedCharacter = 0;
            
        }
        playerObjects[selectedCharacter].SetActive(true);
        characterName.text = names[selectedCharacter];
    }
    public void PreviousCharacter()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter <0)
        {
            selectedCharacter = playerObjects.Length-1;
        }
        playerObjects[selectedCharacter].SetActive(true);
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacter);
        PlayerPrefs.SetString("Default",names[selectedCharacter]);
        SceneManager.LoadScene(gameScene);
    }
}
