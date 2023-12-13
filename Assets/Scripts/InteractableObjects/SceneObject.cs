using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;

public class SceneObject : BaseObject
{
    public bool NonAOS;
    public delegate void SetTransformAndText(Transform pos, string text);
    public static SetTransformAndText SetTransformAndTextEvent;
    [SerializeField] protected Transform HelperPos;
    [SerializeField] protected GameObject[] Visuals;

    private float _emmisionValue = 0.5f;
    public string HelperName { get; private set; }
    protected virtual void Start()
    {
        if (NonAOS)
            return;
        EnableObject(false);
        InstanceHandler.Instance.AOSObjectsHolder.AddSceneObject(this);
    }
    public void SetHelperName(string value) => HelperName = value;
    public override void OnHoverIn(InteractHand interactHand)
    {
        if (HelperPos != null)
            SetTransformAndTextEvent?.Invoke(HelperPos, HelperName);
        EnableHighlight(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        SetTransformAndTextEvent?.Invoke(null, null);
        EnableHighlight(false);
    }
    public override void EnableObject(bool value)
    {
        if (GetComponent<Collider>() != null)
        {
            foreach (Collider c in GetComponents<Collider>())
                c.enabled = value;
        }
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = value;
    }

    protected void EnableHighlight(bool value)
    {
        foreach (var visual in Visuals)
        {
            foreach (var mesh in visual.GetComponentsInChildren<Renderer>())
            {
                if (mesh == null)
                    return;
                if (value)
                {
                    mesh.material.EnableKeyword("_EMISSION");
                    mesh.material.SetColor("_EmissionColor", new Color(_emmisionValue, _emmisionValue, _emmisionValue));
                }
                else
                    mesh.material.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
