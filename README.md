# Library-Validating
[![LibraryValidating](https://shields.southcla.ws/badge/LibraryValidating-v1.0-2f2f2f.svg?style=flat-square)](https://github.com/MrDave1999/Library-Validating)
[![LibraryValidating](https://shields.southcla.ws/badge/CSharp-ValidTextBox-2f2f2f.svg?style=flat-square)](https://github.com/MrDave1999/Library-Validating)

Esta biblioteca de control permite hacer validaciones básicas como por ejemplo, hacer que el usuario ingrese únicamente números enteros en un TextBox.

## Instalación

Para poder instalar, debes añadir una referencia de la biblioteca `ValidBox.dll` en el proyecto actual del programa. Esto se logra yendo a la pestaña de Proyecto/Agregar referencia (en esta opción buscas el DLL y luego le das aceptar).

Para lograr que el control ValidTextBox aparezca en el cuadro de herramientas, debes ir a la pestaña Ver/Cuadro de herramientas, después le das click derecho a cualquier pestaña y le das en elegir elementos -> examinar -> buscas la ruta donde se encuentre ValidBox.dll -> aceptar.

La biblioteca de control la puedes descargar aquí: [LibraryValidating.rar](https://github.com/MrDave1999/Library-Validating/releases/tag/v1.0) 

## Propiedades

- `public TypeValid Type { get; set; }`

Permite asignar el tipo de validación al TextBox. Los valores que puede tomar esta propiedad son constantes de tipo `enum TypeValid`:

`Numeric`: Este valor hace que el textbox acepte únicamente números enteros sin signo.

`SNumeric`: Este valor hace que el textbox acepte únicamente números enteros con signo o sin signo.

`Letter`: Este valor hace que el textbox acepte únicamente letras del abecedario o tildes.

`Decimal`: Este valor hace que el textbox acepte únicamente números decimales sin signo.

`SDecimal`: Este valor hace que el textbox acepte únicamente números decimales con signo o sin signo.

- `public ErrorProvider MsgError { get; set; }`

Proporciona una interfaz de usuario para indicar que un control en un formulario tiene un error asociado.

## Uso

En el siguiente ejemplo se pide al usuario que ingrese su año de nacimiento en un TextBox, para calcular su respectiva edad.
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValidBox;

namespace _Example
{
	public class Example : Form
	{
		private ValidTextBox validTextBox1;
		public Example()
		{
			InitializeComponent();
		}
		
		private void InitializeComponent()
		{
			//Button
			this.button1.Location = new System.Drawing.Point(156, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
			
			//ValidTextBox
			this.validTextBox1.Location = new System.Drawing.Point(42, 25);
            this.validTextBox1.Name = "validTextBox1";
            this.validTextBox1.Size = new System.Drawing.Size(100, 20);
            this.validTextBox1.TabIndex = 1;
			//Aquí se especifica el tipo de validación, en este caso el textbox solo puede aceptar números enteros sin signo.
            this.validTextBox1.Type = TypeValid.Numeric;
			this.validTextBox1.MaxLength = 4;
            this.validTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.validTextBox1_Validating);
			this.validTextBox1 = new ValidTextBox();
		}
		
		private void validTextBox1_Validating(object sender, CancelEventArgs e)
		{
			DateTime a = DateTime.Now;
			int yearBirth = Convert.ToInt32(validTextBox1.Text);
			int yearCurrent = a.Year;
			if(!(yearBirth >= 1920 && yearBirth <= yearCurrent))
			{
				validTextBox1.MsgError.setError(validTextBox1, "El rango que se puede ingresar es de 1929 hasta " + yearCurrent);
				e.Cancel = true;
			}
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			DateTime a = DateTime.Now;
			int yearBirth = Convert.ToInt32(validTextBox1.Text);
			int age = yearBirth - a.Year;
			MessageBox.Show("Tu edad es de: " + age + " años.");
		}
	}
}
```

## Créditos

- [MrDave](https://github.com/MrDave1999)

- [Microsoft](https://github.com/microsoft)
