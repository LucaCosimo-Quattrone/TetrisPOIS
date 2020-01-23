using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisPOIS.MVC.Controller
{
    /// <summary>
    /// Classe controller, integra la parte grafica con il codice effettivo del gioco
    /// </summary>
    class TetrisController
    {
        // Costante utilizzata per lo stretch dell'immagine
        private const int DIMENSIONE_BLOCCHI = 25;

        // Classi che il controller gestirà
        private TetrisForm _tetrisF;
        private Gioco _gioco;

        // Elementi operazionali
        private Rectangle _fig_corrente;
        private bool _menu = true;
        private bool _inPausa = false;

        // Elementi grafici
        private SolidBrush _brushSide = new SolidBrush(Color.DarkBlue);
        private SolidBrush _brushSfondo = new SolidBrush(Color.DarkBlue);

        /// <summary>
        /// Costruttore
        /// </summary>
        public TetrisController()
        {
            this._tetrisF = new TetrisForm();
            _tetrisF.KeyDown += new KeyEventHandler(TastoPremuto);
            _tetrisF.Paint += new PaintEventHandler(DisegnaGioco);
            _tetrisF.T.Tick += new System.EventHandler(TetrisFormTick);
            _tetrisF.NuovaPartita.Click += new System.EventHandler(NuovaPartitaClick);
            _tetrisF.Esci.Click += new System.EventHandler(EsciClick);
            _tetrisF.Aiuto.Click += new System.EventHandler(AiutoClick);
            _tetrisF.Pausa.Click += new System.EventHandler(PausaClick);
            _tetrisF.Riprendi.Click += new System.EventHandler(RiprendiClick);
        }

        /// <summary>
        /// Metodo che mostra all'utente la form
        /// </summary>
        public void Inizia()
        {
            _tetrisF.ShowDialog();
        }

        /// <summary>
        /// Gestisce la fine del gioco
        /// </summary>
        private void GameOver()
        {
            _tetrisF.tStop();
            // Utilizzo una message box per la fine della partita
            string messaggio = "\tPurtroppo hai perso! Hai totalizzato " + _gioco.Punteggio + " punti";
            string titolo = "Game Over";
            DialogResult risposta = MessageBox.Show(messaggio, titolo, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (risposta == System.Windows.Forms.DialogResult.OK)
            {
                _tetrisF.Close();
            }
            else
            {
                throw new Exception("Errore nel finire la partita!");
            }

        }

        /// <summary>
        /// Gestione del click del mouse sul bottone Nuova Partita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuovaPartitaClick(object sender, EventArgs e)
        {
            _gioco = new Gioco();
            _menu = false;
            _tetrisF.tStart();
            _tetrisF.MenuPrincipale.Hide();
        }

        /// <summary>
        /// Gestione del click del mouse sul bottone Comandi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AiutoClick(object sender, EventArgs e)
        {
            MessageBox.Show("\tFRECCIA SU: Ruota la figura \r\n\tFRECCIA GIU: Aumenta velocita discesa della figura \r\n\tFRECCIA DESTRA: Muove la figura a destra \r\n\tFRECCIA SINISTRA: Muove la figura a sinistra",
                            "COMANDI",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        /// <summary>
        /// Gestione del click del mouse sul bottone Esci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EsciClick(object sender, EventArgs e)
        {
            _tetrisF.Close();
        }

        /// <summary>
        /// Metodo per mettere in pausa la partita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PausaClick(object sender, EventArgs e)
        {
            _inPausa = true;
            _tetrisF.Riprendi.Show();
            _tetrisF.Pausa.Hide();
            _tetrisF.tStop(); 
        }

        /// <summary>
        /// Metodo per riprendere la partita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RiprendiClick(object sender, EventArgs e)
        {
            _inPausa = false;
            _tetrisF.Riprendi.Hide();
            _tetrisF.Pausa.Show();
            _tetrisF.tStart();
        }


        /// <summary>
        /// Metodo che gestisce gli eventi che si verificano in un dato intervallo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TetrisFormTick(object sender, System.EventArgs e)
        {
            if (_gioco.InGioco == false)
            {
                GameOver();
            }
            else if (_gioco.InGioco)
            {
                ScendiGiu();
            }
 
        }

        /// <summary>
        /// Fa scendere di un blocco la figura
        /// </summary>
        private void ScendiGiu()
        {
            if (_gioco.InGioco)
            {
                if(_gioco.FiguraCorrente.Fissata == false)
                {
                    _gioco.MuoviGiu();
                    if(_gioco.FiguraCorrente.Fissata == true)
                    {
                        _tetrisF.Invalidate();
                        _gioco.GeneraFigura();
                    } 
                }
            }

            // Aggiorno il livello e il punteggio nella GUI
            _tetrisF.Punteggio.Text = "Punteggio = " + _gioco.Punteggio.ToString();
            _tetrisF.Livello.Text = "Livello = " + _gioco.Livello.ToString();

            // Aumento la difficolta
            ModificaDifficolta();

            _tetrisF.Invalidate(_fig_corrente);
            _fig_corrente.Y += DIMENSIONE_BLOCCHI;
            _tetrisF.Invalidate(_fig_corrente);
            _tetrisF.Update();
            
        }

        /// <summary>
        /// Metodo che gestisce la parte di visualizzazione grafica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisegnaGioco(object sender, PaintEventArgs e)
        {
            if (!_menu)
            {
                e.Graphics.FillRectangle(_brushSide, new Rectangle(250, 0, 125, 400));
                DisegnaBlocchi(e);
                DisegnaFigura(e);
                DisegnaFiguraSuccessiva(_gioco.FiguraSuccessiva, e);
            }
          
        }

        /// <summary>
        /// Gestisce la visualizzazione dei blocchi fissati alla griglia
        /// </summary>
        /// <param name="e"></param>
        private void DisegnaBlocchi(PaintEventArgs e)
        {
            for (int i = 0; i < _gioco.Griglia.Campo.GetLength(0); i++)
            {
                for (int j = 0; j < _gioco.Griglia.Campo.GetLength(1); j++)
                {
                    switch (_gioco.Griglia.Campo[i, j])
                    {
                        case 1:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_I, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_I");
                            }

                            break;
                        case 2:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_O, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_O");
                            }
                           
                           break;
                        case 3:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_T, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_T");
                            }
                           
                           break;
                        case 4:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_S, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_S");
                            }
                           
                           break;
                        case 5:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_Z, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_Z");
                            }
                           
                           break;
                        case 6:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_L, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_L");
                            }
                           
                           break;
                        case 7:
                            try
                            {
                                e.Graphics.DrawImage(TetrisPOIS.Properties.Resources.Blocco_J, j * DIMENSIONE_BLOCCHI, i * DIMENSIONE_BLOCCHI);
                            }
                            catch
                            {
                                new ResourceNotFoundException("Blocco_J");
                            }
                           
                           break;
                    }
                }
            }
        }

        /// <summary>
        /// Disegna l'attuale figura
        /// </summary>
        /// <param name="e"></param>
        private void DisegnaFigura(PaintEventArgs e)
        {
            _fig_corrente = new Rectangle(_gioco.FiguraCorrente.X * DIMENSIONE_BLOCCHI,
                                          _gioco.FiguraCorrente.Y * DIMENSIONE_BLOCCHI,
                                          _gioco.FiguraCorrente.Sprite.Width,
                                          _gioco.FiguraCorrente.Sprite.Height);
            try
            {
                e.Graphics.DrawImage(_gioco.FiguraCorrente.Sprite, _fig_corrente);
            }
            catch
            {
                new ResourceNotFoundException("Sprite_FiguraCorrente");
            }

        }

        /// <summary>
        /// Disegna la figura successiva
        /// </summary>
        /// <param name="f"></param>
        /// <param name="e"></param>
        private void DisegnaFiguraSuccessiva(Figura f, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(_brushSfondo, new Rectangle(280, 50, 30, 30));
            try
            {
                e.Graphics.DrawImage(f.Sprite, 290, 50);
            }
            catch
            {
                new ResourceNotFoundException("Sprite_Figura");
            }
            
            
        }

        /// <summary>
        /// Metodo che gestisce l'input da tastiera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="k"></param>
        private void TastoPremuto(object sender, KeyEventArgs k)
        {
            if (!_inPausa)
            {
                switch (k.KeyData)
                {
                    case (Keys.Up):
                        _gioco.RuotaFigura();

                        // Attraverso invalidate() elimino dalla gestione del timer il rettangolo in cui è l'immagine
                        // attualmente e il rettangolo in cui comparirà l'immagine ruotata, eseguendo infine l'update()
                        _tetrisF.Invalidate(new Rectangle(_gioco.FiguraCorrente.X * DIMENSIONE_BLOCCHI,
                                                          _gioco.FiguraCorrente.Y * DIMENSIONE_BLOCCHI,
                                                          _gioco.FiguraCorrente.Sprite.Width,
                                                          _gioco.FiguraCorrente.Sprite.Height));
                        _tetrisF.Invalidate(_fig_corrente);
                        _tetrisF.Update();
                        break;
                    case (Keys.Down):
                        ScendiGiu();
                        break;
                    case (Keys.Left):
                        _tetrisF.Invalidate(new Rectangle((_gioco.FiguraCorrente.X - 1) * DIMENSIONE_BLOCCHI,
                                                           _gioco.FiguraCorrente.Y * DIMENSIONE_BLOCCHI,
                                                           _gioco.FiguraCorrente.Sprite.Width,
                                                           _gioco.FiguraCorrente.Sprite.Height));
                        _gioco.MuoviSinistra();
                        _tetrisF.Invalidate(_fig_corrente);
                        _tetrisF.Update();
                        break;
                    case (Keys.Right):
                        _tetrisF.Invalidate(new Rectangle((_gioco.FiguraCorrente.X + 1) * DIMENSIONE_BLOCCHI,
                                                           _gioco.FiguraCorrente.Y * DIMENSIONE_BLOCCHI,
                                                           _gioco.FiguraCorrente.Sprite.Width,
                                                           _gioco.FiguraCorrente.Sprite.Height));
                        _gioco.MuoviDestra();
                        _tetrisF.Invalidate(_fig_corrente);
                        _tetrisF.Update();
                        break;
                }
            }
            else
            {
                k.Handled = true;
            }
            
        }

        /// <summary>
        /// Modifica la velocita con cui scendono i blocchi
        /// </summary>
        private void ModificaDifficolta()
        {

            switch (_gioco.Livello)
            {
                case 2:
                    _tetrisF.tIntervallo(800);
                    break;
                case 3:
                    _tetrisF.tIntervallo(600);
                    break;
                case 4:
                    _tetrisF.tIntervallo(500);
                    break;
                case 5:
                    _tetrisF.tIntervallo(400);
                    break;
            }
        }

    }

}

