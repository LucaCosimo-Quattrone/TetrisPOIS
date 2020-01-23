using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisPOIS.MVC.Controller;

namespace TetrisPOIS
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TetrisController gioco = new TetrisController();
            gioco.Inizia();
        }
    }
}
