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

        /// <summary>
        /// Словарь содержащий пары (Текстбоксы, имя параметра)
        /// </summary>
        private Dictionary<TextBox, ParameterNames> _textBoxesDictionary;

        /// <summary>
        /// Конструктор главной формы с необходимыми инициализациями
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _textBoxesDictionary = new Dictionary<TextBox, ParameterNames> 
            {
                {anchorageHeightTextBox, ParameterNames.AnchorageHeight},
                {anchorageThicknessTextBox,
                    ParameterNames.AnchorageThickness},
                {anchorageWidthTextBox, ParameterNames.AnchorageWidth},
                {crossSectionHeightTextBox, 
                    ParameterNames.CrossSectionHeight},
                {crossSectionThicknessTextBox, 
                    ParameterNames.CrossSectionThickness},
                {crossSectionWidthTextBox, 
                    ParameterNames.CrossSectionWidth},
                {distanceAngleToHoleTextBox,
                    ParameterNames.DistanceAngleToHole},
                {holeDiametersTextBox, ParameterNames.HoleDiameters},
                {radiusCrossTieTextBox, ParameterNames.RadiusCrossTie},
                {waveguideLengthTextBox, ParameterNames.WaveguideLenght},
            };

            //foreach (var textBox in _textBoxesDictionary)
            //{
            //    textBox.Key.Text = _waveguideParameters.SetParameterByName();
            //}
            anchorageHeightTextBox.Text = 
                _waveguideParameters.AnchorageHeight.ToString();
            anchorageThicknessTextBox.Text = 
                _waveguideParameters.AnchorageThickness.ToString();
            anchorageWidthTextBox.Text = 
                _waveguideParameters.AnchorageWidth.ToString();
            crossSectionHeightTextBox.Text = 
                _waveguideParameters.CrossSectionHeight.ToString();
            crossSectionThicknessTextBox.Text = 
                _waveguideParameters.CrossSectionThickness.ToString();
            crossSectionWidthTextBox.Text = 
                _waveguideParameters.CrossSectionWidth.ToString();
            distanceAngleToHoleTextBox.Text = 
                _waveguideParameters.DistanceAngleToHole.ToString();
            holeDiametersTextBox.Text = 
                _waveguideParameters.HoleDiameters.ToString();
            radiusCrossTieTextBox.Text = 
                _waveguideParameters.RadiusCrossTie.ToString();
            waveguideLengthTextBox.Text = 
                _waveguideParameters.WaveguideLength.ToString();
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
        }

        /// <summary>
        /// Общий метод валидации текстбокса
        /// </summary>
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!(sender is TextBox textBox)) return;

            try
            {
                _textBoxesDictionary.TryGetValue(textBox,
                    out var parameterInTextBoxName);
                _waveguideParameters.SetParameterByName(parameterInTextBoxName,
                    double.Parse(textBox.Text));

                if (textBox != anchorageHeightTextBox 
                    && textBox != anchorageWidthTextBox 
                    && textBox != crossSectionHeightTextBox 
                    && textBox != crossSectionWidthTextBox) return;

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
            catch (Exception exception)
            {
                BuildButton.Enabled = false;
                textBox.BackColor = Color.LightSalmon;
                toolTip.Active = true;
                toolTip.SetToolTip(textBox, exception.Message);
                e.Cancel = true;
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
        /// Обработчик выбора формы для построения волновода
        /// </summary>
        private void RadioButtons_CheckedChanged
            (object sender, EventArgs e)
        {
            _waveguideParameters.IsWaveguideTurn = 
                TurnWaveguideRadioButton.Checked;
        }
    }
}