using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;

public class ParentObject : MonoBehaviour, IClickAble, IHoverAble
{
    public bool IsClickable { get; set; }
    public bool IsHoverable { get; set; }

    [SerializeField] protected bool isButton;
    [SerializeField] protected bool isButtonInPlace;
    [SerializeField] protected OutlineCore[] outlineObjects;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string helperName;

    public void OnClicked(InteractHand interactHand)
    {
        throw new System.NotImplementedException();
    }

    public void OnHoverIn(InteractHand interactHand)
    {
        throw new System.NotImplementedException();
    }

    public void OnHoverOut(InteractHand interactHand)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //canvasHelper = FindObjectOfType<CanvasObjectHelperController>();
        if (!isButton)
        {
            var collider = gameObject.GetComponent<Collider>();
            if (collider != null)
                collider.enabled = false;
            //AOSColliderActivator.Instance.AddBaseObject(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
