using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class EnableImageButton : BaseButton
{
    [SerializeField] private Transform _newSchemePos;
    private MapImageButton _mapImageButton;
    protected override void Start()
    {
        base.Start();
        BackButton.OnBackButtonClick += OnDisableMapImage;
        _mapImageButton = InstanceHandler.Instance.MapImageButton;
        if (_newSchemePos != null)
            _newSchemePos.transform.parent = null;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_mapImageButton.gameObject.activeSelf)
            _mapImageButton.gameObject.SetActive(false);
        else
        {
            if(_newSchemePos==null)
            {
                Vector3 newImagePos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
                _mapImageButton.transform.position = newImagePos;
            }
            else
            {
                _mapImageButton.transform.position = _newSchemePos.position;
            }

            _mapImageButton.gameObject.SetActive(true);
        }
          
    }
    private void OnDisableMapImage()
    {
        if (!_mapImageButton.gameObject.activeSelf)
            return;
        _mapImageButton.gameObject.SetActive(false);
    }
}
