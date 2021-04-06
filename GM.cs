using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Game Manager Prototype (To quick & easy access to often used game parameters) 
/// </summary>
public class GM : MonoBehaviour
{
    [Header("GM")]
    public static GM Instance;

    [Header("Camera")]
    public Camera mainCam;
    public Vector3 camVelocity = new Vector3 (0f,0f,0f);
    public float camSmoothTime = 0.25f;
    public Animator camAnim;

    [Header("Cutscenes")]
    public GameObject deathCutscene;

    [Header("Combat")]
    public FloorCtrl floorCtrl;
    public int xSize = 9;
    public int ySize = 5;
    public int defaultSortingLayer = 10;
    public float transparencyOffset = 0.3f;

    [Header("Player")]
    public GameObject player;
    public GameObject playerFX;
    public PlayerCtrl playerCtrl;
    public PlayerSkillCtrl playerSkillCtrl;
    public PlayerUICtrl playerUICtrl;
    public PlayerAudioCtrl playerAudioCtrl;
    public HurtCtrl playerHurtCtrl;
    public Animator playerAnim;
    public Rigidbody2D playerRB;
    public SpriteRenderer playerSR;
    public Collider2D playerCol;
    public AudioSource playerAS;
    public float playerSpd = 5f;    
    public LayerMask playerLayer;

    [Header("Ctrls")]
    public GameObject mobileCtrl;
    public Joystick joystick;
    public static GameObject interactButton;
    public Button ineractButtonComponent;
    public Text ineractButtonTxt;
    public static GameObject attackButton;
    public static GameObject aButton;
    public static GameObject bButton;
    public static GameObject cButton;
    public static GameObject dButton;
    public Image aButtonImg;
    public Image bButtonImg;
    public Image cButtonImg;
    public Image dButtonImg;
    public GameObject[] allButtons = { interactButton, attackButton, aButton, bButton, cButton, dButton };

    [Header("Main Scripts")]
    public TimeCtrl timeCtrl;
    public LvlLoader lvlLoader;

    [Header("Menu")]
    public GameObject menu;
    public GameObject menuPanel;
    public GameObject attributesPanel;
    public GameObject statsPanel;
    public GameObject gearPanel;
    public GameObject skillsPanel;
    public GameObject optionsPanel;
    public GameObject bestiaryPanel;
    public MenuCtrl menuCtrl;

    [Header("Enemies")]
    public EnemiesCreator enemiesCreator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

}
