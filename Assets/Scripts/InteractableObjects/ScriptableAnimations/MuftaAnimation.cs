using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule;

public class MuftaAnimation : ObjectWithAnimation
{
    [SerializeField] private GameObject _roof;
    [SerializeField]private float _roofTransfromBottom = 0.44f;
    private float _roofTransfromTop = 0.65f;

    private bool _isAnimated = false;
    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(RoofMover(true));
    }
    public override void PlayScriptableAnimationClose()
    {
        StartCoroutine(RoofMover(false));
    }
    private IEnumerator RoofMover(bool value)
    {
        if (!_isAnimated && value)
        {
            _isAnimated = true;
            _roof.SetActive(true);
            while (_roof.transform.localPosition.y < _roofTransfromTop)
            {
                 _roof.transform.position += new Vector3(0, 0.01f, 0);
                yield return new WaitForSeconds(0.02f);
            }
           _roof.SetActive(false);
        }
        else if (!_isAnimated && !value)
        {
            _isAnimated = true;
            _roof.SetActive(true);
            while (_roof.transform.localPosition.y > _roofTransfromBottom)
            {
                _roof.transform.position -= new Vector3(0, 0.01f, 0);
                yield return new WaitForSeconds(0.02f);
            }
        }
        _isAnimated = false;
    }
}


