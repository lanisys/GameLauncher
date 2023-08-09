using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher
{
    static class Const
    {
        public const char cFM = (char)254; // separateur de champs dans les requetes serveur
        public const char cVM = (char)253; // separateur a l'interieur d'un champ
        public const char cPipe = '|';
        public const byte bFM = 254;
        public const byte bVM = 253;
        public const byte bPipe = 124;

        public const string Exe = @"\Exovival Zombie.exe";
    }
}
