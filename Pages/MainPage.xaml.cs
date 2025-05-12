using MauiAppJogoDaVelha.Models;
using MauiAppJogoDaVelha.PageModels;

namespace MauiAppJogoDaVelha.Pages
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Impede jogada em botão já clicado
            if (!string.IsNullOrEmpty(btn.Text))
                return;

            // Define o texto conforme a vez atual
            btn.Text = vez;

            // Verifica vitória
            if (VerificarVitoria("X"))
            {
                DisplayAlert("Parabéns!", "O X ganhou!", "OK");
                Zerar();
                return;
            }
            else if (VerificarVitoria("O"))
            {
                DisplayAlert("Parabéns!", "O ganhou!", "OK");
                Zerar();
                return;
            }

            // Verifica empate
            if (TodosPreenchidos() && !VerificarVitoria("X") && !VerificarVitoria("O"))
            {
                DisplayAlert("Empate!", "Deu velha!", "OK");
                Zerar();
                return;
            }

            // Alterna a vez
            vez = vez == "X" ? "O" : "X";
        }

        private bool VerificarVitoria(string jogador)
        {
            return
                (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) ||
                (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) ||
                (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) ||

                (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) ||
                (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) ||
                (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) ||

                (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) ||
                (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador);
        }

        private bool TodosPreenchidos()
        {
            return
                !string.IsNullOrEmpty(btn10.Text) &&
                !string.IsNullOrEmpty(btn11.Text) &&
                !string.IsNullOrEmpty(btn12.Text) &&
                !string.IsNullOrEmpty(btn20.Text) &&
                !string.IsNullOrEmpty(btn21.Text) &&
                !string.IsNullOrEmpty(btn22.Text) &&
                !string.IsNullOrEmpty(btn30.Text) &&
                !string.IsNullOrEmpty(btn31.Text) &&
                !string.IsNullOrEmpty(btn32.Text);
        }

        private void Zerar()
        {
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";
            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";
            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";

            vez = "X";
        }

        private void NovoJogo_Clicked(object sender, EventArgs e)
        {
            Zerar();
        }
    }
}
