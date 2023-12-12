using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    public SceneAosObject SceneAosObject { get; set; }
    public ObjectWithAnimation PlaceAnimationObject { get; set; }
    private List<ObjectWithAnimation> _animationObjectList = new List<ObjectWithAnimation>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void AddAnimationObjectToList(ObjectWithAnimation obj)
    {
        _animationObjectList.Add(obj);
    }
    public void PlayCloseAnimationForAllObjects()
    {
        foreach (var item in _animationObjectList)
        {
            item.PlayScriptableAnimationClose();
        }
        _animationObjectList.Clear();
    }
}