using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;

public class SceneObject : BaseObject
{
    public bool NonAOS;

    [SerializeField] protected Transform HelperPos;
    [SerializeField] protected OutlineCore[] OutlineObjects;

    protected string HelperName;
    protected virtual void Start()
    {
        if (!NonAOS)
        {
            EnableObject(false);
            InstanceHandler.Instance.AOSObjectsActivator.AddSceneObject(this);
            SceneAOSObject = GetComponent<SceneAosObject>();
        }
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        if (HelperPos != null)
        {
            InstanceHandler.Instance.ObjectsInfoWindow.SetPosition(HelperPos);
            InstanceHandler.Instance.ObjectsInfoWindow.ShowWindowWithText(HelperName);

        }
        EnableOutlines(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        InstanceHandler.Instance.ObjectsInfoWindow.HidetextHelper();
        EnableOutlines(false);
    }
    public override void EnableObject(bool value)
    {
        if (GetComponent<Collider>() != null)
        {
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = value;
            }
        }
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = value;
        if (GetComponentInChildren<SpriteRenderer>() != null)
        {
            var child = GetComponentInChildren<SpriteRenderer>();
            if (child.GetComponent<BackButton>() == null)
                child.enabled = value;
        }
    }
    public void SetHelperName(string value)
    {
        HelperName = value;
    }
    public string GetAOSName()
    {
        if (SceneAOSObject != null)
            return SceneAOSObject.ObjectId;
        else return null;
    }
    protected void EnableOutlines(bool value)
    {
        if (OutlineObjects != null)
            foreach (var outline in OutlineObjects)
            {
                //if (outline != null)
                //{
                //    outline.enabled = value;
                //    outline.OutlineWidth = 3;
                //}
                if (outline.GetComponent<MeshRenderer>() == null)
                {
                    return;
                }

                if (value)
                {
                    outline.GetComponent<MeshRenderer>().material.color *= 2f;
                }

                else
                {
                    outline.GetComponent<MeshRenderer>().material.color /= 2f;
                }

            }
    }
}
