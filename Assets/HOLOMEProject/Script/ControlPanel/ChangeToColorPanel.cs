using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToColorPanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    // Start is called before the first frame update
    void Start()
    {
        ColorControlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToColorControlPanel()
    {
        ColorControlPanel.SetActive(true);
        BaseControlPanel.SetActive(false);
    }
}
