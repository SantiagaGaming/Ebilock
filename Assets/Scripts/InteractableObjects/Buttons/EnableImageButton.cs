using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class EnableImageButton : BaseButton
{
    private MapImageButton _mapImageButton;
    protected override void Start()
    {
        base.Start();
        BackButton.OnBackButtonClick += OnDisableMapImage;
        _mapImageButton = InstanceHandler.Instance.MapImageButton;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_mapImageButton.gameObject.activeSelf)
            _mapImageButton.gameObject.SetActive(false);
        else
        {
            Vector3 newImagePos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
            _mapImageButton.transform.position = newImagePos;
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
