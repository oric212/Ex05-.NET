// $G$ RUL-005 (-20) Solution file name 'B25 Ex02 Ori 206534018 Omri 209017383' does not match the required format.
// $G$ DSN-007 (-5) Logic should be encapsulated behind a single class exposed to the UI, even if internally composed of multiple components.

namespace Ex02
{
    internal class Program
    {
        public static void Main()
        {
            // $G$ CSS-001 (-3) Local variable should be written in camelCase
            // $G$ CSS-027 (-2) Missing blank line after variable declarations.
            GameManager GM = new GameManager();
            GM.GameLoop();
        }
    }
}
