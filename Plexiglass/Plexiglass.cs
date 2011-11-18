using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plexiglass
{
   public class Plexiglass : Form
   {
      // Feature requests: change text after initialization, progressbar, etc.
      // Use as component? Need empty constructor then. Setup thereafter.

      private Form _toCover;
      private Form _notificationForm;
      private Label _label;
      private PictureBox _pictureBox;
      private readonly int _margin = 10;

      private Plexiglass()
      {
         BackColor = Color.DarkGray;
         FormBorderStyle = FormBorderStyle.None;
         ControlBox = false;
         ShowInTaskbar = false;
         StartPosition = FormStartPosition.Manual;
         AutoScaleMode = AutoScaleMode.None;
      }

      public Plexiglass(Form toCover, double opacity, int width, int height, Color boxColor, Image waitAnimation, string text)
         : this()
      {
         _toCover = toCover;
         Opacity = opacity;

         Location = CalculateOverlayLocation(_toCover);
         ClientSize = new Size(_toCover.Width - 6, _toCover.Height - SystemInformation.CaptionHeight - 6);

         _toCover.Move += new EventHandler(UpdateLocation);

         AddNotificationBox(width, height, boxColor, waitAnimation, text);

         Show(_toCover);
         Enabled = false; // Needs to be set after Show()
      }

      //public Plexiglass(Form toCover, Size size, double opacity, int width, int height, Color boxColor, Image waitAnimation, string text)
      //   : this()
      //{
      //   _toCover = toCover;
      //   Opacity = opacity;

      //   Location = CalculateOverlayLocation(_toCover);
      //   ClientSize = new Size(size.Width, size.Height);

      //   _toCover.Move += new EventHandler(UpdateLocation);

      //   AddNotificationBox(width, height, boxColor, waitAnimation, text);

      //   Show(_toCover);
      //   Enabled = false; // Needs to be set after Show()
      //}

      private Point CalculateOverlayLocation(Form form)
      {
         // Not really sure why location is set outside actually control drawing surface.
         return new Point(form.Location.X + 3, form.Location.Y + SystemInformation.CaptionHeight + 3);
         //return new Point(form.ClientRectangle.X, form.ClientRectangle.Y);
      }

      private void AddNotificationBox(int width, int height, Color boxColor, Image waitAnimation, string text)
      {
         // Put a new form without transperacy on top of transparent overlay form.
         _notificationForm = new Form();
         _notificationForm.BackColor = boxColor;
         _notificationForm.FormBorderStyle = FormBorderStyle.None;
         _notificationForm.ControlBox = false;
         _notificationForm.ShowInTaskbar = false;
         _notificationForm.StartPosition = FormStartPosition.Manual;
         _notificationForm.AutoScaleMode = AutoScaleMode.None;
         _notificationForm.Size = new Size(width, height);
         _notificationForm.Location = new Point(
                                         Location.X + (Size.Width / 2) - (width / 2),
                                         Location.Y + (Size.Height / 2) - (height / 2)
                                      );
         Move += new EventHandler(UpdateLocationNotificationForm);

         // Add wait animation.
         if (waitAnimation != null)
         {
            _pictureBox = new PictureBox();
            _pictureBox.Image = waitAnimation;
            _pictureBox.Size = new Size(_pictureBox.Image.Width, _pictureBox.Image.Height);
            _pictureBox.Location = new Point(_margin, _margin);
            _notificationForm.Controls.Add(_pictureBox);
         }

         // Add notification box text
         _label = new Label();
         _label.Name = "NotificationBoxText";
         _label.ForeColor = Color.Black;
         //_label.BackColor = Color.Pink; // TESTING
         _label.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         _label.TextAlign = ContentAlignment.MiddleCenter;
         if (waitAnimation != null)
         {
            _label.Size = new Size(width - _margin * 2, height - _pictureBox.Image.Height - _margin * 3);
            _label.Location = new Point(_margin, _pictureBox.Image.Height + _margin * 2);

         }
         else
         {
            _label.Size = new Size(width - _margin * 2, height - _margin * 2);
            _label.Location = new Point(_margin, _margin);
         }
         _label.MaximumSize = _label.Size;
         _label.Text = text;
         _notificationForm.Controls.Add(_label);

         _notificationForm.Show(this);
         //_notificationForm.Enabled = false; // FIXME: If not enabled the animation won't run.
      }

      public void Terminate()
      {
         _notificationForm.Close();
         _notificationForm.Dispose();
         Move -= UpdateLocationNotificationForm;
         Close();
         Dispose();
      }

      /// <summary>
      /// A event handler method for updating position of form overlay when parent form is moving. 
      /// Hooks on to the Move event.
      /// </summary>
      /// <param name="sender">Event sender.</param>
      /// <param name="eventArgs">Event arguments.</param>
      private void UpdateLocation(object sender, EventArgs eventArgs)
      {
         Location = CalculateOverlayLocation(_toCover);
      }

      private void UpdateLocationNotificationForm(object sender, EventArgs eventArgs)
      {
         _notificationForm.Location = new Point(
                                         Location.X + (Size.Width / 2) - (_notificationForm.Size.Width / 2),
                                         Location.Y + (Size.Height / 2) - (_notificationForm.Size.Height / 2)
                                      );
      }
   }
}