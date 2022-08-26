using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AOSCanvas")]

public class AOSCanvas : AosObjectBase
{
    [SerializeField] private BaseButton[] _buttons;

    [AosAction("Вкл. Выкл. Кнопок канваса")]
    public void ActivateButtons([AosParameter("Включение кнопок")] bool active)
    {
        foreach (var item in _buttons)
        {
            item.EnableButton(active);
        }

    }
}
