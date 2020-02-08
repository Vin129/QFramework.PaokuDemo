using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.PaokuDemo
{
    public class DontDestory : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
