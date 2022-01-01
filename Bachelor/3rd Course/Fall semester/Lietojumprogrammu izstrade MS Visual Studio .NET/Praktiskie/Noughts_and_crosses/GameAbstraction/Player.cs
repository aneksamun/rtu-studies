using System;
using System.Collections.Generic;
using System.Text;

namespace NougthAndCroses.GameAbstraction {
    public class Player {
        /// <summary>
        /// Keeps current player name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Indicates whether player is cross player.
        /// </summary>
        public bool IsCrossPlayer { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Player() { }

        /// <summary>
        /// Indicates player remark.
        /// </summary>
        public char Remark { get; set; } 

        /// <summary>
        /// Constructor with parametres
        /// </summary>
        /// <param name="isCrossPlayer"></param>
        public Player(bool isCrossPlayer) {
            IsCrossPlayer = isCrossPlayer;
        }
    }
}
