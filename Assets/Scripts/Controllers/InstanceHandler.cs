using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    public SceneAosObject SceneAosObject { get; set; }
    public ObjectWithAnimation PlaceAnimationObject { get; set; }
    private List<ObjectWithAnimation> _animationObjectList = new List<ObjectWithAnimation>();

    [SerializeField] private AOSObjectsActivator _aosObjectsActivator;
    [SerializeField] private BackButtonsActivator _backButtonsActivator;
    [SerializeField] private MeasureButtonsActivator _measureButtonsActivator;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private MovingButtonsController _movinButtonsController;
    [SerializeField] private MovingTextWindow _objectsInfoWindow;
    [SerializeField] private MovingTextWindow _reactionInfoWindow;
    [SerializeField] private CanvasChanger _canvasChanger;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private Diet _diet;
    [SerializeField] private ShupPositionChanger _shupPositionChanger;
    [SerializeField] private Ampermetr _ampermetr;
    [SerializeField] private ShupController _shupController;
    [SerializeField] private PointerDevice _pointerDevice;
    [SerializeField] private MeasureController _measureController;
    [SerializeField] private MapImageButton _mapImageButton;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private API _api;
    [SerializeField] private HelpTextController _helpTextController;
    public MapImageButton MapImageButton => _mapImageButton;
    public PointerDevice PointerDevice => _pointerDevice;
    public ShupController ShupController => _shupController;
    public Ampermetr AmperMetr => _ampermetr;
    public AOSObjectsActivator AOSObjectsActivator => _aosObjectsActivator;
    public MovingButtonsController MovingButtonsController => _movinButtonsController;
    public MovingTextWindow ObjectsInfoWindow => _objectsInfoWindow;
    public MovingTextWindow ReactionInfoWindow => _reactionInfoWindow;
    public LocationController LocationController => _locationController;
    public MeasureButtonsActivator MeasureButtonsActivator => _measureButtonsActivator;
    public CanvasChanger CanvasChanger => _canvasChanger;
    public TimerView TimerView => _timerView;
    public MainMenuCanvas MainMenuCanvas => _mainMenuCanvas;
    public Diet Diet => _diet;
    public Teleporter Teleporter => _teleporter;
    public BackButtonsActivator BackButtonsActivator => _backButtonsActivator;
    public ShupPositionChanger ShupPositionChanger => _shupPositionChanger;
    public MeasureController MeasureController => _measureController;
    public ModeController ModeController => _modeController;
    public HelpTextController HelpTextController => _helpTextController;
    public API API => _api;
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