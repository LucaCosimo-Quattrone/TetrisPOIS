using System.Drawing;

namespace TetrisPOIS.MVC.Model
{
    class FiguraZ : Figura
    {
        private const char NOME = 'Z';
        private int _x, _y;
        private int _rotazione;
        private bool _fissata;
        private Image _sprite;

        // Forme della figura
        private int[,] _forma0 = new int[2, 3]
{
            {5, 5, 0},
            {0, 5, 5}
};

        private int[,] _forma90 = new int[3, 2]
        {
            {0, 5},
            {5, 5},
            {5, 0}
        };

        /// <summary>
        /// Costruttore
        /// </summary>
        public FiguraZ()
        {
            this._x = 3;
            this._y = 0;
            this._rotazione = 0;
            this._fissata = false;
            try
            {
                this._sprite = TetrisPOIS.Properties.Resources.Figura_Z;
            }
            catch
            {
                new ResourceNotFoundException("Figura_Z");
            }
            
        }

        /// <summary>
        /// Metodo per ruotare la figura
        /// </summary>
        public override void Ruota()
        {
            _rotazione++;
            if (_rotazione > 3)
                _rotazione = 0;
            _sprite.RotateFlip(RotateFlipType.Rotate90FlipNone);

            switch (_rotazione)
            {
                case 0:
                    break;
                case 1:
                    _x++;
                    break;
                case 2:
                    _x--;
                    _y++;
                    break;
                case 3:
                    _y--;
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
                    break;
                case 1:
                    xProx++;
                    break;
                case 2:
                    xProx--;
                    break;
                case 3:
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
            int rotazioneProx = _rotazione;

            rotazioneProx++;
            if (rotazioneProx > 3)
                rotazioneProx = 0;

            switch (rotazioneProx)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    yProx++;
                    break;
                case 3:
                    yProx--;
                    break;
            }
            return yProx;
        }

        /// <summary>
        /// Get dell'immagine
        /// </summary>
        public override Image Sprite
        {
            get { return _sprite; }
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
        /// Get/Set della proprietà "fissata"
        /// </summary>
        public override bool Fissata
        {
            get { return _fissata; }
            set { _fissata = value; }
        }
    }
}
