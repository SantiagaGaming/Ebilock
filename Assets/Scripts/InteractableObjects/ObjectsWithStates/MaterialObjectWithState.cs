using UnityEngine;
public class MaterialObjectWithState : BaseObjectWithState
{
    [SerializeField] private GameObject _lamp;
    [SerializeField] private Material _none;
    [SerializeField] private Material _bright;
    public override void RepairObject() => _lamp.GetComponent<Renderer>().material = _bright;
    public override void BrokObject() => _lamp.GetComponent<Renderer>().material = _none;
}
