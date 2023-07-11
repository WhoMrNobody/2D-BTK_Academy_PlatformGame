using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TigerForge;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class DataManager : MonoBehaviour
    {
        public int TotalShootBullet;
        public int TotalKilledZombie;
        int _shootBullet;
        int _killedZombie;

        GameObject _shootText;
        GameObject _killedZombieText;

        EasyFileSave _myFile;
        public int EnemyKilled
        {
            get { return _killedZombie; }
            set { _killedZombie = value;
                GameObject.Find("EnemyKilledText").GetComponent<TMP_Text>().text = "ZOMBIE KILLED : " + _killedZombie.ToString();
            }
        }

        public int ShootBullet
        {
            get { return _shootBullet; }
            set { _shootBullet = value;
                GameObject.Find("ShootText").GetComponent<TMP_Text>().text = "SHOOT BULLET : " + _shootBullet.ToString();
            }
        }

        public static DataManager Instance;
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                StartingProcess();
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        void StartingProcess()
        {
            _myFile = new EasyFileSave();
            LoadData();
        }

        public void SaveData()
        {
            TotalKilledZombie += _killedZombie;
            TotalShootBullet += _shootBullet;

            _myFile.Add("TotalKilledZombie", TotalKilledZombie);
            _myFile.Add("TotalShootBullet", TotalShootBullet);

            _myFile.Save();
        }

        public void LoadData()
        {
            if (_myFile.Load())
            {
                TotalShootBullet = _myFile.GetInt("TotalShootBullet");
                TotalKilledZombie = _myFile.GetInt("TotalKilledZombie");
            }
        }

    }

}
