using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton Pattern
        private static GameManager instance;
        public static GameManager Instance { 
            get { 
                return instance; 
            } 
        }
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this);
            }
        }
    #endregion
    
    // Managers
    private Player player;
    private UiManager uiManager;
    private GameProject gameProject;
    // Date
    private int currentDay = 0;
    private int currentYear = 0;
    // Messages to player
    private bool currentlyTyping = false;
    private Queue<string> msg1Content = new Queue<string>();
    // Characters
    [SerializeField] private Receptionist receptionist;

    private void Start() {
        player = Player.Instance;
        uiManager = UiManager.Instance;
        gameProject = GameProject.Instance;
        #region msg1 content
            msg1Content.Enqueue("De");
            msg1Content.Enqueue("ar ");
            msg1Content.Enqueue("Ms");
            msg1Content.Enqueue(". ");
            msg1Content.Enqueue("Ca");
            msg1Content.Enqueue("rt");
            msg1Content.Enqueue("er");
            msg1Content.Enqueue("\n");
            msg1Content.Enqueue("Tha");
            msg1Content.Enqueue("nk");
            msg1Content.Enqueue(" you");
            msg1Content.Enqueue(" for");
            msg1Content.Enqueue(" re");
            msg1Content.Enqueue("ac");
            msg1Content.Enqueue("hi");
            msg1Content.Enqueue("ng");
            msg1Content.Enqueue(" out");
            msg1Content.Enqueue(" so");
            msg1Content.Enqueue(" ea");
            msg1Content.Enqueue("rly");
            msg1Content.Enqueue(", ");
            msg1Content.Enqueue("I ");
            msg1Content.Enqueue("am");
            msg1Content.Enqueue(" ve");
            msg1Content.Enqueue("ry ");
            msg1Content.Enqueue("ex");
            msg1Content.Enqueue("ci");
            msg1Content.Enqueue("ted");
            msg1Content.Enqueue(" to");
            msg1Content.Enqueue(" be");
            msg1Content.Enqueue(" pa");
            msg1Content.Enqueue("rt");
            msg1Content.Enqueue(" of");
            msg1Content.Enqueue(" the");
            msg1Content.Enqueue(" te");
            msg1Content.Enqueue("am ");
            msg1Content.Enqueue("and");
            msg1Content.Enqueue(" will");
            msg1Content.Enqueue(" gla");
            msg1Content.Enqueue("dly");
            msg1Content.Enqueue(" be");
            msg1Content.Enqueue(" the");
            msg1Content.Enqueue("re");
            msg1Content.Enqueue(" as");
            msg1Content.Enqueue(" so");
            msg1Content.Enqueue("on ");
            msg1Content.Enqueue("as");
            msg1Content.Enqueue(" po");
            msg1Content.Enqueue("ss");
            msg1Content.Enqueue("ib");
            msg1Content.Enqueue("le.");
            msg1Content.Enqueue(" Tha");
            msg1Content.Enqueue("nks ");
            msg1Content.Enqueue(" for");
            msg1Content.Enqueue(" the");
            msg1Content.Enqueue(" op");
            msg1Content.Enqueue("po");
            msg1Content.Enqueue("rt");
            msg1Content.Enqueue("un");
            msg1Content.Enqueue("it");
            msg1Content.Enqueue("y,");
            msg1Content.Enqueue(" I");
            msg1Content.Enqueue(" wi");
            msg1Content.Enqueue("ll");
            msg1Content.Enqueue(" not");
            msg1Content.Enqueue(" dis");
            msg1Content.Enqueue("ap");
            msg1Content.Enqueue("po");
            msg1Content.Enqueue("in");
            msg1Content.Enqueue("t.");
        #endregion
        uiManager.HideHUD();
    }

    private void Update() {
        // Boss sends a msg to player: 
        // Send notification to player and play ding sound 
        // if (/*Timing for first msg*/) {
                // Fill the text component with string
        // }

        // Typing message to team after a milestone is achieved
        if (currentlyTyping == true && Input.anyKeyDown) {
            if (msg1Content.Count != 0) {
                uiManager.GetTeamMsgText().text += msg1Content.Dequeue();
            } else {
                uiManager.GetSendMsgButton().interactable = true;
            }
        }
    }

    // Cutscenes -----------------------------------------------
    public void InitProjectCreation() {
        player.DisableMovement();
        // Maybe wait some secs
        gameProject.InitProjectCreation();
    }

    public void WelcomeIntro() {
       receptionist.Talk();
       // Wait secs?
       receptionist.WalkToProjectManagerDesk();
    }

    // Dialog -----------------------------------------------
    public void InitDialog(string characterName, string dialog) {
        player.DisableMovement();
        uiManager.ShowDialogBox();
        uiManager.GetDialogBoxNameText().text = characterName;
        uiManager.GetDialogBoxMsgText().text = dialog;
    }

    // Messages -----------------------------------------------
    public void StartTypingMsg() {
        player.DisableMovement();
        currentlyTyping = true;
    }

    public void StopTypingMsg() {
        player.EnableMovement();
        currentlyTyping = false;
    }
}
