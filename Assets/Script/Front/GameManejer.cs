using UnityEngine;
using UnityEngine.UI;
using GameLogic;

namespace ThreeBeads
{
    public class GameManejer : MonoBehaviour
    {
        [SerializeField] private Button[] AllPoints = null;
        [SerializeField] public GameObject TurnText = null;
        [SerializeField] private Transform TopMove = null;
        [SerializeField] private Transform DownMove = null;
        [SerializeField] public GameObject TopPW = null;
        [SerializeField] public GameObject DownPW = null;
        [SerializeField] public GameObject GameBord = null;

        private readonly int[] Index = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        internal static GameManejer Instance = null;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
        private void Start()
        {
            for (int i = 0; i < 9; i++)
            {
                int a = Index[i];
                AllPoints[a].onClick.AddListener(delegate
                {
                    ClickButton(a);
                });
            }
        }
        private void ClickButton(int index)
        {
            PlayGame.Instance.MoveBead(index);
        }
        internal Transform GetPoint(int position)
        {
            return AllPoints[position].transform;
        }
        internal void SetTurnText()
        {
            if (LogicData.isBottomPlayerMove)
            {
                TurnText.transform.localPosition = DownMove.localPosition;
            }
            else
            {
                TurnText.transform.localPosition = TopMove.localPosition;
            }
        }

    }

}

