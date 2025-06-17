namespace Ex02
{
    public class Guess
    {
        private string m_Guess = "";
        private string m_Result = "";

        public string GuessValue
        {
            get { return m_Guess; }
        }
        public string Result
        {
            get { return m_Result; }
        }

        public Guess (string i_Guess)
        {
            m_Guess = i_Guess;
        }
        public bool CompareWithSecret(Secret i_Secret)
        {
            int numOfHits = 0;
            int numOfNear = 0;
            int numOfMisses = 0;
            for (int i = 0; i < Settings.m_NumOfPins; i++)
            {
                char currentChar = m_Guess[i];
                int index = i_Secret.SecretValue.IndexOf(currentChar);
                if (index == i)
                {
                    numOfHits++;
                }
                else if (index != -1)
                {
                    numOfNear++;
                }
                else
                {
                    numOfMisses++;
                }
            }
            // $G$ DSN-999 (-5) Feedback should be represented as a collection of feedback options (enum) and not as a string or char.
            // The logic layer doesn't suppose know that the UI present the hits \ misses as 'V' or 'X'

            for (int i = 0; i < numOfHits; i++)
            {
                m_Result += "V";
            }

            for (int i = 0; i < numOfNear; i++)
            {
                m_Result += "X";
            }

            for (int i = 0; i < numOfMisses; i++)
            {
                m_Result += " ";
            }

            return numOfHits == Settings.m_NumOfPins;
        }

        public static bool ContainsOnlyValidLetters(string i_Guess)
        {
            bool result = true;
            foreach (var charecther in i_Guess)
            {
                // $G$ CSS-999 (-5) Avoid hardcoded values – use constants or readonly fields instead.
                if (charecther < 'A' || charecther > 'H')
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static bool CheckIfHasRepeatingChars(string i_Guess)
        {
            bool result = false;
            foreach (char c in i_Guess)
            {
                result = i_Guess.IndexOf(c) != i_Guess.LastIndexOf(c);
                if (result == true)
                {
                    break;
                }
            }

            return result;
        }

        internal static bool IsInCorrectLength(string guess)
        {
            return guess.Length == Settings.m_NumOfPins;
        }
    }
}