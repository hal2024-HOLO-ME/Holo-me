using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public GameObject Food;
    public GameObject FoodStage;
    public GameObject Shower;

    public void OnClickFoodButton()
    {
        Food.SetActive(true);
        FoodStage.SetActive(true);
    }

    public void OnClickShowerButton()
    {
        Shower.SetActive(true);
    }
}
