using System;
using System.Linq;

namespace Ex02
{
    public class Secret
    {
        // $G$ DSN-999 (-3) Sequence of elements should be represented as sequence of enum values and not as a string or char.
        private string m_Secret = "";

        public string SecretValue
        {
            get { return m_Secret; }
        }

        public void GenerateSecret()
        {
            // $G$ NTT-007 (-10) There's no need to re-instantiate the Random instance each time it is used.
            Random random = new Random();
            while (m_Secret.Length < Settings.m_NumOfPins)
            {
                char randomChar = (char)('A' + random.Next(Settings.m_NumOfOptions));
                if (!m_Secret.Contains(randomChar))
                {
                    m_Secret += randomChar;
                }
            }
        }

        internal void ClearSecret()
        {
            m_Secret = "";
        }
    }
}