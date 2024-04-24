using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour, IInteractable
{

    private Animator mAnimator;

    private bool neverOpened;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        neverOpened = true;
    }

    public bool Interact(GameObject currentObj)
    {
        if (mAnimator != null){
            if(neverOpened && currentObj!=null){
                if(currentObj.name.Contains("key")){
                    neverOpened = false;
                    mAnimator.SetTrigger("TrOpen");
                    mAnimator.SetBool("isClosed", false);
                    return true;
                } 
            }
            else{
                if(mAnimator.GetBool("isClosed")==true){
                    mAnimator.SetTrigger("TrOpen");
                    mAnimator.SetBool("isClosed", false);
                    return true;
                }
                else{
                    mAnimator.SetTrigger("TrClose");
                    mAnimator.SetBool("isClosed", true);
                    return true;
                }
            }

        }
        return false;
    }
}
