using System;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public enum NextButtonState
{
    Start,
    Fault
}
public enum DialogRole
{
    User,
    Dude
}
[AosSdk.Core.Utils.AosObject(name: "АПИ")]
public class API : AosObjectBase
{
    public Action ShowPlaceEvent;
    public Action StartUpdatePlaceEvent;
    public Action ResetMeasureButtonsEvent;
    public Action<string> DialogEvent;
    public Action<string> DialogHeaderEvent;
    public Action<float> SetMeasureValueEvent;
    public Action<string> TeleportStartEvent;
    public Action<string> SetLocationEvent;
    public Action<string> SetLocationForFieldCollidersEvent;
    public Action<string> ActivateBackButtonEvent;
    public Action<string> SetTimerTextEvent;
    public Action<string> AddMeasureButtonEvent;
    public Action<string> ReactionEvent;
    public Action<string, DialogRole> AddTextObjectUiEvent;
    public Action<string, string> AddTextObjectUiButtonEvent;
    public Action<string, string> EnableDietButtonsEvent;
    public Action<string, string> PointEvent;
    public Action<string, string> EnableMovingButtonEvent;
    public Action<string, string> ActivateByNameEvent;
    public Action<string, string> ActivatePointByNameEvent;
    public Action<string, string> SetMessageTextEvent;
    public Action<string, string, string> SetResultTextEvent;
    public Action<string, string> ShowExitTextEvent;
    public Action<string, string, string> ShowMenuTextEvent;
    public Action<string, string, string, NextButtonState> SetStartTextEvent;

    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;
    [AosEvent(name: "Кнопка нажата")]
    public event AosEventHandlerWithAttribute OnDialogPoint;
    public static API Instance { get; private set; }
    private string _currentLocation;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Teleport([AosParameter("Задать локацию для перемещения")] string location)
    {
        TeleportStartEvent?.Invoke(location);
        EndTween?.Invoke(location);
    }
    [AosAction(name: "Задать текст приветствия")]
    public void showWelcome(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
        TeleportStartEvent?.Invoke("start");
    }
    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }
    public void showDialog(JObject info, JArray points, JObject nav)
    {
        var dude = info.SelectToken("name");
        if (dude != null)
        {
            var header = dude.ToString();
            DialogHeaderEvent?.Invoke(header);
        }
        foreach (var item in points)
        {
            var action = item.SelectToken("action").ToString();
            Debug.Log("Action " + action);
            if (action != null)
                DialogEvent?.Invoke(action);
            var id = item.SelectToken("apiId").ToString();
            var name = item.SelectToken("name").ToString();
            if (id != null && name != null)
                AddTextObjectUiButtonEvent?.Invoke(id, name);
        }
        var outMsg = info.SelectToken("out_msg");
        if (outMsg != null)
        {
            foreach (var item in outMsg)
            {
                if (item.SelectToken("msg") != null)
                {
                    var msg = item.SelectToken("msg").ToString();
                    AddTextObjectUiEvent?.Invoke(msg, DialogRole.Dude);
                }
            }
        }
    }
    public void addDialogMessage(JArray message)
    {
        string msgText = "";
        foreach (var item in message)
        {
            var msg = item.SelectToken("msg");
            var roles = item.SelectTokens("character");
            if (msg != null)
                msgText = msg.ToString();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (role.SelectToken("opt_type") != null)
                    {
                        var roleText = role.SelectToken("opt_type").ToString();
                        if (roleText == "dude")
                            AddTextObjectUiEvent?.Invoke(msgText, DialogRole.Dude);
                        else if (roleText == "user")
                            AddTextObjectUiEvent?.Invoke(msgText, DialogRole.User);
                    }
                }
            }
        }
    }
    [AosAction(name: "Показать место")]
    public void showPlace(JObject place, JArray data, JObject nav)
    {
        string location = place.SelectToken("apiId").ToString();
        SetLocationEvent?.Invoke(location);
        if (place.SelectToken("name") != null)
        {
            _currentLocation = place.SelectToken("name").ToString();
        }
        ShowPlaceEvent?.Invoke();
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("apiId");
            if (temp != null)
                ActivateByNameEvent?.Invoke(temp.ToString(), item.SelectToken("name").ToString());
            if (item.SelectToken("view") != null)
            {
                var aosObjectWithImage = item.SelectToken("view");
                if (aosObjectWithImage != null)
                {

                    if (aosObjectWithImage.SelectToken("apiId") != null)
                    {
                        string name = aosObjectWithImage.SelectToken("apiId").ToString();
                        ActivateByNameEvent?.Invoke(name, "");
                    }
                }
            }
            updatePlace(data, "");
        }
        if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
        {
            ActivateBackButtonEvent?.Invoke(nav.SelectToken("back").SelectToken("action").ToString());
        }
        SetLocationForFieldCollidersEvent?.Invoke(location);
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data)
    {
        EnableDietButtonsEvent(null, null);
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("points");
            if (temp != null)
            {
                if (temp is JArray)
                {
                    Debug.Log(temp.ToString());
                    foreach (var temp2 in temp)
                    {
                        string buttonName = temp2.SelectToken("apiId").ToString();
                        string buttonText = temp2.SelectToken("name").ToString();
                        EnableDietButtonsEvent(buttonName, buttonText);
                    }
                }
            }
        }
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data, string snd)
    {
        StartUpdatePlaceEvent?.Invoke();
        foreach (JObject item in data)
        {
            string pointId = "";
            string pointActionName = "";
            if (item != null)
            {
                var apiIdParent = item.SelectToken("apiId");
                if (apiIdParent != null)
                {
                    var apiIdParentText = apiIdParent.ToString();
                    ActivatePointByNameEvent?.Invoke(apiIdParentText, "OnClick");
                }

                var childs = item.SelectTokens("childs");
                if (childs != null)
                {
                    foreach (var apiId in childs)
                    {
                        if (apiId != null)
                        {
                            JArray tempArr = (JArray)apiId;
                            foreach (var temp in tempArr)
                            {
                                var pointOpbject = temp.SelectToken("apiId");
                                if (pointOpbject != null)
                                    pointId = pointOpbject.ToString();
                                if (temp.SelectTokens("hands") != null)
                                {
                                    var points = temp.SelectTokens("hands");
                                    foreach (var point in points)
                                    {
                                        var pointName = (JArray)point;
                                        if (pointName != null)
                                            foreach (var pnt in pointName)
                                            {
                                                var ptnObject = pnt.SelectToken("action");
                                                if (ptnObject != null)
                                                {
                                                    pointActionName = ptnObject.ToString();
                                                    ActivatePointByNameEvent?.Invoke(pointId, pointActionName);
                                                }
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    [AosAction(name: "Показать реакцию")]
    public void showReaction(JObject info, JObject nav)
    {
        if (info.SelectToken("text") != null)
        {
            var reactionText = info.SelectToken("text").ToString();
            ReactionEvent?.Invoke(reactionText);
        }
    }

    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        SetMessageTextEvent?.Invoke(headText, commentText);
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        SetResultTextEvent?.Invoke(headText, commentText, evalText);
    }
    [AosAction(name: "Показать точки")]
    public void showPoints(string info, JArray data)
    {
        EnableDietButtonsEvent(null, null);
        EnableMovingButtonEvent?.Invoke(null, null);
        foreach (JObject item in data)
        {
            if (item == null)
                return;
            if (item.SelectToken("tool") != null && item.SelectToken("name") != null)
            {
                if (item.SelectToken("tool").ToString() == "eye")
                {
                    string eye = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(eye, text);
                }
                if (item.SelectToken("tool").ToString() == "hand")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_1")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_2")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_3")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_4")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "tool")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(tool, text);
                }
                if (item.SelectToken("tool").ToString() == "pen")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(tool, text);
                }
                if (item.SelectToken("tool").ToString() == "pen_1")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(tool, text);
                }
            }
            else if (item.SelectToken("apiId") != null && item.SelectToken("name") != null)
            {
                string buttonName = item.SelectToken("apiId").ToString();
                string buttonText = item.SelectToken("name").ToString();
                EnableDietButtonsEvent?.Invoke(buttonName, buttonText);
            }
        }
    }

    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {
        SetTimerTextEvent?.Invoke(time);
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasure(JArray measureDevices, JArray measurePoints)
    {
        Debug.Log("Show Measure");
        ResetMeasureButtonsEvent?.Invoke();
        foreach (JObject item in measurePoints)
        {
            var tmpArray = item.SelectToken("points");
            if (tmpArray != null && tmpArray is JArray)
            {
                foreach (JObject item2 in tmpArray)
                {
                    string butonName = item2.SelectToken("apiId").ToString();
                    AddMeasureButtonEvent?.Invoke(butonName);
                }
            }
        }
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasureResult(JObject result, JObject nav)
    {
        Debug.Log("In Measure text From API");
        if (result.SelectToken("result") != null)
        {
            float measureValue = float.Parse(result.SelectToken("result").ToString());
            SetMeasureValueEvent?.Invoke(measureValue);
            Debug.Log(measureValue + " From API");
        }
    }
    [AosAction(name: "Показать меню")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        string headtext = faultInfo.SelectToken("name").ToString();
        string commentText = faultInfo.SelectToken("text").ToString();
        string exitSureText = exitInfo.SelectToken("quest").ToString();
        ShowMenuTextEvent?.Invoke(headtext, commentText, exitSureText);
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
            ShowExitTextEvent?.Invoke(exitText, warntext);
        }
    }
    public void OnInvokeNavAction(string value)
    {
        navAction.Invoke(value);
    }
    public void ConnectionEstablished(string currentLocation)
    {
        EndTween?.Invoke(currentLocation);
    }
    public void InvokeOnMeasure(string text)
    {
        OnMeasure?.Invoke(text);
    }
    public void OnReasonInvoke(string name)
    {
        OnReason?.Invoke(name);
    }
    public void OnMenuInvoke()
    {
        OnMenu?.Invoke();
    }
    public void OnDialogInvoke(string name)
    {
        OnDialogPoint?.Invoke(name);
    }
}
