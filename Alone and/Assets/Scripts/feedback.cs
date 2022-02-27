using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback : MonoBehaviour
{
    public void SendEmail()

    {

        string email = "anigamingofficial320@gmail.com";

        string subject = MyEscapeURL("Bug Report.");

        string body = MyEscapeURL("Hi,");


        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);

    }

    string MyEscapeURL(string url)

    {

        return WWW.EscapeURL(url).Replace("+", "%20");

    }
    
}
