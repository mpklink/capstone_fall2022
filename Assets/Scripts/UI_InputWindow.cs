using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_InputWindow : MonoBehaviour
{
    [SerializeField] private TMP_InputField field;
    private GlobalVariables globalVar;

    void Start()
    {
        globalVar = FindObjectOfType<GlobalVariables>();
    }

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        
        field.characterLimit = 2;
        field.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar("0123456789", addedChar);
        };
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void FloorSelect()
    {
        Debug.Log(field.text);
        int num = int.Parse(field.text);
        globalVar.current[2] = num;
        Debug.Log(globalVar.current[2]);
        SceneManager.LoadScene("LibraryFloor");
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        }
        else
        {
            return '\0';
        }
    }
}
