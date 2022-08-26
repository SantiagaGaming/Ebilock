using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButtonsController : MonoBehaviour
{
    public static MovingButtonsController Instance;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }
    private MovingButtonsController() { }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    [SerializeField] private GameObject _watchButton;
    [SerializeField] private GameObject _repairButton;
    [SerializeField] private GameObject _adjustButton;

    public void SetMovingButtonsPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void ShowWatchButton()
    {
        _watchButton.SetActive(true);
    }
    public void ShowRepairButton()
    {
        _repairButton.SetActive(true);
    }
    public void ShowAdjustButton()
    {
        _adjustButton.SetActive(true);
    }
    public void HideAllButtons()
    {
        _watchButton.SetActive(false);
        _repairButton.SetActive(false);
        _adjustButton.SetActive(false);
    }
    public void ShowAllButtons()
    {
        _watchButton.SetActive(true);
        _repairButton.SetActive(true);
        _adjustButton.SetActive(true);
    }

}
