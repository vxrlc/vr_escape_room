/***
 * Author: Yunhan Li 
 * Any issue please contact yunhn.lee@gmail.com
 ***/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Valve.VR;

namespace VRKeyboard.Utils {
    public class KeyboardManager : MonoBehaviour {
        #region Public Variables
        [Header("User defined")]
        [Tooltip("If the character is uppercase at the initialization")]
        public bool isUppercase = false;
        public int maxInputLength;
        public GameManager gameManager;
        public GameObject winText;
        public Text passwordText;
        public GameObject comboText;
        public GameObject loseText;
        public GameObject screen;
        public GameObject leaderBoard;
            public GameObject endGameButtons;
      
   
        
        [Header("UI Elements")]
        public Text inputText;

        [Header("Essentials")]
        public Transform characters;
        #endregion

        #region Private Variables
        private string Input {
            get { return inputText.text;  }
            set { inputText.text = value;  }
        }

        private Dictionary<GameObject, Text> keysDictionary = new Dictionary<GameObject, Text>();

        private bool capslockFlag;
        #endregion

        #region Monobehaviour Callbacks
        private void OnEnable()
        {
            if (gameManager.winGame && gameManager.timer > 0)
            {
                winText.SetActive(true);
                comboText.SetActive(false);

            } else if (gameManager.timer <=0)
            {
                comboText.SetActive(false);
                loseText.SetActive(true);
                endGameButtons.SetActive(true);            }
            else
            {
                endGameButtons.SetActive(false);
                winText.SetActive(false);
                comboText.SetActive(true);
            }
        }
        private void Awake() {
            

            for (int i = 0; i < characters.childCount; i++) {
                GameObject key = characters.GetChild(i).gameObject;
                Text _text = key.GetComponentInChildren<Text>();
                keysDictionary.Add(key, _text);

                key.GetComponent<Button>().onClick.AddListener(() => {
                    GenerateInput(_text.text);
                });
            }

            capslockFlag = isUppercase;
            CapsLock();
        }
        #endregion

        #region Public Methods
        public void Backspace() {
            if (Input.Length > 0) {
                Input = Input.Remove(Input.Length - 1);
            } else {
                return;
            }
        }
       public void closeKeyboard()
        {
            gameObject.SetActive(false);
        }
       

        public void Clear() {
            Input = "";
        }
     
        public void Enter()
        {
          if (gameManager.winGame)
            {
                leaderBoard.GetComponent<leaderBoard>().SubmitButton();
                Invoke("loadMenu", 1.0f);
            } else
            {
                if (screen.GetComponent<screenUnlock>().enterPassword(inputText.text))
                {
                    passwordText.text = "Correct Password. Computer Unlocked";
                    Invoke("hideKeyboard", 1f);
                } else
                {
                    passwordText.text = "Inccorrect Password. Please try again.";
                }
                inputText.text = "";
            }
            
        }
        void loadMenu()
        {
            SteamVR_LoadLevel.Begin("menu");
        }
        private void hideKeyboard()
        {
            gameObject.SetActive(false);
        }
        public void CapsLock() {
            if (capslockFlag) {
                foreach (var pair in keysDictionary) {
                    pair.Value.text = ToUpperCase(pair.Value.text);
                }
            } else {
                foreach (var pair in keysDictionary) {
                    pair.Value.text = ToLowerCase(pair.Value.text);
                }
            }
            capslockFlag = !capslockFlag;
        }
        #endregion

        #region Private Methods
        public void GenerateInput(string s) {
            if (Input.Length > maxInputLength) { return; }
            Input += s;
        }

        private string ToLowerCase(string s) {
            return s.ToLower();
        }

        private string ToUpperCase(string s) {
            return s.ToUpper();
        }
        #endregion
    }
}