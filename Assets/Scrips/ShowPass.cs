using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;


public class ShowPass : MonoBehaviour
{
    //[SerializeField] private InputField userPassword;
    [SerializeField] private TMP_InputField userPassword;

    //public void ShowUserPassword()
    //{
    //    if (userPassword.contentType == InputField.ContentType.Password)
    //    {
    //        userPassword.contentType = InputField.ContentType.Standard;
    //    }
    //    else
    //    {
    //        userPassword.contentType = InputField.ContentType.Password;
    //    }
    //    userPassword.ForceLabelUpdate();
    //}


    public void ShowUserPassword()
    {
        if (userPassword.contentType == TMP_InputField.ContentType.Password)
        {
            userPassword.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            userPassword.contentType = TMP_InputField.ContentType.Password;
        }
        userPassword.ForceLabelUpdate();
    }
}
