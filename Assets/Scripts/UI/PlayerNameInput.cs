using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    private string inputName = null; 

    private void Update()
    {
        inputName = inputField.GetComponent<TMP_InputField>().text;
    }

    public void SaveTextToPlayerPrefab()
    {
        if (inputName.Length <= 0)
        {
            Debug.Log("플레이어 이름 오류");
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", inputName);
            SceneManager.LoadScene("MainScene");
        }
    }
}
