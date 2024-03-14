using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptology_Algorithms
{
    public partial class Form2 : Form
    {
        Algorithms algorithm;
        string input = " ";

        public Form2(Algorithms algorithm)
        {
            InitializeComponent();
            this.algorithm = algorithm;
        }

        private void handle_Click(object sender, EventArgs e)
        {
            State state = State.none;
            if ((Button)sender == button1)
            {
                state = State.encryption;
            }
            if ((Button)sender == button2)
            {
                state = State.decryption;
            }

            switch (algorithm)
            {
                case Algorithms.transposition:
                    HandleAlgorithm(algorithm, state);
                    break;
                case Algorithms.permutation_cipher:
                    HandleAlgorithm(algorithm, state);
                    break;
                case Algorithms.vigenere:
                    HandleAlgorithm(algorithm, state);
                    break;
                case Algorithms.caeser:
                    HandleAlgorithm(algorithm, state);
                    break;
                case Algorithms.zigzag:
                    HandleAlgorithm(algorithm, state);
                    break;

            }
        }


        public void HandleAlgorithm(Algorithms algorithm, State state)
        {
            RemoveSpaceCharacters();
            if (algorithm == Algorithms.transposition)
            {
                if (state == State.encryption)
                {
                    Transposition transposition = new Transposition();
                    string encryptedData = transposition.Encrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = encryptedData;
                }
                if (state == State.decryption)
                {
                    Transposition transposition = new Transposition();
                    string decryptedtedData = transposition.Decrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = decryptedtedData;
                }

            }
            if (algorithm == Algorithms.permutation_cipher)
            {
                if (state == State.encryption)
                {
                    PermutationCipher permutationCipher = new PermutationCipher();
                    string encryptedData = permutationCipher.Encrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = encryptedData;
                }
                if (state == State.decryption)
                {
                    PermutationCipher permutationCipher = new PermutationCipher();
                    string decryptedtedData = permutationCipher.Decrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = decryptedtedData;
                }
            }

            if (algorithm == Algorithms.vigenere)
            {
                if (state == State.encryption)
                {
                    Vigenere vigenere = new Vigenere();
                    string encryptedData = vigenere.Encrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = encryptedData;
                }
                if (state == State.decryption)
                {
                    Vigenere vigenere = new Vigenere();
                    string decryptedData = vigenere.Decrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = decryptedData;
                }
            }


            if (algorithm == Algorithms.caeser)
            {
                if (state == State.encryption)
                {
                    Caeser caeser = new Caeser();
                    string encryptedData = caeser.Encrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = encryptedData;
                }
                if (state == State.decryption)
                {
                    Caeser caeser = new Caeser();
                    string decryptedData = caeser.Decrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = decryptedData;
                }
            }

            if (algorithm == Algorithms.zigzag)
            {
                if (state == State.encryption)
                {
                    ZigZag zigzag = new ZigZag(input.Length);
                    string encryptedData = zigzag.Encrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = encryptedData;
                }
                if (state == State.decryption)
                {
                    ZigZag zigzag = new ZigZag(input.Length);
                    string decryptedData = zigzag.Decrypt(input.Trim());
                    textBox1.Clear();
                    textBox1.Text = decryptedData;
                }
            }


        }
        private void RemoveSpaceCharacters()
        {
            input = textBox1.Text.ToString();
            input = new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}
