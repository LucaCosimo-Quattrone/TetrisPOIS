using System;

namespace TetrisPOIS.MVC.Model
{
    class Terreno
    {
        
        // Dimensioni della griglia
        public const int X = 10;
        public const int Y = 16;

        private static int[,] _campo = new int[Y, X];

        /// <summary>
        /// Costruttore
        /// </summary>
        public Terreno()
        {
            for (int i = 0; i < Y; i++)
                for (int j = 0; j < X; j++)
                    _campo[i, j] = 0;
        }

        /// <summary>
        /// Get/Set del campo di gioco
        /// </summary>
        public int[,] Campo
        {
            get { return _campo; }
            set { _campo = value; }
        }

    }
}

