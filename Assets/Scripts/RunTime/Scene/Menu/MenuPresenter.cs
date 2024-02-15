using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

namespace MCL.RunTime.Menu
{
    //最低限の情報以上、その他すべて
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;

        private void Start()
        {
            menuView.ReturnButtonClick
                .Subscribe(_ => UniTask.Void(async token => 
                {
                    await SceneManager.LoadSceneAsync("PlayerWindow", LoadSceneMode.Additive).WithCancellation(token);
                    await SceneManager.UnloadSceneAsync("MenuScene").WithCancellation(token);
                }, destroyCancellationToken))
                .AddTo(destroyCancellationToken);
        }
    }
}
