using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPOIS.MVC.Model
{
    class EstrattoreFigura
    {
        private Random rnd = new Random();

        public Figura EstraiFigura()
        {
            Figura figuraCorrente = null;

            switch (rnd.Next(0, 7))
            {
                case 0:
                    figuraCorrente = new FiguraI();
                    break;
                case 1:
                    figuraCorrente = new FiguraO();
                    break;
                case 2:
                    figuraCorrente = new FiguraT();
                    break;
                case 3:
                    figuraCorrente = new FiguraS();
                    break;
                case 4:
                    figuraCorrente = new FiguraZ();
                    break;
                case 5:
                    figuraCorrente = new FiguraL();
                    break;
                case 6:
                    figuraCorrente = new FiguraJ();
                    break;
            }

            return figuraCorrente;
        }
    }
}
