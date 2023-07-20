using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class deta : MonoBehaviour
    {
        public NewBehaviourScript script;
        public KeyCode none;
        public bool x;
        void Start()
        {
            x = false;
            // gameObject.GetComponent<CanvasGroup>().alpha = 0;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(none))
            {
                x = !x;
                gameObject.GetComponent<CanvasGroup>().blocksRaycasts = !gameObject.GetComponent<CanvasGroup>().blocksRaycasts;
               script.Mouse(!x);
            }
            if (!x)
            {
                gameObject.GetComponent<CanvasGroup>().alpha = 0;
                Time.timeScale = 1;
            }
            else
            {
                gameObject.GetComponent<CanvasGroup>().alpha = 1;
                Time.timeScale = 0;
            }

        }
    }