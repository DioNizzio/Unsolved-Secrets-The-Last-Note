using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour, IInteractable
{

    private Animator mAnimator;

    private bool neverOpened;

    public GameObject fixedKey;
    

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
                        transform.parent.GetComponent<AudioSource>().Play();
                        return true;
                    } 
                }
            }
            else{
                if(mAnimator.GetBool("isClosed")==true){
                    mAnimator.SetTrigger("TrOpen");
                    mAnimator.SetBool("isClosed", false);
                    transform.parent.GetComponent<AudioSource>().Play();
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
