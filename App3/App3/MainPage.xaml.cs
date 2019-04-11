using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3.Modelos;

namespace App3
{
	public partial class MainPage : ContentPage
	{
        // vetor de disciplinas
        Disciplina[] disciplinas = new Disciplina[4]
        {
            new Disciplina("Calc 1", 1),
            new Disciplina("Calc 2", 2),
            new Disciplina("Calc 3", 3),
            new Disciplina("Calc 4", 4)
        };
        // vetor de disciplinas
        Professor[] Professores = new Professor[4]
        {
            new Professor("Paulo", 1),
            new Professor("Arnaldo", 2),
            new Professor("Fantin", 3),
            new Professor("Andre", 4)
        };

        public MainPage()
		{
			InitializeComponent();
            foreach (Disciplina disciplina in disciplinas)
            {
                // adicionar um elemento na caixa de seleção
                Picker2.Items.Add(disciplina.semestre + " - " + disciplina.nome);
            }
            foreach (Professor professor in Professores)
            {
                // adicionar um elemento na caixa de seleção
                Picker1.Items.Add(professor.codigo + " - " + professor.nome);
            }
        }
        void OnButtonClicked(object sender, EventArgs args)
        {
            // desabilitar mensagens
            Label1.IsVisible = false;
            Label2.IsVisible = false;
            Label3.IsVisible = false;
            Label5.IsVisible = false;
            // verificar se período e semestre foram selecionados
            if (Entry1.Text != null &&
                Entry2.Text != null &&
                Entry1.Text.Length > 0 &&
                Entry2.Text.Length > 0 &&
                Picker1.SelectedIndex >= 0 &&
                Picker2.SelectedIndex >= 0 )
            {

                Nota nota = new Nota();
                nota.nome = Entry1.Text;
                nota.valor = int.Parse(Entry2.Text);

                

                if (disciplinas[Picker1.SelectedIndex].Lecionar(Professores[Picker2.SelectedIndex]))
                {
                    if(nota.Aprovar())
                    {
                        Label5.IsVisible = true;
                        Label4.Text = nota.nome;
                        Label1.IsVisible = true;
                    }
                    else
                    {
                        Label2.IsVisible = true;
                    }
                }
                else
                {
                    Label3.IsVisible = true;
                }
                
            }
            else
            {
                Label4.IsVisible = true;
            }


        }
    }
}
