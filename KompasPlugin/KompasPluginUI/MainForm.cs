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
        private WaveguideParameters _waveguideParameters = 
            new WaveguideParameters();

        private List<TextBox> _textBoxes;

        /// <summary>
        /// Конструктор главной формы с необходимыми инициализациями
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _textBoxes = new List<TextBox>
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
            for (int i = 0; i < _textBoxes.Count; i++)
            {
                _textBoxes[i].Text = parameters[i].ToString();
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
        /// Общий метод валидации текстбокса
        /// </summary>
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var parameterNames = _waveguideParameters
                    .GetAllParameterNames();
                Action<string, double> setParameter = 
                    _waveguideParameters.SetValueByKey;

                for (var i = 0; i < _textBoxes.Count; i++)
                {
                    if (_textBoxes[i] == textBox)
                    {
                        try
                        {
                            setParameter(parameterNames[i],
                                double.Parse(textBox.Text));

                            if (textBox == anchorageHeightTextBox
                                || textBox == anchorageWidthTextBox
                                || textBox == crossSectionHeightTextBox
                                || textBox == crossSectionWidthTextBox)
                            {
                                anchorageHeightTextBox.Text =
                                    _waveguideParameters.AnchorageHeight
                                    .ToString();
                                anchorageWidthTextBox.Text =
                                    _waveguideParameters.AnchorageWidth
                                    .ToString();
                                crossSectionHeightTextBox.Text =
                                    _waveguideParameters.CrossSectionHeight
                                    .ToString();
                                crossSectionWidthTextBox.Text =
                                    _waveguideParameters.CrossSectionWidth
                                    .ToString();
                            }
                        }
                        catch (Exception exception)
                        {
                            BuildButton.Enabled = false;
                            textBox.BackColor = Color.LightSalmon;
                            toolTip.Active = true;
                            toolTip.SetToolTip(textBox, exception.Message);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Построить"
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            KompasConnector connector = new KompasConnector();
            _waveguideBuilder = 
                new WaveguideBuilder(_waveguideParameters, connector);

             _waveguideBuilder.BuildWaveguide(); 
            
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
    }
}