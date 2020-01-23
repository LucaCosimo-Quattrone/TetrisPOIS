using System;
using System.Diagnostics;
using System.Media;
using TetrisPOIS.MVC;
using TetrisPOIS.MVC.Model;

namespace TetrisPOIS
{
    /// <summary>
    /// Classe che contiene il codice effettivo del gioco
    /// </summary>
    class Gioco
    {
        // Elementi di gioco
        private Terreno _griglia;
        private EstrattoreFigura _estrattore = new EstrattoreFigura();
        private Figura _figuraCorrente = null, _figuraSuccessiva = null;
        private int _punteggio;
        private int _livello;
        private bool _inGioco = false;

        // Elementi sonori
        private SoundPlayer _gameOverFx;
        private SoundPlayer _lineaCompletaFx;
        private SoundPlayer _figuraBloccataFx;


        /// <summary>
        /// Costruttore
        /// </summary>
        public Gioco()
        {
            IniziaGioco();

            // Gestione caricamento immagini
            try
            {
                this._gameOverFx = new SoundPlayer(TetrisPOIS.Properties.Resources.game_over);
            }
            catch
            {
                new ResourceNotFoundException("Suono_GameOver");
            }
            try
            {
                this._lineaCompletaFx = new SoundPlayer(TetrisPOIS.Properties.Resources.linea_completa);
            }
            catch
            {
                new ResourceNotFoundException("Suono_LineaCompleta");
            }
            try
            {
                this._figuraBloccataFx = new SoundPlayer(TetrisPOIS.Properties.Resources.figura_bloccata);
            }
            catch
            {
                new ResourceNotFoundException("Suono_FiguraBloccata");
            }
        }
            
        /// <summary>
        /// Metodo per iniziare una partita
        /// </summary>
        public void IniziaGioco()
        {
            this._inGioco = true;
            this._griglia = new Terreno();
            this._punteggio = 0;
            this._livello = 1;

            GeneraFigura();
        }

        /// <summary>
        /// Metodo per generare una nuova figura
        /// e assegnarne una nuova a quella successiva
        /// </summary>
        public void GeneraFigura()
        {
            if (_inGioco)
            {
                if ((_figuraCorrente == null) && (_figuraSuccessiva == null))
                {
                    // Estraggo tutti e due le figure a inizio partita
                    _figuraCorrente = _estrattore.EstraiFigura();
                    _figuraSuccessiva = _estrattore.EstraiFigura();
                }
                else
                {
                    // A partita avviata switch delle figure e ne estraggo una successiva 
                    _figuraCorrente = _figuraSuccessiva;
                    _figuraSuccessiva = _estrattore.EstraiFigura();
                }
            }

        }

        /// <summary>
        /// Metodo per muovere verso il basso la
        /// figura corrente
        /// </summary>
        public bool MuoviGiu()
        {
            if (_inGioco)
            {
                // Controllo che la figura possa ancora muoversi altrimenti la fisso nella griglia
                if (((FiguraCorrente.Y + NumeroRigheFigura) < _griglia.Campo.GetLength(0)) && (PuoMuoversi(FiguraCorrente.X, FiguraCorrente.Y + 1)))
                {
                    FiguraCorrente.Y++;
                }
                else
                {
                    FissaFigura();
                    FiguraCorrente.Fissata = true;
                    LineaCompletata();
                }
            }

            // Se la seconda riga è occupata da un'altra figura allora sarà impossibile muoversi e sarà game over
            if ((_griglia.Campo[1, 3] != 0) || (_griglia.Campo[1, 4] != 0) || (_griglia.Campo[1, 5] != 0))
            {
                GameOver();
            }

            return FiguraCorrente.Fissata;
        } // DOPO WHITE BOX

