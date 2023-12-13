using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    [SerializeField] private AOSObjectsHolder _objectsHolder;
    [SerializeField] private BackTriggersHolder _triggersHolder;
    public SceneAosObject SceneAosObject { get; set; }
    public string ActionToInvoke { get; set; }
    public ObjectWithAnimation PlaceAnimationObject { get; set; }
    private List<ObjectWithAnimation> _animationObjectList = new List<ObjectWithAnimation>();
    private BackButton _currentBackButton;
    public static InstanceHandler Instance;
    public AOSObjectsHolder AOSObjectsHolder => _objectsHolder;
    public BackTriggersHolder BackTriggersHoler => _triggersHolder;
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
    public void SetCurrentBackButton(BackButton backButtonObject)
    {
        _currentBackButton = backButtonObject;
    }
    public BackButton GetCurrentBackButton()
    {
        if (_currentBackButton != null)
            return _currentBackButton;
        else return null;
    }
    public void EnableCurrentBackButton(bool value)
    {
        if (_currentBackButton != null)
            _currentBackButton.EnableObject(value);
    }
    public void OnActivaBackButton(string text)
    {
        ActionToInvoke = text;
        EnableCurrentBackButton(true);
    }
}