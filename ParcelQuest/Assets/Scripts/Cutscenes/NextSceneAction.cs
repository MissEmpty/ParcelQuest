using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneAction : CutsceneAction
{
    [SerializeField] private Scene scene;
    public override IEnumerator Play()
    {
      SceneManager.LoadScene("EndScreen");

        yield break;
    }
}
