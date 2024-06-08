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
        this.RegisterEvent<OnCountDownEvent>(e => 
        {
            transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
            transform.Find("Canvas/GameOverPanel").gameObject.SetActive(true);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private void onGamePass(GamePassEvent e)
    {
        transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
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
