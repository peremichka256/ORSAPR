using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KompasPlugin
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса построителя
        /// </summary>
        private WaveguideBuilder _waveguideBuilder;

        /// <summary>
        /// Объект класса с параметрами
        /// </summary>
        private WaveguideParameters _waveguideParameters;


        public MainForm()
        {
            InitializeComponent();
            _waveguideParameters = new WaveguideParameters();

            anchorageHeightTextBox.Text = 
                _waveguideParameters.AnchorageHeight.ToString();
            anchorageWidthTextBox.Text = 
                _waveguideParameters.AnchorageWidth.ToString();
            anchorageThicknessTextBox.Text = 
                _waveguideParameters.AnchorageThickness.ToString();
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

            ParameterTextboxValidating(holeDiametersTextBox, 
                _waveguideParameters.HoleDiameters, new CancelEventArgs());
        }

        /// <summary>
        /// Устанавливает стиль для неправильного проверяемого значения
        /// </summary>
        private void SetValidatingStyle(TextBox textBox)
        {
            textBox.BackColor = Color.LightSalmon;
        }

        /// <summary>
        /// Устанавливает стиль для проверенного значения
        /// </summary>
        private void SetValidatedStyle(TextBox textBox)
        {
            textBox.BackColor = Color.White;
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            KompasConnector kompas = new KompasConnector();
            kompas.Start();
            kompas.CreateDocument3D();
            _waveguideBuilder = new WaveguideBuilder(_waveguideParameters, kompas); 
            _waveguideBuilder.BuildWaveguide(kompas.Part);
        }

        private void ParameterTextboxValidating(TextBox sender, double parameter, CancelEventArgs e)
        {
            try
            {
                parameter = double.Parse(sender.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(sender);
                e.Cancel = true;
            }
        }

        private void HoleDiametersTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.HoleDiameters = 
                    double.Parse(holeDiametersTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(holeDiametersTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void HoleDiametersTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(holeDiametersTextBox);
        }

        private void RadiusCrossTieTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.RadiusCrossTie = 
                    double.Parse(radiusCrossTieTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(radiusCrossTieTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void RadiusCrossTieTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(radiusCrossTieTextBox);
        }

        private void AnchorageHeightTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageHeight = 
                    double.Parse(anchorageHeightTextBox.Text);
                _waveguideParameters.CrossSectionHeight = 
                    _waveguideParameters.AnchorageHeight 
                    - WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.CrossSectionWidth =
                    _waveguideParameters.CrossSectionHeight 
                    * WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageWidth =
                    _waveguideParameters.CrossSectionWidth
                    + WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;

                crossSectionHeightTextBox.Text =
                    _waveguideParameters.CrossSectionHeight.ToString();
                crossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                anchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(anchorageHeightTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void AnchorageHeightTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(anchorageHeightTextBox);
        }

        private void AnchorageWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageWidth = 
                    double.Parse(anchorageWidthTextBox.Text);
                _waveguideParameters.CrossSectionWidth = 
                    _waveguideParameters.AnchorageWidth
                    - WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.CrossSectionHeight =
                    _waveguideParameters.CrossSectionWidth
                    / WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageHeight =
                    _waveguideParameters.CrossSectionHeight
                    + WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;


                crossSectionHeightTextBox.Text =
                    _waveguideParameters.CrossSectionHeight.ToString();
                crossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                anchorageHeightTextBox.Text =
                    _waveguideParameters.AnchorageHeight.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(anchorageWidthTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void AnchorageWidthTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(anchorageWidthTextBox);
        }

        private void AnchorageThicknessTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageThickness = 
                    double.Parse(anchorageThicknessTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(anchorageThicknessTextBox);
                e.Cancel = true;
            }
        }

        private void AnchorageThicknessTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(holeDiametersTextBox);
        }

        private void WaveguideLengthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.WaveguideLength = 
                    double.Parse(waveguideLengthTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(waveguideLengthTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void WaveguideLengthTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(waveguideLengthTextBox);
        }

        private void CrossSectionWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionWidth = 
                    double.Parse(crossSectionWidthTextBox.Text);
                _waveguideParameters.CrossSectionHeight = 
                    _waveguideParameters.CrossSectionWidth 
                    / WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageWidth =
                    _waveguideParameters.CrossSectionWidth + 
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.AnchorageHeight =
                    _waveguideParameters.CrossSectionHeight + 
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;

                crossSectionHeightTextBox.Text = 
                    _waveguideParameters.CrossSectionHeight.ToString();
                anchorageHeightTextBox.Text = 
                    _waveguideParameters.AnchorageHeight.ToString();
                anchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(crossSectionWidthTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void CrossSectionWidthTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(crossSectionWidthTextBox);
        }

        private void CrossSectionThicknessTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionThickness = 
                    double.Parse(crossSectionThicknessTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(crossSectionThicknessTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void CrossSectionThicknessTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(crossSectionThicknessTextBox);
        }

        private void CrossSectionHeightTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionHeight = 
                    double.Parse(crossSectionHeightTextBox.Text);
                _waveguideParameters.CrossSectionWidth =
                    _waveguideParameters.CrossSectionHeight 
                    * WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageWidth =
                    _waveguideParameters.CrossSectionWidth +
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.AnchorageHeight =
                    _waveguideParameters.CrossSectionHeight +
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;

                crossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                anchorageHeightTextBox.Text =
                    _waveguideParameters.AnchorageHeight.ToString();
                anchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(crossSectionHeightTextBox);             
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void CrossSectionHeightTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(crossSectionHeightTextBox);
        }

        //TODO: Убрать дубли
        private void DistanceAngleToHoleTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.DistanceAngleToHole = 
                    double.Parse(distanceAngleToHoleTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(distanceAngleToHoleTextBox);
                e.Cancel = true;
            }
        }

        //TODO: Убрать дубли
        private void DistanceAngleToHoleTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(distanceAngleToHoleTextBox);
        }
    }
}
