using System;
using Jun.Data;
using UnityEngine;

namespace Jun.Manage.Game
{
    public class RosterManager : MonoBehaviour
    {
        [SerializeField] private Character[] loster = new Character[5];

        public Character[] Loster
        {
            get { return loster; }
            private set { loster = value; }
        }
        
        private void Awake()
        {
            loster[0] = Manager.Resource.Load<Character>("Scriptable/Character/Kyouka");
            loster[1] = Manager.Resource.Load<Character>("Scriptable/Character/Kyaru");
            loster[2] = Manager.Resource.Load<Character>("Scriptable/Character/Kotkoro");
            loster[3] = Manager.Resource.Load<Character>("Scriptable/Character/Saren");
            loster[4] = Manager.Resource.Load<Character>("Scriptable/Character/Pecorinne");
        }
    }
}


