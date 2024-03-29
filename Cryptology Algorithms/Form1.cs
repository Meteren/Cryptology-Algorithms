namespace Cryptology_Algorithms
{
    public partial class Form1 : Form
    {
        Algorithms algorithm;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Algorithms";

        }

        private void transposition_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.transposition;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Transposition";
            enDecScreen.ShowDialog();
        }

        private void permutation_CLick(object sender, EventArgs e)
        {
            algorithm = Algorithms.permutation_cipher;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Permutation";
            enDecScreen.ShowDialog();
        }

        private void vigenere_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.vigenere;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Vigenere";
            enDecScreen.ShowDialog();
        }

        private void caeser_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.caeser;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Ceaser";
            enDecScreen.ShowDialog();
        }

        private void zig_zag_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.zigzag;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Zig Zag";
            enDecScreen.ShowDialog();
        }

        private void lineer_affine_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.lineer_affine;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Lineer Affine";
            enDecScreen.ShowDialog();
        }

        private void four_square_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.four_square;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Four Square";
            enDecScreen.ShowDialog();
        }

        private void route_Click(object sender, EventArgs e)
        {
            algorithm = Algorithms.route;
            Form2 enDecScreen = new Form2(algorithm);
            enDecScreen.Text = "Route";
            enDecScreen.ShowDialog();
        }
    }
}