using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFadeIn : MonoBehaviour
{
    [SerializeField] private Teleporter _teleporter;
    public void StartFade()
    {
        Player.Instance.FadeIn(0f, true);
        StartCoroutine(StartFadeCo());
    }
    private IEnumerator StartFadeCo()
    {
        yield return new WaitForSeconds(0.2f);
        Player.Instance.FadeOut(0.3f, false);
        yield return new WaitForSeconds(1.5f);
    }
}
