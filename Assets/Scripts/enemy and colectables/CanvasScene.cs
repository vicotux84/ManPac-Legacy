using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScene : MonoBehaviour{
    public GameObject load_text;
    private void Awake() {
         StartCoroutine(LevelUI());
    }

  IEnumerator LevelUI(){
       load_text.SetActive(true);
        yield return new WaitForSeconds(8);
      load_text.SetActive(false);
      yield return new WaitForSeconds(2);
    }
}
