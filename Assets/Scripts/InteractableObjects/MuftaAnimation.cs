using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class MuftaAnimation : MonoBehaviour, IAnimationObject
{
    [SerializeField] private GameObject _roof;

    private bool _isAmimated = false;

    private IEnumerator RoofMover(bool value)
    {
        if (!_isAmimated)
        {
            _roof.SetActive(true);
            _isAmimated = true;
            int y = 0;
            while (y < 25)
            {
                if (value)
                    _roof.transform.position += new Vector3(0, 0.01f, 0);
                else
                    _roof.transform.position -= new Vector3(0, 0.01f, 0);
                yield return new WaitForSeconds(0.02f);
                y++;
            }

            if (value)
            {
                _roof.SetActive(false);
            }
            _isAmimated = false;
        }
    }
    public void CloseAnimation()
    {
        StartCoroutine(RoofMover(false));
    }

    public void OpenAnimation()
    {
        StartCoroutine(RoofMover(true));
    }
}


