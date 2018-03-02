using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Documents;
using System.Threading.Tasks;

namespace WPFGame
{
    class Text
    {
        static public Brush DefaultColor = Brushes.Black;
        static public Brush PlayerColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00FF00"));
        static public Brush EnemyColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0000"));

        public bool HidEnemyBox = true;

        public bool OPLogUpdate = false;

        public Brush TextColor = null;

        public List<Run> OPLog = new List<Run>();
        public List<Run> GetOPLog()
        {
            return OPLog;
        }
        public void AddToOPLog(string text, Brush brush = null)
        {
            Run run = new Run("\n" + text)
            {
                Foreground = brush ?? Brushes.Black
            };

            OPLog.Add(run);
            OPLogUpdate = true;
        }
    }
}
