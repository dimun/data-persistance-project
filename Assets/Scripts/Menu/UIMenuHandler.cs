using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuHandler : MonoBehaviour
{
    public TMP_InputField nameInput;

    private void Start()
    {
        nameInput.onEndEdit.AddListener(SetName);
    }
    public void SetName(string name)
    {
        GameManager.Instance.Name = name;
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
