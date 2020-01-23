using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPOIS.MVC.Model
{
    class FiguraI : Figura
    {
        private const char NOME = 'I';
        private int _x, _y;
        private int _rotazione;
        private bool _fissata;
        private Image _sprite;

        // Forme della figura I 
        private int[,] _forma0 = new int[4, 1]
        {
            {1},
            {1},
            {1},
            {1}
        };

        private int[,] _forma90 = new int[1, 4]
        {
            {1, 1, 1, 1}
        };


        /// <summary>
        /// Costruttore
        /// </summary>
        public FiguraI()
        {
            this._x = 4;
            this._y = 0;
            this._rotazione = 0;
            this._fissata = false;
            try
            {
                this._sprite = TetrisPOIS.Properties.Resources.Figura_I;
            }
            catch
            {
                new ResourceNotFoundException("Figura_I");
            }
        }

        /// <summary>
        /// Metodo per ruotare la figura
        /// </summary>
        public override void Ruota()
        {
           
            // Incremento la rotazione della figura
            _rotazione++;

            // La rotazione ha un ciclo che va da 0 a 3
            if (_rotazione > 3)
                _rotazione = 0;

            // Capovolgo l'immagine della figura
            _sprite.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Cambio le coordinate in base alla rotazione
            switch (_rotazione)
            {
                case 0:
                    _y -= 2;
                    _x++;
                    break;
                case 1:
                    _y++;
                    _x--;
                    break;
                case 2:
                    _x += 2;
                    _y--;
                    break;
                case 3:
                    _x -= 2;
                    _y += 2;
                    break;
            }
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
            int[,] forma = null;

            rotazione++;
            if (rotazione > 3)
                rotazione = 0;

            switch (rotazione)
            {
                case 0:
                    forma = _forma0;
                    break;
                case 1:
                    forma = _forma90;
                    break;
                case 2:
                    forma = _forma0;
                    break;
                case 3:
                    forma = _forma90;
                    break;
            }

            return forma;
        }

        /// <summary>
        /// Metodo per identificare la coordinata X della prox rotazione
        /// </summary>
        /// <returns>
        /// La coordinata X della prox rotazione
        /// </returns>
        public override int XProssimaRotazione()
        {
            int xProx = _x;
            int rotazioneProx = _rotazione;

            rotazioneProx++;
            if (rotazioneProx > 3)
                rotazioneProx = 0;

            switch (rotazioneProx)
            {
                case 0:
                    xProx++;
                    break;
                case 1:
                    xProx--;
                    break;
                case 2:
                    xProx += 2;
                    break;
                case 3:
                    xProx -= 2;
                    break;
            }
            return xProx;
        }

        /// <summary>
        /// Metodo per identificare la coordinata Y della prox rotazione
        /// </summary>
        /// <returns>
        /// La coordinata Y della prox rotazione
        /// </returns>
        public override int YProssimaRotazione()
        {
            int yProx = _y;
            int proxRotazione = _rotazione;

            proxRotazione++;
            if (proxRotazione > 3)
                proxRotazione = 0;

            switch (proxRotazione)
            {
                case 0:
                    yProx -= 2;
                    break;
                case 1:
                    yProx++;
                    break;
                case 2:
                    yProx--;
                    break;
                case 3:
                    yProx += 2;
                    break;
            }
            return yProx;
        }

        /// <summary>
        /// Get della forma
        /// </summary>
        public override int[,] Forma
        {
            get
            {
                int[,] forma = null;

                switch (_rotazione)
                {
                    case 0:
                        forma = _forma0;
                        break;
                    case 1:
                        forma = _forma90;
                        break;
                    case 2:
                        forma = _forma0;
                        break;
                    case 3:
                        forma = _forma90;
                        break;
                }
                return forma;
            }
        }

        /// <summary>
        /// Get del nome
        /// </summary>
        public char Nome
        {
            get{ return NOME; }
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
        /// Get della rotazione
        /// </summary>
        public override int Rotazione
        {
            get { return _rotazione; }
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
