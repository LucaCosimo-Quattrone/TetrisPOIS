using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPOIS.MVC.Model
{
    class FiguraO : Figura
    {
        private const char NOME = 'O';
        private int _x, _y;
        private int _rotazione;
        private bool _fissata;
        private Image _sprite;

        // Forma della figura
        private int[,] _forma0 = new int[2, 2]
        {
            {2, 2},
            {2, 2}
        };

            
        /// <summary>
        /// Costruttore
        /// </summary>
        public FiguraO()
        {
            this._x = 4;
            this._y = 0;
            this._rotazione = 0;
            this._fissata = false;
            try
            {
                this._sprite = TetrisPOIS.Properties.Resources.Figura_O;
            }
            catch
            {
                new ResourceNotFoundException("Figura_O");
            }
        }

        /// <summary>
        /// Metodo per ruotare la figura
        /// </summary>
        public override void Ruota()
        {
            _rotazione = 0;
        }

        /// <summary>
        /// Get della rotazione
        /// </summary>
        public override int Rotazione
        {
            get { return _rotazione; }
        }

        /// <summary>
        /// Get della forma
        /// </summary>
        public override int[,] Forma
        {
            get { return _forma0; }
        }

        /// <summary>
        /// Metodo per identificare la forma della prossima rotazione
        /// </summary>
        /// <param name="rotazione">Rotazione che si vuole eseguire</param>
        /// <returns>
        /// La forma della figura ruotata
        /// </returns>
        public override int[,] ProssimaRotazione(int rotazione)
        {
            return _forma0;
        }

        /// <summary>
        /// Metodo per identificare la coordinata X della prox rotazione
        /// </summary>
        /// <returns>
        /// La coordinata X della prox rotazione
        /// </returns>
        public override int XProssimaRotazione()
        { 
            return _x;
        }

        /// <summary>
        /// Metodo per identificare la coordinata Y della prox rotazione
        /// </summary>
        /// <returns>
        /// La coordinata Y della prox rotazione
        /// </returns>
        public override int YProssimaRotazione()
        {
            return _y;
        }

        /// <summary>
        /// Get del nome
        /// </summary>
        public char Nome
        {
            get { return NOME; }
        }

        /// <summary>
        /// Get/Set della coordinata X
        /// </summary>
        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Get/Set della coordinata Y
        /// </summary>
        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Get dell'immagine
        /// </summary>
        public override Image Sprite
        {
            get { return _sprite; }
        }

        /// <summary>
        /// Get/Set della proprietà "fissata"
        /// </summary>
        public override bool Fissata
        {
            get { return _fissata; }
            set { _fissata = value; }
        }
    }
}
