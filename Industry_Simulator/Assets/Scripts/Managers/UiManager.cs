using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    #region Singleton Pattern
        private static UiManager instance;
        public static UiManager Instance { 
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

    // HUD
    [Header("HUD")]
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private Text gameStudioNameText;
    [SerializeField] private Text projectNameText;
    [SerializeField] private Text currentMilestoneText;
    [SerializeField] private Text dateText;
    [SerializeField] private Text teamSizeText;
    [SerializeField] private Button buildButton;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Text dialogBoxNameText;
    [SerializeField] private Text dialogBoxMsgText;

    // Main Window Panel
    [Header("Main Window Panel")]
    [SerializeField] private GameObject mainWindow;
    [SerializeField] private Button closeWindowButton;
    // Building system UI
    [Header("Building system UI")]
    [SerializeField] private Button buildTabButton;
    [SerializeField] private GameObject buildPanel;
    [SerializeField] private GameObject mainBuildCategory1Panel;
    [SerializeField] private GameObject buildCategory1Panel;
    [SerializeField] private GameObject buildCategory2Panel;
    [SerializeField] private GameObject buildCategory3Panel;
    // Project Info panel
    [Header("Project Info panel")]
    [SerializeField] private Button projectTabButton;
    [SerializeField] private GameObject projectInfoPanel;
    // Milestone panel
    [Header("Milestone panel")]
    [SerializeField] private GameObject milestonePanel;
    [SerializeField] private GameObject milestoneSummaryScreen;
    [SerializeField] private GameObject milestoneMangementScreen;
    // Team panel
    [Header("Team panel")]
    [SerializeField] private Button teamTabButton;
    [SerializeField] private GameObject teamPanel;
    [SerializeField] private GameObject teamMainPanel;
    [SerializeField] private GameObject teamDesignPanel;
    [SerializeField] private GameObject teamDevPanel;
    [SerializeField] private GameObject teamArtPanel;
    [SerializeField] private GameObject teamMarketingPanel;
    [SerializeField] private GameObject teamQAPanel;
    // WorkOS Panel
    [Header("WorkOS panel")]
    [SerializeField] private Button workOsTabButton;
    [SerializeField] private GameObject workOSPanel;
    [SerializeField] private GameObject workOSinboxPanel;
    [SerializeField] private GameObject workOSprojectsPanel;
    [SerializeField] private GameObject workOSBossInboxPanel;
    [SerializeField] private GameObject workOSTeamInboxPanel;
    [SerializeField] private Button inboxButton;
    [SerializeField] private Button projectsButton;
    [SerializeField] private Button bossInboxButton;
    [SerializeField] private Button teamInboxButton;
    [SerializeField] private Text teamMsg1;
    [SerializeField] private Button sendTeaMsgButton;

    private void Start() {
        HideHUD();
    }

    private void Update() {
        // Update UI with the correct info
        gameStudioNameText.text = Player.Instance.GetGameStudioName();
        projectNameText.text = GameProject.Instance.GetProjectName();
        teamSizeText.text = Player.Instance.GetTeamSize().ToString();
        currentMilestoneText.text = Player.Instance.GetCurrentMilestone();
        //dateText.text = 
    }

    public void ShowMainWindow() {
        mainWindow.SetActive(true);
        HideHUD();
    }

    public void CloseMainWindow() {
        mainWindow.SetActive(false);
        ShowHUD();
    }

    public void ShowProjectInfoPanel() {
        ShowMainWindow();
        projectInfoPanel.SetActive(true);
        teamPanel.SetActive(false);
        workOSPanel.SetActive(false);
        buildPanel.SetActive(false);
    }

    public void ShowTeamPanel() {
        ShowMainWindow();
        projectInfoPanel.SetActive(false);
        teamPanel.SetActive(true);
        workOSPanel.SetActive(false);
        buildPanel.SetActive(false);
        teamMainPanel.SetActive(true);
        teamDevPanel.SetActive(false);
        teamDesignPanel.SetActive(false);
        teamArtPanel.SetActive(false);
        teamMarketingPanel.SetActive(false);
        teamQAPanel.SetActive(false);
    }

    public void CloseTeamPanel() {
        teamPanel.SetActive(false);
    }

    public void ShowTeamDevPanel() {
        teamMainPanel.SetActive(false);
        teamDevPanel.SetActive(true);
        teamDesignPanel.SetActive(false);
        teamArtPanel.SetActive(false);
        teamMarketingPanel.SetActive(false);
        teamQAPanel.SetActive(false);
    }

    public void ShowTeamDesignPanel() {
        teamMainPanel.SetActive(false);
        teamDevPanel.SetActive(false);
        teamDesignPanel.SetActive(true);
        teamArtPanel.SetActive(false);
        teamMarketingPanel.SetActive(false);
        teamQAPanel.SetActive(false);
    }

    public void ShowTeamArtPanel() {
        teamMainPanel.SetActive(false);
        teamDevPanel.SetActive(false);
        teamDesignPanel.SetActive(false);
        teamArtPanel.SetActive(true);
        teamMarketingPanel.SetActive(false);
        teamQAPanel.SetActive(false);
    }

    public void ShowTeamMarketingPanel() {
        teamMainPanel.SetActive(false);
        teamDevPanel.SetActive(false);
        teamDesignPanel.SetActive(false);
        teamArtPanel.SetActive(false);
        teamMarketingPanel.SetActive(true);
        teamQAPanel.SetActive(false);
    }

    public void ShowTeamQAPanel() {
        teamMainPanel.SetActive(false);
        teamDevPanel.SetActive(false);
        teamDesignPanel.SetActive(false);
        teamArtPanel.SetActive(false);
        teamMarketingPanel.SetActive(false);
        teamQAPanel.SetActive(true);
    }

    public void ShowWorkOSPanel() {
        ShowMainWindow();
        projectInfoPanel.SetActive(false);
        teamPanel.SetActive(false);
        workOSPanel.SetActive(true);
        buildPanel.SetActive(false);
        workOSprojectsPanel.SetActive(false);
        workOSinboxPanel.SetActive(false);
    }

    public void ShowInboxPanel() {
        workOSprojectsPanel.SetActive(false);
        workOSinboxPanel.SetActive(true);
        workOSBossInboxPanel.SetActive(false);
        workOSTeamInboxPanel.SetActive(false);
    }

    public void ShowBossInboxPanel() {
        workOSBossInboxPanel.SetActive(true);
        workOSTeamInboxPanel.SetActive(false);
    }

    public void ShowTeamInboxPanel() {
        workOSBossInboxPanel.SetActive(false);
        workOSTeamInboxPanel.SetActive(true);
    }

    public void ShowProjectsPanel() {
        workOSprojectsPanel.SetActive(true);
        workOSinboxPanel.SetActive(false);
    }

    public void ShowBuildPanel() {
        ShowMainWindow();
        projectInfoPanel.SetActive(false);
        teamPanel.SetActive(false);
        workOSPanel.SetActive(false);
        buildPanel.SetActive(true);
        mainBuildCategory1Panel.SetActive(true);
        buildCategory1Panel.SetActive(false);
        buildCategory2Panel.SetActive(false);
        buildCategory3Panel.SetActive(false);
    }

    public void ShowBuildPanel1() {
        mainBuildCategory1Panel.SetActive(false);
        buildCategory1Panel.SetActive(true);
        buildCategory2Panel.SetActive(false);
        buildCategory3Panel.SetActive(false);
    }

    public void ShowBuildPanel2() {
        mainBuildCategory1Panel.SetActive(false);
        buildCategory1Panel.SetActive(false);
        buildCategory2Panel.SetActive(true);
        buildCategory3Panel.SetActive(false);
    }

    public void ShowBuildPanel3() {
        mainBuildCategory1Panel.SetActive(false);
        buildCategory1Panel.SetActive(false);
        buildCategory2Panel.SetActive(false);
        buildCategory3Panel.SetActive(true);
    }

    public void ShowMilestonePanel() {
        milestonePanel.SetActive(true);
        milestoneSummaryScreen.SetActive(true);
        milestoneMangementScreen.SetActive(false);
    }

    public void ShowMilestoneManagementPanel() {
        milestonePanel.SetActive(true);
        milestoneSummaryScreen.SetActive(false);
        milestoneMangementScreen.SetActive(true);
    }

    public void WriteMessageToTeam() {
        HideMilestonePanel();
        CloseTeamPanel();
        ShowWorkOSPanel();
        ShowInboxPanel();
        ShowTeamInboxPanel();
        projectTabButton.interactable = false;
        teamTabButton.interactable = false;
        workOsTabButton.interactable = false;
        buildTabButton.interactable = false;
        inboxButton.interactable = false;
        projectsButton.interactable = false;
        bossInboxButton.interactable = false;
        teamInboxButton.interactable = false;
        closeWindowButton.interactable = false;
        GameManager.Instance.StartTypingMsg();
        sendTeaMsgButton.interactable = false;
    }

    public void SendMessageToTeam() {
        GameManager.Instance.StopTypingMsg();
        projectTabButton.interactable = true;
        teamTabButton.interactable = true;
        workOsTabButton.interactable = true;
        buildTabButton.interactable = true;
        inboxButton.interactable = true;
        projectsButton.interactable = true;
        bossInboxButton.interactable = true;
        teamInboxButton.interactable = true;
        closeWindowButton.interactable = true;
        milestonePanel.SetActive(false);
    }

    public Text GetTeamMsgText() {
        return teamMsg1;
    }

    public Button GetSendMsgButton() {
        return sendTeaMsgButton;
    }

    public void HideMilestonePanel() {
        milestonePanel.SetActive(false);
    }

    public void ShowHUD() {
        hudPanel.SetActive(true);
    }
    
    public void HideHUD() {
        hudPanel.SetActive(false);
    }

    public void ShowDialogBox() {
        dialogBox.SetActive(true);
    }

    public void HideDialogBox() {
        dialogBox.SetActive(false);
    }

    public Text GetDialogBoxNameText() {
        return dialogBoxNameText;
    }

    public Text GetDialogBoxMsgText() {
        return dialogBoxMsgText;
    }
}