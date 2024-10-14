using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TMP_Text playerNameText;

    void Start()
    {
        playerNameText.text = PlayerCharacterData.playerName;
    }
}