        /// <summary>
        /// Metodo per muovere verso sinistra la
        /// figura corrente
        /// </summary>
        public void MuoviSinistra()
        {
            if (_inGioco)
            {
                // Controllo che la figura non sia al bordo della griglia
                if (FiguraCorrente.X > 0)
                {
                    if (PuoMuoversi(FiguraCorrente.X - 1, FiguraCorrente.Y))
                    {
                        FiguraCorrente.X--;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo per muovere verso destra la 
        /// figura corrente
        /// </summary>
        public void MuoviDestra()
        {
            if (_inGioco)
            {
                // Controllo che la figura non sia al bordo della griglia
                if ((FiguraCorrente.X + NumeroColonneFigura) < _griglia.Campo.GetLength(1))
                {
                    if (PuoMuoversi(FiguraCorrente.X + 1, FiguraCorrente.Y))
                    {
                        FiguraCorrente.X++;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo per ruotare la figura corrente
        /// </summary>
        /// <returns>
        /// Se la figura ha effettuato una rotazione o meno
        /// </returns>
        public bool RuotaFigura()
        {
            bool fatto = false;

            if (_inGioco)
            {
                if (PuoRuotare())
                {
                    _figuraCorrente.Ruota();
                    fatto = true;
                }
            }
            return fatto;
        }

        /// <summary>
        /// Metodo per far finire una partita
        /// </summary>
        private void GameOver()
        {
            this._inGioco = false;

            // Riproduco FX
            try
            {
                SuonoGameOver();
            }
            catch
            {
                new ResourceNotFoundException("Suono_GameOver");
            }
        }

        /// <summary>
        /// Metodo per accertarsi che la figura corrente
        /// possa muoversi in una determinata direzione
        /// (basso, sx, dx)
        /// </summary>
        /// <returns> 
        /// Se la figura puo muoversi
        /// </returns>
        private bool PuoMuoversi(int x, int y)
        {
            bool puoMuoversi = true;

            // Creo la matrice temporanea
            int[,] tempGriglia = _griglia.Campo;

            // Controllo se la figura ha spazio per muoversi
            for (int i = y, righe = 0; i < (y + NumeroRigheFigura); i++, righe++)
            {
                for (int j = x, colonne = 0; j < (x + NumeroColonneFigura); j++, colonne++)
                {
                    if ((tempGriglia[i, j] != 0) && (FiguraCorrente.Forma[righe, colonne] != 0))
                    {
                        puoMuoversi = false;
                    }
                        
                }
                    
            }

            return puoMuoversi;
        }

        /// <summary>
        /// Metodo per accertarsi che la figura corrente
        /// possa ruotare.
        /// </summary>
        /// <returns> 
        /// Se la figura puo ruotare 
        /// </returns>
        private bool PuoRuotare()
        {
            bool puoruotare = true;

            // Creo una matrice temporanea della figura a rotazione effetuata
            int[,] temp = _figuraCorrente.ProssimaRotazione(_figuraCorrente.Rotazione);

            // Ottengo le cordinate a rotazione effettuata
            int XProx = _figuraCorrente.XProssimaRotazione();
            int YProx = _figuraCorrente.YProssimaRotazione();

            // Controllo che la figura non esca dai bordi della griglia
            if ((XProx + temp.GetLength(1)) > _griglia.Campo.GetLength(1))
            {
                puoruotare = false;
            }
            else if ((YProx + temp.GetLength(0)) > _griglia.Campo.GetLength(0))
            {
                puoruotare = false;
            }
            else if (XProx < 0)
            {
                puoruotare = false;
            }
            else
            {
                // Controllo che non si sovrapponga a un'altra figura
                for (int i = YProx; i < (YProx + temp.GetLength(0)); i++)
                {
                    for (int j = XProx; j < (XProx + temp.GetLength(1)); j++)
                    {
                        if (_griglia.Campo[i, j] != 0)
                        {
                            puoruotare = false;
                        }
                    }
                }              
            }

            return puoruotare;
        }

        /// <summary>
        /// Metodo per "fissare" una figura alla griglia di gioco
        /// </summary>
        private void FissaFigura()
        {
            // Identifico le coordinate attuali della figura nella griglia, scorro tutta la figura
            // e assegno alla griglia i valori della figura corrente
            for (int i = FiguraCorrente.Y, righe = 0; i < (FiguraCorrente.Y + NumeroRigheFigura); i++, righe++)
            {
                for (int j = FiguraCorrente.X, colonne = 0; j < (FiguraCorrente.X + NumeroColonneFigura); j++, colonne++)
                {
                    if (FiguraCorrente.Forma[righe, colonne] != 0)
                    {
                        _griglia.Campo[i, j] = FiguraCorrente.Forma[righe, colonne];
                    }       
                }     
            }

            // Riproduco FX
            try
            {
                SuonoFiguraBloccata();
            }
            catch
            {
                new ResourceNotFoundException("Suono_FiguraBloccata");
            }

            // Aumento punteggio e controllo il livello
            AumentaPunteggio();
            ScalaLivello(_punteggio);

        } // BLACK BOX

        /// <summary>
        /// Metodo che controllo se è stata completata una o più linee
        /// </summary>
        public void LineaCompletata()
        {
            int nLineeCompletate = 0;

            for(int i = 0; i < _griglia.Campo.GetLength(0); i++)
            {
                bool lineaCompletata = true;

                // Controllo riga per riga se ci sono delle linee completate
                for(int j = 0; (j < _griglia.Campo.GetLength(1)) && (lineaCompletata == true); j++)
                {
                    if(_griglia.Campo[i,j] == 0)
                    {
                        lineaCompletata = false;
                    }
                }

                if (lineaCompletata)
                {
                    nLineeCompletate++;

                    for (int y = i; y > 0; y--)
                    {
                        for (int j = 0; j < _griglia.Campo.GetLength(1); j++)
                        {
                            // La riga della griglia sarà uguale a quella sopra
                            _griglia.Campo[y, j] = _griglia.Campo[y - 1, j];
                            _griglia.Campo[0, j] = 0;
                        }
                    }
                }
            }

            if(nLineeCompletate > 0)
            {
                // Aumento punteggio in base alle righe completate, controllo il livello e riproduco suono
                try
                {
                    SuonoLineaCompletata();
                }
                catch
                {
                    new ResourceNotFoundException("Suono_LineaCompletata");
                }

                AumentaPunteggio(nLineeCompletate);
                ScalaLivello(_punteggio);
            }
            
        }

        /// <summary>
        /// Metodo che gestisce l'aumento statico del punteggio
        /// </summary>
        private void AumentaPunteggio()
        {
            _punteggio += 1;
        }

        /// <summary>
        /// Metodo che sfrutta l'overloading per gestire l'aumento del punteggio in base alle linee completate
        /// </summary>
        /// <param name="LineeCompletate">Numero di linee completate</param>
        private void AumentaPunteggio(int LineeCompletate)
        {
            switch (LineeCompletate)
            {
                case 1:
                    _punteggio += 10;
                    break;
                case 2:
                    _punteggio += 30;
                    break;
                case 3:
                    _punteggio += 60;
                    break;
                case 4:
                    _punteggio += 100;
                    break;
            }
        }

        /// <summary>
        /// Riproduce il suono di una figura che si blocca
        /// </summary>
        private void SuonoFiguraBloccata()
        {
            _figuraBloccataFx.Play();
        }

        /// <summary>
        /// Riproduce il suono di una linea completata
        /// </summary>
        private void SuonoLineaCompletata()
        {
            _lineaCompletaFx.Play();
        }

        /// <summary>
        /// Riproduce il suono del game over
        /// </summary>
        private void SuonoGameOver()
        {
            _gameOverFx.Play();
        }

        /// <summary>
        /// Aumenta il livello in base al punteggio raggiunto
        /// </summary>
        /// <param name="punteggio">Punteggio attuale del giocatore</param>
        private void ScalaLivello(int punteggio)
        {
            if (punteggio > 100)
            {
                _livello = 2;
            }
            if (punteggio > 200)
            {
                _livello = 3;
            }
            if (punteggio > 300)
            {
                _livello = 4;
            }
            if (punteggio > 400)
            {
                _livello = 5;
            }
  
        }

        /// <summary>
        /// Get dell'attributo InGioco
        /// </summary>
        public bool InGioco
        {
            get { return _inGioco; }
        }

        /// <summary>
        /// Get della figura corrente
        /// </summary>
        public Figura FiguraCorrente
        {
            get { return _figuraCorrente; }
        }

        /// <summary>
        /// Get della figura successiva
        /// </summary>
        public Figura FiguraSuccessiva
        {
            get { return _figuraSuccessiva; }
        }

        /// <summary>
        /// Get del numero di righe della figura corrente
        /// </summary>
        private int NumeroRigheFigura
        {
            get { return _figuraCorrente.Forma.GetLength(0); }
        }

        /// <summary>
        /// Get del numero di colonne della figura corrente
        /// </summary>
        private int NumeroColonneFigura
        {
            get { return _figuraCorrente.Forma.GetLength(1); }
        }

        /// <summary>
        /// Get della griglia di gioco
        /// </summary>
        public Terreno Griglia
        {
            get { return this._griglia; }
        }

        /// <summary>
        /// Get del punteggio della partita attuale
        /// </summary>
        public int Punteggio
        {
            get { return _punteggio; }
        }

        /// <summary>
        /// Get del livello
        /// </summary>
        public int Livello
        {
            get { return _livello; }
        }

    }
}
