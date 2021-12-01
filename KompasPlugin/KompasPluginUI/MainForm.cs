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
            /*_waveguideParameters = new WaveguideParameters(double.Parse(AnchorageHeightTextBox.Text),
                double.Parse(AnchorageThicknessTextBox.Text),
                double.Parse(AnchorageWidthTextBox.Text),
                double.Parse(CrossSectionHeightTextBox.Text),
                double.Parse(CrossSectionThicknessTextBox.Text),
                double.Parse(AnchorageHeightTextBox.Text),
                double.Parse(DistanceAngleToHoleTextBox.Text),
                double.Parse(HoleDiametersTextBox.Text),
                double.Parse(RadiusCrossTieTextBox.Text),
                double.Parse(WaveguideLengthTextBox.Text));*/
            _waveguideParameters = new WaveguideParameters(90, 12,
                130, 40, 7, 80, 30,
                4, 3, 400);
        }

        private void HoleDiametersTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadiusCrossTieTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnchorageHeightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnchorageWidthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnchorageThicknessTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WaveguideLengthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrossSectionWidthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrossSectionThicknessTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrossSectionHeightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DistanceAngleToHoleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuildButton_Click(object sender, EventArgs e)
        {

        }
    }
}
