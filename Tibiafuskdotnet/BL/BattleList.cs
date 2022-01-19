using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibiafuskdotnet.BL;

namespace Tibiafuskdotnet.BL
{
    class BattleList
    {


        public Client client;

        /// <summary>
        /// Create a battlelist object.
        /// </summary>
        /// <param name="c"></param>
        public BattleList(Client c)
        {
            client = c;
        }


/*
        public IEnumerable<Creature> GetCreatures()
        {
            for (uint i = BattleList.Start; i < BattleList.End; i += BattleList.StepCreatures)
            {
                if ( (MemoryReader.BattleListconvert + Creature.DistanceIsVisible) == 1)
                    yield return new Creature(client, i);
            }
        }*/






        /// <summary>
        /// Distance between creatures.
        /// </summary>
        public static uint StepCreatures; // A8 before 8.70

        /// <summary>
        /// Maximum number of creatures.
        /// </summary>
        public static uint MaxCreatures; // it was 250 before 8.62

        /// <summary>
        /// Start of the battle list.
        /// </summary>
        public static uint Start;

        /// <summary>
        /// End of the battle list.
        /// </summary>
        public static uint End;
    }
}
