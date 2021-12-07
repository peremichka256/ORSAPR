using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KompasPlugin
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса билдера
        /// </summary>
        private WaveguideBuilder _waveguideBuilder;

        /// <summary>
        /// Объект класса параметра
        /// </summary>
        private WaveguideParameters _waveguideParameters;


        public MainForm()
        {
            InitializeComponent();
            _waveguideParameters = new WaveguideParameters();

            AnchorageHeightTextBox.Text = 
                _waveguideParameters.AnchorageHeight.ToString();
            AnchorageWidthTextBox.Text = 
                _waveguideParameters.AnchorageWidth.ToString();
            AnchorageThicknessTextBox.Text = 
                _waveguideParameters.AnchorageThickness.ToString();
            CrossSectionHeightTextBox.Text = 
                _waveguideParameters.CrossSectionHeight.ToString();
            CrossSectionThicknessTextBox.Text = 
                _waveguideParameters.CrossSectionThickness.ToString();
            CrossSectionWidthTextBox.Text = 
                _waveguideParameters.CrossSectionWidth.ToString();
            DistanceAngleToHoleTextBox.Text = 
                _waveguideParameters.DistanceAngleToHole.ToString();
            HoleDiametersTextBox.Text = 
                _waveguideParameters.HoleDiameters.ToString();
            RadiusCrossTieTextBox.Text = 
                _waveguideParameters.RadiusCrossTie.ToString(); 
            WaveguideLengthTextBox.Text = 
                _waveguideParameters.WaveguideLength.ToString();

            var kompas = new KompasConnector();
            kompas.KompasConnect();
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
            _waveguideBuilder = new WaveguideBuilder(_waveguideParameters);
        }

        private void HoleDiametersTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.HoleDiameters = 
                    double.Parse(HoleDiametersTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(HoleDiametersTextBox);
                e.Cancel = true;
            }
        }

        private void HoleDiametersTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(HoleDiametersTextBox);
        }

        private void RadiusCrossTieTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.RadiusCrossTie = 
                    double.Parse(RadiusCrossTieTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(RadiusCrossTieTextBox);
                e.Cancel = true;
            }
        }

        private void RadiusCrossTieTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(RadiusCrossTieTextBox);
        }

        private void AnchorageHeightTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageHeight = 
                    double.Parse(AnchorageHeightTextBox.Text);
                _waveguideParameters.CrossSectionHeight = 
                    _waveguideParameters.AnchorageHeight 
                    - WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.CrossSectionWidth =
                    _waveguideParameters.CrossSectionHeight 
                    * WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageWidth =
                    _waveguideParameters.CrossSectionWidth
                    + WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;

                CrossSectionHeightTextBox.Text =
                    _waveguideParameters.CrossSectionHeight.ToString();
                CrossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                AnchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(AnchorageHeightTextBox);
                e.Cancel = true;
            }
        }

        private void AnchorageHeightTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(AnchorageHeightTextBox);
        }

        private void AnchorageWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageWidth = 
                    double.Parse(AnchorageWidthTextBox.Text);
                _waveguideParameters.CrossSectionWidth = 
                    _waveguideParameters.AnchorageWidth
                    - WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.CrossSectionHeight =
                    _waveguideParameters.CrossSectionWidth
                    / WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageHeight =
                    _waveguideParameters.CrossSectionHeight
                    + WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;


                CrossSectionHeightTextBox.Text =
                    _waveguideParameters.CrossSectionHeight.ToString();
                CrossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                AnchorageHeightTextBox.Text =
                    _waveguideParameters.AnchorageHeight.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(AnchorageWidthTextBox);
                e.Cancel = true;
            }
        }

        private void AnchorageWidthTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(AnchorageWidthTextBox);
        }

        private void AnchorageThicknessTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.AnchorageThickness = 
                    double.Parse(AnchorageThicknessTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(AnchorageThicknessTextBox);
                e.Cancel = true;
            }
        }

        private void AnchorageThicknessTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(HoleDiametersTextBox);
        }

        private void WaveguideLengthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.WaveguideLength = 
                    double.Parse(WaveguideLengthTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(WaveguideLengthTextBox);
                e.Cancel = true;
            }
        }

        private void WaveguideLengthTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(WaveguideLengthTextBox);
        }

        private void CrossSectionWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionWidth = 
                    double.Parse(CrossSectionWidthTextBox.Text);
                _waveguideParameters.CrossSectionHeight = 
                    _waveguideParameters.CrossSectionWidth 
                    / WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageWidth =
                    _waveguideParameters.CrossSectionWidth + 
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.AnchorageHeight =
                    _waveguideParameters.CrossSectionHeight + 
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;

                CrossSectionHeightTextBox.Text = 
                    _waveguideParameters.CrossSectionHeight.ToString();
                AnchorageHeightTextBox.Text = 
                    _waveguideParameters.AnchorageHeight.ToString();
                AnchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(CrossSectionWidthTextBox);
                e.Cancel = true;
            }
        }

        private void CrossSectionWidthTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(CrossSectionWidthTextBox);
        }

        private void CrossSectionThicknessTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionThickness = 
                    double.Parse(CrossSectionThicknessTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(CrossSectionThicknessTextBox);
                e.Cancel = true;
            }
        }

        private void CrossSectionThicknessTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(CrossSectionThicknessTextBox);
        }

        private void CrossSectionHeightTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.CrossSectionHeight = 
                    double.Parse(CrossSectionHeightTextBox.Text);
                _waveguideParameters.CrossSectionWidth =
                    _waveguideParameters.CrossSectionHeight 
                    * WaveguideParameters.CROSS_SECTION_SIDE_MULTIPLIER;
                _waveguideParameters.AnchorageWidth =
                    _waveguideParameters.CrossSectionWidth +
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;
                _waveguideParameters.AnchorageHeight =
                    _waveguideParameters.CrossSectionHeight +
                    WaveguideParameters.ANCHORAGE_CROSS_SECTION_DIFFERENCE;

                CrossSectionWidthTextBox.Text =
                    _waveguideParameters.CrossSectionWidth.ToString();
                AnchorageHeightTextBox.Text =
                    _waveguideParameters.AnchorageHeight.ToString();
                AnchorageWidthTextBox.Text =
                    _waveguideParameters.AnchorageWidth.ToString();
            }
            catch (Exception)
            {
                SetValidatingStyle(CrossSectionHeightTextBox);             
                e.Cancel = true;
            }
        }

        private void CrossSectionHeightTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(CrossSectionHeightTextBox);
        }

        private void DistanceAngleToHoleTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                _waveguideParameters.DistanceAngleToHole = 
                    double.Parse(DistanceAngleToHoleTextBox.Text);
            }
            catch (Exception)
            {
                SetValidatingStyle(DistanceAngleToHoleTextBox);
                e.Cancel = true;
            }
        }

        private void DistanceAngleToHoleTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(DistanceAngleToHoleTextBox);
        }
    }
}
