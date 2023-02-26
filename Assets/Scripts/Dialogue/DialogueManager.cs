//https://www.youtube.com/watch?v=vY0Sk93YUhA
//I also used his tutorials for the other ink stuff
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
//using Ink.UnityIntegration;

public class DialogueManager : MonoBehaviour
{
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;} //read-only to outside scripts
    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private DialogueVariables dialogueVariables;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    
    void Start()
    {
        layoutAnimator = dialoguePanel.GetComponent<Animator>();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get all choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
        
        // handle continuing to the next line in the dialogue when submit is pressed
        if ( currentStory.currentChoices.Count == 0 && Input.GetButtonDown("Interact"))
        {
            ContinueStory();        
        }
    
        //player can cancel dialogue at any time with "x"
        if (dialogueIsPlaying && Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        speakerText.text = "???";
        portraitAnimator.Play("default");
        layoutAnimator.Play("right");
        dialogueVariables.StartListening(currentStory);

    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        dialogueVariables.StopListening(currentStory);
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            //display choices if any
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            //parse tag into their key:value pair
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be approprately parsed. There is either more or less than 2 values: " + tag);
            }
            string tagKey = splitTag[0].Trim(); //trim gets rid of empty space that may be at the beginning or end of the string
            string tagValue = splitTag[1].Trim();

            //handle tag
            switch(tagKey)
            {
                case SPEAKER_TAG:
                    speakerText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    Debug.Log(tag);
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("more choices were given than ui can support.");
        }

        //enable and initialize the choices up to the amount of choices allowed for this line of dialogue
        //we only have two max
        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        //go thru remaining choices the ui supports and make sure theyre hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }
    // i believe this is to have the player automatically select the first choice if they were to click the interact button
    private IEnumerator SelectFirstChoice()
    {
        //event system requires we clear it first, then wait for at least one frame before we set current select obj
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {   
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    public void GiveEssence()
    {
        //if give essence variable in ink file == true
        //set visible/active their corresponding essence
        //(seralize related essence to demon)
    }

    //allows unity to access the variable from ink file (dictionary) and use it
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }
}
