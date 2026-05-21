using System.Collections.ObjectModel;
using System.Windows;

namespace Lista;

public partial class MainWindow : Window
{
    public ObservableCollection<string> nomes { get; set; } = new();
    
    public MainWindow()
    {
        InitializeComponent();
        
        this.DataContext = this;
    }

    private void BtnAdicionaNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome valido!");
                return;
        }
        
        nomes.Add(tbNome.Text);
    }

    private void BtnRemoveNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (!nomes.Contains(tbNome.Text))
        {
            MessageBox.Show("Esse nome não está na lista!");
            return;
        }
        var nomeEncontrado = nomes.FirstOrDefault(nomePessoa => nomePessoa.Equals(tbNome.Text, StringComparison.CurrentCultureIgnoreCase));
        
        
        nomes.Remove(nomeEncontrado);
        MessageBox.Show("Nome removido com sucesso!");
    }

    private void BtnEncontrarNomes_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome valido!");
            return;
        }
        lbNomes.SelectedItems.Clear();
        string minusculo = tbNome.Text.ToLower();
        foreach (var nome in nomes)
        {
            if (nome.Contains(minusculo, StringComparison.CurrentCultureIgnoreCase))
            {
                lbNomes.SelectedItems.Add(nome);
            }
        }

    }
}