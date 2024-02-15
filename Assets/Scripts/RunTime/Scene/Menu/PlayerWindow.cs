using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

namespace MCL.RunTime.PlayerWindow
{
    public class PlayerWindow : MonoBehaviour
    {
        [SerializeField]
        private Button returnBtn = null;

        private void Start()
        {
            returnBtn.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            StartCoroutine(SceneLoad());
        }

        private IEnumerator SceneLoad()
        {
            yield return SceneManager.LoadSceneAsync("PlayerWindow",LoadSceneMode.Additive);
            yield return SceneManager.UnloadSceneAsync("MenuScene");
        }
    }
}