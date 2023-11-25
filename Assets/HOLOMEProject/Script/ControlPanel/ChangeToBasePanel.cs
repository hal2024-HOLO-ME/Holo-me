using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToBasePanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToBaseControlPanel()
    {
        BaseControlPanel.SetActive(true);
        ColorControlPanel.SetActive(false);
    }
}
