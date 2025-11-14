using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClientApp;
using ClientApp.Forms;

namespace AgentApp.Forms
{
    public class StartUpForm : Form
    {
        private Button btnAgent;
        private Button btnClient;
        private Button btnExit;
        private Random rand = new Random();

        public StartUpForm()
        {
            this.Text = "Welcome to Real Estate App";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(400, 250);
            this.BackColor = Color.Pink;

            // Agent button (white, round)
            btnAgent = new Button()
            {
                Text = "Agent",
                Location = new Point(50, 80),
                Size = new Size(120, 40),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAgent.Click += (s, e) =>
            {
                var agentForm = new AgentDashboardForm("AgentUser");
                agentForm.Show();
                this.Hide();
            };
            MakeButtonRound(btnAgent);

            // Client button (white, round)
            btnClient = new Button()
            {
                Text = "Client",
                Location = new Point(220, 80),
                Size = new Size(120, 40),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClient.Click += (s, e) =>
            {
                var loginForm = new ClientLoginForm();
                loginForm.Show();
                this.Hide();
            };
            MakeButtonRound(btnClient);

            // Exit button (red, heart shape)
            btnExit = new Button()
            {
                Text = "Exit",
                Location = new Point(140, 150),
                Size = new Size(120, 100), // taller for heart shape
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnExit.Click += (s, e) => Application.Exit();
            MakeButtonHeart(btnExit);

            Controls.Add(btnAgent);
            Controls.Add(btnClient);
            Controls.Add(btnExit);

            // Hook up Paint event for glitter
            this.Paint += StartUpForm_Paint;
        }

        private void MakeButtonRound(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            var path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        private void MakeButtonHeart(Button btn)
        {
            var path = new GraphicsPath();

            // Approximate heart shape with Bezier curves
            path.StartFigure();
            path.AddBezier(new Point(btn.Width / 2, btn.Height / 4),
                           new Point(btn.Width, 0),
                           new Point(btn.Width, btn.Height / 2),
                           new Point(btn.Width / 2, btn.Height));
            path.AddBezier(new Point(btn.Width / 2, btn.Height),
                           new Point(0, btn.Height / 2),
                           new Point(0, 0),
                           new Point(btn.Width / 2, btn.Height / 4));
            path.CloseFigure();

            btn.Region = new Region(path);
        }

        // Glitter effect
        private void StartUpForm_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 50; i++) // number of sparkles
            {
                int x = rand.Next(this.ClientSize.Width);
                int y = rand.Next(this.ClientSize.Height);
                int size = rand.Next(2, 6); // sparkle size

                using (Brush brush = new SolidBrush(Color.FromArgb(
                    rand.Next(200, 256), // brightness
                    255, 255, rand.Next(200, 256)))) // pastel sparkle
                {
                    e.Graphics.FillEllipse(brush, x, y, size, size);
                }
            }
        }
    }
}
