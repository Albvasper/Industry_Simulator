using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProject : MonoBehaviour {

    #region Singleton Pattern
        private static GameProject instance;
        public static GameProject Instance { 
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
    
    private string projectName = "";
    private string tags = "";
    private string platform = "";
    private string artStyle = "";
    private string description = "";
    private string graphics = "";
    [SerializeField] private GameObject createProjectPanel;
    [SerializeField] private Text gameStudioNameText;
    [SerializeField] private InputField projectNameInputField;
    [SerializeField] private InputField tagsInputField;
    [SerializeField] private InputField platformInputField;
    [SerializeField] private InputField artStyleInputField;
    [SerializeField] private InputField descriptionInputField;
    [SerializeField] private Button twoDGraphicsButton;
    [SerializeField] private Button threeDGraphicsButton;

    private void Start() {
        createProjectPanel.SetActive(false);
        gameStudioNameText.text = GameManager.Instance.GetGameStudioName();
    }

    public void InitProjectCreation() {
        createProjectPanel.SetActive(true);
    }

    public void SaveProjectInfo() {
        if (projectName == "" || tags == ""|| platform == "" || artStyle == "" || description == "" || graphics == "") {
            // Deny saving data until every field is filled
            Debug.Log("No!");
        } else {
            Destroy(createProjectPanel);
        }
    }

    public void SetProjectName() {
        projectName = projectNameInputField.text;
    }

    public void SetTags() {
        tags = tagsInputField.text;
    }

    public void SetPlatforms() {
        platform = platformInputField.text;
    }

    public void SetArtStyle() {
        artStyle = artStyleInputField.text;
    }
    
    public void SetDescription() {
        description = descriptionInputField.text;
    }

    public void SetTwoDGraphics() {
        graphics = "2D";
        threeDGraphicsButton.interactable = true;
        twoDGraphicsButton.interactable = false;
    }

    public void SetThreeDGraphics() {
        graphics = "3D";
        twoDGraphicsButton.interactable = true;
        threeDGraphicsButton.interactable = false;
    }

    public string GetProjectName() {
        return projectName;
    }

    public string GetTags() {
        return tags;
    }

    public string GetPlatform() {
        return platform;
    }

    public string GetArtStyle() {
        return artStyle;
    }

    public string GetGraphics() {
        return graphics;
    }
}
