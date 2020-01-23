using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisPOIS
{
    /// <summary>
    /// Contiene i metodi della parte grafica
    /// </summary>
    public partial class TetrisForm : Form
    {
        // Listener
        private delegate void KeyEventHandler(object sender, KeyEventArgs e);
        private delegate void PaintEventHandler(object sender, PaintEventArgs e);
        private delegate void EventHandler(object sender, System.EventArgs e);

        // Timer
        private Timer _t;

        /// <summary>
        /// Costruttore
        /// </summary>
        public TetrisForm()
        {
            InitializeComponent();
            this._t = new Timer();
            Inizializza();

        }

        /// <summary>
        /// Inizializza il timer
        /// </summary>
        public void Inizializza()
        {
            this._t.Enabled = false;
            tIntervallo(1000);
        }

        /// <summary>
        /// Get del timer
        /// </summary>
        public Timer T
        {
            get { return _t; }
        }
        
        /// <summary>
        /// Permette al timer di partire/ripartire
        /// </summary>
        public void tStart()
        {
            this._t.Enabled = true;
        }

        /// <summary>
        /// Fa stoppare il timer
        /// </summary>
        public void tStop()
        {
            this._t.Enabled = false;
        }

        /// <summary>
        /// Setta l'intervallo di t a un dato valore
        /// </summary>
        /// <param name="valore">Il valore che assumera l'intervallo</param>
        public void tIntervallo(int valore)
        {
            _t.Interval = valore;
        }

    }
}
