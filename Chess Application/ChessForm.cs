using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_5
{
    public partial class ChessForm : Form
    {
        public ChessForm()
        {
            InitializeComponent();

            this.label_Player1.Parent = ChessBackground;
            this.label_Player2.Parent = ChessBackground;

        }


    }
}
