using System;
using System.Collections;
using System.Collections.Generic;
using FrameworkDesign.Example;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GamePassEvent.Register(onGamePass);
    }

    private void onGamePass()
    {
        transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        GamePassEvent.unRegister(onGamePass);
    }

}
