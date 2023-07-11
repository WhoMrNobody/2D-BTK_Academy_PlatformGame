using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BTK_Academy_DigitalGame_Course.Manager;

namespace BTK_Academy_DigitalGame_Course.Data
{
    public class BringScores : MonoBehaviour
    {
        [SerializeField] TMP_Text _bestZombieKilledText;
        [SerializeField] TMP_Text _bestShootFireballText;
        void Start()
        {
            BringScoreTexts();
        }

        void BringScoreTexts()
        {
            DataManager.Instance.LoadData();

            _bestShootFireballText.text = "Shoot Fireballs : " + DataManager.Instance.ShootBullet.ToString();
            _bestZombieKilledText.text = "Killed Zombie : " + DataManager.Instance.EnemyKilled.ToString();
        }
    }

}
