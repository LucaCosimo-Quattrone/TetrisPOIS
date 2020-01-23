using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPOIS
{
    public abstract class Figura
    {
        /// <summary>
        /// Get della forma
        /// </summary>
        public abstract int[,] Forma
        {
            get;
        }

        /// <summary>
        /// Get della rotazione
        /// </summary>
        public abstract int Rotazione
        {
            get;
        }

        /// <summary>
        /// Get/Set della coordinata X
        /// </summary>
        public abstract int X
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set della coordinata Y
        /// </summary>
        public abstract int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set della proprietà "fissata"
        /// </summary>
        public abstract bool Fissata
        {
            get;
            set;
        }

        /// <summary>
        /// Get dell'immagine
        /// </summary>
        public abstract Image Sprite
        {
            get;
        }

        /// <summary>
        /// Metodo per identificare la coordinata X della prox rotazione
        /// </summary>
        /// <returns>
        /// La coordinata X della prox rotazione
        /// </returns>
        public abstract int XProssimaRotazione();

        /// <summary>
        /// Metodo per identificare la coordinata Y della prox rotazione
        /// </summary>
        /// <returns>
        /// La coordinata Y della prox rotazione
        /// </returns>
        public abstract int YProssimaRotazione();

        /// <summary>
        /// Metodo per identificare la forma della prossima rotazione
        /// </summary>
        /// <param name="rotazione">Rotazione che si vuole eseguire</param>
        /// <returns>
        /// La forma della figura ruotata
        /// </returns>
        public abstract int[,] ProssimaRotazione(int rotazione);

        /// <summary>
        /// Metodo per ruotare la figura
        /// </summary>
        public abstract void Ruota();
    }
}

