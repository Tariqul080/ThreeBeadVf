using UnityEngine;
using UnityEngine.UI;
using GameLogic;
using DG.Tweening;

namespace ThreeBeads
{
    public class PlayGame : MonoBehaviour
    {
        [SerializeField] private Bead Bead = null;
        [SerializeField] private Transform BeadParent = null;
        [SerializeField] private Sprite TopBead = null;
        [SerializeField] private Sprite DownBead = null;

        internal static PlayGame Instance = null;
        internal readonly GameLogics logic = new GameLogics();

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        private void Start()
        {
            DrowBoard();
        }

        private void DrowBoard()
        {
            int counter = 0, counterPoss = -1;
            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    counterPoss++;
                    int bead = LogicData.BoardFormet[i, j];
                    if (bead==LogicData.Empty)
                    {
                        continue;
                    }
                    Bead script = Instantiate(Bead, BeadParent);
                    script.transform.localPosition = GameManejer.Instance.GetPoint(counterPoss).localPosition;
                    script.GetComponent<Image>().sprite = bead == LogicData.TopBead ? TopBead : DownBead;
                    script.bead = bead;
                    script.currentPos = counterPoss;
                    counter++;
                }
            }
        }
        internal void MoveBead(int index)
        {
            if (Data.SelectedBead!=null)
            {
                
                bool rightPosition = logic.MoveBeadRight(Data.SelectedBead.currentPos, index);
                if (rightPosition == true)
                {
                    Data.SelectedBead.transform.DOLocalMove(GameManejer.Instance.GetPoint(index).localPosition, LogicData.MoveTime).OnComplete(() =>
                    {
                        Data.SelectedBead.currentPos = index;
                        GameManejer.Instance.SetTurnText();
                        Data.SelectedBead = null;
                        GameOverCheck(); // check game over after complete a move.
                    });
                }
            }
        }

        private void GameOverCheck()
        {
            int endResult = logic.IsGameOver(LogicData.BoardFormet); // gameover 1 and 2
            if (endResult == 1 || endResult == 2)
            {
                if (endResult == 1)
                {
                    GameManejer.Instance.TurnText.SetActive(false);
                    GameManejer.Instance.GameBord.SetActive(false);
                    GameManejer.Instance.TopPW.SetActive(true);
                }
                else
                {
                    GameManejer.Instance.TurnText.SetActive(false);
                    GameManejer.Instance.GameBord.SetActive(false);
                    GameManejer.Instance.DownPW.SetActive(true);
                }
            }
        }
    }
}
