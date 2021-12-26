using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KompasPlugin
{
    /// <summary>
    /// Класс хранящий и обрабатывающий пользовательский интерфейс плагина
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса построителя
        /// </summary>
        private WaveguideBuilder _waveguideBuilder;

        /// <summary>
        /// Объект класса с параметрами
        /// </summary>
        private WaveguideParameters _waveguideParameters = new WaveguideParameters();

        /// <summary>
        /// Конструктор главной формы с необходимыми инициализациями
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            List<TextBox> textBoxes = new List<TextBox>
            {
                anchorageHeightTextBox,
                anchorageThicknessTextBox,
                anchorageWidthTextBox,
                crossSectionHeightTextBox,
                crossSectionThicknessTextBox,
                crossSectionWidthTextBox,
                distanceAngleToHoleTextBox,
                holeDiametersTextBox,
                radiusCrossTieTextBox,
                waveguideLengthTextBox
            };
            //Важно точное соотношение порядка текстбоксов и параметров
            //валидируемых в этих текстбоксах
            List<double> parameters = new List<double>
            {
                _waveguideParameters.AnchorageHeight,
                _waveguideParameters.AnchorageThickness,
                _waveguideParameters.AnchorageWidth,
                _waveguideParameters.CrossSectionHeight,
                _waveguideParameters.CrossSectionThickness,
                _waveguideParameters.CrossSectionWidth,
                _waveguideParameters.DistanceAngleToHole,
                _waveguideParameters.HoleDiameters,
                _waveguideParameters.RadiusCrossTie,
                _waveguideParameters.WaveguideLength
            };

            //Занесения в текстбоксы дефолтных значений
            //и задание поведения проверенного текстбокса
            for (int i = 0; i < textBoxes.Count; i++)
            {
                textBoxes[i].Text = parameters[i].ToString();
                textBoxes[i].Validated 
                    += new EventHandler(TextBox_Validated);
            }
        }

        /// <summary>
        /// Устанавливает стиль для проверенного значения
        /// </summary>
        /// <param name="sender">Текстбокс</param>
        private void TextBox_Validated(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                BuildButton.Enabled = true;
                textBox.BackColor = Color.White;
                toolTip.Active = false;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Устанавливает стиль для значения непрошедшего проверку 
        /// </summary>
        /// <param name="sender">Текстбокс</param>
        /// <param name="e"></param>
        /// <param name="errorMessage"></param>
        private void TextBox_ValidatingFail(object sender,
            CancelEventArgs e, string errorMessage)
        {
            if (sender is TextBox textBox)
            {
                BuildButton.Enabled = false;
                textBox.BackColor = Color.LightSalmon;
                toolTip.Active = true;
                toolTip.SetToolTip(textBox, errorMessage);
                e.Cancel = true;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Обработчик нажания кнопки "Построить"
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            KompasConnector connector = new KompasConnector();
            _waveguideBuilder = 
                new WaveguideBuilder(_waveguideParameters, connector);
            _waveguideBuilder.BuildWaveguide();
        }

        /// <summary>
        /// Валидация текстбокса с диаметром отверстий
        /// </summary>
        private void HoleDiametersTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.HoleDiameters = 
                    double.Parse(holeDiametersTextBox.Text);
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с радиусом фаски
        /// </summary>
        private void RadiusCrossTieTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.RadiusCrossTie = 
                    double.Parse(radiusCrossTieTextBox.Text);
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с высотой креплений
        /// </summary>
        private void AnchorageHeightTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageHeight = 
                    double.Parse(anchorageHeightTextBox.Text);

                crossSectionHeightTextBox.Text =
                    _waveguideParameters.CrossSectionHeight.ToString();
                crossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                anchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с шириной креплений
        /// </summary>
        private void AnchorageWidthTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageWidth = 
                    double.Parse(anchorageWidthTextBox.Text);


                crossSectionHeightTextBox.Text =
                    _waveguideParameters.CrossSectionHeight.ToString();
                crossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                anchorageHeightTextBox.Text =
                    _waveguideParameters.AnchorageHeight.ToString();
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с толщиной креплений
        /// </summary>
        private void AnchorageThicknessTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageThickness = 
                    double.Parse(anchorageThicknessTextBox.Text);
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }


        /// <summary>
        /// Валидация текстбокса с длиной волновода
        /// </summary>
        private void WaveguideLengthTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.WaveguideLength = 
                    double.Parse(waveguideLengthTextBox.Text);
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с шириной сечения
        /// </summary>
        private void CrossSectionWidthTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionWidth = 
                    double.Parse(crossSectionWidthTextBox.Text);

                crossSectionHeightTextBox.Text = 
                    _waveguideParameters.CrossSectionHeight.ToString();
                anchorageHeightTextBox.Text = 
                    _waveguideParameters.AnchorageHeight.ToString();
                anchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с толщиной сечения
        /// </summary>
        private void CrossSectionThicknessTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionThickness = 
                    double.Parse(crossSectionThicknessTextBox.Text);
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с высотой сечения
        /// </summary>
        private void CrossSectionHeightTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionHeight = 
                    double.Parse(crossSectionHeightTextBox.Text);

                crossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                anchorageHeightTextBox.Text =
                    _waveguideParameters.AnchorageHeight.ToString();
                anchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception exception) 
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        //TODO: Убрать дубли
        //TODO: Убрать дубли
        /// <summary>
        /// Валидация текстбокса с расстоянием от угла до отверстия
        /// </summary>
        private void DistanceAngleToHoleTextBox_Validating(object sender,
            CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.DistanceAngleToHole = 
                    double.Parse(distanceAngleToHoleTextBox.Text);
            }
            catch (Exception exception)
            {
                TextBox_ValidatingFail(sender, e, exception.Message);
            }
        }

        /// <summary>
        /// Выбор построения прямого волновода
        /// </summary>
        private void DefaultWaveguideRadioButton_CheckedChanged
            (object sender, EventArgs e)
        {
            _waveguideParameters.IsWaveguideTurn = false;
        }

        /// <summary>
        /// Выбор построения изогнутого волновода
        /// </summary>
        private void TurnWaveguideRadioButton_CheckedChanged
            (object sender, EventArgs e)
        {
            _waveguideParameters.IsWaveguideTurn = true;
        }
        //TODO: Убрать дубли
    }
}
