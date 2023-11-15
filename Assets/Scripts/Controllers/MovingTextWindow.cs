using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class MovingTextWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private GameObject _canvasObject;
    [SerializeField] private GameObject _canvasOnScreenObject;
    [SerializeField] private TextMeshProUGUI _canvasOnScreenText;

    private ModeController _mode;
    private Transform _helperPos;

    private string _text;
    private float _timer = 0.2f;
    private bool _vr;

    private void Start()
    {
        _mode = FindObjectOfType<ModeController>();
        if (_mode == null)
            return;
        _vr = _mode.VrMode;
        SceneObject.SetTransformAndTextEvent += SetTransfromAndText;
    }
    public void SetTransfromAndText(Transform newPos, string text)
    {
        if (newPos != null && text != null)
        {
            _text = HtmlToText.Instance.HTMLToTextReplace(text);
            StartCoroutine("GetHelpName");
        }
        else
        {
            _timer = 0.3f;
            StopCoroutine("GetHelpName");
            if (_vr)
                _canvasObject.SetActive(false);
            else
                _canvasOnScreenObject.SetActive(false);
        }
    }
    private IEnumerator GetHelpName()
    {
        yield return new WaitForSeconds(_timer);
        if (_vr)
        {
            _textMesh.text = _text;
            transform.position = _helperPos.position;
            yield return new WaitForSeconds(0.01f);
            _canvasObject.SetActive(true);
        }
        else
        {
            _canvasOnScreenText.text = _text;
            yield return new WaitForSeconds(0.01f);
            _canvasOnScreenObject.SetActive(true);
        }

    }
}
