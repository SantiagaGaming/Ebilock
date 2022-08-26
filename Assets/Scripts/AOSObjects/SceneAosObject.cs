using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosObject")]
public class SceneAosObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    protected BaseObject baseObject;
    [SerializeField] private bool _button;

    public void InvokeOnClick()
    {
        OnClickObject?.Invoke(ObjectId);
    }

    [AosAction("Задать имя объекта")]
    public virtual void SetObjectName([AosParameter("Задать Текст")] string text)
    {
        baseObject = GetComponent<BaseObject>();
        baseObject.SetHelperName(text);
    }
    [AosAction("Вкл. Выкл. Коллайдер объекта")]
    public void ActivateObjectCollider([AosParameter("Включение коллайдера")] bool active)
    {
      Collider col =  gameObject.GetComponent<Collider>();
        if(col!=null && !_button)
            col.enabled = active;
    }

}
