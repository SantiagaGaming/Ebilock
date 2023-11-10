using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;

public class SceneObject : BaseObject
{
    public bool NonAOS;

    [SerializeField] protected Transform HelperPos;
    [SerializeField] protected GameObject[] Visuals;

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
        EnableHighlight(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        InstanceHandler.Instance.ObjectsInfoWindow.HidetextHelper();
        EnableHighlight(false);
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
    protected void EnableHighlight(bool value)
    {
        foreach (var visual in Visuals)
        {
            foreach (var mesh in visual.GetComponentsInChildren<MeshRenderer>())
            {
                if (mesh == null)
                    return;
                if (value)
                    mesh.GetComponent<MeshRenderer>().material.color *= 2.5f;
                else
                    mesh.GetComponent<MeshRenderer>().material.color /= 2.5f;
            }
        }
    }
}
