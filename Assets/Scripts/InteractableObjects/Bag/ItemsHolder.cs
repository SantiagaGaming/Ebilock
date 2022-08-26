using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private Transform _position;
    private void Start()
    {
        foreach (var item in _items)
        {
            item.transform.position = _position.position;
        }
        HideItems();
    }
    public void HideItems()
    {
        foreach (var item in _items)
        {
            item.transform.position = _position.position;
        }
    }
    public void PullItems()
    {
        Vector3 tempPos = _position.position;
        for (int i = 0; i < _items.Length; i++)
        {
            tempPos -= new Vector3(0.4f, 0, 0);
            _items[i].transform.position = tempPos;
        }
    }
}
