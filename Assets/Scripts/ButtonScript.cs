using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //public variable to reference the button text - set this up in the Unity editor
    public TMP_Text buttonText;

    public void ButtonMethod()
    {
        //buttonText.text = "The text has changed";
        SceneManager.LoadScene("Demo");
    }
}