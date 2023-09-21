using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] GameObject[] Rope_Center;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if(hit2D.collider != null)
            {
                if(hit2D.collider.CompareTag("Center1"))
                {
                    hit2D.collider.gameObject.SetActive(false);
                    //ball.HingeControl["Center1"].enabled = false;
                    foreach (var item in Rope_Center)
                    {
                        if(item.GetComponent<RopeManagement>().hingeName =="Center1")
                        {
                            foreach (var item2 in item.GetComponent<RopeManagement>().linkPool)
                            {
                                item2.SetActive(false);
                            }
                        }
                    }
                }
                else if(hit2D.collider.CompareTag("Center2"))
                {
                    hit2D.collider.gameObject.SetActive(false);
                    //ball.HingeControl["Center2"].enabled = false;
                    foreach (var item in Rope_Center)
                    {
                        if(item.GetComponent<RopeManagement>().hingeName =="Center2")
                        {
                            foreach (var item2 in item.GetComponent<RopeManagement>().linkPool)
                            {
                                item2.SetActive(false);
                            }
                        }
                    }
                }
            }
            
        }
        
    }
}
