using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ValidBox
{
    public partial class ValidTextBox: TextBox
    {
        public ValidTextBox()
        {
            InitializeComponent();
            MsgError = new ErrorProvider();
        }

        public TypeValid Type { get; set; }
        public ErrorProvider MsgError { get; set; }
        protected override void OnValidating(CancelEventArgs e)
        {
            if (Text.Trim().Length == 0)
            {
                MsgError.SetError(this, "El campo está vacío!");
                e.Cancel = true;
                return;
            }
            switch(Type)
            {
                case TypeValid.Numeric:
                    if (!ValidString.isNumeric(Text))
                    {
                        MsgError.SetError(this, "En este campo solo se permite el ingreso de dígitos.\nNo puedes ingresar números con signo, ni caracteres que no sea dígito.");
                        e.Cancel = true;
                    }
                    break;
                case TypeValid.SNumeric:
                    if (!ValidString.isNumeric(Text, 'S'))
                    {
                        MsgError.SetError(this, "En este campo solo se permite números enteros con signo o sin signo.");
                        e.Cancel = true;
                    }
                    break;
                case TypeValid.Letter:
                    if (!ValidString.isLetter(Text))
                    {
                        MsgError.SetError(this, "En este campo solo se permite el ingreso de letras.\nSólo se puede ingresar letras del abecedario y tildes.");
                        e.Cancel = true;
                    }
                    break;
                case TypeValid.Decimal:
                    if (!ValidString.isFloat(Text))
                    {
                        MsgError.SetError(this, "En este campo solo se permite el ingreso de números decimales sin signo.");
                        e.Cancel = true;
                    }
                    break;
                case TypeValid.SDecimal:
                    if (!ValidString.isFloat(Text, 'S'))
                     {
                        MsgError.SetError(this, "En este campo solo se permite números decimales con signo o sin signo.");
                        e.Cancel = true;
                     }
 
                    break;
                default:  
                    break;
            }
            if(!e.Cancel)
                base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            MsgError.SetError(this, "");
        }
    }
}
