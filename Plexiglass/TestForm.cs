using System.Windows.Forms;
using System.Drawing;

namespace Plexiglass
{
   public partial class TestForm : Form
   {
      public TestForm()
      {
         InitializeComponent();
      }

      private void btnAddOverlay_Click(object sender, System.EventArgs e)
      {
         Plexiglass Overlay = new Plexiglass(this, 0.85, 500, 200, Color.Cornsilk, null, "Loading ...");
      }
   }
}
