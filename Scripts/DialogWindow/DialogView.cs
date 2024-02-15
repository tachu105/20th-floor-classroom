using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MCL.RunTime.DialogWindow
{
    /// <summary>
    /// ダイアログのViewer
    /// </summary>
    public class DialogView : MonoBehaviour
    {
        [SerializeField, Tooltip("ダイアログのボタン")]
        private Button[] m_dialogButtons = null;

        [SerializeField, Tooltip("ダイアログのボタンのテキスト")]
        private TextMeshProUGUI[] m_dialogButtonTMPs = null;

        [SerializeField, Tooltip("ダイアログのタイトルテキスト")]
        private TextMeshProUGUI m_dialogTitle = null;

        [SerializeField ,Tooltip("ダイアログのメインテキスト")]
        private TextMeshProUGUI m_mainMessage = null;

        //ボタンが1つの場合の配置
        private readonly int singleButtonPosX = 0;

        //ボタンが2つの場合の配置
        private readonly int[] doubleButtonPosX = { -80, 80 };

        //ボタンが3つの場合の配置
        private readonly int[] tripleButtonPosX = { -150, 0, 150 };


        /// <summary>
        /// ButtonのButtonコンポーネント
        /// </summary>
        public Button[] dialogButtons
        {
            get
            {
                return m_dialogButtons;
            }
        }

        /// <summary>
        /// ダイアログのタイトルのテキスト
        /// </summary>
        public string dialogTitleText
        {
            set => m_dialogTitle.text = value;
        }

        /// <summary>
        /// ダイアログのメインメッセージのテキスト
        /// </summary>
        public string mainMessageText
        {
            set => m_mainMessage.text = value;
        }

        /// <summary>
        /// Buttonのテキスト
        /// </summary>
        public string[] dialogButtonTexts
        {
            set
            {
                for (byte i = 0; i < value.Length; i++)
                {
                    m_dialogButtonTMPs[i].text = value[i];
                }
            }
        }

        /// <summary>
        /// Buttonの色
        /// </summary>
        public Color[] dialogButtonColors
        {
            set
            {
                for (byte i = 0; i < value.Length; i++)
                {
                    m_dialogButtons[i].targetGraphic.color = value[i];
                }
            }
        }

        /// <summary>
        /// 使用するボタンの個数
        /// </summary>
        public byte dialogButtonCount
        {
            set
            {
                switch (value)
                {
                    case 1:
                        m_dialogButtons[0].transform.localPosition = new Vector3(singleButtonPosX, 0, 0);

                        m_dialogButtons[0].gameObject.SetActive(true);
                        m_dialogButtons[1].gameObject.SetActive(false);
                        m_dialogButtons[2].gameObject.SetActive(false);
                        break;
                    case 2:
                        m_dialogButtons[0].transform.localPosition = new Vector3(doubleButtonPosX[0], 0, 0);
                        m_dialogButtons[1].transform.localPosition = new Vector3(doubleButtonPosX[1], 0, 0);

                        m_dialogButtons[0].gameObject.SetActive(true);
                        m_dialogButtons[1].gameObject.SetActive(true);
                        m_dialogButtons[2].gameObject.SetActive(false);
                        break;
                    case 3:
                        m_dialogButtons[0].transform.localPosition = new Vector3(tripleButtonPosX[0], 0, 0);
                        m_dialogButtons[1].transform.localPosition = new Vector3(tripleButtonPosX[1], 0, 0);
                        m_dialogButtons[2].transform.localPosition = new Vector3(tripleButtonPosX[2], 0, 0);

                        m_dialogButtons[0].gameObject.SetActive(true);
                        m_dialogButtons[1].gameObject.SetActive(true);
                        m_dialogButtons[2].gameObject.SetActive(true);
                        break;

                    default:
                        throw new ArgumentException("ダイアログボタンの数は3つ以内としてください．");
                }
            }
        }
    }
}
