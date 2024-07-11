using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour, IInteractable
{

    private Animator mAnimator;

    private bool neverOpened;

    public GameObject fixedKey;
    
    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = transform.parent.GetComponent<Animator>();
        neverOpened = true;
    }

    public bool Interact(GameObject currentObj)
    {
        if (mAnimator != null){
            if(neverOpened){
                if(currentObj!=null){
                    if(currentObj.name.Contains("Key")){
                        fixedKey.SetActive(true);
                        Destroy(currentObj);
                        neverOpened = false;
                        mAnimator.SetTrigger("TrOpen");
                        mAnimator.SetBool("isClosed", false);
                        GetComponent<AudioSource>().Play();
                        uIManager.ShowDialogue("Cool bar. These are very expensive bottles of wine. I do love the taste of a good sweet bottle of wine, even after everything I lost.");
                        return true;
                    } 
                }
            }
            else{
                if(mAnimator.GetBool("isClosed")==true){
                    mAnimator.SetTrigger("TrOpen");
                    mAnimator.SetBool("isClosed", false);
                    GetComponent<AudioSource>().Play();
                    return false;
                }
                else{
                    mAnimator.SetTrigger("TrClose");
                    mAnimator.SetBool("isClosed", true);
                    return false;
                }
            }

        }
        return false;
    }
}
