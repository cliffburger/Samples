using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace BowlingByContract.Game
{
    public class BowlingGame
    {
        [ContractInvariantMethod]
	    private void OK()
	    {
		    Contract.Invariant(Score >=0);
	    }

        public int Score { get; private set; }

        public void Bowl(int pinsKnockedDown)
        {
            Contract.Requires(pinsKnockedDown >= 0, "Whoa, how did you manage to knock down a negative number of pins? Did you knock a few back up?.");
            Contract.Requires(pinsKnockedDown <= 10, "There are only 10 pins.");

            Score += pinsKnockedDown;
        }

        public void LegacyBowl(int pinsKnockedDown)
        {
            if(pinsKnockedDown < 0)
            {
                throw new ArgumentException("pinKnockedDown");
            }
            Contract.EndContractBlock();
        }

        public void SetScore(int score)
        {
            Score = score;
        }
    }
}
