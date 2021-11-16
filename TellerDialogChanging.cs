using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TellerDialogChanging : MonoBehaviour
{
    public List<string> dialog; //Keep a list of Dialog Texts - Write in component
    public Animator tellerAnimation; //Component to get Animator Parameters
    public List<GameObject> buttonChoices; //List of a Buttons to change. Set in Component.
    public List<AudioClip> audioClips; //List of Audio Clips. Set in Component.  Should be same order as Dialog.
    private AudioSource characterAudioSource; //Audio Source to Play Audio Clips.
    public int dialogOption = 0; //Default Dialog Option. *Note: Can make this -1 and increase it to zero when interact.
    public TMP_Text dialogBoxText; //Text Box for update dialog text. Set in Component.
    // Start is called before the first frame update
    void Start()
    {
        tellerAnimation = GetComponentInParent<Animator>();
        characterAudioSource = GetComponent<AudioSource>();
        ErrorChecking(); //Not needed, but helpful to make sure all components are grabbed
        dialogBoxText.text = "Teller: " + dialog[dialogOption]; 
        characterAudioSource.PlayOneShot(audioClips[dialogOption]);

    }
    public void OnChoiceOnePress()
    {
        
        buttonChoices[dialogOption].SetActive(false);
        //Increase Dialog Option
        dialogOption++;
        if(dialogOption > dialog.Count - 1)
        {
            dialogOption = 0;
        }
        //Change Text
        dialogBoxText.text = "Teller: " + dialog[dialogOption]; 
        
        //Change Animation
        tellerAnimation.SetInteger("dialogPhrase",dialogOption);
        
        //Play Audio
        characterAudioSource.PlayOneShot(audioClips[dialogOption]);
        //Activate Next Buttons
        buttonChoices[dialogOption].SetActive(true);
       
    }

    private void Update() {
        if(!characterAudioSource.isPlaying)
        {
            tellerAnimation.SetBool("isTalking",false);

        }   
        else
        {
            tellerAnimation.SetBool("isTalking",true);
        } 
    }

    private void ErrorChecking()
    {
        if(dialog.Count <= 0)
        {
            Debug.LogError("There are no Dialog Text Strings inputted in the TellerDialogChanging Component.");
        }

        if(dialogBoxText == null)
        {
            Debug.LogError("No TMP Text Box attached to component.");
        }
        
        if(audioClips.Count <= 0)
        {
            Debug.LogError("No Audio Clips Found.");
        }

        if(buttonChoices.Count <= 0)
        {
            Debug.LogError("No button choices found. Attach them to this component.");
        }
    }

}
