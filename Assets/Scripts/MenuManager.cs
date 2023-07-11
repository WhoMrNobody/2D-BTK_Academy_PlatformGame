using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class MenuManager : MonoBehaviour
    {

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}

