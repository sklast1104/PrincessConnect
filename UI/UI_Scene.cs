using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Jun.Manage;

namespace Jun.UI
{
    public class UI_Scene : UI_Base
    {
        public override void Init()
        {
            Manager.UI.SetCanvas(gameObject, false);
        }
    }
}
