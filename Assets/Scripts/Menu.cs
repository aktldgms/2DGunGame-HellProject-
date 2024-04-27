using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nickname;
    private void Start()
    {
        if(!PlayerPrefs.HasKey("nickname"))
        {
            PlayerPrefs.SetString("nickname", "");
        }
    }
    public void PlayScene()
    {
        if(nickname.text != "")
        {
            PlayerPrefs.SetString("nickname", nickname.text);
            SceneManager.LoadScene(1);
        }
    }
}
