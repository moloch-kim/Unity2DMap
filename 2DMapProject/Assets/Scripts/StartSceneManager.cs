using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public InputField nameInput;

    public void OnStartButtonClicked()
    {
        PlayerCharacterData.playerName = nameInput.text;
        SceneManager.LoadScene("MainScene"); // ���� ������ �̵�
    }

}
