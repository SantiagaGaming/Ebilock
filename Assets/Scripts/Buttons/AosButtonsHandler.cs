using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Контроллер событий кнопок")]

public class AosButtonsHandler : AosObjectBase
{

    [AosEvent(name: "Клик на кнопку проверки")]
    public event AosEventHandlerWithAttribute OnAdjustClicked;
    [AosEvent(name: "Клик на кнопку осмотра")]
    public event AosEventHandlerWithAttribute OnWatchClicked;
    [AosEvent(name: "Клик на кнопку замены")]
    public event AosEventHandlerWithAttribute OnRepairClicked;

    [AosAction(name: "Показать кнопку осмотра")]
    public void ShowWatchButton()
    {
        MovingButtonsController.Instance.ShowWatchButton();
    }
    [AosAction(name: "Показать кнопку замены")]
    public void ShowRepairButton()
    {
        MovingButtonsController.Instance.ShowRepairButton();
    }
    [AosAction(name: "Показать кнопку провекри")]
    public void ShowAdjustButton()
    {
        MovingButtonsController.Instance.ShowAdjustButton();
    }
    [AosAction(name: "Показать все кнопки")]
    public void ShowAllButtons()
    {
        MovingButtonsController.Instance.ShowAllButtons();
    }
    [AosAction(name: "Скрыть все кнопки")]
    public void HideAllButtons()
    {
        MovingButtonsController.Instance.HideAllButtons();
    }
    public void AdjustClicked(string name)
    {
        OnAdjustClicked?.Invoke(name);
    }
    public void WatchClicked(string name)
    {
        OnWatchClicked?.Invoke(name);
    }
    public void RepairClicked(string name)
    {
        OnRepairClicked?.Invoke(name);
    }

}

