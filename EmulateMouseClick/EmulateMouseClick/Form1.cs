using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulateMouseClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for(int i=0; i<500;i++)
            {
                MouseClick(i,i,0);
                Thread.Sleep(100);
            }
        }


        [DllImport("User32.dll")]
        private static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        //для удобства использования создаем перечисление с необходимыми флагами (константами), которые определяют действия мыши: 
        [Flags]
        private enum MouseFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            Absolute = 0x8000
        };

        private void MouseClick(int x, int y, int flag)
        {
            //и использование - клик левой примерно в центре экрана
            //(подробнее о координатах, передаваемых в mouse_event см. в MSDN): 
            if (flag == 0)
            {
                mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
                mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
                mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
                //mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
                //mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, x, y, 0, UIntPtr.Zero);
            }
        }
    }

}
