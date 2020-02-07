using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
namespace QFramework.PaokuDemo
{
    public class GameStart : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.LoadLevelScene(SceneType.MainMenu);
        }
    }
}
