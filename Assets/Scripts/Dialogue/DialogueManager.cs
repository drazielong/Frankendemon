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
    [SerializeField] private GameObject dialogueController;
    [SerializeField] private GameObject continueIcon; 
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private Animator portraitAnimatorPlayer;
    [SerializeField] private Animator portraitAnimatorCompanion;
    private Animator layoutAnimator;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;} //read-only to outside scripts
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = true;
    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string PLAYER_PORTRAIT_TAG = "player portrait";
    private const string COMPANION_PORTRAIT_TAG = "companion portrait";
    private const string LAYOUT_TAG = "layout";
    private DialogueVariables dialogueVariables;
    private bool skip;

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
        layoutAnimator = dialogueController.GetComponent<Animator>();
        dialogueIsPlaying = false;
        dialogueController.SetActive(false);
        skip = false;

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
        if (Input.GetButtonDown("Interact"))
        {
            skip = true;
        }

        if(!dialogueIsPlaying)
        {
            return;
        }
        
        // handle continuing to the next line in the dialogue when submit is pressed
        if (canContinueToNextLine 
            && currentStory.currentChoices.Count == 0 
            && Input.GetButtonDown("Interact"))
        {
            ContinueStory();  
        }
    
        //player can cancel dialogue at any time with "x" <- idk if we wanna keep this but for testing idc
        if (dialogueIsPlaying && Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(ExitDialogueMode());
            skip = false;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueController.SetActive(true);
        speakerText.text = "???";
        portraitAnimator.Play("default");
        portraitAnimatorPlayer.Play("default");
        portraitAnimatorCompanion.Play("invis");
        //commented out the layout part bc it always fucks the first line of dialogue
        //layoutAnimator.Play("none");

        dialogueVariables.StartListening(currentStory);
        //update ink variable after swapping powers
        currentStory.variablesState["power_name"] = Globals.currentPower;
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialogueController.SetActive(false);
        dialogueText.text = "";
        dialogueVariables.StopListening(currentStory);
    }

    public void ContinueStory() //note: made public bc the essence needs to call this manually bc of its hierarchy shit
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = ""; 
        continueIcon.SetActive(false);
        HideChoices();
        canContinueToNextLine = false;
        skip = false;

        bool isAddingRichTextTag = false;

        foreach (char letter in line.ToCharArray())
        {          
            //if interact is pressed, finish up the line
            if (skip)
            {
                dialogueText.text = line;
                break;
            }

            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                //pull variables from ink into unity as story continues
                Globals.VarCheck(); 
                dialogueText.text += letter;
                yield return new WaitForSeconds(Globals.typingSpeed);
            }        
        }
        canContinueToNextLine = true;
        //display choices if any
        DisplayChoices();
        continueIcon.SetActive(true);
        skip = false;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
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
                case PLAYER_PORTRAIT_TAG:
                    portraitAnimatorPlayer.Play(tagValue);
                    break;
                case COMPANION_PORTRAIT_TAG:
                    portraitAnimatorCompanion.Play(tagValue);
                    break;
                case LAYOUT_TAG:
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
    public IEnumerator SelectFirstChoice()
    {
        //event system requires we clear it first, then wait for at least one frame before we set current select obj
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {   
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
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

    public void GiveEssence()
    {
        //if give essence variable in ink file == true
        //set visible/active their corresponding essence
        //(seralize related essence to demon) so we dont have to have another whole ass script for it
    }
}
