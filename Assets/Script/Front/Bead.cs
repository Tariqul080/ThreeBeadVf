using UnityEngine.UI;
using UnityEngine;
using GameLogic;

namespace ThreeBeads
{
    public class Bead : MonoBehaviour
    {
        [SerializeField] private Button Button = null;

        internal int bead = -1;
        internal int currentPos = -1;
        private void Start()
        {
            Button.onClick.AddListener(delegate
            {
                ClickButton();
            });
        }

        private void ClickButton()
        {
            if (bead==LogicData.DownBead && LogicData.isBottomPlayerMove==true)
            {
                Data.SelectedBead = this;
            }
            else if (bead==LogicData.TopBead && LogicData.isBottomPlayerMove == false)
            {
                Data.SelectedBead = this;
            }
            else
            {
                Data.SelectedBead = null;
            }
        }

      

    }

}

