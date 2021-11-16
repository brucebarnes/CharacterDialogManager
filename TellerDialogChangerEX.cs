using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TellerDialogChangerEX : MonoBehaviour
{
    //Lists Needed
    public List<string> dialog;
    public List<GameObject> buttonChoices;
    public List<AudioClip> audioClips;

    //Component References
    public Animator tellerAnimation;
    private AudioSource characterAudioSource;
    public TMP_Text dialogBoxText;

    //Paramater Variables
    public int dialogOption = 0;
    public bool isTalking = false;
    public string characterName;

    // Start is called before the first frame update
    void Start()
    {
        //Get References
        tellerAnimation = GetComponentInParent<Animator>();
        characterAudioSource =GetComponent<AudioSource>();

        //Set First text and Play first Audio
        dialogBoxText.text = characterName + ": " +  dialog[dialogOption];
        characterAudioSource.PlayOneShot(audioClips[dialogOption]);
    }

    public void OnChoiceOnePress()
    {
        //Change Buttons to Inactive
        buttonChoices[dialogOption].SetActive(false);
        //Keep Track of Dialog Option
        dialogOption++;
        if(dialogOption > dialog.Count - 1)
        {
            dialogOption = 1;
        }
        //Change Text
        dialogBoxText.text = characterName + ": " +  dialog[dialogOption];
        //Change Animation
        tellerAnimation.SetInteger("dialogOption",dialogOption);
        //Play Audio
        characterAudioSource.PlayOneShot(audioClips[dialogOption]);
        //Activate Next Buttons
        buttonChoices[dialogOption].SetActive(true);

    }


    // Update is called once per frame
    void Update()
    {
        //Keep track of IsTalking
        if(characterAudioSource.isPlaying)
        {
            isTalking = true;
            tellerAnimation.SetBool("isTalking",isTalking);
        }
        else
        {
            isTalking = false;
            tellerAnimation.SetBool("isTalking",isTalking);
        }

    }
}
