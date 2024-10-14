using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public InputField nameInput;
    public Button startButton;
    void Start()
    {
        startButton.gameObject.SetActive(false);

        nameInput.onValueChanged.AddListener(OnNameInputChanged);
    }
    public void OnStartButtonClicked()
    {
        PlayerCharacterData.playerName = nameInput.text;
        SceneManager.LoadScene("MainScene"); // ���� ������ �̵�
    }
    void OnNameInputChanged(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            startButton.gameObject.SetActive(false);
        }
        else
        {
            startButton.gameObject.SetActive(true);
        }
    }
}
