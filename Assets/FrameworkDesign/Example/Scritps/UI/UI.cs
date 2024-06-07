using System;
using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using FrameworkDesign.Example;
using UnityEngine;

public class UI : MonoBehaviour,IController
{
    // Start is called before the first frame update
    void Awake()
    {
        this.RegisterEvent<GamePassEvent>(onGamePass);
    }

    private void onGamePass(GamePassEvent e)
    {
        transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        this.UnRegisterEvent<GamePassEvent>(onGamePass);
    }

    public IArchitecture GetArchitecture()
    {
        return PointGame.Interface;
    }
}
