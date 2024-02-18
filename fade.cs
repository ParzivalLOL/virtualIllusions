using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{
    public Renderer fake;
    public Renderer real;
    public Renderer realH;
    public Renderer H;
    public GameObject tramp;
    public bool isMemo = false;
    // Start is called before the first frame update
    void Start()
    {
        fake.enabled = false;
        H.enabled = false;
        
        Invoke("disappear", 5f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void disappear() {
        isMemo = true;
        real.enabled = false;
        realH.enabled = false;
        fake.enabled = true;
        H.enabled = true;
        tramp.GetComponent<SpriteRenderer>().enabled = false;


    }
    
}
