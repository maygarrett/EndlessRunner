using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugOnly : MonoBehaviour {

    private void Awake()
    {
        GameObject.SetActive(Debug.isDebugBuilt);
    }

    // to withhold things from dev builds, deactivate it if bool Debug.isDebugBuilt is false. Debug.isDebugBuilt is true when in inspector and using development build options, and is false when using release options
    // GameObject.SetActive(Debug.isDebugBuilt);      // use in awake
    // make a separate script with the line above and it will set each thing the script is attached to to inactive when not in debug mode

    // to make sure things get fully disables, destroy them instead
    /*if(!Debug.isDebugBuilt)
    {
        Destroy(gameObject);
    }*/
}
